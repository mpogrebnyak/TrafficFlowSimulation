using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class StartAndStopMovementModeSettingsModel : BaseParametersModel
{
	[Translation(Locales.ru, "Расстояние до остановки")]
	[Translation(Locales.en, "Distance to the stop")]
	[CustomDisplayAttribute(1)]
	[Required]
	public double L { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.L = L;
	}
}