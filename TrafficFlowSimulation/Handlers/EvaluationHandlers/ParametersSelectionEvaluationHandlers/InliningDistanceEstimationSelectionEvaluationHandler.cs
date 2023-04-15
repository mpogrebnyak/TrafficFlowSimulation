using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;
using TrafficFlowSimulation.Windows.CustomControls;
using TrafficFlowSimulation.Windows.Helpers;
using Helper = TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers.InliningDistanceEstimationSelectionEvaluationHelper;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 2)
			return;

		var settings = (InliningDistanceEstimationSettingsModel) p.ModeSettings;
		var form = p.Form;
		var progressBarHelper = new ProgressBarHelper(form);

		if (((ComboBoxItem) settings.IsParametersEvaluated).Value.Equals(EvaluateParameters.No))
		{
			progressBarHelper.SetMaximum((int) settings.MaximumDistanceBetweenCars);

			Task.Factory.StartNew(() =>
			{
				var coordinatesModel = EvaluateInternal((ModelParameters) modelParameters.Clone(), settings, progressBarHelper);

				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(coordinatesModel);
				};

				p.Form.Invoke(action);
			}, TaskCreationOptions.None);
		}
		else
		{
			var spinningLabelHelper = new SpinningLabelHelper(form);
			spinningLabelHelper.StartSpinning();

			var tasks = new List<TaskModel>();
			for (var k = 0.11; k < 0.15; k += 0.01)
			//for (var k = 1.0; k < 1.1; k += 0.1)
			{
				var mp = (ModelParameters)modelParameters.Clone();
				mp.k = new List<double> {k, k};

				var task = new Task<List<InliningDistanceEstimationCoordinatesModel>>(() => EvaluateInternal(mp, settings, progressBarHelper));
				tasks.Add(new TaskModel
				{
					ModelParameters = mp,
					Task = task
				});
			}

			progressBarHelper.SetMaximum((int) settings.MaximumDistanceBetweenCars * tasks.Count);

			tasks.ForEach(x => x.Task.Start());

			var result = new Dictionary<double, List<InliningDistanceEstimationCoordinatesModel>>();
			while (tasks.Count != 0)
			{
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
				var index = Task.WaitAny(tasks.Select(x => x.Task).ToArray());

				result.Add(tasks[index].ModelParameters.k.First(), tasks[index].Task.Result);

				Helper.GenerateCharts(tasks[index].ModelParameters, tasks[index].Task.Result);
				Helper.SavePoints(tasks[index].ModelParameters, settings, tasks[index].Task.Result);
				tasks.RemoveAt(index);
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
			}
			spinningLabelHelper.StopSpinning();

			if (result.ContainsKey(modelParameters.k.First()))
			{
				var resultCoordinates = result[modelParameters.k.First()];

				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(resultCoordinates);
				};

				p.Form.Invoke(action);
			}
		}
	}

	protected override void EvaluatePreCalculated(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var preCalculatedParameters = (List<InliningDistanceEstimationCoordinatesModel>) p.PreCalculatedParameters;

		Helper.GenerateCharts(modelParameters, preCalculatedParameters);

		MethodInvoker action = delegate
		{
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(preCalculatedParameters);
		};

		p.Form.Invoke(action);
	}

	private List<InliningDistanceEstimationCoordinatesModel> EvaluateInternal(ModelParameters modelParameters, InliningDistanceEstimationSettingsModel modeSettings, ProgressBarHelper? progressBarHelper = null)
	{
		var cm = new List<InliningDistanceEstimationCoordinatesModel>();

		var min = 0.0;
		var max = Math.Floor(modelParameters.Vmax[1]) + 1;
		var step = 0.05;
		//var step = 0.1; 
		for (double space = 0; space <= modeSettings.MaximumDistanceBetweenCars; space+=step)
		//for (double space = 5.5; space <= 6; space+=step)
		{
			progressBarHelper?.Update(step);

			if (space <= modelParameters.lCar[0] + modelParameters.lSafe[1])
			{
				for (var i = max; i >= min; i -= step)
				{
					Helper.AddCoordinates(modelParameters, cm, space, i, -1);
				}

				cm.Last().IsIntensityChangedToZero = true;
				continue;
			}

			var topSolution = IsDecelerate(modelParameters, space, max);
			if (topSolution.IsDeceleration == false)
			{
				for (var i = max; i >= min; i -= step)
				{
					Helper.AddCoordinates(modelParameters, cm, space, i, 0);
				}

				cm.First().IsIntensityChangedToZero = true;
				continue;
			}

			var bottomSolution = IsDecelerate(modelParameters, space, min);

			Helper.AddCoordinates(modelParameters, cm, space, max, topSolution.Intensity);
			Helper.AddCoordinates(modelParameters, cm, space, min, bottomSolution.Intensity);

			for (var i = max; i >= min; i -= step)
			{
				var solution = IsDecelerate(modelParameters, space, i);

				if (!solution.IsDeceleration)
				{
					cm.Last().IsIntensityChangedToZero = true;
					for (var j = i; j >= min; j -= step)
					{
						Helper.AddCoordinates(modelParameters, cm, space, j, 0);
					}
					break;
				}

				Helper.AddCoordinates(modelParameters, cm, space, i, solution.Intensity);
			}
		}

		return cm;
	}

	private DecelerationEvaluation IsDecelerate(ModelParameters modelParameters, double space, double speed)
	{
		var r = new RungeKuttaMethod(modelParameters, new MainEquation(modelParameters));
		r.SetInitialConditions(
			new List<double> {modelParameters.Vn[0], speed},
			new List<double> {modelParameters.lambda[0], -space});

		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var x = new double[n];
		var y = new double[n];
		for (int i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		var localMax = modelParameters.Vmax[1];
		double localMin = 0;
		double diff = 0;
		var isDeceleration = false;

		while (true)
		{
			for (int i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();

			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			if (xp[1] > x[1] || x[0] < x[1])// || double.IsNaN(x[1]) || double.IsNaN(y[1]))
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = true,
					Intensity = -1
				};
			}

			if (double.IsNaN(x[1]) || double.IsNaN(y[1]))
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = true,
					Intensity = -1
				};
			}

			if (y[1] > yp[1])
			{
				if (isDeceleration)
				{
					diff = Math.Max(diff, localMax - localMin);
					isDeceleration = false;
				}

				localMax = y[1];
			}
			else
			{
				localMin = y[1];
				isDeceleration = true;
			}

			//var eps = 0.1;
			const int eps = 1;
			if (modelParameters.Vmax[0] - y[0] < eps && modelParameters.Vmax[1] - y[1] < eps)
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = diff > eps,
					Intensity = diff > eps
						? diff
						: 0
				};
			}

		}
	}

	private class DecelerationEvaluation
	{
		public bool IsDeceleration { get; set; }

		public double Intensity { get; set; }
	}

	private class TaskModel
	{
		public ModelParameters ModelParameters { get; set; }

		public Task<List<InliningDistanceEstimationCoordinatesModel>> Task { get; set; }
	}
}