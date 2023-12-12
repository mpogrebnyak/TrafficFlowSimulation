using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Helpers;
using Common.Errors;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class SpeedLimitChangingModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Количество отрезков")]
	[Translation(Locales.en, "")]
	[CustomDisplay(1)]
	[Required]
	public int SegmentsNumber { get; set; }

	[Translation(Locales.ru, "Начало отрезков")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2, true, placeHolder: "1:100 2:200 3:300")] 
	public string SegmentBeginning { get; set; }

	[Translation(Locales.ru, "Скорость на отрезках")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4, true, placeHolder: "1:10 2:5 3:15")]
	[Required]
	public string SpeedInSegment { get; set; }

	public new void MapTo(SortedDictionary<int, SegmentModel> segmentSpeeds)
	{
		var segmentBeginning = ChartRenderModelHelper.ParseMultipleValues(SegmentBeginning);
		var speedInSegment = ChartRenderModelHelper.ParseMultipleValues(SpeedInSegment);

		if (segmentBeginning.Count != SegmentsNumber)
		{
			throw new ParametersException(nameof(SegmentBeginning), "Ошибка");
		}

		if (segmentBeginning.Count != SegmentsNumber && speedInSegment.Count != SegmentsNumber)
		{
			
		}

		for (var i = 0; i < SegmentsNumber; i++)
		{
			segmentSpeeds.Add(i + 1, new SegmentModel
			{
				SegmentBeginning = 0,
				Speed = 0
			});
		}
		/*	segmentSpeeds.Add(1, new SegmentModel
			{
				SegmentBeginning = SegmentBeginning,
				Speed = 5
			});
			segmentSpeeds.Add(2, new SegmentModel
			{
				SegmentBeginning = SegmentEnding,
				Speed = 10
			});
			segmentSpeeds.Add(3, new SegmentModel
			{
				SegmentBeginning = L,
				Speed = 0
			});
			*/
	}
	
	public override object GetDefault()
	{
		return Default();
	}

	public static SpeedLimitChangingModeSettingsModel Default()
	{
		return new SpeedLimitChangingModeSettingsModel
		{
			L = 10
		};
	}
}