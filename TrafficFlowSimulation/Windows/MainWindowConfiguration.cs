using Common;
using Common.Modularity;
using TrafficFlowSimulation.Configurations;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;

namespace TrafficFlowSimulation.Windows;

public class MainWindowConfiguration : IInitializable
{
	private readonly MainWindow _form;

	public MainWindowConfiguration(MainWindow form)
	{
		_form = form;
	}

	public void Initialize()
	{
		CommonHelper.ServiceRegistration.RegisterInstance(() => new MainWindowHelper(_form), skipIfAlreadyRegistered: false);

		var movementSimulationConfiguration = new MovementSimulationConfiguration(_form);
		movementSimulationConfiguration.Initialize();

		FormUpdateHandler.Initialize(_form);
	}
}