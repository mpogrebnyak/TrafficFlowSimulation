namespace ChartRendering.Models;

public class EnvironmentArgs : EnvironmentArgsBase
{
	public bool IsGreenLight { get; set; }

	public double GreenTime { get; set; }

	public double RedTime { get; set; }
}