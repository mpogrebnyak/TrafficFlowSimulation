using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Localization.Localization;
using Settings;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Windows.Components;

public class TableLayoutPanelComponent : IComponent
{
	private static TableLayoutPanelComponentHelper _helper;

	private static BindingSource _bindingSource;

	private TableLayoutPanel _tableLayoutPanel;

	private ErrorProvider _errorProvider;

	private Type _modelType;

	private static readonly Font Font = new ("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);

	private static readonly string _textBoxPrefix = "textBox_";
	private static readonly string _labelPrefix = "label_";
	private static readonly string _comboBoxPrefix = "comboBox_";

	protected static readonly string _multipleTag = "multiple";

	public TableLayoutPanelComponent(
		Type modelType,
		TableLayoutPanel? tableLayoutPanel, 
		Dictionary<Type, BindingSource> bindingSources, 
		ErrorProvider errorProvider)
	{
		if (tableLayoutPanel == null)
			throw new InvalidOperationException();

		_modelType = modelType;
		_tableLayoutPanel = tableLayoutPanel;
		_errorProvider = errorProvider;

		_helper = new TableLayoutPanelComponentHelper(_multipleTag);
		_tableLayoutPanel.CellPaint += _helper.TableLayoutCellPaintEvent;

		if (bindingSources.ContainsKey(modelType))
			bindingSources.Remove(modelType);

		var bindingSource = _helper.CreateBindingSource(modelType);
		bindingSources.Add(modelType, bindingSource);
		_bindingSource = bindingSource;
	}

	public void Initialize()
	{
		var locale = SettingsHelper.Get<LocalizationSettings>().CurrentLocale;
		var controls = _tableLayoutPanel.Controls;

		_tableLayoutPanel.Controls.Clear();
		_tableLayoutPanel.RowCount = 0;
		var row = _tableLayoutPanel.RowCount - 1;
		var counter = 0;

		var properties = from property in _modelType.GetProperties()
			where !Attribute.IsDefined(property, typeof(HiddenAttribute))&& Attribute.IsDefined(property, typeof(CustomDisplayAttribute))
			orderby ((CustomDisplayAttribute)property
				.GetCustomAttributes(typeof(CustomDisplayAttribute), false)
				.Single()).Order
			select property;

		foreach (var property in properties)
		{
			row++;
			var translationAttribute = (TranslationAttribute[])property.GetCustomAttributes(typeof(TranslationAttribute), false);
			var text = translationAttribute.SingleOrDefault(x => x.Locale == locale)?.Value;

			var displayFormatAttribute = (CustomDisplayAttribute[])property.GetCustomAttributes(typeof(CustomDisplayAttribute), false);
			var attribute = displayFormatAttribute.Single();

			if (attribute.EnumType != null)
			{
				var comboBox = CreateComboBox(property.Name, property.Name, attribute.EnumType, attribute.IsHidden, attribute.IsReadOnly, counter++);
				if (attribute.IsMultiple)
				{
					controls.Add(comboBox, 0, row);
					_tableLayoutPanel.SetColumnSpan(comboBox, 2);
				}
				else
				{
					var label = CreateLabel(property.Name, text, counter++);
					controls.Add(label, 0, row);
					controls.Add(comboBox, 1, row);
				}

				continue;
			}

			var textBox = CreateTextBox(property.Name, property.Name, _tableLayoutPanel.Size.Width, attribute.IsHidden, attribute.IsReadOnly, counter++);
			if (attribute.IsMultiple)
			{
				textBox.Tag = _multipleTag;
				controls.Add(textBox, 0, row);
				_tableLayoutPanel.SetColumnSpan(textBox, 2);
			}
			else
			{
				var label = CreateLabel(property.Name, text, counter++);
				controls.Add(label, 0, row);
				controls.Add(textBox, 1, row);
			}
			_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleLeft);
		}
	}

	private TextBox CreateTextBox(string name, string dataMember, int width, bool isHidden, bool isReadOnly, int tabIndex)
	{
		var textBox = new TextBox
		{
			Font = Font,
			Name = _textBoxPrefix + name,
			Size = new Size(width, 27),
			TabIndex = tabIndex
		};

		textBox.DataBindings.Add(new Binding("Text", _bindingSource, dataMember, true));
		if(isHidden) textBox.Hide();
		if(isReadOnly) textBox.Enabled = false;

		return textBox;
	}

	private Label CreateLabel(string name, string? text, int tabIndex)
	{
		var label = new Label
		{
			Font = Font,
			Name = _labelPrefix + name,
			Text = text,
			Anchor = AnchorStyles.Left,
			AutoSize = true,
			TabIndex = tabIndex
		};

		return label;
	}

	private ComboBox CreateComboBox(string name, string dataMember, Type enumType, bool isHidden, bool isReadOnly, int tabIndex)
	{
		var comboBox = new ComboBox
		{
			Font = Font,
			Name = _comboBoxPrefix + name,
			DrawMode = DrawMode.OwnerDrawVariable,
			DropDownStyle = ComboBoxStyle.DropDownList,
			FormattingEnabled = true,
			Tag = enumType,
			TabIndex = tabIndex
		};

		comboBox.DataSource = _helper.GetComboBoxDataSource(enumType);
		comboBox.DataBindings.Add(new Binding("SelectedItem", _bindingSource, dataMember, true));

		comboBox.DrawItem += _helper.ComboBoxDrawItemEvent;
		comboBox.SelectedIndexChanged += _helper.GetComboBoxSelectedIndexChangedEvent(enumType);

		if(isHidden) comboBox.Hide();
		if(isReadOnly) comboBox.Enabled = false;

		return comboBox;
	}
}