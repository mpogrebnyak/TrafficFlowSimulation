
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menu_Panel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.slam_Panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.field_n = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.menu_Panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1896, 977);
            this.splitContainer1.SplitterDistance = 450;
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
            this.splitContainer2.Panel1MinSize = 500;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.distanceChart);
            this.splitContainer2.Panel2MinSize = 500;
            this.splitContainer2.Size = new System.Drawing.Size(1896, 523);
            this.splitContainer2.SplitterDistance = 790;
            this.splitContainer2.TabIndex = 0;
            // 
            // speedChart
            // 
            chartArea5.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea5);
            this.speedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.speedChart.Legends.Add(legend5);
            this.speedChart.Location = new System.Drawing.Point(0, 0);
            this.speedChart.Name = "speedChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Series2";
            this.speedChart.Series.Add(series9);
            this.speedChart.Series.Add(series10);
            this.speedChart.Size = new System.Drawing.Size(790, 523);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "speedChart";
            // 
            // menu_Panel
            // 
            this.menu_Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_Panel.Controls.Add(this.textBox1);
            this.menu_Panel.Controls.Add(this.field_n);
            this.menu_Panel.Controls.Add(this.startButton);
            this.menu_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menu_Panel.Location = new System.Drawing.Point(1629, 0);
            this.menu_Panel.Name = "menu_Panel";
            this.menu_Panel.Size = new System.Drawing.Size(267, 977);
            this.menu_Panel.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(46, 529);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 63);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // slam_Panel
            // 
            this.slam_Panel.BackColor = System.Drawing.SystemColors.InfoText;
            this.slam_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.slam_Panel.Location = new System.Drawing.Point(1619, 0);
            this.slam_Panel.Name = "slam_Panel";
            this.slam_Panel.Size = new System.Drawing.Size(10, 977);
            this.slam_Panel.TabIndex = 3;
            this.slam_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.slam_Panel_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1896, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 24);
            this.toolStripButton1.Text = "Start";
            // 
            // distanceChart
            // 
            chartArea6.Name = "ChartArea1";
            this.distanceChart.ChartAreas.Add(chartArea6);
            this.distanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.distanceChart.Legends.Add(legend6);
            this.distanceChart.Location = new System.Drawing.Point(0, 0);
            this.distanceChart.Name = "distanceChart";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Series2";
            this.distanceChart.Series.Add(series11);
            this.distanceChart.Series.Add(series12);
            this.distanceChart.Size = new System.Drawing.Size(1102, 523);
            this.distanceChart.TabIndex = 0;
            this.distanceChart.Text = "chart1";
            // 
            // field_n
            // 
            this.field_n.Location = new System.Drawing.Point(80, 109);
            this.field_n.Name = "field_n";
            this.field_n.Size = new System.Drawing.Size(100, 22);
            this.field_n.TabIndex = 1;
            this.field_n.Text = "5";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 156);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 977);
            this.Controls.Add(this.slam_Panel);
            this.Controls.Add(this.menu_Panel);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.menu_Panel.ResumeLayout(false);
            this.menu_Panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel menu_Panel;
        private System.Windows.Forms.Panel slam_Panel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
        private System.Windows.Forms.TextBox field_n;
        private System.Windows.Forms.TextBox textBox1;
    }
}