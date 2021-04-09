using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage.File;
using MFilesAPI;


namespace DemoEnvironmentVaultTool
{
    public partial class VaultDownload : Form
    {
        Form1 mainForm;
        bool onlyConfFile = false; // flag is there is only vault configuration file in Azure (in case of cloud vault)


        public VaultDownload(Form1 incomingForm)
        {
            mainForm = incomingForm;
            InitializeComponent();

            
            restoreBackUpWorker.DoWork += new DoWorkEventHandler(restoreBackUpWorker_DoWork);
            restoreBackUpWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(restoreBackUpWorker_RunWorkerCompleted);
            restoreBackUpWorker.ProgressChanged += new ProgressChangedEventHandler(restoreBackUpWorker_ProgressChanged);
            restoreBackUpWorker.WorkerReportsProgress = true;
            restoreBackUpWorker.WorkerSupportsCancellation = true;
            

            vaultDownloadWorker.DoWork += new DoWorkEventHandler(vaultDownloadWorker_DoWork);
            vaultDownloadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vaultDownloadWorker_RunWorkerCompleted);
            vaultDownloadWorker.ProgressChanged += new ProgressChangedEventHandler(vaultDownloadWorker_ProgressChanged);
            vaultDownloadWorker.WorkerReportsProgress = true;

        }

        private BackgroundWorker restoreBackUpWorker = new BackgroundWorker();
        private BackgroundWorker vaultDownloadWorker = new BackgroundWorker();

        private void VaultDownload_Load(object sender, EventArgs e)
        {
            AzureOperations azureOperations = new AzureOperations();

            if (Connectivity.InternetConnectivity())
            {
                if (azureOperations.ConnectToAzureFiles())
                {
                    RefreshAvailableVaultsView();

                }
            }
        }

        private void RefreshAvailableVaultsView()
        {
            listAvailableVaults.Items.Clear();
            listAvailableVaults.MultiSelect = false;
            listAvailableVaults.FullRowSelect = true;
            listAvailableVaults.Columns[0].ListView.Font = new Font(listAvailableVaults.Columns[0].ListView.Font, FontStyle.Bold);

            AzureOperations azureOperations = new AzureOperations();
            CloudFileShare share = azureOperations.GetVaultFileShareInAzure();
            var directories = share.GetRootDirectoryReference()
                .GetDirectoryReference(Constants.vaultDirectoryNameInAzure)
                .ListFilesAndDirectories()
                .OfType<CloudFileDirectory>();

            foreach (var directory in directories)
            {
                RepositoryVault rVault = vaultExist(directory.Name);

                if (!rVault.vaultExistInEnv)
                {
                    ListViewItem lvi = new ListViewItem(directory.Name);
                    lvi.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    lvi.SubItems.Add(rVault.vaultVersion);
                    lvi.SubItems.Add(rVault.vaultDate);
                    lvi.SubItems.Add(rVault.vaultGUID); // This is NOT visible in the listing, but is needed in later phases
                    listAvailableVaults.Items.Add(lvi);
                }
            }

            listAvailableVaults.SelectedItems.Clear();
            return;
        }

        private struct RepositoryVault
        {
            public bool vaultExistInEnv;
            public string vaultVersion;
            public string vaultDate;
            public string vaultGUID;
            public bool takeSafetyBackup;
        }

