using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Attribute;
using ChartRendering.Constants.Modes;
using ChartRendering.Properties;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders;
using Localization;
using Localization.Localization;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

namespace TrafficFlowSimulation.Windows.Helpers;

public class LocalizationWindowHelper
{
	public LocalizationComponentsModel _lc;

	public LocalizationWindowHelper(LocalizationComponentsModel localizationComponentsModel)
	{
		_lc = localizationComponentsModel;
	}

	public void LocalizeComponents()
	{
		_lc.StartToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().StartButtonTitle;
		_lc.StopToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().StopButtonTitle;
		_lc.ContinueToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().ContinueButtonTitle;
		_lc.DrivingModeStripLabel.Text = LocalizationHelper.Get<MainWindowResources>().DrivingModeLabel;
		_lc.MovementParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().MovementParametersGroupBoxText;
		_lc.ModeSettingsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().ModeSettingsGroupBoxText;
		_lc.BasicParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().BasicParametersGroupBoxText;
		_lc.AdditionalParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().AdditionalParametersGroupBoxText;
		_lc.InitialConditionsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().InitialConditionsGroupBoxText;
		_lc.ControlsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().ControlsGroupBoxText;
		_lc.SubmitButton.Text = LocalizationHelper.Get<MainWindowResources>().SubmitButtonText;
		_lc.ParametersSelectionToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().ParametersSelectionButtonText;
		_lc.EstimateTrafficCapacityCheckBox.Text = LocalizationHelper.Get<MainWindowResources>().EstimateTrafficCapacityCheckBoxText;

		foreach (DrivingMode value in SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().AvailableDrivingModes)
		{
			_lc.DrivingModeStripDropDownButton.DropDownItems.Cast<ToolStripMenuItem>().Single(x => x.Name == value.ToString()).Text = value.GetDescription();

			if (value == SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentDrivingMode)
				_lc.DrivingModeStripDropDownButton.Text = value.GetDescription();
		}

		LocalizeCharts();
	}

	private void LocalizeCharts()
	{
		LocalizeChartLegend(_lc.AllCharts.DistanceChart);
		LocalizeChartLegend(_lc.AllCharts.SpeedChart);
		LocalizeChartLegend(_lc.AllCharts.CarsMovementChart);

		/*LocalizeAxes(_lc.AllCharts.DistanceChart,
			LocalizationHelper.Get<ChartResources>().TimeAxisTitleText,
			LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText);
		LocalizeAxes(_lc.AllCharts.SpeedChart,
			LocalizationHelper.Get<ChartResources>().TimeAxisTitleText,
			LocalizationHelper.Get<ChartResources>().SpeedAxisTitleText);
		LocalizeAxes(_lc.AllCharts.CarsMovementChart,
			LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
			string.Empty);*/
	}

	private void LocalizeChartLegend(Chart chart)
	{
		if (chart.Legends.Any())
			RenderingHelper.DisplayChartLegend(chart, chart.Legends[0].LegendStyle);
		else
			RenderingHelper.DisplayChartLegend(chart, null);
	}

	private void LocalizeAxes(Chart chart, string xAxisText, string yAxisText)
	{
		if (chart.ChartAreas.Any() && !String.IsNullOrEmpty(chart.ChartAreas[0].AxisX.Title))
			chart.ChartAreas[0].AxisX.Title = xAxisText;

		if (chart.ChartAreas.Any() && !String.IsNullOrEmpty(chart.ChartAreas[0].AxisY.Title))
			chart.ChartAreas[0].AxisY.Title = yAxisText;
	}

	public void LocalizePanel(Type modelType, TableLayoutPanel? tableLayoutPanel)
	{
		if (tableLayoutPanel == null) return;

		var locale = SettingsHelper.Get<LocalizationSettings>().CurrentLocale;

		var controls = tableLayoutPanel.Controls;
		var labelsList = new List<Label>();
		var comboBoxesList = new List<ComboBox>();

		foreach (var control in controls)
		{
			switch (control)
			{
				case Label label:
					labelsList.Add(label);
					break;
				case ComboBox comboBox:
					comboBoxesList.Add(comboBox);
					break;
			}
		}

		var properties = from property in modelType.GetProperties()
			where !Attribute.IsDefined(property, typeof(HiddenAttribute))&& Attribute.IsDefined(property, typeof(CustomDisplayAttribute))
			orderby ((CustomDisplayAttribute) property
				.GetCustomAttributes(typeof(CustomDisplayAttribute), false)
				.Single()).Order
			select property;

		foreach (var property in properties)
		{
			var translationAttribute = (TranslationAttribute[])property.GetCustomAttributes(typeof(TranslationAttribute), false);

			var regex = new Regex(@"." + property.Name + "$");
			var label = labelsList.SingleOrDefault(x => regex.IsMatch(x.Name));
			if (label != null)
			{
				var text = translationAttribute.SingleOrDefault(x => x.Locale == locale)?.Value;
				label.Text = text;
			}
		}

		EnumComboBoxHelper.LocalizeEnumComboBoxItems(comboBoxesList);
	}
}