using System.Collections.Generic;

namespace ChartRendering.Models;

public class MultipleTrafficLightsEnvironmentArgs : EnvironmentArgsBase
{
	public List<SingleTrafficLight> TrafficLight { get; set; }
}

public class SingleTrafficLight
{
	public bool IsGreenLight { get; set; }

	public double Time { get; set; } 
}