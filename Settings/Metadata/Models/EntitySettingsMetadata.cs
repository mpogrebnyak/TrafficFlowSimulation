namespace Settings.Metadata.Models
{
	public class EntitySettingsMetadata
	{
		public EntitySettingsMetadata(SettingsGroupMetadata settingsMetadata)
		{
			SettingsMetadata = settingsMetadata;
		}

		public SettingsGroupMetadata SettingsMetadata { get; protected set; }
	}
}