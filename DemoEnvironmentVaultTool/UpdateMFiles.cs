using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using MFilesAPI;

namespace DemoEnvironmentVaultTool
{
    public partial class UpdateMFiles : Form
    {
        public UpdateMFiles()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.MinimumSize = new Size(429, 273);
            this.MaximumSize = new Size(429, 273);

            // Initialize Background worker
            mFilesDownloadWorker.DoWork += new DoWorkEventHandler(mFilesDownloadWorker_DoWork);
            mFilesDownloadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mFilesDownloadWorker_RunWorkerCompleted);
            mFilesDownloadWorker.ProgressChanged += new ProgressChangedEventHandler(mFilesDownloadWorker_ProgressChanged);
            mFilesDownloadWorker.WorkerReportsProgress = true;
            LocalFileOperations localFileOperations = new LocalFileOperations();

            localFileOperations.ClearUpdateTempPath();
            /*
            if (Directory.Exists(Constants.updateTempPath))
                Directory.Delete(Constants.updateTempPath, true);
            */

            mFVersionLabel.Visible = false;
            updVersionLabel.Visible = false;

            UpdateCurrentMFVersionLabel();
            AzureOperations azureOperations = new AzureOperations();
            if (azureOperations.ConnectToAzureFiles())
            {
                UpdateMFVersionView();
            }
            else
                MessageBox.Show("Something went wrong when trying t to Azure File Share!");

        }

        private BackgroundWorker mFilesDownloadWorker = new BackgroundWorker();

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static MFilesServerApplication GetMFServerConnection()
        {
            MFilesServerApplication serverConnection = new MFilesServerApplication();
            serverConnection.ConnectAdministrativeEx(null,
                                                     MFAuthType.MFAuthTypeSpecificMFilesUser,
                                                     Constants.userName, Constants.passWord, "", "",
                                                     Constants.protocolSequence, Constants.server,
                                                     Constants.endPoint, false, "");
            return serverConnection;
        }
        private void UpdateMFVersionView()
        {
            try
            {
                AzureOperations azureOperations = new AzureOperations();
                string installerDir = azureOperations.GetMFilesInstallerDirectoryInAzure();
                updVersionLabel.Text = installerDir;
                updVersionLabel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void UpdateCurrentMFVersionLabel()
        {
            MFilesOperations mFilesOperations = new MFilesOperations();
            mFVersionLabel.Text = mFilesOperations.GetMFServerVersion();
            mFVersionLabel.Visible = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            // MessageBox.Show("M-Files will be updated. Please wait until the operation is completed.");

            UserMessages msg = new UserMessages();
            try
            {
                if (!mFilesDownloadWorker.IsBusy)
                {
                    msg.ShowDownloadInstallerMessage(true, progressLabel);
                    ButtonsEnabled(false);
                    mFilesDownloadWorker.RunWorkerAsync(updVersionLabel.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void mFilesDownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            string installerName = String.Empty;
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            Directory.CreateDirectory(Constants.updateTempPath);
            // Installer (msi-package) is downloaded in blocks (size defined in segmentSize variable) to inform download progress
            string msiDirectoryName = e.Argument.ToString(); // directory name in Azure File Share (\MFilesInstallers\19.5.7772.0)
                                                              
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference(Constants.azureShareReference);
                                 
            CloudFileDirectory rootDir = share.GetRootDirectoryReference(); // Root directory of the file share
            CloudFileDirectory installersDir = rootDir.GetDirectoryReference(Constants.mFilesInstallerDirectoryNameInAzure);
            CloudFileDirectory installerDir = installersDir.GetDirectoryReference(msiDirectoryName); // Now we are finally in the directory where the installer is

            var azFiles = installerDir.ListFilesAndDirectories().OfType<CloudFile>();
            foreach (var azFile in azFiles)
            {
                installerName = azFile.Name; // There is only one file (M-Files installer file) in the directory. When it is found, let's go out from foreach
                break;
            }

           
           
            int segmentSize = 1 * 1024 * 1024; // size of the block
            long startPosition = 0;

            var installerFile = installerDir.GetFileReference(installerName);
            installerFile.FetchAttributes();
            var remainingAmount = installerFile.Properties.Length;
            string fullTempFileName = Constants.updateTempPath + installerName;
            do
            {
                long blockSize = Math.Min(segmentSize, remainingAmount);
                byte[] fileContents = new byte[blockSize];
                using (MemoryStream ms = new MemoryStream())
                {
                    installerFile.DownloadRangeToStream(ms, startPosition, blockSize);
                    ms.Position = 0;
                    ms.Read(fileContents, 0, fileContents.Length);
                    using (FileStream fs = new FileStream(fullTempFileName, FileMode.OpenOrCreate))
                    {
                        fs.Position = startPosition;
                        fs.Write(fileContents, 0, fileContents.Length);
                    }
                }
                startPosition += blockSize;
                remainingAmount -= blockSize;
                double downloaded = (100 * (double)startPosition / (double)installerFile.Properties.Length);
                int percentage = (int)downloaded;
                
                sendingWorker.ReportProgress(percentage);
            }
            while (remainingAmount > 0);
        }

        protected void mFilesDownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            if (e.Error == null)
            {
                msg.ShowInstallerDownloadCompleted(true, progressLabel);
                updateMFiles();
            }
            else
            {
                msg.ShowInstallerDownloadError(true, progressLabel);
                MessageBox.Show(e.Error.ToString());
            }
            ButtonsEnabled(true);
            msg.ClearAllMessages(progressLabel, lblStatus);
        }


        protected void mFilesDownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            msg.InstallerDownloadProgress(true, e.ProgressPercentage, lblStatus);
        }

        private void ButtonsEnabled(bool state)
        {
            updateButton.Enabled = state;
            closeButton.Enabled = state;
        }

        private void updateMFiles()
        {
            LocalFileOperations localFileOperations = new LocalFileOperations();
            progressLabel.Visible = false;
            Refresh();
            DirectoryInfo updTempDir = new DirectoryInfo(Constants.updateTempPath);
            FileInfo[] msiFiles = updTempDir.GetFiles().ToArray();
            string msiFile = msiFiles[0].FullName;
            string updateMessage = "Ready to update current M-Files to version " + updVersionLabel.Text + ".\r\nAre you ready to proceed?\r\nM-Files installer will be started. Please follow its update procedure.";
            DialogResult dialogResult = MessageBox.Show(updateMessage, "M-Files Update", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                string parameters = "/i " + msiFile;
                System.Diagnostics.Process.Start("msiexec", parameters);
                this.Close();
            }
            else
            {
                // Directory.Delete(Constants.updateTempPath, true);
                localFileOperations.ClearUpdateTempPath();
                MessageBox.Show("Operation cancelled!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
