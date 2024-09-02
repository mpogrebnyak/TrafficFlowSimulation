using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ChartRendering.Attribute;
using ChartRendering.Models;
using Common;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class MovementThroughMultipleTrafficLightsModeSettingsModel : BaseSettingsModels
{
	[Hidden]
	public override double L { get; set; } 

	[Translation(Locales.ru, "Количество светофоров")]
	[Translation(Locales.en, "Traffic lights number")]
	[CustomDisplay(1)]
	[Required, Range(2, 100)]
	public virtual int TrafficLightsNumber { get; set; }

	[Translation(Locales.ru, "Время зеленого сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2, true)] 
	public virtual string TrafficLightsGreenTime { get; set; }
	
	[Translation(Locales.ru, "Время красного сигнала")]
	[Translation(Locales.en, "")]
	[CustomDisplay(3, true)] 
	public virtual string TrafficLightsRedTime { get; set; }

	[Translation(Locales.ru, "Положение светофоров")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4, true)] 
	public virtual string TrafficLightsPosition { get; set; }

	public override object GetDefault()
	{
		return new MovementThroughMultipleTrafficLightsModeSettingsModel
		{
			L = MaxL,
			TrafficLightsNumber = 2,
			TrafficLightsGreenTime = "1:20, 2:10", 
			TrafficLightsRedTime = "1:10, 2:20",
			TrafficLightsPosition = "1:0, 2:100"
		};
	}

	public TrafficLightsParameters MapTo()
	{
		return new TrafficLightsParameters
		{
			TrafficLightsGreenTime = CommonParserHelper.ParseMultipleValues(TrafficLightsGreenTime).Values.ToList(),
			TrafficLightsRedTime = CommonParserHelper.ParseMultipleValues(TrafficLightsRedTime).Values.ToList(),
			TrafficLightsPosition = CommonParserHelper.ParseMultipleValues(TrafficLightsPosition).Values.ToList()
		};
	}

	public MovementThroughMultipleTrafficLightsModeSettingsModel MapFrom(MovementThroughOneTrafficLightModeSettingsModel model)
	{
		return new MovementThroughMultipleTrafficLightsModeSettingsModel
		{
			L = model.L,
			TrafficLightsNumber = 1,
			TrafficLightsGreenTime = "1:" + model.SingleLightGreenTime, 
			TrafficLightsRedTime = "1:" + model.SingleLightRedTime,
			TrafficLightsPosition = "1:0"
		};
	}
}
