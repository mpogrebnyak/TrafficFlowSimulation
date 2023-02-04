﻿namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

public class AccelerationCoefficientEnvironmentModel
{
	public double? MinAValue { get; set; }

	public double? MaxAValue { get; set; }

	public AccelerationCoefficientEnvironmentModel()
	{
		MinAValue = null;
		MaxAValue = null;
	}
}