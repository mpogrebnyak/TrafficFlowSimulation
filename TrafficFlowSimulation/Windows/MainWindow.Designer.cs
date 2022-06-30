
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
            this.LanguagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ContinueToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DrivingModeStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.DrivingModeStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.LocalizationBinding = new System.Windows.Forms.BindingSource(this.components);
            this.InitialConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.InitialConditionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AdditionalParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.AdditionalParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BasicParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.BasicParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ModeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AutoScrollComboBox = new TrafficFlowSimulation.Windows.CustomControls.CustomComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ScrollForNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SingleField_Lenght = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.singleLightRedTime = new System.Windows.Forms.TextBox();
            this.ModeSettingsBinding = new System.Windows.Forms.BindingSource(this.components);
            this.singleLightGreenTime = new System.Windows.Forms.TextBox();
            this.customComboBox1 = new TrafficFlowSimulation.Windows.CustomControls.CustomComboBox();
            this.SlamPanel = new System.Windows.Forms.Panel();
            this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.autoScrollBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ControlMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.carsMovementContainer)).BeginInit();
            this.carsMovementContainer.Panel1.SuspendLayout();
            this.carsMovementContainer.Panel2.SuspendLayout();
            this.carsMovementContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.carsMovementChart)).BeginInit();
            this.ChartContainerСontextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.chartsContainer)).BeginInit();
            this.chartsContainer.Panel1.SuspendLayout();
            this.chartsContainer.Panel2.SuspendLayout();
            this.chartsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.distanceChart)).BeginInit();
            this.parametersPanel.SuspendLayout();
            this.MovementParametersGroupBox.SuspendLayout();
            this.ControlsGroupBox.SuspendLayout();
            this.ControlsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.LocalizationBinding)).BeginInit();
            this.InitialConditionsGroupBox.SuspendLayout();
            this.AdditionalParametersGroupBox.SuspendLayout();
            this.BasicParametersGroupBox.SuspendLayout();
            this.ModeSettingsGroupBox.SuspendLayout();
            this.SettingsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ScrollForNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ModeSettingsBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ParametersErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.autoScrollBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlMenuStrip
            // 
            this.ControlMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (249)))), ((int) (((byte) (246)))), ((int) (((byte) (247)))));
            this.ControlMenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ControlMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ControlMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.StartToolStripButton, this.LanguagesSwitcherButton, this.StopToolStripButton, this.ContinueToolStripButton, this.toolStripSeparator2, this.DrivingModeStripLabel, this.DrivingModeStripDropDownButton});
            this.ControlMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ControlMenuStrip.Name = "ControlMenuStrip";
            this.ControlMenuStrip.Size = new System.Drawing.Size(1539, 30);
            this.ControlMenuStrip.TabIndex = 0;
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StartToolStripButton.Image = ((System.Drawing.Image) (resources.GetObject("StartToolStripButton.Image")));
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Size = new System.Drawing.Size(69, 27);
            this.StartToolStripButton.Text = "Start";
            this.StartToolStripButton.Click += new System.EventHandler(this.StartToolStripButton_Click);
            // 
            // LanguagesSwitcherButton
            // 
            this.LanguagesSwitcherButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LanguagesSwitcherButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.RussianMenuItem, this.EnglishMenuItem});
            this.LanguagesSwitcherButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.LanguagesSwitcherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LanguagesSwitcherButton.Name = "LanguagesSwitcherButton";
            this.LanguagesSwitcherButton.Size = new System.Drawing.Size(85, 27);
            this.LanguagesSwitcherButton.Text = "Русский";
            // 
            // RussianMenuItem
            // 
            this.RussianMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("RussianMenuItem.Image")));
            this.RussianMenuItem.Name = "RussianMenuItem";
            this.RussianMenuItem.Size = new System.Drawing.Size(156, 28);
            this.RussianMenuItem.Text = "Русский";
            this.RussianMenuItem.Click += new System.EventHandler(this.RussianMenuItem_Click);
            // 
            // EnglishMenuItem
            // 
            this.EnglishMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("EnglishMenuItem.Image")));
            this.EnglishMenuItem.Name = "EnglishMenuItem";
            this.EnglishMenuItem.Size = new System.Drawing.Size(156, 28);
            this.EnglishMenuItem.Text = "English";
            this.EnglishMenuItem.Click += new System.EventHandler(this.EnglishMenuItem_Click);
            // 
            // StopToolStripButton
            // 
            this.StopToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StopToolStripButton.Image = ((System.Drawing.Image) (resources.GetObject("StopToolStripButton.Image")));
            this.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopToolStripButton.Name = "StopToolStripButton";
            this.StopToolStripButton.Size = new System.Drawing.Size(68, 27);
            this.StopToolStripButton.Text = "Stop";
            this.StopToolStripButton.ToolTipText = "Stop";
            this.StopToolStripButton.Click += new System.EventHandler(this.StopToolStripButton_Click);
            // 
            // ContinueToolStripButton
            // 
            this.ContinueToolStripButton.Image = ((System.Drawing.Image) (resources.GetObject("ContinueToolStripButton.Image")));
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
            this.DrivingModeStripDropDownButton.Image = ((System.Drawing.Image) (resources.GetObject("DrivingModeStripDropDownButton.Image")));
            this.DrivingModeStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrivingModeStripDropDownButton.Name = "DrivingModeStripDropDownButton";
            this.DrivingModeStripDropDownButton.Size = new System.Drawing.Size(89, 27);
            this.DrivingModeStripDropDownButton.Text = "Режимы";
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
            this.carsMovementContainer.SplitterDistance = 375;
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
            this.carsMovementChart.Size = new System.Drawing.Size(1539, 375);
            this.carsMovementChart.TabIndex = 0;
            this.carsMovementChart.Text = "chart1";
            // 
            // ChartContainerСontextMenuStrip
            // 
            this.ChartContainerСontextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (249)))), ((int) (((byte) (246)))), ((int) (((byte) (247)))));
            this.ChartContainerСontextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ChartContainerСontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.LegendToolStripMenuItem, this.AxisToolStripMenuItem, this.toolStripSeparator1, this.SaveToolStripMenuItem});
            this.ChartContainerСontextMenuStrip.Name = "contextMenuStrip1";
            this.ChartContainerСontextMenuStrip.Size = new System.Drawing.Size(153, 82);
            // 
            // LegendToolStripMenuItem
            // 
            this.LegendToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ShowFullToolStripMenuItem, this.ShowPartiallyToolStripMenuItem, this.HideLegendToolStripMenuItem});
            this.LegendToolStripMenuItem.Name = "LegendToolStripMenuItem";
            this.LegendToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.LegendToolStripMenuItem.Text = "Легенда";
            // 
            // ShowFullToolStripMenuItem
            // 
            this.ShowFullToolStripMenuItem.Name = "ShowFullToolStripMenuItem";
            this.ShowFullToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.ShowFullToolStripMenuItem.Text = "Отображать полностью";
            this.ShowFullToolStripMenuItem.Click += new System.EventHandler(this.ShowFullToolStripMenuItem_Click);
            // 
            // ShowPartiallyToolStripMenuItem
            // 
            this.ShowPartiallyToolStripMenuItem.Name = "ShowPartiallyToolStripMenuItem";
            this.ShowPartiallyToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.ShowPartiallyToolStripMenuItem.Text = "Отображать частично";
            this.ShowPartiallyToolStripMenuItem.Click += new System.EventHandler(this.ShowPartiallyToolStripMenuItem_Click);
            // 
            // HideLegendToolStripMenuItem
            // 
            this.HideLegendToolStripMenuItem.Name = "HideLegendToolStripMenuItem";
            this.HideLegendToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.HideLegendToolStripMenuItem.Text = "Скрыть";
            this.HideLegendToolStripMenuItem.Click += new System.EventHandler(this.HideLegendToolStripMenuItem_Click);
            // 
            // AxisToolStripMenuItem
            // 
            this.AxisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ShowAxisToolStripMenuItem, this.HideAxisToolStripMenuItem});
            this.AxisToolStripMenuItem.Name = "AxisToolStripMenuItem";
            this.AxisToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.AxisToolStripMenuItem.Text = "Оси";
            // 
            // ShowAxisToolStripMenuItem
            // 
            this.ShowAxisToolStripMenuItem.Name = "ShowAxisToolStripMenuItem";
            this.ShowAxisToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.ShowAxisToolStripMenuItem.Text = "Показать";
            this.ShowAxisToolStripMenuItem.Click += new System.EventHandler(this.ShowAxisToolStripMenuItem_Click);
            // 
            // HideAxisToolStripMenuItem
            // 
            this.HideAxisToolStripMenuItem.Name = "HideAxisToolStripMenuItem";
            this.HideAxisToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
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
            this.chartsContainer.Size = new System.Drawing.Size(1539, 275);
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
            this.speedChart.Size = new System.Drawing.Size(718, 275);
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
            this.distanceChart.Size = new System.Drawing.Size(817, 275);
            this.distanceChart.TabIndex = 0;
            this.distanceChart.Text = "chart2";
            // 
            // parametersPanel
            // 
            this.parametersPanel.AutoScroll = true;
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (249)))), ((int) (((byte) (246)))), ((int) (((byte) (247)))));
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
            this.MovementParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.MovementParametersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MovementParametersGroupBox.Name = "MovementParametersGroupBox";
            this.MovementParametersGroupBox.Size = new System.Drawing.Size(375, 741);
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
            this.ControlsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ControlsGroupBox.Location = new System.Drawing.Point(3, 591);
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
            this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (243)))), ((int) (((byte) (241)))), ((int) (((byte) (245)))));
            this.ControlsTableLayoutPanel.SetColumnSpan(this.LoadButton, 2);
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
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
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (243)))), ((int) (((byte) (241)))), ((int) (((byte) (245)))));
            this.ControlsTableLayoutPanel.SetColumnSpan(this.SaveButton, 2);
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
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
            this.SubmitButton.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (243)))), ((int) (((byte) (241)))), ((int) (((byte) (245)))));
            this.ControlsTableLayoutPanel.SetColumnSpan(this.SubmitButton, 2);
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SubmitButton.Location = new System.Drawing.Point(3, 3);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(357, 32);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Применить";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // LocalizationBinding
            // 
            this.LocalizationBinding.DataSource = typeof(TrafficFlowSimulation.Properties.TranslationResources.ParametersResources);
            // 
            // InitialConditionsGroupBox
            // 
            this.InitialConditionsGroupBox.AutoSize = true;
            this.InitialConditionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InitialConditionsGroupBox.Controls.Add(this.InitialConditionsTableLayoutPanel);
            this.InitialConditionsGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "InitialConditionsGroupBoxText", true));
            this.InitialConditionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.InitialConditionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.InitialConditionsGroupBox.Location = new System.Drawing.Point(3, 558);
            this.InitialConditionsGroupBox.Name = "InitialConditionsGroupBox";
            this.InitialConditionsGroupBox.Size = new System.Drawing.Size(369, 33);
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
            this.InitialConditionsTableLayoutPanel.Size = new System.Drawing.Size(363, 0);
            this.InitialConditionsTableLayoutPanel.TabIndex = 0;
            // 
            // AdditionalParametersGroupBox
            // 
            this.AdditionalParametersGroupBox.AutoSize = true;
            this.AdditionalParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AdditionalParametersGroupBox.Controls.Add(this.AdditionalParametersTableLayoutPanel);
            this.AdditionalParametersGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "AdditionalParametersGroupBoxText", true));
            this.AdditionalParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdditionalParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.AdditionalParametersGroupBox.Location = new System.Drawing.Point(3, 527);
            this.AdditionalParametersGroupBox.Name = "AdditionalParametersGroupBox";
            this.AdditionalParametersGroupBox.Size = new System.Drawing.Size(369, 31);
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
            this.AdditionalParametersTableLayoutPanel.Size = new System.Drawing.Size(363, 0);
            this.AdditionalParametersTableLayoutPanel.TabIndex = 0;
            // 
            // BasicParametersGroupBox
            // 
            this.BasicParametersGroupBox.AutoSize = true;
            this.BasicParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BasicParametersGroupBox.Controls.Add(this.BasicParametersTableLayoutPanel);
            this.BasicParametersGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "BasicParametersGroupBoxText", true));
            this.BasicParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.BasicParametersGroupBox.Location = new System.Drawing.Point(3, 496);
            this.BasicParametersGroupBox.Name = "BasicParametersGroupBox";
            this.BasicParametersGroupBox.Size = new System.Drawing.Size(369, 31);
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
            this.BasicParametersTableLayoutPanel.Size = new System.Drawing.Size(363, 0);
            this.BasicParametersTableLayoutPanel.TabIndex = 0;
            // 
            // ModeSettingsGroupBox
            // 
            this.ModeSettingsGroupBox.AutoSize = true;
            this.ModeSettingsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModeSettingsGroupBox.Controls.Add(this.SettingsTableLayoutPanel);
            this.ModeSettingsGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.LocalizationBinding, "ModeSettingsGroupBoxText", true));
            this.ModeSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ModeSettingsGroupBox.Location = new System.Drawing.Point(3, 34);
            this.ModeSettingsGroupBox.Name = "ModeSettingsGroupBox";
            this.ModeSettingsGroupBox.Size = new System.Drawing.Size(369, 462);
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
            this.SettingsTableLayoutPanel.Controls.Add(this.label7, 0, 0);
            this.SettingsTableLayoutPanel.Controls.Add(this.label6, 0, 1);
            this.SettingsTableLayoutPanel.Controls.Add(this.AutoScrollComboBox, 1, 0);
            this.SettingsTableLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.SettingsTableLayoutPanel.Controls.Add(this.ScrollForNumericUpDown, 1, 1);
            this.SettingsTableLayoutPanel.Controls.Add(this.SingleField_Lenght, 1, 2);
            this.SettingsTableLayoutPanel.Controls.Add(this.label12, 0, 3);
            this.SettingsTableLayoutPanel.Controls.Add(this.label13, 0, 4);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox6, 0, 12);
            this.SettingsTableLayoutPanel.Controls.Add(this.label11, 0, 11);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox7, 1, 11);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox5, 0, 10);
            this.SettingsTableLayoutPanel.Controls.Add(this.label8, 0, 9);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox4, 1, 9);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox3, 0, 8);
            this.SettingsTableLayoutPanel.Controls.Add(this.label3, 0, 7);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox2, 1, 7);
            this.SettingsTableLayoutPanel.Controls.Add(this.textBox1, 1, 6);
            this.SettingsTableLayoutPanel.Controls.Add(this.label1, 0, 6);
            this.SettingsTableLayoutPanel.Controls.Add(this.label14, 0, 5);
            this.SettingsTableLayoutPanel.Controls.Add(this.singleLightRedTime, 1, 5);
            this.SettingsTableLayoutPanel.Controls.Add(this.singleLightGreenTime, 1, 4);
            this.SettingsTableLayoutPanel.Controls.Add(this.customComboBox1, 1, 3);
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
            this.SettingsTableLayoutPanel.Size = new System.Drawing.Size(363, 431);
            this.SettingsTableLayoutPanel.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 20);
            this.label7.TabIndex = 8;
            this.label7.Tag = "_msf";
            this.label7.Text = "Отслеживание автомобиля";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label6.Location = new System.Drawing.Point(3, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 20);
            this.label6.TabIndex = 7;
            this.label6.Tag = "_msf";
            this.label6.Text = "Номер отслеживаемого";
            // 
            // AutoScrollComboBox
            // 
            this.AutoScrollComboBox.BorderColor = System.Drawing.Color.LightGray;
            this.AutoScrollComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AutoScrollComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AutoScrollComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.AutoScrollComboBox.FormattingEnabled = true;
            this.AutoScrollComboBox.Location = new System.Drawing.Point(275, 3);
            this.AutoScrollComboBox.Name = "AutoScrollComboBox";
            this.AutoScrollComboBox.Size = new System.Drawing.Size(85, 28);
            this.AutoScrollComboBox.TabIndex = 9;
            this.AutoScrollComboBox.Tag = "_msf";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 6;
            this.label2.Tag = "_msf";
            this.label2.Text = "Расстояние до остановки";
            // 
            // ScrollForNumericUpDown
            // 
            this.ScrollForNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ScrollForNumericUpDown.Location = new System.Drawing.Point(275, 37);
            this.ScrollForNumericUpDown.Name = "ScrollForNumericUpDown";
            this.ScrollForNumericUpDown.Size = new System.Drawing.Size(85, 27);
            this.ScrollForNumericUpDown.TabIndex = 5;
            this.ScrollForNumericUpDown.Tag = "_msf";
            // 
            // SingleField_Lenght
            // 
            this.SingleField_Lenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SingleField_Lenght.Location = new System.Drawing.Point(275, 70);
            this.SingleField_Lenght.Name = "SingleField_Lenght";
            this.SingleField_Lenght.Size = new System.Drawing.Size(85, 27);
            this.SingleField_Lenght.TabIndex = 4;
            this.SingleField_Lenght.Tag = "_msf";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label12.Location = new System.Drawing.Point(3, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 20);
            this.label12.TabIndex = 21;
            this.label12.Tag = "TrafficThroughOneTrafficLight_msf";
            this.label12.Text = "Цвет первого сигнала";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label13.Location = new System.Drawing.Point(3, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 20);
            this.label13.TabIndex = 22;
            this.label13.Tag = "TrafficThroughOneTrafficLight_msf";
            this.label13.Text = "Время зеленого сигнала";
            // 
            // textBox6
            // 
            this.SettingsTableLayoutPanel.SetColumnSpan(this.textBox6, 2);
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox6.Location = new System.Drawing.Point(3, 401);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(357, 27);
            this.textBox6.TabIndex = 19;
            this.textBox6.Tag = "_msf";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label11.Location = new System.Drawing.Point(3, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 20);
            this.label11.TabIndex = 16;
            this.label11.Tag = "_msf";
            this.label11.Text = "Время красного сигнала";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox7.Location = new System.Drawing.Point(275, 368);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(85, 27);
            this.textBox7.TabIndex = 20;
            this.textBox7.Tag = "_msf";
            // 
            // textBox5
            // 
            this.SettingsTableLayoutPanel.SetColumnSpan(this.textBox5, 2);
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox5.Location = new System.Drawing.Point(3, 335);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(357, 27);
            this.textBox5.TabIndex = 18;
            this.textBox5.Tag = "_msf";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label8.Location = new System.Drawing.Point(3, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 20);
            this.label8.TabIndex = 15;
            this.label8.Tag = "_msf";
            this.label8.Text = "Время зеленого сигнала";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox4.Location = new System.Drawing.Point(275, 302);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(85, 27);
            this.textBox4.TabIndex = 17;
            this.textBox4.Tag = "_msf";
            // 
            // textBox3
            // 
            this.SettingsTableLayoutPanel.SetColumnSpan(this.textBox3, 2);
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox3.Location = new System.Drawing.Point(3, 269);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(357, 27);
            this.textBox3.TabIndex = 14;
            this.textBox3.Tag = "_msf";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.Location = new System.Drawing.Point(3, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 20);
            this.label3.TabIndex = 11;
            this.label3.Tag = "_msf";
            this.label3.Text = "Положение светофоров";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox2.Location = new System.Drawing.Point(275, 236);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Tag = "_msf";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.textBox1.Location = new System.Drawing.Point(275, 203);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 27);
            this.textBox1.TabIndex = 12;
            this.textBox1.Tag = "_msf";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(3, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 10;
            this.label1.Tag = "_msf";
            this.label1.Text = "Количество светофоров";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label14.Location = new System.Drawing.Point(3, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 20);
            this.label14.TabIndex = 23;
            this.label14.Tag = "TrafficThroughOneTrafficLight_msf";
            this.label14.Text = "Время красного сигнала";
            // 
            // singleLightRedTime
            // 
            this.singleLightRedTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModeSettingsBinding, "SingleLightRedTime", true));
            this.singleLightRedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.singleLightRedTime.Location = new System.Drawing.Point(275, 170);
            this.singleLightRedTime.Name = "singleLightRedTime";
            this.singleLightRedTime.Size = new System.Drawing.Size(85, 27);
            this.singleLightRedTime.TabIndex = 24;
            this.singleLightRedTime.Tag = "TrafficThroughOneTrafficLight_msf";
            // 
            // ModeSettingsBinding
            // 
            this.ModeSettingsBinding.DataSource = typeof(TrafficFlowSimulation.Models.ModeSettingsModel);
            // 
            // singleLightGreenTime
            // 
            this.singleLightGreenTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModeSettingsBinding, "SingleLightGreenTime", true));
            this.singleLightGreenTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.singleLightGreenTime.Location = new System.Drawing.Point(275, 137);
            this.singleLightGreenTime.Name = "singleLightGreenTime";
            this.singleLightGreenTime.Size = new System.Drawing.Size(85, 27);
            this.singleLightGreenTime.TabIndex = 25;
            this.singleLightGreenTime.Tag = "TrafficThroughOneTrafficLight_msf";
            // 
            // customComboBox1
            // 
            this.customComboBox1.BorderColor = System.Drawing.Color.LightGray;
            this.customComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.customComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.customComboBox1.FormattingEnabled = true;
            this.customComboBox1.Location = new System.Drawing.Point(275, 103);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Size = new System.Drawing.Size(85, 28);
            this.customComboBox1.TabIndex = 26;
            this.customComboBox1.Tag = "TrafficThroughOneTrafficLight_msf";
            // 
            // SlamPanel
            // 
            this.SlamPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (151)))), ((int) (((byte) (29)))));
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
            this.ParametersErrorProvider.Icon = ((System.Drawing.Icon) (resources.GetObject("ParametersErrorProvider.Icon")));
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // autoScrollBindingSource
            // 
            this.autoScrollBindingSource.DataSource = typeof(TrafficFlowSimulation.Сonstants.AutoScroll);
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
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize) (this.carsMovementContainer)).EndInit();
            this.carsMovementContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.carsMovementChart)).EndInit();
            this.ChartContainerСontextMenuStrip.ResumeLayout(false);
            this.chartsContainer.Panel1.ResumeLayout(false);
            this.chartsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.chartsContainer)).EndInit();
            this.chartsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.speedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.distanceChart)).EndInit();
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            this.MovementParametersGroupBox.ResumeLayout(false);
            this.MovementParametersGroupBox.PerformLayout();
            this.ControlsGroupBox.ResumeLayout(false);
            this.ControlsGroupBox.PerformLayout();
            this.ControlsTableLayoutPanel.ResumeLayout(false);
            this.ControlsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.LocalizationBinding)).EndInit();
            this.InitialConditionsGroupBox.ResumeLayout(false);
            this.InitialConditionsGroupBox.PerformLayout();
            this.AdditionalParametersGroupBox.ResumeLayout(false);
            this.AdditionalParametersGroupBox.PerformLayout();
            this.BasicParametersGroupBox.ResumeLayout(false);
            this.BasicParametersGroupBox.PerformLayout();
            this.ModeSettingsGroupBox.ResumeLayout(false);
            this.ModeSettingsGroupBox.PerformLayout();
            this.SettingsTableLayoutPanel.ResumeLayout(false);
            this.SettingsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ScrollForNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ModeSettingsBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ParametersErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.autoScrollBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource LocalizationBinding;
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
        private System.Windows.Forms.TableLayoutPanel SettingsTableLayoutPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox AdditionalParametersGroupBox;
        private System.Windows.Forms.TableLayoutPanel AdditionalParametersTableLayoutPanel;
        private System.Windows.Forms.GroupBox InitialConditionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel InitialConditionsTableLayoutPanel;
        private System.Windows.Forms.TextBox SingleField_Lenght;
        private System.Windows.Forms.NumericUpDown ScrollForNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource autoScrollBindingSource;
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
        private System.Windows.Forms.ToolStripDropDownButton DrivingModeStripDropDownButton;
        private CustomControls.CustomComboBox AutoScrollComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.BindingSource ModeSettingsBinding;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox singleLightRedTime;
        private System.Windows.Forms.TextBox singleLightGreenTime;
        private CustomControls.CustomComboBox customComboBox1;
    }
}