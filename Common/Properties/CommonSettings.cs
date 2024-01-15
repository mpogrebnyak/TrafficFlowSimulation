using System.ComponentModel;

namespace Common.Properties;

public class CommonSettings
{
	[DefaultValue(@"\Images")]
	public string FolderName { get; set; }
}