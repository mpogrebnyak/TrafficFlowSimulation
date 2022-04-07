namespace Settings.Metadata.Models
{
	public class SettingsGroupMetadata : SettingsMetadata
	{
		public SettingsGroupMetadata()
		{
			Children = new SettingsMetadata[0];
		}

		public SettingsMetadata[] Children { get; set; }
		
		public IList<SettingsMetadata> GetAllChildMetadata()
		{
			return GetAllChildMetadata(this);
		}

		private static IList<SettingsMetadata> GetAllChildMetadata(SettingsGroupMetadata group)
		{
			var lst = new List<SettingsMetadata>();
			lst.AddRange(group.Children);

			lst.AddRange(group.Children.OfType<SettingsGroupMetadata>().SelectMany(GetAllChildMetadata));
			return lst;
		}
	}
}