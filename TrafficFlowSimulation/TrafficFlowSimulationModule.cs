using Common.Modularity;
using TrafficFlowSimulation.Configurations;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation;

public class TrafficFlowSimulationModule : IInitializable
{
	public void Initialize()
	{
		var handlersConfiguration = new HandlersConfiguration();
		handlersConfiguration.Initialize();

		var modelsConfiguration = new ModelsConfiguration();
		modelsConfiguration.Initialize();
	}
}