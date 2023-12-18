namespace ChartRendering.Models;

public class DecelerationCoefficientEnvironmentModel
{
	public double StopTime { get; set; }
	public double? OptimalQ { get; set; }

	public double OptimalTime { get; set; }
	public double? DoubleOptimalQ { get; set; }

	public double DoubleOptimalTime { get; set; }

	public DecelerationCoefficientEnvironmentModel()
	{
		OptimalQ = null;
		DoubleOptimalQ = null;
	}
}