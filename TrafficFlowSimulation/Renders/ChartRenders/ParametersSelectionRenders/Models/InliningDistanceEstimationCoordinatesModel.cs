﻿using System.Drawing;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

public class InliningDistanceEstimationCoordinatesModel
{
	public double X { get; set; }

	public double Y { get; set; }

	public Color Color { get; set; }

	public bool IsIntensityChange { get; set; }
}