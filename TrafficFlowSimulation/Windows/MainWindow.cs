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
using TrafficFlowSimulation.MovementSimulation;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Models;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		// вынести в хелпер, там создать, от туда и получать
		private LocalizationComponentsModel _localizationComponents;
		private AllChartsModel _allCharts;
		private TableLayoutPanelsModel _panels;
		private Dictionary<Type, BindingSource> _bindingSources = new();

		public MainWindow()
		{
			InitializeComponent();
			CustomInitializeComponent();
			InitializeInterface();

			//доделать
			MultipleField_tau.Enabled = false;
			SaveButton.Enabled = false;
			LoadButton.Enabled = false;
		}

		private void CustomInitializeComponent()
		{
			carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
			chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;
			ControlMenuStrip.Renderer = new ControlToolStripCustomRender();
			ChartContainerСontextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new SubMenuCustomColorTable());

			_allCharts = new AllChartsModel
			{
				SpeedChart = speedChart,
				DistanceChart = distanceChart,
				CarsMovementChart = carsMovementChart
			};

			_localizationComponents = new LocalizationComponentsModel
			{
				AllCharts = _allCharts,
				LocalizationBinding = LocalizationBinding,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = languagesSwitcherButton,
				StartToolStripButton = StartToolStripButton,
				StopToolStripButton = StopToolStripButton,
				ContinueToolStripButton = ContinueToolStripButton,
				DrivingModeStripLabel = DrivingModeStripLabel,
			};

			_panels = new TableLayoutPanelsModel
			{
				BasicParametersTableLayoutPanel = BasicParametersTableLayoutPanel,
				AdditionalParametersTableLayoutPanel = AdditionalParametersTableLayoutPanel,
				InitialConditionsTableLayoutPanel = InitialConditionsTableLayoutPanel
			};

			MovementSimulationConfiguration.Registrate(_allCharts);
		}

		private void InitializeInterface()
		{
			DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, Controls.Owner);

			MainWindowHelper.InitializeTableLayoutPanelComponent(_panels, _bindingSources, ParametersErrorProvider);
			LocalizationService.Translate(_localizationComponents);

			var defaultModelParameters = ModelParametersMapper.GetDefaultParameters();
			ModelParametersBinding.DataSource = defaultModelParameters;

			var defaultModeSettings = ModeSettingsMapper.GetDefault();
			ModeSettingsBinding.DataSource = defaultModeSettings;

			//EditModelParametersBinding.DataSource = new EditBasicModelParameters
			//{
			//	n = 100,
			//	Vmax_multiple = "123",
			//};
			//var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			//RenderingHelper.CreateCharts(_allCharts, modelParameters);
			//ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);

			MainWindowHelper.ShowCurrentModeSettingsFields(Controls.Owner);
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			parametersPanel.Hide();
			ModelParametersBinding.EndEdit();
			ModeSettingsBinding.EndEdit();
			EditModelParametersBinding.EndEdit();


			var ee = (EditModelParameters)EditModelParametersBinding.DataSource;
			//var isAllCarsIdentical = MainWindowHelper.IsAllCarsIdentical(IdenticalCarsComboBox);
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			
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
			LocalizationService.Translate(_localizationComponents);
			DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, Controls.Owner);
			
			
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
			LocalizationService.Translate(_localizationComponents);
			DrivingModeComponent.Initialize(DrivingModeStripDropDownButton, Controls.Owner);
			
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
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.SaveChart(chart);
		}

		private void HideLegendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, null);
		}

		private void ShowFullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, LegendStyle.Table);
		}

		private void ShowPartiallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart, LegendStyle.Column);
		}

		private void IdenticalCarsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = (ComboboxItem)IdenticalCarsComboBox.SelectedItem;
			switch (item.Value)
			{
				case IdenticalCars.Yes:
					MainWindowHelper.HideMultipleField(Controls.Owner);
					break;
				case IdenticalCars.No:
					ModelParametersBinding.EndEdit();
					ModelParametersBinding.DataSource = ModelParametersMapper.MapMultiple(ModelParametersBinding.DataSource);
					MainWindowHelper.ShowMultipleField(Controls.Owner);
					break;
			}
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			var modelParameters = new ModelParameters();
			_bindingSources.ForEach(x => x.Value.EndEdit());

			((EditBasicModelParameters)_bindingSources[typeof(EditBasicModelParameters)].DataSource).MapTo(modelParameters);
			((EditAdditionalModelParameters)_bindingSources[typeof(EditAdditionalModelParameters)].DataSource).MapTo(modelParameters);
			((EditInitialConditionsModelParameters)_bindingSources[typeof(EditInitialConditionsModelParameters)].DataSource).MapTo(modelParameters);
			
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
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowAxis(chart, true);
		}

		private void ShowAxisToolStripMenuItem_Click(object sender, EventArgs e)
		{ 
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowAxis(chart, false);
		}

		private void DrawColoredItems(object sender, DrawItemEventArgs e)
		{
			var comboBox = sender as ComboBox;
			MainWindowHelper.DrawColoredItems(comboBox, e);
		}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			if (_allCharts != null)
			{
				ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
			}
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
			// проинициализировать чарты в этом месте 
			//ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
		}
	}
}
