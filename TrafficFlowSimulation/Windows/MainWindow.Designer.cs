
using TrafficFlowSimulation.Properties;
using TrafficFlowSimulation.Properties.TranslationResources;

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
            this.languagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ContinueToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DrivingModeStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.carsMovementContainer = new System.Windows.Forms.SplitContainer();
            this.carsMovementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartContainerСontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LegendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPartiallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideLegendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label9 = new System.Windows.Forms.Label();
            this.MultipleField_Vn = new System.Windows.Forms.TextBox();
            this.SingleField_Vn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SingleField_lamda = new System.Windows.Forms.TextBox();
            this.MultipleField_lamda = new System.Windows.Forms.TextBox();
            this.AdditionalParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.AdditionalParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.SingleField_g = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SingleField_mu = new System.Windows.Forms.TextBox();
            this.BasicParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.BasicParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SingleField_n = new System.Windows.Forms.TextBox();
            this.VehiclesNumberLabel = new System.Windows.Forms.Label();
            this.IdenticalCarsLabel = new System.Windows.Forms.Label();
            this.MaximumSpeedLabel = new System.Windows.Forms.Label();
            this.SingleField_Vmax = new System.Windows.Forms.TextBox();
            this.MultipleField_Vmax = new System.Windows.Forms.TextBox();
            this.DriverResponseTimeLabel = new System.Windows.Forms.Label();
            this.SingleField_tau = new System.Windows.Forms.TextBox();
            this.MultipleField_tau = new System.Windows.Forms.TextBox();
            this.AccelerationIntensityLabel = new System.Windows.Forms.Label();
            this.SingleField_a = new System.Windows.Forms.TextBox();
            this.DecelerationIntensityLabel = new System.Windows.Forms.Label();
            this.SingleField_q = new System.Windows.Forms.TextBox();
            this.MultipleField_a = new System.Windows.Forms.TextBox();
            this.MultipleField_q = new System.Windows.Forms.TextBox();
            this.SingleField_l = new System.Windows.Forms.TextBox();
            this.MultipleField_l = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SingleField_k = new System.Windows.Forms.TextBox();
            this.MultipleField_k = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SingleField_s = new System.Windows.Forms.TextBox();
            this.MultipleField_s = new System.Windows.Forms.TextBox();
            this.ModeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SingleField_Lenght = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ScrollForNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.SlamPanel = new System.Windows.Forms.Panel();
            this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LocalizationBinding = new System.Windows.Forms.BindingSource(this.components);
            this.ModelParametersBinding = new System.Windows.Forms.BindingSource(this.components);
            this.AutoScrollComboBox = new TrafficFlowSimulation.Windows.CustomControls.CustomComboBox();
            this.autoScrollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IdenticalCarsComboBox = new TrafficFlowSimulation.Windows.CustomControls.CustomComboBox();
            this.ControlMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).BeginInit();
            this.carsMovementContainer.Panel1.SuspendLayout();
            this.carsMovementContainer.Panel2.SuspendLayout();
            this.carsMovementContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).BeginInit();
            this.ChartContainerСontextMenuStrip.SuspendLayout();
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
            this.InitialConditionsTableLayoutPanel.SuspendLayout();
            this.AdditionalParametersGroupBox.SuspendLayout();
            this.AdditionalParametersTableLayoutPanel.SuspendLayout();
            this.BasicParametersGroupBox.SuspendLayout();
            this.BasicParametersTableLayoutPanel.SuspendLayout();
            this.ModeSettingsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollForNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizationBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelParametersBinding)).BeginInit();
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
            this.languagesSwitcherButton,
            this.StopToolStripButton,
            this.ContinueToolStripButton,
            this.toolStripSeparator2,
            this.DrivingModeStripLabel,
            this.toolStripDropDownButton1});
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
            // languagesSwitcherButton
            // 
            this.languagesSwitcherButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languagesSwitcherButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RussianMenuItem,
            this.EnglishMenuItem});
            this.languagesSwitcherButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.languagesSwitcherButton.Image = ((System.Drawing.Image)(resources.GetObject("languagesSwitcherButton.Image")));
            this.languagesSwitcherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.languagesSwitcherButton.Name = "languagesSwitcherButton";
            this.languagesSwitcherButton.Size = new System.Drawing.Size(106, 27);
            this.languagesSwitcherButton.Text = "Русский";
            // 
            // RussianMenuItem
            // 
            this.RussianMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RussianMenuItem.Image")));
            this.RussianMenuItem.Name = "RussianMenuItem";
            this.RussianMenuItem.Size = new System.Drawing.Size(156, 28);
            this.RussianMenuItem.Text = "Русский";
            this.RussianMenuItem.Click += new System.EventHandler(this.RussianMenuItem_Click);
            // 
            // EnglishMenuItem
            // 
            this.EnglishMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EnglishMenuItem.Image")));
            this.EnglishMenuItem.Name = "EnglishMenuItem";
            this.EnglishMenuItem.Size = new System.Drawing.Size(156, 28);
            this.EnglishMenuItem.Text = "English";
            this.EnglishMenuItem.Click += new System.EventHandler(this.EnglishMenuItem_Click);
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(231, 27);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 28);
            this.toolStripMenuItem2.Text = "12";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(224, 28);
            this.toolStripMenuItem3.Text = "33";
            // 
            // carsMovementContainer
            // 
            this.carsMovementContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carsMovementContainer.Location = new System.Drawing.Point(0, 30);
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
            this.carsMovementContainer.Size = new System.Drawing.Size(1539, 654);
            this.carsMovementContainer.SplitterDistance = 381;
            this.carsMovementContainer.TabIndex = 1;
            // 
            // carsMovementChart
            // 
            chartArea1.Name = "ChartArea1";
            this.carsMovementChart.ChartAreas.Add(chartArea1);
            this.carsMovementChart.ContextMenuStrip = this.ChartContainerСontextMenuStrip;
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
            this.carsMovementChart.Size = new System.Drawing.Size(1539, 381);
            this.carsMovementChart.TabIndex = 0;
            this.carsMovementChart.Text = "chart1";
            // 
            // ChartContainerСontextMenuStrip
            // 
            this.ChartContainerСontextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.ChartContainerСontextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ChartContainerСontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LegendToolStripMenuItem,
            this.AxisToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveToolStripMenuItem});
            this.ChartContainerСontextMenuStrip.Name = "contextMenuStrip1";
            this.ChartContainerСontextMenuStrip.Size = new System.Drawing.Size(153, 82);
            // 
            // LegendToolStripMenuItem
            // 
            this.LegendToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFullToolStripMenuItem,
            this.ShowPartiallyToolStripMenuItem,
            this.HideLegendToolStripMenuItem});
            this.LegendToolStripMenuItem.Name = "LegendToolStripMenuItem";
            this.LegendToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.LegendToolStripMenuItem.Text = "Легенда";
            // 
            // ShowFullToolStripMenuItem
            // 
            this.ShowFullToolStripMenuItem.Name = "ShowFullToolStripMenuItem";
            this.ShowFullToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.ShowFullToolStripMenuItem.Text = "Отображать полностью";
            this.ShowFullToolStripMenuItem.Click += new System.EventHandler(this.ShowFullToolStripMenuItem_Click);
            // 
            // ShowPartiallyToolStripMenuItem
            // 
            this.ShowPartiallyToolStripMenuItem.Name = "ShowPartiallyToolStripMenuItem";
            this.ShowPartiallyToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.ShowPartiallyToolStripMenuItem.Text = "Отображать частично";
            this.ShowPartiallyToolStripMenuItem.Click += new System.EventHandler(this.ShowPartiallyToolStripMenuItem_Click);
            // 
            // HideLegendToolStripMenuItem
            // 
            this.HideLegendToolStripMenuItem.Name = "HideLegendToolStripMenuItem";
            this.HideLegendToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.HideLegendToolStripMenuItem.Text = "Скрыть";
            this.HideLegendToolStripMenuItem.Click += new System.EventHandler(this.HideLegendToolStripMenuItem_Click);
            // 
            // AxisToolStripMenuItem
            // 
            this.AxisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowAxisToolStripMenuItem,
            this.HideAxisToolStripMenuItem});
            this.AxisToolStripMenuItem.Name = "AxisToolStripMenuItem";
            this.AxisToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.AxisToolStripMenuItem.Text = "Оси";
            // 
            // ShowAxisToolStripMenuItem
            // 
            this.ShowAxisToolStripMenuItem.Name = "ShowAxisToolStripMenuItem";
            this.ShowAxisToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.ShowAxisToolStripMenuItem.Text = "Показать";
            this.ShowAxisToolStripMenuItem.Click += new System.EventHandler(this.ShowAxisToolStripMenuItem_Click);
            // 
            // HideAxisToolStripMenuItem
            // 
            this.HideAxisToolStripMenuItem.Name = "HideAxisToolStripMenuItem";
            this.HideAxisToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.HideAxisToolStripMenuItem.Text = "Скрыть";
            this.HideAxisToolStripMenuItem.Click += new System.EventHandler(this.HideAxisToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
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
            this.chartsContainer.Size = new System.Drawing.Size(1539, 269);
            this.chartsContainer.SplitterDistance = 718;
            this.chartsContainer.TabIndex = 0;
            // 
            // speedChart
            // 
            chartArea2.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea2);
            this.speedChart.ContextMenuStrip = this.ChartContainerСontextMenuStrip;
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
            this.speedChart.Size = new System.Drawing.Size(718, 269);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "chart1";
            // 
            // distanceChart
            // 
            chartArea3.Name = "ChartArea1";
            this.distanceChart.ChartAreas.Add(chartArea3);
            this.distanceChart.ContextMenuStrip = this.ChartContainerСontextMenuStrip;
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
            this.distanceChart.Size = new System.Drawing.Size(817, 269);
            this.distanceChart.TabIndex = 0;
            this.distanceChart.Text = "chart2";
            // 
            // parametersPanel
            // 
            this.parametersPanel.AutoScroll = true;
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.parametersPanel.Controls.Add(this.MovementParametersGroupBox);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.parametersPanel.Location = new System.Drawing.Point(1143, 30);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Size = new System.Drawing.Size(396, 654);
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
            this.MovementParametersGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "MovementParametersGroupBoxText", true));
            this.MovementParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovementParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MovementParametersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MovementParametersGroupBox.Name = "MovementParametersGroupBox";
            this.MovementParametersGroupBox.Size = new System.Drawing.Size(375, 1133);
            this.MovementParametersGroupBox.TabIndex = 20;
            this.MovementParametersGroupBox.TabStop = false;
            this.MovementParametersGroupBox.Text = "Параметры движения:";
            // 
            // ControlsGroupBox
            // 
            this.ControlsGroupBox.AutoSize = true;
            this.ControlsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ControlsGroupBox.Controls.Add(this.ControlsTableLayoutPanel);
            this.ControlsGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "ControlsGroupBoxText", true));
            this.ControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ControlsGroupBox.Location = new System.Drawing.Point(3, 983);
            this.ControlsGroupBox.Name = "ControlsGroupBox";
            this.ControlsGroupBox.Size = new System.Drawing.Size(369, 147);
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
            this.ControlsTableLayoutPanel.Size = new System.Drawing.Size(363, 114);
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
            this.InitialConditionsGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "InitialConditionsGroupBoxText", true));
            this.InitialConditionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InitialConditionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InitialConditionsGroupBox.Location = new System.Drawing.Point(3, 818);
            this.InitialConditionsGroupBox.Name = "InitialConditionsGroupBox";
            this.InitialConditionsGroupBox.Size = new System.Drawing.Size(369, 165);
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
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.label9, 0, 0);
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.MultipleField_Vn, 0, 2);
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.SingleField_Vn, 1, 0);
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.label10, 0, 3);
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.SingleField_lamda, 1, 3);
            this.InitialConditionsTableLayoutPanel.Controls.Add(this.MultipleField_lamda, 0, 5);
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
            this.InitialConditionsTableLayoutPanel.Size = new System.Drawing.Size(363, 132);
            this.InitialConditionsTableLayoutPanel.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Начальные скорости";
            // 
            // MultipleField_Vn
            // 
            this.InitialConditionsTableLayoutPanel.SetColumnSpan(this.MultipleField_Vn, 2);
            this.MultipleField_Vn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Vn_multiple", true));
            this.MultipleField_Vn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_Vn.Location = new System.Drawing.Point(3, 36);
            this.MultipleField_Vn.Name = "MultipleField_Vn";
            this.MultipleField_Vn.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_Vn.TabIndex = 1;
            // 
            // SingleField_Vn
            // 
            this.SingleField_Vn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Vn", true));
            this.SingleField_Vn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_Vn.Location = new System.Drawing.Point(275, 3);
            this.SingleField_Vn.Name = "SingleField_Vn";
            this.SingleField_Vn.Size = new System.Drawing.Size(85, 27);
            this.SingleField_Vn.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Начальные положения";
            // 
            // SingleField_lamda
            // 
            this.SingleField_lamda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "lambda", true));
            this.SingleField_lamda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_lamda.Location = new System.Drawing.Point(275, 69);
            this.SingleField_lamda.Name = "SingleField_lamda";
            this.SingleField_lamda.Size = new System.Drawing.Size(85, 27);
            this.SingleField_lamda.TabIndex = 5;
            // 
            // MultipleField_lamda
            // 
            this.InitialConditionsTableLayoutPanel.SetColumnSpan(this.MultipleField_lamda, 2);
            this.MultipleField_lamda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "lambda_multiple", true));
            this.MultipleField_lamda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_lamda.Location = new System.Drawing.Point(3, 102);
            this.MultipleField_lamda.Name = "MultipleField_lamda";
            this.MultipleField_lamda.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_lamda.TabIndex = 6;
            // 
            // AdditionalParametersGroupBox
            // 
            this.AdditionalParametersGroupBox.AutoSize = true;
            this.AdditionalParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AdditionalParametersGroupBox.Controls.Add(this.AdditionalParametersTableLayoutPanel);
            this.AdditionalParametersGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "AdditionalParametersGroupBoxText", true));
            this.AdditionalParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdditionalParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdditionalParametersGroupBox.Location = new System.Drawing.Point(3, 721);
            this.AdditionalParametersGroupBox.Name = "AdditionalParametersGroupBox";
            this.AdditionalParametersGroupBox.Size = new System.Drawing.Size(369, 97);
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
            this.AdditionalParametersTableLayoutPanel.Controls.Add(this.label4, 0, 0);
            this.AdditionalParametersTableLayoutPanel.Controls.Add(this.SingleField_g, 1, 0);
            this.AdditionalParametersTableLayoutPanel.Controls.Add(this.label5, 0, 1);
            this.AdditionalParametersTableLayoutPanel.Controls.Add(this.SingleField_mu, 1, 1);
            this.AdditionalParametersTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdditionalParametersTableLayoutPanel.Location = new System.Drawing.Point(3, 28);
            this.AdditionalParametersTableLayoutPanel.Name = "AdditionalParametersTableLayoutPanel";
            this.AdditionalParametersTableLayoutPanel.RowCount = 2;
            this.AdditionalParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AdditionalParametersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AdditionalParametersTableLayoutPanel.Size = new System.Drawing.Size(363, 66);
            this.AdditionalParametersTableLayoutPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Свободное падение";
            // 
            // SingleField_g
            // 
            this.SingleField_g.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "g", true));
            this.SingleField_g.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_g.Location = new System.Drawing.Point(275, 3);
            this.SingleField_g.Name = "SingleField_g";
            this.SingleField_g.Size = new System.Drawing.Size(85, 27);
            this.SingleField_g.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Коэффициент трения";
            // 
            // SingleField_mu
            // 
            this.SingleField_mu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "mu", true));
            this.SingleField_mu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_mu.Location = new System.Drawing.Point(275, 36);
            this.SingleField_mu.Name = "SingleField_mu";
            this.SingleField_mu.Size = new System.Drawing.Size(85, 27);
            this.SingleField_mu.TabIndex = 3;
            // 
            // BasicParametersGroupBox
            // 
            this.BasicParametersGroupBox.AutoSize = true;
            this.BasicParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BasicParametersGroupBox.Controls.Add(this.BasicParametersTableLayoutPanel);
            this.BasicParametersGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "BasicParametersGroupBoxText", true));
            this.BasicParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BasicParametersGroupBox.Location = new System.Drawing.Point(3, 165);
            this.BasicParametersGroupBox.Name = "BasicParametersGroupBox";
            this.BasicParametersGroupBox.Size = new System.Drawing.Size(369, 556);
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
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_n, 1, 0);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.VehiclesNumberLabel, 0, 0);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.IdenticalCarsLabel, 0, 1);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MaximumSpeedLabel, 0, 2);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_Vmax, 1, 2);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_Vmax, 0, 3);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.DriverResponseTimeLabel, 0, 4);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_tau, 1, 4);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_tau, 0, 5);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.AccelerationIntensityLabel, 0, 6);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_a, 1, 6);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.DecelerationIntensityLabel, 0, 8);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_q, 1, 8);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_a, 0, 7);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_q, 0, 9);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_l, 1, 10);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_l, 0, 11);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.label1, 0, 10);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.label3, 0, 12);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_k, 1, 12);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_k, 0, 13);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.label8, 0, 14);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.SingleField_s, 1, 14);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.MultipleField_s, 0, 15);
            this.BasicParametersTableLayoutPanel.Controls.Add(this.IdenticalCarsComboBox, 1, 1);
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
            this.BasicParametersTableLayoutPanel.Size = new System.Drawing.Size(363, 525);
            this.BasicParametersTableLayoutPanel.TabIndex = 0;
            this.BasicParametersTableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.BasicParametersTableLayoutPanel_CellPaint);
            // 
            // SingleField_n
            // 
            this.SingleField_n.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "n", true));
            this.SingleField_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParametersErrorProvider.SetIconAlignment(this.SingleField_n, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.SingleField_n.Location = new System.Drawing.Point(275, 3);
            this.SingleField_n.Name = "SingleField_n";
            this.SingleField_n.Size = new System.Drawing.Size(85, 27);
            this.SingleField_n.TabIndex = 2;
            // 
            // VehiclesNumberLabel
            // 
            this.VehiclesNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VehiclesNumberLabel.AutoSize = true;
            this.VehiclesNumberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "VehiclesNumberLabel", true));
            this.VehiclesNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VehiclesNumberLabel.Location = new System.Drawing.Point(3, 6);
            this.VehiclesNumberLabel.Name = "VehiclesNumberLabel";
            this.VehiclesNumberLabel.Size = new System.Drawing.Size(226, 20);
            this.VehiclesNumberLabel.TabIndex = 3;
            this.VehiclesNumberLabel.Text = "Количество автомобилей";
            // 
            // IdenticalCarsLabel
            // 
            this.IdenticalCarsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IdenticalCarsLabel.AutoSize = true;
            this.IdenticalCarsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "IdenticalCarsLabel", true));
            this.IdenticalCarsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdenticalCarsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdenticalCarsLabel.Location = new System.Drawing.Point(3, 38);
            this.IdenticalCarsLabel.Name = "IdenticalCarsLabel";
            this.IdenticalCarsLabel.Size = new System.Drawing.Size(245, 20);
            this.IdenticalCarsLabel.TabIndex = 4;
            this.IdenticalCarsLabel.Text = "Все автомобили одинаковы";
            this.toolTip1.SetToolTip(this.IdenticalCarsLabel, "Подсказка");
            // 
            // MaximumSpeedLabel
            // 
            this.MaximumSpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MaximumSpeedLabel.AutoSize = true;
            this.MaximumSpeedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "MaximumSpeedLabel", true));
            this.MaximumSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSpeedLabel.Location = new System.Drawing.Point(3, 69);
            this.MaximumSpeedLabel.Name = "MaximumSpeedLabel";
            this.MaximumSpeedLabel.Size = new System.Drawing.Size(215, 20);
            this.MaximumSpeedLabel.TabIndex = 16;
            this.MaximumSpeedLabel.Text = "Максимальная скорость";
            // 
            // SingleField_Vmax
            // 
            this.SingleField_Vmax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Vmax", true));
            this.SingleField_Vmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_Vmax.Location = new System.Drawing.Point(275, 66);
            this.SingleField_Vmax.Name = "SingleField_Vmax";
            this.SingleField_Vmax.Size = new System.Drawing.Size(85, 27);
            this.SingleField_Vmax.TabIndex = 14;
            this.SingleField_Vmax.Tag = "SingleField";
            // 
            // MultipleField_Vmax
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_Vmax, 2);
            this.MultipleField_Vmax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Vmax_multiple", true));
            this.MultipleField_Vmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_Vmax.Location = new System.Drawing.Point(3, 99);
            this.MultipleField_Vmax.Name = "MultipleField_Vmax";
            this.MultipleField_Vmax.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_Vmax.TabIndex = 24;
            this.MultipleField_Vmax.Tag = "MultipleField";
            // 
            // DriverResponseTimeLabel
            // 
            this.DriverResponseTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DriverResponseTimeLabel.AutoSize = true;
            this.DriverResponseTimeLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "DriverResponseTimeLabel", true));
            this.DriverResponseTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DriverResponseTimeLabel.Location = new System.Drawing.Point(3, 135);
            this.DriverResponseTimeLabel.Name = "DriverResponseTimeLabel";
            this.DriverResponseTimeLabel.Size = new System.Drawing.Size(224, 20);
            this.DriverResponseTimeLabel.TabIndex = 15;
            this.DriverResponseTimeLabel.Text = "Время реакции водителя";
            // 
            // SingleField_tau
            // 
            this.SingleField_tau.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "tau", true));
            this.SingleField_tau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_tau.Location = new System.Drawing.Point(275, 132);
            this.SingleField_tau.Name = "SingleField_tau";
            this.SingleField_tau.Size = new System.Drawing.Size(85, 27);
            this.SingleField_tau.TabIndex = 1;
            // 
            // MultipleField_tau
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_tau, 2);
            this.MultipleField_tau.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "tau_multiple", true));
            this.MultipleField_tau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_tau.Location = new System.Drawing.Point(3, 165);
            this.MultipleField_tau.Name = "MultipleField_tau";
            this.MultipleField_tau.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_tau.TabIndex = 26;
            this.MultipleField_tau.Tag = "MultipleField";
            // 
            // AccelerationIntensityLabel
            // 
            this.AccelerationIntensityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AccelerationIntensityLabel.AutoSize = true;
            this.AccelerationIntensityLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "AccelerationIntensityLabel", true));
            this.AccelerationIntensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccelerationIntensityLabel.Location = new System.Drawing.Point(3, 201);
            this.AccelerationIntensityLabel.Name = "AccelerationIntensityLabel";
            this.AccelerationIntensityLabel.Size = new System.Drawing.Size(210, 20);
            this.AccelerationIntensityLabel.TabIndex = 17;
            this.AccelerationIntensityLabel.Text = "Интенсивность разгона";
            // 
            // SingleField_a
            // 
            this.SingleField_a.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "a", true));
            this.SingleField_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_a.Location = new System.Drawing.Point(275, 198);
            this.SingleField_a.Name = "SingleField_a";
            this.SingleField_a.Size = new System.Drawing.Size(85, 27);
            this.SingleField_a.TabIndex = 0;
            // 
            // DecelerationIntensityLabel
            // 
            this.DecelerationIntensityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DecelerationIntensityLabel.AutoSize = true;
            this.DecelerationIntensityLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "DecelerationIntensityLabel", true));
            this.DecelerationIntensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecelerationIntensityLabel.Location = new System.Drawing.Point(3, 267);
            this.DecelerationIntensityLabel.Name = "DecelerationIntensityLabel";
            this.DecelerationIntensityLabel.Size = new System.Drawing.Size(247, 20);
            this.DecelerationIntensityLabel.TabIndex = 18;
            this.DecelerationIntensityLabel.Text = "Интенсивность торможения";
            // 
            // SingleField_q
            // 
            this.SingleField_q.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "q", true));
            this.SingleField_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_q.Location = new System.Drawing.Point(275, 264);
            this.SingleField_q.Name = "SingleField_q";
            this.SingleField_q.Size = new System.Drawing.Size(85, 27);
            this.SingleField_q.TabIndex = 8;
            // 
            // MultipleField_a
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_a, 2);
            this.MultipleField_a.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "a_multiple", true));
            this.MultipleField_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_a.Location = new System.Drawing.Point(3, 231);
            this.MultipleField_a.Name = "MultipleField_a";
            this.MultipleField_a.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_a.TabIndex = 28;
            this.MultipleField_a.Tag = "MultipleField";
            // 
            // MultipleField_q
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_q, 2);
            this.MultipleField_q.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "q_multiple", true));
            this.MultipleField_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_q.Location = new System.Drawing.Point(3, 297);
            this.MultipleField_q.Name = "MultipleField_q";
            this.MultipleField_q.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_q.TabIndex = 30;
            this.MultipleField_q.Tag = "MultipleField";
            // 
            // SingleField_l
            // 
            this.SingleField_l.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "l", true));
            this.SingleField_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_l.Location = new System.Drawing.Point(275, 330);
            this.SingleField_l.Name = "SingleField_l";
            this.SingleField_l.Size = new System.Drawing.Size(85, 27);
            this.SingleField_l.TabIndex = 32;
            // 
            // MultipleField_l
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_l, 2);
            this.MultipleField_l.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "l_multiple", true));
            this.MultipleField_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_l.Location = new System.Drawing.Point(3, 363);
            this.MultipleField_l.Name = "MultipleField_l";
            this.MultipleField_l.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_l.TabIndex = 34;
            this.MultipleField_l.Tag = "MultipleField";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Безопасное расстояние";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Коэффициент плавности";
            // 
            // SingleField_k
            // 
            this.SingleField_k.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "k", true));
            this.SingleField_k.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_k.Location = new System.Drawing.Point(275, 396);
            this.SingleField_k.Name = "SingleField_k";
            this.SingleField_k.Size = new System.Drawing.Size(85, 27);
            this.SingleField_k.TabIndex = 36;
            // 
            // MultipleField_k
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_k, 2);
            this.MultipleField_k.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "k_multiple", true));
            this.MultipleField_k.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_k.Location = new System.Drawing.Point(3, 429);
            this.MultipleField_k.Name = "MultipleField_k";
            this.MultipleField_k.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_k.TabIndex = 37;
            this.MultipleField_k.Tag = "MultipleField";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Расстояние влияния";
            // 
            // SingleField_s
            // 
            this.SingleField_s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "s", true));
            this.SingleField_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_s.Location = new System.Drawing.Point(275, 462);
            this.SingleField_s.Name = "SingleField_s";
            this.SingleField_s.Size = new System.Drawing.Size(85, 27);
            this.SingleField_s.TabIndex = 39;
            // 
            // MultipleField_s
            // 
            this.BasicParametersTableLayoutPanel.SetColumnSpan(this.MultipleField_s, 2);
            this.MultipleField_s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "s_multiple", true));
            this.MultipleField_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultipleField_s.Location = new System.Drawing.Point(3, 495);
            this.MultipleField_s.Name = "MultipleField_s";
            this.MultipleField_s.Size = new System.Drawing.Size(357, 27);
            this.MultipleField_s.TabIndex = 40;
            this.MultipleField_s.Tag = "MultipleField";
            // 
            // ModeSettingsGroupBox
            // 
            this.ModeSettingsGroupBox.AutoSize = true;
            this.ModeSettingsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModeSettingsGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.ModeSettingsGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "ModeSettingsGroupBoxText", true));
            this.ModeSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModeSettingsGroupBox.Location = new System.Drawing.Point(3, 34);
            this.ModeSettingsGroupBox.Name = "ModeSettingsGroupBox";
            this.ModeSettingsGroupBox.Size = new System.Drawing.Size(369, 131);
            this.ModeSettingsGroupBox.TabIndex = 20;
            this.ModeSettingsGroupBox.TabStop = false;
            this.ModeSettingsGroupBox.Text = "Настройки режима движения:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.SingleField_Lenght, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ScrollForNumericUpDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.AutoScrollComboBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // SingleField_Lenght
            // 
            this.SingleField_Lenght.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Lenght", true));
            this.SingleField_Lenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingleField_Lenght.Location = new System.Drawing.Point(275, 3);
            this.SingleField_Lenght.Name = "SingleField_Lenght";
            this.SingleField_Lenght.Size = new System.Drawing.Size(85, 27);
            this.SingleField_Lenght.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Расстояние до остановки";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Отслеживание автомобиля";
            // 
            // ScrollForNumericUpDown
            // 
            this.ScrollForNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScrollForNumericUpDown.Location = new System.Drawing.Point(275, 70);
            this.ScrollForNumericUpDown.Name = "ScrollForNumericUpDown";
            this.ScrollForNumericUpDown.Size = new System.Drawing.Size(85, 27);
            this.ScrollForNumericUpDown.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Номер отслеживаемого";
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
            this.SlamPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SlamPanel_MouseClick);
            // 
            // ParametersErrorProvider
            // 
            this.ParametersErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ParametersErrorProvider.ContainerControl = this;
            this.ParametersErrorProvider.DataSource = this.ModelParametersBinding;
            this.ParametersErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ParametersErrorProvider.Icon")));
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // LocalizationBinding
            // 
            this.LocalizationBinding.DataSource = typeof(TrafficFlowSimulation.Properties.TranslationResources.ParametersResources);
            // 
            // ModelParametersBinding
            // 
            this.ModelParametersBinding.DataSource = typeof(TrafficFlowSimulation.Models.ModelParametersModel);
            // 
            // AutoScrollComboBox
            // 
            this.AutoScrollComboBox.BorderColor = System.Drawing.Color.LightGray;
            this.AutoScrollComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AutoScrollComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutoScrollComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoScrollComboBox.FormattingEnabled = true;
            this.AutoScrollComboBox.Location = new System.Drawing.Point(275, 36);
            this.AutoScrollComboBox.Name = "AutoScrollComboBox";
            this.AutoScrollComboBox.Size = new System.Drawing.Size(85, 28);
            this.AutoScrollComboBox.TabIndex = 9;
            this.AutoScrollComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawColoredItems);
            // 
            // autoScrollBindingSource
            // 
            this.autoScrollBindingSource.DataSource = typeof(TrafficFlowSimulation.Сonstants.AutoScroll);
            // 
            // IdenticalCarsComboBox
            // 
            this.IdenticalCarsComboBox.BorderColor = System.Drawing.Color.Black;
            this.IdenticalCarsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.IdenticalCarsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IdenticalCarsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdenticalCarsComboBox.FormattingEnabled = true;
            this.IdenticalCarsComboBox.Location = new System.Drawing.Point(275, 36);
            this.IdenticalCarsComboBox.Name = "IdenticalCarsComboBox";
            this.IdenticalCarsComboBox.Size = new System.Drawing.Size(85, 28);
            this.IdenticalCarsComboBox.TabIndex = 41;
            this.IdenticalCarsComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawColoredItems);
            this.IdenticalCarsComboBox.SelectedIndexChanged += new System.EventHandler(this.IdenticalCarsComboBox_SelectedIndexChanged);
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
            this.ControlMenuStrip.ResumeLayout(false);
            this.ControlMenuStrip.PerformLayout();
            this.carsMovementContainer.Panel1.ResumeLayout(false);
            this.carsMovementContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).EndInit();
            this.carsMovementContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).EndInit();
            this.ChartContainerСontextMenuStrip.ResumeLayout(false);
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
            this.InitialConditionsTableLayoutPanel.ResumeLayout(false);
            this.InitialConditionsTableLayoutPanel.PerformLayout();
            this.AdditionalParametersGroupBox.ResumeLayout(false);
            this.AdditionalParametersGroupBox.PerformLayout();
            this.AdditionalParametersTableLayoutPanel.ResumeLayout(false);
            this.AdditionalParametersTableLayoutPanel.PerformLayout();
            this.BasicParametersGroupBox.ResumeLayout(false);
            this.BasicParametersGroupBox.PerformLayout();
            this.BasicParametersTableLayoutPanel.ResumeLayout(false);
            this.BasicParametersTableLayoutPanel.PerformLayout();
            this.ModeSettingsGroupBox.ResumeLayout(false);
            this.ModeSettingsGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollForNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizationBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelParametersBinding)).EndInit();
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
        private System.Windows.Forms.TextBox SingleField_n;
        private System.Windows.Forms.TextBox SingleField_tau;
        private System.Windows.Forms.TextBox SingleField_a;
        private System.Windows.Forms.ToolStripButton StartToolStripButton;
        private System.Windows.Forms.BindingSource ModelParametersBinding;
        private System.Windows.Forms.ToolStripDropDownButton languagesSwitcherButton;
        private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
        private System.Windows.Forms.BindingSource LocalizationBinding;
        private System.Windows.Forms.TextBox SingleField_q;
        private System.Windows.Forms.ErrorProvider ParametersErrorProvider;
        private System.Windows.Forms.DataVisualization.Charting.Chart carsMovementChart;
        private System.Windows.Forms.ContextMenuStrip ChartContainerСontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton StopToolStripButton;
        private System.Windows.Forms.ToolStripButton ContinueToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowFullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPartiallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideLegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox MovementParametersGroupBox;
        private System.Windows.Forms.GroupBox ModeSettingsGroupBox;
        private System.Windows.Forms.GroupBox BasicParametersGroupBox;
        private System.Windows.Forms.TableLayoutPanel BasicParametersTableLayoutPanel;
        private System.Windows.Forms.TextBox SingleField_Vmax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label VehiclesNumberLabel;
        private System.Windows.Forms.Label IdenticalCarsLabel;
        private System.Windows.Forms.Label DriverResponseTimeLabel;
        private System.Windows.Forms.Label MaximumSpeedLabel;
        private System.Windows.Forms.Label AccelerationIntensityLabel;
        private System.Windows.Forms.Label DecelerationIntensityLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox AdditionalParametersGroupBox;
        private System.Windows.Forms.TableLayoutPanel AdditionalParametersTableLayoutPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SingleField_g;
        private System.Windows.Forms.GroupBox InitialConditionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel InitialConditionsTableLayoutPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SingleField_mu;
        private System.Windows.Forms.TextBox SingleField_Lenght;
        private System.Windows.Forms.NumericUpDown ScrollForNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource autoScrollBindingSource;
        private System.Windows.Forms.TextBox MultipleField_Vmax;
        private System.Windows.Forms.TextBox MultipleField_tau;
        private System.Windows.Forms.TextBox MultipleField_a;
        private System.Windows.Forms.TextBox MultipleField_q;
        private System.Windows.Forms.TextBox SingleField_l;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MultipleField_l;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SingleField_k;
        private System.Windows.Forms.TextBox MultipleField_k;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SingleField_s;
        private System.Windows.Forms.TextBox MultipleField_s;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox MultipleField_Vn;
        private System.Windows.Forms.TextBox SingleField_Vn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SingleField_lamda;
        private System.Windows.Forms.TextBox MultipleField_lamda;
        private System.Windows.Forms.GroupBox ControlsGroupBox;
        private System.Windows.Forms.TableLayoutPanel ControlsTableLayoutPanel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ToolStripMenuItem AxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel DrivingModeStripLabel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private CustomControls.CustomComboBox AutoScrollComboBox;
        private CustomControls.CustomComboBox IdenticalCarsComboBox;
    }
}