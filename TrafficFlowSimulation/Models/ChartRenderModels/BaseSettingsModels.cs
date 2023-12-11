using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ChartRenderModels;

public class BaseSettingsModels : BaseChartRenderModel
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

	public override object GetDefault()
	{
		return new BaseSettingsModels
		{
			L = 0
		};
	}
}