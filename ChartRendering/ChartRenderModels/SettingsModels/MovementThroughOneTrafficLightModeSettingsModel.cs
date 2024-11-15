﻿using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class MovementThroughOneTrafficLightModeSettingsModel : BaseSettingsModels
{
	[Hidden]
	public override double L { get; set; } 

	[Translation(Locales.ru, "Цвет первого сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2, enumType: typeof(TrafficLightColor))]
	[Required]
	public EnumItem FirstTrafficLightColor { get; set; }

	[Translation(Locales.ru, "Время зеленого сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2)]
	[Required]
	public double SingleLightGreenTime { get; set; }

	[Translation(Locales.ru, "Время красного сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(3)]
	[Required]
	public double SingleLightRedTime { get; set; }

	public override object GetDefault()
	{
		return new MovementThroughOneTrafficLightModeSettingsModel
		{
			L = MaxL,
			FirstTrafficLightColor = new EnumItem(TrafficLightColor.Green),
			SingleLightGreenTime = 10,
			SingleLightRedTime = 20
		};
	}
}
