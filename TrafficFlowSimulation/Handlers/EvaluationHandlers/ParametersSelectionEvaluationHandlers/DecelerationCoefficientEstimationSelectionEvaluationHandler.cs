using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;
using TrafficFlowSimulation.Windows.CustomControls;
using TrafficFlowSimulation.Windows.Helpers;
using Helper = TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers.DecelerationCoefficientEstimationSelectionEvaluationHelper;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class DecelerationCoefficientEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 1)
			return;

		var settings = (DecelerationCoefficientEstimationSettingsModel) p.ModeSettings;
		var isParametersEvaluated = ((ComboBoxItem) settings.IsParametersEvaluated).Value.Equals(EvaluateParameters.Yes);

		var cm = new List<DecelerationCoefficientEstimationCoordinatesModel>();
		double? optimalQ = null;
		var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);

		var step = 0.01;
		for (var q = step; q <= settings.MaxQ; q += step)
		{
			var mp = (ModelParameters)modelParameters.Clone();
			mp.q = new List<double> {q};

			var coordinatesModel = EvaluateInternal(mp);

			if(coordinatesModel.IsCollapse)
				continue;

			cm.Add(coordinatesModel);

			if (coordinatesModel.Y <= tStop && !optimalQ.HasValue)
			{
				optimalQ = coordinatesModel.X;
				coordinatesModel.Color = CustomColors.Green;
			}
		}

		MethodInvoker action = delegate
		{
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(cm);
			if (optimalQ.HasValue)
			{
				ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChartEnvironments(optimalQ);
			}
		};
		p.Form.Invoke(action);

		if (isParametersEvaluated)
		{ 
			//ParametersEvaluation(p);
		}

	}

	private void ParametersEvaluation(Parameters parameters)
	{
		var modelParameters = parameters.ModelParameters;
		var settings = (DecelerationCoefficientEstimationSettingsModel)parameters.ModeSettings;
		var form = parameters.Form;

		var spinningLabelHelper = new SpinningLabelHelper(form);
		spinningLabelHelper.StartSpinning();

		var tasks = new List<TaskModel>();
		for (var v = 15.0; v <= 30; v += 1)
		{
			var mp = (ModelParameters) modelParameters.Clone();
			mp.Vn = new List<double> {v};
			mp.L = System.Math.Pow(v, 2) / (2 * mp.g * mp.mu) + mp.lSafe[0];
			var task = CreateTask(Keys.VKey, mp);

			tasks.Add(new TaskModel
			{
				Key = Keys.VKey,
				ModelParameters = mp,
				Task = task
			});

			task.Start();
		}

		var eee = new List<PointF>();
		while (tasks.Count != 0)
		{
			spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
			var index = Task.WaitAny(tasks.Select(x => x.Task).ToArray());

			switch (tasks[index].Key)
			{
				case Keys.VKey:
				{
					eee.Add(new PointF
					{
						X = (float) tasks[index].ModelParameters.Vn[0],
						Y = (float) tasks[index].Task.Result
					});
					break;
				}
				case "mu":
				{
					break;
				}
			}
		//	Helper.GenerateCharts(tasks[index].ModelParameters, tasks[index].Task.Result);
			tasks.RemoveAt(index);
			spinningLabelHelper.UpdateSpinningToolTip(tasks.Count);
		}

		Helper.GenerateCharts(modelParameters, eee);

		spinningLabelHelper.StopSpinning();
	}

	private DecelerationCoefficientEstimationCoordinatesModel EvaluateInternal(ModelParameters modelParameters)
	{
		var r = new RungeKuttaMethod(modelParameters, new SingleCarDecelerationEquation(modelParameters));
		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var t = r.T.Last();
		var x = new double[n];
		var y = new double[n];
		for (var i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		while (y[0] >= 0.01)
		{
			if (modelParameters.L - x[0] < 0.001)
			{ 
				return new DecelerationCoefficientEstimationCoordinatesModel
				{
					IsCollapse = true
				};
			}

			for (var i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();
			for (var i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}
			t = r.T.Last();
		}
		
		if (y[0] < 0)
		{ 
			return new DecelerationCoefficientEstimationCoordinatesModel
			{
				IsCollapse = true
			};
		}

		return new DecelerationCoefficientEstimationCoordinatesModel
		{
			X = modelParameters.q[0],
			Y = t,
			Color = CustomColors.Black,
			IsCollapse = false
		};
	}

	private Task<double?> CreateTask(string key, ModelParameters modelParameters)
	{
		return new Task<double?>(() =>
		{
			var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);

			for (var q = 0.1; q <= 1; q += 0.01)
			{
				var mp = (ModelParameters) modelParameters.Clone();
				mp.q = new List<double> {q};

				var coordinatesModel = EvaluateInternal(mp);
				if(coordinatesModel.IsCollapse)
					continue;

				if (coordinatesModel.Y >= tStop)
				{
					return q;
				}
			}

			return 0;
		});
	}

	private static class Keys
	{
		public const string VKey = "VKey";

		public const string MuKey = "MuKey";
	}

	private class TaskModel
	{
		public string Key { get; set; }

		public double Q { get; set; }

		public ModelParameters ModelParameters { get; set; }

		public Task<double?> Task { get; set; }
	}
}