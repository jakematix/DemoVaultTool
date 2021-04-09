using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using MFilesAPI;
using System.Xml;

namespace DemoEnvironmentVaultTool
{
    public partial class snapshotToolForm : Form
    {
        Form1 mainForm;
        public snapshotToolForm(Form1 incomingForm)
        {
            mainForm = incomingForm;
            InitializeComponent();
            this.MinimumSize = new Size(828, 584);
            this.MaximumSize = new Size(828, 584);

            RefreshVaultView();
            RefreshSnapshotView();
            


            // Initialize Background worker
            vaultBackUpWorker.DoWork += new DoWorkEventHandler(vaultBackUpWorker_DoWork);  
            vaultBackUpWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vaultBackUpWorker_RunWorkerCompleted);
            vaultBackUpWorker.ProgressChanged += new ProgressChangedEventHandler(vaultBackUpWorker_ProgressChanged);
            vaultBackUpWorker.WorkerReportsProgress = true;

            restoreBackUpWorker.DoWork += new DoWorkEventHandler(restoreBackUpWorker_DoWork);
            restoreBackUpWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(restoreBackUpWorker_RunWorkerCompleted);
            restoreBackUpWorker.ProgressChanged += new ProgressChangedEventHandler(restoreBackUpWorker_ProgressChanged);
            restoreBackUpWorker.WorkerReportsProgress = true;
            restoreBackUpWorker.WorkerSupportsCancellation = true;

