using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Common;
using Common.Modularity;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows;

public class ParametersSelectionWindowConfiguration : IInitializable
{
	private readonly Chart _chart;

	private readonly ErrorProvider _errorProvider;

	private readonly Control.ControlCollection _controls;

	public ParametersSelectionWindowConfiguration(
		Chart chart,
		ErrorProvider errorProvider,
		Control.ControlCollection controls)
	{
		_chart = chart;
		_errorProvider = errorProvider;
		_controls = controls;
	}
	public void Initialize()
	{
		CommonHelper.ServiceRegistrator.RegisterInstance<ParametersSelectionWindowHelper>(() => new ParametersSelectionWindowHelper(
		//	_localizationComponents,
		//	_allCharts,
			_errorProvider,
			_controls), skipIfAlreadyRegistered: false);

		var movementSimulationConfiguration = new ParametersSelectionConfiguration(_chart);
		movementSimulationConfiguration.Initialize();
	}
}