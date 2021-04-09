namespace DemoEnvironmentVaultTool
{
    partial class VaultAppManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultAppManager));
            this.listVaultApps = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLicense = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateAppButton = new System.Windows.Forms.Button();
            this.updateLicenseButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.vaultLabel = new System.Windows.Forms.Label();
            this.oMsgLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.unistallAppButton = new System.Windows.Forms.Button();
            this.updateFromAzureButton = new System.Windows.Forms.Button();
            this.InstallDropDown = new System.Windows.Forms.Button();
            this.UpdatePanelDropDown = new System.Windows.Forms.Panel();
            this.LicenseButton = new System.Windows.Forms.Button();
            this.LicensePanelDropDown = new System.Windows.Forms.Panel();
            this.UpdateLicFromAzureButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UpdatePanelDropDown.SuspendLayout();
            this.LicensePanelDropDown.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listVaultApps
            // 
            this.listVaultApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVaultApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnVersion,
            this.columnStatus,
            this.columnLicense,
            this.columnType,
            this.columnNote});
            this.listVaultApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listVaultApps.HideSelection = false;
            this.listVaultApps.Location = new System.Drawing.Point(257, 61);
            this.listVaultApps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listVaultApps.Name = "listVaultApps";
            this.listVaultApps.Size = new System.Drawing.Size(1098, 307);
            this.listVaultApps.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listVaultApps.TabIndex = 0;
            this.listVaultApps.UseCompatibleStateImageBehavior = false;
            this.listVaultApps.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Application Name";
            this.columnName.Width = 281;
            // 
            // columnVersion
            // 
            this.columnVersion.Text = "Version";
            this.columnVersion.Width = 88;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 89;
            // 
            // columnLicense
            // 
            this.columnLicense.DisplayIndex = 4;
            this.columnLicense.Text = "License";
            this.columnLicense.Width = 111;
            // 
            // columnType
            // 
            this.columnType.DisplayIndex = 3;
            this.columnType.Text = "App Type";
            this.columnType.Width = 97;
            // 
            // columnNote
            // 
            this.columnNote.Text = "Note";
            this.columnNote.Width = 410;
            // 
            // updateAppButton
            // 
            this.updateAppButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.updateAppButton.FlatAppearance.BorderSize = 0;
            this.updateAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateAppButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateAppButton.ForeColor = System.Drawing.Color.White;
            this.updateAppButton.Location = new System.Drawing.Point(0, 74);
            this.updateAppButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateAppButton.Name = "updateAppButton";
            this.updateAppButton.Size = new System.Drawing.Size(238, 37);
            this.updateAppButton.TabIndex = 2;
            this.updateAppButton.Text = "Install App from File";
            this.updateAppButton.UseVisualStyleBackColor = false;
            this.updateAppButton.Click += new System.EventHandler(this.updateAppButton_Click);
            // 
            // updateLicenseButton
            // 
            this.updateLicenseButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.updateLicenseButton.FlatAppearance.BorderSize = 0;
            this.updateLicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateLicenseButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateLicenseButton.ForeColor = System.Drawing.Color.White;
            this.updateLicenseButton.Location = new System.Drawing.Point(0, 74);
            this.updateLicenseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateLicenseButton.Name = "updateLicenseButton";
            this.updateLicenseButton.Size = new System.Drawing.Size(238, 37);
            this.updateLicenseButton.TabIndex = 3;
            this.updateLicenseButton.Text = "Install License file";
            this.updateLicenseButton.UseVisualStyleBackColor = false;
            this.updateLicenseButton.Click += new System.EventHandler(this.updateLicenseButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(3, 25);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(238, 37);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // vaultLabel
            // 
            this.vaultLabel.AutoSize = true;
            this.vaultLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaultLabel.Location = new System.Drawing.Point(253, 23);
            this.vaultLabel.Name = "vaultLabel";
            this.vaultLabel.Size = new System.Drawing.Size(47, 20);
            this.vaultLabel.TabIndex = 5;
            this.vaultLabel.Text = "Vault";
            // 
            // oMsgLabel
            // 
            this.oMsgLabel.AutoSize = true;
            this.oMsgLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oMsgLabel.Location = new System.Drawing.Point(253, 397);
            this.oMsgLabel.Name = "oMsgLabel";
            this.oMsgLabel.Size = new System.Drawing.Size(81, 20);
            this.oMsgLabel.TabIndex = 6;
            this.oMsgLabel.Text = "operation";
            this.oMsgLabel.Visible = false;
            this.oMsgLabel.Click += new System.EventHandler(this.operationMsgLabel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mfappx";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\demo.user\\Desktop";
            this.openFileDialog1.Title = "Browse Application File";
            // 
            // unistallAppButton
            // 
            this.unistallAppButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.unistallAppButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.unistallAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unistallAppButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unistallAppButton.ForeColor = System.Drawing.Color.White;
            this.unistallAppButton.Location = new System.Drawing.Point(3, 89);
            this.unistallAppButton.Name = "unistallAppButton";
            this.unistallAppButton.Size = new System.Drawing.Size(238, 37);
            this.unistallAppButton.TabIndex = 7;
            this.unistallAppButton.Text = "Uninstall Application";
            this.unistallAppButton.UseVisualStyleBackColor = false;
            this.unistallAppButton.Click += new System.EventHandler(this.unistallAppButton_Click);
            // 
            // updateFromAzureButton
            // 
            this.updateFromAzureButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.updateFromAzureButton.FlatAppearance.BorderSize = 0;
            this.updateFromAzureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateFromAzureButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateFromAzureButton.ForeColor = System.Drawing.Color.White;
            this.updateFromAzureButton.Location = new System.Drawing.Point(0, 37);
            this.updateFromAzureButton.Name = "updateFromAzureButton";
            this.updateFromAzureButton.Size = new System.Drawing.Size(238, 37);
            this.updateFromAzureButton.TabIndex = 8;
            this.updateFromAzureButton.Text = "Update App";
            this.updateFromAzureButton.UseVisualStyleBackColor = false;
            this.updateFromAzureButton.Click += new System.EventHandler(this.updateFromAzureButton_Click);
            // 
            // InstallDropDown
            // 
            this.InstallDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.InstallDropDown.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.InstallDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallDropDown.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallDropDown.ForeColor = System.Drawing.Color.White;
            this.InstallDropDown.Location = new System.Drawing.Point(0, 0);
            this.InstallDropDown.Name = "InstallDropDown";
            this.InstallDropDown.Size = new System.Drawing.Size(238, 37);
            this.InstallDropDown.TabIndex = 9;
            this.InstallDropDown.Text = "Application Update";
            this.InstallDropDown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.InstallDropDown.UseVisualStyleBackColor = false;
            this.InstallDropDown.Click += new System.EventHandler(this.InstallDropDown_Click);
            // 
            // UpdatePanelDropDown
            // 
            this.UpdatePanelDropDown.Controls.Add(this.InstallDropDown);
            this.UpdatePanelDropDown.Controls.Add(this.updateFromAzureButton);
            this.UpdatePanelDropDown.Controls.Add(this.updateAppButton);
            this.UpdatePanelDropDown.Location = new System.Drawing.Point(3, 3);
            this.UpdatePanelDropDown.MaximumSize = new System.Drawing.Size(240, 112);
            this.UpdatePanelDropDown.MinimumSize = new System.Drawing.Size(240, 37);
            this.UpdatePanelDropDown.Name = "UpdatePanelDropDown";
            this.UpdatePanelDropDown.Size = new System.Drawing.Size(240, 37);
            this.UpdatePanelDropDown.TabIndex = 10;
            // 
            // LicenseButton
            // 
            this.LicenseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.LicenseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.LicenseButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.LicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LicenseButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseButton.ForeColor = System.Drawing.Color.White;
            this.LicenseButton.Location = new System.Drawing.Point(0, 0);
            this.LicenseButton.Name = "LicenseButton";
            this.LicenseButton.Size = new System.Drawing.Size(238, 37);
            this.LicenseButton.TabIndex = 11;
            this.LicenseButton.Text = "License Update";
            this.LicenseButton.UseVisualStyleBackColor = false;
            this.LicenseButton.Click += new System.EventHandler(this.LicenseButton_Click);
            // 
            // LicensePanelDropDown
            // 
            this.LicensePanelDropDown.Controls.Add(this.LicenseButton);
            this.LicensePanelDropDown.Controls.Add(this.UpdateLicFromAzureButton);
            this.LicensePanelDropDown.Controls.Add(this.updateLicenseButton);
            this.LicensePanelDropDown.Location = new System.Drawing.Point(3, 46);
            this.LicensePanelDropDown.MaximumSize = new System.Drawing.Size(238, 112);
            this.LicensePanelDropDown.MinimumSize = new System.Drawing.Size(238, 37);
            this.LicensePanelDropDown.Name = "LicensePanelDropDown";
            this.LicensePanelDropDown.Size = new System.Drawing.Size(238, 37);
            this.LicensePanelDropDown.TabIndex = 12;
            // 
            // UpdateLicFromAzureButton
            // 
            this.UpdateLicFromAzureButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.UpdateLicFromAzureButton.FlatAppearance.BorderSize = 0;
            this.UpdateLicFromAzureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateLicFromAzureButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLicFromAzureButton.ForeColor = System.Drawing.Color.White;
            this.UpdateLicFromAzureButton.Location = new System.Drawing.Point(0, 37);
            this.UpdateLicFromAzureButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateLicFromAzureButton.Name = "UpdateLicFromAzureButton";
            this.UpdateLicFromAzureButton.Size = new System.Drawing.Size(238, 37);
            this.UpdateLicFromAzureButton.TabIndex = 13;
            this.UpdateLicFromAzureButton.Text = "Update License Now";
            this.UpdateLicFromAzureButton.UseVisualStyleBackColor = false;
            this.UpdateLicFromAzureButton.Click += new System.EventHandler(this.UpdateLicFromAzureButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.flowLayoutPanel1.Controls.Add(this.UpdatePanelDropDown);
            this.flowLayoutPanel1.Controls.Add(this.LicensePanelDropDown);
            this.flowLayoutPanel1.Controls.Add(this.unistallAppButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-1, 229);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 234);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // timer2
            // 
            this.timer2.Interval = 15;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 230);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Vault Application Manager\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.pictureBox1.BackgroundImage = global::DemoEnvironmentVaultTool.Properties.Resources.app_configman_s0;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(61, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(-1, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 65);
            this.panel2.TabIndex = 16;
            // 
            // VaultAppManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1369, 526);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.oMsgLabel);
            this.Controls.Add(this.vaultLabel);
            this.Controls.Add(this.listVaultApps);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "VaultAppManager";
            this.Text = "Vault Application Manager";
            this.UpdatePanelDropDown.ResumeLayout(false);
            this.LicensePanelDropDown.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listVaultApps;
        private System.Windows.Forms.Button updateAppButton;
        private System.Windows.Forms.Button updateLicenseButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnVersion;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnLicense;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnNote;
        private System.Windows.Forms.Label vaultLabel;
        private System.Windows.Forms.Label oMsgLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button unistallAppButton;
        private System.Windows.Forms.Button updateFromAzureButton;
        private System.Windows.Forms.Button InstallDropDown;
        private System.Windows.Forms.Panel UpdatePanelDropDown;
        private System.Windows.Forms.Button LicenseButton;
        private System.Windows.Forms.Panel LicensePanelDropDown;
        private System.Windows.Forms.Button UpdateLicFromAzureButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}