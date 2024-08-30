using System.Collections.Generic;

namespace ChartRendering.Models;

public class TrafficLightsParameters
{
	public List<double> TrafficLightsGreenTime { get; set; }
	
	public List<double> TrafficLightsRedTime { get; set; }
	
	public List<double> TrafficLightsPosition { get; set; }
}