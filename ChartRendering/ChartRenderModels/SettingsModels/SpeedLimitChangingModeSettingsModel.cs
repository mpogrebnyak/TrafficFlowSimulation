using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using Common.Errors;
using EvaluationKernel.Helpers;
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

	[Translation(Locales.ru, "Начальная скорость")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2)]
	[Required]
	public virtual double InitialSpeed { get; set; }

	[Translation(Locales.ru, "Начало отрезков")]
	[Translation(Locales.en, "")]
	[CustomDisplay(3, true, placeHolder: "1:100 2:200 3:300")] 
	public string SegmentBeginning { get; set; }

	[Translation(Locales.ru, "Скорость на отрезках")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4, true, placeHolder: "1:16.7 2:8.3 3:16.7")]
	[Required]
	public string SpeedInSegment { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);

		for (int i = 0; i < mp.n; i++)
		{
			mp.Vn[i] = InitialSpeed;
			mp.lambda[i] = -EquationHelper.S(mp, 16) * (i);
		}
	}

	public void MapTo(SortedDictionary<int, SegmentModel> segmentSpeeds)
	{
		var segmentBeginning = ChartRenderModelHelper.ParseMultipleValues(SegmentBeginning);
		var speedInSegment = ChartRenderModelHelper.ParseMultipleValues(SpeedInSegment);

		if (segmentBeginning.Count != SegmentsNumber)
		{
			throw new ParametersException(nameof(SegmentBeginning), "Ошибка");
		}

		if (segmentBeginning.Count != SegmentsNumber && speedInSegment.Count != SegmentsNumber)
		{
			throw new ParametersException(nameof(SegmentBeginning), "Ошибка");
		}

		segmentSpeeds.Add(0, new SegmentModel
		{
			SegmentBeginning = -MaxL,
			Speed = InitialSpeed
		});

		for (var i = 0; i < SegmentsNumber; i++)
		{
			segmentSpeeds.Add(i + 1, new SegmentModel
			{
				SegmentBeginning = segmentBeginning[i],
				Speed = speedInSegment[i],
			});
		}

		segmentSpeeds.Add(SegmentsNumber + 1, new SegmentModel
		{
			SegmentBeginning = MaxL,
			Speed = 0
		});
	}

	public override object GetDefault()
	{
		return Default();
	}

	public static SpeedLimitChangingModeSettingsModel Default()
	{
		var n = 3;
		var segmentBeginning = string.Empty;
		var speedInSegment = string.Empty;
		for (var i = 0; i < n; i++)
		{
			segmentBeginning += i + 1 + ":" + 100 * i + ' ';
			speedInSegment += i + 1 + ":" + ((i % 2 == 0 ? 16.7 : 8.3)) + ' ';
		}
		return new SpeedLimitChangingModeSettingsModel
		{
			Scroll = new EnumItem(AutoScroll.No),
			ScrollFor = 0,
			L = MaxL,
			InitialSpeed = 16.7,
			SegmentsNumber = n,
			SegmentBeginning = segmentBeginning,
			SpeedInSegment = speedInSegment
		};
	}
}