namespace ChartRendering.Models;

public class SingleTrafficLightsEnvironmentArgs : EnvironmentArgsBase
{
	public bool IsGreenLight { get; set; }

	public double Time { get; set; }
}