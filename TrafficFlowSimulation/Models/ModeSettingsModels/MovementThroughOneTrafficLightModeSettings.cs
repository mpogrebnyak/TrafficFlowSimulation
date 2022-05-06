namespace TrafficFlowSimulation.Models.ModeSettingsModels;

public class MovementThroughOneTrafficLightModeSettings : ModeSettings
{
	public TrafficLightModel TrafficLight { get; set; }

	public static MovementThroughOneTrafficLightModeSettings GetDefault()
	{
		return new MovementThroughOneTrafficLightModeSettings
		{
			TrafficLight = new TrafficLightModel
			{
				Number = 1,
				Position = 0,
				GreenSignalTime = 5,
				RedSignalTime = 5
			}
		};
	}
}