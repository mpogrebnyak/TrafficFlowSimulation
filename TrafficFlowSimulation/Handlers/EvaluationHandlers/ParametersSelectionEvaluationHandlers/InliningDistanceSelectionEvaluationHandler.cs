using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 2)
			return;

		var r = new RungeKuttaMethod(modelParameters, new BaseEquation(modelParameters));
		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var t = r.T.Last();
		var tp = t;
		var x = new double[n];
		var y = new double[n];
		for (int i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		var eps = 0.0001;
		var xPoints = new List<double>();
		var yPoints = new List<double>();

		var continueCalculating = true;
		while (continueCalculating)
		{
			for (int i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();
			t = r.T.Last();
			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			if (t - tp > 0.1)
			{
				tp = t;

				xPoints.Add(x[0] - x[1]);
				yPoints.Add(y[0] - y[1]);

				if (y[0] >= modelParameters.Vmax[0] - eps && y[1] >= modelParameters.Vmax[1] - eps)
					continueCalculating = false;
			}
		}

		MethodInvoker action = delegate
		{
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(xPoints, yPoints);

			Application.DoEvents();
		};

		p.Form.Invoke(action);
	}
}