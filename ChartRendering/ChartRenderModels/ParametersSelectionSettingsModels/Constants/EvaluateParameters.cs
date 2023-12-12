using Localization.Localization;

namespace TrafficFlowSimulation.Models.ChartRenderModels.ParametersSelectionSettingsModels.Constants;

public class EvaluateParametersResources
{
	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}

public enum EvaluateParameters
{
	[LocalizedDescription("Yes", typeof(EvaluateParametersResources))]
	Yes = 1,

	[LocalizedDescription("No", typeof(EvaluateParametersResources))]
	No = 2
}