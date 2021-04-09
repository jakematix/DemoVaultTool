

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
        // public const string vaultConfigurationPath = "C:\\MFDE Utilities\\VaultConfigurations\\";
        // public const string regPath = "C:\\MFDE Utilities\\VaultConfigurations\\RegistrySettings\\";
        public const string xmlVaultConfPath = "\\M-Files\\Demo Vault Tool\\VaultConf\\";
        public const int vaultNameInfoLocation = 0; // denotes column index "Vault Name" in Currently Installed Vaults view
        public const int versionInfoLocation = 1; // denotes column index "Version" in Currently Installed Vaults view
        public const int defaultInfoLocation = 2; // denotes column index "Default" in Currently Installed Vaults view
        public const int dateInfoLocation = 3; // denotes column index "Creation Date" in Currently Installed vaults view
        public const int vaultGUIDInfoLocation = 4; // denotes hidden columns index "Vault GUID" in Currently Installed Vaults view.
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
        public const string mFilesInstallerDirectoryNameInAzure = "MFilesInstallers";
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
        public const string selectVaultToBeDownloaded = "You must first select the vault to be installed in the Demo Environment!";






        // ------------------------------------------------------------------------------------------------------------------------------




    }
}
