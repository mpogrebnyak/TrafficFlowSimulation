using System.Collections.Generic;
using ChartRendering.ChartRenderModels;
using Common;
using EvaluationKernel.Models;

namespace ChartRendering.Models;

public class SerializerPointsModel : SerializerData
{
	public double LastValue { get; set; }

	public ModelParameters ModelParameters { get; set; }

	public BaseSettingsModels ModeSettings { get; set; }

	public List<CoefficientEstimationCoordinatesModel> CoordinatesModel { get; set; }
}