using System;
using Settings.Metadata;
using Settings.Metadata.Models;

namespace Settings.Managers
{
	public class SettingsMetadataManager : ISettingsMetadataManager
	{
		private readonly ISettingsMetadataBuilder _metadataBuilder;

		public SettingsMetadataManager()
		{
			_metadataBuilder = new SettingsMetadataBuilder();
		}

		public EntitySettingsMetadata GetMetadata(Type settingType)
		{
			if (settingType == null) throw new ArgumentNullException("settingType");

			var classMetadata = _metadataBuilder.BuildMetadata(settingType);
			return new EntitySettingsMetadata(classMetadata);
		}
	}
}