using System.Text.Json;

namespace Common;

public static class SerializerDataHelper
{
	public static void ExportPoints(string fileName, List<PointsSerializerModel> points)
	{
		File.WriteAllText(fileName, JsonSerializer.Serialize(points));
	}

	public static List<PointsSerializerModel> ImportPoints(string fileName)
	{
		var json = File.ReadAllText(fileName);
		var points = JsonSerializer.Deserialize<List<PointsSerializerModel>>(json);

		return points;
	}
}

public class PointsSerializerModel
{
	public double X { get; set; }
	public double Y { get; set; }
	public string Color { get; set; }
}