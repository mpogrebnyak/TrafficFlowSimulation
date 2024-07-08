using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ChartRendering.Attribute;
using ChartRendering.Helpers;
using Localization;
using Localization.Localization;
using Settings;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows;

namespace TrafficFlowSimulation.Helpers;

public class LocalizationWindowHelper
{
	private readonly MainWindow _form;

	private readonly Dictionary<Type, BindingSource> _bindingSources;

	public LocalizationWindowHelper(MainWindow form, Dictionary<Type, BindingSource> bindingSources)
	{
		_form = form;
		_bindingSources = bindingSources;
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

			if (value.ToString() == ModesHelper.GetCurrentDrivingMode())
				_form.DrivingModeStripDropDownButton.Text = value.GetDescription();
		}

		LocalizeToolTip();

		foreach (var source in _bindingSources)
		{
			source.Value.ResetBindings(false);
		}
	}

	private void LocalizeToolTip()
	{
		var toolTip = new ToolTip();
		toolTip.SetToolTip(_form.EstimateTrafficCapacityCheckBox, LocalizationHelper.Get<MainWindowResources>().EstimateTrafficCapacityCheckBoxToolTip);
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