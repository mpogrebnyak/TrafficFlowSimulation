using System.Text.Json;

namespace Common;

public static class SerializerDataHelper
{
	public static void Serialize(string fileName, object objectToSerialize, Type objectType)
	{
		var json = JsonSerializer.Serialize(objectToSerialize, objectType);
		File.WriteAllText(fileName, json);
	}

	public static object Deserialize(string fileName, Type objectType)
	{
		var json = File.ReadAllText(fileName);
		return JsonSerializer.Deserialize(json, objectType);
	}
}

public class SerializerData
{
	public string Name { get; set; }
}