using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels.Constants;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;

public class DecelerationCoefficientEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Выполнить оценку q при различных скоростях")]
	[Translation(Locales.en, "Evaluate q at different speeds")]
	[CustomDisplay(1, enumType: typeof(EvaluateParameters))]
	public object IsParametersEvaluated  { get; set; }

	[Translation(Locales.ru, "Максимальное значение")]
	[Translation(Locales.en, "Maximum value")]
	[CustomDisplay(1)]
	[Required]
	public double MaxQ { get; set; }
	
	public override void MapTo(ModelParameters mp)
	{
	}

	public override object GetDefault()
	{
		return new DecelerationCoefficientEstimationSettingsModel
		{
			IsParametersEvaluated = new ComboBoxItem
			{
				Text = EvaluateParameters.No.GetDescription(),
				Value = EvaluateParameters.No
			},
			MaxQ = 1
		};
	}
}