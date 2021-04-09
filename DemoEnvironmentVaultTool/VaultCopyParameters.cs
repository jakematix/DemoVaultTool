using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public partial class VaultCopyParameters : Form
    {
        

        public VaultCopyParameters()
        {
     
            InitializeComponent();
            this.MinimumSize = new Size(582, 284);
            this.MaximumSize = new Size(582, 284);
            // CheckStructureOnly();

        }
        /*
        private void copyApplications_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyApplications.CheckState)
            {
                case CheckState.Checked:
                    this.CopyApplications = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyApplications = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyApplications = false;
                    break;
            }
        }
        */
        /*
        private void copyDocumentProfiles_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyDocumentProfiles.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    CheckPropertyDefinitions(true);
                    this.CopyDocumentProfiles = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyDocumentProfiles = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyDocumentProfiles = false;
                    break;
            }


        }
        */
        /*
        private void copyConnectionsToExternalLocations_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyConnectionsToExternalLocations.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    CheckPropertyDefinitions(true);
                    CheckClassesAndClassGroups(true);
                    CheckUsersAndUserGroups(true);
                    CheckWorkflows(true);
                    CheckContentsOfValueLists(true);
                    CheckDocumentsAndOtherObjects(true);
                    this.CopyConnectionsToExternalLocations = true;
                    break;
                case CheckState.Unchecked:
                    CheckDocumentsAndOtherObjects(false);
                    this.CopyConnectionsToExternalLocations = false;
                    break;
                case CheckState.Indeterminate:
                    CheckDocumentsAndOtherObjects(false);
                    this.CopyConnectionsToExternalLocations = false;
                    break;
            }
        }
        */
        /*
        private void copyValueListContent_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyValueListContent.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    this.CopyValueListContent = true;
                    break;
                case CheckState.Unchecked:
                    CheckDocumentsAndOtherObjects(false);
                    CheckConnectionsToExternalSources(false);
                    this.CopyValueListContent = false;
                    break;
                case CheckState.Indeterminate:
                    CheckDocumentsAndOtherObjects(false);
                    CheckConnectionsToExternalSources(false);
                    this.CopyValueListContent = false;
                    break;
            }
        }
        */
        /*
        private void copyDocuments_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyDocuments.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    CheckPropertyDefinitions(true);
                    CheckDocumentsAndOtherObjects(true);
                    CheckUsersAndUserGroups(true);
                    CheckWorkflows(true);
                    CheckConnectionsToExternalSources(true);
                    CheckContentsOfValueLists(true);
                    this.CopyDocuments = true;
                    copyFileContent.Enabled = true;
                    break;
                case CheckState.Unchecked:
                    copyFileContent.CheckState = CheckState.Unchecked;
                    copyFileContent.Enabled = false;
                    CheckConnectionsToExternalSources(false);
                    this.CopyDocuments = false;
                    break;
                case CheckState.Indeterminate:
                    copyFileContent.CheckState = CheckState.Unchecked;
                    copyFileContent.Enabled = false;
                    CheckConnectionsToExternalSources(false);
                    this.CopyDocuments = false;
                    break;
            }
        }
        */
        /*
        private void copyFileContent_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyFileContent.CheckState)
            {
                case CheckState.Checked:
                    this.CopyFileContent = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyFileContent = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyFileContent = false;
                    break;
            }
        }
        */
        /*

        private void copyInternalEventHandlers_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyInternalEventHandlers.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    CheckPropertyDefinitions(true);
                    CheckClassesAndClassGroups(true);
                    this.CopyInternalEventHandlers = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyInternalEventHandlers = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyInternalEventHandlers = false;
                    break;
            }
        }
        */
        /*
        private void copyEventLog_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyEventLog.CheckState)
            {
                case CheckState.Checked:
                    this.CopyEventLog = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyEventLog = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyEventLog = false;
                    break;
            }
        }
        */
        /*
        private void copyLanguagesAndTranslations_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyLanguagesAndTranslations.CheckState)
            {
                case CheckState.Checked:
                    this.CopyLanguagesAndTranslations = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyLanguagesAndTranslations = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyLanguagesAndTranslations = false;
                    break;
            }
        }
        */
        /*
        private void copyValueListDefinitions_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyValueListDefinitions.CheckState)
            {
                case CheckState.Checked:
                    this.CopyValueListDefinitions = true;
                    break;
                case CheckState.Unchecked:
                    CheckContentsOfValueLists(false);
                    this.CopyValueListDefinitions = false;
                    break;
                case CheckState.Indeterminate:
                    CheckContentsOfValueLists(false);
                    this.CopyValueListDefinitions = false;
                    break;
            }
        }
        */
        /*
        private void copyPropertyDefinitions_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyPropertyDefinitions.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    this.CopyPropertyDefinitions = true;
                    break;
                case CheckState.Unchecked:
                    CheckViews(false);
                    CheckClassesAndClassGroups(false);
                    this.CopyPropertyDefinitions = false;
                    break;
                case CheckState.Indeterminate:
                    CheckViews(false);
                    CheckClassesAndClassGroups(false);
                    this.CopyPropertyDefinitions = false;
                    break;
            }
        }
        */
        /*
        private void copyDataSets_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyDataSets.CheckState)
            {
                case CheckState.Checked:
                    this.CopyDataSets = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyDataSets = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyDataSets = false;
                    break;
            }
        }
        */
        /*
        private void copyScheduledExportAndImportJobs_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyScheduledExportAndImportJobs.CheckState)
            {
                case CheckState.Checked:
                    this.CopyScheduledExportAndImportJobs = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyScheduledExportAndImportJobs = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyScheduledExportAndImportJobs = false;
                    break;
            }
        }
        */
        /*
        private void copyUserAccounts_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyUserAccounts.CheckState)
            {
                case CheckState.Checked:
                    this.CopyUserAccounts = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyUserAccounts = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyUserAccounts = false;
                    break;
            }
        }
        */
        /*
        private void copyViews_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyViews.CheckState)
            {
                case CheckState.Checked:
                    CheckObjectTypesAndValueListDefinitions(true);
                    CheckPropertyDefinitions(true);
                    this.CopyViews = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyViews = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyViews = false;
                    break;
            }
        }
        */
        /*
        private void copyWorkFlows_CheckedChanged(object sender, EventArgs e)
        {
            switch (copyWorkFlows.CheckState)
            {
                case CheckState.Checked:
                    this.CopyWorkFlows = true;
                    break;
                case CheckState.Unchecked:
                    this.CopyWorkFlows = false;
                    break;
                case CheckState.Indeterminate:
                    this.CopyWorkFlows = false;
                    break;
            }
        }
        */

        private void createVaultConnection_CheckedChanged(object sender, EventArgs e)
        {
            switch (createVaultConnection.CheckState)
            {
                case CheckState.Checked:
                    this.CreateVaultConnection = true;
                    break;
                case CheckState.Unchecked:
                    this.CreateVaultConnection = false;
                    break;
                case CheckState.Indeterminate:
                    this.CreateVaultConnection = false;
                    break;
            }
        }





        private void okButton_Click(object sender, EventArgs e)
        {
            if (vaultName.Text != String.Empty)
            {
                this.CopyVaultName = vaultName.Text;
            }
            else
            {
                MessageBox.Show(Constants.copyVaultNameMissing);
                return;
            }
            if (copyAllDataCheckbox.CheckState == CheckState.Unchecked && copyStructureOnlyCheckbox.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show(Constants.allDataOrStructureOnlyMissing);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /*
        private void CheckApplications(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyApplications = state;
            copyApplications.Checked = state;    
        }
        */

        /*
        private void CheckClassesAndClassGroups(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyDocumentProfiles = state;
            copyDocumentProfiles.Checked = state;
        }
        */
        /*
        private void CheckConnectionsToExternalSources(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyConnectionsToExternalLocations = state;
            copyConnectionsToExternalLocations.Checked = state;
        }
        */
        /*
        private void CheckContentsOfValueLists(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyValueListContent = state;
            copyValueListContent.Checked = state;
        }
        */
        /*
        private void CheckDocumentsAndOtherObjects(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyDocuments = state;
            copyDocuments.Checked = state;
        }
        */
        /*
        private void CheckFileContent(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyFileContent = state;
            copyFileContent.Checked = state;
        }
        */
        /*
        private void CheckEventHandlers(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyInternalEventHandlers = state;
            copyInternalEventHandlers.Checked = state;
        }
        */
        /*
        private void CheckEventLog(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyEventLog = state;
            copyEventLog.Checked = state;
        }
        */
        /*
        private void CheckPropertyDefinitions(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyPropertyDefinitions = state;
            copyPropertyDefinitions.Checked = state;
        }
        */
        /*
        private void CheckObjectTypesAndValueListDefinitions(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyValueListDefinitions = state;
            copyValueListDefinitions.Checked = state;
        }
        */
        /*
        private void CheckScheduledExportAndImportJobs(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyScheduledExportAndImportJobs = state;
            copyScheduledExportAndImportJobs.Checked = state;
        }
        */
        /*
        private void CheckReportingAndMetadataExportDataSets(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyDataSets = state;
            copyDataSets.Checked = state;
        }
        */
        /*
        private void CheckUsersAndUserGroups(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyUserAccounts = state;
            copyUserAccounts.Checked = state;
        }
        */
        /*
        private void CheckViews(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyViews = state;
            copyViews.Checked = state;
        }
        */
        /*
        private void CheckWorkflows(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyWorkFlows = state;
            copyWorkFlows.Checked = state;
        }
        */
        /*
        private void CheckLanguagesAndTranslations(bool state)
        {
            ClearAllDataAndStructureOnlyFlag();
            this.CopyLanguagesAndTranslations = state;
            copyLanguagesAndTranslations.Checked = state;
        }
        */
        private void CheckCreatVaultConnection(bool state)
        {
            this.CreateVaultConnection = state;
            createVaultConnection.Checked = state;
        }
        /*
        private void EnableCheckmarks(bool state)
        {
           
            copyApplications.Enabled = state;
            copyConnectionsToExternalLocations.Enabled = state;
            copyDataSets.Enabled = state;
            copyDocumentProfiles.Enabled = state;
            copyDocuments.Enabled = state;
            copyEventLog.Enabled = state;
            copyFileContent.Enabled = state;
            copyInternalEventHandlers.Enabled = state;
            copyLanguagesAndTranslations.Enabled = state;
        }
        */

        private void ClearAllDataAndStructureOnlyFlag()
        {
            this.CopyAllData = false;
            this.CopyOnlyStructure = false;
        }

        /*
        private void CheckStructureOnly()
        {
            CheckObjectTypesAndValueListDefinitions(true);
            CheckPropertyDefinitions(true);
            CheckClassesAndClassGroups(true);
            CheckViews(true);
            CheckWorkflows(true);
            CheckLanguagesAndTranslations(true);
            CheckEventHandlers(true);
            CheckApplications(true);
            CheckUsersAndUserGroups(false);
            CheckConnectionsToExternalSources(false);
            CheckContentsOfValueLists(false);
            CheckDocumentsAndOtherObjects(false);
            CheckEventLog(false);
            CheckReportingAndMetadataExportDataSets(false);
            CheckScheduledExportAndImportJobs(false);
        }
        */
        // public Boolean CopyApplications { get; set; }
        // public Boolean CopyDocumentProfiles { get; set; }
        // public Boolean CopyConnectionsToExternalLocations { get; set; }
        // public Boolean CopyValueListContent { get; set; }
        // public Boolean CopyDocuments { get; set; }
        // public Boolean CopyInternalEventHandlers { get; set; }
        // public Boolean CopyEventLog { get; set; }
        // public Boolean CopyLanguagesAndTranslations { get; set; }
        // public Boolean CopyValueListDefinitions { get; set; }
        // public Boolean CopyPropertyDefinitions { get; set; }
        // public Boolean CopyDataSets { get; set; }
        // public Boolean CopyScheduledExportAndImportJobs { get; set; }
        // public Boolean CopyUserAccounts { get; set; }
        // public Boolean CopyViews { get; set; }
        // public Boolean CopyWorkFlows { get; set; }
        public Boolean CopyAllData { get; set; }
        public Boolean CopyOnlyStructure { get; set; }
        // public Boolean CopyFileContent { get; set; }
        public Boolean CreateVaultConnection { get; set; }
        public string CopyVaultName { get; set; }

        private void copyAllDataCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (copyAllDataCheckbox.Checked == true)
            {
                createVaultConnection.Enabled = true;
                copyStructureOnlyCheckbox.Enabled = false;
                copyStructureOnlyCheckbox.Checked = false;
                this.CopyOnlyStructure = false;
                this.CopyAllData = true;
            }
            
            if (copyAllDataCheckbox.Checked == false)
            {
                createVaultConnection.Enabled = false;
                copyStructureOnlyCheckbox.Enabled = true;
                this.CopyOnlyStructure = false;
                this.CopyAllData = false;
            }
        }

        private void copyStructureOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (copyStructureOnlyCheckbox.Checked == true)
            {
                createVaultConnection.Enabled = false;
                createVaultConnection.Checked = false;
                copyAllDataCheckbox.Checked = false;
                copyAllDataCheckbox.Enabled = false;
                this.CopyOnlyStructure = true;
                this.CopyAllData = false;
            }
            
            if (copyStructureOnlyCheckbox.Checked == false)
            {
                createVaultConnection.Enabled = false;
                copyAllDataCheckbox.Enabled = true;
                this.CopyOnlyStructure = false;
                this.CopyAllData = false;
            }
            

        }
    }


    
}
