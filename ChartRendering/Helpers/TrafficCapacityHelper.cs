using System;
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

	private static List<int> _currentRoundNumber = new();

	private static List<int> _roundTime = new();

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

	public static void RenderTrafficCapacity(SeriesCollection chartSeries, string chartAreaName, List<int>? roundTime = null)
	{
		_roundTime = new List<int>();
		SeriesTrafficCapacity.Clear();

		var environmentLineSeries = chartSeries
			.Where(x => x.Tag is string tag && tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		foreach (var series in environmentLineSeries.Select((value, i) => new { i, value }))
		{
			var key = KeyPrefix + Math.Round(series.value.Points.First().XValue, 2);
			if (SeriesTrafficCapacity.ContainsKey(key) == false)
			{
				_roundTime.Add(roundTime != null && series.i >= 0 && roundTime.Count - 1 >= series.i
					? roundTime[series.i]
					: RoundTime);
				_currentRoundNumber.Add(1);

				SeriesTrafficCapacity.Add(key, CreateTrafficCapacity());
				var trafficCapacitySeries =
					CreateTrafficCapacitySeriesLabel(series.value.Name, series.value.Points.First().XValue, series.i);
				trafficCapacitySeries.ForEach(x =>
				{
					x.ChartArea = chartAreaName;
					chartSeries.Add(x);
				});
			}
		}
	}

	public static void UpdateTrafficCapacity(SeriesCollection chartSeries, List<double> values, double t)
	{
		var environmentLineSeries = chartSeries
			.Where(x => x.Tag is string tag && tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		chartSeries
			.Where(x => x.Name.Contains("FictitiousSeries"))
			.ForEach(x => x.Enabled = IsTrafficCapacityAvailable());

		foreach (var series in environmentLineSeries.Select((value, i) => new { i, value }))
		{
			var trafficCapacity = series.value.Points.Any()
				? values.Count(x => x > series.value.Points.First().XValue)
				: 0;

			var trafficCapacitySeries = chartSeries.
				SingleOrDefault(x => x.Name.Contains(TrafficCapacityName + series.value.Name));

			if (trafficCapacitySeries != null)
			{
				trafficCapacitySeries.Enabled = IsTrafficCapacityAvailable();
				var currentTrafficCapacity = int.Parse(trafficCapacitySeries.Tag.ToString());
				if (currentTrafficCapacity < trafficCapacity)
				{
					CalculateTrafficCapacity(series.value.Points.First().XValue, t, trafficCapacity, series.i);
					trafficCapacitySeries.Label = GetTrafficCapacityLabel(series.value.Points.First().XValue, series.i);
					trafficCapacitySeries.Tag = trafficCapacity.ToString();
				}
			}
		}

		if (IsTrafficCapacityAvailable())
		{
			var rounds = SettingsHelper.Get<ChartRenderingSettings>().TrafficCapacityRoundsNumber;
			for (var i = 0; i < environmentLineSeries.Count; i++)
			{
				if (t > _currentRoundNumber[i] * _roundTime[i] && t < (rounds + 1) * _roundTime[i])
				{
					_currentRoundNumber[i]++;
					CommonFileHelper.WriteDictionaryToFile(SeriesTrafficCapacity, " ");
				}
			}
		}
	}

	private static Series[] CreateTrafficCapacitySeriesLabel(string name, double xCoordinate, int index)
	{
		var trafficCapacitySeries = new Series
		{
			Name = TrafficCapacityName + name,
			ChartType = SeriesChartType.Point,
			BorderWidth = 2,
			Color = Color.Transparent,
			IsVisibleInLegend = false,
			Label = GetTrafficCapacityLabel(xCoordinate, index),
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

	private static void CalculateTrafficCapacity(double key, double t, int capacity, int index)
	{
		var trafficCapacity = SeriesTrafficCapacity[KeyPrefix + Math.Round(key, 2)];
		var innerKeys = trafficCapacity
			.ToDictionary(entry => entry.Key, entry => entry.Value)
			.Keys
			.Where(x => x * _roundTime[index] > t);

		foreach (var innerKey in innerKeys)
		{
			trafficCapacity[innerKey] = capacity;
		}
	}

	private static string GetTrafficCapacityLabel(double key, int index)
	{
		var trafficCapacity = SeriesTrafficCapacity.First(x => x.Key == KeyPrefix + Math.Round(key, 2)).Value;

		var label = LocalizationHelper.Get<ChartRenderingResources>().TrafficCapacityLabelHead;

		var rounds = SettingsHelper.Get<ChartRenderingSettings>().TrafficCapacityRoundsNumber;
		for (var round = 1; round <= rounds; round++)
		{
			label += LocalizationHelper.Get<ChartRenderingResources>()
				.TrafficCapacity(round * _roundTime[index], trafficCapacity[round].ToString("D2"));

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