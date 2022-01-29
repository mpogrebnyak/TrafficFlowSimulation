
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.ToolStrip();
            this.startToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.languagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carsMovementContainer = new System.Windows.Forms.SplitContainer();
            this.chartsContainer = new System.Windows.Forms.SplitContainer();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.q_field = new System.Windows.Forms.TextBox();
            this.modelParametersBinding = new System.Windows.Forms.BindingSource(this.components);
            this.decelerationIntensityLabel = new System.Windows.Forms.Label();
            this.accelerationIntensityLabel = new System.Windows.Forms.Label();
            this.maximumSpeedLabel = new System.Windows.Forms.Label();
            this.vehiclesNumberLabel = new System.Windows.Forms.Label();
            this.ParametersTitleLable = new System.Windows.Forms.Label();
            this.n_field = new System.Windows.Forms.TextBox();
            this.v_max_field = new System.Windows.Forms.TextBox();
            this.a_field = new System.Windows.Forms.TextBox();
            this.slam_Panel = new System.Windows.Forms.Panel();
            this.parametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.carsMovementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.localizationBinding = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).BeginInit();
            this.carsMovementContainer.Panel1.SuspendLayout();
            this.carsMovementContainer.Panel2.SuspendLayout();
            this.carsMovementContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).BeginInit();
            this.chartsContainer.Panel1.SuspendLayout();
            this.chartsContainer.Panel2.SuspendLayout();
            this.chartsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
            this.parametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelParametersBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripButton,
            this.languagesSwitcherButton});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1577, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "toolStrip1";
            // 
            // startToolStripButton
            // 
            this.startToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripButton.Image")));
            this.startToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripButton.Name = "startToolStripButton";
            this.startToolStripButton.Size = new System.Drawing.Size(44, 24);
            this.startToolStripButton.Text = "Start";
            this.startToolStripButton.Click += new System.EventHandler(this.startToolStripButton_Click);
            // 
            // languagesSwitcherButton
            // 
            this.languagesSwitcherButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languagesSwitcherButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RussianMenuItem,
            this.EnglishMenuItem});
            this.languagesSwitcherButton.Image = ((System.Drawing.Image)(resources.GetObject("languagesSwitcherButton.Image")));
            this.languagesSwitcherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.languagesSwitcherButton.Name = "languagesSwitcherButton";
            this.languagesSwitcherButton.Size = new System.Drawing.Size(97, 24);
            this.languagesSwitcherButton.Text = "Русский";
            // 
            // RussianMenuItem
            // 
            this.RussianMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RussianMenuItem.Image")));
            this.RussianMenuItem.Name = "RussianMenuItem";
            this.RussianMenuItem.Size = new System.Drawing.Size(146, 26);
            this.RussianMenuItem.Text = "Русский";
            this.RussianMenuItem.Click += new System.EventHandler(this.RussianMenuItem_Click);
            // 
            // EnglishMenuItem
            // 
            this.EnglishMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EnglishMenuItem.Image")));
            this.EnglishMenuItem.Name = "EnglishMenuItem";
            this.EnglishMenuItem.Size = new System.Drawing.Size(146, 26);
            this.EnglishMenuItem.Text = "English";
            this.EnglishMenuItem.Click += new System.EventHandler(this.EnglishMenuItem_Click);
            // 
            // carsMovementContainer
            // 
            this.carsMovementContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carsMovementContainer.Location = new System.Drawing.Point(0, 27);
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
            this.carsMovementContainer.Size = new System.Drawing.Size(1577, 657);
            this.carsMovementContainer.SplitterDistance = 403;
            this.carsMovementContainer.TabIndex = 1;
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
            this.chartsContainer.Size = new System.Drawing.Size(1577, 250);
            this.chartsContainer.SplitterDistance = 720;
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
            this.speedChart.Size = new System.Drawing.Size(720, 250);
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
            this.distanceChart.Size = new System.Drawing.Size(853, 250);
            this.distanceChart.TabIndex = 0;
            this.distanceChart.Text = "chart2";
            // 
            // parametersPanel
            // 
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.parametersPanel.Controls.Add(this.q_field);
            this.parametersPanel.Controls.Add(this.decelerationIntensityLabel);
            this.parametersPanel.Controls.Add(this.accelerationIntensityLabel);
            this.parametersPanel.Controls.Add(this.maximumSpeedLabel);
            this.parametersPanel.Controls.Add(this.vehiclesNumberLabel);
            this.parametersPanel.Controls.Add(this.ParametersTitleLable);
            this.parametersPanel.Controls.Add(this.n_field);
            this.parametersPanel.Controls.Add(this.v_max_field);
            this.parametersPanel.Controls.Add(this.a_field);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.parametersPanel.Location = new System.Drawing.Point(1236, 27);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Size = new System.Drawing.Size(341, 657);
            this.parametersPanel.TabIndex = 2;
            // 
            // q_field
            // 
            this.q_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelParametersBinding, "q", true));
            this.q_field.Location = new System.Drawing.Point(214, 188);
            this.q_field.Name = "q_field";
            this.q_field.Size = new System.Drawing.Size(100, 22);
            this.q_field.TabIndex = 8;
            // 
            // modelParametersBinding
            // 
            this.modelParametersBinding.DataSource = typeof(EvaluationKernel.Models.ModelParameters);
            // 
            // decelerationIntensityLabel
            // 
            this.decelerationIntensityLabel.AutoSize = true;
            this.decelerationIntensityLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localizationBinding, "DecelerationIntensityLabel", true));
            this.decelerationIntensityLabel.Location = new System.Drawing.Point(4, 195);
            this.decelerationIntensityLabel.Name = "decelerationIntensityLabel";
            this.decelerationIntensityLabel.Size = new System.Drawing.Size(191, 16);
            this.decelerationIntensityLabel.TabIndex = 7;
            this.decelerationIntensityLabel.Text = "Интенсивность торможения";
            // 
            // accelerationIntensityLabel
            // 
            this.accelerationIntensityLabel.AutoSize = true;
            this.accelerationIntensityLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localizationBinding, "AccelerationIntensityLabel", true));
            this.accelerationIntensityLabel.Location = new System.Drawing.Point(4, 162);
            this.accelerationIntensityLabel.Name = "accelerationIntensityLabel";
            this.accelerationIntensityLabel.Size = new System.Drawing.Size(165, 16);
            this.accelerationIntensityLabel.TabIndex = 6;
            this.accelerationIntensityLabel.Text = "Интенсивность разгона";
            // 
            // maximumSpeedLabel
            // 
            this.maximumSpeedLabel.AutoSize = true;
            this.maximumSpeedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localizationBinding, "MaximumSpeedLabel", true));
            this.maximumSpeedLabel.Location = new System.Drawing.Point(4, 126);
            this.maximumSpeedLabel.Name = "maximumSpeedLabel";
            this.maximumSpeedLabel.Size = new System.Drawing.Size(165, 16);
            this.maximumSpeedLabel.TabIndex = 5;
            this.maximumSpeedLabel.Text = "Максимальная скорость";
            // 
            // vehiclesNumberLabel
            // 
            this.vehiclesNumberLabel.AutoSize = true;
            this.vehiclesNumberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localizationBinding, "VehiclesNumberLabel", true));
            this.vehiclesNumberLabel.Location = new System.Drawing.Point(4, 97);
            this.vehiclesNumberLabel.Name = "vehiclesNumberLabel";
            this.vehiclesNumberLabel.Size = new System.Drawing.Size(176, 16);
            this.vehiclesNumberLabel.TabIndex = 4;
            this.vehiclesNumberLabel.Text = "Количество автомобилей";
            // 
            // ParametersTitleLable
            // 
            this.ParametersTitleLable.AutoSize = true;
            this.ParametersTitleLable.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.localizationBinding, "ParametersTitle", true));
            this.ParametersTitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParametersTitleLable.Location = new System.Drawing.Point(30, 17);
            this.ParametersTitleLable.Name = "ParametersTitleLable";
            this.ParametersTitleLable.Size = new System.Drawing.Size(226, 50);
            this.ParametersTitleLable.TabIndex = 3;
            this.ParametersTitleLable.Text = "Введите параметры \r\nмодели";
            this.ParametersTitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // n_field
            // 
            this.n_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelParametersBinding, "n", true));
            this.n_field.Location = new System.Drawing.Point(214, 94);
            this.n_field.Name = "n_field";
            this.n_field.Size = new System.Drawing.Size(100, 22);
            this.n_field.TabIndex = 2;
            // 
            // v_max_field
            // 
            this.v_max_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelParametersBinding, "Vmax", true));
            this.v_max_field.Location = new System.Drawing.Point(214, 126);
            this.v_max_field.Name = "v_max_field";
            this.v_max_field.Size = new System.Drawing.Size(100, 22);
            this.v_max_field.TabIndex = 1;
            // 
            // a_field
            // 
            this.a_field.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelParametersBinding, "a", true));
            this.a_field.Location = new System.Drawing.Point(214, 162);
            this.a_field.Name = "a_field";
            this.a_field.Size = new System.Drawing.Size(100, 22);
            this.a_field.TabIndex = 0;
            // 
            // slam_Panel
            // 
            this.slam_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(29)))));
            this.slam_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slam_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.slam_Panel.Location = new System.Drawing.Point(1228, 27);
            this.slam_Panel.Name = "slam_Panel";
            this.slam_Panel.Size = new System.Drawing.Size(8, 657);
            this.slam_Panel.TabIndex = 3;
            this.slam_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.slam_Panel_MouseClick);
            // 
            // parametersErrorProvider
            // 
            this.parametersErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.parametersErrorProvider.ContainerControl = this;
            this.parametersErrorProvider.DataSource = this.modelParametersBinding;
            this.parametersErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("parametersErrorProvider.Icon")));
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
            this.carsMovementChart.Size = new System.Drawing.Size(1577, 403);
            this.carsMovementChart.TabIndex = 0;
            this.carsMovementChart.Text = "chart1";
            // 
            // localizationBinding
            // 
            this.localizationBinding.DataSource = typeof(TrafficFlowSimulation.Resources.ParametersResources);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1577, 684);
            this.Controls.Add(this.slam_Panel);
            this.Controls.Add(this.parametersPanel);
            this.Controls.Add(this.carsMovementContainer);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.carsMovementContainer.Panel1.ResumeLayout(false);
            this.carsMovementContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementContainer)).EndInit();
            this.carsMovementContainer.ResumeLayout(false);
            this.chartsContainer.Panel1.ResumeLayout(false);
            this.chartsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartsContainer)).EndInit();
            this.chartsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelParametersBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsMovementChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuStrip;
        private System.Windows.Forms.SplitContainer carsMovementContainer;
        private System.Windows.Forms.SplitContainer chartsContainer;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
        private System.Windows.Forms.Panel parametersPanel;
        private System.Windows.Forms.Panel slam_Panel;
        private System.Windows.Forms.TextBox n_field;
        private System.Windows.Forms.TextBox v_max_field;
        private System.Windows.Forms.TextBox a_field;
        private System.Windows.Forms.ToolStripButton startToolStripButton;
        private System.Windows.Forms.BindingSource modelParametersBinding;
        private System.Windows.Forms.Label ParametersTitleLable;
        private System.Windows.Forms.ToolStripDropDownButton languagesSwitcherButton;
        private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
        private System.Windows.Forms.BindingSource localizationBinding;
        private System.Windows.Forms.Label maximumSpeedLabel;
        private System.Windows.Forms.Label vehiclesNumberLabel;
        private System.Windows.Forms.Label accelerationIntensityLabel;
        private System.Windows.Forms.TextBox q_field;
        private System.Windows.Forms.Label decelerationIntensityLabel;
        private System.Windows.Forms.ErrorProvider parametersErrorProvider;
        private System.Windows.Forms.DataVisualization.Charting.Chart carsMovementChart;
    }
}