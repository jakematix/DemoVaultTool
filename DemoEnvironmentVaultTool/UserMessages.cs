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
        }

        public void ShowRestoreVaultMessage(bool state, Label label)
        {

            if (state)
                label.Text = Constants.vaultRestoreMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowBuildingSnapshotMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.snapshotBuildingMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowSafetyBackupMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.safetyBackupMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowClientRestartMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.clientRestartMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowErrorDuringOperation(bool state, Label label)
        {
            if (state)
                label.Text = Constants.errorDuringOperation;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowEnablingVaultConnectionMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.enablingVaultConnectionMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowVaultCopyMessage(bool state, Label label, string originalVaultName, string copyVaultName)
        {
            if (state)
                label.Text = Constants.copyVault + originalVaultName + " --> " + copyVaultName;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowCopyVaultBackUpMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.copyVaultBackupMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowDownloadInstallerMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.downloadingInstallerMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowInstallerDownloadCompleted(bool state, Label label)
        {
            if (state)
                label.Text = Constants.installerDownloadCompletedMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowInstallerDownloadError(bool state, Label label)
        {
            if (state)
                label.Text = Constants.installerDownloadErrorMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
        }

        public void ShowVaultCopyCompletedMessage(bool state, Label label)
        {
            if (state)
                label.Text = Constants.vaultCopyCompletedMsg;
            else
                label.Text = String.Empty;
            label.Visible = state;
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

        public void ClearAllMessages(Label label, ToolStripLabel tLabel)
        {
            label.Text = String.Empty;
            tLabel.Text = String.Empty;
        }
        
        public void ClearAllMessages(Label label)
        {
            label.Text = String.Empty;
        }
        
        public void ClearAllMessages(ToolStripLabel tLabel)
        {
            tLabel.Text = String.Empty;
        }

        
    }
}
