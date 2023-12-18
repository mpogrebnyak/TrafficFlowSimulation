using System.Collections.Generic;

namespace ChartRendering.Models;

public class CoordinatesArgs
{
	public double t { get; set; }

	public List<double> x { get; set; }

	public List<double> y { get; set; }
}