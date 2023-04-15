using System.Collections.Generic;
using Common;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

public class SerializerPointsModel : SerializerData
{
	public ModelParameters ModelParameters { get; set; }

	public BaseSettingsModels ModeSettings { get; set; }

	public List<InliningDistanceEstimationCoordinatesModel> CoordinatesModel { get; set; }
}