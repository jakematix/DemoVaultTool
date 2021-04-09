namespace DemoEnvironmentVaultTool
{
    partial class WelcomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeScreen));
            this.toolboxBox = new System.Windows.Forms.PictureBox();
            this.mFilesBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.toolboxBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFilesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolboxBox
            // 
            this.toolboxBox.Image = ((System.Drawing.Image)(resources.GetObject("toolboxBox.Image")));
            this.toolboxBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("toolboxBox.InitialImage")));
            this.toolboxBox.Location = new System.Drawing.Point(44, 99);
            this.toolboxBox.Name = "toolboxBox";
            this.toolboxBox.Size = new System.Drawing.Size(140, 140);
            this.toolboxBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toolboxBox.TabIndex = 0;
            this.toolboxBox.TabStop = false;
            // 
            // mFilesBox
            // 
            this.mFilesBox.Image = ((System.Drawing.Image)(resources.GetObject("mFilesBox.Image")));
            this.mFilesBox.Location = new System.Drawing.Point(268, 99);
            this.mFilesBox.Name = "mFilesBox";
            this.mFilesBox.Size = new System.Drawing.Size(168, 50);
            this.mFilesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mFilesBox.TabIndex = 1;
            this.mFilesBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(247, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Demo Vault Tool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(248, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 3;
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mFilesBox);
            this.Controls.Add(this.toolboxBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(550, 350);
            this.MinimumSize = new System.Drawing.Size(550, 350);
            this.Name = "WelcomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Shown += new System.EventHandler(this.WelcomeScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.toolboxBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFilesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox toolboxBox;
        private System.Windows.Forms.PictureBox mFilesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}