        private RepositoryVault vaultExist(string vaultName) // Read the data from the vault in Vault Library (Repository) 
        {
            RepositoryVault vaultData;
            vaultData.vaultExistInEnv = false;
            vaultData.vaultDate = String.Empty;
            vaultData.vaultVersion = String.Empty;
            vaultData.vaultGUID = String.Empty;
            vaultData.takeSafetyBackup = false;

            string vaultVersion = String.Empty;

            AzureOperations azureOperations = new AzureOperations();

            CloudFileDirectory vaultDir = azureOperations.GetVaultDirectoryInAzure(vaultName);
            CloudFileDirectory configDir = vaultDir.GetDirectoryReference("Configs");

            // Copy first the configuration XML file to C:\Tools\Temp
            if (!Directory.Exists(Constants.tempPath))
            {
                Directory.CreateDirectory(Constants.tempPath);
            }

            string tempDestFile = Constants.tempPath + vaultName + ".xml"; // First XML is copied to C:\Tools\Temp 
            using (var destStream = File.OpenWrite(tempDestFile))
            {
                var sourceFile = configDir.GetFileReference(vaultName + ".xml");
                sourceFile.DownloadToStream(destStream);
            }

            // If the vault exist in demo environment, read its creation date from the config XML file (to existingVaultDate)  
            // and compare it to the creation date read from the downloaded XML file (repositoryVaultDate)

            // Read GUID of the vault from downloaded XML file. That is the value of GUID in the vault in repository
            // string tempXMLFile = Constants.tempPath + vaultName + ".xml";
            string vaultGUID = String.Empty;
            string repositoryVaultDate = String.Empty;
            string existingVaultDate = String.Empty;
            bool vaultExist = true;

            foreach (var element in XmlHelper.StreamConnections(tempDestFile))
            {
                vaultVersion = element.VaultVersion;
                vaultGUID = element.ServerVaultGUID;
                repositoryVaultDate = element.VaultDate;
                break;
            }

            // Delete downloaded XML file right away from C:\Tools\Temp, but check if exist first
            if (File.Exists(tempDestFile))
            {
                File.Delete(tempDestFile);
            }
            string vName = vaultFound(vaultGUID);
            if (vName != null)
            {

                // If GUID is found => there is vault already => we need to compare dates
                // Read date of the existing vault to exVaultDate string

                string envDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string confFile = envDirectory + Constants.xmlVaultConfPath + vaultName + "_" + vaultGUID + ".xml";
                foreach (var element in XmlHelper.StreamConnections(confFile))
                {
                    existingVaultDate = element.VaultDate;
                    break;
                }
                // convert date strings to DateTime
                DateTime rVaultDate = DateTime.Parse(repositoryVaultDate);
                DateTime eVaultDate = DateTime.Parse(existingVaultDate);

                if (eVaultDate.Date < rVaultDate.Date) // existing vault is older than the one in the repo
                                                       // => 
                                                       // existing vault is destroyed and new can be downloaded 
                {
                    vaultExist = false;

                }
                else
                {
                    vaultExist = true; // Existing vault is newer than the one in the repo.
                }
            }
            else
            {
                // There was not earlier vault with the same GUID => new vault in the repo => ok to download
                vaultExist = false;
            }
            vaultData.vaultExistInEnv = vaultExist;
            vaultData.vaultVersion = vaultVersion;
            vaultData.vaultDate = repositoryVaultDate;
            vaultData.vaultGUID = vaultGUID;

            return vaultData;
        }

        private string vaultFound(string guid)
        {
            // Go thru all vaults in the Demo Environment and compare GUIDs
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            // MFilesAPI.MFilesServerApplication oMFServerApp = GetMFServerConnection();
            VaultsOnServer oVaults = oMFServerApp.GetVaults();
            foreach (VaultOnServer oOneVault in oVaults)
            {
                if (String.Equals(guid, oOneVault.GUID))
                {
                    return oOneVault.Name; // If GUID match, return name of the vault.
                }
            }
            return null;
        }

        private void addToDemoButton_Click(object sender, EventArgs e)
        {
            if (listAvailableVaults.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.selectVaultToBeDownloaded);
                return;
            }

            string vaultNameInRepo = listAvailableVaults.SelectedItems[0].Text;
            string vaultGUIDInRepo = listAvailableVaults.SelectedItems[0].SubItems[3].Text; // vault GUID is in hidden Subitems[3] location.
            DialogResult dialogResult;

            string installationMessage = String.Format(Constants.vaultInstallationNewMessage, vaultNameInRepo);
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;

            RepositoryVault rVault = vaultExist(vaultNameInRepo);

