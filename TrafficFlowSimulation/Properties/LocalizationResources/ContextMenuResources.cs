﻿using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public class ContextMenuResources
{
	[Translation(Locales.ru, "Легенда")]
	[Translation(Locales.en, "Legend")]
	public string LegendToolStripMenuItem { get; set; }

	[Translation(Locales.ru, "Отображать полностью")]
	[Translation(Locales.en, "Display full")]
	public string DisplayLegendFullMenuItem { get; set; }

	[Translation(Locales.ru, "Отображать частично")]
	[Translation(Locales.en, "Display partially")]
	public string DisplayLegendPartiallyMenuItem { get; set; }

	[Translation(Locales.ru, "Скрыть")]
	[Translation(Locales.en, "Hide")]
	public string HideLegendMenuItem { get; set; }

	[Translation(Locales.ru, "Оси")]
	[Translation(Locales.en, "Axes")]
	public string AxesToolStripMenuItem { get; set; }

	[Translation(Locales.ru, "Показать")]
	[Translation(Locales.en, "Display")]
	public string DisplayAxesMenuItem { get; set; }

	[Translation(Locales.ru, "Скрыть")]
	[Translation(Locales.en, "Hide")]
	public string HideAxesMenuItem { get; set; }

	[Translation(Locales.ru, "Показать график скорости от расстояния")]
	[Translation(Locales.en, "Show speed from distance chart")]
	public string ShowSpeedFromDistanceChartMenuItem { get; set; }

	[Translation(Locales.ru, "Сохранить")]
	[Translation(Locales.en, "Save")]
	public string SaveChartToolStripMenuItem { get; set; }

	[Translation(Locales.ru, "Сохранить изображение как ...")]
	[Translation(Locales.en, "Save image as ...")]
	public string SaveImageText { get; set; }
}