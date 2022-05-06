namespace TrafficFlowSimulation.Models;

public class TrafficLightModel
{
	public int Number { get; set; }

	public double Position { get; set; }

	public double GreenSignalTime { get; set; }

	public double RedSignalTime { get; set; }
}