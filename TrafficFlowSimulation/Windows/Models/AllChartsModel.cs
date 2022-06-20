using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Windows.Models;

public class AllChartsModel
{
	public Chart SpeedChart { get; set; }

	public Chart DistanceChart { get; set; }

	public Chart CarsMovementChart { get; set; }
}