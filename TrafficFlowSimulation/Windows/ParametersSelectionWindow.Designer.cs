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
            this.ToolStripLoadingLabel = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ParametersSelectionModeStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.ParametersSelectionStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ParametersSelectionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ParametersPanel = new System.Windows.Forms.Panel();
            this.BasicParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.BasicParametersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MovementParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.ModeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SlamPanel = new System.Windows.Forms.Panel();
            this.ParametersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ControlMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersSelectionChart)).BeginInit();
            this.ParametersPanel.SuspendLayout();
            this.BasicParametersGroupBox.SuspendLayout();
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
            this.ToolStripLoadingLabel,
            this.ToolStripProgressBar,
            this.toolStripSeparator2,
            this.ParametersSelectionModeStripLabel,
            this.ParametersSelectionStripDropDownButton});
            this.ControlMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ControlMenuStrip.Name = "ControlMenuStrip";
            this.ControlMenuStrip.Size = new System.Drawing.Size(1023, 31);
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
            this.SelectParametersToolStripButton.Click += new System.EventHandler(this.SelectParametersToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ToolStripLoadingLabel
            // 
            this.ToolStripLoadingLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripLoadingLabel.Image = global::TrafficFlowSimulation.Properties.Resources.gear_static;
            this.ToolStripLoadingLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripLoadingLabel.Name = "ToolStripLoadingLabel";
            this.ToolStripLoadingLabel.Size = new System.Drawing.Size(28, 28);
            // 
            // ToolStripProgressBar
            // 
            this.ToolStripProgressBar.Name = "ToolStripProgressBar";
            this.ToolStripProgressBar.Size = new System.Drawing.Size(150, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
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
            this.ParametersSelectionChart.Size = new System.Drawing.Size(1023, 577);
            this.ParametersSelectionChart.TabIndex = 1;
            this.ParametersSelectionChart.Text = "ParametersSelectionChart";
            // 
            // ParametersPanel
            // 
            this.ParametersPanel.AutoScroll = true;
            this.ParametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.ParametersPanel.Controls.Add(this.BasicParametersGroupBox);
            this.ParametersPanel.Controls.Add(this.MovementParametersGroupBox);
            this.ParametersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ParametersPanel.Location = new System.Drawing.Point(627, 31);
            this.ParametersPanel.Name = "ParametersPanel";
            this.ParametersPanel.Size = new System.Drawing.Size(396, 577);
            this.ParametersPanel.TabIndex = 3;
            // 
            // BasicParametersGroupBox
            // 
            this.BasicParametersGroupBox.AutoSize = true;
            this.BasicParametersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BasicParametersGroupBox.Controls.Add(this.BasicParametersTableLayoutPanel);
            this.BasicParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BasicParametersGroupBox.Location = new System.Drawing.Point(0, 68);
            this.BasicParametersGroupBox.Name = "BasicParametersGroupBox";
            this.BasicParametersGroupBox.Size = new System.Drawing.Size(396, 31);
            this.BasicParametersGroupBox.TabIndex = 22;
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
            this.BasicParametersTableLayoutPanel.Size = new System.Drawing.Size(390, 0);
            this.BasicParametersTableLayoutPanel.TabIndex = 0;
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
            this.SlamPanel.Location = new System.Drawing.Point(619, 31);
            this.SlamPanel.Name = "SlamPanel";
            this.SlamPanel.Size = new System.Drawing.Size(8, 577);
            this.SlamPanel.TabIndex = 4;
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
            this.ClientSize = new System.Drawing.Size(1023, 608);
            this.Controls.Add(this.SlamPanel);
            this.Controls.Add(this.ParametersPanel);
            this.Controls.Add(this.ParametersSelectionChart);
            this.Controls.Add(this.ControlMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParametersSelectionWindow";
            this.Text = "Traffic flow simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParametersSelectionWindow_FormClosing);
            this.Shown += new System.EventHandler(this.ParametersSelectionWindowHelper_Shown);
            this.ControlMenuStrip.ResumeLayout(false);
            this.ControlMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersSelectionChart)).EndInit();
            this.ParametersPanel.ResumeLayout(false);
            this.ParametersPanel.PerformLayout();
            this.BasicParametersGroupBox.ResumeLayout(false);
            this.BasicParametersGroupBox.PerformLayout();
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
		private System.Windows.Forms.Panel ParametersPanel;
		private System.Windows.Forms.GroupBox MovementParametersGroupBox;
		private System.Windows.Forms.GroupBox ModeSettingsGroupBox;
		private System.Windows.Forms.TableLayoutPanel SettingsTableLayoutPanel;
		private System.Windows.Forms.Panel SlamPanel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel ParametersSelectionModeStripLabel;
		private System.Windows.Forms.ToolStripDropDownButton ParametersSelectionStripDropDownButton;
		private System.Windows.Forms.ErrorProvider ParametersErrorProvider;
        private System.Windows.Forms.GroupBox BasicParametersGroupBox;
        private System.Windows.Forms.TableLayoutPanel BasicParametersTableLayoutPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.ToolStripLabel ToolStripLoadingLabel;
    }
}