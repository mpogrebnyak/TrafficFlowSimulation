﻿using ChartRendering.Attribute;
using ChartRendering.Constants;
using EvaluationKernel.Helpers;
using EvaluationKernel.Models;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class RoadHoleModeSettingsModel : SpeedLimitChangingModeSettingsModel
{
	[Hidden]
	public override EnumItem Scroll { get; set; }

	[Hidden]
	public override int ScrollFor { get; set; }

	[Hidden]
	public override int SegmentsNumber { get; set; }

	[Hidden]
	public override string SegmentBeginning { get; set; }

	[Hidden]
	public override string SpeedInSegment { get; set; }

	[Translation(Locales.ru, "Длина препятстивия")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4)] 
	public double SegmentLenght { get; set; }

	[Translation(Locales.ru, "Скорость на препятстивии")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4)] 
	public double SegmentSpeed{ get; set; }

	public override object GetDefault()
	{
		return Default();
	}

	public override void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);

		for (var i = 0; i < mp.n; i++)
		{
			mp.Vn[i] = InitialSpeed;
			mp.lambda[i] = -EquationHelper.S(mp, InitialSpeed) * (i + 1);
		}
	}

	public static RoadHoleModeSettingsModel Default()
	{
		var p = new RoadHoleModeSettingsModel
		{
			Scroll = new EnumItem(AutoScroll.No),
			ScrollFor = 0,
			L = MaxL,
			InitialSpeed = 16.7,
			SegmentsNumber = 3,
			SegmentLenght = 2,
			SegmentSpeed = 1.38
		};
		p.SegmentBeginning = "1:0" + " 2:" + p.SegmentLenght + " 3:" + p.L;
		p.SpeedInSegment = "1:" + p.SegmentSpeed + " 2:" + p.InitialSpeed + " 3:" + p.InitialSpeed;

		return p;
	}
}