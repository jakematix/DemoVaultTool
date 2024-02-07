namespace DemoEnvironmentVaultTool
{
    partial class VaultDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultDownload));
            this.listAvailableVaults = new System.Windows.Forms.ListView();
            this.vaultName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vaultVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.creationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mFilesVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addToDemoButton = new System.Windows.Forms.Button();
            this.moreInfoButton = new System.Windows.Forms.Button();
            this.prgLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.availableLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mFVersionLabel = new System.Windows.Forms.Label();
            this.mFVersionInfo = new System.Windows.Forms.Label();
            this.availableConnectionsView = new System.Windows.Forms.ListView();
            this.connectionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectionCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.availableConnectionsLabel = new System.Windows.Forms.Label();
            this.addConnectionButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAvailableVaults
            // 
            this.listAvailableVaults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAvailableVaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vaultName,
            this.vaultVersion,
            this.creationDate,
            this.mFilesVersion});
            this.listAvailableVaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAvailableVaults.HideSelection = false;
            this.listAvailableVaults.Location = new System.Drawing.Point(258, 39);
            this.listAvailableVaults.Name = "listAvailableVaults";
            this.listAvailableVaults.Size = new System.Drawing.Size(556, 343);
            this.listAvailableVaults.TabIndex = 0;
            this.listAvailableVaults.UseCompatibleStateImageBehavior = false;
            this.listAvailableVaults.View = System.Windows.Forms.View.Details;
            this.listAvailableVaults.SelectedIndexChanged += new System.EventHandler(this.listAvailableVaults_SelectedIndexChanged);
            // 
            // vaultName
            // 
            this.vaultName.Text = "Vault Name";
            this.vaultName.Width = 220;
            // 
            // vaultVersion
            // 
            this.vaultVersion.Text = "Version";
            this.vaultVersion.Width = 67;
            // 
            // creationDate
            // 
            this.creationDate.Text = "Creation Date";
            this.creationDate.Width = 110;
            // 
            // mFilesVersion
            // 
            this.mFilesVersion.Text = "M-Files Version";
            this.mFilesVersion.Width = 137;
            // 
            // addToDemoButton
            // 
            this.addToDemoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.addToDemoButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.addToDemoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.addToDemoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToDemoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToDemoButton.ForeColor = System.Drawing.Color.White;
            this.addToDemoButton.Location = new System.Drawing.Point(3, 3);
            this.addToDemoButton.Name = "addToDemoButton";
            this.addToDemoButton.Size = new System.Drawing.Size(238, 37);
            this.addToDemoButton.TabIndex = 1;
            this.addToDemoButton.Text = "Add Vault";
            this.addToDemoButton.UseVisualStyleBackColor = false;
            this.addToDemoButton.Click += new System.EventHandler(this.addToDemoButton_Click);
            // 
            // moreInfoButton
            // 
            this.moreInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.moreInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.moreInfoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.moreInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreInfoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoButton.ForeColor = System.Drawing.Color.White;
            this.moreInfoButton.Location = new System.Drawing.Point(3, 46);
            this.moreInfoButton.Name = "moreInfoButton";
            this.moreInfoButton.Size = new System.Drawing.Size(238, 37);
            this.moreInfoButton.TabIndex = 2;
            this.moreInfoButton.Text = "Vault Description";
            this.moreInfoButton.UseVisualStyleBackColor = false;
            this.moreInfoButton.Click += new System.EventHandler(this.moreInfoButton_Click);
            // 
            // prgLabel
            // 
            this.prgLabel.AutoSize = true;
            this.prgLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgLabel.Location = new System.Drawing.Point(255, 638);
            this.prgLabel.Name = "prgLabel";
            this.prgLabel.Size = new System.Drawing.Size(84, 20);
            this.prgLabel.TabIndex = 3;
            this.prgLabel.Text = "Operation";
            this.prgLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(3, 66);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(238, 37);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
            // 
            // availableLabel
            // 
            this.availableLabel.AutoSize = true;
            this.availableLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableLabel.Location = new System.Drawing.Point(254, 9);
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(127, 20);
            this.availableLabel.TabIndex = 6;
            this.availableLabel.Text = "Available Vaults";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(826, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // mFVersionLabel
            // 
            this.mFVersionLabel.AutoSize = true;
            this.mFVersionLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mFVersionLabel.Location = new System.Drawing.Point(254, 679);
            this.mFVersionLabel.Name = "mFVersionLabel";
            this.mFVersionLabel.Size = new System.Drawing.Size(119, 20);
            this.mFVersionLabel.TabIndex = 8;
            this.mFVersionLabel.Text = "M-Files version:";
            // 
            // mFVersionInfo
            // 
            this.mFVersionInfo.AutoSize = true;
            this.mFVersionInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mFVersionInfo.Location = new System.Drawing.Point(379, 679);
            this.mFVersionInfo.Name = "mFVersionInfo";
            this.mFVersionInfo.Size = new System.Drawing.Size(53, 20);
            this.mFVersionInfo.TabIndex = 9;
            this.mFVersionInfo.Text = "label1";
            this.mFVersionInfo.Visible = false;
            // 
            // availableConnectionsView
            // 
            this.availableConnectionsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.availableConnectionsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.connectionName,
            this.connectionCreationDate});
            this.availableConnectionsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableConnectionsView.HideSelection = false;
            this.availableConnectionsView.Location = new System.Drawing.Point(258, 447);
            this.availableConnectionsView.Name = "availableConnectionsView";
            this.availableConnectionsView.Size = new System.Drawing.Size(556, 169);
            this.availableConnectionsView.TabIndex = 0;
            this.availableConnectionsView.UseCompatibleStateImageBehavior = false;
            this.availableConnectionsView.View = System.Windows.Forms.View.Details;
            // 
            // connectionName
            // 
            this.connectionName.Text = "Connection Name";
            this.connectionName.Width = 300;
            // 
            // connectionCreationDate
            // 
            this.connectionCreationDate.Text = "Creation Date";
            this.connectionCreationDate.Width = 236;
            // 
            // availableConnectionsLabel
            // 
            this.availableConnectionsLabel.AutoSize = true;
            this.availableConnectionsLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableConnectionsLabel.Location = new System.Drawing.Point(254, 414);
            this.availableConnectionsLabel.Name = "availableConnectionsLabel";
            this.availableConnectionsLabel.Size = new System.Drawing.Size(266, 20);
            this.availableConnectionsLabel.TabIndex = 11;
            this.availableConnectionsLabel.Text = "Available Cloud Vault Connections";
            // 
            // addConnectionButton
            // 
            this.addConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.addConnectionButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.addConnectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.addConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addConnectionButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addConnectionButton.ForeColor = System.Drawing.Color.White;
            this.addConnectionButton.Location = new System.Drawing.Point(3, 3);
            this.addConnectionButton.Name = "addConnectionButton";
            this.addConnectionButton.Size = new System.Drawing.Size(238, 37);
            this.addConnectionButton.TabIndex = 12;
            this.addConnectionButton.Text = "Add Connection";
            this.addConnectionButton.UseVisualStyleBackColor = false;
            this.addConnectionButton.Click += new System.EventHandler(this.addConnectionButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.flowLayoutPanel1.Controls.Add(this.addToDemoButton);
            this.flowLayoutPanel1.Controls.Add(this.moreInfoButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 226);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 106);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 229);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vault Library";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DemoEnvironmentVaultTool.Properties.Resources.external_repository_s0;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(59, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.panel2.Location = new System.Drawing.Point(0, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 120);
            this.panel2.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.flowLayoutPanel2.Controls.Add(this.addConnectionButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 447);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(238, 169);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(140)))), ((int)(((byte)(204)))));
            this.panel3.Controls.Add(this.closeButton);
            this.panel3.Location = new System.Drawing.Point(0, 613);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 104);
            this.panel3.TabIndex = 17;
            // 
            // VaultDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 740);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.availableConnectionsLabel);
            this.Controls.Add(this.availableConnectionsView);
            this.Controls.Add(this.mFVersionInfo);
            this.Controls.Add(this.mFVersionLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.availableLabel);
            this.Controls.Add(this.prgLabel);
            this.Controls.Add(this.listAvailableVaults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VaultDownload";
            this.Text = "Vault Library";
            this.Load += new System.EventHandler(this.VaultDownload_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listAvailableVaults;
        private System.Windows.Forms.Button addToDemoButton;
        private System.Windows.Forms.ColumnHeader vaultName;
        private System.Windows.Forms.ColumnHeader vaultVersion;
        private System.Windows.Forms.ColumnHeader creationDate;
        private System.Windows.Forms.Button moreInfoButton;
        private System.Windows.Forms.Label prgLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label availableLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ColumnHeader mFilesVersion;
        private System.Windows.Forms.Label mFVersionLabel;
        private System.Windows.Forms.Label mFVersionInfo;
        private System.Windows.Forms.ListView availableConnectionsView;
        private System.Windows.Forms.Label availableConnectionsLabel;
        private System.Windows.Forms.ColumnHeader connectionName;
        private System.Windows.Forms.ColumnHeader connectionCreationDate;
        private System.Windows.Forms.Button addConnectionButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}