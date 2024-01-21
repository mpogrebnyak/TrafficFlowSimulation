using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Renders.ChartRenders;
using Common;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;

namespace TrafficFlowSimulation.Handlers;

public class ChartRenderingHandler
{
	private readonly List<string> _chartNames;

	private readonly List<IChartRender> _providers = new();

	public ChartRenderingHandler(List<string> chartNames, string mode)
	{
		_chartNames = chartNames;
		InitializeChartProviders(mode);
	}

	public void InitializeChartProviders(string mode)
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

	public void UpdateScale(CoordinatesArgs coordinates)
	{
		foreach (var provider in _providers)
		{
			provider.UpdateScale(coordinates);
		}
	}

	public void SaveCharts(List<Chart> charts, string fileName)
	{
		foreach (var chart in charts)
		{
			RenderingHelper.CreateChartToSave(chart)
				.SaveImage(CommonFileHelper.CreateFilePath(fileName + "_" + chart.Name, null, CommonFileHelper.Extension.Png), ChartImageFormat.Png);
		}
	}

	public void SaveCoordinates(SerializerPointsModel serializerData, string fileName)
	{
		var path = CommonFileHelper.CreateFilePath(fileName, null, CommonFileHelper.Extension.Txt);

		var attempt = 5;
		while (true)
		{
			try
			{
				attempt--;
				SerializerPointsHelper.SerializePoints(path, serializerData);
				return;
			}
			catch (Exception e)
			{
				if (attempt == 0)
				{
					throw new Exception(e.Message);
				}
				GC.Collect();
				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}