
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
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.simulationPanel = new System.Windows.Forms.Panel();
            this.distancePanel = new System.Windows.Forms.Panel();
            this.distancePictureBox = new System.Windows.Forms.PictureBox();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.speedPictureBox = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.simulationPanel.SuspendLayout();
            this.distancePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distancePictureBox)).BeginInit();
            this.speedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(97, 131);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(88, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "button1";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(97, 58);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(88, 50);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // simulationPanel
            // 
            this.simulationPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.simulationPanel.Controls.Add(this.menuPanel);
            this.simulationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.simulationPanel.Location = new System.Drawing.Point(0, 0);
            this.simulationPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(1920, 397);
            this.simulationPanel.TabIndex = 1;
            // 
            // distancePanel
            // 
            this.distancePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.distancePanel.Controls.Add(this.distancePictureBox);
            this.distancePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.distancePanel.Location = new System.Drawing.Point(959, 397);
            this.distancePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distancePanel.Name = "distancePanel";
            this.distancePanel.Size = new System.Drawing.Size(961, 580);
            this.distancePanel.TabIndex = 2;
            // 
            // distancePictureBox
            // 
            this.distancePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.distancePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distancePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.distancePictureBox.Location = new System.Drawing.Point(0, 0);
            this.distancePictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distancePictureBox.Name = "distancePictureBox";
            this.distancePictureBox.Size = new System.Drawing.Size(961, 580);
            this.distancePictureBox.TabIndex = 0;
            this.distancePictureBox.TabStop = false;
            // 
            // speedPanel
            // 
            this.speedPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.speedPanel.Controls.Add(this.speedPictureBox);
            this.speedPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.speedPanel.Location = new System.Drawing.Point(0, 397);
            this.speedPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new System.Drawing.Size(961, 580);
            this.speedPanel.TabIndex = 3;
            // 
            // speedPictureBox
            // 
            this.speedPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.speedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedPictureBox.Location = new System.Drawing.Point(0, 0);
            this.speedPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedPictureBox.Name = "speedPictureBox";
            this.speedPictureBox.Size = new System.Drawing.Size(961, 580);
            this.speedPictureBox.TabIndex = 0;
            this.speedPictureBox.TabStop = false;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.Window;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Controls.Add(this.stopButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuPanel.Location = new System.Drawing.Point(1452, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(468, 397);
            this.menuPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 977);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.distancePanel);
            this.Controls.Add(this.simulationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1942, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.simulationPanel.ResumeLayout(false);
            this.distancePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.distancePictureBox)).EndInit();
            this.speedPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;

        #endregion
        private System.Windows.Forms.Panel simulationPanel;
        private System.Windows.Forms.Panel distancePanel;
        private System.Windows.Forms.Panel speedPanel;
        private System.Windows.Forms.PictureBox distancePictureBox;
        private System.Windows.Forms.PictureBox speedPictureBox;
        private System.Windows.Forms.Panel menuPanel;
    }
}