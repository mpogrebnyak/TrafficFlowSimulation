using ChartRendering.Constants;
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.CarsMovementSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CarsMovementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SpeedAndDistanceSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DistanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpeedFromDistanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ParametersPanel = new System.Windows.Forms.Panel();
            this.TrafficCapacityGroupBox = new System.Windows.Forms.GroupBox();
            this.TrafficCapacityTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.EstimateTrafficCapacityCheckBox = new System.Windows.Forms.CheckBox();
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
            this.autoScrollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ControlMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarsMovementSplitContainer)).BeginInit();
            this.CarsMovementSplitContainer.Panel1.SuspendLayout();
            this.CarsMovementSplitContainer.Panel2.SuspendLayout();
            this.CarsMovementSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarsMovementChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartsSplitContainer)).BeginInit();
            this.ChartsSplitContainer.Panel1.SuspendLayout();
            this.ChartsSplitContainer.Panel2.SuspendLayout();
            this.ChartsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedAndDistanceSplitContainer)).BeginInit();
            this.SpeedAndDistanceSplitContainer.Panel1.SuspendLayout();
            this.SpeedAndDistanceSplitContainer.Panel2.SuspendLayout();
            this.SpeedAndDistanceSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistanceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedFromDistanceChart)).BeginInit();
            this.ParametersPanel.SuspendLayout();
            this.TrafficCapacityGroupBox.SuspendLayout();
            this.TrafficCapacityTableLayoutPanel.SuspendLayout();
            this.MovementParametersGroupBox.SuspendLayout();
            this.ControlsGroupBox.SuspendLayout();
            this.ControlsTableLayoutPanel.SuspendLayout();
            this.InitialConditionsGroupBox.SuspendLayout();
            this.AdditionalParametersGroupBox.SuspendLayout();
            this.BasicParametersGroupBox.SuspendLayout();
            this.ModeSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).BeginInit();
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
            this.ControlMenuStrip.Size = new System.Drawing.Size(1539, 30);
            this.ControlMenuStrip.TabIndex = 0;
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripButton.Image")));
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Size = new System.Drawing.Size(69, 27);
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
            this.LanguagesSwitcherButton.Size = new System.Drawing.Size(86, 27);
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
            this.StopToolStripButton.Size = new System.Drawing.Size(68, 27);
            this.StopToolStripButton.Text = "Stop";
            this.StopToolStripButton.ToolTipText = "Stop";
            this.StopToolStripButton.Click += new System.EventHandler(this.StopToolStripButton_Click);
            // 
            // ContinueToolStripButton
            // 
            this.ContinueToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ContinueToolStripButton.Image")));
            this.ContinueToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ContinueToolStripButton.Name = "ContinueToolStripButton";
            this.ContinueToolStripButton.Size = new System.Drawing.Size(133, 27);
            this.ContinueToolStripButton.Text = "Продолжить";
            this.ContinueToolStripButton.Click += new System.EventHandler(this.ContinueToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // DrivingModeStripLabel
            // 
            this.DrivingModeStripLabel.Name = "DrivingModeStripLabel";
            this.DrivingModeStripLabel.Size = new System.Drawing.Size(152, 27);
            this.DrivingModeStripLabel.Text = "Режим движения:";
            // 
            // DrivingModeStripDropDownButton
            // 
            this.DrivingModeStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DrivingModeStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("DrivingModeStripDropDownButton.Image")));
            this.DrivingModeStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrivingModeStripDropDownButton.Name = "DrivingModeStripDropDownButton";
            this.DrivingModeStripDropDownButton.Size = new System.Drawing.Size(90, 27);
            this.DrivingModeStripDropDownButton.Text = "Режимы";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // ParametersSelectionToolStripButton
            // 
            this.ParametersSelectionToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ParametersSelectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ParametersSelectionToolStripButton.Image")));
            this.ParametersSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParametersSelectionToolStripButton.Name = "ParametersSelectionToolStripButton";
            this.ParametersSelectionToolStripButton.Size = new System.Drawing.Size(193, 27);
            this.ParametersSelectionToolStripButton.Text = "Оценка параметров";
            this.ParametersSelectionToolStripButton.Click += new System.EventHandler(this.ParametersSelectionToolStripButton_Click);
            // 
            // CarsMovementSplitContainer
            // 
            this.CarsMovementSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarsMovementSplitContainer.Location = new System.Drawing.Point(0, 30);
            this.CarsMovementSplitContainer.Name = "CarsMovementSplitContainer";
            this.CarsMovementSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CarsMovementSplitContainer.Panel1
            // 
            this.CarsMovementSplitContainer.Panel1.Controls.Add(this.CarsMovementChart);
            // 
            // CarsMovementSplitContainer.Panel2
            // 
            this.CarsMovementSplitContainer.Panel2.Controls.Add(this.ChartsSplitContainer);
            this.CarsMovementSplitContainer.Size = new System.Drawing.Size(1539, 654);
            this.CarsMovementSplitContainer.SplitterDistance = 371;
            this.CarsMovementSplitContainer.TabIndex = 1;
            // 
            // CarsMovementChart
            // 
            chartArea1.Name = "ChartArea1";
            this.CarsMovementChart.ChartAreas.Add(chartArea1);
            this.CarsMovementChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.CarsMovementChart.Legends.Add(legend1);
            this.CarsMovementChart.Location = new System.Drawing.Point(0, 0);
            this.CarsMovementChart.Name = "CarsMovementChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.CarsMovementChart.Series.Add(series1);
            this.CarsMovementChart.Size = new System.Drawing.Size(1539, 371);
            this.CarsMovementChart.TabIndex = 0;
            // 
            // ChartsSplitContainer
            // 
            this.ChartsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ChartsSplitContainer.Name = "ChartsSplitContainer";
            // 
            // ChartsSplitContainer.Panel1
            // 
            this.ChartsSplitContainer.Panel1.Controls.Add(this.SpeedAndDistanceSplitContainer);
            // 
            // ChartsSplitContainer.Panel2
            // 
            this.ChartsSplitContainer.Panel2.Controls.Add(this.SpeedFromDistanceChart);
            this.ChartsSplitContainer.Size = new System.Drawing.Size(1539, 279);
            this.ChartsSplitContainer.SplitterDistance = 718;
            this.ChartsSplitContainer.TabIndex = 0;
            // 
            // SpeedAndDistanceSplitContainer
            // 
            this.SpeedAndDistanceSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedAndDistanceSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SpeedAndDistanceSplitContainer.Name = "SpeedAndDistanceSplitContainer";
            // 
            // SpeedAndDistanceSplitContainer.Panel1
            // 
            this.SpeedAndDistanceSplitContainer.Panel1.Controls.Add(this.SpeedChart);
            // 
            // SpeedAndDistanceSplitContainer.Panel2
            // 
            this.SpeedAndDistanceSplitContainer.Panel2.Controls.Add(this.DistanceChart);
            this.SpeedAndDistanceSplitContainer.Size = new System.Drawing.Size(718, 279);
            this.SpeedAndDistanceSplitContainer.SplitterDistance = 349;
            this.SpeedAndDistanceSplitContainer.TabIndex = 0;
            // 
            // SpeedChart
            // 
            chartArea2.Name = "ChartArea1";
            this.SpeedChart.ChartAreas.Add(chartArea2);
            this.SpeedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.SpeedChart.Legends.Add(legend2);
            this.SpeedChart.Location = new System.Drawing.Point(0, 0);
            this.SpeedChart.Name = "SpeedChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.SpeedChart.Series.Add(series2);
            this.SpeedChart.Size = new System.Drawing.Size(349, 279);
            this.SpeedChart.TabIndex = 0;
            // 
            // DistanceChart
            // 
            chartArea3.Name = "ChartArea1";
            this.DistanceChart.ChartAreas.Add(chartArea3);
            this.DistanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.DistanceChart.Legends.Add(legend3);
            this.DistanceChart.Location = new System.Drawing.Point(0, 0);
            this.DistanceChart.Name = "DistanceChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.DistanceChart.Series.Add(series3);
            this.DistanceChart.Size = new System.Drawing.Size(365, 279);
            this.DistanceChart.TabIndex = 0;
            // 
            // SpeedFromDistanceChart
            // 
            chartArea4.Name = "ChartArea1";
            this.SpeedFromDistanceChart.ChartAreas.Add(chartArea4);
            this.SpeedFromDistanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.SpeedFromDistanceChart.Legends.Add(legend4);
            this.SpeedFromDistanceChart.Location = new System.Drawing.Point(0, 0);
            this.SpeedFromDistanceChart.Name = "SpeedFromDistanceChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.SpeedFromDistanceChart.Series.Add(series4);
            this.SpeedFromDistanceChart.Size = new System.Drawing.Size(817, 279);
            this.SpeedFromDistanceChart.TabIndex = 1;
            // 
            // ParametersPanel
            // 
            this.ParametersPanel.AutoScroll = true;
            this.ParametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.ParametersPanel.Controls.Add(this.TrafficCapacityGroupBox);
            this.ParametersPanel.Controls.Add(this.MovementParametersGroupBox);
            this.ParametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ParametersPanel.Location = new System.Drawing.Point(1143, 30);
            this.ParametersPanel.Name = "ParametersPanel";
            this.ParametersPanel.Size = new System.Drawing.Size(396, 654);
            this.ParametersPanel.TabIndex = 2;
            // 
            // TrafficCapacityGroupBox
            // 
            this.TrafficCapacityGroupBox.AutoSize = true;
            this.TrafficCapacityGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrafficCapacityGroupBox.Controls.Add(this.TrafficCapacityTableLayoutPanel);
            this.TrafficCapacityGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.TrafficCapacityGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrafficCapacityGroupBox.Location = new System.Drawing.Point(0, 310);
            this.TrafficCapacityGroupBox.Name = "TrafficCapacityGroupBox";
            this.TrafficCapacityGroupBox.Size = new System.Drawing.Size(396, 68);
            this.TrafficCapacityGroupBox.TabIndex = 25;
            this.TrafficCapacityGroupBox.TabStop = false;
            this.TrafficCapacityGroupBox.Text = "Пропускная способность";
            // 
            // TrafficCapacityTableLayoutPanel
            // 
            this.TrafficCapacityTableLayoutPanel.AutoSize = true;
            this.TrafficCapacityTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrafficCapacityTableLayoutPanel.ColumnCount = 1;
            this.TrafficCapacityTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TrafficCapacityTableLayoutPanel.Controls.Add(this.EstimateTrafficCapacityCheckBox, 0, 0);
            this.TrafficCapacityTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrafficCapacityTableLayoutPanel.Location = new System.Drawing.Point(3, 30);
            this.TrafficCapacityTableLayoutPanel.Name = "TrafficCapacityTableLayoutPanel";
            this.TrafficCapacityTableLayoutPanel.RowCount = 1;
            this.TrafficCapacityTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrafficCapacityTableLayoutPanel.Size = new System.Drawing.Size(390, 35);
            this.TrafficCapacityTableLayoutPanel.TabIndex = 0;
            // 
            // EstimateTrafficCapacityCheckBox
            // 
            this.EstimateTrafficCapacityCheckBox.AutoSize = true;
            this.EstimateTrafficCapacityCheckBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EstimateTrafficCapacityCheckBox.Location = new System.Drawing.Point(3, 3);
            this.EstimateTrafficCapacityCheckBox.Name = "EstimateTrafficCapacityCheckBox";
            this.EstimateTrafficCapacityCheckBox.Size = new System.Drawing.Size(352, 29);
            this.EstimateTrafficCapacityCheckBox.TabIndex = 0;
            this.EstimateTrafficCapacityCheckBox.Text = "Оценить пропускную способность";
            this.EstimateTrafficCapacityCheckBox.UseVisualStyleBackColor = true;
            this.EstimateTrafficCapacityCheckBox.CheckedChanged += new System.EventHandler(this.EstimateTrafficCapacityCheckBox_CheckedChanged);
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
            this.SlamPanel.Location = new System.Drawing.Point(1135, 30);
            this.SlamPanel.Name = "SlamPanel";
            this.SlamPanel.Size = new System.Drawing.Size(8, 654);
            this.SlamPanel.TabIndex = 3;
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
            // autoScrollBindingSource
            // 
            this.autoScrollBindingSource.DataSource = typeof(AutoScroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1539, 684);
            this.Controls.Add(this.SlamPanel);
            this.Controls.Add(this.ParametersPanel);
            this.Controls.Add(this.CarsMovementSplitContainer);
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
            this.CarsMovementSplitContainer.Panel1.ResumeLayout(false);
            this.CarsMovementSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CarsMovementSplitContainer)).EndInit();
            this.CarsMovementSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CarsMovementChart)).EndInit();
            this.ChartsSplitContainer.Panel1.ResumeLayout(false);
            this.ChartsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartsSplitContainer)).EndInit();
            this.ChartsSplitContainer.ResumeLayout(false);
            this.SpeedAndDistanceSplitContainer.Panel1.ResumeLayout(false);
            this.SpeedAndDistanceSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedAndDistanceSplitContainer)).EndInit();
            this.SpeedAndDistanceSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistanceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedFromDistanceChart)).EndInit();
            this.ParametersPanel.ResumeLayout(false);
            this.ParametersPanel.PerformLayout();
            this.TrafficCapacityGroupBox.ResumeLayout(false);
            this.TrafficCapacityGroupBox.PerformLayout();
            this.TrafficCapacityTableLayoutPanel.ResumeLayout(false);
            this.TrafficCapacityTableLayoutPanel.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.autoScrollBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ControlMenuStrip;
		private System.Windows.Forms.SplitContainer CarsMovementSplitContainer;
		private System.Windows.Forms.SplitContainer ChartsSplitContainer;
		internal System.Windows.Forms.DataVisualization.Charting.Chart SpeedChart;
		internal System.Windows.Forms.DataVisualization.Charting.Chart DistanceChart;
		private System.Windows.Forms.Panel ParametersPanel;
		private System.Windows.Forms.Panel SlamPanel;
		internal System.Windows.Forms.ToolStripButton StartToolStripButton;
		internal System.Windows.Forms.ToolStripDropDownButton LanguagesSwitcherButton;
		private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
		internal System.Windows.Forms.ErrorProvider ParametersErrorProvider;
		internal System.Windows.Forms.DataVisualization.Charting.Chart CarsMovementChart;
		internal System.Windows.Forms.ToolStripButton StopToolStripButton;
		internal System.Windows.Forms.ToolStripButton ContinueToolStripButton;
		internal System.Windows.Forms.GroupBox MovementParametersGroupBox;
		internal System.Windows.Forms.GroupBox ModeSettingsGroupBox;
		internal System.Windows.Forms.GroupBox BasicParametersGroupBox;
		private System.Windows.Forms.TableLayoutPanel BasicParametersTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel SettingsTableLayoutPanel;
		private System.Windows.Forms.ToolTip toolTip1;
		internal System.Windows.Forms.GroupBox AdditionalParametersGroupBox;
		private System.Windows.Forms.TableLayoutPanel AdditionalParametersTableLayoutPanel;
		internal System.Windows.Forms.GroupBox InitialConditionsGroupBox;
		private System.Windows.Forms.TableLayoutPanel InitialConditionsTableLayoutPanel;
		private System.Windows.Forms.BindingSource autoScrollBindingSource;
		internal System.Windows.Forms.GroupBox ControlsGroupBox;
		private System.Windows.Forms.TableLayoutPanel ControlsTableLayoutPanel;
		private System.Windows.Forms.Button LoadButton;
		internal System.Windows.Forms.Button SubmitButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.ToolStripLabel DrivingModeStripLabel;
		internal System.Windows.Forms.ToolStripDropDownButton DrivingModeStripDropDownButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		internal System.Windows.Forms.ToolStripButton ParametersSelectionToolStripButton;
		internal System.Windows.Forms.DataVisualization.Charting.Chart SpeedFromDistanceChart;
        private System.Windows.Forms.SplitContainer SpeedAndDistanceSplitContainer;
        private System.Windows.Forms.GroupBox TrafficCapacityGroupBox;
        private System.Windows.Forms.TableLayoutPanel TrafficCapacityTableLayoutPanel;
        internal System.Windows.Forms.CheckBox EstimateTrafficCapacityCheckBox;
    }
}