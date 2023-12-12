using System.Collections.Generic;
using ChartRendering.ChartRenderModels;
using Common;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace ChartRendering.Renders.ChartRenders.ParametersSelectionRenders.Models;

public class SerializerPointsModel : SerializerData
{
	public double LastValue { get; set; }
	public ModelParameters ModelParameters { get; set; }

	public BaseSettingsModels ModeSettings { get; set; }

	public List<InliningDistanceEstimationCoordinatesModel> CoordinatesModel { get; set; }
}