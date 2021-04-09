using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public class UserMessages
    {
 
        public void ShowCopyingVaultMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.copyingVaultFromRepoMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowRestoreVaultMessage(bool state, Label label)
        {

            if (state)
                label.Text = Constants.vaultRestoreMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowMFilesVersion(bool state, Label label, string mFVersionNumber)
        {
            if (state)
                label.Text = mFVersionNumber;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowBuildingSnapshotMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.snapshotBuildingMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowSafetyBackupMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.safetyBackupMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowClientRestartMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.clientRestartMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowErrorDuringOperation(bool state, Label label)
        {
            if (state)
                label.Text = Constants.errorDuringOperation;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowEnablingVaultConnectionMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.enablingVaultConnectionMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowVaultCopyMessage(bool state, Label label, string originalVaultName, string copyVaultName)
        {
            if (state)
                label.Text = Constants.copyVault + originalVaultName + " --> " + copyVaultName;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowCopyVaultBackUpMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.copyVaultBackupMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowDownloadInstallerMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.downloadingInstallerMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowInstallerDownloadCompleted(bool state, Label label)
        {
            if (state)
                label.Text = Constants.installerDownloadCompletedMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowInstallerDownloadError(bool state, Label label)
        {
            if (state)
                label.Text = Constants.installerDownloadErrorMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowVaultCopyCompletedMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.vaultCopyCompletedMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        
        public void ShowVaultOnlineMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.vaultOnlineMessage;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ShowVaultOffilineMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.vaultOfflineMessage;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }
        
        public void ShowClosingOfflineVaultsMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.closingOnlineVaultsMessage;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }
        public void RestoreBackUpVaultsProgress(bool state, int value, ToolStripStatusLabel label)
        {
            if (state)
                label.Text = Constants.restoreBackUpVaultsProcessed + value + "% ...";
            else
                label.Text = String.Empty;
            label.Visible = state;
            
        }

        public void CopyVaultProgress(bool state, int value, ToolStripStatusLabel label)
        {
            if (state)
                label.Text = Constants.copyingVaultProgress + value + "% done...";
            else
                label.Text = String.Empty;
            label.Visible = state;
            
        }

        public void InstallerDownloadProgress(bool state, int value, ToolStripStatusLabel label)
        {
            if (state)
                label.Text = Constants.downloadingInstallerProgress + value + "% done...";
            else
                label.Text = String.Empty;
            label.Visible = state;
            
        }

        public void VaultIsRestarting(bool state, Label label)
        {
            if (state)
                label.Text = Constants.vaultIsRestartingMessage;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void LicenseIsUpdating(bool state, Label label)
        {
            if (state)
                label.Text = Constants.applicationLicenseIsUpdating;
            else
                label.Text = String.Empty;
            label.Visible = state;
            label.Refresh();
        }

        public void ClearAllMessages(Label label, ToolStripLabel tLabel)
        {
            label.Text = String.Empty;
            tLabel.Text = String.Empty;
            label.Refresh();
        }
        
        public void ClearAllMessages(Label label)
        {
            label.Text = String.Empty;
            label.Refresh();
        }
        
        public void ClearAllMessages(ToolStripLabel tLabel)
        {
            tLabel.Text = String.Empty;
        }

        
    }
}
