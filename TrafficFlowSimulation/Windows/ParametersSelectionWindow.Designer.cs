namespace TrafficFlowSimulation.Windows
{
    partial class ParametersSelectionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersSelectionWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ControlMenuStrip = new System.Windows.Forms.ToolStrip();
            this.SelectParametersToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ParametersSelectionModeStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.ParametersSelectionStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ParametersSelectionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.MovementParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.ModeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SlamPanel = new System.Windows.Forms.Panel();
            this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ControlMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersSelectionChart)).BeginInit();
            this.parametersPanel.SuspendLayout();
            this.MovementParametersGroupBox.SuspendLayout();
            this.ModeSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlMenuStrip
            // 
            this.ControlMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ControlMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectParametersToolStripButton,
            this.toolStripSeparator1,
            this.ParametersSelectionModeStripLabel,
            this.ParametersSelectionStripDropDownButton});
            this.ControlMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ControlMenuStrip.Name = "ControlMenuStrip";
            this.ControlMenuStrip.Size = new System.Drawing.Size(800, 31);
            this.ControlMenuStrip.TabIndex = 0;
            this.ControlMenuStrip.Text = "ControlMenuStrip";
            // 
            // SelectParametersToolStripButton
            // 
            this.SelectParametersToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectParametersToolStripButton.Image")));
            this.SelectParametersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectParametersToolStripButton.Name = "SelectParametersToolStripButton";
            this.SelectParametersToolStripButton.Size = new System.Drawing.Size(176, 28);
            this.SelectParametersToolStripButton.Text = "Оценить параметры";
            this.SelectParametersToolStripButton.Click += new System.EventHandler(this.SelectParametersToolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ParametersSelectionModeStripLabel
            // 
            this.ParametersSelectionModeStripLabel.Name = "ParametersSelectionModeStripLabel";
            this.ParametersSelectionModeStripLabel.Size = new System.Drawing.Size(203, 28);
            this.ParametersSelectionModeStripLabel.Text = "Режим оценки параметров:";
            // 
            // ParametersSelectionStripDropDownButton
            // 
            this.ParametersSelectionStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ParametersSelectionStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("ParametersSelectionStripDropDownButton.Image")));
            this.ParametersSelectionStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParametersSelectionStripDropDownButton.Name = "ParametersSelectionStripDropDownButton";
            this.ParametersSelectionStripDropDownButton.Size = new System.Drawing.Size(81, 28);
            this.ParametersSelectionStripDropDownButton.Text = "Режимы";
            // 
            // ParametersSelectionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ParametersSelectionChart.ChartAreas.Add(chartArea1);
            this.ParametersSelectionChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.ParametersSelectionChart.Legends.Add(legend1);
            this.ParametersSelectionChart.Location = new System.Drawing.Point(0, 31);
            this.ParametersSelectionChart.Name = "ParametersSelectionChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ParametersSelectionChart.Series.Add(series1);
            this.ParametersSelectionChart.Size = new System.Drawing.Size(800, 419);
            this.ParametersSelectionChart.TabIndex = 1;
            this.ParametersSelectionChart.Text = "ParametersSelectionChart";
            // 
            // parametersPanel
            // 
            this.parametersPanel.AutoScroll = true;
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.parametersPanel.Controls.Add(this.MovementParametersGroupBox);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.parametersPanel.Location = new System.Drawing.Point(404, 31);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Size = new System.Drawing.Size(396, 419);
            this.parametersPanel.TabIndex = 3;
            // 
            // MovementParametersGroupBox
            // 
            this.MovementParametersGroupBox.AutoSize = true;
            this.MovementParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MovementParametersGroupBox.Controls.Add(this.ModeSettingsGroupBox);
            this.MovementParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovementParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MovementParametersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MovementParametersGroupBox.Name = "MovementParametersGroupBox";
            this.MovementParametersGroupBox.Size = new System.Drawing.Size(396, 68);
            this.MovementParametersGroupBox.TabIndex = 20;
            this.MovementParametersGroupBox.TabStop = false;
            this.MovementParametersGroupBox.Text = "Параметры:";
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
            this.ModeSettingsGroupBox.Text = "Настройки:";
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
            this.SlamPanel.Location = new System.Drawing.Point(396, 31);
            this.SlamPanel.Name = "SlamPanel";
            this.SlamPanel.Size = new System.Drawing.Size(8, 419);
            this.SlamPanel.TabIndex = 4;
            this.SlamPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SlamPanel_MouseClick);
            // 
            // ParametersErrorProvider
            // 
            this.ParametersErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ParametersErrorProvider.ContainerControl = this;
            this.ParametersErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ParametersErrorProvider.Icon")));
            // 
            // ParametersSelectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SlamPanel);
            this.Controls.Add(this.parametersPanel);
            this.Controls.Add(this.ParametersSelectionChart);
            this.Controls.Add(this.ControlMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParametersSelectionWindow";
            this.Text = "Traffic flow simulation";
            this.ControlMenuStrip.ResumeLayout(false);
            this.ControlMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersSelectionChart)).EndInit();
            this.parametersPanel.ResumeLayout(false);
            this.parametersPanel.PerformLayout();
            this.MovementParametersGroupBox.ResumeLayout(false);
            this.MovementParametersGroupBox.PerformLayout();
            this.ModeSettingsGroupBox.ResumeLayout(false);
            this.ModeSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ControlMenuStrip;
        private System.Windows.Forms.ToolStripButton SelectParametersToolStripButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart ParametersSelectionChart;
        private System.Windows.Forms.Panel parametersPanel;
        private System.Windows.Forms.GroupBox MovementParametersGroupBox;
        private System.Windows.Forms.GroupBox ModeSettingsGroupBox;
        private System.Windows.Forms.TableLayoutPanel SettingsTableLayoutPanel;
        private System.Windows.Forms.Panel SlamPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel ParametersSelectionModeStripLabel;
        private System.Windows.Forms.ToolStripDropDownButton ParametersSelectionStripDropDownButton;
        private System.Windows.Forms.ErrorProvider ParametersErrorProvider;
    }
}