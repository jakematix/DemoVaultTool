using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public partial class VaultCopyParameters : Form
    {
        

        public VaultCopyParameters()
        {
     
            InitializeComponent();
            this.MinimumSize = new Size(582, 284);
            this.MaximumSize = new Size(582, 284);
            // CheckStructureOnly();

        }
 

        private void createVaultConnection_CheckedChanged(object sender, EventArgs e)
        {
            switch (createVaultConnection.CheckState)
            {
                case CheckState.Checked:
                    this.CreateVaultConnection = true;
                    break;
                case CheckState.Unchecked:
                    this.CreateVaultConnection = false;
                    break;
                case CheckState.Indeterminate:
                    this.CreateVaultConnection = false;
                    break;
            }
        }





        private void okButton_Click(object sender, EventArgs e)
        {
            if (vaultName.Text != String.Empty)
            {
                this.CopyVaultName = vaultName.Text;
            }
            else
            {
                MessageBox.Show(Constants.copyVaultNameMissing);
                return;
            }
            if (copyAllDataCheckbox.CheckState == CheckState.Unchecked && copyStructureOnlyCheckbox.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show(Constants.allDataOrStructureOnlyMissing);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CheckCreatVaultConnection(bool state)
        {
            this.CreateVaultConnection = state;
            createVaultConnection.Checked = state;
        }

        private void ClearAllDataAndStructureOnlyFlag()
        {
            this.CopyAllData = false;
            this.CopyOnlyStructure = false;
        }

        public Boolean CopyAllData { get; set; }
        public Boolean CopyOnlyStructure { get; set; }
        public Boolean CreateVaultConnection { get; set; }
        public string CopyVaultName { get; set; }

        private void copyAllDataCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (copyAllDataCheckbox.Checked == true)
            {
                createVaultConnection.Enabled = true;
                copyStructureOnlyCheckbox.Enabled = false;
                copyStructureOnlyCheckbox.Checked = false;
                this.CopyOnlyStructure = false;
                this.CopyAllData = true;
            }
            
            if (copyAllDataCheckbox.Checked == false)
            {
                createVaultConnection.Enabled = false;
                copyStructureOnlyCheckbox.Enabled = true;
                this.CopyOnlyStructure = false;
                this.CopyAllData = false;
            }
        }

        private void copyStructureOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (copyStructureOnlyCheckbox.Checked == true)
            {
                createVaultConnection.Enabled = false;
                createVaultConnection.Checked = false;
                copyAllDataCheckbox.Checked = false;
                copyAllDataCheckbox.Enabled = false;
                this.CopyOnlyStructure = true;
                this.CopyAllData = false;
            }
            
            if (copyStructureOnlyCheckbox.Checked == false)
            {
                createVaultConnection.Enabled = false;
                copyAllDataCheckbox.Enabled = true;
                this.CopyOnlyStructure = false;
                this.CopyAllData = false;
            }
            

        }
    }


    
}
