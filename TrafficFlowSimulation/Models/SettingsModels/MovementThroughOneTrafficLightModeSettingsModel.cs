using System.ComponentModel.DataAnnotations;
using Localization.Localization;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class MovementThroughOneTrafficLightModeSettingsModel
{
	[Translation(Locales.ru, "Зеленый")]
	[Translation(Locales.en, "")]
	[CustomDisplayAttribute(1)]
	[Required]
	public double SingleLightGreenTime { get; set; }

	[Translation(Locales.ru, "Красный")]
	[Translation(Locales.en, "")]
	[CustomDisplayAttribute(2)]
	[Required]
	public double SingleLightRedTime { get; set; }
}