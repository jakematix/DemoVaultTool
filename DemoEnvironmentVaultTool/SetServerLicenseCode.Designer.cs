namespace DemoEnvironmentVaultTool
{
    partial class SetServerLicenseCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetServerLicenseCode));
            this.serverLicCodeText = new System.Windows.Forms.Label();
            this.serialNumberTxt = new System.Windows.Forms.Label();
            this.serialCode = new System.Windows.Forms.TextBox();
            this.licenseCodeText = new System.Windows.Forms.Label();
            this.licenseCode = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverLicCodeText
            // 
            this.serverLicCodeText.AutoSize = true;
            this.serverLicCodeText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLicCodeText.Location = new System.Drawing.Point(16, 23);
            this.serverLicCodeText.Name = "serverLicCodeText";
            this.serverLicCodeText.Size = new System.Drawing.Size(283, 20);
            this.serverLicCodeText.TabIndex = 0;
            this.serverLicCodeText.Text = "Set the License code and click Apply.";
            // 
            // serialNumberTxt
            // 
            this.serialNumberTxt.AutoSize = true;
            this.serialNumberTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumberTxt.Location = new System.Drawing.Point(16, 83);
            this.serialNumberTxt.Name = "serialNumberTxt";
            this.serialNumberTxt.Size = new System.Drawing.Size(109, 20);
            this.serialNumberTxt.TabIndex = 1;
            this.serialNumberTxt.Text = "Serial Number";
            // 
            // serialCode
            // 
            this.serialCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialCode.Location = new System.Drawing.Point(158, 86);
            this.serialCode.Name = "serialCode";
            this.serialCode.Size = new System.Drawing.Size(400, 20);
            this.serialCode.TabIndex = 2;
            // 
            // licenseCodeText
            // 
            this.licenseCodeText.AutoSize = true;
            this.licenseCodeText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseCodeText.Location = new System.Drawing.Point(16, 131);
            this.licenseCodeText.Name = "licenseCodeText";
            this.licenseCodeText.Size = new System.Drawing.Size(110, 20);
            this.licenseCodeText.TabIndex = 3;
            this.licenseCodeText.Text = "License Code";
            // 
            // licenseCode
            // 
            this.licenseCode.Location = new System.Drawing.Point(158, 133);
            this.licenseCode.Multiline = true;
            this.licenseCode.Name = "licenseCode";
            this.licenseCode.Size = new System.Drawing.Size(400, 250);
            this.licenseCode.TabIndex = 4;
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.applyButton.FlatAppearance.BorderSize = 0;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(158, 418);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(163, 37);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(395, 418);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(163, 37);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SetServerLicenseCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 471);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.licenseCode);
            this.Controls.Add(this.licenseCodeText);
            this.Controls.Add(this.serialCode);
            this.Controls.Add(this.serialNumberTxt);
            this.Controls.Add(this.serverLicCodeText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetServerLicenseCode";
            this.Text = "Set M-Files Server License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverLicCodeText;
        private System.Windows.Forms.Label serialNumberTxt;
        private System.Windows.Forms.TextBox serialCode;
        private System.Windows.Forms.Label licenseCodeText;
        private System.Windows.Forms.TextBox licenseCode;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button closeButton;
    }
}