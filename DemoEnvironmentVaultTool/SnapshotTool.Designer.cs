namespace DemoEnvironmentVaultTool
{
    partial class snapshotToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(snapshotToolForm));
            this.vaultsInServer_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.availableSnapshots_listView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.takeSnapshot_button = new System.Windows.Forms.Button();
            this.restore_button = new System.Windows.Forms.Button();
            this.destroy_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgLabel = new System.Windows.Forms.Label();
            this.copyVaultButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vaultsInServer_listView
            // 
            this.vaultsInServer_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vaultsInServer_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.vaultsInServer_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaultsInServer_listView.HideSelection = false;
            this.vaultsInServer_listView.Location = new System.Drawing.Point(26, 37);
            this.vaultsInServer_listView.MultiSelect = false;
            this.vaultsInServer_listView.Name = "vaultsInServer_listView";
            this.vaultsInServer_listView.Size = new System.Drawing.Size(341, 326);
            this.vaultsInServer_listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.vaultsInServer_listView.TabIndex = 0;
            this.vaultsInServer_listView.UseCompatibleStateImageBehavior = false;
            this.vaultsInServer_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vault Name";
            this.columnHeader1.Width = 218;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "GUID";
            this.columnHeader2.Width = 294;
            // 
            // availableSnapshots_listView
            // 
            this.availableSnapshots_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.availableSnapshots_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.availableSnapshots_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableSnapshots_listView.HideSelection = false;
            this.availableSnapshots_listView.Location = new System.Drawing.Point(16, 38);
            this.availableSnapshots_listView.Name = "availableSnapshots_listView";
            this.availableSnapshots_listView.Size = new System.Drawing.Size(341, 326);
            this.availableSnapshots_listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.availableSnapshots_listView.TabIndex = 2;
            this.availableSnapshots_listView.UseCompatibleStateImageBehavior = false;
            this.availableSnapshots_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Snapshot Name";
            this.columnHeader3.Width = 241;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 261;
            // 
            // takeSnapshot_button
            // 
            this.takeSnapshot_button.BackColor = System.Drawing.Color.SteelBlue;
            this.takeSnapshot_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.takeSnapshot_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeSnapshot_button.ForeColor = System.Drawing.Color.White;
            this.takeSnapshot_button.Location = new System.Drawing.Point(26, 383);
            this.takeSnapshot_button.Name = "takeSnapshot_button";
            this.takeSnapshot_button.Size = new System.Drawing.Size(163, 37);
            this.takeSnapshot_button.TabIndex = 4;
            this.takeSnapshot_button.Text = "Take Snapshot";
            this.takeSnapshot_button.UseVisualStyleBackColor = false;
            this.takeSnapshot_button.Click += new System.EventHandler(this.takeSnapshot_button_Click);
            // 
            // restore_button
            // 
            this.restore_button.BackColor = System.Drawing.Color.SteelBlue;
            this.restore_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restore_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restore_button.ForeColor = System.Drawing.Color.White;
            this.restore_button.Location = new System.Drawing.Point(16, 383);
            this.restore_button.Name = "restore_button";
            this.restore_button.Size = new System.Drawing.Size(163, 37);
            this.restore_button.TabIndex = 5;
            this.restore_button.Text = "Restore";
            this.restore_button.UseVisualStyleBackColor = false;
            this.restore_button.Click += new System.EventHandler(this.restore_button_Click);
            // 
            // destroy_button
            // 
            this.destroy_button.BackColor = System.Drawing.Color.SteelBlue;
            this.destroy_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destroy_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destroy_button.ForeColor = System.Drawing.Color.White;
            this.destroy_button.Location = new System.Drawing.Point(196, 383);
            this.destroy_button.Name = "destroy_button";
            this.destroy_button.Size = new System.Drawing.Size(163, 37);
            this.destroy_button.TabIndex = 6;
            this.destroy_button.Text = "Destroy";
            this.destroy_button.UseVisualStyleBackColor = false;
            this.destroy_button.Click += new System.EventHandler(this.destroy_button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(610, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // prgLabel
            // 
            this.prgLabel.AutoSize = true;
            this.prgLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgLabel.Location = new System.Drawing.Point(34, 474);
            this.prgLabel.Name = "prgLabel";
            this.prgLabel.Size = new System.Drawing.Size(44, 20);
            this.prgLabel.TabIndex = 9;
            this.prgLabel.Text = "oper";
            this.prgLabel.Visible = false;
            // 
            // copyVaultButton
            // 
            this.copyVaultButton.BackColor = System.Drawing.Color.SteelBlue;
            this.copyVaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyVaultButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyVaultButton.ForeColor = System.Drawing.Color.White;
            this.copyVaultButton.Location = new System.Drawing.Point(204, 383);
            this.copyVaultButton.Name = "copyVaultButton";
            this.copyVaultButton.Size = new System.Drawing.Size(163, 37);
            this.copyVaultButton.TabIndex = 10;
            this.copyVaultButton.Text = "Copy Vault";
            this.copyVaultButton.UseVisualStyleBackColor = false;
            this.copyVaultButton.Click += new System.EventHandler(this.copyVaultButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.destroy_button);
            this.groupBox1.Controls.Add(this.restore_button);
            this.groupBox1.Controls.Add(this.availableSnapshots_listView);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(414, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 440);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Snapshots";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.copyVaultButton);
            this.groupBox2.Controls.Add(this.takeSnapshot_button);
            this.groupBox2.Controls.Add(this.vaultsInServer_listView);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 440);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local Vaults";
            // 
            // snapshotToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 545);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.prgLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "snapshotToolForm";
            this.Text = "Demo Vault Tool - Backup & Copy";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView vaultsInServer_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView availableSnapshots_listView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button takeSnapshot_button;
        private System.Windows.Forms.Button restore_button;
        private System.Windows.Forms.Button destroy_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label prgLabel;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button copyVaultButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}