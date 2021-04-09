namespace DemoEnvironmentVaultTool
{
    partial class VaultCopyParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultCopyParameters));
            this.vaultName = new System.Windows.Forms.TextBox();
            this.copyVaultNameLabel = new System.Windows.Forms.Label();
            this.vaultCopyGroupBox = new System.Windows.Forms.GroupBox();
            this.copyStructureOnlyCheckbox = new System.Windows.Forms.CheckBox();
            this.copyAllDataCheckbox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createVaultConnection = new System.Windows.Forms.CheckBox();
            this.vaultCopyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // vaultName
            // 
            this.vaultName.Location = new System.Drawing.Point(185, 21);
            this.vaultName.Name = "vaultName";
            this.vaultName.Size = new System.Drawing.Size(366, 20);
            this.vaultName.TabIndex = 0;
            // 
            // copyVaultNameLabel
            // 
            this.copyVaultNameLabel.AutoSize = true;
            this.copyVaultNameLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyVaultNameLabel.Location = new System.Drawing.Point(12, 22);
            this.copyVaultNameLabel.Name = "copyVaultNameLabel";
            this.copyVaultNameLabel.Size = new System.Drawing.Size(167, 17);
            this.copyVaultNameLabel.TabIndex = 1;
            this.copyVaultNameLabel.Text = "Name of the Vault Copy";
            // 
            // vaultCopyGroupBox
            // 
            this.vaultCopyGroupBox.Controls.Add(this.copyStructureOnlyCheckbox);
            this.vaultCopyGroupBox.Controls.Add(this.copyAllDataCheckbox);
            this.vaultCopyGroupBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaultCopyGroupBox.Location = new System.Drawing.Point(15, 58);
            this.vaultCopyGroupBox.Name = "vaultCopyGroupBox";
            this.vaultCopyGroupBox.Size = new System.Drawing.Size(536, 90);
            this.vaultCopyGroupBox.TabIndex = 2;
            this.vaultCopyGroupBox.TabStop = false;
            this.vaultCopyGroupBox.Text = "Data to Copy";
            // 
            // copyStructureOnlyCheckbox
            // 
            this.copyStructureOnlyCheckbox.AutoSize = true;
            this.copyStructureOnlyCheckbox.Location = new System.Drawing.Point(6, 51);
            this.copyStructureOnlyCheckbox.Name = "copyStructureOnlyCheckbox";
            this.copyStructureOnlyCheckbox.Size = new System.Drawing.Size(136, 20);
            this.copyStructureOnlyCheckbox.TabIndex = 18;
            this.copyStructureOnlyCheckbox.Text = "Copy Structure Only";
            this.copyStructureOnlyCheckbox.UseVisualStyleBackColor = true;
            this.copyStructureOnlyCheckbox.CheckedChanged += new System.EventHandler(this.copyStructureOnlyCheckbox_CheckedChanged);
            // 
            // copyAllDataCheckbox
            // 
            this.copyAllDataCheckbox.AutoSize = true;
            this.copyAllDataCheckbox.Location = new System.Drawing.Point(6, 25);
            this.copyAllDataCheckbox.Name = "copyAllDataCheckbox";
            this.copyAllDataCheckbox.Size = new System.Drawing.Size(102, 20);
            this.copyAllDataCheckbox.TabIndex = 17;
            this.copyAllDataCheckbox.Text = "Copy All Data";
            this.copyAllDataCheckbox.UseVisualStyleBackColor = true;
            this.copyAllDataCheckbox.CheckedChanged += new System.EventHandler(this.copyAllDataCheckbox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(23, 193);
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
            this.cancelButton.Location = new System.Drawing.Point(382, 193);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(163, 37);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createVaultConnection
            // 
            this.createVaultConnection.AutoSize = true;
            this.createVaultConnection.Enabled = false;
            this.createVaultConnection.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createVaultConnection.Location = new System.Drawing.Point(21, 154);
            this.createVaultConnection.Name = "createVaultConnection";
            this.createVaultConnection.Size = new System.Drawing.Size(356, 20);
            this.createVaultConnection.TabIndex = 5;
            this.createVaultConnection.Text = "Create vault connection configuration file for the copy vault.";
            this.createVaultConnection.UseVisualStyleBackColor = true;
            this.createVaultConnection.CheckedChanged += new System.EventHandler(this.createVaultConnection_CheckedChanged);
            // 
            // VaultCopyParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 245);
            this.Controls.Add(this.createVaultConnection);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.vaultCopyGroupBox);
            this.Controls.Add(this.copyVaultNameLabel);
            this.Controls.Add(this.vaultName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VaultCopyParameters";
            this.Text = "Vault Copy";
            this.vaultCopyGroupBox.ResumeLayout(false);
            this.vaultCopyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vaultName;
        private System.Windows.Forms.Label copyVaultNameLabel;
        private System.Windows.Forms.GroupBox vaultCopyGroupBox;
        private System.Windows.Forms.CheckBox copyWorkFlows;
        private System.Windows.Forms.CheckBox copyViews;
        private System.Windows.Forms.CheckBox copyUserAccounts;
        private System.Windows.Forms.CheckBox copyScheduledExportAndImportJobs;
        private System.Windows.Forms.CheckBox copyDataSets;
        private System.Windows.Forms.CheckBox copyPropertyDefinitions;
        private System.Windows.Forms.CheckBox copyValueListDefinitions;
        private System.Windows.Forms.CheckBox copyLanguagesAndTranslations;
        private System.Windows.Forms.CheckBox copyInternalEventHandlers;
        private System.Windows.Forms.CheckBox copyEventLog;
        private System.Windows.Forms.CheckBox copyDocuments;
        private System.Windows.Forms.CheckBox copyValueListContent;
        private System.Windows.Forms.CheckBox copyConnectionsToExternalLocations;
        private System.Windows.Forms.CheckBox copyDocumentProfiles;
        private System.Windows.Forms.CheckBox copyApplications;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox copyFileContent;
        private System.Windows.Forms.CheckBox createVaultConnection;
        private System.Windows.Forms.CheckBox copyStructureOnlyCheckbox;
        private System.Windows.Forms.CheckBox copyAllDataCheckbox;
    }
}