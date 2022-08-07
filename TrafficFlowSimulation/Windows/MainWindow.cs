using System;
using System.Windows.Forms;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.Services;
using TrafficFlowSimulation.Windows.Helpers;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		//private MainWindowHelper _mainWindowHelper;
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

			var allCharts = new AllChartsModel
			{
				SpeedChart = speedChart,
				DistanceChart = distanceChart,
				CarsMovementChart = carsMovementChart
			};

			var localizationComponents = new LocalizationComponentsModel
			{
				AllCharts = allCharts,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = LanguagesSwitcherButton,
				StartToolStripButton = StartToolStripButton,
				StopToolStripButton = StopToolStripButton,
				ContinueToolStripButton = ContinueToolStripButton,
				DrivingModeStripLabel = DrivingModeStripLabel,
				MovementParametersGroupBox = MovementParametersGroupBox,
				BasicParametersGroupBox = BasicParametersGroupBox,
				AdditionalParametersGroupBox = AdditionalParametersGroupBox,
				InitialConditionsGroupBox = InitialConditionsGroupBox,
				ModeSettingsGroupBox = ModeSettingsGroupBox,
				ControlsGroupBox = ControlsGroupBox,
				DrivingModeStripDropDownButton = DrivingModeStripDropDownButton
			};

			var mainWindowConfiguration = new MainWindowConfiguration(localizationComponents,
				allCharts,
				ParametersErrorProvider,
				Controls);

			mainWindowConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<MainWindowHelper>().InitializeInterface();
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			parametersPanel.Hide();
			ModeSettingsBinding.EndEdit();

			//var modelParameters = _mainWindowHelper.CollectParametersFromBindingSource();
			//var ee = (EditModelParameters)EditModelParametersBinding.DataSource;
			//var isAllCarsIdentical = MainWindowHelper.IsAllCarsIdentical(IdenticalCarsComboBox);
			//var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, IdenticalCars.Yes);
			
			// временно возьмем значения по умолчанию, потом сделаем закгрузку с интерфейса
			// var modeSettings = new ModeSettingsModel();
			//modeSettings.MapTo(ModelParametersBinding.DataSource);
			var modeSettings = ModeSettingsMapper.MapModel(ModeSettingsBinding.DataSource);
			var modelParameters = new ModelParameters();
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

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			//var modelParameters = _mainWindowHelper.CollectParametersFromBindingSource();
			
			//((EditBasicModelParameters)ee.DataSource).MapTo(modelParameters);
			//((EditBasicModelParameters) ee.DataSource).MapTo(modelParameters);

		//	var ee2 = _bindingSources.Single(x => x.Key == typeof(EditAdditionalModelParameters));
		//	((EditAdditionalModelParameters)ee2.Value.DataSource).MapTo(modelParameters);
			//editModelParameters.MapTo(modelParameters);
			//var isAllCarsIdentical = (IdenticalCars)(IdenticalCarsComboBox.SelectedItem as ComboboxItem).Value;
			//var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, isAllCarsIdentical);

			//ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
			//RenderingHelper.CreateCharts(_allCharts, modelParameters);
		}

		//private void DrawColoredItems(object sender, DrawItemEventArgs e)
		//{
		//	var comboBox = sender as ComboBox;
		//	MainWindowHelper.DrawColoredItems(comboBox, e);
		//}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			//if (_mainWindowHelper != null && _mainWindowHelper.AllCharts != null)
			///{
			//	ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
			//}
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<IDefaultParametersValuesService>()
				.GetDefaultModelParameters();
				//_mainWindowHelper.CollectParametersFromBindingSource();

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
			// проинициализировать чарты в этом месте 
			//ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
		}
	}
}
