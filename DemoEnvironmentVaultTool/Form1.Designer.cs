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
            this.takeBackUpButton = new System.Windows.Forms.Button();
            this.restoreFromBackUpButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.backUpDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.destroyBackUpButton = new System.Windows.Forms.Button();
            this.availableVaultsDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.enableDisableButton = new System.Windows.Forms.Button();
            this.moreInfoButton = new System.Windows.Forms.Button();
            this.prgLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateMFilesButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.winUpdateButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.connectivityLabel = new System.Windows.Forms.Label();
            this.localizationOptions = new System.Windows.Forms.ComboBox();
            this.localeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.removeVaultButton = new System.Windows.Forms.Button();
            this.connectionsButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.listCurrentVaults.Location = new System.Drawing.Point(19, 35);
            this.listCurrentVaults.Margin = new System.Windows.Forms.Padding(2);
            this.listCurrentVaults.MultiSelect = false;
            this.listCurrentVaults.Name = "listCurrentVaults";
            this.listCurrentVaults.Size = new System.Drawing.Size(490, 386);
            this.listCurrentVaults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listCurrentVaults.TabIndex = 2;
            this.listCurrentVaults.UseCompatibleStateImageBehavior = false;
            this.listCurrentVaults.View = System.Windows.Forms.View.Details;
            this.listCurrentVaults.SelectedIndexChanged += new System.EventHandler(this.listCurrentVaults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vault Name";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 76;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Creation Date";
            this.columnHeader5.Width = 110;
            // 
            // takeBackUpButton
            // 
            this.takeBackUpButton.Location = new System.Drawing.Point(0, 0);
            this.takeBackUpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.takeBackUpButton.Name = "takeBackUpButton";
            this.takeBackUpButton.Size = new System.Drawing.Size(87, 28);
            this.takeBackUpButton.TabIndex = 21;
            // 
            // restoreFromBackUpButton
            // 
            this.restoreFromBackUpButton.BackColor = System.Drawing.Color.SteelBlue;
            this.restoreFromBackUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreFromBackUpButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreFromBackUpButton.ForeColor = System.Drawing.Color.White;
            this.restoreFromBackUpButton.Image = ((System.Drawing.Image)(resources.GetObject("restoreFromBackUpButton.Image")));
            this.restoreFromBackUpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restoreFromBackUpButton.Location = new System.Drawing.Point(-1, 318);
            this.restoreFromBackUpButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.restoreFromBackUpButton.Name = "restoreFromBackUpButton";
            this.restoreFromBackUpButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.restoreFromBackUpButton.Size = new System.Drawing.Size(238, 62);
            this.restoreFromBackUpButton.TabIndex = 28;
            this.restoreFromBackUpButton.Text = " Backup && Copy";
            this.restoreFromBackUpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restoreFromBackUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.restoreFromBackUpButton.UseVisualStyleBackColor = true;
            this.restoreFromBackUpButton.Click += new System.EventHandler(this.restoreFromBackUpButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(0, 562);
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
            // destroyBackUpButton
            // 
            this.destroyBackUpButton.Location = new System.Drawing.Point(0, 0);
            this.destroyBackUpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.destroyBackUpButton.Name = "destroyBackUpButton";
            this.destroyBackUpButton.Size = new System.Drawing.Size(87, 28);
            this.destroyBackUpButton.TabIndex = 20;
            // 
            // enableDisableButton
            // 
            this.enableDisableButton.BackColor = System.Drawing.Color.SteelBlue;
            this.enableDisableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableDisableButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDisableButton.ForeColor = System.Drawing.Color.White;
            this.enableDisableButton.Image = ((System.Drawing.Image)(resources.GetObject("enableDisableButton.Image")));
            this.enableDisableButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enableDisableButton.Location = new System.Drawing.Point(-1, 379);
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
            // moreInfoButton
            // 
            this.moreInfoButton.BackColor = System.Drawing.Color.SteelBlue;
            this.moreInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreInfoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoButton.ForeColor = System.Drawing.Color.White;
            this.moreInfoButton.Location = new System.Drawing.Point(19, 440);
            this.moreInfoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moreInfoButton.Name = "moreInfoButton";
            this.moreInfoButton.Size = new System.Drawing.Size(163, 37);
            this.moreInfoButton.TabIndex = 16;
            this.moreInfoButton.Text = "More Info";
            this.moreInfoButton.UseVisualStyleBackColor = false;
            this.moreInfoButton.Click += new System.EventHandler(this.moreInfoButton_Click);
            // 
            // prgLabel
            // 
            this.prgLabel.AutoSize = true;
            this.prgLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgLabel.Location = new System.Drawing.Point(261, 526);
            this.prgLabel.Name = "prgLabel";
            this.prgLabel.Size = new System.Drawing.Size(69, 17);
            this.prgLabel.TabIndex = 12;
            this.prgLabel.Text = "Operation";
            this.prgLabel.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.connectionsButton);
            this.panel1.Controls.Add(this.UpdateMFilesButton);
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.winUpdateButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 624);
            this.panel1.TabIndex = 19;
            // 
            // UpdateMFilesButton
            // 
            this.UpdateMFilesButton.BackColor = System.Drawing.Color.DarkBlue;
            this.UpdateMFilesButton.Enabled = false;
            this.UpdateMFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateMFilesButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateMFilesButton.ForeColor = System.Drawing.Color.White;
            this.UpdateMFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateMFilesButton.Image")));
            this.UpdateMFilesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateMFilesButton.Location = new System.Drawing.Point(0, 501);
            this.UpdateMFilesButton.Margin = new System.Windows.Forms.Padding(12, 12, 3, 4);
            this.UpdateMFilesButton.Name = "UpdateMFilesButton";
            this.UpdateMFilesButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.UpdateMFilesButton.Size = new System.Drawing.Size(238, 62);
            this.UpdateMFilesButton.TabIndex = 28;
            this.UpdateMFilesButton.Text = "        Update Available";
            this.UpdateMFilesButton.UseVisualStyleBackColor = false;
            this.UpdateMFilesButton.Click += new System.EventHandler(this.UpdateMFiles_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.SteelBlue;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(119, 562);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(118, 62);
            this.refreshButton.TabIndex = 28;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // winUpdateButton
            // 
            this.winUpdateButton.BackColor = System.Drawing.Color.DarkBlue;
            this.winUpdateButton.Enabled = false;
            this.winUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winUpdateButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winUpdateButton.ForeColor = System.Drawing.Color.White;
            this.winUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("winUpdateButton.Image")));
            this.winUpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.winUpdateButton.Location = new System.Drawing.Point(0, 440);
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
            this.pictureBox1.Location = new System.Drawing.Point(74, 102);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
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
            this.localizationOptions.Location = new System.Drawing.Point(391, 14);
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
            this.groupBox1.Location = new System.Drawing.Point(265, 565);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 46);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Locale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Change:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connectivityLabel);
            this.groupBox2.Location = new System.Drawing.Point(597, 518);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 46);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.removeVaultButton);
            this.groupBox4.Controls.Add(this.moreInfoButton);
            this.groupBox4.Controls.Add(this.listCurrentVaults);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(265, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(526, 492);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Currently Installed Local Vaults";
            // 
            // removeVaultButton
            // 
            this.removeVaultButton.BackColor = System.Drawing.Color.SteelBlue;
            this.removeVaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeVaultButton.ForeColor = System.Drawing.Color.White;
            this.removeVaultButton.Location = new System.Drawing.Point(346, 440);
            this.removeVaultButton.Name = "removeVaultButton";
            this.removeVaultButton.Size = new System.Drawing.Size(163, 37);
            this.removeVaultButton.TabIndex = 17;
            this.removeVaultButton.Text = "Remove Vault";
            this.removeVaultButton.UseVisualStyleBackColor = false;
            this.removeVaultButton.Click += new System.EventHandler(this.removeVaultButton_Click);
            // 
            // connectionsButton
            // 
            this.connectionsButton.BackColor = System.Drawing.Color.SteelBlue;
            this.connectionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionsButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionsButton.ForeColor = System.Drawing.Color.White;
            this.connectionsButton.Image = ((System.Drawing.Image)(resources.GetObject("connectionsButton.Image")));
            this.connectionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionsButton.Location = new System.Drawing.Point(0, 257);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(806, 647);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.enableDisableButton);
            this.Controls.Add(this.restoreFromBackUpButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.prgLabel);
            this.Controls.Add(this.destroyBackUpButton);
            this.Controls.Add(this.takeBackUpButton);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Demo Vault Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listCurrentVaults;
        private System.Windows.Forms.Button takeBackUpButton;
        private System.Windows.Forms.Button restoreFromBackUpButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.FolderBrowserDialog backUpDialog;
        private System.Windows.Forms.Button destroyBackUpButton;
        private System.Windows.Forms.FolderBrowserDialog availableVaultsDialog;
        private System.Windows.Forms.Button enableDisableButton;
        private System.Windows.Forms.Button moreInfoButton;
        private System.Windows.Forms.Label prgLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button winUpdateButton;
        private System.Windows.Forms.Label connectivityLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox localizationOptions;
        private System.Windows.Forms.Label localeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button UpdateMFilesButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button removeVaultButton;
        private System.Windows.Forms.Button connectionsButton;
    }
}

