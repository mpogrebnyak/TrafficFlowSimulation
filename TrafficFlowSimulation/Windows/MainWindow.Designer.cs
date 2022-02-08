
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
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.StartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.languagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.carsMovementContainer = new System.Windows.Forms.SplitContainer();
            this.carsMovementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CarsMovementContainerСontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HideLegendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображатьПолностьюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображатьЧастичноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsContainer = new System.Windows.Forms.SplitContainer();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.MovementParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.v_max_field = new System.Windows.Forms.TextBox();
            this.ModelParametersBinding = new System.Windows.Forms.BindingSource(this.components);
            this.a_field = new System.Windows.Forms.TextBox();
            this.q_field = new System.Windows.Forms.TextBox();
            this.MaximumSpeedLabel = new System.Windows.Forms.Label();
            this.AccelerationIntensityLabel = new System.Windows.Forms.Label();
            this.DecelerationIntensityLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.RegimeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.n_field = new System.Windows.Forms.TextBox();
            this.VehiclesNumberLabel = new System.Windows.Forms.Label();
            this.IdenticalCarsLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.slam_Panel = new System.Windows.Forms.Panel();
            this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.LocalizationBinding = new System.Windows.Forms.BindingSource(this.components);
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).BeginInit();
            this.carsMovementContainer.Panel1.SuspendLayout();
            this.carsMovementContainer.Panel2.SuspendLayout();
            this.carsMovementContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).BeginInit();
            this.CarsMovementContainerСontextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).BeginInit();
            this.chartsContainer.Panel1.SuspendLayout();
            this.chartsContainer.Panel2.SuspendLayout();
            this.chartsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
            this.parametersPanel.SuspendLayout();
            this.MovementParametersGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelParametersBinding)).BeginInit();
            this.RegimeSettingsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizationBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripButton,
            this.languagesSwitcherButton,
            this.StopToolStripButton,
            this.toolStripButton1});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1539, 30);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "toolStrip1";
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripButton.Image")));
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Size = new System.Drawing.Size(49, 27);
            this.StartToolStripButton.Text = "Start";
            this.StartToolStripButton.Click += new System.EventHandler(this.startToolStripButton_Click);
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
            this.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopToolStripButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripButton.Image")));
            this.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopToolStripButton.Name = "StopToolStripButton";
            this.StopToolStripButton.Size = new System.Drawing.Size(48, 27);
            this.StopToolStripButton.Text = "Stop";
            this.StopToolStripButton.ToolTipText = "Stop";
            this.StopToolStripButton.Click += new System.EventHandler(this.StopToolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 27);
            this.toolStripButton1.Text = "Продолжить";
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
            this.carsMovementContainer.SplitterDistance = 392;
            this.carsMovementContainer.TabIndex = 1;
            // 
            // carsMovementChart
            // 
            chartArea1.Name = "ChartArea1";
            this.carsMovementChart.ChartAreas.Add(chartArea1);
            this.carsMovementChart.ContextMenuStrip = this.CarsMovementContainerСontextMenuStrip;
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
            this.carsMovementChart.Size = new System.Drawing.Size(1539, 392);
            this.carsMovementChart.TabIndex = 0;
            this.carsMovementChart.Text = "chart1";
            // 
            // CarsMovementContainerСontextMenuStrip
            // 
            this.CarsMovementContainerСontextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.CarsMovementContainerСontextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CarsMovementContainerСontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideLegendToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveToolStripMenuItem});
            this.CarsMovementContainerСontextMenuStrip.Name = "contextMenuStrip1";
            this.CarsMovementContainerСontextMenuStrip.Size = new System.Drawing.Size(153, 58);
            // 
            // HideLegendToolStripMenuItem
            // 
            this.HideLegendToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отображатьПолностьюToolStripMenuItem,
            this.отображатьЧастичноToolStripMenuItem,
            this.скрытьToolStripMenuItem});
            this.HideLegendToolStripMenuItem.Name = "HideLegendToolStripMenuItem";
            this.HideLegendToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.HideLegendToolStripMenuItem.Text = "Легенда";
            this.HideLegendToolStripMenuItem.Click += new System.EventHandler(this.HideLegendToolStripMenuItem_Click);
            // 
            // отображатьПолностьюToolStripMenuItem
            // 
            this.отображатьПолностьюToolStripMenuItem.Name = "отображатьПолностьюToolStripMenuItem";
            this.отображатьПолностьюToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.отображатьПолностьюToolStripMenuItem.Text = "Отображать полностью";
            // 
            // отображатьЧастичноToolStripMenuItem
            // 
            this.отображатьЧастичноToolStripMenuItem.Name = "отображатьЧастичноToolStripMenuItem";
            this.отображатьЧастичноToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.отображатьЧастичноToolStripMenuItem.Text = "Отображать частично";
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.скрытьToolStripMenuItem.Text = "Скрыть";
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
            this.chartsContainer.Size = new System.Drawing.Size(1539, 258);
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
            this.speedChart.Size = new System.Drawing.Size(718, 258);
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
            this.distanceChart.Size = new System.Drawing.Size(817, 258);
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
            this.MovementParametersGroupBox.Controls.Add(this.groupBox5);
            this.MovementParametersGroupBox.Controls.Add(this.groupBox4);
            this.MovementParametersGroupBox.Controls.Add(this.groupBox3);
            this.MovementParametersGroupBox.Controls.Add(this.RegimeSettingsGroupBox);
            this.MovementParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MovementParametersGroupBox.Location = new System.Drawing.Point(-8, 0);
            this.MovementParametersGroupBox.Name = "MovementParametersGroupBox";
            this.MovementParametersGroupBox.Size = new System.Drawing.Size(380, 690);
            this.MovementParametersGroupBox.TabIndex = 20;
            this.MovementParametersGroupBox.TabStop = false;
            this.MovementParametersGroupBox.Text = "Параметры движения:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 265);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Основные параметры:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.v_max_field, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.a_field, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.q_field, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.MaximumSpeedLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AccelerationIntensityLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.DecelerationIntensityLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 234);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(279, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(86, 27);
            this.textBox4.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(224, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Время реакции водителя";
            // 
            // v_max_field
            // 
            this.v_max_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "Vmax", true));
            this.v_max_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.v_max_field.Location = new System.Drawing.Point(279, 36);
            this.v_max_field.Name = "v_max_field";
            this.v_max_field.Size = new System.Drawing.Size(86, 27);
            this.v_max_field.TabIndex = 1;
            // 
            // ModelParametersBinding
            // 
            this.ModelParametersBinding.DataSource = typeof(EvaluationKernel.Models.ModelParameters);
            // 
            // a_field
            // 
            this.a_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "a", true));
            this.a_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_field.Location = new System.Drawing.Point(279, 69);
            this.a_field.Name = "a_field";
            this.a_field.Size = new System.Drawing.Size(86, 27);
            this.a_field.TabIndex = 0;
            // 
            // q_field
            // 
            this.q_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "q", true));
            this.q_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q_field.Location = new System.Drawing.Point(279, 102);
            this.q_field.Name = "q_field";
            this.q_field.Size = new System.Drawing.Size(86, 27);
            this.q_field.TabIndex = 8;
            // 
            // MaximumSpeedLabel
            // 
            this.MaximumSpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MaximumSpeedLabel.AutoSize = true;
            this.MaximumSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSpeedLabel.Location = new System.Drawing.Point(3, 39);
            this.MaximumSpeedLabel.Name = "MaximumSpeedLabel";
            this.MaximumSpeedLabel.Size = new System.Drawing.Size(215, 20);
            this.MaximumSpeedLabel.TabIndex = 16;
            this.MaximumSpeedLabel.Text = "Максимальная скорость";
            // 
            // AccelerationIntensityLabel
            // 
            this.AccelerationIntensityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AccelerationIntensityLabel.AutoSize = true;
            this.AccelerationIntensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccelerationIntensityLabel.Location = new System.Drawing.Point(3, 72);
            this.AccelerationIntensityLabel.Name = "AccelerationIntensityLabel";
            this.AccelerationIntensityLabel.Size = new System.Drawing.Size(210, 20);
            this.AccelerationIntensityLabel.TabIndex = 17;
            this.AccelerationIntensityLabel.Text = "Интенсивность разгона";
            // 
            // DecelerationIntensityLabel
            // 
            this.DecelerationIntensityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DecelerationIntensityLabel.AutoSize = true;
            this.DecelerationIntensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecelerationIntensityLabel.Location = new System.Drawing.Point(3, 105);
            this.DecelerationIntensityLabel.Name = "DecelerationIntensityLabel";
            this.DecelerationIntensityLabel.Size = new System.Drawing.Size(247, 20);
            this.DecelerationIntensityLabel.TabIndex = 18;
            this.DecelerationIntensityLabel.Text = "Интенсивность торможения";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Безопасное расстояние";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(279, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 27);
            this.textBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Плавность торможения";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(279, 168);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 27);
            this.textBox2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Расстояние влияния";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(279, 201);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 27);
            this.textBox3.TabIndex = 24;
            // 
            // RegimeSettingsGroupBox
            // 
            this.RegimeSettingsGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.RegimeSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegimeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegimeSettingsGroupBox.Location = new System.Drawing.Point(3, 34);
            this.RegimeSettingsGroupBox.Name = "RegimeSettingsGroupBox";
            this.RegimeSettingsGroupBox.Size = new System.Drawing.Size(374, 101);
            this.RegimeSettingsGroupBox.TabIndex = 20;
            this.RegimeSettingsGroupBox.TabStop = false;
            this.RegimeSettingsGroupBox.Text = "Настройки режима движения:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.n_field, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.VehiclesNumberLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.IdenticalCarsLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(368, 70);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // n_field
            // 
            this.n_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModelParametersBinding, "n", true));
            this.n_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParametersErrorProvider.SetIconAlignment(this.n_field, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.n_field.Location = new System.Drawing.Point(279, 3);
            this.n_field.Name = "n_field";
            this.n_field.Size = new System.Drawing.Size(86, 27);
            this.n_field.TabIndex = 2;
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
            this.IdenticalCarsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdenticalCarsLabel.Location = new System.Drawing.Point(3, 41);
            this.IdenticalCarsLabel.Name = "IdenticalCarsLabel";
            this.IdenticalCarsLabel.Size = new System.Drawing.Size(245, 20);
            this.IdenticalCarsLabel.TabIndex = 4;
            this.IdenticalCarsLabel.Text = "Все автомобили одинаковы";
            this.toolTip1.SetToolTip(this.IdenticalCarsLabel, "Подсказка");
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.comboBox1.Location = new System.Drawing.Point(279, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 28);
            this.comboBox1.TabIndex = 5;
            // 
            // slam_Panel
            // 
            this.slam_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(29)))));
            this.slam_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slam_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.slam_Panel.Location = new System.Drawing.Point(1135, 30);
            this.slam_Panel.Name = "slam_Panel";
            this.slam_Panel.Size = new System.Drawing.Size(8, 654);
            this.slam_Panel.TabIndex = 3;
            this.slam_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.slam_Panel_MouseClick);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 400);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(374, 106);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дополнительные параметры:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox6, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(368, 75);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ускорение свободного падения";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(279, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(86, 27);
            this.textBox5.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Коэффициент трения";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(3, 506);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(374, 100);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Начальные условия";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(368, 67);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(279, 43);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(86, 27);
            this.textBox6.TabIndex = 3;
            // 
            // LocalizationBinding
            // 
            this.LocalizationBinding.DataSource = typeof(TrafficFlowSimulation.Properties.ParametersResources);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1539, 684);
            this.Controls.Add(this.slam_Panel);
            this.Controls.Add(this.parametersPanel);
            this.Controls.Add(this.carsMovementContainer);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.toolTip1.SetToolTip(this, "Подсказка\r\n\r\n");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.carsMovementContainer.Panel1.ResumeLayout(false);
            this.carsMovementContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).EndInit();
            this.carsMovementContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).EndInit();
            this.CarsMovementContainerСontextMenuStrip.ResumeLayout(false);
            this.chartsContainer.Panel1.ResumeLayout(false);
            this.chartsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).EndInit();
            this.chartsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
            this.parametersPanel.ResumeLayout(false);
            this.MovementParametersGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelParametersBinding)).EndInit();
            this.RegimeSettingsGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LocalizationBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip MenuStrip;
		private System.Windows.Forms.SplitContainer carsMovementContainer;
		private System.Windows.Forms.SplitContainer chartsContainer;
		private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
		private System.Windows.Forms.Panel parametersPanel;
		private System.Windows.Forms.Panel slam_Panel;
		private System.Windows.Forms.TextBox n_field;
		private System.Windows.Forms.TextBox v_max_field;
		private System.Windows.Forms.TextBox a_field;
		private System.Windows.Forms.ToolStripButton StartToolStripButton;
		private System.Windows.Forms.BindingSource ModelParametersBinding;
		private System.Windows.Forms.ToolStripDropDownButton languagesSwitcherButton;
		private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
		private System.Windows.Forms.BindingSource LocalizationBinding;
		private System.Windows.Forms.TextBox q_field;
		private System.Windows.Forms.ErrorProvider ParametersErrorProvider;
		private System.Windows.Forms.DataVisualization.Charting.Chart carsMovementChart;
		private System.Windows.Forms.ContextMenuStrip CarsMovementContainerСontextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem HideLegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton StopToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображатьПолностьюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображатьЧастичноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox MovementParametersGroupBox;
        private System.Windows.Forms.GroupBox RegimeSettingsGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label VehiclesNumberLabel;
        private System.Windows.Forms.Label IdenticalCarsLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label MaximumSpeedLabel;
        private System.Windows.Forms.Label AccelerationIntensityLabel;
        private System.Windows.Forms.Label DecelerationIntensityLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
    }
}