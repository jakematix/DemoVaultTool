

using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace DemoEnvironmentVaultTool
{
    static class Constants
    {
        // --------------- Locations and Paths -----------------------------------------------------------------------------------------
        public const string basePath = "\\M-Files\\Demo Vault Tool\\DemoVaultBackups\\";
        public const string safetyBkPath = "\\M-Files\\Demo Vault Tool\\SafetyBackups\\";
        public const string vaultsPath = "C:\\Program Files\\M-Files\\Server Vaults\\";
        public const string tempPath = "C:\\Tools\\Temp\\";
        public const string updateTempPath = "C:\\Tools\\UpdateTemp\\";
        public const string moreInfoPath = "C:\\Tools\\MoreInfoTemp\\";
        public const string localizationPath = "\\M-Files\\Demo Vault Tool\\Localizations\\";
        public const string serverVaultsFolder = "C:\\Program Files\\M-Files\\Server Vaults\\";
        public const string xmlVaultConfPath = "\\M-Files\\Demo Vault Tool\\VaultConf\\";
        public const string vaultDescriptionPath = "\\M-Files\\Demo Vault Tool\\Descriptions\\";
        public const int vaultNameInfoLocation = 0; // denotes column index "Vault Name" in Currently Installed Vaults view
        public const int versionInfoLocation = 1; // denotes column index "Version" in Currently Installed Vaults view
        public const int defaultInfoLocation = 2; // denotes column index "Default" in Currently Installed Vaults view
        public const int dateInfoLocation = 3; // denotes column index "Creation Date" in Currently Installed vaults view
        public const int vaultGUIDInfoLocation = 4; // denotes hidden columns index "Vault GUID" in Currently Installed Vaults view.
        public const int appApplicationIDLocation = 6; // denotes hidden column index "Application ID" in Vault Application Manager view.
        public const int appVaultGUIDLocation = 7; // denotes hidden column index "Vault GUID" in Vault Application Manager view.
        public const int appVaultNoteLocation = 5; // denotes Note column in Vault Application Manager view.
        public const int appApplicationVersionLocation = 1; // denotes Version columns in Vault Application Manager view.
        // ------------------------------------------------------------------------------------------------------------------------------

        // -------------- Connection details --------------------------------------------------------------------------------------------
        public const string userName = "Administrator";
        public const string passWord = "MotSys123";
        public const string protocolSequence = "ncacn_ip_tcp";
        public const string domain = "";
        public const string server = "localhost";
        public const string endPoint = "2266";
        public const string networkAddress = "localhost";
        public const string authType = "1";
        public const string autoLogin = "0";
        public const string encryptedConnection = "0";
        public const string infoTip = "Browse to this folder to view the contents of this document vault.";
        public const string azureShareReference = "democontent";
        public const string vaultDirectoryNameInAzure = "Vaults";
        public const string connectionDataDirectoryNameInAzure = "CloudVaultConnections";
        public const string mFilesInstallerDirectoryNameInAzure = "MFilesInstallers";
        public const string applicationDirectoryNameInAzure = "VaultApplications";
        // ------------------------------------------------------------------------------------------------------------------------------
               
        // -------------- User Messages -------------------------------------------------------------------------------------------------
        public const string copyingVaultFromRepoMsg = "Downloading the selected vault from Repository. Please wait.";
        public const string vaultRestoreMsg = "Restoring vault to M-Files. Please wait.";
        public const string safetyBackupMsg = "Taking Safety Backups from existing vaults. Please wait.";
        public const string snapshotBuildingMsg = "Building Snapshot from the selected vaults. Please wait.";
        public const string copyingMFilesMsg = "Downloading M-Files installer from Repository. Please wait.";
        public const string clientRestartMsg = "M-Files client restarts...";
        public const string copyVaultBackupMsg = "Copy vault - backing up the original vault.";
        public const string restoreBackUpVaultsProcessed = "Vaults processed: ";
        public const string errorDuringOperation = "An error occurred during the operation.";
        public const string copyingVaultProgress = "Downloading vault: ";
        public const string enablingVaultConnectionMsg = "Enabling vault connections. Please wait...";
        public const string vaultConnectionConfFileCopied = "Cloud vault connection configuration downloaded.";
        public const string vaultCopySelectionErrorMsg = "Select only one vault to be downloaded.";
        public const string downloadingInstallerProgress = "Downloading Installer: ";
        public const string downloadingInstallerMsg = "Downloading M-Files Installer from Repository. Please wait.";
        public const string installerDownloadCompletedMsg = "Installer download completed. Startíng M-Files installer...";
        public const string installerDownloadErrorMsg = "An error occurred during the download!";
        public const string connectivityTestSite = "google.com";
        public const string statusConnected = "Connected";
        public const string statusNotConnected = "Not Connected";
        public const string copyVaultNameMissing = "Vault name is missing.";
        public const string vaultToBeCopiedMissing = "You must first select the vault to be copied.";
        public const string severalVaultsToBeCopied = "Select only one vault to be copied.";
        public const string allDataOrStructureOnlyMissing = "You need to choose whether to copy All Data or Structure Only.";
        public const string copyVault = "Copying vault: ";
        public const string vaultCopyCompletedMsg = "Vault copying completed.";
        public const string vaultInstallationHeaderMessage = "Vault Download and Install";
        public const string vaultInstallationReplaceMessage = "You are about to download and install vault {0} from the Vault Library to M-Files.\r\n\r\n" +
            "Note that there is already a vault with same GUID ({1}) and named as {2} in M-Files.\r\n\r\n" +
            "If you continue, the vault will be destroyed and the new vault is installed. " +
            "If you want to save the current vault, use the Snapshot feature to save it first.\r\n\r\n" +
            "Do you still want to continue and install the vault from the Library?";
        public const string vaultInstallationNewMessage = "You are about to download and install vault {0} from the Vault Library to M-Files.\r\n\r\n" +
            "Do you want to continue?";
        public const string removeVaultMessage = "You are about to destroy vault named {0} from Demo Environment.\r\n\r\n" +
            "Do you want to continue?";
        public const string vaultDestroyingHeaderMessage = "Vault Destroying";
        public const string removeVaultSelectionEmptyMessage = "You need first select vault to be removed!";
        public const string restoreVaultNameMissing = "Vault name is missing.";
        public const string snapshotNameMissing = "Snaphot name is missing.";
        public const string snapshotAlreadyExistMessage = "There is already a Snapshot with the same name.";
        public const string snapshotCreationStartedMessage = "Snapshot creation started. Please wait until the operation is completed.";
        public const string selectFirstVaultForSnapshotMessage = "You need to select a vault before proceeding.";
        public const string selectSnapshotMessage = "Select first the Snapshot.";
        public const string snapshotRemovedMessage = "Snapshot is destroyed!";
        public const string operationCancelledMessage = "Operation cancelled!";
        public const string selectVaultToBeDownloaded = "You must first select the vault to be added.";
        public const string needToUpdateMFilesMessage = "The vault you are about to download requires M-Files version {0}.\r\n\r\n" +
            "Please, update M-Files in your Demo Environment.";
        public const string mFilesVersionMismatchTitle = "M-Files version mismatch";
        public const string selectConnectionToBeDownloaded = "You must first select the cloud vault connection to be added.";
        public const string cloudVaultConnectionAdded = "{0} cloud vault connection added.";
        public const string licenseCodeSuccess = "License code changed successfully.";
        public const string licenseCodeError = "Error when changing the license code!";
        public const string licenseCodeFieldEmptyError = "You need to give a license code!";
        public const string licenseExpiredError = "M-Files server license has been expired.\r\nYou need to update Demo License. Click ´Server License´ to update.";
        public const string vaultOnlineMessage = "Bringing the vault Online. Please wait...";
        public const string vaultOfflineMessage = "Taking the vault Offline. Please wait...";
        public const string closingOnlineVaultsMessage = "Taking the online vaults to Offline. Please wait...";
        public const string vaultIsRestartingMessage = "The vault is restarting. Please wait...";
        public const string applicationInstalledMessage = "Application installed. Vault will be restarted.";
        public const string applicationLicenseIsUpdating = "Vault Application License is being updated. Please wait...";
        public const string applicationLicenseUpdatedMessage = "Vault Application License updated.";
        public const string selectApplicationToUpdateLicense = "Select first the application for License update.";
        public const string selectApplicationToBeRemoved = "Select first the application to be removed.";
        public const string applicationRemoved = "Vault Application removed. Vault will be restarted.";
        public const string applicationUpdateAvailable = "Application update available!";
        public const string licenseUpdateAvailable = "License update available!";
        public const string selectApplicationToBeUpdated = "Select first the application to be updated.";
        public const string questionToProceedToAppUpdate = "Application will be updated. Vault is restarted during the operation.\r\n\r\n" +
            "Are you ready to proceed?";
        public const string vaultAppQuestionCaption = "Vault Application Update";
        public const string selectVaultForAppManager = "Select first the vault.";
        public const string somethingWentWrongMessage = "Something went wrong!\r\n\r\n";
        // ------------------------------------------------------------------------------------------------------------------------------
    }
}
