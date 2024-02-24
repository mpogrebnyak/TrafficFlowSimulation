using System.Collections;
using Common.Properties;
using Settings;

namespace Common;

public static class CommonFileHelper
{
	public enum Extension
	{
		Jpeg,
		Png, 
		Txt,
		Emf
	}

	public static string CreateFileName(string prefixName, Dictionary<string, double> parameters)
	{
		var fileName = prefixName;
		foreach (var p in parameters)
		{
			fileName += @"_" + p.Key + "=" + Math.Round(p.Value, 2);
		}

		return fileName;
	}

	public static string CreateFilePath(string fileName = "", string? folderPath = null, Extension? extension = null, bool IsAllNamesUnique = false)
	{
		var folderName = SettingsHelper.Get<CommonSettings>().FolderName;

		folderPath ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal) + folderName;
		var folderExists = Directory.Exists(folderPath);
		if (!folderExists)
			Directory.CreateDirectory(folderPath);

		fileName = IsAllNamesUnique ?
			CreateDateName() + fileName
			: fileName;
		var fileExtension = GetExtension(extension);

		return folderPath +  @"\" + fileName + fileExtension;
	}

	public static void WriteDictionaryToFile<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string separator, string? filePath = null)
	{
		filePath ??= CreateFilePath("Dictionary", null, Extension.Txt);
		using var writer = new StreamWriter(filePath);
		foreach (var pair in dictionary)
		{
			if (pair.Value is IDictionary innerDictionary)
			{
				writer.WriteLine($"{pair.Key}");

				foreach (var key in innerDictionary.Keys)
				{
					writer.WriteLine($"{key}{separator}{innerDictionary[key]}");
				}

				writer.WriteLine();
				continue;
			}
			writer.WriteLine($"{pair.Key}{separator}{pair.Value}");
		}
	}

	private static string CreateDateName()
	{
		var date = CommonHelper.GetDate;
		var time = CommonHelper.GetTime;

		return date.ToString(@"MM/dd/yyyy") + "_" + time.ToString(@"hh\.mm\.ss") + "_";
	}

	private static string GetExtension(Extension? extension)
	{
		return extension switch
		{
			Extension.Jpeg => ".jpeg",
			Extension.Png => ".png",
			Extension.Txt => ".txt",
			Extension.Emf => ".emf",
			_ => ".png"
		};
	}
}