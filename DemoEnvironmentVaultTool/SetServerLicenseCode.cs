using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFilesAPI;

namespace DemoEnvironmentVaultTool
{
    public partial class SetServerLicenseCode : Form
    {   
        public SetServerLicenseCode()
        {

            InitializeComponent();
            this.MinimumSize = new Size(600, 510);
            this.MaximumSize = new Size(600, 510);
            FillSerialNumber();
            
        }

        private void FillSerialNumber()
        {
            MFilesOperations mFilesOperations = new MFilesOperations();
            LicenseStatus licenseStatus = mFilesOperations.GetServerLicenseStatus();
            serialCode.Text = licenseStatus.SerialNumber;
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (licenseCode.Text.Length != 0)
            {
                MFilesOperations mFilesOperations = new MFilesOperations();
                if (!mFilesOperations.SetServerLicense(serialCode.Text, licenseCode.Text))
                    MessageBox.Show(Constants.licenseCodeError);
                else
                {
                    MessageBox.Show(Constants.licenseCodeSuccess);
                    Form1 mainForm = new Form1();
                    mainForm.UpdateServerVersionAndLic();
                }
            }
            else
            {
                MessageBox.Show(Constants.licenseCodeFieldEmptyError);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
