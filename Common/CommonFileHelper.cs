namespace Common;

public static class CommonFileHelper
{
	public static string CreateFileName(string prefixName, Dictionary<string, double> parameters)
	{
		var fileName = prefixName;
		foreach (var p in parameters)
		{
			fileName += @"_" + p.Key + "=" + Math.Round(p.Value, 2);
		}

		return fileName;
	}

	// TODO сделать нормальное создание и сохранение файлов
	public static string CreateFile(string fileName, string folder, string extension, string? folderPath = null)
	{
		folderPath ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		var folderName = @"\" + Path.GetFileName(folder);
		folderPath += folderName;
		var folderExists = Directory.Exists(folderPath);
		if (!folderExists)
			Directory.CreateDirectory(folderPath);

		return folderPath +  @"\" + fileName + extension;
	}
}