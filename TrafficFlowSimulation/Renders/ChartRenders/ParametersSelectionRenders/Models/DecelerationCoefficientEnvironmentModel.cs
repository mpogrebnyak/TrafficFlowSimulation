namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

public class DecelerationCoefficientEnvironmentModel
{
	public double? OptimalQ { get; set; }

	public double? DoubleOptimalQ { get; set; }

	public DecelerationCoefficientEnvironmentModel()
	{
		OptimalQ = null;
		DoubleOptimalQ = null;
	}
}