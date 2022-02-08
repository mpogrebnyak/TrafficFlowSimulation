using Settings.Managers;

namespace Settings
{
	public static class SettingsHelper
	{
		private static SettingsManager _manager;

		public static void InitializeSettings()
		{
			var settingsMetadataManager = new SettingsMetadataManager();
			_manager =  new SettingsManager(settingsMetadataManager);
		}

		public static TSettings Get<TSettings>() where TSettings : new()
		{
			return _manager.Get<TSettings>();
		}
	}
}