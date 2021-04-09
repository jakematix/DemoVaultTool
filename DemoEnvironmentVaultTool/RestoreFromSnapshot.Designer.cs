namespace DemoEnvironmentVaultTool
{
    partial class RestoreFromSnapshot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreFromSnapshot));
            this.vaultName = new System.Windows.Forms.TextBox();
            this.restoreVaultName = new System.Windows.Forms.Label();
            this.createVaultXml = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vaultName
            // 
            this.vaultName.Location = new System.Drawing.Point(234, 30);
            this.vaultName.Name = "vaultName";
            this.vaultName.Size = new System.Drawing.Size(306, 20);
            this.vaultName.TabIndex = 0;
            // 
            // restoreVaultName
            // 
            this.restoreVaultName.AutoSize = true;
            this.restoreVaultName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreVaultName.Location = new System.Drawing.Point(22, 31);
            this.restoreVaultName.Name = "restoreVaultName";
            this.restoreVaultName.Size = new System.Drawing.Size(197, 17);
            this.restoreVaultName.TabIndex = 1;
            this.restoreVaultName.Text = "Name of vault to be restored";
            // 
            // createVaultXml
            // 
            this.createVaultXml.AutoSize = true;
            this.createVaultXml.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createVaultXml.Location = new System.Drawing.Point(25, 80);
            this.createVaultXml.Name = "createVaultXml";
            this.createVaultXml.Size = new System.Drawing.Size(277, 20);
            this.createVaultXml.TabIndex = 2;
            this.createVaultXml.Text = "Create vault connection for the restored vault";
            this.createVaultXml.UseVisualStyleBackColor = true;
            this.createVaultXml.CheckedChanged += new System.EventHandler(this.createVaultXml_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(25, 136);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(163, 37);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.SteelBlue;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(377, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(163, 37);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RestoreFromSnapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 193);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.createVaultXml);
            this.Controls.Add(this.restoreVaultName);
            this.Controls.Add(this.vaultName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RestoreFromSnapshot";
            this.Text = "Restore Vault From Snapshot";
            this.Load += new System.EventHandler(this.RestoreFromSnapshot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vaultName;
        private System.Windows.Forms.Label restoreVaultName;
        private System.Windows.Forms.CheckBox createVaultXml;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}