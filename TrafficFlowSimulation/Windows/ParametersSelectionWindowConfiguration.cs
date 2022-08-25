using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows;

public class ParametersEvaluationWindowConfiguration : TrafficFlowSimulationModule
{
	private readonly Chart _chart;

	private readonly ErrorProvider _errorProvider;

	private readonly Control.ControlCollection _controls;

	public ParametersEvaluationWindowConfiguration(
		Chart chart,
		ErrorProvider errorProvider,
		Control.ControlCollection controls)
	{
		_chart = chart;
		_errorProvider = errorProvider;
		_controls = controls;
	}
	public override void Initialize()
	{
		_serviceRegistrator.RegisterInstance<ParametersSelectionWindowHelper>(() => new ParametersSelectionWindowHelper(
		//	_localizationComponents,
		//	_allCharts,
			_errorProvider,
			_controls));

		var movementSimulationConfiguration = new ParametersSelectionConfiguration(_chart);
		movementSimulationConfiguration.Initialize();
	}
}