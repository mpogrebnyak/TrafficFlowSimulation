using ChartRendering.Renders.ChartRenders.ParametersSelectionRenders.Models;
using Common;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace ChartRendering.Helpers;

public static class SerializerPointsHelper
{
	public static void SerializePoints(string filePath, SerializerPointsModel serializerPointsModel)
	{
		SerializerDataHelper.Serialize(filePath, serializerPointsModel, serializerPointsModel.GetType());
	}

	public static SerializerPointsModel DeserializePoints(string filePath)
	{
		var deserializeObject = (SerializerPointsModel)SerializerDataHelper.Deserialize(filePath, typeof(SerializerPointsModel));

	//	modelParameters = deserializeObject.ModelParameters;
	//	modeSettings = deserializeObject.ModeSettings;

	//	deserializeObject.CoordinatesModel.ForEach(x =>
	//	{
	//		if (x.Intensity > 0 && x.Intensity < 1)
	//			x.Color = CustomColors.Green.Name;
	//	});

		return new SerializerPointsModel
		{
			Name = deserializeObject.Name,
			ModelParameters = deserializeObject.ModelParameters,
			ModeSettings = deserializeObject.ModeSettings,
			CoordinatesModel = deserializeObject.CoordinatesModel,
			LastValue = deserializeObject.LastValue
		};
	}
}