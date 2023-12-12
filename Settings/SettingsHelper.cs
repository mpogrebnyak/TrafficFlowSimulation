using Settings.Managers;

namespace Settings
{
	public static class SettingsHelper
	{
		private static SettingsManager _manager;

		public static void InitializeSettings()
		{
			var settingsMetadataManager = new SettingsMetadataManager();
			var memorySettingsStorage = new MemorySettingsStorage();
			_manager = new SettingsManager(settingsMetadataManager, memorySettingsStorage);
		}

		public static TSettings Get<TSettings>() where TSettings : new()
		{
			return _manager.Get<TSettings>();
		}
		
		public static void Set<TSettings>(TSettings instance) where TSettings : new()
		{
			_manager.Set(typeof(TSettings), instance);
		}
	}
}