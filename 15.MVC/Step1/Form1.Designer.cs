using System;
using System.Windows.Forms;

namespace Step1
{
    partial class Form1
    {
        private Button buttonIncreaseBPM;
        private Button buttonDecreaseBPM;
        private Button buttonStart;
        private System.Windows.Forms.Label labelMVC;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.TrackBar trackBarBPM;
        private System.Windows.Forms.TextBox textBoxBMP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TextBox textBoxCurrentBMP;

        //private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.TextBox textBoxCurrentBMP;

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
            this.panelColor = new System.Windows.Forms.Panel();
            this.textBoxCurrentBMP = new System.Windows.Forms.TextBox();
            this.labelMVC = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.buttonIncreaseBPM = new System.Windows.Forms.Button();
            this.buttonDecreaseBPM = new System.Windows.Forms.Button();
            this.trackBarBPM = new System.Windows.Forms.TrackBar();
            this.textBoxBMP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBPM)).BeginInit();
            this.groupBoxView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelColor
            // 
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelColor.Location = new System.Drawing.Point(25, 69);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(258, 29);
            this.panelColor.TabIndex = 6;
            // 
            // textBoxCurrentBMP
            // 
            this.textBoxCurrentBMP.ForeColor = System.Drawing.Color.Red;
            this.textBoxCurrentBMP.Location = new System.Drawing.Point(98, 28);
            this.textBoxCurrentBMP.Name = "textBoxCurrentBMP";
            this.textBoxCurrentBMP.Size = new System.Drawing.Size(37, 20);
            this.textBoxCurrentBMP.TabIndex = 0;
            this.textBoxCurrentBMP.Text = "0";
            // 
            // labelMVC
            // 
            this.labelMVC.AutoSize = true;
            this.labelMVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMVC.ForeColor = System.Drawing.Color.Red;
            this.labelMVC.Location = new System.Drawing.Point(12, 25);
            this.labelMVC.Name = "labelMVC";
            this.labelMVC.Size = new System.Drawing.Size(174, 18);
            this.labelMVC.TabIndex = 0;
            this.labelMVC.Text = "Model View Controller";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(262, 54);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.buttonIncreaseBPM);
            this.groupBoxControl.Controls.Add(this.buttonDecreaseBPM);
            this.groupBoxControl.Controls.Add(this.trackBarBPM);
            this.groupBoxControl.Controls.Add(this.textBoxBMP);
            this.groupBoxControl.Controls.Add(this.label1);
            this.groupBoxControl.Controls.Add(this.buttonSet);
            this.groupBoxControl.Location = new System.Drawing.Point(35, 218);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(302, 173);
            this.groupBoxControl.TabIndex = 2;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "DJ Control";
            // 
            // buttonIncreaseBPM
            // 
            this.buttonIncreaseBPM.Location = new System.Drawing.Point(158, 84);
            this.buttonIncreaseBPM.Name = "buttonIncreaseBPM";
            this.buttonIncreaseBPM.Size = new System.Drawing.Size(75, 23);
            this.buttonIncreaseBPM.TabIndex = 5;
            this.buttonIncreaseBPM.Text = ">>";
            this.buttonIncreaseBPM.UseVisualStyleBackColor = true;
            this.buttonIncreaseBPM.Click += new System.EventHandler(this.buttonIncreaseBPM_Click);
            // 
            // buttonDecreaseBPM
            // 
            this.buttonDecreaseBPM.Location = new System.Drawing.Point(65, 84);
            this.buttonDecreaseBPM.Name = "buttonDecreaseBPM";
            this.buttonDecreaseBPM.Size = new System.Drawing.Size(75, 23);
            this.buttonDecreaseBPM.TabIndex = 4;
            this.buttonDecreaseBPM.Text = "<<";
            this.buttonDecreaseBPM.UseVisualStyleBackColor = true;
            this.buttonDecreaseBPM.Click += new System.EventHandler(this.buttonDecreaseBPM_Click);
            // 
            // trackBarBPM
            // 
            this.trackBarBPM.LargeChange = 10;
            this.trackBarBPM.Location = new System.Drawing.Point(19, 113);
            this.trackBarBPM.Maximum = 200;
            this.trackBarBPM.Minimum = 1;
            this.trackBarBPM.Name = "trackBarBPM";
            this.trackBarBPM.Size = new System.Drawing.Size(277, 45);
            this.trackBarBPM.TabIndex = 3;
            this.trackBarBPM.TickFrequency = 10;
            this.trackBarBPM.Value = 120;
            this.trackBarBPM.Scroll += new System.EventHandler(this.trackBarBPM_Scroll);
            // 
            // textBoxBMP
            // 
            this.textBoxBMP.Location = new System.Drawing.Point(145, 29);
            this.textBoxBMP.Name = "textBoxBMP";
            this.textBoxBMP.Size = new System.Drawing.Size(88, 20);
            this.textBoxBMP.TabIndex = 2;
            this.textBoxBMP.Text = "120";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter BMP";
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(65, 55);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(168, 23);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current BMP:";
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.panelColor);
            this.groupBoxView.Controls.Add(this.label2);
            this.groupBoxView.Controls.Add(this.textBoxCurrentBMP);
            this.groupBoxView.Location = new System.Drawing.Point(35, 83);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(302, 118);
            this.groupBoxView.TabIndex = 3;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "DJ View";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(262, 25);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 405);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelMVC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxControl.ResumeLayout(false);
            this.groupBoxControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBPM)).EndInit();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

    }
}

