
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.speedPictureBox = new System.Windows.Forms.PictureBox();
            this.distancePictureBox = new System.Windows.Forms.PictureBox();
            this.menu_Panel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.slam_Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distancePictureBox)).BeginInit();
            this.menu_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.splitContainer2.Panel1.Controls.Add(this.speedPictureBox);
            this.splitContainer2.Panel1MinSize = 500;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.distancePictureBox);
            this.splitContainer2.Panel2MinSize = 500;
            this.splitContainer2.Size = new System.Drawing.Size(1896, 523);
            this.splitContainer2.SplitterDistance = 790;
            this.splitContainer2.TabIndex = 0;
            // 
            // speedPictureBox
            // 
            this.speedPictureBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.speedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedPictureBox.Location = new System.Drawing.Point(0, 0);
            this.speedPictureBox.Name = "speedPictureBox";
            this.speedPictureBox.Size = new System.Drawing.Size(790, 523);
            this.speedPictureBox.TabIndex = 0;
            this.speedPictureBox.TabStop = false;
            // 
            // distancePictureBox
            // 
            this.distancePictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.distancePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.distancePictureBox.Location = new System.Drawing.Point(0, 0);
            this.distancePictureBox.Name = "distancePictureBox";
            this.distancePictureBox.Size = new System.Drawing.Size(1102, 523);
            this.distancePictureBox.TabIndex = 0;
            this.distancePictureBox.TabStop = false;
            // 
            // menu_Panel
            // 
            this.menu_Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 977);
            this.Controls.Add(this.slam_Panel);
            this.Controls.Add(this.menu_Panel);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic flow simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distancePictureBox)).EndInit();
            this.menu_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox speedPictureBox;
        private System.Windows.Forms.PictureBox distancePictureBox;
        private System.Windows.Forms.Panel menu_Panel;
        private System.Windows.Forms.Panel slam_Panel;
        private System.Windows.Forms.Button startButton;
    }
}