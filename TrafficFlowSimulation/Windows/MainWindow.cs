using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.MovementSimulation;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		private MainWindowHelper _mainWindowHelper;
		// вынести в хелпер, там создать, от туда и получать
		// создать тут передать в конструктор хелпера и из него все возвращать
		//private LocalizationComponentsModel _localizationComponents;
		//private AllChartsModel _allCharts;
		//private TableLayoutPanelsModel _panels;
		//private Dictionary<Type, BindingSource> _bindingSources = new();

		public MainWindow()
		{
			InitializeComponent();
			CustomInitializeComponent();
			InitializeInterface();

			//доделать
			//MultipleField_tau.Enabled = false;
			SaveButton.Enabled = false;
			LoadButton.Enabled = false;
		}

		private void CustomInitializeComponent()
		{
			carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
			chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;
			ControlMenuStrip.Renderer = new ControlToolStripCustomRender();
			ChartContainerСontextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new SubMenuCustomColorTable());

			var allCharts = new AllChartsModel
			{
				SpeedChart = speedChart,
				DistanceChart = distanceChart,
				CarsMovementChart = carsMovementChart
			};

			var localizationComponents = new LocalizationComponentsModel
			{
				AllCharts = allCharts,
				LocalizationBinding = LocalizationBinding,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = languagesSwitcherButton,
				StartToolStripButton = StartToolStripButton,
				StopToolStripButton = StopToolStripButton,
				ContinueToolStripButton = ContinueToolStripButton,
				DrivingModeStripLabel = DrivingModeStripLabel,
			};

			var panels = new TableLayoutPanelsModel
			{
				BasicParametersTableLayoutPanel = BasicParametersTableLayoutPanel,
				AdditionalParametersTableLayoutPanel = AdditionalParametersTableLayoutPanel,
				InitialConditionsTableLayoutPanel = InitialConditionsTableLayoutPanel,
				SettingsTableLayoutPanel = SettingsTableLayoutPanel
			};

			_mainWindowHelper = new MainWindowHelper(localizationComponents,
				allCharts,
				panels,
				ParametersErrorProvider
			);

			MovementSimulationConfiguration.Registrate(allCharts);
		}

		private void InitializeInterface()
		{
			_mainWindowHelper.InitializeInterface();
			DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, _mainWindowHelper);

			//_mainWindowHelper.InitializeTableLayoutPanelComponent(_panels, _bindingSources, ParametersErrorProvider);
			//LocalizationService.Translate(_localizationComponents);

			//var defaultModeSettings = ModeSettingsMapper.GetDefault();
			//ModeSettingsBinding.DataSource = defaultModeSettings;

			//MainWindowHelper.ShowCurrentModeSettingsFields(Controls.Owner);
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			parametersPanel.Hide();
			ModeSettingsBinding.EndEdit();

			var modelParameters = _mainWindowHelper.CollectParametersFromBindingSource();
			//var ee = (EditModelParameters)EditModelParametersBinding.DataSource;
			//var isAllCarsIdentical = MainWindowHelper.IsAllCarsIdentical(IdenticalCarsComboBox);
			//var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			
			// временно возьмем значения по умолчанию, потом сделаем закгрузку с интерфейса
			// var modeSettings = new ModeSettingsModel();
			//modeSettings.MapTo(ModelParametersBinding.DataSource);
			var modeSettings = ModeSettingsMapper.MapModel(ModeSettingsBinding.DataSource);

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);

			//ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
			//RenderingHelper.CreateCharts(_allCharts, modelParameters);

			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).AbortExecution();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).Execute(
				this,
				modelParameters,
				modeSettings);
			//EvaluationHandler.AbortExecution();
			//EvaluationHandler.Execute(
			//	_allCharts,
			//	modelParameters,
			//	modeSettings
			//	);
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).AbortExecution();

			//CarsRenderingHelper.DeleteFolder();
			//EvaluationHandler.AbortExecution();
		}

		private void SlamPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (parametersPanel.Visible)
				parametersPanel.Hide();
			else
				parametersPanel.Show();
		}

		private void EnglishMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("En");
			languagesSwitcherButton.Image = Properties.Resources.united_kingdom;
			LocalizationService.Translate(_mainWindowHelper.LocalizationComponents);
			//DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, Controls.Owner);
			
			
			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.Locale = "en";
			SettingsHelper.Set<Properties.Settings>(settings);
		//	var tableLayoutPanelComponent = new TableLayoutPanelComponent(
		//		BasicParametersTableLayoutPanel, 
		//		EditModelParametersBinding,
		//		ParametersErrorProvider);
		//	tableLayoutPanelComponent.Initialize(typeof(EditBasicModelParameters));

		}

		private void RussianMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
			languagesSwitcherButton.Image = Properties.Resources.russia;
			LocalizationService.Translate(_mainWindowHelper.LocalizationComponents);
			//DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, Controls.Owner);
			
			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.Locale = "ru";
			SettingsHelper.Set<Properties.Settings>(settings);
		//	var tableLayoutPanelComponent = new TableLayoutPanelComponent(
		//		BasicParametersTableLayoutPanel, 
		//		EditModelParametersBinding,
		//		ParametersErrorProvider);
		//	tableLayoutPanelComponent.Initialize(typeof(EditBasicModelParameters));

		}

		private void StopToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).StopExecution();
		}

		private void ContinueToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).StartExecution();
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.SaveChart(chart);
		}

		private void HideLegendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, null);
		}

		private void ShowFullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, LegendStyle.Table);
		}

		private void ShowPartiallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, LegendStyle.Column);
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			var modelParameters = _mainWindowHelper.CollectParametersFromBindingSource();
			
			//((EditBasicModelParameters)ee.DataSource).MapTo(modelParameters);
			//((EditBasicModelParameters) ee.DataSource).MapTo(modelParameters);

		//	var ee2 = _bindingSources.Single(x => x.Key == typeof(EditAdditionalModelParameters));
		//	((EditAdditionalModelParameters)ee2.Value.DataSource).MapTo(modelParameters);
			//editModelParameters.MapTo(modelParameters);
			//var isAllCarsIdentical = (IdenticalCars)(IdenticalCarsComboBox.SelectedItem as ComboboxItem).Value;
			//var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, isAllCarsIdentical);

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
			//RenderingHelper.CreateCharts(_allCharts, modelParameters);
		}

		private void HideAxisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowAxis(chart, true);
		}

		private void ShowAxisToolStripMenuItem_Click(object sender, EventArgs e)
		{ 
			var chart = _mainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowAxis(chart, false);
		}

		//private void DrawColoredItems(object sender, DrawItemEventArgs e)
		//{
		//	var comboBox = sender as ComboBox;
		//	MainWindowHelper.DrawColoredItems(comboBox, e);
		//}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			if (_mainWindowHelper != null && _mainWindowHelper.AllCharts != null)
			{
				ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
			}
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			var modelParameters = _mainWindowHelper.CollectParametersFromBindingSource();

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
			// проинициализировать чарты в этом месте 
			//ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
		}
	}
}
