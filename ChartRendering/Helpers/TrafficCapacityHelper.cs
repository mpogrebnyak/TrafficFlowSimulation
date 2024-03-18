﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using ChartRendering.Properties;
using ChartRendering.Renders.ChartRenders;
using Common;
using Localization;
using Microsoft.Practices.ObjectBuilder2;
using Settings;

namespace ChartRendering.Helpers;

public static class TrafficCapacityHelper
{
	private const int RoundTime = 60;

	private const string TrafficCapacityName = "TrafficCapacitySeries_";

	private const string KeyPrefix = "Line ";

	private static readonly Dictionary<string, Dictionary<int, int>> SeriesTrafficCapacity = new();

	private static int _currentRoundNumber= 1;

	private static int _roundTime = RoundTime;

	private static Dictionary<int, int> CreateTrafficCapacity()
	{
		var dictionary = new Dictionary<int, int>();
		var minutes = SettingsHelper.Get<ChartRenderingSettings>().TrafficCapacityRoundsNumber;
		for (var i = 1; i <= minutes; i++)
		{
			dictionary.Add(i, 0);
		}

		return dictionary;
	}

	public static void RenderTrafficCapacity(SeriesCollection chartSeries, string chartAreaName, int? roundTime = null)
	{
		_roundTime = roundTime ?? RoundTime;
		SeriesTrafficCapacity.Clear();

		var environmentLineSeries = chartSeries
			.Where(x => (string) x.Tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		foreach (var series in environmentLineSeries)
		{
			SeriesTrafficCapacity.Add(KeyPrefix + Math.Round(series.Points.First().XValue, 2), CreateTrafficCapacity());
			var trafficCapacitySeries = CreateTrafficCapacitySeriesLabel(series.Name, series.Points.First().XValue);
			trafficCapacitySeries.ForEach(x =>
			{
				x.ChartArea = chartAreaName;
				chartSeries.Add(x);
			});
		}
	}

	public static void UpdateTrafficCapacity(SeriesCollection chartSeries, List<double> values, double t)
	{
		var environmentLineSeries = chartSeries
			.Where(x => (string) x.Tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		chartSeries
			.Where(x => x.Name.Contains("FictitiousSeries"))
			.ForEach(x => x.Enabled = IsTrafficCapacityAvailable());

		foreach (var series in environmentLineSeries)
		{
			var trafficCapacity = series.Points.Any()
				? values.Count(x => x > series.Points.First().XValue)
				: 0;

			var trafficCapacitySeries = chartSeries.
				SingleOrDefault(x => x.Name.Contains(TrafficCapacityName + series.Name));

			if (trafficCapacitySeries != null)
			{
				trafficCapacitySeries.Enabled = IsTrafficCapacityAvailable();
				var currentTrafficCapacity = int.Parse(trafficCapacitySeries.Tag.ToString());
				if (currentTrafficCapacity < trafficCapacity)
				{
					CalculateTrafficCapacity(series.Points.First().XValue, t, trafficCapacity);
					trafficCapacitySeries.Label = GetTrafficCapacityLabel(series.Points.First().XValue);
					trafficCapacitySeries.Tag = trafficCapacity.ToString();
				}
			}
		}

		if (IsTrafficCapacityAvailable())
		{
			var rounds = SettingsHelper.Get<ChartRenderingSettings>().TrafficCapacityRoundsNumber;
			if (t > _currentRoundNumber * _roundTime && t < (rounds + 1) * _roundTime)
			{
				_currentRoundNumber++;
				CommonFileHelper.WriteDictionaryToFile(SeriesTrafficCapacity, " ");
			}
		}
	}

	private static Series[] CreateTrafficCapacitySeriesLabel(string name, double xCoordinate)
	{
		var trafficCapacitySeries = new Series
		{
			Name = TrafficCapacityName + name,
			ChartType = SeriesChartType.Point,
			BorderWidth = 2,
			Color = Color.Transparent,
			IsVisibleInLegend = false,
			Label = GetTrafficCapacityLabel(xCoordinate),
			LabelForeColor = Color.Black,
			LabelBorderColor = CustomColors.SystemOrange,
			LabelBorderDashStyle = ChartDashStyle.Dot,
			LabelBackColor = CustomColors.SystemBeige,
			LabelBorderWidth = 2,
			Font = new Font("Microsoft Sans Serif", 10F),
			SmartLabelStyle = new SmartLabelStyle
			{
				Enabled = true,
				IsMarkerOverlappingAllowed = false,
				IsOverlappedHidden = true,
				AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial,
				MovingDirection = LabelAlignmentStyles.BottomLeft,
				MinMovingDistance = 6,
				CalloutStyle = LabelCalloutStyle.Underlined,
				CalloutLineAnchorCapStyle = LineAnchorCapStyle.Arrow
			},
			Tag = 0.ToString(),
			Enabled = IsTrafficCapacityAvailable()
		};
		trafficCapacitySeries.Points.Add(new DataPoint(xCoordinate, 0.42));

		/*
		Добавляет мнимые точки на график, чтобы label не прыгал и всегда находился в одном месте
		*/
		var fictitiousSeries = new Series
		{
			Name = "FictitiousSeries" + name,
			ChartType = SeriesChartType.Point,
			BorderWidth = 2,
			Color = Color.Transparent,
			IsVisibleInLegend = false,
			Enabled = IsTrafficCapacityAvailable()
		};
		fictitiousSeries.Points.Add(new DataPoint(xCoordinate, 0.6));

		return new[] {trafficCapacitySeries, fictitiousSeries};
	}

	private static void CalculateTrafficCapacity(double key, double t, int capacity)
	{
		var trafficCapacity = SeriesTrafficCapacity[KeyPrefix + Math.Round(key, 2)];
		var innerKeys = trafficCapacity
			.ToDictionary(entry => entry.Key, entry => entry.Value)
			.Keys
			.Where(x => x * _roundTime > t);

		foreach (var innerKey in innerKeys)
		{
			trafficCapacity[innerKey] = capacity;
		}
	}

	private static string GetTrafficCapacityLabel(double key)
	{
		var trafficCapacity = SeriesTrafficCapacity.First(x => x.Key == KeyPrefix + Math.Round(key, 2)).Value;

		var label = LocalizationHelper.Get<ChartRenderingResources>().TrafficCapacityLabelHead;

		var rounds = SettingsHelper.Get<ChartRenderingSettings>().TrafficCapacityRoundsNumber;
		for (var round = 1; round <= rounds; round++)
		{
			label += LocalizationHelper.Get<ChartRenderingResources>()
				.TrafficCapacity(round * _roundTime, trafficCapacity[round].ToString("D2"));

			label += round != rounds
				? "; "
				: ". ";

			label += rounds % 2 == 0 && round == rounds / 2 || rounds % 2 == 1 && round == (rounds - 1) / 2
				? "\n"
				: "";
		}

		label += "\n \n";
		return label;
	}

	private static bool IsTrafficCapacityAvailable()
	{
		return SettingsHelper.Get<ChartRenderingSettings>().IsTrafficCapacityAvailable;
	}
}