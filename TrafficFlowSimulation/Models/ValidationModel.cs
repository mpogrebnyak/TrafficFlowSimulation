using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TrafficFlowSimulation.Models
{
	public class ValidationModel : IDataErrorInfo
	{
		[Browsable(false)]
		public string this[string property]
		{
			get
			{
				var propertyDescriptor = TypeDescriptor.GetProperties(this)[property];
				if (propertyDescriptor == null)
					return string.Empty;

				var results = new List<ValidationResult>();
				var result = Validator.TryValidateProperty(
					propertyDescriptor.GetValue(this),
					new ValidationContext(this, null, null)
					{
						MemberName = property,
						DisplayName = EmptyDisplayName.Value,
					},
					results);
				if (!result)
					return results.First().ErrorMessage.Replace(EmptyDisplayName.Value, "");
				return string.Empty;
			}
		}

		[Browsable(false)]
		public string Error
		{
			get
			{
				var results = new List<ValidationResult>();
				var result = Validator.TryValidateObject(this,
					new ValidationContext(this, null, null), results, true);
				if (!result)
					return string.Join("\n", results.Select(x => x.ErrorMessage));
				else
					return null;
			}
		}

		public class EmptyDisplayName
		{
			public const string Value = "___empty___";
		}
	}
}
