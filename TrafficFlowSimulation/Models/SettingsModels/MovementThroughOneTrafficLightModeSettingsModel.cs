using System.ComponentModel.DataAnnotations;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;
using TrafficFlowSimulation.Models.SettingsModels.Constants;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class MovementThroughOneTrafficLightModeSettingsModel : BaseSettingsModels
{
	[Hidden]
	public override double L { get; set; } 

	[Translation(Locales.ru, "Цвет первого сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2, enumType: typeof(FirstTrafficLightColor))]
	[Required]
	public object FirstTrafficLightColor { get; set; }

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
}
