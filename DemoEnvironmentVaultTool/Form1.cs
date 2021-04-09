using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage.File;
using WUApiLib;
using System.Globalization;
using System.Management.Automation;
using MFilesAPI;
using System.Xml;


namespace DemoEnvironmentVaultTool
{
    public partial class Form1 : Form
    {


        public Form1()
        {

            InitializeComponent();
            // Initialize Background worker



            checkUpdateWorker.DoWork += new DoWorkEventHandler(checkUpdateWorker_DoWork);
            checkUpdateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(checkUpdateWorker_RunWorkerCompleted);
            checkUpdateWorker.WorkerReportsProgress = false;

        }

        private BackgroundWorker checkUpdateWorker = new BackgroundWorker();




        private void Form1_Load(object sender, EventArgs e)
        {
            AzureOperations azureOperations = new AzureOperations();
            this.MinimumSize = new Size(821, 686);
            this.MaximumSize = new Size(821, 686);
            winUpdateButton.Visible = false;
            UpdateMFilesButton.Visible = false;
            ClearTemps();
            RefreshVaultView();
            PopulateLocalizations();
            

            if (Connectivity.ConnectivityStatus(connectivityLabel))
            {
                if (azureOperations.ConnectToAzureFiles())
                {
                    CheckMFilesUpdates();
                }
                if (!checkUpdateWorker.IsBusy)
                    checkUpdateWorker.RunWorkerAsync();
            }
            else
            {

                moreInfoButton.Enabled = false;
            }
        }

        public void WelcomeScreen()
        {
            Application.Run(new WelcomeScreen());
        }

        private void ClearTemps()
        {
            if (Directory.Exists(Constants.tempPath))
                Directory.Delete(Constants.tempPath, true);
            if (Directory.Exists(Constants.updateTempPath))
                Directory.Delete(Constants.updateTempPath, true);
        }

        private string VersionWithPaddingZeros(string rawVersionNumber)
        {
            String[] dot = { "." };
            int count = 4;
            string versionNumberWithPadding = string.Empty;

            String[] versionList = rawVersionNumber.Split(dot, count, StringSplitOptions.RemoveEmptyEntries);
            if (versionList[1].Length < 2)
                versionList[1] = string.Format("{0:00}", versionList[1].PadLeft(2, '0'));
            if (versionList[3].Length < 2)
                versionList[3] = string.Format("{0:00}", versionList[3].PadLeft(2, '0'));
            foreach (string s in versionList)
                versionNumberWithPadding = versionNumberWithPadding + s;
            return versionNumberWithPadding;
        }

        private void CheckMFilesUpdates()
        {
            MFilesOperations mFilesOperations = new MFilesOperations();
            string serverVersion = mFilesOperations.GetMFServerVersion();
            
            AzureOperations azureOperations = new AzureOperations();
            string updServerVersion = azureOperations.GetMFilesInstallerDirectoryInAzure();

            uint mFserverVersion = UInt32.Parse(VersionWithPaddingZeros(serverVersion));
            uint updateServerVersion = UInt32.Parse(VersionWithPaddingZeros(updServerVersion));

            if (updateServerVersion > mFserverVersion)
            {
                UpdateMFilesButton.Enabled = true;
                UpdateMFilesButton.Visible = true;
            }
            else
            {
                UpdateMFilesButton.Enabled = false;
                UpdateMFilesButton.Enabled = false;
            }
        }

        private void CheckConnectivityStatusAndPollWinUpdates()
        {
            winUpdateButton.Visible = false;
            if (Connectivity.ConnectivityStatus(connectivityLabel))
            {
                AzureOperations azureOperations = new AzureOperations();
                if (azureOperations.ConnectToAzureFiles())
                    // RefreshAvailableVaultsView();
                if (!checkUpdateWorker.IsBusy)
                    checkUpdateWorker.RunWorkerAsync();
                moreInfoButton.Enabled = true;

            }
            else
            {
                moreInfoButton.Enabled = false;
                enableDisableButton.Enabled = false;
                
            }

        }

        

