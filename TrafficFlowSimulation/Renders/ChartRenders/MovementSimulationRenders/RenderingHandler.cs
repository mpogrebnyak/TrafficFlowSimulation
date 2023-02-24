using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

public class RenderingHandler
{
	private AllChartsModel Charts { get; }

	private DrivingMode DrivingMode { get; set; }

	private IChartRender SpeedProvider { get; set; }

	private IChartRender DistanceProvider { get; set; }

	private IChartRender CarMovementProvider { get; set; }

	private IChartRender SpeedFromDistanceProvider { get; set; }

	public RenderingHandler(AllChartsModel charts)
	{
		Charts = charts;
		DrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
		SpeedProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.SpeedChart.Name + DrivingMode);
		DistanceProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.DistanceChart.Name + DrivingMode);
		CarMovementProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.CarsMovementChart.Name + DrivingMode);

		SpeedFromDistanceProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.SpeedFromDistanceChart.Name);
	}

	public void ChangeDrivingMode(DrivingMode drivingMode)
	{
		DrivingMode = drivingMode;

		SpeedProvider = ServiceLocator.Current.GetInstance<IChartRender>(Charts.SpeedChart.Name + drivingMode);
		DistanceProvider = ServiceLocator.Current.GetInstance<IChartRender>(Charts.DistanceChart.Name + drivingMode);
		CarMovementProvider = ServiceLocator.Current.GetInstance<IChartRender>(Charts.CarsMovementChart.Name + drivingMode);
	}

	public void RenderCharts(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		SpeedProvider.RenderChart(modelParameters, modeSettings);
		DistanceProvider.RenderChart(modelParameters, modeSettings);
		CarMovementProvider.RenderChart(modelParameters, modeSettings);

		SpeedFromDistanceProvider.RenderChart(modelParameters, modeSettings);
	}

	public void UpdateCharts(object parameters)
	{
		SpeedProvider.UpdateChart(parameters);
		DistanceProvider.UpdateChart(parameters);
		CarMovementProvider.UpdateChart(parameters);

		SpeedFromDistanceProvider.UpdateChart(parameters);
	}

	public void UpdateChartEnvironments(object parameters)
	{
		SpeedProvider.UpdateEnvironment(parameters);
		DistanceProvider.UpdateEnvironment(parameters);
		CarMovementProvider.UpdateEnvironment(parameters);
	}

	public void SetMarkerImage()
	{
		CarMovementProvider.SetMarkerImage();
	}

	public void AddSeries(int index)
	{
		SpeedProvider.AddSeries(index);
		DistanceProvider.AddSeries(index);
		CarMovementProvider.AddSeries(index);
	}
}