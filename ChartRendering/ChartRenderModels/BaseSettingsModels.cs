using ChartRendering.Attribute;
using EvaluationKernel.Models;
using Localization.Localization;
using Microsoft.Build.Framework;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels;

public abstract class BaseSettingsModels : ISettingsModel
{
	[Translation(Locales.ru, "Расстояние до остановки")]
	[Translation(Locales.en, "Distance to the stop")]
	[CustomDisplay(1)]
	[Required]
	public virtual double L { get; set; }

	public virtual void MapTo(ModelParameters mp)
	{
		mp.L = L;
	}

	public abstract object GetDefault();
}