            if (!rVault.vaultExistInEnv)
            {
                MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
                VaultsOnServer oVaults = oMFServerApp.GetVaults();
                foreach (VaultOnServer oOneVault in oVaults)
                {
                    if (oOneVault.GUID == vaultGUIDInRepo)
                    {
                        installationMessage = String.Format(Constants.vaultInstallationReplaceMessage, vaultNameInRepo, oOneVault.GUID, oOneVault.Name);
                        messageBoxIcon = MessageBoxIcon.Warning;
                        break;
                    }
                }

                dialogResult = MessageBox.Show(installationMessage, Constants.vaultInstallationHeaderMessage, MessageBoxButtons.YesNo, messageBoxIcon);
                if (dialogResult == DialogResult.No)
                    return;
                else
                {
                    try
                    {
                        if (!vaultDownloadWorker.IsBusy)
                        {
                            ButtonsEnabled(false);
                            UserMessages msg = new UserMessages();
                            msg.ShowCopyingVaultMessage(true, prgLabel);
                            vaultDownloadWorker.RunWorkerAsync(vaultNameInRepo);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        protected void vaultDownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            if (!Directory.Exists(Constants.tempPath))
            {
                Directory.CreateDirectory(Constants.tempPath);
            }
            // Vault is downloaded in blocks (size defined in segmentSize variable) to inform download progress
            string vaultName = e.Argument.ToString();

            AzureOperations azureOperations = new AzureOperations();
            CloudFileDirectory vaultDir = azureOperations.GetVaultDirectoryInAzure(vaultName);

            int segmentSize = 1 * 1024 * 1024; // size of the block
            long startPosition = 0;

            string completeVaultName = vaultName + ".mfb";

            var vaultFile = vaultDir.GetFileReference(completeVaultName);
            if (!vaultFile.Exists())
                onlyConfFile = true;

            vaultFile.FetchAttributes();
            var remainingAmount = vaultFile.Properties.Length;
            string fullTempFileName = Constants.tempPath + completeVaultName;

            do
            {
                long blockSize = Math.Min(segmentSize, remainingAmount);
                byte[] fileContents = new byte[blockSize];
                using (MemoryStream ms = new MemoryStream())
                {
                    vaultFile.DownloadRangeToStream(ms, startPosition, blockSize);
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
                double downloaded = (100 * (double)startPosition / (double)vaultFile.Properties.Length);
                int percentage = (int)downloaded;
                sendingWorker.ReportProgress(percentage);
            }
            while (remainingAmount > 0);

            // Copy configuration XML-files


            CloudFileDirectory configDir = vaultDir.GetDirectoryReference("Configs");
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // In the Repository, the XML file is in format vaultName.xml. 
            // It is first downloaded to \Tools\Temp directory

            string tempXmlFile = Constants.tempPath + vaultName + ".xml";

            using (var destStream = File.OpenWrite(tempXmlFile))
            {
                var sourceFile = configDir.GetFileReference(vaultName + ".xml");
                sourceFile.DownloadToStream(destStream);
            }

            // In this phase we need to read the content of the downloaded vaultname.xml
            // to define what is the vault GUID. We read <VaultGUID> valiue from the XML
            // and rename vaultname.xml to vaultname_vaultGUID.xml.
            string vaultGUID = ReadVaultData(tempXmlFile, "guid");
            string conFileName = directory + Constants.xmlVaultConfPath + vaultName + "_" + vaultGUID + ".xml";
            // Copy vaultname.xml as vaultname_vaultGUID.xml to %appdata%\M-Files\Demo Vault Tool\VaultConf
            File.Copy(tempXmlFile, conFileName, true);
            File.Delete(tempXmlFile);
        }

        protected void vaultDownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UserMessages msg = new UserMessages();

            if(e.Error == null)
            {
                msg.ShowCopyingVaultMessage(false, prgLabel);
                msg.CopyVaultProgress(false, 0, lblStatus);

                // Restore vault back from the temp folder to M-Files
                // First put all MFB files to an array
                DirectoryInfo dirInfo = new DirectoryInfo(Constants.tempPath); // --> vaultDownloadWorked.completed
                FileInfo[] filesArr = dirInfo.GetFiles().ToArray(); // --> vaultDownloadWorker.completed
                                                                    // CopyVaultConfigs(fullRepositoryPath);
                                                                    // Files from the directory and restoration bool to the list to be send to the Background worker
                List<object> restoreArguments = new List<object>();
                restoreArguments.Add(false);
                restoreArguments.Add(filesArr);



                if (!restoreBackUpWorker.IsBusy)
                {
                    ButtonsEnabled(false);
                    msg.ShowRestoreVaultMessage(true, prgLabel);
                    // ShowRestoreVaultMessage(true);
                    restoreBackUpWorker.RunWorkerAsync(restoreArguments); // perform Restore operation in Backgroun process (own thread)
                }
            }
            else
            {
                msg.ShowErrorDuringOperation(true, prgLabel);
                MessageBox.Show(e.Error.ToString());
                msg.ShowErrorDuringOperation(false, prgLabel);
            }

            ButtonsEnabled(true);
            msg.ShowRestoreVaultMessage(false, prgLabel);
            mainForm.RefreshVaultView();
        }

        protected void vaultDownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            msg.CopyVaultProgress(true, e.ProgressPercentage, lblStatus);
        }

        protected void restoreBackUpWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            List<object> genericlist = e.Argument as List<object>;
            bool restoration = (bool)genericlist[0];
            FileInfo[] fileArr = (FileInfo[])genericlist[1];
            int fileCounter = 0;

            ButtonsEnabled(false);
            UserMessages msg = new UserMessages();
            msg.ShowRestoreVaultMessage(true, prgLabel);

            try
            {
                // Get M-Files Server App and login
                MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
                // MFilesAPI.MFilesServerApplication oMFServerApp = GetMFServerConnection();

                // Loop all the files and collect the names and GUIDs to a string and
                // vault properties to a list

                List<VaultPropertiesExt> listVaultProperties = new List<VaultPropertiesExt>();

                foreach (FileInfo f in fileArr)
                {
                    VaultProperties vaultProperties;
                    vaultProperties = oMFServerApp.VaultManagementOperations.GetBackupFileContents(f.FullName, "");
                    // restoreMessage = restoreMessage + vaultProperties.DisplayName + " (" + vaultProperties.VaultGUID + ")\r\n";

                    // Store to the List
                    VaultPropertiesExt sVaultPropertiesExt;
                    sVaultPropertiesExt.vaultProperties = vaultProperties;
                    sVaultPropertiesExt.fullPath = f.FullName;
                    listVaultProperties.Add(sVaultPropertiesExt);
                }

                // Loop the backups and restore them                   
                foreach (VaultPropertiesExt sOneVaultPropExt in listVaultProperties)
                {
                    string backupPath = sOneVaultPropExt.fullPath;
                    string vaultName = sOneVaultPropExt.vaultProperties.DisplayName;
                    string vaultGUID = sOneVaultPropExt.vaultProperties.VaultGUID;
                    bool isFirebirdEngine = true;
                    int vaultExistence = oMFServerApp.GetVaults().GetVaultIndexByGUID(vaultGUID);

                    if (restoration)
                    {
                        if (vaultExistence != -1)
                        {
                            // Vault exist
                            // Check type of the engine
                            if (oMFServerApp.VaultManagementOperations.GetVaultProperties(vaultGUID).SQLDatabase.Engine != MFilesAPI.MFDBEngine.MFDBEngineFirebird)
                            {
                                // The Engine is not Firebird, this will be ignored
                                isFirebirdEngine = false;
                                MessageBox.Show("The vault " + vaultName + " has been converted to the SQL Server based after taking the backup. This vault cannot be restored and is ignored.");
                            }
                            else
                            {
                                // The Engine is Firebird
                                // Check first if the restoration is from backup or new vault from repository
                                // restoration == true ; from backup
                                // restorarion == false ; from repository


                                // First take Safety Backups from the existing vault if something goes
                                // wrong during the restoration
                                // ShowSafetyBackupMessage(true);
                                BackupJob backupJob = new BackupJob();
                                backupJob.BackupType = MFBackupType.MFBackupTypeFull;
                                backupJob.OverwriteExistingFiles = false;
                                string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                                // string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                                backupJob.TargetFile = directory + Constants.safetyBkPath + "\\" + vaultName + "__" + GetTimeStamp() + ".mfb";

                                // backupJob.TargetFile = Constants.safetyBkPath + "\\" + vaultName + "__" + GetTimeStamp() + ".mfb";
                                backupJob.VaultGUID = vaultGUID;
                                oMFServerApp.VaultManagementOperations.BackupVault(backupJob);

                                // Destroy the vault
                                oMFServerApp.VaultManagementOperations.DestroyVault(vaultGUID);
                                // ShowSafetyBackupMessage(false);
                            }
                        }
                    }
                    {
                        if (vaultExistence != -1)
                            DeleteVault(vaultName, vaultGUID, false);
                    }

                    // Restore the vault if the Engine is Firebird
                    if (isFirebirdEngine)
                    {
                        // ShowRestoreVaultMessage(true);
                        /*
                        // We need to write to Registry due to bug in M-Files
                        // ****************************** REMOVE LINES WHEN THE BUG IS FIXED *****************************************
                        string regKey = "SOFTWARE\\Motive\\M-Files\\" + GetMFClientVersion() + "\\Server\\MFServer\\Vaults";
                        RegistryKey subKey = Registry.LocalMachine.OpenSubKey(regKey, true).CreateSubKey(vaultGUID);
                        subKey.SetValue("DataFolder", "");
                        subKey.Close();
                        // ***********************************************************************************************************
                        */

                        VaultProperties vaultProperties = new VaultProperties();
                        RestoreJob restoreJob = new RestoreJob();
                        vaultProperties.DisplayName = vaultName;
                        vaultProperties.VaultGUID = vaultGUID;
                        vaultProperties.MainDataFolder = Constants.vaultsPath + vaultName + "\\";
                        restoreJob.BackupFileFull = backupPath;
                        restoreJob.VaultProperties = vaultProperties;
                        restoreJob.OverwriteExistingFiles = true;
                        int percentage = (int)(Math.Round(((double)fileCounter / (double)fileArr.Length * 100)));
                        sendingWorker.ReportProgress(percentage);
                        oMFServerApp.VaultManagementOperations.RestoreVault(restoreJob);
                        oMFServerApp.VaultManagementOperations.TakeVaultOffline(vaultGUID, true);
                        fileCounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void restoreBackUpWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            msg.RestoreBackUpVaultsProgress(true, e.ProgressPercentage, lblStatus);
        }

        protected void restoreBackUpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            if (e.Error == null)
            {
                msg.RestoreBackUpVaultsProgress(false, 0, lblStatus);
                MessageBox.Show("Operation completed!");
            }
            else
            {
                msg.ShowErrorDuringOperation(true, prgLabel);
                MessageBox.Show(e.Error.ToString());
                msg.ShowErrorDuringOperation(false, prgLabel);
            }
            ButtonsEnabled(true);
            msg.ShowRestoreVaultMessage(false, prgLabel);
            RefreshAvailableVaultsView();
            mainForm.RefreshVaultView();
            
            if (Directory.Exists(Constants.tempPath))
            {
                Directory.Delete(Constants.tempPath, true);
            }

        }

        private string ReadVaultData(string xmlFile, string dataToRead)
        {
            // Reads vault data from XML file:
            // * description
            // * date
            // * version
            // * GUID
            // * Vault Name
            // * Vault Type
            string returnData = String.Empty;
            foreach (var element in XmlHelper.StreamConnections(xmlFile))
            {
                switch (dataToRead)
                {
                    case "version":
                        returnData = element.VaultVersion;
                        break;

                    case "description":
                        returnData = element.VaultDescription;
                        break;

                    case "vaulttype":
                        returnData = element.VaultType;
                        break;

                    case "date":
                        returnData = element.VaultDate;
                        break;

                    case "guid":
                        returnData = element.ServerVaultGUID;
                        break;

                    case "vaultname":
                        returnData = element.ServerVaultName;
                        break;

                }
            }
            return returnData;
        }

        private bool DeleteVault(string vaultName, string vaultGUID, bool deleteConfig)
        {
            // Process:
            // 1. If the vault is Online, put it Offline
            // 2. Remove vault connection
            // 3. Destroy the vault
            // 4. Delete configuration XML
            // 5. Restart M-Files Client

            bool success = false;
            UserMessages msg = new UserMessages();
            MFilesOperations clientRst = new MFilesOperations();

            try
            {
                MFilesClientApplication oMFClientApp = new MFilesClientApplication();
                MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();


                // 1. If the vault is Online, put if Offline
                if (oMFServerApp.GetOnlineVaults().GetVaultIndexByGUID(vaultGUID) != 1)
                    oMFServerApp.VaultManagementOperations.TakeVaultOffline(vaultGUID, true);

                // 2. Remove all vault connections for Vault GUID
                VaultConnections vaultConns = oMFClientApp.GetVaultConnectionsWithGUID(vaultGUID);
                foreach (VaultConnection vaultConn in vaultConns)
                    oMFClientApp.RemoveVaultConnection(vaultConn.Name, vaultConn.UserSpecific);

                // 3. Destroy the Vault

                oMFServerApp.VaultManagementOperations.DestroyVault(vaultGUID);

                // 4. Delete Vault Configuration XML file if needed
                if (deleteConfig)
                {
                    string vaultConfFile = GetConfFileNameByGUID(vaultGUID); // Check if there is conf xml for the vault
                    if (!String.IsNullOrEmpty(vaultConfFile))
                        File.Delete(vaultConfFile);
                }

                // 4.1 

                // 5. Restart M-Files Client Service

                msg.ShowClientRestartMessage(true, prgLabel);
                clientRst.RestartMFClientService();
                // RestartMFClientService();
                msg.ShowClientRestartMessage(false, prgLabel);

                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show(ex.Message);
            }

            return success;
        }

        private string GetConfFileNameByGUID(string guid)
        {
            // Loops all XML files in %appdata%/VaultConf and reads ServerVaultGuid and compares the value to "guid". If found, returns
            // XML file name, otherwise empty string.
            string[] filesInDir;
            string fileName = String.Empty;

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
            filesInDir = Directory.GetFiles(directory);
            foreach (string file in filesInDir)
            {
                if (ReadVaultData(file, "guid") == guid)
                {
                    fileName = file;
                    break;
                }
            }
            return fileName;
        }

        private void ButtonsEnabled(bool state)
        {
            moreInfoButton.Enabled = state;
            closeButton.Enabled = state;
            addToDemoButton.Enabled = state;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private struct VaultPropertiesExt
        {
            public MFilesAPI.VaultProperties vaultProperties;
            public string fullPath;
        }

        private string GetTimeStamp()
        {
            string returnValue;

            DateTime dateTimeNow = DateTime.Now;
            returnValue = dateTimeNow.Year + "-" + dateTimeNow.Month + "-" + dateTimeNow.Day + "-";
            returnValue = returnValue + dateTimeNow.Hour + "-" + dateTimeNow.Minute + "-" + dateTimeNow.Second;

            return returnValue;
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void moreInfoButton_Click(object sender, EventArgs e)
        {
            string vaultName = String.Empty;
            string vaultGUID = String.Empty;
            string vaultDescription = String.Empty;
            string destFile = String.Empty;

            char[] delimitChars = { '{', '}' };
            string xmlFile = String.Empty;

            if (listAvailableVaults.SelectedItems.Count != 0)
            {
                if (!Directory.Exists(Constants.moreInfoPath))
                {
                    Directory.CreateDirectory(Constants.moreInfoPath);
                }
                try
                {
                    vaultName = listAvailableVaults.SelectedItems[0].Text;
                    listAvailableVaults.SelectedItems.Clear();
                    AzureOperations azureOperations = new AzureOperations();

                    CloudFileDirectory vaultDir = azureOperations.GetVaultDirectoryInAzure(vaultName);
                    CloudFileDirectory configDir = vaultDir.GetDirectoryReference("Configs");
                    destFile = Constants.moreInfoPath + vaultName + ".xml";
                    using (var destStream = File.OpenWrite(destFile))
                    {
                        var sourceFile = configDir.GetFileReference(vaultName + ".xml");
                        sourceFile.DownloadToStream(destStream);
                    }
                    vaultDescription = ReadVaultData(destFile, "description");
                    vaultDescription = "microsoft-edge:" + vaultDescription;
                    Process.Start(vaultDescription);
                    Directory.Delete(Constants.moreInfoPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