        private string GetLocalization()
        {
            string cultureInfo = CultureInfo.CurrentCulture.Name;
            string localization;
            switch (cultureInfo)
            {
                case "en-US":
                    localization = "United States";
                    break;
                case "fi-FI":
                    localization = "Finland";
                    break;
                case "en-GB":
                    localization = "United Kingdom";
                    break;
                case "fr-FR":
                    localization = "France";
                    break;
                case "sv-SE":
                    localization = "Sweden";
                    break;
                case "de-DE":
                    localization = "Germany";
                    break;
                default:
                    localization = cultureInfo;
                    break;
            }
            return localization;
          
        }
    
        private void PopulateLocalizations()
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string localizationPath = directory + Constants.localizationPath;
            string fileNameBody = String.Empty;
           
            DirectoryInfo dir = new DirectoryInfo(localizationPath);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                fileNameBody = file.Name.Substring(0, file.Name.Length - 4);
                localizationOptions.Items.Add(fileNameBody);
            }
            localeLabel.Text = CultureInfo.CurrentCulture.NativeName;

        }
        private void PollVaultConnectionsAndCreateXml(string vaultGUID)
        {
            // Check if there is a vault connection for the given Vault GUID exist and there is also conf file for it. 

            // string file = String.Empty;
            MFilesClientApplication oMFClientApp = new MFilesClientApplication();
            VaultConnections vaultConns = oMFClientApp.GetVaultConnections();

            foreach (VaultConnection vaultConnection in vaultConns)
            {
                if (vaultConnection.ServerVaultGUID == vaultGUID)
                {
                    if (GetConfFileNameByGUID(vaultGUID) == String.Empty)
                    {
                        CreateVaultConnectionXmlFromVaultConnection(vaultConnection);
                        break;
                    }
                }
            }
        }

        /*
        private void CheckVaultConnectionXmlFileAndUpdate(VaultConnection vaultConnection)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
            string fullFileName = directory + vaultConnection.ServerVaultName + "_" + vaultConnection.ServerVaultGUID + ".xml";

            MessageBox.Show(fullFileName);

            

            XmlDocument xmlConfFile = new XmlDocument();
            xmlConfFile.Load(fullFileName);

            XmlNode vaultInfo = xmlConfFile["VaultConnections"].AppendChild(xmlConfFile.CreateElement("VaultConnection"));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("VaultDate")).AppendChild(xmlConfFile.CreateTextNode(DateTime.Now.ToString("yyyy-MM-dd")));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("ConnectionName")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.Name));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("InfoTip")).AppendChild(xmlConfFile.CreateTextNode(Constants.infoTip));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("ProtocolSequence")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.ProtocolSequence));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("NetworkAddress")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.NetworkAddress));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("EndPoint")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.Endpoint));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("ServerVaultGUID")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.ServerVaultGUID));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("ServerVaultNamr")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.ServerVaultName));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("AuthType")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.AuthType.ToString()));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("AutoLogin")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.AutoLogin.ToString()));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("EncryptedConnection")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.EncryptedConnection.ToString()));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("UserName")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.UserName));
            vaultInfo.AppendChild(xmlConfFile.CreateElement("Password")).AppendChild(xmlConfFile.CreateTextNode(vaultConnection.Password));

            xmlConfFile.Save(fullFileName);
        }
        */

        private void CreateVaultConnectionXmlFromVaultConnection(VaultConnection vaultConnection)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string authTypeAsNumber = String.Empty;
            


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
            vaultTypeNode.AppendChild(confFile.CreateTextNode("UserMade"));
            descriptionsNode.AppendChild(vaultTypeNode);

            XmlNode vaultConnectionNode = confFile.CreateElement("VaultConnection");
            vaultConnectionsNode.AppendChild(vaultConnectionNode);

            XmlNode vaultDateNode = confFile.CreateElement("VaultDate");
            vaultDateNode.AppendChild(confFile.CreateTextNode(dateToday));
            vaultConnectionNode.AppendChild(vaultDateNode);

            XmlNode connectionNameNode = confFile.CreateElement("ConnectionName");
            connectionNameNode.AppendChild(confFile.CreateTextNode(vaultConnection.Name));
            vaultConnectionNode.AppendChild(connectionNameNode);

            XmlNode infoTipNode = confFile.CreateElement("InfoTip");
            infoTipNode.AppendChild(confFile.CreateTextNode(Constants.infoTip));
            vaultConnectionNode.AppendChild(infoTipNode);

            XmlNode protocolSequenceNode = confFile.CreateElement("ProtocolSequence");
            protocolSequenceNode.AppendChild(confFile.CreateTextNode(vaultConnection.ProtocolSequence));
            vaultConnectionNode.AppendChild(protocolSequenceNode);

            XmlNode networkAddressNode = confFile.CreateElement("NetworkAddress");
            networkAddressNode.AppendChild(confFile.CreateTextNode(vaultConnection.NetworkAddress));
            vaultConnectionNode.AppendChild(networkAddressNode);

            XmlNode endPointNode = confFile.CreateElement("EndPoint");
            endPointNode.AppendChild(confFile.CreateTextNode(vaultConnection.Endpoint));
            vaultConnectionNode.AppendChild(endPointNode);

            XmlNode serverVaultGUIDNode = confFile.CreateElement("ServerVaultGUID");
            serverVaultGUIDNode.AppendChild(confFile.CreateTextNode(vaultConnection.ServerVaultGUID));
            vaultConnectionNode.AppendChild(serverVaultGUIDNode);

            XmlNode serverVaultNameNode = confFile.CreateElement("ServerVaultName");
            serverVaultNameNode.AppendChild(confFile.CreateTextNode(vaultConnection.ServerVaultName));
            vaultConnectionNode.AppendChild(serverVaultNameNode);

            XmlNode authTypeNode = confFile.CreateElement("AuthType");
            MFAuthType authType = vaultConnection.AuthType;
            switch (authType)
            {
                case MFAuthType.MFAuthTypeUnknown:
                    authTypeAsNumber = "0";
                    break;
                case MFAuthType.MFAuthTypeLoggedOnWindowsUser:
                    authTypeAsNumber = "1";
                    break;
                case MFAuthType.MFAuthTypeSpecificWindowsUser:
                    authTypeAsNumber = "2";
                    break;
                case MFAuthType.MFAuthTypeSpecificMFilesUser:
                    authTypeAsNumber = "3";
                    break;
                default:
                    authTypeAsNumber = "1";
                    break;
            }
            authTypeNode.AppendChild(confFile.CreateTextNode(authTypeAsNumber));
            vaultConnectionNode.AppendChild(authTypeNode);

            XmlNode autoLoginNode = confFile.CreateElement("AutoLogin");
            autoLoginNode.AppendChild(confFile.CreateTextNode(Constants.autoLogin));
            vaultConnectionNode.AppendChild(autoLoginNode);

            XmlNode encryptedConnectionNode = confFile.CreateElement("EncryptedConnection");
            encryptedConnectionNode.AppendChild(confFile.CreateTextNode(Constants.encryptedConnection));
            vaultConnectionNode.AppendChild(encryptedConnectionNode);

            XmlNode userNameNode = confFile.CreateElement("UserName");
            userNameNode.AppendChild(confFile.CreateTextNode(vaultConnection.UserName));
            vaultConnectionNode.AppendChild(userNameNode);

            XmlNode passwordNode = confFile.CreateElement("Password");
            passwordNode.AppendChild(confFile.CreateTextNode(vaultConnection.Password));
            vaultConnectionNode.AppendChild(passwordNode);

            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath + vaultConnection.ServerVaultName + "_" + vaultConnection.ServerVaultGUID + ".xml";


            confFile.Save(fileName);

        }

        private void removeFromDemoButton_Click(object sender, EventArgs e)
        {
            // string removeMessage = String.Empty;
            string vaultName = String.Empty;
            string vaultGUID = String.Empty;
            try
            {
                if (listCurrentVaults.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You need first select vault to be removed!");
                    return;
                }

                vaultName = listCurrentVaults.SelectedItems[0].SubItems[Constants.vaultNameInfoLocation].Text;
                vaultGUID = listCurrentVaults.SelectedItems[0].SubItems[Constants.vaultGUIDInfoLocation].Text;

                // MessageBox.Show(vaultName + "--" + vaultGUID);
                
                // removeMessage = "The following vaults will be deleted (Destroyed) completely from Demo Environment:\r\n" + vaultName;
                DialogResult dialogResult = MessageBox.Show(String.Format(Constants.removeVaultMessage, vaultName), Constants.vaultDestroyingHeaderMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteVault(vaultName, vaultGUID, true);
                    Refresh();
                    // MessageBox.Show("Operation completed.");
                }
                else
                {
                    listCurrentVaults.SelectedItems.Clear();
                    return;
                }
                RefreshVaultView();
                // RefreshAvailableVaultsView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        /*
        private void restoreFromBackUpButton_Click(object sender, EventArgs e)
        {
            snapshotToolForm SnapshotToolForm = new snapshotToolForm();
            SnapshotToolForm.Show();
        }

            */

        protected void checkUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender; // Capture the BackgroudWorker that fired the event
            var updateSession = new UpdateSession();
            var updateSearcher = updateSession.CreateUpdateSearcher();
            updateSearcher.Online = true;

            try
            {
                var searchResult = updateSearcher.Search("IsInstalled = 0 And IsHidden = 0 And BrowseOnly = 0");
                if (searchResult.Updates.Count > 0)
                {
                    winUpdateButton.Text = "  Windows Updates\r\nAvailable (" + searchResult.Updates.Count.ToString() + ")";
                    if (searchResult.Updates.Count >= 10) // If there are 10 or more updates, change the Button backcolor red.
                    {
                        winUpdateButton.BackColor = Color.Red;
                    }
                    else
                    {
                        winUpdateButton.BackColor = Color.Blue;
                    }
                    
                        winUpdateButton.Enabled = true;
                        winUpdateButton.Visible = true;
                        windowsUpdates.Clear();
                        foreach (IUpdate update in searchResult.Updates)
                        {
                            windowsUpdates.Add(update.Title);
                        }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void checkUpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            return;
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


        

        

        

        private void listCurrentVaults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listAvailableVaults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Close the application", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }

        public void RefreshVaultView()
        {
            string confFilename = String.Empty;
            string vaultVersion = String.Empty;
            string vaultDate = String.Empty;
            string directory = String.Empty;
            string defaultVault = String.Empty;
            string vaultType = String.Empty;
            UserMessages msg = new UserMessages();

            listCurrentVaults.Items.Clear();
            listCurrentVaults.MultiSelect = false;
            listCurrentVaults.FullRowSelect = true;
            msg.ShowRestoreVaultMessage(false, prgLabel);
            msg.ShowBuildingSnapshotMessage(false, prgLabel);
            msg.ShowCopyingVaultMessage(false, prgLabel);
            msg.ShowSafetyBackupMessage(false, prgLabel);

            listCurrentVaults.Columns[0].ListView.Font = new Font(listCurrentVaults.Columns[0].ListView.Font, FontStyle.Bold);

            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();

            directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;

            VaultsOnServer oVaults = oMFServerApp.GetVaults();
            foreach (VaultOnServer oOneVault in oVaults)
            {
                ListViewItem vault = new ListViewItem(oOneVault.Name);

                // Check if there is XML configuration file with the same GUID than the vault in server. If the GUID is found, then the vault
                // is considered to be the default vault although user may have been changed the vault name. 

                confFilename = GetConfFileNameByGUID(oOneVault.GUID);

                if (confFilename != String.Empty)
                {
                    vaultType = ReadVaultData(confFilename, "vaulttype");
                    if (vaultType == "LocalDefault" || vaultType == "CloudDefault")
                        defaultVault = "Default";
                    else if (vaultType == "UserMade")
                        defaultVault = "User Made";
                    else if (vaultType == "LocalCopy")
                        defaultVault = "Copied";
                    vaultVersion = ReadVaultData(confFilename, "version");
                    vaultDate = ReadVaultData(confFilename, "date");
                }
                else
                {
                    defaultVault = "User Made";
                    vaultVersion = "-";
                    vaultDate = "-";
                    PollVaultConnectionsAndCreateXml(oOneVault.GUID);
                               
                }

                vault.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
                if (oMFServerApp.GetOnlineVaults().GetVaultIndexByGUID(oOneVault.GUID) != -1)
                {
                    vault.ForeColor = Color.Green;
                }
                vault.SubItems.Add(vaultVersion);
                vault.SubItems.Add(defaultVault);
                vault.SubItems.Add(vaultDate);
                vault.SubItems.Add(oOneVault.GUID);
                listCurrentVaults.Items.Add(vault);
                listCurrentVaults.SelectedItems.Clear();
            }
        }
                       

        private void CopyVaultConfigs(string configPath)
        {
            string sourceFile = null;
            string destFile = null;
            try
            {
                configPath = configPath + "Configs\\";
                DirectoryInfo dirInfo = new DirectoryInfo(configPath);

                FileInfo[] filesXML = dirInfo.GetFiles("*.xml");
                foreach (FileInfo file in filesXML)
                {
                    sourceFile = Path.Combine(file.DirectoryName + "\\" + file.Name);
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
                    destFile = Path.Combine(directory, file.Name);
                    File.Copy(sourceFile, destFile, true);
                    // Remove Read Only attribute from the files copied to the directory
                    FileInfo dFile = new FileInfo(destFile);
                    dFile.IsReadOnly = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
        /*
        private void DeleteVaultConfigs(string vaultName)
        {
            try
            {
                vaultName = vaultName + "*.*";
                string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
                foreach (string file in Directory.GetFiles(directory, vaultName))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
        */


        private struct VaultPropertiesExt
        {
            public MFilesAPI.VaultProperties vaultProperties;
            public string fullPath;
        }

        private struct BackUpVault
        {
            public string name;
            public string GUID;
        }

        private struct RepositoryVault
        {
            public bool vaultExistInEnv;
            public string vaultVersion;
            public string vaultDate;
            public string vaultGUID;
            public bool takeSafetyBackup;
        }

        private List<string> windowsUpdates = new List<string>();

        private string GetMFClientVersion()
        {
            MFilesClientApplication mFClient = new MFilesClientApplication();
            return mFClient.GetClientVersion().Display;
        }

        

        private void enableDisableButton_Click(object sender, EventArgs e)
        {
            VaultDownload vaultDownload = new VaultDownload(this);
            vaultDownload.Show();
        }

        private void moreInfoButton_Click(object sender, EventArgs e)
        {
            string vaultName = String.Empty;
            string vaultGUID = String.Empty;
            string vaultDescription = String.Empty;
            string destFile = String.Empty;
            string[] filesInDir;
            char[] delimitChars = { '{', '}' };
            string xmlFile = String.Empty;

            if (listCurrentVaults.SelectedItems.Count !=0 )
            {
                try
                {
                    vaultName = listCurrentVaults.SelectedItems[0].Text;
                    vaultGUID = listCurrentVaults.SelectedItems[0].SubItems[Constants.vaultGUIDInfoLocation].Text; // note that vault GUID is stored to ListView 
                    listCurrentVaults.SelectedItems.Clear();
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;
                    filesInDir = Directory.GetFiles(directory);
                    foreach (string filename in filesInDir)
                    {
                        string[] splitText = filename.Split(delimitChars);
                        string guid = "{" + splitText[1] + "}";
                        if (guid == vaultGUID)
                        {
                            destFile = filename;
                            break;
                        }                    
                    }
                    if (!File.Exists(destFile))
                    {
                        MessageBox.Show("There is no description available for vault " + vaultName + ".");
                        return;
                    }
                    vaultDescription = ReadVaultData(destFile, "description");
                    vaultDescription = "microsoft-edge:" + vaultDescription;
                    Process.Start(vaultDescription);
                    // Process.Start("MicrosoftEdge.exe", ReadVaultData(destFile, "description"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select first the Vault from the list.");
                return;
            }
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


        /*
        private void updateMFilesButton_Click(object sender, EventArgs e)
        {
            UpdateMFiles UpdateMFiles = new UpdateMFiles();
            UpdateMFiles.Show();
        }
        */


        private void ButtonsEnabled(bool state)
        {

          
            enableDisableButton.Enabled = state;
            moreInfoButton.Enabled = state;
            closeButton.Enabled = state;
            restoreFromBackUpButton.Enabled = state;
            winUpdateButton.Enabled = state;
            refreshButton.Enabled = state;
            UpdateMFilesButton.Enabled = state;


        }

        private string GetTimeStamp()
        {
            string returnValue;

            DateTime dateTimeNow = DateTime.Now;
            returnValue = dateTimeNow.Year + "-" + dateTimeNow.Month + "-" + dateTimeNow.Day + "-";
            returnValue = returnValue + dateTimeNow.Hour + "-" + dateTimeNow.Minute + "-" + dateTimeNow.Second;

            return returnValue;
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

        private void winUpdateButton_Click(object sender, EventArgs e)
        {
            string winUpdateMessage = "There are following Windows updates available: \r\n\r\n";
            string winUpdateMessagePart = "";
            foreach (string winUpd in windowsUpdates)
            {
                winUpdateMessagePart = winUpdateMessagePart + winUpd + "\r\n";
            }
            winUpdateMessage = winUpdateMessage + winUpdateMessagePart + "\r\n\r\n" + "Do you want to close Demo Vault Tool and go to Windows Update?\r\n\r\nNote that the Update procedure can take even hours depending on the amount of updates etc.";
            DialogResult dialogResult = MessageBox.Show(winUpdateMessage, "Windows Updates Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                string startUpdText = "/name Microsoft.WindowsUpdate";
                Process.Start("C:\\Windows\\System32\\control.exe", startUpdText);
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UserMessages msg = new UserMessages();
            MFilesOperations mFilesOperations = new MFilesOperations();
            CheckConnectivityStatusAndPollWinUpdates();
            RefreshVaultView();
            ClearTemps();
            CheckMFilesUpdates();
            msg.ShowClientRestartMessage(true, prgLabel);
            mFilesOperations.RestartMFClientService();
            msg.ShowClientRestartMessage(false, prgLabel);
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void localizationOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newLocation = localizationOptions.SelectedItem.ToString();

            string locMsg = "You are about to change the Demo Environment location to " + newLocation + ".\r\nThe Demo Environment will be restarted during the process." +
                "\r\n\r\nDo you want to perform the localization change?";
            DialogResult dialogResult = MessageBox.Show(locMsg, "Localization Change", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                string fullFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.localizationPath + newLocation + ".PS1";
                string pSScript = File.ReadAllText(fullFileName);
                using (PowerShell pSInstance = PowerShell.Create())
                {
                    pSInstance.AddScript(pSScript);
                    pSInstance.Invoke();
                }
                Process.Start("shutdown.exe", "-r -t 5");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation cancelled.");
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private string GetPartFromConfFileName(string fullFilename, string part)
        {
            // Returns Name or GUID from the filename <Name>_<GUID>.xml
            // If part = "name", return Name
            // If part = "guid", return GUID

            string retValue = String.Empty;

            char[] delimitChar = { '_' };

            string filename = Path.GetFileName(fullFilename);
            string[] name = filename.Split(delimitChar);

            switch (part)
            {
                case "name":
                    retValue = name[0];
                    break;
                case "guid":
                    retValue = name[1];
                    break;
            }
            return retValue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateMFiles_Click(object sender, EventArgs e)
        {
            string updMsg = "There is M-Files update available.\r\nDo you want to close Demo Vault Tool and start M-Files Installer download?";
            DialogResult dialogResult = MessageBox.Show(updMsg, "M-Files Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                UpdateMFiles UpdateMFiles = new UpdateMFiles();
                UpdateMFiles.FormClosed += new FormClosedEventHandler(UpdateMFiles_FormClosed);
                UpdateMFiles.Show();
                this.Hide();
            }
            else
                return;
        }

        private void UpdateMFiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void restoreFromBackUpButton_Click(object sender, EventArgs e)
        {
            snapshotToolForm snapshotTool = new snapshotToolForm(this);
            snapshotTool.Show();
        }

        private void removeVaultButton_Click(object sender, EventArgs e)
        {
            string vaultName = String.Empty;
            string vaultGUID = String.Empty;

            try
            {
                if (listCurrentVaults.SelectedItems.Count == 0)
                {
                    MessageBox.Show(Constants.removeVaultSelectionEmptyMessage);
                    return;
                }

                vaultName = listCurrentVaults.SelectedItems[0].SubItems[Constants.vaultNameInfoLocation].Text;
                vaultGUID = listCurrentVaults.SelectedItems[0].SubItems[Constants.vaultGUIDInfoLocation].Text;

                DialogResult dialogResult = MessageBox.Show(String.Format(Constants.removeVaultMessage, vaultName),
                    Constants.vaultDestroyingHeaderMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteVault(vaultName, vaultGUID, true);
                    Refresh();
                }
                else
                {
                    listCurrentVaults.SelectedItems.Clear();
                    return;
                }

                RefreshVaultView();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void connectionsButton_Click(object sender, EventArgs e)
        {
            enableDisableForm enabledisable = new enableDisableForm(this);
            enabledisable.Show();
        }


    }
       
}


