namespace DemoEnvironmentVaultTool
{
    partial class enableDisableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(enableDisableForm));
            this.availableVaults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enabledVaults = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enableButton = new System.Windows.Forms.Button();
            this.disableButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.progLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // availableVaults
            // 
            this.availableVaults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.availableVaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.availableVaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableVaults.Location = new System.Drawing.Point(18, 34);
            this.availableVaults.Name = "availableVaults";
            this.availableVaults.Size = new System.Drawing.Size(317, 279);
            this.availableVaults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.availableVaults.TabIndex = 0;
            this.availableVaults.UseCompatibleStateImageBehavior = false;
            this.availableVaults.View = System.Windows.Forms.View.Details;
            this.availableVaults.SelectedIndexChanged += new System.EventHandler(this.availableVaults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vault Name";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Location";
            this.columnHeader3.Width = 80;
            // 
            // enabledVaults
            // 
            this.enabledVaults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.enabledVaults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.enabledVaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enabledVaults.Location = new System.Drawing.Point(19, 34);
            this.enabledVaults.Name = "enabledVaults";
            this.enabledVaults.Size = new System.Drawing.Size(317, 279);
            this.enabledVaults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.enabledVaults.TabIndex = 2;
            this.enabledVaults.UseCompatibleStateImageBehavior = false;
            this.enabledVaults.View = System.Windows.Forms.View.Details;
            this.enabledVaults.SelectedIndexChanged += new System.EventHandler(this.enabledVaults_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Connection Name";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Location";
            this.columnHeader4.Width = 80;
            // 
            // enableButton
            // 
            this.enableButton.BackColor = System.Drawing.Color.SteelBlue;
            this.enableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableButton.ForeColor = System.Drawing.Color.White;
            this.enableButton.Location = new System.Drawing.Point(25, 381);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(216, 37);
            this.enableButton.TabIndex = 4;
            this.enableButton.Text = "Enable Vault Connection";
            this.enableButton.UseVisualStyleBackColor = false;
            this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
            // 
            // disableButton
            // 
            this.disableButton.BackColor = System.Drawing.Color.SteelBlue;
            this.disableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableButton.ForeColor = System.Drawing.Color.White;
            this.disableButton.Location = new System.Drawing.Point(497, 381);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(216, 37);
            this.disableButton.TabIndex = 5;
            this.disableButton.Text = "Disable Vault Connection";
            this.disableButton.UseVisualStyleBackColor = false;
            this.disableButton.Click += new System.EventHandler(this.disableButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(550, 435);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(163, 37);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // progLabel
            // 
            this.progLabel.AutoSize = true;
            this.progLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progLabel.Location = new System.Drawing.Point(22, 444);
            this.progLabel.Name = "progLabel";
            this.progLabel.Size = new System.Drawing.Size(41, 18);
            this.progLabel.TabIndex = 7;
            this.progLabel.Text = "Oper";
            this.progLabel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enabledVaults);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(377, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 335);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enabled Vault Connections";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.availableVaults);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 335);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Vault Connections";
            // 
            // enableDisableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 486);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.enableButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "enableDisableForm";
            this.Text = "Demo Vault Tool - Enable and  Disable Vault Connections";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView availableVaults;
        private System.Windows.Forms.ListView enabledVaults;
        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label progLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}