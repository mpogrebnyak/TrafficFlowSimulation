using System.Collections.Generic;
using Common;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class SerializerPointsHelper
{
	public static void SerializePoints(string fileName, string filePath, ModelParameters modelParameters, BaseSettingsModels modeSettings, List<InliningDistanceEstimationCoordinatesModel> coordinatesModel)
	{
		var serializerData = new SerializerPointsModel
		{
			Name = fileName,
			ModelParameters = modelParameters,
			ModeSettings = modeSettings,
			CoordinatesModel = coordinatesModel
		};

		SerializerDataHelper.Serialize(filePath, serializerData, serializerData.GetType());
	}

	public static List<InliningDistanceEstimationCoordinatesModel> DeserializePoints(string filePath, out ModelParameters modelParameters, out BaseSettingsModels modeSettings)
	{
		var deserializeObject = (SerializerPointsModel)SerializerDataHelper.Deserialize(filePath, typeof(SerializerPointsModel));

		modelParameters = deserializeObject.ModelParameters;
		modeSettings = deserializeObject.ModeSettings;

		deserializeObject.CoordinatesModel.ForEach(x =>
		{
			if (x.Intensity > 0 && x.Intensity < 1)
				x.Color = CustomColors.Green.Name;
		});
		return deserializeObject.CoordinatesModel;
	}
}