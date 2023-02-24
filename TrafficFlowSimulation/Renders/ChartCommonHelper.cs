namespace TrafficFlowSimulation.Renders;

public static class ChartCommonHelper
{
	public static double CalculateFromPosition(double position)
	{
		const int step = 1;
		return position - step;
	}

	public static double CalculateToPosition(double position)
	{
		const int step = 1;
		return position + step;
	}
}