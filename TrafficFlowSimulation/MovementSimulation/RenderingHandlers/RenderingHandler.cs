using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.Services;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers;

public class RenderingHandler
{
	private AllChartsModel _charts { get; set; }

	private DrivingMode _drivingMode { get; set; }

	private IChartRender _speedProvider { get; set; }
	private IChartRender _distanceProvider { get; set; }
	private IChartRender _carMovementProvider { get; set; }

	public RenderingHandler(AllChartsModel charts)
	{
		_charts = charts;
		//Сделать дефолтное значение
		_drivingMode = DrivingMode.StartAndStopMovement;
		_speedProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.SpeedChart.Name + _drivingMode);
		_distanceProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.DistanceChart.Name + _drivingMode);
		_carMovementProvider = ServiceLocator.Current.GetInstance<IChartRender>(charts.CarsMovementChart.Name + _drivingMode);
	}

	public void ChangeDrivingMode(DrivingMode drivingMode)
	{
		_drivingMode = drivingMode;

		_speedProvider = ServiceLocator.Current.GetInstance<IChartRender>(_charts.SpeedChart.Name + drivingMode);
		_distanceProvider = ServiceLocator.Current.GetInstance<IChartRender>(_charts.DistanceChart.Name + drivingMode);
		_carMovementProvider = ServiceLocator.Current.GetInstance<IChartRender>(_charts.CarsMovementChart.Name + drivingMode);

		var modelParameters = ServiceLocator.Current.GetInstance<IDefaultParametersValuesService>().GetDefaultModelParameters();
		RenderCharts(modelParameters);
	}

	public void RenderCharts(ModelParameters modelParameters)
	{
		_speedProvider.RenderChart(modelParameters);
		_distanceProvider.RenderChart(modelParameters);
		_carMovementProvider.RenderChart(modelParameters);
	}

	public void UpdateCharts(double t, double[] x, double[] y )
	{
		_speedProvider.UpdateChart(new List<double> {t}, x.ToList(), y.ToList());
		_distanceProvider.UpdateChart(new List<double> {t}, x.ToList(), y.ToList());
		_carMovementProvider.UpdateChart(new List<double> {t}, x.ToList(), y.ToList());
	}

	public void UpdateChartEnvironments(EnvironmentParametersModel parameters)
	{
		_speedProvider.UpdateEnvironment(parameters);
		_distanceProvider.UpdateEnvironment(parameters);
		_carMovementProvider.UpdateEnvironment(parameters);
	}

	public void SetMarkerImage()
	{
		_carMovementProvider.SetMarkerImage();
	}

	public void AddSeries(int index)
	{
		_speedProvider.AddSeries(index);
		_distanceProvider.AddSeries(index);
		_carMovementProvider.AddSeries(index);
	}
}