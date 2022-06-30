using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Services;

namespace TrafficFlowSimulation;

public class TrafficFlowSimulationModule
{
	protected IServiceRegistrator _serviceRegistrator = ServiceLocator.Current.GetInstance<IServiceRegistrator>();

	public virtual void Initialize()
	{
		_serviceRegistrator.RegisterInstance<IDefaultParametersValuesService>(typeof(DefaultParametersValuesService));
	}
}