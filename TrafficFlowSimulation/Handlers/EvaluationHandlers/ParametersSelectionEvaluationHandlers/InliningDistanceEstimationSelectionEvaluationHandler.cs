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
		progressBarHelper.SetMaximum((int)settings.MaximumDistanceBetweenCars);
		var spinningLabelHelper = new SpinningLabelHelper(form);
		spinningLabelHelper.StartSpinning();

		Task.Factory.StartNew(() =>
		{
			var coordinatesModel = EvaluateInternal((ModelParameters)modelParameters.Clone(), settings, progressBarHelper);

			MethodInvoker action = delegate
			{
				ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(coordinatesModel);
			};

			p.Form.Invoke(action);
		}, TaskCreationOptions.None);

		if (((ComboBoxItem)settings.IsParametersEvaluated).Value.Equals(EvaluateParameters.Yes))
		{
			var tasks = new List<TaskModel>();
			for (var k = 0.1; k < 1; k += 0.1)
			{
				var mp = (ModelParameters)modelParameters.Clone();
				mp.k = new List<double> {k, k};

				var task = new Task<List<InliningDistanceEstimationCoordinatesModel>>(
						() => EvaluateInternal(mp, settings));
				tasks.Add(new TaskModel
				{
					ModelParameters = mp,
					Task = task
				});

				task.Start();
			}

			while (tasks.Count != 0)
			{
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
				var index = Task.WaitAny(tasks.Select(x => x.Task).ToArray());

				Helper.GenerateCharts(tasks[index].ModelParameters, tasks[index].Task.Result);
				tasks.RemoveAt(index);
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
			}
			spinningLabelHelper.StopSpinning();
		}
	}

	private List<InliningDistanceEstimationCoordinatesModel> EvaluateInternal(ModelParameters modelParameters, InliningDistanceEstimationSettingsModel modeSettings, ProgressBarHelper? progressBarHelper = null)
	{
		var cm = new List<InliningDistanceEstimationCoordinatesModel>();

		var min = 0.0;
		var max = Math.Floor(modelParameters.Vmax[1]) + 1;
		var step = 2;
		for (double space = 0; space <= modeSettings.MaximumDistanceBetweenCars; space+=step)
		{
			progressBarHelper?.Update((int) space);

			var intensityChange = false;
			if (space <= modelParameters.lCar[0] + modelParameters.lSafe[1])
			{
				for (var i = min; i <= max; i += step)
				{
					Helper.AddCoordinates(modelParameters, cm, space, i, -1);
					if (i == min)
					{
						cm.Last().IsIntensityChange = true;
					}
				}
				continue;
			}

			var topSolution = IsDecelerate(modelParameters, space, max);
			if (topSolution.IsDeceleration == false)
			{
				for (var i = min; i <= max; i += step)
				{
					Helper.AddCoordinates(modelParameters, cm, space, i, 0);
				}
				cm.Last().IsIntensityChange = true;
				continue;
			}

			var bottomSolution = IsDecelerate(modelParameters, space, min);

			Helper.AddCoordinates(modelParameters, cm, space, max, topSolution.Intensity);
			Helper.AddCoordinates(modelParameters, cm, space, min, bottomSolution.Intensity);

			for (var i = min + step; i < max; i += step)
			{
				var solution = IsDecelerate(modelParameters, space, i);

				if (!intensityChange && solution.IsDeceleration)
				{
					cm.Last().IsIntensityChange = true;
					intensityChange = true;
				}

				Helper.AddCoordinates(modelParameters, cm, space, i, solution.Intensity);
			}
		}

		return cm;
	}

	private DecelerationEvaluation IsDecelerate(ModelParameters modelParameters, double space, double speed)
	{
		var r = new RungeKuttaMethod(modelParameters, new BaseEquation(modelParameters));
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

		var eps = 0.1;

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

			if (double.IsNaN(x[1]) || double.IsNaN(y[1]))
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = true,
					Intensity = -1
				};
			}

			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
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