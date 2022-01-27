
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
            this.menuStrip = new System.Windows.Forms.ToolStrip();
            this.startToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.languagesSwitcherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.RussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.ParametersTitleLable = new System.Windows.Forms.Label();
            this.field_n = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.slam_Panel = new System.Windows.Forms.Panel();
            this.modelParametersBinding = new System.Windows.Forms.BindingSource(this.components);
            this.localizationBinding = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
            this.parametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelParametersBinding)).BeginInit();
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
            this.menuStrip.Size = new System.Drawing.Size(1896, 31);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "toolStrip1";
            // 
            // startToolStripButton
            // 
            this.startToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripButton.Image")));
            this.startToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripButton.Name = "startToolStripButton";
            this.startToolStripButton.Size = new System.Drawing.Size(44, 28);
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
            this.languagesSwitcherButton.Size = new System.Drawing.Size(97, 28);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1896, 946);
            this.splitContainer1.SplitterDistance = 473;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.speedChart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.distanceChart);
            this.splitContainer2.Size = new System.Drawing.Size(1896, 469);
            this.splitContainer2.SplitterDistance = 688;
            this.splitContainer2.TabIndex = 0;
            // 
            // speedChart
            // 
            chartArea1.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea1);
            this.speedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.speedChart.Legends.Add(legend1);
            this.speedChart.Location = new System.Drawing.Point(0, 0);
            this.speedChart.Name = "speedChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.speedChart.Series.Add(series1);
            this.speedChart.Size = new System.Drawing.Size(688, 469);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "chart1";
            // 
            // distanceChart
            // 
            chartArea2.Name = "ChartArea1";
            this.distanceChart.ChartAreas.Add(chartArea2);
            this.distanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.distanceChart.Legends.Add(legend2);
            this.distanceChart.Location = new System.Drawing.Point(0, 0);
            this.distanceChart.Name = "distanceChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.distanceChart.Series.Add(series2);
            this.distanceChart.Size = new System.Drawing.Size(1204, 469);
            this.distanceChart.TabIndex = 0;
            this.distanceChart.Text = "chart2";
            // 
            // parametersPanel
            // 
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.parametersPanel.Controls.Add(this.ParametersTitleLable);
            this.parametersPanel.Controls.Add(this.field_n);
            this.parametersPanel.Controls.Add(this.textBox2);
            this.parametersPanel.Controls.Add(this.textBox1);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.parametersPanel.Location = new System.Drawing.Point(1555, 31);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Size = new System.Drawing.Size(341, 946);
            this.parametersPanel.TabIndex = 2;
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
            // field_n
            // 
            this.field_n.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelParametersBinding, "n", true));
            this.field_n.Location = new System.Drawing.Point(127, 100);
            this.field_n.Name = "field_n";
            this.field_n.Size = new System.Drawing.Size(100, 22);
            this.field_n.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 238);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // slam_Panel
            // 
            this.slam_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(29)))));
            this.slam_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slam_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.slam_Panel.Location = new System.Drawing.Point(1547, 31);
            this.slam_Panel.Name = "slam_Panel";
            this.slam_Panel.Size = new System.Drawing.Size(8, 946);
            this.slam_Panel.TabIndex = 3;
            this.slam_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.slam_Panel_MouseClick);
            // 
            // modelParametersBinding
            // 
            this.modelParametersBinding.DataSource = typeof(EvaluationKernel.Models.ModelParameters);
            // 
            // localizationBinding
            // 
            this.localizationBinding.DataSource = typeof(TrafficFlowSimulation.Resources.ParametersResources);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 977);
            this.Controls.Add(this.slam_Panel);
            this.Controls.Add(this.parametersPanel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelParametersBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
        private System.Windows.Forms.Panel parametersPanel;
        private System.Windows.Forms.Panel slam_Panel;
        private System.Windows.Forms.TextBox field_n;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton startToolStripButton;
        private System.Windows.Forms.BindingSource modelParametersBinding;
        private System.Windows.Forms.Label ParametersTitleLable;
        private System.Windows.Forms.ToolStripDropDownButton languagesSwitcherButton;
        private System.Windows.Forms.ToolStripMenuItem RussianMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishMenuItem;
        private System.Windows.Forms.BindingSource localizationBinding;
    }
}