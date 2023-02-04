﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class AccelerationCoefficientEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 1)
			return;

		var settings = (AccelerationCoefficientEstimationSettingsModel) p.ModeSettings;

		var cm = new List<AccelerationCoefficientEstimationCoordinatesModel>();
		var em = new AccelerationCoefficientEnvironmentModel();

		var step = 0.001;
		for (var a = step; a <= settings.MaxA; a += step)
		{
			var previousCoordinatesModel = cm.LastOrDefault();

			var mp = (ModelParameters)modelParameters.Clone();
			mp.a = new List<double> {a};

			var coordinatesModel = EvaluateInternal(mp);
			cm.Add(coordinatesModel);

			if (previousCoordinatesModel != null && previousCoordinatesModel.Color != coordinatesModel.Color)
			{
				em.MaxAValue = em.MinAValue.HasValue && !em.MaxAValue.HasValue
					? coordinatesModel.X
					: null;
				em.MinAValue ??= coordinatesModel.X;
			}
		}

		AccelerationCoefficientEstimationSelectionEvaluationHelper.GenerateCharts(modelParameters, cm, em); 

		MethodInvoker action = delegate
		{
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(cm);
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChartEnvironments(em);
		};

		p.Form.Invoke(action);
	}

	private AccelerationCoefficientEstimationCoordinatesModel EvaluateInternal(ModelParameters modelParameters)
	{
		var r = new RungeKuttaMethod(modelParameters, new SingleCarAccelerationEquation(modelParameters));
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

		while (y[0] <= Math.Floor(modelParameters.Vmax[0]))
		{
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

		return new AccelerationCoefficientEstimationCoordinatesModel
		{
			X = modelParameters.a[0],
			Y = t,
			Color = t >= 5 && t <= 15
				? CustomColors.Green
				: CustomColors.BrightRed
		};
	}
}