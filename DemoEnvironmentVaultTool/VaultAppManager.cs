using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage.File;
using MFilesAPI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace DemoEnvironmentVaultTool
{
    public partial class VaultAppManager : Form
    {
        private bool iSCollapsedUpd = true;
        private bool isCollapsedLic = true;
        private bool vaultIsOnline = false;
        private string vaultGUID = String.Empty;
        private string vaultName = String.Empty;
        LocalFileOperations localFileOperations = new LocalFileOperations();

        public VaultAppManager(string vGuid, string vName, bool onlineVault)
        {
            InitializeComponent();
            this.MinimumSize = new Size(1385, 565);
            this.MaximumSize = new Size(1385, 565);

            vaultOfflineWorker.DoWork += new DoWorkEventHandler(vaultOfflineWorker_DoWork);
            vaultOfflineWorker.ProgressChanged += new ProgressChangedEventHandler(vaultOfflineWorker_ProgressChanged);
            vaultOfflineWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(vaultOfflineWorker_RunWorkerCompleted);
            oMsgLabel.Visible = false;
            listVaultApps.Items.Clear();
            listVaultApps.MultiSelect = false;
            listVaultApps.FullRowSelect = true;
            listVaultApps.Columns[0].ListView.Font = new Font(listVaultApps.Columns[0].ListView.Font, FontStyle.Bold);
            vaultIsOnline = onlineVault;
            vaultName = vName;
            vaultGUID = vGuid;
            vaultLabel.Text = vName;
            ViewApplications();        
            ButtonState(true);
        }

        private BackgroundWorker vaultOfflineWorker = new BackgroundWorker();

        private void ViewApplications()
        {
            UserMessages msg = new UserMessages();
            listVaultApps.Items.Clear();
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();

            Vault vault = LoginToVault(vaultGUID);

            CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            UserMessages msg = new UserMessages();

            if (vaultIsOnline)
            {
                if (!vaultOfflineWorker.IsBusy)
                {
                    ButtonState(false);
                    msg.ShowClosingOfflineVaultsMessage(true, oMsgLabel);
                    vaultOfflineWorker.RunWorkerAsync();
                }
            }
            this.Close();
        }

        

        private void ListApplications(Vault vault, CustomApplications serverApps, CustomApplications clientApps, string vaultGUID)
        {

            PopulateApplicationView(vault, serverApps, vaultGUID);
            PopulateApplicationView(vault, clientApps, vaultGUID);

        }

        void PopulateApplicationView(Vault vault, CustomApplications vaultApps, string vaultGUID)
        {
           
            foreach (CustomApplication vaultApp in vaultApps)
            {

                // CreateTemp();
                localFileOperations.CreateTemp();
                
                ListViewItem app = new ListViewItem(vaultApp.Name);
                app.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
                app.SubItems.Add(vaultApp.Version);
                if (vaultApp.Enabled)
                    app.SubItems.Add("Enabled");
                else
                    app.SubItems.Add("Disabled");
                MFApplicationLicenseStatus licStatus = vault.CustomApplicationManagementOperations.GetCustomApplicationLicenseStatus(vaultApp.ID);

                if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusNotNeeded)
                {
                    app.SubItems.Add("Not needed");
                }
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusFormatError)
                {
                    app.SubItems.Add("Format Error!");
                }
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusTrial)
                {
                    app.SubItems.Add("Trial");
                }
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusGracePeriod)
                    app.SubItems.Add("To be expired");
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusValid)
                    app.SubItems.Add("Valid");
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusInvalid)
                {
                    app.SubItems.Add("Invalid!");
                }
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusInstalled)
                    app.SubItems.Add("Installed");
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusNotInstalled)
                {
                    app.SubItems.Add("Not installed");
                }
                else if (licStatus == MFApplicationLicenseStatus.MFApplicationLicenseStatusUnknown)
                {
                    app.SubItems.Add("Unknown");
                }
                else
                    app.SubItems.Add("Unknown");

                if (vaultApp.ApplicationType == MFCustomApplicationType.MFCustomApplicationTypeClient)
                    app.SubItems.Add("Client app");
                else if (vaultApp.ApplicationType == MFCustomApplicationType.MFCustomApplicationTypeServer)
                    app.SubItems.Add("Server app");
                else
                    app.SubItems.Add("Unknown");
                VaultApplicationData AppData = new VaultApplicationData(vaultApp.ID, vaultApp.Version);
                string noteMessage = " ";

                if (AppData.UpdAvailable)
                    noteMessage = Constants.applicationUpdateAvailable;
                LicenseData licenseData = new LicenseData(vaultApp.ID, vault);
                if (licenseData.UpdateAvailable)
                    if (AppData.UpdAvailable)
                        noteMessage = noteMessage + " " + Constants.licenseUpdateAvailable;
                    else
                        noteMessage = Constants.licenseUpdateAvailable;
                app.SubItems.Add(noteMessage);

                app.SubItems.Add(vaultApp.ID);
                app.SubItems.Add(vaultGUID);
                listVaultApps.Items.Add(app);
                localFileOperations.ClearTemp();
                // DeleteTemp();
            }
        }


        protected void vaultOfflineWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            oMFServerApp.VaultManagementOperations.TakeVaultOffline(vaultGUID, true);
        }

        protected void vaultOfflineWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UserMessages msg = new UserMessages();
            ButtonState(true);
            msg.ShowClosingOfflineVaultsMessage(false, oMsgLabel);
            this.Close();
        }

        protected void vaultOfflineWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        void ButtonState(bool state)
        {
            updateAppButton.Enabled = 
            updateLicenseButton.Enabled = 
            UpdateLicFromAzureButton.Enabled =
            closeButton.Enabled = 
            updateFromAzureButton.Enabled =
            InstallDropDown.Enabled =
            LicenseButton.Enabled =
            unistallAppButton.Enabled = state;
        }


        private void operationMsgLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateAppButton_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            Vault vault;
            UserMessages msg = new UserMessages();

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\demo.user\Desktop",
                Title = "Browse Application Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "mfappx",
                Filter = "mfappx files (*.mfappx)|*.mfappx|zip files (*.zip)|*.zip",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = false,
                ShowReadOnly = true,


            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                vault = LoginToVault(vaultGUID);
                ButtonState(false);
                vault.CustomApplicationManagementOperations.InstallCustomApplication(fileName);
                msg.VaultIsRestarting(true, oMsgLabel);
                MessageBox.Show(Constants.applicationInstalledMessage); 
                vault.Restart();
                vault = LoginToVault(vaultGUID);
                listVaultApps.Items.Clear();

                CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

                CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                    MFExtApplicationPlatform.MFExtApplicationPlatformNone);

                ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);
                ButtonState(true);
                msg.VaultIsRestarting(false, oMsgLabel);
            }
        }

        private Vault LoginToVault(string guid)
        {
            MFilesServerApplication oMFServerApp = MFilesOperations.GetMFServerConnection();
            return oMFServerApp.LogInToVaultEx(guid);
        }

        private void updateLicenseButton_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            Vault vault;
            UserMessages msg = new UserMessages();
            if (listVaultApps.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.selectApplicationToUpdateLicense);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\demo.user\Desktop",
                Title = "Browse Application License Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "lic",
                Filter = "lic files (*.lic)|*.lic",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = false,
                ShowReadOnly = true,
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonState(false);
                string licString = File.ReadAllText(openFileDialog1.FileName);
                vault = LoginToVault(vaultGUID);
                string applicationID = listVaultApps.SelectedItems[0].SubItems[Constants.appApplicationIDLocation].Text;
                msg.LicenseIsUpdating(true, oMsgLabel);
                vault.CustomApplicationManagementOperations.InstallCustomApplicationLicense(applicationID, licString);
                listVaultApps.Items.Clear();

                CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

                CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                    MFExtApplicationPlatform.MFExtApplicationPlatformNone);

                ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);
                MessageBox.Show(Constants.applicationLicenseUpdatedMessage);
                ButtonState(true);
                msg.LicenseIsUpdating(false, oMsgLabel);

            }

        }

        private void unistallAppButton_Click(object sender, EventArgs e)
        {
            Vault vault;
            UserMessages msg = new UserMessages();
            if (listVaultApps.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.selectApplicationToBeRemoved);
                return;
            }
            vault = LoginToVault(vaultGUID);
            string applicationID = listVaultApps.SelectedItems[0].SubItems[Constants.appApplicationIDLocation].Text;
            ButtonState(false);
            vault.CustomApplicationManagementOperations.UninstallCustomApplication(applicationID);
            msg.VaultIsRestarting(true, oMsgLabel);
            MessageBox.Show(Constants.applicationRemoved);
            vault.Restart();
            vault = LoginToVault(vaultGUID);
            listVaultApps.Items.Clear();
            CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);
            CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);
            ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);

            msg.VaultIsRestarting(false, oMsgLabel);
            ButtonState(true);

        }

        private void updateFromAzureButton_Click(object sender, EventArgs e)
        {
            // if ((listVaultApps.SelectedItems.Count == 0) || (listVaultApps.SelectedItems[0].SubItems[Constants.appVaultNoteLocation].Text != Constants.applicationUpdateAvailable))
            if (listVaultApps.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.selectApplicationToBeUpdated);
                return;
            }

            // CreateTemp();
            localFileOperations.CreateTemp();

            Vault vault;

            string appGuid = listVaultApps.SelectedItems[0].SubItems[Constants.appApplicationIDLocation].Text;
            string appVersion = listVaultApps.SelectedItems[0].SubItems[Constants.appApplicationVersionLocation].Text;
            VaultApplicationData AppData = new VaultApplicationData(appGuid, appVersion);
            AzureOperations azureOperations = new AzureOperations();
            CloudFileDirectory applicationDir = azureOperations.GetApplicationDirectoryInAzure(appGuid);

            string applicationName = AppData.AppName + ".mfappx";
            string tempDestFile = Constants.tempPath + applicationName;

            
            using (var destStream = File.OpenWrite(tempDestFile))
            {
                var sourceFile = applicationDir.GetFileReference(applicationName);
                sourceFile.DownloadToStream(destStream);
            }
            

            DialogResult dialogResult = MessageBox.Show(Constants.questionToProceedToAppUpdate, Constants.vaultAppQuestionCaption, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                localFileOperations.ClearTemp();
                // DeleteTemp();
                return;
            }
            ButtonState(false);
            vault = LoginToVault(listVaultApps.SelectedItems[0].SubItems[Constants.appVaultGUIDLocation].Text);
            UserMessages msg = new UserMessages();
            vault.CustomApplicationManagementOperations.InstallCustomApplication(tempDestFile);
            msg.VaultIsRestarting(true, oMsgLabel);
            vault.Restart();
            vault = LoginToVault(vaultGUID);
            listVaultApps.Items.Clear();

            CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
            MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);
            ButtonState(true);
            msg.VaultIsRestarting(false, oMsgLabel);
            localFileOperations.ClearTemp();
            // DeleteTemp();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iSCollapsedUpd)
            {
                UpdatePanelDropDown.Height += 10;
                if (UpdatePanelDropDown.Size == UpdatePanelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    iSCollapsedUpd = false;
                }
            }
            else
            {
                UpdatePanelDropDown.Height -= 10;
                if (UpdatePanelDropDown.Size == UpdatePanelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    iSCollapsedUpd = true;
                }
            }
        }

        private void InstallDropDown_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LicenseButton_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsedLic)
            {
                LicensePanelDropDown.Height += 10;
                if (LicensePanelDropDown.Size == LicensePanelDropDown.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsedLic = false;
                }
            }
            else
            {
                LicensePanelDropDown.Height -= 10;
                if (LicensePanelDropDown.Size == LicensePanelDropDown.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsedLic = true;
                }
            }
        }

        /*
        private void CreateTemp()
        {
            if (!Directory.Exists(Constants.tempPath))
            {
                Directory.CreateDirectory(Constants.tempPath);
            }
        }

        private void DeleteTemp()
        {
            if (Directory.Exists(Constants.tempPath))
                Directory.Delete(Constants.tempPath, true);
        }
        */


        private void UpdateLicFromAzureButton_Click(object sender, EventArgs e)
        {
            UserMessages msg = new UserMessages();
            string newLicFile = String.Empty;
            if (listVaultApps.SelectedItems.Count == 0)
            {
                MessageBox.Show(Constants.selectApplicationToUpdateLicense);
                return;
            }
            localFileOperations.CreateTemp();
            // CreateTemp();
            Vault vault;
            string applicationID = listVaultApps.SelectedItems[0].SubItems[Constants.appApplicationIDLocation].Text;

            try
            {
                AzureOperations azureOperations = new AzureOperations();

                CloudFileDirectory applicationDir = azureOperations.GetApplicationDirectoryInAzure(applicationID);
                
                msg.LicenseIsUpdating(true, oMsgLabel);
                
                newLicFile = Constants.tempPath + "license.lic";
                msg.LicenseIsUpdating(true, oMsgLabel);
                ButtonState(false);
                using (var destStream = File.OpenWrite(newLicFile))
                {
                    var sourceFile = applicationDir.GetFileReference("license.lic");
                    sourceFile.DownloadToStream(destStream);
                }
                
            }
            catch (Exception ex)
            {
                ButtonState(true);
                msg.LicenseIsUpdating(false, oMsgLabel);
                localFileOperations.ClearTemp();
                // DeleteTemp();
                MessageBox.Show(Constants.somethingWentWrongMessage + ex.Message);
                return;
            }
            string licString = File.ReadAllText(newLicFile);
            vault = LoginToVault(vaultGUID);
            vault.CustomApplicationManagementOperations.InstallCustomApplicationLicense(applicationID, licString);
            listVaultApps.Items.Clear();

            CustomApplications serverVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeServer,
            MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            CustomApplications clientVaultApps = vault.CustomApplicationManagementOperations.GetCustomApplicationsEx2(MFCustomApplicationType.MFCustomApplicationTypeClient,
                MFExtApplicationPlatform.MFExtApplicationPlatformNone);

            ListApplications(vault, serverVaultApps, clientVaultApps, vaultGUID);
            msg.LicenseIsUpdating(false, oMsgLabel);
            MessageBox.Show(Constants.applicationLicenseUpdatedMessage);
            ButtonState(true);
            localFileOperations.ClearTemp();
            // DeleteTemp();
        }
    }

    public class application
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string RequiredMfilesVersion { get; set; }
        
    }

    

    public static class XmlHelperApp
    {
        public static IEnumerable<application> StreamConnections(string uri)
        {
            using (XmlReader xmlReader = XmlReader.Create(uri))
            {
                string guid = null;
                string name = null;
                string version = null;
                string requiredMfilesVersion = null;

                xmlReader.MoveToContent();
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "guid")
                    {
                        guid = xmlReader.ReadElementContentAsString();
                        break;
                    }
                }
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "name")
                    {
                        name = xmlReader.ReadElementContentAsString();
                        break;
                    }
                }
                while (xmlReader.Read())
                { 
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "version")
                    {
                        version = xmlReader.ReadElementContentAsString();
                        break;
                    }
                }
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "required-mfiles-version")
                    {
                        requiredMfilesVersion = xmlReader.ReadElementContentAsString();
                        break;
                    }
                }
                yield return new application()
                {
                    Guid = guid,
                    Name = name,
                    Version = version,
                    RequiredMfilesVersion = requiredMfilesVersion
                };
            }
        }
    }

    public class LicenseData
    {
        public bool UpdateAvailable { get; set; }
        public string LicenseContent { get; set; }

        public LicenseData(string appGuid, Vault vault)
        {
            string licTempDestFile = String.Empty;
            string candidateLicContent = String.Empty;
            string dateRegExpression = @"\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*"; // regular expression string to parse LicenseExpireDate from lic-file.
            string currentLicDateRegExpression = @"(?<=expires:.).*"; // regular expression to get date from application details
            CultureInfo provider = CultureInfo.InvariantCulture;

            AzureOperations azureOperations = new AzureOperations();
            CloudFileDirectory applicationDir = azureOperations.GetApplicationDirectoryInAzure(appGuid);
            if (applicationDir.Exists())
            {
                if (applicationDir.GetFileReference("license.lic").Exists())
                {
                    
                    
                    licTempDestFile = Constants.tempPath + "license.lic";
                    try
                    {
                        using (var destStream = File.OpenWrite(licTempDestFile))
                        {
                            var sourceFile = applicationDir.GetFileReference("license.lic");
                            sourceFile.DownloadToStream(destStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Constants.somethingWentWrongMessage + ex.Message);
                    }
                    
                    candidateLicContent = File.ReadAllText(licTempDestFile);

                    // Search and get date from lic-file using regular expression
                    Regex rg = new Regex(dateRegExpression);
                    Match candidateLicExpirationDateFound = rg.Match(candidateLicContent);
                    string candidateLicExpirationDateString = candidateLicExpirationDateFound.Value.ToString();
                    // Parse date to invariant culture and make it localization independent
                    DateTime candidateLicExpirationDate = DateTime.ParseExact(candidateLicExpirationDateString,
                        new string[] { "dd.MM.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "d.M.yyyy", "M/d/yyyy" },
                        provider, DateTimeStyles.None);
                    
                    // Read detailed license content from the vault application
                    string currentLicContent = vault.CustomApplicationManagementOperations.GetCustomApplicationLicenseDetails(appGuid);
                    // Search and get date from detailed license information using regular expression
                    Regex rg2 = new Regex(currentLicDateRegExpression);
                    Match matchedLicExpirationDateString = rg2.Match(currentLicContent);
                    string currentLicExpirationDateString = matchedLicExpirationDateString.Value.ToString();

                    if (matchedLicExpirationDateString.Success && (currentLicExpirationDateString.Substring(0,7) != "License"))
                    {
                        // Convert string to DateTime.
                        
                        // Trim possible hidden characters out from the date string.
                        string trimmedLicExpirationDateString = new string(currentLicExpirationDateString.Where(c => !char.IsControl(c) && (char.IsLetterOrDigit(c) || char.IsPunctuation(c) ||
                             char.IsSeparator(c) || char.IsSymbol(c) || char.IsWhiteSpace(c))).ToArray());

                        DateTime currentLicExpirationDate = DateTime.ParseExact(trimmedLicExpirationDateString,
                        new string[] { "dd.MM.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "d.M.yyyy", "M/d/yyyy" },
                        provider, DateTimeStyles.None);

                        int diff = DateTime.Compare(candidateLicExpirationDate, currentLicExpirationDate);
                        // If the lic-file contains newer date than the one get in license details in current vault application, there is an update available. 
                        if (DateTime.Compare(candidateLicExpirationDate, currentLicExpirationDate) == 1)
                            this.UpdateAvailable = true;
                        this.LicenseContent = candidateLicContent;
                    }
                }
                else
                {
                    this.UpdateAvailable = false;
                }
            }
            else
            {
                this.UpdateAvailable = false;
            }
        }
    }

    public class VaultApplicationData
    {
        public bool Exist { get; set; }
        public bool UpdAvailable { get; set; }
        public string AppGuid { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string RequiredMFVersion { get; set; }
        

        public VaultApplicationData(string guid, string currentApplicationVersion)
        {
            string requiredMFilesVersion = String.Empty;
            string applicationVersion = String.Empty;
            string applicationName = String.Empty;
            string applicationGuid = String.Empty;
            ulong requiredMFilesVersionAsNumber = 0;
            ulong applicationVersionAsNumber = 0;
            ulong currentApplicationVersionAsNumber = 0;
            string tempDestFile = String.Empty;
            LocalFileOperations localFileOperations = new LocalFileOperations();



            AzureOperations azureOperations = new AzureOperations();
            MFilesOperations mFilesOperations = new MFilesOperations();

            localFileOperations.CreateTemp();
            /*
            if (!Directory.Exists(Constants.tempPath))
            {
                Directory.CreateDirectory(Constants.tempPath);
            }
            */
            CloudFileDirectory applicationDir = azureOperations.GetApplicationDirectoryInAzure(guid);
            string azureDirectory = guid;

            this.Exist = applicationDir.Exists();

            if (applicationDir.Exists())
            {
                
                tempDestFile = Constants.tempPath + "appdef.xml";

                using (var destStream = File.OpenWrite(tempDestFile))
                {
                    var sourceFile = applicationDir.GetFileReference("appdef.xml");
                    sourceFile.DownloadToStream(destStream);
                }
               

                string mFServerVersion = mFilesOperations.GetMFServerVersion();
                ulong mFServerVersionAsNumber = mFilesOperations.MFilesVersionWithPaddingZeros(mFServerVersion);
                foreach (var element in XmlHelperApp.StreamConnections(tempDestFile))
                {
                    applicationGuid = element.Guid;
                    applicationName = element.Name;
                    requiredMFilesVersion = element.RequiredMfilesVersion;
                    applicationVersion = element.Version;
                    break;
                }
                if (requiredMFilesVersion == null)
                {

                    requiredMFilesVersion = mFilesOperations.GetMFServerVersion();
                }
                this.RequiredMFVersion = requiredMFilesVersion;
                this.AppVersion = applicationVersion;
                this.AppName = applicationName;
                this.AppGuid = applicationGuid;

                requiredMFilesVersionAsNumber = mFilesOperations.MFilesVersionWithPaddingZeros(requiredMFilesVersion);

                applicationVersionAsNumber = mFilesOperations.MFilesVersionWithPaddingZeros(applicationVersion);

                currentApplicationVersionAsNumber = mFilesOperations.MFilesVersionWithPaddingZeros(currentApplicationVersion);

                if ((mFServerVersionAsNumber >= requiredMFilesVersionAsNumber) && (applicationVersionAsNumber > currentApplicationVersionAsNumber))
                    this.UpdAvailable = true;
                else
                    this.UpdAvailable = false;
            }
            else
            {
                this.RequiredMFVersion = String.Empty;
                this.AppVersion = String.Empty;
                this.AppName = String.Empty;
                this.AppGuid = String.Empty;
                this.UpdAvailable = false;
            }

        }
    }
}
