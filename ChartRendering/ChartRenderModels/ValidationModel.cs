using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Common.Errors;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;

namespace ChartRendering.ChartRenderModels;

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

			var propertyInfo = propertyDescriptor.ComponentType.GetProperty(property);
			var currentLocale = LocalizationSettingManager.GetCurrentLocale();

			var displayName = propertyDescriptor.DisplayName;
			if (propertyInfo != null)
			{
				var translationAttributes = System.Attribute.GetCustomAttributes(propertyInfo).OfType<TranslationAttribute>().ToArray();
				foreach (var attribute in translationAttributes)
				{
					if (attribute.Locale == currentLocale)
					{
						displayName = "\"" + attribute.Value + "\"";
					}
				}
			}

			var results = new List<ValidationResult>();
			var result = Validator.TryValidateProperty(
				propertyDescriptor.GetValue(this),
				new ValidationContext(this, null, null)
				{
					MemberName = property,
					DisplayName = displayName
				},
				results);

			if (!result)
			{
				var errorMessage = results.First().ErrorMessage;
				ServiceLocator.Current.GetInstance<IErrorManager>().Send(property, new ErrorEventArgs(new Exception(errorMessage)));

				return errorMessage;
			}

			return string.Empty;
		}
	}

	[Browsable(false)]
	public string? Error
	{
		get
		{
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(this,
				new ValidationContext(this, null, null), validationResults, true);

			if (!isValid)
				return string.Join("\n", validationResults.Select(x => x.ErrorMessage));

			return null;
		}
	}
}
