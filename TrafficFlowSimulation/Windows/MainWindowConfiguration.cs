using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.MovementSimulation;
using TrafficFlowSimulation.Services;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows;

public class MainWindowConfiguration : TrafficFlowSimulationModule
{
	private readonly LocalizationComponentsModel _localizationComponents;

	private readonly AllChartsModel _allCharts;

	private readonly ErrorProvider _errorProvider;

	private readonly Dictionary<Type, BindingSource> _bindingSources;

	private readonly Control.ControlCollection _controls;

	public MainWindowConfiguration(
		LocalizationComponentsModel localizationComponentsModel,
		AllChartsModel allCharts,
		ErrorProvider errorProvider,
		Control.ControlCollection controls)
	{
		_localizationComponents = localizationComponentsModel;
		_allCharts = allCharts;
		_errorProvider = errorProvider;
		_bindingSources = new();
		_controls = controls;
	}

	public override void Initialize()
	{
		_serviceRegistrator.RegisterInstance<MainWindowHelper>(() => new MainWindowHelper(
			_localizationComponents,
			_allCharts,
			_errorProvider,
			_controls));

		var movementSimulationConfiguration = new MovementSimulationConfiguration(_allCharts);
		movementSimulationConfiguration.Initialize();
	}
}