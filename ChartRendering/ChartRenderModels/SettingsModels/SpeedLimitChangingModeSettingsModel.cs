using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using Common;
using Common.Errors;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class SpeedLimitChangingModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Следовать за автомобилем")]
	[CustomDisplay(1, enumType: typeof(AutoScroll))]
	public override EnumItem Scroll { get; set; }

	[Translation(Locales.ru, "Номер автомобиля")]
	[CustomDisplay(2)]
	public override int ScrollFor { get; set; }

	[Translation(Locales.ru, "Количество отрезков")]
	[Translation(Locales.en, "")]
	[CustomDisplay(1)]
	[Required]
	public virtual int SegmentsNumber { get; set; }

	[Translation(Locales.ru, "Начальная скорость потока")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2)]
	[Required]
	public virtual double InitialSpeed { get; set; }

	[Translation(Locales.ru, "Начало отрезков")]
	[Translation(Locales.en, "")]
	[CustomDisplay(3, true, placeHolder: "1:100 2:200 3:300")] 
	public virtual string SegmentBeginning { get; set; }

	[Translation(Locales.ru, "Скорость на отрезках")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4, true, placeHolder: "1:16.7 2:8.3 3:16.7")]
	[Required]
	public virtual string SpeedInSegment { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);

		for (var i = 0; i < mp.n; i++)
		{
			mp.Vn[i] = InitialSpeed;
			mp.lambda[i] = -100 - (Equation.S(mp, i, InitialSpeed) + mp.tau[i] * InitialSpeed) * i;
		}
	}

	public void MapTo(SortedDictionary<int, SegmentModel> segmentSpeeds)
	{
		var segmentBeginning = CommonParserHelper.ParseMultipleValues(SegmentBeginning);
		var speedInSegment = CommonParserHelper.ParseMultipleValues(SpeedInSegment);

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

		for (var i = 1; i <= SegmentsNumber; i++)
		{
			segmentSpeeds.Add(i, new SegmentModel
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
		var n = 2;
		var segmentBeginning = string.Empty;
		var speedInSegment = string.Empty;
		for (var i = 0; i < n; i++)
		{
			segmentBeginning += i + 1 + ":" + (100 * i + 50) + ' ';
			speedInSegment += i + 1 + ":" + ((i % 2 == 0 ? 8 : 8)) + ' ';
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

	public void GetSegmentBeginningList(SortedDictionary<int, SegmentModel> segmentSpeeds, out List<double> segmentBeginningList, out List<double> segmentSpeedList)
	{
		segmentBeginningList = segmentSpeeds
			.Where(x => x.Key != 0 && x.Key != SegmentsNumber + 1)
			.Select(x=> x.Value.SegmentBeginning)
			.ToList();

		segmentSpeedList = segmentSpeeds
			.Where(x => x.Key != SegmentsNumber + 1)
			.Select(x=> x.Value.Speed)
			.ToList();
	}
}