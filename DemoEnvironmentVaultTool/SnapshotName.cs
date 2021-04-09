using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DemoEnvironmentVaultTool
{
    public partial class SnapshotName : Form
    {
        public SnapshotName()
        {
            InitializeComponent();
            this.MinimumSize = new Size(582, 188);
            this.MaximumSize = new Size(582, 188);
        }
        public string NameOfSnapshot { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            string fullSnapshotDirectoryName = String.Empty;
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (nameOfTheSnapshot.Text != String.Empty)
            {
                fullSnapshotDirectoryName = nameOfTheSnapshot.Text;
                fullSnapshotDirectoryName = directory + Constants.basePath + fullSnapshotDirectoryName;
                if (!Directory.Exists(fullSnapshotDirectoryName))
                    Directory.CreateDirectory(fullSnapshotDirectoryName);
                else
                {
                    MessageBox.Show(Constants.snapshotAlreadyExistMessage);
                    nameOfTheSnapshot.Clear();
                    return;
                }
                // this.NameOfSnapshot = nameOfTheSnapshot.Text;
            }
            else
            {
                MessageBox.Show(Constants.snapshotNameMissing);
                return;
            }
            this.NameOfSnapshot = fullSnapshotDirectoryName;
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
