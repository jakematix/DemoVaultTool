using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public partial class RestoreFromSnapshot : Form
    {
        public RestoreFromSnapshot()
        {
            InitializeComponent();
            this.MinimumSize = new Size(582, 232);
            this.MaximumSize = new Size(582, 232);


        }

        private void RestoreFromSnapshot_Load(object sender, EventArgs e)
        {
            vaultName.Text = snapshotToolForm.snapShotName;
                      
        }

        public string RestoreVaultName { get; set; }
        public Boolean CreateVaultConnection { get; set; }

        private void createVaultXml_CheckedChanged(object sender, EventArgs e)
        {
            switch (createVaultXml.CheckState)
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
                this.RestoreVaultName = vaultName.Text;
            }
            else
            {
                MessageBox.Show(Constants.restoreVaultNameMissing);
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
    }


}
