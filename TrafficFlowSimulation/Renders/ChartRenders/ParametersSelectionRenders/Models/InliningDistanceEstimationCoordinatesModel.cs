using System.Drawing;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

public enum PointColor
{
	Green,
	Red
}

public class InliningDistanceEstimationCoordinatesModel
{
	public double x { get; set; }

	public double y { get; set; }

	public PointColor color { get; set; }
}