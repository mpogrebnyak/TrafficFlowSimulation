namespace TrafficFlowSimulation.Renders;

public static class ChartCommonHelper
{
	public static double CalculateFromPosition(double position, int step = 1)
	{
		return position - step;
	}

	public static double CalculateToPosition(double position, int step = 1)
	{
		return position + step;
	}
}