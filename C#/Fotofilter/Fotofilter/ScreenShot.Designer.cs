namespace Fotofilter
{
    partial class ScreenShot
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
            this.pbxCameraFeed = new System.Windows.Forms.PictureBox();
            this.btnSnapImage = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCameraFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCameraFeed
            // 
            this.pbxCameraFeed.Location = new System.Drawing.Point(-2, -2);
            this.pbxCameraFeed.Name = "pbxCameraFeed";
            this.pbxCameraFeed.Size = new System.Drawing.Size(1280, 720);
            this.pbxCameraFeed.TabIndex = 0;
            this.pbxCameraFeed.TabStop = false;
            // 
            // btnSnapImage
            // 
            this.btnSnapImage.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSnapImage.Location = new System.Drawing.Point(10, 724);
            this.btnSnapImage.Name = "btnSnapImage";
            this.btnSnapImage.Size = new System.Drawing.Size(180, 50);
            this.btnSnapImage.TabIndex = 1;
            this.btnSnapImage.Text = "Take Picture";
            this.btnSnapImage.UseVisualStyleBackColor = true;
            this.btnSnapImage.Click += new System.EventHandler(this.SnapImage);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(196, 724);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(382, 724);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(180, 50);
            this.Start.TabIndex = 3;
            this.Start.Text = "Start Camera";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartCamera);
            // 
            // ScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1267, 782);
            this.ControlBox = false;
            this.Controls.Add(this.Start);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSnapImage);
            this.Controls.Add(this.pbxCameraFeed);
            this.Name = "ScreenShot";
            ((System.ComponentModel.ISupportInitialize)(this.pbxCameraFeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxCameraFeed;
        private System.Windows.Forms.Button btnSnapImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Start;
    }
}