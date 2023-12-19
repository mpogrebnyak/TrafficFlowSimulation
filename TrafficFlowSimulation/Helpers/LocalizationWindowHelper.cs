using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Attribute;
using ChartRendering.Helpers;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders;
using Localization;
using Localization.Localization;
using Modes;
using Modes.Constants;
using Settings;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows;

namespace TrafficFlowSimulation.Helpers;

public class LocalizationWindowHelper
{
	private readonly MainWindow _form;

	public LocalizationWindowHelper(MainWindow form)
	{
		_form = form;
	}

	public void LocalizeComponents()
	{
		_form.StartToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().StartButtonTitle;
		_form.StopToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().StopButtonTitle;
		_form.ContinueToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().ContinueButtonTitle;
		_form.DrivingModeStripLabel.Text = LocalizationHelper.Get<MainWindowResources>().DrivingModeLabel;
		_form.MovementParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().MovementParametersGroupBoxText;
		_form.ModeSettingsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().ModeSettingsGroupBoxText;
		_form.BasicParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().BasicParametersGroupBoxText;
		_form.AdditionalParametersGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().AdditionalParametersGroupBoxText;
		_form.InitialConditionsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().InitialConditionsGroupBoxText;
		_form.ControlsGroupBox.Text = LocalizationHelper.Get<MainWindowResources>().ControlsGroupBoxText;
		_form.SubmitButton.Text = LocalizationHelper.Get<MainWindowResources>().SubmitButtonText;
		_form.ParametersSelectionToolStripButton.Text = LocalizationHelper.Get<MainWindowResources>().ParametersSelectionButtonText;
		_form.EstimateTrafficCapacityCheckBox.Text = LocalizationHelper.Get<MainWindowResources>().EstimateTrafficCapacityCheckBoxText;

		foreach (var value in ModesHelper.GetAvailableDrivingModes())
		{
			_form.DrivingModeStripDropDownButton.DropDownItems.Cast<ToolStripMenuItem>().Single(x => x.Name == value.ToString()).Text = value.GetDescription();

			if (value == ModesHelper.GetCurrentDrivingMode())
				_form.DrivingModeStripDropDownButton.Text = value.GetDescription();
		}

		LocalizeCharts();
	}

	private void LocalizeCharts()
	{
		LocalizeChartLegend(_form.DistanceChart);
		LocalizeChartLegend(_form.SpeedChart);
		LocalizeChartLegend(_form.CarsMovementChart);
		//LocalizeChartLegend(_form.SpeedFromDistanceChart);

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