using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Helper = ChartRendering.Helpers.InliningDistanceEstimationSelectionEvaluationHelper;

namespace ChartRendering.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 2)
			return;

		var settings = (InliningDistanceEstimationSettingsModel) p.ModeSettings;
		//var form = p.Form;
		/*var progressBarHelper = new ProgressBarHelper(form);

		if (((ComboBoxItem) settings.IsParametersEvaluated).Value.Equals(EvaluateParameters.No))
		{
			progressBarHelper.SetMaximum((int) settings.MaximumDistanceBetweenCars);

			Task.Factory.StartNew(() =>
			{
				EvaluateInternal((ModelParameters) modelParameters.Clone(), settings, progressBarHelper);

				var filePath = Helper.CreatePointsFile(modelParameters.k[1]);
				var pointsModel = SerializerPointsHelper.DeserializePoints(filePath);

				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(pointsModel.CoordinatesModel);
				};

				p.Form.Invoke(action);
			}, TaskCreationOptions.None);
		}
		else
		{
			var spinningLabelHelper = new SpinningLabelHelper(form);
			spinningLabelHelper.StartSpinning();

			var tasks = new List<TaskModel>();
			for (var k = 2.0; k < 2.1; k += 0.1)
			{
				var mp = (ModelParameters)modelParameters.Clone();
				mp.k = new List<double> {k, k};

				var task = new Task(() => EvaluateInternal(mp, settings, progressBarHelper));
				tasks.Add(new TaskModel
				{
					ModelParameters = mp,
					Task = task
				});
			}

			progressBarHelper.SetMaximum((int) settings.MaximumDistanceBetweenCars * tasks.Count);

			tasks.ForEach(x => x.Task.Start());
			var firstK = tasks.First().ModelParameters.k.First();

			while (tasks.Count != 0)
			{
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
				var index = Task.WaitAny(tasks.Select(x => x.Task).ToArray());

				tasks.RemoveAt(index);
				spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
			}
			spinningLabelHelper.StopSpinning();

			var filePath = Helper.CreatePointsFile(firstK);
			var pointsModel = SerializerPointsHelper.DeserializePoints(filePath);

			MethodInvoker action = delegate
			{ 
				ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(pointsModel.CoordinatesModel);
			};

			p.Form.Invoke(action);
		}
		*/
	}

	protected override void EvaluatePreCalculated(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var preCalculatedParameters = (List<InliningDistanceEstimationCoordinatesModel>) p.PreCalculatedParameters;

		MethodInvoker action = delegate
		{ 
			//ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(preCalculatedParameters);
		};

		//p.Form.Invoke(action);

		var filePath = Helper.CreatePointsFile(modelParameters.k[1]);
		Helper.GenerateCharts(filePath);
	}

/*	private void EvaluateInternal(ModelParameters modelParameters, InliningDistanceEstimationSettingsModel modeSettings, ProgressBarHelper? progressBarHelper = null)
	{
		var filePath = Helper.CreatePointsFile(modelParameters.k[1]);

		var step = 0.05;
		if (Helper.TryGetLastValue(filePath, out var initialSpace))
		{
			if (step >= modeSettings.MaximumDistanceBetweenCars)
				return;

			initialSpace -= step;
			progressBarHelper?.Update(initialSpace);
		}
		else
		{
			Helper.SavePoints(filePath, modelParameters, modeSettings);
		}

		var min = 0;
		var max = Math.Floor(modelParameters.Vmax[1]) + 1;

		for (double space = initialSpace + step; space <= modeSettings.MaximumDistanceBetweenCars; space+=step)
		{
			var cm = new List<InliningDistanceEstimationCoordinatesModel>();

			progressBarHelper?.Update(step);

			if (space <= modelParameters.lCar[0] + modelParameters.lSafe[1])
			{
				for (var i = max; i >= min; i -= step)
				{
					Helper.AddCoordinates(i, cm, space, i, -1);
				}

				Helper.SavePoints(filePath, cm, space);
				continue;
			}

			var topSolution = IsDecelerate(modelParameters, space, max);
			if (topSolution.IsDeceleration == false)
			{
				for (var i = max; i >= min; i -= step)
				{
					Helper.AddCoordinates(i, cm, space, i, 0);
				}

				cm.First().IsIntensityChangedToZero = true;
				Helper.SavePoints(filePath, cm, space);
				continue;
			}

			Helper.AddCoordinates(max, cm, space, max, topSolution.Intensity);
			Helper.AddCoordinates(max, cm, space, min, 0);

			for (var i = max-step; i >= min+step; i -= step)
			{
				if (i < step)
					i = 0;

				var solution = IsDecelerate(modelParameters, space, i);
				Helper.AddCoordinates(i, cm, space, i, solution.Intensity);

				if (!solution.IsDeceleration)
				{
					cm.Last().IsIntensityChangedToZero = true;
					for (var j = i-step; j >= min+step; j -= step)
					{
						Helper.AddCoordinates(j, cm, space, j, 0);
					}
					break;
				}
			}

			if (!cm.Any(x => x.IsIntensityChangedToZero))
			{
				cm.Last().IsIntensityChangedToZero = true;
			}

			Helper.SavePoints(filePath, cm, space);
		}

		Helper.GenerateCharts(filePath);
	}*/

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

		var localMax = speed;
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
			var t = r.T.Last();

			if (t > 0.2)
			{
				var q = 0;
			}
			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			if (xp[1] > x[1] || 
				x[0] - x[1] < modelParameters.lCar[0] + modelParameters.lSafe[1] + 1 ||
				double.IsNaN(x[1]) ||
				double.IsNaN(y[1]))
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = true,
					Intensity = -1
				};
			}

			if (y[1] > yp[1] && y[1] - yp[1] > 0.0001)
			{
				var qq = y[1] - yp[1];
				if (isDeceleration)
				{
					diff = Math.Max(diff, localMax - localMin);
					if (diff > speed)
						diff = speed;
					isDeceleration = false;
				}

				localMax = y[1];
			}
			else
			{
				localMin = y[1];
				isDeceleration = true;
			}

			const double eps = 0.1;
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

		public Task Task { get; set; }
	}
}