
using TrafficFlowSimulation.Models.SettingsModels.Constants;
using TrafficFlowSimulation.Properties;

namespace TrafficFlowSimulation.Windows
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.ControlMenuStrip = new System.Windows.Forms.ToolStrip();
			this.StartToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.LanguagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ContinueToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DrivingModeStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.DrivingModeStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ParametersSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.carsMovementContainer = new System.Windows.Forms.SplitContainer();
			this.carsMovementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chartsContainer = new System.Windows.Forms.SplitContainer();
			this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.parametersPanel = new System.Windows.Forms.Panel();
			this.MovementParametersGroupBox = new System.Windows.Forms.GroupBox();
			this.ControlsGroupBox = new System.Windows.Forms.GroupBox();
			this.ControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.LoadButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.SubmitButton = new System.Windows.Forms.Button();
			this.InitialConditionsGroupBox = new System.Windows.Forms.GroupBox();
			this.InitialConditionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.AdditionalParametersGroupBox = new System.Windows.Forms.GroupBox();
			this.AdditionalParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.BasicParametersGroupBox = new System.Windows.Forms.GroupBox();
			this.BasicParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ModeSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.SettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.SlamPanel = new System.Windows.Forms.Panel();
			this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ModeSettingsBinding = new System.Windows.Forms.BindingSource(this.components);
			this.autoScrollBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ControlMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).BeginInit();
			this.carsMovementContainer.Panel1.SuspendLayout();
			this.carsMovementContainer.Panel2.SuspendLayout();
			this.carsMovementContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).BeginInit();
			this.chartsContainer.Panel1.SuspendLayout();
			this.chartsContainer.Panel2.SuspendLayout();
			this.chartsContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
			this.parametersPanel.SuspendLayout();
			this.MovementParametersGroupBox.SuspendLayout();
			this.ControlsGroupBox.SuspendLayout();
			this.ControlsTableLayoutPanel.SuspendLayout();
			this.InitialConditionsGroupBox.SuspendLayout();
			this.AdditionalParametersGroupBox.SuspendLayout();
			this.BasicParametersGroupBox.SuspendLayout();
			this.ModeSettingsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeSettingsBinding)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.autoScrollBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ControlMenuStrip
			// 
			this.ControlMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
			this.ControlMenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ControlMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ControlMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.StartToolStripButton,
			this.LanguagesSwitcherButton,
			this.StopToolStripButton,
			this.ContinueToolStripButton,
			this.toolStripSeparator2,
			this.DrivingModeStripLabel,
			this.DrivingModeStripDropDownButton,
			this.toolStripSeparator1,
			this.ParametersSelectionToolStripButton});
			this.ControlMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.ControlMenuStrip.Name = "ControlMenuStrip";
			this.ControlMenuStrip.Size = new System.Drawing.Size(1539, 31);
			this.ControlMenuStrip.TabIndex = 0;
			// 
			// StartToolStripButton
			// 
			this.StartToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripButton.Image")));
			this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StartToolStripButton.Name = "StartToolStripButton";
			this.StartToolStripButton.Size = new System.Drawing.Size(69, 28);
			this.StartToolStripButton.Text = "Start";
			this.StartToolStripButton.Click += new System.EventHandler(this.StartToolStripButton_Click);
			// 
			// LanguagesSwitcherButton
			// 
			this.LanguagesSwitcherButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.LanguagesSwitcherButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.RussianMenuItem,
			this.EnglishMenuItem});
			this.LanguagesSwitcherButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LanguagesSwitcherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LanguagesSwitcherButton.Name = "LanguagesSwitcherButton";
			this.LanguagesSwitcherButton.Size = new System.Drawing.Size(86, 28);
			this.LanguagesSwitcherButton.Text = "Русский";
			// 
			// RussianMenuItem
			// 
			this.RussianMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RussianMenuItem.Image")));
			this.RussianMenuItem.Name = "RussianMenuItem";
			this.RussianMenuItem.Size = new System.Drawing.Size(156, 28);
			this.RussianMenuItem.Text = "Русский";
			// 
			// EnglishMenuItem
			// 
			this.EnglishMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EnglishMenuItem.Image")));
			this.EnglishMenuItem.Name = "EnglishMenuItem";
			this.EnglishMenuItem.Size = new System.Drawing.Size(156, 28);
			this.EnglishMenuItem.Text = "English";
			// 
			// StopToolStripButton
			// 
			this.StopToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripButton.Image")));
			this.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StopToolStripButton.Name = "StopToolStripButton";
			this.StopToolStripButton.Size = new System.Drawing.Size(68, 28);
			this.StopToolStripButton.Text = "Stop";
			this.StopToolStripButton.ToolTipText = "Stop";
			this.StopToolStripButton.Click += new System.EventHandler(this.StopToolStripButton_Click);
			// 
			// ContinueToolStripButton
			// 
			this.ContinueToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ContinueToolStripButton.Image")));
			this.ContinueToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ContinueToolStripButton.Name = "ContinueToolStripButton";
			this.ContinueToolStripButton.Size = new System.Drawing.Size(133, 28);
			this.ContinueToolStripButton.Text = "Продолжить";
			this.ContinueToolStripButton.Click += new System.EventHandler(this.ContinueToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// DrivingModeStripLabel
			// 
			this.DrivingModeStripLabel.Name = "DrivingModeStripLabel";
			this.DrivingModeStripLabel.Size = new System.Drawing.Size(152, 28);
			this.DrivingModeStripLabel.Text = "Режим движения:";
			// 
			// DrivingModeStripDropDownButton
			// 
			this.DrivingModeStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DrivingModeStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("DrivingModeStripDropDownButton.Image")));
			this.DrivingModeStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DrivingModeStripDropDownButton.Name = "DrivingModeStripDropDownButton";
			this.DrivingModeStripDropDownButton.Size = new System.Drawing.Size(90, 28);
			this.DrivingModeStripDropDownButton.Text = "Режимы";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// ParametersSelectionToolStripButton
			// 
			this.ParametersSelectionToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ParametersSelectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ParametersSelectionToolStripButton.Image")));
			this.ParametersSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParametersSelectionToolStripButton.Name = "ParametersSelectionToolStripButton";
			this.ParametersSelectionToolStripButton.Size = new System.Drawing.Size(193, 28);
			this.ParametersSelectionToolStripButton.Text = "Оценка параметров";
			this.ParametersSelectionToolStripButton.Click += new System.EventHandler(this.ParametersSelectionToolStripButton_Click);
			// 
			// carsMovementContainer
			// 
			this.carsMovementContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.carsMovementContainer.Location = new System.Drawing.Point(0, 31);
			this.carsMovementContainer.Name = "carsMovementContainer";
			this.carsMovementContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// carsMovementContainer.Panel1
			// 
			this.carsMovementContainer.Panel1.Controls.Add(this.carsMovementChart);
			// 
			// carsMovementContainer.Panel2
			// 
			this.carsMovementContainer.Panel2.Controls.Add(this.chartsContainer);
			this.carsMovementContainer.Size = new System.Drawing.Size(1539, 653);
			this.carsMovementContainer.SplitterDistance = 373;
			this.carsMovementContainer.TabIndex = 1;
			// 
			// carsMovementChart
			// 
			chartArea1.Name = "ChartArea1";
			this.carsMovementChart.ChartAreas.Add(chartArea1);
			this.carsMovementChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.carsMovementChart.Legends.Add(legend1);
			this.carsMovementChart.Location = new System.Drawing.Point(0, 0);
			this.carsMovementChart.Name = "carsMovementChart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.carsMovementChart.Series.Add(series1);
			this.carsMovementChart.Size = new System.Drawing.Size(1539, 373);
			this.carsMovementChart.TabIndex = 0;
			this.carsMovementChart.Text = "chart1";
			// 
			// chartsContainer
			// 
			this.chartsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartsContainer.Location = new System.Drawing.Point(0, 0);
			this.chartsContainer.Name = "chartsContainer";
			// 
			// chartsContainer.Panel1
			// 
			this.chartsContainer.Panel1.Controls.Add(this.speedChart);
			// 
			// chartsContainer.Panel2
			// 
			this.chartsContainer.Panel2.Controls.Add(this.distanceChart);
			this.chartsContainer.Size = new System.Drawing.Size(1539, 276);
			this.chartsContainer.SplitterDistance = 718;
			this.chartsContainer.TabIndex = 0;
			// 
			// speedChart
			// 
			chartArea2.Name = "ChartArea1";
			this.speedChart.ChartAreas.Add(chartArea2);
			this.speedChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend1";
			this.speedChart.Legends.Add(legend2);
			this.speedChart.Location = new System.Drawing.Point(0, 0);
			this.speedChart.Name = "speedChart";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.speedChart.Series.Add(series2);
			this.speedChart.Size = new System.Drawing.Size(718, 276);
			this.speedChart.TabIndex = 0;
			this.speedChart.Text = "chart1";
			// 
			// distanceChart
			// 
			chartArea3.Name = "ChartArea1";
			this.distanceChart.ChartAreas.Add(chartArea3);
			this.distanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend3.Name = "Legend1";
			this.distanceChart.Legends.Add(legend3);
			this.distanceChart.Location = new System.Drawing.Point(0, 0);
			this.distanceChart.Name = "distanceChart";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			this.distanceChart.Series.Add(series3);
			this.distanceChart.Size = new System.Drawing.Size(817, 276);
			this.distanceChart.TabIndex = 0;
			this.distanceChart.Text = "chart2";
			// 
			// parametersPanel
			// 
			this.parametersPanel.AutoScroll = true;
			this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
			this.parametersPanel.Controls.Add(this.MovementParametersGroupBox);
			this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.parametersPanel.Location = new System.Drawing.Point(1143, 31);
			this.parametersPanel.Name = "parametersPanel";
			this.parametersPanel.Size = new System.Drawing.Size(396, 653);
			this.parametersPanel.TabIndex = 2;
			// 
			// MovementParametersGroupBox
			// 
			this.MovementParametersGroupBox.AutoSize = true;
			this.MovementParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.MovementParametersGroupBox.Controls.Add(this.ControlsGroupBox);
			this.MovementParametersGroupBox.Controls.Add(this.InitialConditionsGroupBox);
			this.MovementParametersGroupBox.Controls.Add(this.AdditionalParametersGroupBox);
			this.MovementParametersGroupBox.Controls.Add(this.BasicParametersGroupBox);
			this.MovementParametersGroupBox.Controls.Add(this.ModeSettingsGroupBox);
			this.MovementParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.MovementParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MovementParametersGroupBox.Location = new System.Drawing.Point(0, 0);
			this.MovementParametersGroupBox.Name = "MovementParametersGroupBox";
			this.MovementParametersGroupBox.Size = new System.Drawing.Size(396, 310);
			this.MovementParametersGroupBox.TabIndex = 20;
			this.MovementParametersGroupBox.TabStop = false;
			this.MovementParametersGroupBox.Text = "Параметры движения:";
			// 
			// ControlsGroupBox
			// 
			this.ControlsGroupBox.AutoSize = true;
			this.ControlsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ControlsGroupBox.Controls.Add(this.ControlsTableLayoutPanel);
			this.ControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.ControlsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ControlsGroupBox.Location = new System.Drawing.Point(3, 160);
			this.ControlsGroupBox.Name = "ControlsGroupBox";
			this.ControlsGroupBox.Size = new System.Drawing.Size(390, 147);
			this.ControlsGroupBox.TabIndex = 24;
			this.ControlsGroupBox.TabStop = false;
			this.ControlsGroupBox.Text = "Элементы управления";
			// 
			// ControlsTableLayoutPanel
			// 
			this.ControlsTableLayoutPanel.AutoSize = true;
			this.ControlsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ControlsTableLayoutPanel.ColumnCount = 1;
			this.ControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.ControlsTableLayoutPanel.Controls.Add(this.LoadButton, 0, 2);
			this.ControlsTableLayoutPanel.Controls.Add(this.SaveButton, 0, 1);
			this.ControlsTableLayoutPanel.Controls.Add(this.SubmitButton, 0, 0);
			this.ControlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ControlsTableLayoutPanel.Location = new System.Drawing.Point(3, 30);
			this.ControlsTableLayoutPanel.Name = "ControlsTableLayoutPanel";
			this.ControlsTableLayoutPanel.RowCount = 3;
			this.ControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.ControlsTableLayoutPanel.Size = new System.Drawing.Size(384, 114);
			this.ControlsTableLayoutPanel.TabIndex = 0;
			// 
			// LoadButton
			// 
			this.LoadButton.AutoSize = true;
			this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
			this.ControlsTableLayoutPanel.SetColumnSpan(this.LoadButton, 2);
			this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoadButton.Location = new System.Drawing.Point(3, 79);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(357, 32);
			this.LoadButton.TabIndex = 10;
			this.LoadButton.Text = "Загрузить";
			this.LoadButton.UseVisualStyleBackColor = false;
			// 
			// SaveButton
			// 
			this.SaveButton.AutoSize = true;
			this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
			this.ControlsTableLayoutPanel.SetColumnSpan(this.SaveButton, 2);
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveButton.Location = new System.Drawing.Point(3, 41);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(357, 32);
			this.SaveButton.TabIndex = 9;
			this.SaveButton.Text = "Сохранить";
			this.SaveButton.UseVisualStyleBackColor = false;
			// 
			// SubmitButton
			// 
			this.SubmitButton.AutoSize = true;
			this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
			this.ControlsTableLayoutPanel.SetColumnSpan(this.SubmitButton, 2);
			this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SubmitButton.Location = new System.Drawing.Point(3, 3);
			this.SubmitButton.Name = "SubmitButton";
			this.SubmitButton.Size = new System.Drawing.Size(357, 32);
			this.SubmitButton.TabIndex = 8;
			this.SubmitButton.Text = "Применить";
			this.SubmitButton.UseVisualStyleBackColor = false;
			this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// InitialConditionsGroupBox
			// 
			this.InitialConditionsGroupBox.AutoSize = true;
			this.InitialConditionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.InitialConditionsGroupBox.Controls.Add(this.InitialConditionsTableLayoutPanel);
			this.InitialConditionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.InitialConditionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.InitialConditionsGroupBox.Location = new System.Drawing.Point(3, 127);
			this.InitialConditionsGroupBox.Name = "InitialConditionsGroupBox";
			this.InitialConditionsGroupBox.Size = new System.Drawing.Size(390, 33);
			this.InitialConditionsGroupBox.TabIndex = 23;
			this.InitialConditionsGroupBox.TabStop = false;
			this.InitialConditionsGroupBox.Text = "Начальные условия:";
			// 
			// InitialConditionsTableLayoutPanel
			// 
			this.InitialConditionsTableLayoutPanel.AutoSize = true;
			this.InitialConditionsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.InitialConditionsTableLayoutPanel.ColumnCount = 2;
			this.InitialConditionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.InitialConditionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.InitialConditionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InitialConditionsTableLayoutPanel.Location = new System.Drawing.Point(3, 30);
			this.InitialConditionsTableLayoutPanel.Name = "InitialConditionsTableLayoutPanel";
			this.InitialConditionsTableLayoutPanel.RowCount = 6;
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.InitialConditionsTableLayoutPanel.Size = new System.Drawing.Size(384, 0);
			this.InitialConditionsTableLayoutPanel.TabIndex = 0;
			// 
			// AdditionalParametersGroupBox
			// 
			this.AdditionalParametersGroupBox.AutoSize = true;
			this.AdditionalParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.AdditionalParametersGroupBox.Controls.Add(this.AdditionalParametersTableLayoutPanel);
			this.AdditionalParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.AdditionalParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AdditionalParametersGroupBox.Location = new System.Drawing.Point(3, 96);
			this.AdditionalParametersGroupBox.Name = "AdditionalParametersGroupBox";
			this.AdditionalParametersGroupBox.Size = new System.Drawing.Size(390, 31);
			this.AdditionalParametersGroupBox.TabIndex = 22;
			this.AdditionalParametersGroupBox.TabStop = false;
			this.AdditionalParametersGroupBox.Text = "Дополнительные параметры:";
			// 
			// AdditionalParametersTableLayoutPanel
			// 
			this.AdditionalParametersTableLayoutPanel.AutoSize = true;
			this.AdditionalParametersTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.AdditionalParametersTableLayoutPanel.ColumnCount = 2;
			this.AdditionalParametersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.AdditionalParametersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AdditionalParametersTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdditionalParametersTableLayoutPanel.Location = new System.Drawing.Point(3, 28);
			this.AdditionalParametersTableLayoutPanel.Name = "AdditionalParametersTableLayoutPanel";
			this.AdditionalParametersTableLayoutPanel.RowCount = 2;
			this.AdditionalParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.AdditionalParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.AdditionalParametersTableLayoutPanel.Size = new System.Drawing.Size(384, 0);
			this.AdditionalParametersTableLayoutPanel.TabIndex = 0;
			// 
			// BasicParametersGroupBox
			// 
			this.BasicParametersGroupBox.AutoSize = true;
			this.BasicParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BasicParametersGroupBox.Controls.Add(this.BasicParametersTableLayoutPanel);
			this.BasicParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.BasicParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BasicParametersGroupBox.Location = new System.Drawing.Point(3, 65);
			this.BasicParametersGroupBox.Name = "BasicParametersGroupBox";
			this.BasicParametersGroupBox.Size = new System.Drawing.Size(390, 31);
			this.BasicParametersGroupBox.TabIndex = 21;
			this.BasicParametersGroupBox.TabStop = false;
			this.BasicParametersGroupBox.Text = "Основные параметры:";
			// 
			// BasicParametersTableLayoutPanel
			// 
			this.BasicParametersTableLayoutPanel.AutoSize = true;
			this.BasicParametersTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BasicParametersTableLayoutPanel.ColumnCount = 2;
			this.BasicParametersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.BasicParametersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.BasicParametersTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BasicParametersTableLayoutPanel.Location = new System.Drawing.Point(3, 28);
			this.BasicParametersTableLayoutPanel.Name = "BasicParametersTableLayoutPanel";
			this.BasicParametersTableLayoutPanel.RowCount = 16;
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.BasicParametersTableLayoutPanel.Size = new System.Drawing.Size(384, 0);
			this.BasicParametersTableLayoutPanel.TabIndex = 0;
			// 
			// ModeSettingsGroupBox
			// 
			this.ModeSettingsGroupBox.AutoSize = true;
			this.ModeSettingsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ModeSettingsGroupBox.Controls.Add(this.SettingsTableLayoutPanel);
			this.ModeSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.ModeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ModeSettingsGroupBox.Location = new System.Drawing.Point(3, 34);
			this.ModeSettingsGroupBox.Name = "ModeSettingsGroupBox";
			this.ModeSettingsGroupBox.Size = new System.Drawing.Size(390, 31);
			this.ModeSettingsGroupBox.TabIndex = 20;
			this.ModeSettingsGroupBox.TabStop = false;
			this.ModeSettingsGroupBox.Text = "Настройки режима движения:";
			// 
			// SettingsTableLayoutPanel
			// 
			this.SettingsTableLayoutPanel.AutoSize = true;
			this.SettingsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.SettingsTableLayoutPanel.ColumnCount = 2;
			this.SettingsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.SettingsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.SettingsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SettingsTableLayoutPanel.Location = new System.Drawing.Point(3, 28);
			this.SettingsTableLayoutPanel.Name = "SettingsTableLayoutPanel";
			this.SettingsTableLayoutPanel.RowCount = 13;
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.SettingsTableLayoutPanel.Size = new System.Drawing.Size(384, 0);
			this.SettingsTableLayoutPanel.TabIndex = 0;
			// 
			// SlamPanel
			// 
			this.SlamPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(29)))));
			this.SlamPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SlamPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.SlamPanel.Location = new System.Drawing.Point(1135, 31);
			this.SlamPanel.Name = "SlamPanel";
			this.SlamPanel.Size = new System.Drawing.Size(8, 653);
			this.SlamPanel.TabIndex = 3;
			this.SlamPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SlamPanel_MouseClick);
			// 
			// ParametersErrorProvider
			// 
			this.ParametersErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.ParametersErrorProvider.ContainerControl = this;
			this.ParametersErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ParametersErrorProvider.Icon")));
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// ModeSettingsBinding
			// 
			this.ModeSettingsBinding.DataSource = typeof(TrafficFlowSimulation.Models.ModeSettingsModel);
			// 
			// autoScrollBindingSource
			// 
			this.autoScrollBindingSource.DataSource = typeof(TrafficFlowSimulation.Models.SettingsModels.Constants.AutoScroll);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(1539, 684);
			this.Controls.Add(this.SlamPanel);
			this.Controls.Add(this.parametersPanel);
			this.Controls.Add(this.carsMovementContainer);
			this.Controls.Add(this.ControlMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Traffic flow simulation";
			this.toolTip1.SetToolTip(this, "Подсказка\r\n\r\n");
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Shown += new System.EventHandler(this.MainWindow_Shown);
			this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
			this.ControlMenuStrip.ResumeLayout(false);
			this.ControlMenuStrip.PerformLayout();
			this.carsMovementContainer.Panel1.ResumeLayout(false);
			this.carsMovementContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).EndInit();
			this.carsMovementContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).EndInit();
			this.chartsContainer.Panel1.ResumeLayout(false);
			this.chartsContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).EndInit();
			this.chartsContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
			this.parametersPanel.ResumeLayout(false);
			this.parametersPanel.PerformLayout();
			this.MovementParametersGroupBox.ResumeLayout(false);
			this.MovementParametersGroupBox.PerformLayout();
			this.ControlsGroupBox.ResumeLayout(false);
			this.ControlsGroupBox.PerformLayout();
			this.ControlsTableLayoutPanel.ResumeLayout(false);
			this.ControlsTableLayoutPanel.PerformLayout();
			this.InitialConditionsGroupBox.ResumeLayout(false);
			this.InitialConditionsGroupBox.PerformLayout();
			this.AdditionalParametersGroupBox.ResumeLayout(false);
			this.AdditionalParametersGroupBox.PerformLayout();
			this.BasicParametersGroupBox.ResumeLayout(false);
			this.BasicParametersGroupBox.PerformLayout();
			this.ModeSettingsGroupBox.ResumeLayout(false);
			this.ModeSettingsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeSettingsBinding)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.autoScrollBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ControlMenuStrip;
		private System.Windows.Forms.SplitContainer carsMovementContainer;
		private System.Windows.Forms.SplitContainer chartsContainer;
		private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
		private System.Windows.Forms.Panel parametersPanel;
		private System.Windows.Forms.Panel SlamPanel;
		private System.Windows.Forms.ToolStripButton StartToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton LanguagesSwitcherButton;
		private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
		private System.Windows.Forms.ErrorProvider ParametersErrorProvider;
		private System.Windows.Forms.DataVisualization.Charting.Chart carsMovementChart;
		private System.Windows.Forms.ToolStripButton StopToolStripButton;
		private System.Windows.Forms.ToolStripButton ContinueToolStripButton;
		private System.Windows.Forms.GroupBox MovementParametersGroupBox;
		private System.Windows.Forms.GroupBox ModeSettingsGroupBox;
		private System.Windows.Forms.GroupBox BasicParametersGroupBox;
		private System.Windows.Forms.TableLayoutPanel BasicParametersTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel SettingsTableLayoutPanel;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox AdditionalParametersGroupBox;
		private System.Windows.Forms.TableLayoutPanel AdditionalParametersTableLayoutPanel;
		private System.Windows.Forms.GroupBox InitialConditionsGroupBox;
		private System.Windows.Forms.TableLayoutPanel InitialConditionsTableLayoutPanel;
		private System.Windows.Forms.BindingSource autoScrollBindingSource;
		private System.Windows.Forms.GroupBox ControlsGroupBox;
		private System.Windows.Forms.TableLayoutPanel ControlsTableLayoutPanel;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Button SubmitButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel DrivingModeStripLabel;
		private System.Windows.Forms.ToolStripDropDownButton DrivingModeStripDropDownButton;
		private System.Windows.Forms.BindingSource ModeSettingsBinding;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ParametersSelectionToolStripButton;
	}
}