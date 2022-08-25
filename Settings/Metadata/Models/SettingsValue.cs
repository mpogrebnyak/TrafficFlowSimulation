namespace Settings.Metadata.Models;

public class SettingsValue
{
	protected bool Equals(SettingsValue other)
	{
		return string.Equals(Value, other.Value);
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((SettingsValue) obj);
	}

	public override int GetHashCode()
	{
		unchecked
		{
			var hashCode = (Value != null ? Value.GetHashCode() : 0);
			hashCode = (hashCode * 397);
			return hashCode;
		}
	}

	/// <summary>
	///	 Значение настройки.
	/// </summary>
	public string Value { get; set; }

}