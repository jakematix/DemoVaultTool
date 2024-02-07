namespace DemoEnvironmentVaultTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listCurrentVaults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backUpDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.availableVaultsDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.moreInfoButton = new System.Windows.Forms.Button();
            this.prgLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectivityLabel = new System.Windows.Forms.Label();
            this.localizationOptions = new System.Windows.Forms.ComboBox();
            this.localeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.vaultAppManagerButton = new System.Windows.Forms.Button();
            this.removeVaultButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mFVersionText = new System.Windows.Forms.Label();
            this.mFVersion = new System.Windows.Forms.Label();
            this.serverLicText = new System.Windows.Forms.Label();
            this.serverLicStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.winUpdateButton = new System.Windows.Forms.Button();
            this.updateLicenseButton = new System.Windows.Forms.Button();
            this.enableDisableButton = new System.Windows.Forms.Button();
            this.restoreFromBackUpButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.connectionsButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.UpdateMFilesButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listCurrentVaults
            // 
            this.listCurrentVaults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCurrentVaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listCurrentVaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCurrentVaults.HideSelection = false;
            this.listCurrentVaults.Location = new System.Drawing.Point(19, 33);
            this.listCurrentVaults.Margin = new System.Windows.Forms.Padding(2);
            this.listCurrentVaults.MultiSelect = false;
            this.listCurrentVaults.Name = "listCurrentVaults";
            this.listCurrentVaults.Size = new System.Drawing.Size(578, 442);
            this.listCurrentVaults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listCurrentVaults.TabIndex = 2;
            this.listCurrentVaults.UseCompatibleStateImageBehavior = false;
            this.listCurrentVaults.View = System.Windows.Forms.View.Details;
            this.listCurrentVaults.SelectedIndexChanged += new System.EventHandler(this.listCurrentVaults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vault Name";
            this.columnHeader1.Width = 265;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 86;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Creation Date";
            this.columnHeader5.Width = 130;
            // 
            // moreInfoButton
            // 
            this.moreInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.moreInfoButton.FlatAppearance.BorderSize = 0;
            this.moreInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreInfoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoButton.ForeColor = System.Drawing.Color.White;
            this.moreInfoButton.Location = new System.Drawing.Point(19, 490);
            this.moreInfoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moreInfoButton.Name = "moreInfoButton";
            this.moreInfoButton.Size = new System.Drawing.Size(163, 37);
            this.moreInfoButton.TabIndex = 16;
            this.moreInfoButton.Text = "Description";
            this.moreInfoButton.UseVisualStyleBackColor = false;
            this.moreInfoButton.Click += new System.EventHandler(this.moreInfoButton_Click);
            // 
            // prgLabel
            // 
            this.prgLabel.AutoSize = true;
            this.prgLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgLabel.Location = new System.Drawing.Point(261, 580);
            this.prgLabel.Name = "prgLabel";
            this.prgLabel.Size = new System.Drawing.Size(84, 20);
            this.prgLabel.TabIndex = 12;
            this.prgLabel.Text = "Operation";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 704);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // connectivityLabel
            // 
            this.connectivityLabel.AutoSize = true;
            this.connectivityLabel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectivityLabel.ForeColor = System.Drawing.Color.Red;
            this.connectivityLabel.Location = new System.Drawing.Point(34, 13);
            this.connectivityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.connectivityLabel.Name = "connectivityLabel";
            this.connectivityLabel.Size = new System.Drawing.Size(124, 20);
            this.connectivityLabel.TabIndex = 22;
            this.connectivityLabel.Text = "Not Connected";
            this.connectivityLabel.Visible = false;
            // 
            // localizationOptions
            // 
            this.localizationOptions.BackColor = System.Drawing.SystemColors.Window;
            this.localizationOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localizationOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.localizationOptions.FormattingEnabled = true;
            this.localizationOptions.Location = new System.Drawing.Point(476, 14);
            this.localizationOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.localizationOptions.Name = "localizationOptions";
            this.localizationOptions.Size = new System.Drawing.Size(127, 24);
            this.localizationOptions.TabIndex = 23;
            this.localizationOptions.SelectedIndexChanged += new System.EventHandler(this.localizationOptions_SelectedIndexChanged);
            // 
            // localeLabel
            // 
            this.localeLabel.AutoSize = true;
            this.localeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localeLabel.Location = new System.Drawing.Point(6, 17);
            this.localeLabel.Name = "localeLabel";
            this.localeLabel.Size = new System.Drawing.Size(51, 17);
            this.localeLabel.TabIndex = 24;
            this.localeLabel.Text = "Locale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.localizationOptions);
            this.groupBox1.Controls.Add(this.localeLabel);
            this.groupBox1.Location = new System.Drawing.Point(265, 637);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 46);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Locale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Change:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connectivityLabel);
            this.groupBox2.Location = new System.Drawing.Point(684, 572);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 46);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.vaultAppManagerButton);
            this.groupBox4.Controls.Add(this.removeVaultButton);
            this.groupBox4.Controls.Add(this.moreInfoButton);
            this.groupBox4.Controls.Add(this.listCurrentVaults);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(265, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(615, 541);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Currently Installed Local Vaults";
            // 
            // vaultAppManagerButton
            // 
            this.vaultAppManagerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.vaultAppManagerButton.FlatAppearance.BorderSize = 0;
            this.vaultAppManagerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vaultAppManagerButton.ForeColor = System.Drawing.Color.White;
            this.vaultAppManagerButton.Location = new System.Drawing.Point(230, 490);
            this.vaultAppManagerButton.Name = "vaultAppManagerButton";
            this.vaultAppManagerButton.Size = new System.Drawing.Size(163, 37);
            this.vaultAppManagerButton.TabIndex = 29;
            this.vaultAppManagerButton.Text = "Applications";
            this.vaultAppManagerButton.UseVisualStyleBackColor = false;
            this.vaultAppManagerButton.Click += new System.EventHandler(this.vaultManagerButton_Click);
            // 
            // removeVaultButton
            // 
            this.removeVaultButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.removeVaultButton.FlatAppearance.BorderSize = 0;
            this.removeVaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeVaultButton.ForeColor = System.Drawing.Color.White;
            this.removeVaultButton.Location = new System.Drawing.Point(434, 491);
            this.removeVaultButton.Name = "removeVaultButton";
            this.removeVaultButton.Size = new System.Drawing.Size(163, 37);
            this.removeVaultButton.TabIndex = 17;
            this.removeVaultButton.Text = "Remove Vault";
            this.removeVaultButton.UseVisualStyleBackColor = false;
            this.removeVaultButton.Click += new System.EventHandler(this.removeVaultButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(41, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Demo Vault Tool";
            // 
            // mFVersionText
            // 
            this.mFVersionText.AutoSize = true;
            this.mFVersionText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mFVersionText.ForeColor = System.Drawing.Color.White;
            this.mFVersionText.Location = new System.Drawing.Point(6, 208);
            this.mFVersionText.Name = "mFVersionText";
            this.mFVersionText.Size = new System.Drawing.Size(123, 20);
            this.mFVersionText.TabIndex = 29;
            this.mFVersionText.Text = "M-Files version: ";
            // 
            // mFVersion
            // 
            this.mFVersion.AutoSize = true;
            this.mFVersion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mFVersion.ForeColor = System.Drawing.Color.White;
            this.mFVersion.Location = new System.Drawing.Point(125, 208);
            this.mFVersion.Name = "mFVersion";
            this.mFVersion.Size = new System.Drawing.Size(53, 20);
            this.mFVersion.TabIndex = 30;
            this.mFVersion.Text = "label1";
            // 
            // serverLicText
            // 
            this.serverLicText.AutoSize = true;
            this.serverLicText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLicText.ForeColor = System.Drawing.Color.White;
            this.serverLicText.Location = new System.Drawing.Point(6, 230);
            this.serverLicText.Name = "serverLicText";
            this.serverLicText.Size = new System.Drawing.Size(165, 20);
            this.serverLicText.TabIndex = 31;
            this.serverLicText.Text = "Server License Status:";
            // 
            // serverLicStatus
            // 
            this.serverLicStatus.AutoSize = true;
            this.serverLicStatus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLicStatus.ForeColor = System.Drawing.Color.White;
            this.serverLicStatus.Location = new System.Drawing.Point(168, 230);
            this.serverLicStatus.Name = "serverLicStatus";
            this.serverLicStatus.Size = new System.Drawing.Size(53, 20);
            this.serverLicStatus.TabIndex = 32;
            this.serverLicStatus.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.serverLicStatus);
            this.panel1.Controls.Add(this.winUpdateButton);
            this.panel1.Controls.Add(this.updateLicenseButton);
            this.panel1.Controls.Add(this.serverLicText);
            this.panel1.Controls.Add(this.mFVersion);
            this.panel1.Controls.Add(this.enableDisableButton);
            this.panel1.Controls.Add(this.mFVersionText);
            this.panel1.Controls.Add(this.restoreFromBackUpButton);
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.connectionsButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 703);
            this.panel1.TabIndex = 19;
            // 
            // winUpdateButton
            // 
            this.winUpdateButton.BackColor = System.Drawing.Color.DarkBlue;
            this.winUpdateButton.Enabled = false;
            this.winUpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.winUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winUpdateButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winUpdateButton.ForeColor = System.Drawing.Color.White;
            this.winUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("winUpdateButton.Image")));
            this.winUpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.winUpdateButton.Location = new System.Drawing.Point(0, 516);
            this.winUpdateButton.Margin = new System.Windows.Forms.Padding(0);
            this.winUpdateButton.Name = "winUpdateButton";
            this.winUpdateButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.winUpdateButton.Size = new System.Drawing.Size(238, 62);
            this.winUpdateButton.TabIndex = 28;
            this.winUpdateButton.Text = "   Windows Updates\r\nAvailable ( )";
            this.winUpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.winUpdateButton.UseVisualStyleBackColor = false;
            this.winUpdateButton.Click += new System.EventHandler(this.winUpdateButton_Click);
            // 
            // updateLicenseButton
            // 
            this.updateLicenseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.updateLicenseButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.updateLicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateLicenseButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateLicenseButton.ForeColor = System.Drawing.Color.White;
            this.updateLicenseButton.Image = ((System.Drawing.Image)(resources.GetObject("updateLicenseButton.Image")));
            this.updateLicenseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateLicenseButton.Location = new System.Drawing.Point(0, 454);
            this.updateLicenseButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.updateLicenseButton.Name = "updateLicenseButton";
            this.updateLicenseButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.updateLicenseButton.Size = new System.Drawing.Size(238, 62);
            this.updateLicenseButton.TabIndex = 29;
            this.updateLicenseButton.Text = "Server License";
            this.updateLicenseButton.UseVisualStyleBackColor = false;
            this.updateLicenseButton.Click += new System.EventHandler(this.updateLicenseButton_Click_1);
            // 
            // enableDisableButton
            // 
            this.enableDisableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.enableDisableButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.enableDisableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableDisableButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDisableButton.ForeColor = System.Drawing.Color.White;
            this.enableDisableButton.Image = global::DemoEnvironmentVaultTool.Properties.Resources.external_repository_png40;
            this.enableDisableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enableDisableButton.Location = new System.Drawing.Point(0, 392);
            this.enableDisableButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.enableDisableButton.Name = "enableDisableButton";
            this.enableDisableButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.enableDisableButton.Size = new System.Drawing.Size(238, 62);
            this.enableDisableButton.TabIndex = 28;
            this.enableDisableButton.Text = " Vault Library";
            this.enableDisableButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.enableDisableButton.UseVisualStyleBackColor = false;
            this.enableDisableButton.Click += new System.EventHandler(this.enableDisableButton_Click);
            // 
            // restoreFromBackUpButton
            // 
            this.restoreFromBackUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.restoreFromBackUpButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.restoreFromBackUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreFromBackUpButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreFromBackUpButton.ForeColor = System.Drawing.Color.White;
            this.restoreFromBackUpButton.Image = ((System.Drawing.Image)(resources.GetObject("restoreFromBackUpButton.Image")));
            this.restoreFromBackUpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restoreFromBackUpButton.Location = new System.Drawing.Point(0, 330);
            this.restoreFromBackUpButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.restoreFromBackUpButton.Name = "restoreFromBackUpButton";
            this.restoreFromBackUpButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.restoreFromBackUpButton.Size = new System.Drawing.Size(238, 62);
            this.restoreFromBackUpButton.TabIndex = 28;
            this.restoreFromBackUpButton.Text = " Backup && Copy";
            this.restoreFromBackUpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restoreFromBackUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.restoreFromBackUpButton.UseVisualStyleBackColor = false;
            this.restoreFromBackUpButton.Click += new System.EventHandler(this.restoreFromBackUpButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(120, 640);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(118, 62);
            this.refreshButton.TabIndex = 28;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // connectionsButton
            // 
            this.connectionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.connectionsButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.connectionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionsButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionsButton.ForeColor = System.Drawing.Color.White;
            this.connectionsButton.Image = ((System.Drawing.Image)(resources.GetObject("connectionsButton.Image")));
            this.connectionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionsButton.Location = new System.Drawing.Point(0, 268);
            this.connectionsButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.connectionsButton.Name = "connectionsButton";
            this.connectionsButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.connectionsButton.Size = new System.Drawing.Size(238, 62);
            this.connectionsButton.TabIndex = 28;
            this.connectionsButton.Text = "       Connections";
            this.connectionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionsButton.UseVisualStyleBackColor = false;
            this.connectionsButton.Click += new System.EventHandler(this.connectionsButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(74, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(97, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(74, 104);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(0, 640);
            this.closeButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.closeButton.Size = new System.Drawing.Size(120, 62);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // UpdateMFilesButton
            // 
            this.UpdateMFilesButton.BackColor = System.Drawing.Color.DarkBlue;
            this.UpdateMFilesButton.Enabled = false;
            this.UpdateMFilesButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.UpdateMFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateMFilesButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateMFilesButton.ForeColor = System.Drawing.Color.White;
            this.UpdateMFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateMFilesButton.Image")));
            this.UpdateMFilesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateMFilesButton.Location = new System.Drawing.Point(-1, 578);
            this.UpdateMFilesButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.UpdateMFilesButton.Name = "UpdateMFilesButton";
            this.UpdateMFilesButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.UpdateMFilesButton.Size = new System.Drawing.Size(238, 62);
            this.UpdateMFilesButton.TabIndex = 28;
            this.UpdateMFilesButton.Text = "        Update Available";
            this.UpdateMFilesButton.UseVisualStyleBackColor = false;
            this.UpdateMFilesButton.Click += new System.EventHandler(this.UpdateMFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(894, 726);
            this.Controls.Add(this.UpdateMFilesButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.prgLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Demo Vault Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listCurrentVaults;
        private System.Windows.Forms.Button restoreFromBackUpButton;
        private System.Windows.Forms.FolderBrowserDialog backUpDialog;
        private System.Windows.Forms.FolderBrowserDialog availableVaultsDialog;
        private System.Windows.Forms.Button enableDisableButton;
        private System.Windows.Forms.Button moreInfoButton;
        private System.Windows.Forms.Label prgLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label connectivityLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox localizationOptions;
        private System.Windows.Forms.Label localeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button removeVaultButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button UpdateMFilesButton;
        private System.Windows.Forms.Button winUpdateButton;
        private System.Windows.Forms.Button updateLicenseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label mFVersionText;
        private System.Windows.Forms.Label mFVersion;
        private System.Windows.Forms.Label serverLicText;
        private System.Windows.Forms.Label serverLicStatus;
        private System.Windows.Forms.Button connectionsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button vaultAppManagerButton;
    }
}

