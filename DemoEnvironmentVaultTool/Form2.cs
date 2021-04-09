using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using MFilesAPI;

namespace DemoEnvironmentVaultTool
{
    public partial class enableDisableForm : Form
    {
        Form1 mainForm;
        public enableDisableForm(Form1 incomingForm)
        {
            mainForm = incomingForm;
            InitializeComponent();
            this.MinimumSize = new Size(755, 525);
            this.MaximumSize = new Size(755, 525);
            RefreshAllVaultConnections();

            RefreshEnabledVaults();
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            string vName = availableVaults.SelectedItems[0].SubItems[2].Text; // Full file name is stored to listView availableVaults.

            string iFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                Constants.xmlVaultConfPath + vName + ".ico";

            ButtonsEnabled(false);
            CreateVaultConnection(vName, iFile);
            ButtonsEnabled(true);
            mainForm.RefreshVaultView();
        }

        private void disableButton_Click(object sender, EventArgs e)
        {
            string connName = enabledVaults.SelectedItems[0].Text;
            ButtonsEnabled(false);
            RemoveVaultConnection(connName);
            ButtonsEnabled(true);
            mainForm.RefreshVaultView();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {


            this.Close();

        }

        private void RefreshAllVaultConnections()
        {
            string[] filesInDir;
            char[] delimitChar = { '_' };
            string xmlFile = String.Empty;
            string vaultLocation = String.Empty;
            string vaultType = String.Empty;
            string connectionName = String.Empty;
            string connectionGUID = String.Empty;

            availableVaults.Items.Clear();
            availableVaults.MultiSelect = false;
            availableVaults.FullRowSelect = true;
            bool internetConnection = Connectivity.InternetConnectivity();

            availableVaults.Columns[0].ListView.Font = new Font(availableVaults.Columns[0].ListView.Font, FontStyle.Bold);
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath;

            filesInDir = Directory.GetFiles(directory);
            foreach (string fullFilename in filesInDir)
            {
                string fileName = Path.GetFileName(fullFilename);
                string[] splitText = fileName.Split(delimitChar);
                connectionName = splitText[0];
                connectionGUID = splitText[1];
                int dotXML = connectionGUID.IndexOf(".");
                connectionGUID = connectionGUID.Remove(dotXML, 4);

                foreach (var element in XmlHelper.StreamConnections(fullFilename))
                {
                    // vaultLocation = element.NetworkAddress;
                    vaultType = element.VaultType;
                    break;
                }

                ListViewItem connection = new ListViewItem(connectionName);
                connection.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                connection.ForeColor = Color.Black;

                if (vaultType == "LocalCopy" || vaultType == "LocalDefault" || vaultType == "UserMade")
                {
                    vaultLocation = "Local";


                }
                else if (vaultType == "CloudDefault")
                {
                    vaultLocation = "Cloud";
                    if (!internetConnection)
                        connection.ForeColor = Color.Red;
                }
                else
                {
                    vaultLocation = "N/A";
                } 

                // If there is NOT a vault with the same GUID, don't show the connection even though there is a connection XML (just in case)

                if (vaultLocation == "Cloud" || ((vaultLocation == "Local" || vaultLocation == "N/A") && VaultExist(connectionGUID)))
                { 
                    connection.SubItems.Add(vaultLocation);
                    connection.SubItems.Add(fullFilename); // full file name with folder path is also stored
                    availableVaults.Items.Add(connection);
                }
            }
        }

        private bool VaultExist(string GUID)
        {
            bool found = false;
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            VaultsOnServer oVaults = oMFServerApp.GetVaults();
            foreach (VaultOnServer oVault in oVaults)
                if (oVault.GUID == GUID)
                {
                    found = true;
                    break;
                }
            return found;
        }

        private void CreateVaultConnection(string xmlFile, string iconFile)
        {
            UserMessages msg = new UserMessages();
            // Vault connection
            MFilesClientApplication oMFClientApp = new MFilesClientApplication();
            // Get M-Files Server App and login
            Vault oVault = new Vault();
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection(); 
            // MFilesServerApplication oMFServerApp = GetMFServerConnection();
            VaultConnection vConn = new VaultConnection();

            // xmlFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Constants.xmlVaultConfPath + xmlFile;

            // Read vault connection properties from XML file and assign them to VaultConnection().
            msg.ShowEnablingVaultConnectionMessage(true, progLabel);

            Refresh();
            foreach (var element in XmlHelper.StreamConnections(xmlFile))
            {
                vConn.Name = element.ConnectionName;
                vConn.ProtocolSequence = element.ProtocolSequence;
                vConn.NetworkAddress = element.NetworkAddress; 
                vConn.Endpoint = element.EndPoint; 
                vConn.ServerVaultGUID = element.ServerVaultGUID; 
                vConn.ServerVaultName = element.ServerVaultName; 
                switch (element.AuthType)
                {
                    case 0:
                        vConn.AuthType = MFAuthType.MFAuthTypeUnknown;
                        break;
                    case 1:
                        vConn.AuthType = MFAuthType.MFAuthTypeLoggedOnWindowsUser;
                        break;
                    case 2:
                        vConn.AuthType = MFAuthType.MFAuthTypeSpecificWindowsUser;
                        break;
                    case 3:
                        vConn.AuthType = MFAuthType.MFAuthTypeSpecificMFilesUser;
                        break;
                }
                vConn.AutoLogin = element.AutoLogin;
                vConn.EncryptedConnection = element.EncryptedConnection;

                vConn.UserSpecific = false;
                vConn.UserName = element.UserName; 
                vConn.Password = element.Password;
                /*
                MessageBox.Show("Connection Name: " + vConn.Name + "\r\n" +
                    "Protocol Sequence: " + vConn.ProtocolSequence + "\r\n" +
                    "Network Address: " + vConn.NetworkAddress + "\r\n" +
                    "Endpoint: " + vConn.Endpoint + "\r\n" +
                    "ServerVaultGUID: " + vConn.ServerVaultGUID + "\r\n" +
                    "ServerVaultName: " + vConn.ServerVaultName + "\r\n" +
                    "Authtype: " + vConn.AuthType + "\r\n" +
                    "Autologin: " + vConn.AutoLogin + "\r\n" +
                    "EncryptedConnection: " + vConn.EncryptedConnection + "\r\n" +
                    "Username: " + vConn.UserName + "\r\n" +
                    "Password: " + vConn.Password);
                */

            
                
                // Check if the vault is offline AND vault is in localhost, take it online
                if ((oMFServerApp.GetOnlineVaults().GetVaultIndexByGUID(vConn.ServerVaultGUID) == -1) && (vConn.NetworkAddress == "localhost"))
                {
                    oMFServerApp.VaultManagementOperations.BringVaultOnline(vConn.ServerVaultGUID);
                }
                try
                {

                    oMFClientApp.AddVaultConnection(vConn);
                    oVault = vConn.BindToVault(this.Handle, true, false);
                    RefreshEnabledVaults();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // progLabel.Visible = false;
            msg.ShowEnablingVaultConnectionMessage(false, progLabel);
            MFilesOperations mFilesOperations = new MFilesOperations();
            msg.ShowClientRestartMessage(true, progLabel);
            mFilesOperations.RestartMFClientService();
            msg.ClearAllMessages(progLabel);
            availableVaults.SelectedItems.Clear();
            MessageBox.Show("Connection to vault " + vConn.ServerVaultName + " enabled.");

            Refresh();
        }

        private void RemoveVaultConnection(string connectionName)
        {
            UserMessages msg = new UserMessages();
            MFilesOperations mFilesOperations = new MFilesOperations();
            // 1. If vault is Online, take if Offline
            // 2. Remove all vault connections from the Vault (based on Vault GUID).

            // Vault connection
            MFilesClientApplication oMFClientApp = new MFilesClientApplication();
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            // MFilesServerApplication oMFServerApp = GetMFServerConnection();       
            VaultConnection connection = oMFClientApp.GetVaultConnection(connectionName);

            // Check what vault connections the Vautl have based on its GUID.
            string vaultGUID = connection.ServerVaultGUID;
            VaultConnections vaultConnections = oMFClientApp.GetVaultConnectionsWithGUID(vaultGUID);


            // 1. If vault is Online, take if Offline
            if (oMFServerApp.GetOnlineVaults().GetVaultIndexByGUID(connection.ServerVaultGUID) != -1)
                oMFServerApp.VaultManagementOperations.TakeVaultOffline(connection.ServerVaultGUID, true);

            // 2. Remobe all vault connections from the vault based on its GUID.
            foreach (VaultConnection vaultConnection in vaultConnections)
                oMFClientApp.RemoveVaultConnection(vaultConnection.Name, vaultConnection.UserSpecific);

            msg.ShowClientRestartMessage(true, progLabel);
            mFilesOperations.RestartMFClientService();
            msg.ClearAllMessages(progLabel);
            MessageBox.Show("Connection to vault " + connection.ServerVaultName + " disabled.");
            RefreshEnabledVaults();
        }

        private void RefreshEnabledVaults()
        {
            string vaultLocation = String.Empty;
            // Vault connection
            enabledVaults.Items.Clear();
            enabledVaults.MultiSelect = false;
            enabledVaults.FullRowSelect = true;
            bool internetConnection = Connectivity.InternetConnectivity();
            enabledVaults.Columns[0].ListView.Font = new Font(enabledVaults.Columns[0].ListView.Font, FontStyle.Bold);
            MFilesClientApplication oMFClientApp = new MFilesClientApplication();
            VaultConnections vaultConns = oMFClientApp.GetVaultConnections();
            foreach (VaultConnection vaultConn in vaultConns)
            {
                ListViewItem vc = new ListViewItem(vaultConn.Name);
                vc.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                if (vaultConn.NetworkAddress == "localhost")
                    vaultLocation = "Local";
                else
                {
                    vaultLocation = "Cloud";
                    if (!internetConnection)
                        vc.ForeColor = Color.Red;
                }


                vc.SubItems.Add(vaultLocation);
                enabledVaults.Items.Add(vc);

            }
        }

        private byte[] GetBytes(Icon icon)
        {
            MemoryStream stream = new MemoryStream();
            icon.Save(stream);
            return stream.GetBuffer();
        }

        private void ButtonsEnabled(bool state)
        {
            enableButton.Enabled = state;
            disableButton.Enabled = state;
            closeButton.Enabled = state;
        }

        private void availableVaults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enabledVaults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    public class VaultConn
    {
        public string VaultVersion { get; set; }
        public string VaultDescription { get; set; }
        public string VaultType { get; set; }
        public string VaultDate { get; set; }
        public string ConnectionName { get; set; }
        public string InfoTip { get; set; }
        public string ProtocolSequence { get; set; }
        public string NetworkAddress { get; set; }
        public string EndPoint { get; set; }
        public string ServerVaultGUID { get; set; }
        public string ServerVaultName { get; set; }
        public int AuthType { get; set; }
        public bool AutoLogin { get; set; }
        public bool EncryptedConnection { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public static class XmlHelper
    {
        public static IEnumerable<VaultConn> StreamConnections(string uri)
        {
            using (XmlReader reader = XmlReader.Create(uri))
            {
                string vaultVersion = null;
                string vaultDescription = null;
                string vaultType = null;
                string vaultDate = null;
                string connectionName = null;
                string infoTip = null;
                string protocolSequence = null;
                string networkAddress = null;
                string endPoint = null;
                string serverVaultGUID = null;
                string serverVaultName = null;
                int authType = 0;
                bool autoLogin = false;
                bool encryptedConnection = false;
                string username = null;
                string password = null;

                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Descriptions")
                    {

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "VaultVersion")
                            {
                                vaultVersion = reader.ReadElementContentAsString();
                                break;
                            }
                        }

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "VaultDescription")
                            {
                                vaultDescription = reader.ReadElementContentAsString();
                                break;
                            }   
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "VaultType")
                            {
                                vaultType = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Element && reader.Name == "VaultConnection")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "VaultDate")
                            {
                                vaultDate = reader.ReadElementContentAsString();
                                break;
                            }
                        }

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ConnectionName")
                            {
                                connectionName = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "InfoTip")
                            {
                                infoTip = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ProtocolSequence")
                            {
                                protocolSequence = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "NetworkAddress")
                            {
                                networkAddress = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "EndPoint")
                            {
                                endPoint = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ServerVaultGUID")
                            {
                                serverVaultGUID = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ServerVaultName")
                            {
                                serverVaultName = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "AuthType")
                            {
                                authType = reader.ReadElementContentAsInt();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "AutoLogin")
                            {
                                autoLogin = reader.ReadElementContentAsBoolean();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "EncryptedConnection")
                            {
                                encryptedConnection = reader.ReadElementContentAsBoolean();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "UserName")
                            {
                                username = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
                            {
                                password = reader.ReadElementContentAsString();
                                break;
                            }
                        }
                        yield return new VaultConn()
                        {
                            VaultVersion = vaultVersion,
                            VaultDescription = vaultDescription,
                            VaultType = vaultType,
                            VaultDate = vaultDate,
                            ConnectionName = connectionName,
                            InfoTip = infoTip,
                            ProtocolSequence = protocolSequence,
                            NetworkAddress = networkAddress,
                            EndPoint = endPoint,
                            ServerVaultGUID = serverVaultGUID,
                            ServerVaultName = serverVaultName,
                            AuthType = authType,
                            AutoLogin = autoLogin,
                            EncryptedConnection = encryptedConnection,
                            UserName = username,
                            Password = password

                        };
                    }
                }
            }
        }
    }



    public class vConnection
    {
        public string infoTip;
        public string protocolSequence;
        public string networkAddress;
        public string endPoint;
        public string serverVaultGUID;
        public string serverVaultName;
        public int authType;
        public bool autoLogin;
        public string username;
        public string password;
    }
}
