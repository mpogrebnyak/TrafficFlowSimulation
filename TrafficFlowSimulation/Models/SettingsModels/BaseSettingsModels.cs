using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class BaseSettingsModels : ValidationModel, IModel
{
	[Translation(Locales.ru, "Расстояние до остановки")]
	[Translation(Locales.en, "Distance to the stop")]
	[CustomDisplay(1)]
	[Required]
	public virtual double L { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.L = L;
	}

	public virtual object GetDefault()
	{
		return new BaseSettingsModels
		{
			L = 0
		};
	}
}