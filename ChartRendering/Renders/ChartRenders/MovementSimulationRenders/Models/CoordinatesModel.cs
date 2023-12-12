using System.Collections.Generic;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.Models;

public class CoordinatesModel
{
	public double t { get; set; }

	public List<double> x { get; set; }

	public List<double> y { get; set; }
}