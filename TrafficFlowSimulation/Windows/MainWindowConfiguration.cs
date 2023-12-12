using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChartRendering.Models;
using Common;
using Common.Modularity;
using TrafficFlowSimulation.Configurations;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Windows.Helpers;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows;

public class MainWindowConfiguration : IInitializable
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

	public void Initialize()
	{
		CommonHelper.ServiceRegistration.RegisterInstance<MainWindowHelper>(() => new MainWindowHelper(
			_localizationComponents,
			_allCharts,
			_errorProvider,
			_controls), skipIfAlreadyRegistered: false);

		var movementSimulationConfiguration = new MovementSimulationConfiguration(_allCharts);
		movementSimulationConfiguration.Initialize();
	}
}