using System.Collections.Generic;

namespace ChartRendering.Models;

public class CoordinatesArgs
{
	public double T { get; set; }

	public List<double> X { get; set; }

	public List<double> Y { get; set; }
}