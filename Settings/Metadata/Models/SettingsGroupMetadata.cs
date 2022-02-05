namespace Settings.Metadata.Models
{
	public class SettingsGroupMetadata : SettingsMetadata
	{
		public SettingsGroupMetadata()
		{
			Children = new SettingsMetadata[0];
		}

		public SettingsMetadata[] Children { get; set; }
	}
}