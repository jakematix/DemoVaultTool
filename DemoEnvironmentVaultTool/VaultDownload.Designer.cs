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
            this.addToDemoButton = new System.Windows.Forms.Button();
            this.moreInfoButton = new System.Windows.Forms.Button();
            this.prgLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.availableLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAvailableVaults
            // 
            this.listAvailableVaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vaultName,
            this.vaultVersion,
            this.creationDate});
            this.listAvailableVaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAvailableVaults.Location = new System.Drawing.Point(23, 41);
            this.listAvailableVaults.Name = "listAvailableVaults";
            this.listAvailableVaults.Size = new System.Drawing.Size(419, 343);
            this.listAvailableVaults.TabIndex = 0;
            this.listAvailableVaults.UseCompatibleStateImageBehavior = false;
            this.listAvailableVaults.View = System.Windows.Forms.View.Details;
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
            // addToDemoButton
            // 
            this.addToDemoButton.BackColor = System.Drawing.Color.SteelBlue;
            this.addToDemoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToDemoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToDemoButton.ForeColor = System.Drawing.Color.White;
            this.addToDemoButton.Location = new System.Drawing.Point(23, 403);
            this.addToDemoButton.Name = "addToDemoButton";
            this.addToDemoButton.Size = new System.Drawing.Size(163, 37);
            this.addToDemoButton.TabIndex = 1;
            this.addToDemoButton.Text = "Add to Demo";
            this.addToDemoButton.UseVisualStyleBackColor = false;
            this.addToDemoButton.Click += new System.EventHandler(this.addToDemoButton_Click);
            // 
            // moreInfoButton
            // 
            this.moreInfoButton.BackColor = System.Drawing.Color.SteelBlue;
            this.moreInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreInfoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoButton.ForeColor = System.Drawing.Color.White;
            this.moreInfoButton.Location = new System.Drawing.Point(279, 403);
            this.moreInfoButton.Name = "moreInfoButton";
            this.moreInfoButton.Size = new System.Drawing.Size(163, 37);
            this.moreInfoButton.TabIndex = 2;
            this.moreInfoButton.Text = "Description";
            this.moreInfoButton.UseVisualStyleBackColor = false;
            this.moreInfoButton.Click += new System.EventHandler(this.moreInfoButton_Click);
            // 
            // prgLabel
            // 
            this.prgLabel.AutoSize = true;
            this.prgLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgLabel.Location = new System.Drawing.Point(19, 459);
            this.prgLabel.Name = "prgLabel";
            this.prgLabel.Size = new System.Drawing.Size(74, 17);
            this.prgLabel.TabIndex = 3;
            this.prgLabel.Text = "Operation";
            this.prgLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(279, 491);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(163, 37);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
            // 
            // availableLabel
            // 
            this.availableLabel.AutoSize = true;
            this.availableLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableLabel.Location = new System.Drawing.Point(23, 13);
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(127, 20);
            this.availableLabel.TabIndex = 6;
            this.availableLabel.Text = "Available Vaults";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(463, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // VaultDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 560);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.availableLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.prgLabel);
            this.Controls.Add(this.moreInfoButton);
            this.Controls.Add(this.addToDemoButton);
            this.Controls.Add(this.listAvailableVaults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VaultDownload";
            this.Text = "Vault Library";
            this.Load += new System.EventHandler(this.VaultDownload_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}