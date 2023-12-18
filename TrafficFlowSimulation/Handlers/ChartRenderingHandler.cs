using System.Collections.Generic;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using ChartRendering.Renders.ChartRenders;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Modes;
using Modes.Constants;

namespace TrafficFlowSimulation.Handlers;

public class ChartRenderingHandler
{
	private readonly List<string> _chartNames;

	private readonly List<IChartRender> _providers = new();

	public ChartRenderingHandler(List<string> chartNames)
	{
		_chartNames = chartNames;

		var drivingMode = ModesHelper.GetCurrentDrivingMode();
		InitializeChartProviders(drivingMode);
	}

	public void InitializeChartProviders(DrivingMode mode)
	{
		_providers.Clear();
		foreach (var name in _chartNames)
		{
			var provider = ServiceLocator.Current.GetInstance<IChartRender>(name + mode);
			_providers.Add(provider);
		}
	}

	public void RenderCharts(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		foreach (var provider in _providers)
		{
			provider.RenderChart(modelParameters, modeSettings);
		}
	}

	public void UpdateCharts(CoordinatesArgs coordinates)
	{
		foreach (var provider in _providers)
		{
			provider.UpdateChart(coordinates);
		}
	}

	public void UpdateChartEnvironments(object parameters)
	{
		foreach (var provider in _providers)
		{
			provider.UpdateEnvironment(parameters);
		}
	}

	public void SetMarkerImage(object? parameters = null)
	{
		foreach (var provider in _providers)
		{
			provider.SetMarkerImage(parameters);
		}
	}

	public void AddSeries(int index)
	{
		foreach (var provider in _providers)
		{
			provider.AddSeries(index);
		}
	}
}