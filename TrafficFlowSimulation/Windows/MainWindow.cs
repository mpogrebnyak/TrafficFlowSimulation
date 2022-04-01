using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Rendering;
using TrafficFlowSimulation.Windows.Controllers;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		private LocalizationComponentsModel _localizationComponents;
		private AllChartsModel _allCharts;

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
				AutoScrollComboBox = AutoScrollComboBox,
				IdenticalCarsComboBox = IdenticalCarsComboBox
			};
			
			
			RenderConfiguration.RegistrateCharts(_allCharts);
		}

		private void InitializeInterface()
		{
			LocalizationService.Translate(_localizationComponents);
			
			var defaultModelParameters = ModelParametersMapper.GetDefaultParameters();
			ModelParametersBinding.DataSource = defaultModelParameters;

			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			RenderingHelper.CreateCharts(_allCharts, modelParameters);

			DrivingModeControllers.Initialize(DrivingModeStripDropDownButton);
		
			// перенести в main
			CarsRenderingHelper.CreatePaintedCars();
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			parametersPanel.Hide();
			ModelParametersBinding.EndEdit();
			//var isAllCarsIdentical = MainWindowHelper.IsAllCarsIdentical(IdenticalCarsComboBox);
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			var modeSettings = new ModeSettings();
			modeSettings.MapTo(AutoScrollComboBox.SelectedIndex, ScrollForNumericUpDown.Value);

			RenderingHelper.CreateCharts(_allCharts, modelParameters);

			EvaluationHandler.AbortExecution();
			EvaluationHandler.Execute(
				_allCharts,
				modelParameters,
				modeSettings
				);
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			EvaluationHandler.AbortExecution();
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
			DrivingModeControllers.Initialize(DrivingModeStripDropDownButton);
		}

		private void RussianMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
			languagesSwitcherButton.Image = Properties.Resources.russia;
			LocalizationService.Translate(_localizationComponents);
			DrivingModeControllers.Initialize(DrivingModeStripDropDownButton);
		}

		private void StopToolStripButton_Click(object sender, EventArgs e)
		{
			EvaluationHandler.StopThread();
		}

		private void ContinueToolStripButton_Click(object sender, EventArgs e)
		{
			EvaluationHandler.StartThread();
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

		private void BasicParametersTableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			var isAllCarsIdentical = (IdenticalCars)(IdenticalCarsComboBox.SelectedItem as ComboboxItem).Value;
			if (isAllCarsIdentical == IdenticalCars.No)
				MainWindowHelper.PaintCellPaint(sender, e);
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			ModelParametersBinding.EndEdit();
			var isAllCarsIdentical = (IdenticalCars)(IdenticalCarsComboBox.SelectedItem as ComboboxItem).Value;
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, isAllCarsIdentical);

			RenderingHelper.CreateCharts(_allCharts, modelParameters);
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
    }
}
