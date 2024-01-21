using System;
using System.Drawing;
using System.Windows.Forms;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Helpers;

namespace TrafficFlowSimulation.Windows.Components;

public class LanguageComponent : IComponent
{
	private ToolStripDropDownButton _languageButton;

	public LanguageComponent(ToolStripDropDownButton languageButton)
	{
		_languageButton = languageButton;
	}

	public void Initialize()
	{
		_languageButton.DropDownItems.Clear();
		var availableLocales = SettingsHelper.Get<LocalizationSettings>().AvailableLocales;
		var currentLocale = SettingsHelper.Get<LocalizationSettings>().CurrentLocale;

		foreach (var locale in availableLocales)
		{
			var menuItem = new ToolStripMenuItem
			{
				Font = new Font("Segoe UI", 10.2F,
					FontStyle.Regular, GraphicsUnit.Point, 204)
			};

			switch (locale)
			{
				case Locales.ru:
				{
					const string text = "Русский";
					menuItem.Image = Properties.Resources.ru;
					menuItem.Name = Locales.ru;
					menuItem.Text = text;

					if (locale == currentLocale)
						SetCurrentLocaleInLanguageButton(_languageButton, text, Properties.Resources.ru_square);
					break;
				}

				case Locales.en:
				{
					const string text = "English";
					menuItem.Image = Properties.Resources.uk;
					menuItem.Name = Locales.en;
					menuItem.Text = text;

					if (locale == currentLocale)
						SetCurrentLocaleInLanguageButton(_languageButton, text, Properties.Resources.uk_square);
					break;
				}
			}

			menuItem.Click += MenuItem_Click;
			_languageButton.DropDownItems.Add(menuItem);
		}

		_languageButton.Font = new Font("Segoe UI", 10.2F,
			FontStyle.Regular, GraphicsUnit.Point,  204);
	}

	private void SetCurrentLocaleInLanguageButton(ToolStripDropDownButton languageButton, string text, Bitmap image)
	{
		languageButton.Text = text;
		languageButton.Image = image;
	}

	private void MenuItem_Click(object sender, EventArgs e)
	{
		var selectedItem = sender as ToolStripMenuItem;
		if (selectedItem == null) return;

		var owner = (selectedItem.Owner as ToolStripDropDownMenu)?.OwnerItem;
		if (owner == null) return;

		owner.Text = selectedItem.Text;

		var settings = SettingsHelper.Get<LocalizationSettings>();

		switch (selectedItem.Name)
		{
			case Locales.ru:
			{
				settings.CurrentLocale = Locales.ru;
				owner.Image = Properties.Resources.ru_square;
				break;
			}

			case Locales.en:
			{
				settings.CurrentLocale = Locales.en;
				owner.Image = Properties.Resources.uk_square;
				break;
			}
		}
		SettingsHelper.Set(settings);

		ServiceLocator.Current.GetInstance<MainWindowHelper>().LocalizeComponents();
	}
}