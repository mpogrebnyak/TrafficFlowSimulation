using ChartRendering.Attribute;
using EvaluationKernel.Models;
using Localization.Localization;
using Microsoft.Build.Framework;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels;

public class BaseSettingsModels : ValidationModel, ISettingsModel
{
	protected const double MaxL = (double) (decimal.MaxValue / 2);

//	[Hidden]
	public virtual EnumItem Scroll { get; set; }

//	[Hidden]
	public virtual int ScrollFor { get; set; }

	[Translation(Locales.ru, "Расстояние до остановки")]
	[Translation(Locales.en, "Distance to the stop")]
	[CustomDisplay(3)]
	[Required]
	public virtual double L { get; set; }

	public virtual void MapTo(ModelParameters mp)
	{
		mp.L = L;
	}

	public virtual void MapToSelf() { }

	public virtual object GetDefault()
	{
		return null;
	}
}