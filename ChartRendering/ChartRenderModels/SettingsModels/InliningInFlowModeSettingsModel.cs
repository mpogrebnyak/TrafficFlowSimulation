using System;
using ChartRendering.Attribute;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.Constants;
using Localization.Localization;
using Microsoft.Build.Framework;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public virtual bool ChangeFirstInliningInFlowCarColor{ get; set; }

	[Translation(Locales.ru, "Номер автомобиля\nдля перестроения")]
	[CustomDisplay(1)]
	[Required]
	public virtual int Number { get; set; }

	[Translation(Locales.ru, "Максимальное расстояние\nдо перестроения")]
	[CustomDisplay(2)]
	[Required]
	public virtual double Lenght { get; set; }

	[Translation(Locales.ru, "Максимальное расстяоние\nперед машиной\nдля перестроения")]
	[CustomDisplay(3)]
	[Required]
	public virtual double LenghtToInline { get; set; }

	[Hidden]
	[Translation(Locales.ru, "Перестроение всего потока")]
	[CustomDisplay(4, enumType: typeof(AllCarsChangeLine))]
	[Required]
	public virtual EnumItem IsAllCarsChangeLine { get; set; }

	public override object GetDefault()
	{
		var defaultBPM = BaseParametersModelForTwoFlows.Default();
		var defaultAPM = AdditionalParametersModel.Default();
		var defaultICP = InitialConditionsParametersModelForTwoFlows.Default();

		return new InliningInFlowModeSettingsModel
		{
			L = 5000,
			ChangeFirstInliningInFlowCarColor = true,
			Number = 1,
			Lenght = 100,
			LenghtToInline =  Math.Round(Math.Pow(defaultICP.m_Vn, 2) / (2 * defaultAPM.g * defaultAPM.mu) + defaultICP.m_Vn * (defaultBPM.m_tau + defaultBPM.m_tau_b) + defaultBPM.m_l_car + defaultBPM.m_l_safe, 2),
			IsAllCarsChangeLine = new EnumItem(AllCarsChangeLine.No)
		};
	}
}