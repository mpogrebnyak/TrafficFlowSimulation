using ChartRendering.Models;
using Common;

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