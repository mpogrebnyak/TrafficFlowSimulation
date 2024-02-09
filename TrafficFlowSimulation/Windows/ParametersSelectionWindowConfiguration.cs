using Common;
using Common.Modularity;
using EvaluationKernel.Helpers;
using TrafficFlowSimulation.Configurations;
using TrafficFlowSimulation.Helpers;

namespace TrafficFlowSimulation.Windows;

public class ParametersSelectionWindowConfiguration : IInitializable
{
	private readonly ParametersSelectionWindow _form;

	public ParametersSelectionWindowConfiguration(ParametersSelectionWindow form)
	{
		_form = form;
	}

	public void Initialize()
	{
		CommonHelper.ServiceRegistration.RegisterInstance(() => new ParametersSelectionWindowHelper(_form), skipIfAlreadyRegistered: false);

		var movementSimulationConfiguration = new ParametersSelectionConfiguration(_form);
		movementSimulationConfiguration.Initialize();

		CommonHelper.ServiceRegistration.RegisterInstance(() => new SpinningLabelHelper(_form), ModesHelper.ParametersSelectionModeType, false);
	}
}