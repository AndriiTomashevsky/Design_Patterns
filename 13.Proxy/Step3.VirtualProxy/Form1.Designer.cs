namespace Step3.VirtualProxy
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonTestImageProxy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(24, 44);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(235, 247);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonTestImageProxy
            // 
            this.buttonTestImageProxy.Location = new System.Drawing.Point(12, 12);
            this.buttonTestImageProxy.Name = "buttonTestImageProxy";
            this.buttonTestImageProxy.Size = new System.Drawing.Size(75, 23);
            this.buttonTestImageProxy.TabIndex = 1;
            this.buttonTestImageProxy.Text = "Load Image";
            this.buttonTestImageProxy.UseVisualStyleBackColor = true;
            this.buttonTestImageProxy.Click += new System.EventHandler(this.buttonTestImageProxy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 311);
            this.Controls.Add(this.buttonTestImageProxy);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "VirtualProxy";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonTestImageProxy;
    }
}