            vaultCopyWorker.DoWork += new DoWorkEventHandler(vaultCopyWorker_DoWork);
            vaultCopyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vaultCopyWorker_RunWorkerCompleted);
            vaultCopyWorker.ProgressChanged += new ProgressChangedEventHandler(vaultCopyWorker_ProgressChanged);
            vaultCopyWorker.WorkerReportsProgress = true;
            vaultCopyWorker.WorkerSupportsCancellation = true;

        }

        public static string snapShotName = String.Empty;

        private BackgroundWorker vaultBackUpWorker = new BackgroundWorker();
        private BackgroundWorker restoreBackUpWorker = new BackgroundWorker();
        private BackgroundWorker vaultCopyWorker = new BackgroundWorker();


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void takeSnapshot_button_Click(object sender, EventArgs e)
        {
            string snapShotDir = String.Empty;
            UserMessages msg = new UserMessages();
            try
            {
                if (vaultsInServer_listView.SelectedItems.Count == 0)
                {
                    MessageBox.Show(Constants.selectFirstVaultForSnapshotMessage);
                    return;
                }

                // First create new backup folder (C:\DemoVaultBackups) if it does not already exist.
                // This is the "root" directory for all the snapshots/backups.

                // Define Backup (Snapshot) name (directory)

                using (var snapshotName = new SnapshotName())
                {
                    var result = snapshotName.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        snapShotDir = snapshotName.NameOfSnapshot;
  
                        BackUpVault[] bkVault = new BackUpVault[vaultsInServer_listView.SelectedItems.Count]; // size of the name-GUID struct is the number of selected vaults in the listCurrentVaults

                        for (int i = 0; i < vaultsInServer_listView.SelectedItems.Count; i++)
                        {
                            bkVault[i].name = vaultsInServer_listView.SelectedItems[i].SubItems[0].Text;
                            bkVault[i].GUID = vaultsInServer_listView.SelectedItems[i].SubItems[1].Text;
                        }

                        // Snapshot directory and vault struct to the List to be further send to Background process.
                        List<object> backUpArguments = new List<object>();
                        backUpArguments.Add(snapShotDir);
                        backUpArguments.Add(bkVault);


                        if (!vaultBackUpWorker.IsBusy)
                        {
                            ButtonsEnabled(false);
                            msg.ShowBuildingSnapshotMessage(true, prgLabel);
                            // ShowBuildingSnapshotMessage(true);
                            vaultBackUpWorker.RunWorkerAsync(backUpArguments); // perform Backup operation in Background process (own thread)
                            MessageBox.Show(Constants.snapshotCreationStartedMessage);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshVaultView()
        {


            UserMessages msg = new UserMessages();
            vaultsInServer_listView.Items.Clear();
            vaultsInServer_listView.MultiSelect = true;
            vaultsInServer_listView.FullRowSelect = true;
            vaultsInServer_listView.Columns[0].ListView.Font = new Font(vaultsInServer_listView.Columns[0].ListView.Font, FontStyle.Bold);
            vaultsInServer_listView.Columns[1].ListView.Font = new Font(vaultsInServer_listView.Columns[1].ListView.Font, FontStyle.Bold);
            msg.ShowRestoreVaultMessage(false, prgLabel);
            msg.ShowBuildingSnapshotMessage(false, prgLabel);
            msg.ShowCopyingVaultMessage(false, prgLabel);
            msg.ShowSafetyBackupMessage(false, prgLabel);

            // ShowRestoreVaultMessage(false);
            // ShowBuildingSnapshotMessage(false);
            // ShowCopyingVaultMessage(false);
            // ShowSafetyBackupMessage(false);

            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            //MFilesAPI.MFilesServerApplication oMFServerApp = GetMFServerConnection();

            VaultsOnServer oVaults = oMFServerApp.GetVaults();
            foreach (VaultOnServer oOneVault in oVaults)
            {
                ListViewItem vault = new ListViewItem(oOneVault.Name);
                vault.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                vault.SubItems.Add(oOneVault.GUID);
                vaultsInServer_listView.Items.Add(vault);
            }
        }

        /*
        public static MFilesAPI.MFilesServerApplication GetMFServerConnection()
        {
            MFilesAPI.MFilesServerApplication serverConnection = new MFilesAPI.MFilesServerApplication();
            serverConnection.ConnectAdministrativeEx(null,
                                                     MFilesAPI.MFAuthType.MFAuthTypeSpecificMFilesUser,
                                                     Constants.userName, Constants.passWord, "", "",
                                                     Constants.protocolSequence, Constants.server,
                                                     Constants.endPoint, false, "");
            return serverConnection;
        }
        */

        

        private void ButtonsEnabled(bool state)
        {
            takeSnapshot_button.Enabled = state;
            button1.Enabled = state;
            restore_button.Enabled = state;
            destroy_button.Enabled = state;
            copyVaultButton.Enabled = state;
        }

        private struct BackUpVault
        {
            public string name;
            public string GUID;
        }

        private struct CopyVault
        {
            public string name;
        }

        private struct VaultPropertiesExt
        {
            public VaultProperties vaultProperties;
            public string fullPath;
            public string directoryName;
        }

        private void RefreshSnapshotView()
        {
            availableSnapshots_listView.Items.Clear();
            availableSnapshots_listView.MultiSelect = false;
            availableSnapshots_listView.FullRowSelect = true;
            availableSnapshots_listView.Columns[0].ListView.Font = new Font(availableSnapshots_listView.Columns[0].ListView.Font, FontStyle.Bold);
            availableSnapshots_listView.Columns[1].ListView.Font = new Font(availableSnapshots_listView.Columns[1].ListView.Font, FontStyle.Bold);
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string basePath = directory + Constants.basePath;
            DirectoryInfo dir = new DirectoryInfo(basePath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo di in dirs)
            {
                ListViewItem lvi = new ListViewItem(di.Name);
                lvi.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                lvi.SubItems.Add(di.CreationTime.ToString("yyyy'-'MM'-'dd"));
                availableSnapshots_listView.Items.Add(lvi);
            }
        }

        private string GetTimeStamp()
        {
            string returnValue;

            DateTime dateTimeNow = DateTime.Now;
            
            returnValue = dateTimeNow.Year + "-" + dateTimeNow.Month + "-" + dateTimeNow.Day + "-";
            returnValue = returnValue + dateTimeNow.Hour + "-" + dateTimeNow.Minute;

            return returnValue;
        }

        private void vaultBackUpWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            List<object> genericlist = e.Argument as List<object>;
            string backupPath = (string)genericlist[0];
            BackUpVault[] bkVault = (BackUpVault[])genericlist[1];
            // ShowBuildingSnapshotMessage(true);


            // Get M-Files Server App and login
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            // MFilesAPI.MFilesServerApplication oMFServerApp = GetMFServerConnection();

            // Go thru the selected vaults and perform backup operation for those
            for (int vault = 0; vault < bkVault.Length; vault++)
            {
                string vaultName = bkVault[vault].name;
                string vaultGUID = bkVault[vault].GUID;
                int percentage = (int)(Math.Round(((double)vault / (double)bkVault.Length * 100)));
                BackupJob vaultBackupJob = new BackupJob();
                vaultBackupJob.BackupType = MFBackupType.MFBackupTypeFull;
                vaultBackupJob.OverwriteExistingFiles = false;
                vaultBackupJob.TargetFile = backupPath + "\\" + vaultName + ".mfb";
                vaultBackupJob.VaultGUID = vaultGUID;
                sendingWorker.ReportProgress(percentage);
                oMFServerApp.VaultManagementOperations.BackupVault(vaultBackupJob);
                // Check if there is also Configuration XML available. If YES, then copy it also to backup directory
                string fullConfFileName = GetConfFileNameByGUID(vaultGUID);
                if (fullConfFileName != String.Empty) {
                    
                    File.Copy(fullConfFileName, backupPath + "\\" + Path.GetFileName(fullConfFileName));
                }
            }
        }

        protected void vaultBackUpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {

                lblStatus.Text = "Snapshot creaion completed.";
                MessageBox.Show("Snapshot creation completed!");
                lblStatus.Text = "";
            }
            else
            {
                lblStatus.Text = "An error occurred during the Snapshot Creation!";
                MessageBox.Show("Something went wrong during the snapshot creation operation!");
            }
            ButtonsEnabled(true);
            RefreshVaultView();
            RefreshSnapshotView();
            // UserMessages msg = new UserMessages();
            // msg.ShowSafetyBackupMessage(false, prgLabel);
            // ShowBuildingSnapshotMessage(false);
        }

        protected void vaultBackUpWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = "Vaults processed: " + e.ProgressPercentage + "% ...";
        }

        private void restore_button_Click(object sender, EventArgs e)
        {
            string directoryName = String.Empty;
            string restoreMessage = String.Empty;

            if (availableSnapshots_listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select first the Snapshot from the list.");
                return;
            }
            try
            {
                // Get Backup (Snapshot) name (directory)
                snapShotName = availableSnapshots_listView.SelectedItems[0].Text;

                RestoreParameters restoreParameters;

                using (var restoreVaultForm = new RestoreFromSnapshot())
                {
                    var result = restoreVaultForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        restoreParameters.vaultName = restoreVaultForm.RestoreVaultName;
                        restoreParameters.createVaultConnection = restoreVaultForm.CreateVaultConnection;
                        string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        directoryName = directory + Constants.basePath + snapShotName;
                        DirectoryInfo dInfo = new DirectoryInfo(directoryName);
                        FileInfo[] filesArr = dInfo.GetFiles("*.mfb").ToArray();

                        // Go thru the files in the Snapshot to construct and show message to show the vaults to be restored.
                        // Get M-Files Server App and login

                        MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
                        foreach (FileInfo f in filesArr)
                        {
                            VaultProperties vaultProperties;
                            vaultProperties = oMFServerApp.VaultManagementOperations.GetBackupFileContents(f.FullName, "");
                            // vaultProperties.DisplayName = restoreParameters.vaultName;

                            List<object> restoreArguments = new List<object>();
                            restoreArguments.Add(true);
                            restoreArguments.Add(filesArr);
                            restoreArguments.Add(restoreParameters.vaultName);
                            restoreArguments.Add(restoreParameters.createVaultConnection);

                            if (!restoreBackUpWorker.IsBusy)
                            {
                                ButtonsEnabled(false);
                                UserMessages msg = new UserMessages();
                                msg.ShowRestoreVaultMessage(true, prgLabel);
                                // ShowRestoreVaultMessage(true);
                                restoreBackUpWorker.RunWorkerAsync(restoreArguments); // perform Restore operation as Backgroun process (own thread)
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void restoreBackUpWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            List<object> genericlist = e.Argument as List<object>;
            bool restoration = (bool)genericlist[0]; 
            FileInfo[] fileArr = (FileInfo[])genericlist[1]; // original backup name
            string restoreVaultName = (string)genericlist[2]; // restored vault name
            bool createConfigXml = (bool)genericlist[3]; 
            int fileCounter = 0;
            string appDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            ButtonsEnabled(false);
            // ShowRestoreVaultMessage(true);

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
                    
       

                    // Store to the List
                    VaultPropertiesExt sVaultPropertiesExt;
                    sVaultPropertiesExt.vaultProperties = vaultProperties;
                    sVaultPropertiesExt.fullPath = f.FullName;
                    sVaultPropertiesExt.directoryName = f.DirectoryName;
                    listVaultProperties.Add(sVaultPropertiesExt);
                }

                // Loop the backups and restore them                   
                foreach (VaultPropertiesExt sOneVaultPropExt in listVaultProperties)
                {
                    string backupPath = sOneVaultPropExt.fullPath;
                    string bkDirectoryName = sOneVaultPropExt.directoryName;
                    string vaultName = sOneVaultPropExt.vaultProperties.DisplayName;
                    string vaultGUID = sOneVaultPropExt.vaultProperties.VaultGUID;
                    bool isFirebirdEngine = true;
                    int vaultExistence = oMFServerApp.GetVaults().GetVaultIndexByGUID(vaultGUID);
                    // If the vault is from Vault Library and the vault already exist, do nothing.
                    if (!restoration & vaultExistence != -1)
                    {
                        MessageBox.Show("Vault " + vaultName + " already exist.");
                        restoreBackUpWorker.CancelAsync(); //
                        return;
                    }
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
                                MessageBox.Show("The vault " + vaultName + " has been converted to the SQL Server based after taking the backup. This vault cannot be restored and will be ignored.");
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

                                backupJob.TargetFile = appDirectory + Constants.safetyBkPath + "\\" + vaultName + "__" + GetTimeStamp() + ".mfb";

                                // backupJob.TargetFile = Constants.safetyBkPath + "\\" + vaultName + "__" + GetTimeStamp() + ".mfb";
                                int percentage = (int)(Math.Round(((double)fileCounter / (double)fileArr.Length * 100)));
                                sendingWorker.ReportProgress(percentage);
                                backupJob.VaultGUID = vaultGUID;
                                oMFServerApp.VaultManagementOperations.BackupVault(backupJob);

                                // If there is a vault connection for the vault, delete it
                                MFilesClientApplication oMFClientApp = new MFilesClientApplication();
                                VaultConnections vaultConnections = oMFClientApp.GetVaultConnectionsWithGUID(vaultGUID);
                                foreach (VaultConnection vaultConnection in vaultConnections)
                                    oMFClientApp.RemoveVaultConnection(vaultConnection.Name, vaultConnection.UserSpecific);
                                
                                // Destroy the vault
                                oMFServerApp.VaultManagementOperations.DestroyVault(vaultGUID);
                                // ShowSafetyBackupMessage(false);
                            }
                        }
                    }

                    // Restore the vault if the Engine is Firebird
                    if (isFirebirdEngine)
                    {
                        // ShowRestoreVaultMessage(true);
                        /*
                        // We need to write to Registry due to bug in M-Files
                        
                        MFilesOperations mFilesOperations = new MFilesOperations();
                        
                        string regKey = "SOFTWARE\\Motive\\M-Files\\" + mFilesOperations.GetMFClientVersion() + "\\Server\\MFServer\\Vaults";
                        RegistryKey subKey = Registry.LocalMachine.OpenSubKey(regKey, true).CreateSubKey(vaultGUID);
                        subKey.SetValue("DataFolder", "");
                        subKey.Close();
                        */


                        VaultProperties vaultProperties = new VaultProperties();
                        RestoreJob restoreJob = new RestoreJob();
                        // vaultProperties.DisplayName = vaultName;
                        vaultProperties.DisplayName = restoreVaultName;
                        vaultProperties.VaultGUID = vaultGUID;
                        vaultProperties.MainDataFolder = Constants.vaultsPath + vaultName + "\\";
                        restoreJob.BackupFileFull = backupPath;
                        restoreJob.OverwriteExistingFiles = true;
                        restoreJob.VaultProperties = vaultProperties;
                        oMFServerApp.VaultManagementOperations.RestoreVault(restoreJob);
                        oMFServerApp.VaultManagementOperations.TakeVaultOffline(vaultGUID, true);
                        // If there is Configuration File available for the backup file, copy it to VaultConf and replace existing one
                        /*
                        string confFile = GetConfFileFromBackup(bkDirectoryName, vaultName, vaultGUID);

                        
                        if (confFile != String.Empty)
                            File.Copy(confFile, appDirectory + Constants.xmlVaultConfPath + Path.GetFileName(confFile), true);
                        */
                        if (createConfigXml)
                            CreateVaultConnectionXml(restoreVaultName, vaultGUID);
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
            lblStatus.Text = "Vaults processed: " + e.ProgressPercentage + "% ...";
        }

        protected void restoreBackUpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                lblStatus.Text = "Operation completed.";
                MessageBox.Show("Operation completed!");
                lblStatus.Text = "";
            }
            else
            {
                lblStatus.Text = "An error occurred during the operation!";
                MessageBox.Show(e.Error.ToString());
            }
            ButtonsEnabled(true);
            UserMessages msg = new UserMessages();
            msg.ShowRestoreVaultMessage(false, prgLabel);

            RefreshSnapshotView();
            RefreshVaultView();
            mainForm.RefreshVaultView();
            if (Directory.Exists(Constants.tempPath))
            {
                Directory.Delete(Constants.tempPath, true);
            }

        }

        

        protected void vaultCopyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            List<object> genericlist = e.Argument as List<object>;
            string originalVaultGUID = (string)genericlist[0];
            CopyParameters copyParameters = (CopyParameters)genericlist[1];


            // originalVaultName = Constants.vaultsPath + originalVaultName; // Location of server vaults C:\Program Files\M-Files\Server Vaults

            try
            {

                // Get M-Files Server App and login

                MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
                VaultsOnServer oVaults = oMFServerApp.GetVaults();

                VaultOnServer sourceVault = oVaults.GetVaultByGUID(originalVaultGUID);
                VaultProperties sourceVaultProperties = oMFServerApp.VaultManagementOperations.GetVaultProperties(sourceVault.GUID);
                VaultProperties copyVaultProperties = new VaultProperties();
                CopyVaultJob copyVaultJob = new CopyVaultJob();

                copyVaultProperties = sourceVaultProperties;
                copyVaultProperties.VaultGUID = Guid.NewGuid().ToString("B");
                copyVaultProperties.DisplayName = copyParameters.copyVaultName;
                copyVaultProperties.MainDataFolder = Constants.vaultsPath + copyParameters.copyVaultName;

                copyVaultJob.VaultProperties = copyVaultProperties;
                copyVaultJob.VaultGUID = originalVaultGUID;
                copyVaultJob.CopyflagUseTargetGUID = false;

                copyVaultJob.CopyflagAllData = copyParameters.copyAllData;
                copyVaultJob.CopyflagAllExceptData = copyParameters.copyOnlyStructure;


                string GUID = CreateCopyVault(oMFServerApp, copyVaultJob);
                oMFServerApp.VaultManagementOperations.TakeVaultOffline(GUID, true);

                if (copyParameters.createVaultConnection)
                    CreateVaultConnectionXml(copyVaultProperties.DisplayName, GUID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void vaultCopyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            if (e.Error == null)
            {
                vaultsInServer_listView.SelectedItems.Clear();
                msg.ShowVaultCopyCompletedMessage(true, prgLabel);
                lblStatus.Text = "Operation completed.";
                MessageBox.Show(Constants.vaultCopyCompletedMsg);
                lblStatus.Text = "";
                msg.ShowVaultCopyCompletedMessage(false, prgLabel);
                

            }
            else
            {
                lblStatus.Text = "An error occurred during the operation!";
                MessageBox.Show(e.Error.ToString());
            }
            ButtonsEnabled(true);
            RefreshSnapshotView();
            RefreshVaultView();
            mainForm.RefreshVaultView();
        }

        protected void vaultCopyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void CreateVaultConnectionXml(string vaultName, string vaultGUID)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");


            XmlDocument confFile = new XmlDocument();
            XmlNode confNode = confFile.CreateXmlDeclaration("1.0", "UTF-8", null);
            confFile.AppendChild(confNode);

            XmlNode vaultConnectionsNode = confFile.CreateElement("VaultConnections");
            confFile.AppendChild(vaultConnectionsNode);

            XmlNode descriptionsNode = confFile.CreateElement("Descriptions");
            vaultConnectionsNode.AppendChild(descriptionsNode);

            XmlNode vaultVersionNode = confFile.CreateElement("VaultVersion");
            vaultVersionNode.AppendChild(confFile.CreateTextNode("1.0"));
            descriptionsNode.AppendChild(vaultVersionNode);

            XmlNode vaultDescriptionNode = confFile.CreateElement("VaultDescription");
            vaultDescriptionNode.AppendChild(confFile.CreateTextNode("http://localhost"));
            descriptionsNode.AppendChild(vaultDescriptionNode);

            XmlNode vaultTypeNode = confFile.CreateElement("VaultType");
            vaultTypeNode.AppendChild(confFile.CreateTextNode("LocalCopy"));
            descriptionsNode.AppendChild(vaultTypeNode);

            XmlNode vaultConnectionNode = confFile.CreateElement("VaultConnection");
            vaultConnectionsNode.AppendChild(vaultConnectionNode);

            XmlNode vaultDateNode = confFile.CreateElement("VaultDate");
            vaultDateNode.AppendChild(confFile.CreateTextNode(dateToday));
            vaultConnectionNode.AppendChild(vaultDateNode);

            XmlNode connectionNameNode = confFile.CreateElement("ConnectionName");
            connectionNameNode.AppendChild(confFile.CreateTextNode(vaultName));
            vaultConnectionNode.AppendChild(connectionNameNode);

            XmlNode infoTipNode = confFile.CreateElement("InfoTip");
            infoTipNode.AppendChild(confFile.CreateTextNode(Constants.infoTip));
            vaultConnectionNode.AppendChild(infoTipNode);

            XmlNode protocolSequenceNode = confFile.CreateElement("ProtocolSequence");
            protocolSequenceNode.AppendChild(confFile.CreateTextNode(Constants.protocolSequence));
            vaultConnectionNode.AppendChild(protocolSequenceNode);

            XmlNode networkAddressNode = confFile.CreateElement("NetworkAddress");
            networkAddressNode.AppendChild(confFile.CreateTextNode(Constants.networkAddress));
            vaultConnectionNode.AppendChild(networkAddressNode);

            XmlNode endPointNode = confFile.CreateElement("EndPoint");
            endPointNode.AppendChild(confFile.CreateTextNode(Constants.endPoint));
            vaultConnectionNode.AppendChild(endPointNode);

            XmlNode serverVaultGUIDNode = confFile.CreateElement("ServerVaultGUID");
            serverVaultGUIDNode.AppendChild(confFile.CreateTextNode(vaultGUID));
            vaultConnectionNode.AppendChild(serverVaultGUIDNode);

            XmlNode serverVaultNameNode = confFile.CreateElement("ServerVaultName");
            serverVaultNameNode.AppendChild(confFile.CreateTextNode(vaultName));
            vaultConnectionNode.AppendChild(serverVaultNameNode);

            XmlNode authTypeNode = confFile.CreateElement("AuthType");
            authTypeNode.AppendChild(confFile.CreateTextNode(Constants.authType));
            vaultConnectionNode.AppendChild(authTypeNode);

            XmlNode autoLoginNode = confFile.CreateElement("AutoLogin");
            autoLoginNode.AppendChild(confFile.CreateTextNode(Constants.autoLogin));
            vaultConnectionNode.AppendChild(autoLoginNode);

            XmlNode encryptedConnectionNode = confFile.CreateElement("EncryptedConnection");
            encryptedConnectionNode.AppendChild(confFile.CreateTextNode(Constants.encryptedConnection));
            vaultConnectionNode.AppendChild(encryptedConnectionNode);

            XmlNode userNameNode = confFile.CreateElement("UserName");
            userNameNode.AppendChild(confFile.CreateTextNode(String.Empty));
            vaultConnectionNode.AppendChild(userNameNode);

            XmlNode passwordNode = confFile.CreateElement("Password");
            passwordNode.AppendChild(confFile.CreateTextNode(String.Empty));
            vaultConnectionNode.AppendChild(passwordNode);

            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath + vaultName + "_" + vaultGUID + ".xml";
             

            confFile.Save(fileName);

        }

        private string GetMFClientVersion()
        {
            MFilesClientApplication mFClient = new MFilesClientApplication();
            return mFClient.GetClientVersion().Display;
        }

        private void destroy_button_Click(object sender, EventArgs e)
        {
            {
                string directoryName = null;
                string destroyMessage = null;

                if (availableSnapshots_listView.SelectedItems.Count == 0)
                {
                    MessageBox.Show(Constants.selectSnapshotMessage);
                    return;
                }

                try
                {
                    // First select the backups (snapshot, directory) to be destroyed
                    string snapshotName = availableSnapshots_listView.SelectedItems[0].Text;
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    directoryName = directory + Constants.basePath + snapshotName + "\\";

                    destroyMessage = "You are about to destroy snapshot \r\n" + snapshotName + " !";
                    DialogResult dialogResult = MessageBox.Show((destroyMessage), "Destroy Snapshot directory", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        // Destroy all backups and finally the directory itself
                        Directory.Delete(directoryName, true);
                        MessageBox.Show(Constants.snapshotRemovedMessage);
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show(Constants.operationCancelledMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                RefreshSnapshotView();
            }
        }

        private string GetConfFileNameByGUID(string GUID)
        {
            string[] filesInDir;
            char[] delimitChar = { '_' };
            string fileName = String.Empty;
            string connectionGUID = String.Empty;

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
            filesInDir = Directory.GetFiles(directory);
            foreach (string file in filesInDir)
            {
                string[] splitText = file.Split(delimitChar);
                connectionGUID = splitText[1];
                int dotXML = connectionGUID.IndexOf(".");
                connectionGUID = connectionGUID.Remove(dotXML, 4);
                if (GUID == connectionGUID)
                {
                    fileName = file;
                    break;
                }
            }
            return fileName;
        }

        private string GetConfFileFromBackup(string backupPath, string vaultName, string vaultGUID)
        {
            string confFileName = String.Empty;
            string foundConfFile = String.Empty;
            string[] filesInDir;
            // backupDir = Constants.basePath + vault + "//";
            confFileName = backupPath + "\\" + vaultName + "_" + vaultGUID + ".xml";
            
            filesInDir = Directory.GetFiles(backupPath + "\\");
            foreach (string file in filesInDir)
            {
                if (file == confFileName)
                {
                    foundConfFile = file;
                    break;
                }
            }
            return foundConfFile;
        }

        private void copyVaultButton_Click(object sender, EventArgs e)
        {
            UserMessages msg = new UserMessages();
            if (vaultsInServer_listView.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.vaultToBeCopiedMissing);
                vaultsInServer_listView.SelectedItems.Clear();
                return;
            }
            else if (vaultsInServer_listView.SelectedItems.Count > 1)
            {
                MessageBox.Show(Constants.severalVaultsToBeCopied);
                vaultsInServer_listView.SelectedItems.Clear();
                return;
            }
            

            CopyParameters copyParameters;

            string originalVaultName = vaultsInServer_listView.SelectedItems[0].SubItems[0].Text;
            string originalVaultGUID = vaultsInServer_listView.SelectedItems[0].SubItems[1].Text;

            try
            {

                using (var copyVaultForm = new VaultCopyParameters())
                {
                    var result = copyVaultForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        copyParameters.copyAllData = copyVaultForm.CopyAllData;
                        copyParameters.copyOnlyStructure = copyVaultForm.CopyOnlyStructure;
                        copyParameters.createVaultConnection = copyVaultForm.CreateVaultConnection;
                        copyParameters.copyVaultName = copyVaultForm.CopyVaultName;

                        List<object> copyArguments = new List<object>();
                        copyArguments.Add(originalVaultGUID);
                        copyArguments.Add(copyParameters);


                        if (!vaultCopyWorker.IsBusy)
                        {
                            ButtonsEnabled(false);
                            prgLabel.Visible = true;
                            prgLabel.Text = "Vault Copying: " + originalVaultName + " --> " + copyVaultForm.CopyVaultName;
                            // msg.ShowVaultCopyMessage(true, prgLabel, originalVaultName, copyVaultForm.CopyVaultName);
                            vaultCopyWorker.RunWorkerAsync(copyArguments);
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public static string CreateCopyVault(MFilesServerApplication serverApplication, CopyVaultJob copyVaultJob)
        {

            // Sanity.
            if (null == serverApplication)
                throw new ArgumentNullException(nameof(serverApplication));
            if (null == copyVaultJob)
                throw new ArgumentNullException(nameof(copyVaultJob));

            return serverApplication.VaultManagementOperations.CopyVault(copyVaultJob)?.VaultProperties?.VaultGUID;
        }

        private struct CopyParameters
        {
            public Boolean copyAllData;
            public Boolean copyOnlyStructure;
            public Boolean createVaultConnection;
            public string copyVaultName;
        };

        private struct RestoreParameters
        {
            public string vaultName;
            public Boolean createVaultConnection;
        };



        private void removeVaultButton_Click(object sender, EventArgs e)
        {
            
        }

        

        private string GetConfigFileNameByGUID(string guid)
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
    }



}
