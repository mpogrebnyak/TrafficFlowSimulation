using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Localization;
using Microsoft.Practices.ObjectBuilder2;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

public static class TrafficCapacityHelper
{
	private static Dictionary<int, int> _trafficCapacity = new Dictionary<int, int>()
	{
		{60, 0},
		{120, 0},
		{180, 0},
		{240, 0}
	};

	private static readonly string TrafficCapacityName = "TrafficCapacitySeries_";

	public static void RenderTrafficCapacity(SeriesCollection chartSeries, string chartAreaName)
	{
		if(IsTrafficCapacityAvailable() == false)
			return;

		var environmentLineSeries = chartSeries
			.Where(x => x.Tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		foreach (var series in environmentLineSeries)
		{
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
		if(IsTrafficCapacityAvailable() == false)
			return;

		var environmentLineSeries = chartSeries
			.Where(x => x.Tag == ChartsRender.EnvironmentSeriesTag && x.ChartType == SeriesChartType.Line)
			.ToList();

		foreach (var series in environmentLineSeries)
		{
			var trafficCapacity = series.Points.Any()
				? values.Count(x => x > series.Points.First().XValue)
				: 0;

			var trafficCapacitySeries = chartSeries.
				SingleOrDefault(x => x.Name.Contains(TrafficCapacityName + series.Name));

			if (trafficCapacitySeries != null)
			{
				var currentTrafficCapacity = int.Parse(trafficCapacitySeries.Tag.ToString());
				if (currentTrafficCapacity < trafficCapacity)
				{
					CalculateTrafficCapacity(t, trafficCapacity);
					trafficCapacitySeries.Label = GetTrafficCapacityLabel();
					trafficCapacitySeries.Tag = trafficCapacity.ToString();
				}
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
			Label = GetTrafficCapacityLabel(),
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
				MinMovingDistance = 20,
				CalloutStyle = LabelCalloutStyle.Underlined,
				CalloutLineAnchorCapStyle = LineAnchorCapStyle.Arrow
			},
			Tag = 0.ToString()
		};
		trafficCapacitySeries.Points.Add(new DataPoint(xCoordinate, 0.5));

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
		};
		fictitiousSeries.Points.Add(new DataPoint(xCoordinate, 0.6));
		fictitiousSeries.Points.Add(new DataPoint(xCoordinate - 5, 0.3));

		return new[] {trafficCapacitySeries, fictitiousSeries};
	}

	private static void CalculateTrafficCapacity(double t, int trafficCapacity)
	{
		var keys = _trafficCapacity
			.ToDictionary(entry => entry.Key, entry => entry.Value)
			.Keys
			.Where(x => x > t);

		foreach (var key in keys)
		{
			_trafficCapacity[key] = trafficCapacity;
		}
	}

	private static string GetTrafficCapacityLabel()
	{
		return LocalizationHelper.Get<ChartResources>().TrafficCapacity(_trafficCapacity[60],_trafficCapacity[120],_trafficCapacity[180],_trafficCapacity[240]);
	}

	private static bool IsTrafficCapacityAvailable()
	{
		return SettingsHelper.Get<Properties.Settings>().IsTrafficCapacityAvailable;
	}
}