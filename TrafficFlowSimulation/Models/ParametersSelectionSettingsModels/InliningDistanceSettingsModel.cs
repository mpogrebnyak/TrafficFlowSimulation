﻿using System.ComponentModel.DataAnnotations;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;

public class InliningDistanceSettingsModel
{
	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1)]
	[Required, Range(1, 10000)]
	public int n { get; set; }
}