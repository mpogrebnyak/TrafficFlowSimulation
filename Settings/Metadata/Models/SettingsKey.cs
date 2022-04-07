namespace Settings.Metadata.Models;

public class SettingsKey
{
	/// <summary>
	/// Ключ настройки.
	/// </summary>
	public string Name { get; set; }

	protected bool Equals(SettingsKey other)
	{
		return string.Equals(Name, other.Name);
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hashCode = (Name != null ? Name.GetHashCode() : 0);
			return hashCode;
		}
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((SettingsKey) obj);
	}
}