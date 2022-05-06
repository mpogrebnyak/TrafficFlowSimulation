using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.MovementThroughOneTrafficLight;

public class EnvironmentModel : EnvironmentParametersModel
{
	public bool IsGreenLight { get; set; }

	public double GreenTime { get; set; }

	public double RedTime { get; set; }
}