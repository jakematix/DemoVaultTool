using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public class AzureOperations
    {
        public bool ConnectToAzureFiles()

        {
            // Create connection to Azure File Share. Connection string is defined in App.config
            try
            {
                CloudStorageAccount repositoryAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudFileClient fileClient = repositoryAccount.CreateCloudFileClient();
                CloudFileShare share = fileClient.GetShareReference(Constants.azureShareReference);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong when connecting to Demo Repository in Azure Files.\r\n" + ex.Message);
                return false;
            }
            return true;
        }

        public CloudFileDirectory GetVaultDirectoryInAzure(string vaultName)
        {
            // Return cloud file directory in Azure File Sharw based on tha vault name
            try
            {
                CloudFileShare share = GetVaultFileShareInAzure();

                CloudFileDirectory rootDir = share.GetRootDirectoryReference(); // Root directory of the file share
                CloudFileDirectory vaultsDir = rootDir.GetDirectoryReference(Constants.vaultDirectoryNameInAzure);
                CloudFileDirectory vaultDir = vaultsDir.GetDirectoryReference(vaultName);
                return vaultDir;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong when accessing Azure Cloud Directory.\r\n" + ex.Message);
                return null;
            }
        }

        
        public CloudFileShare GetVaultFileShareInAzure()
        {
            // Returns Cloud File Share in Azure
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
                CloudFileShare share = fileClient.GetShareReference(Constants.azureShareReference);
                return share;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong accessing Azure Cloud File Share.\r\n" + ex.Message);
                return null;
            }
        }

        public string GetMFilesInstallerDirectoryInAzure()
        {
            try
            {
                string insDirName = String.Empty;
                CloudFileShare share = GetVaultFileShareInAzure();
                
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();
                var installerDirs = rootDir.GetDirectoryReference(Constants.mFilesInstallerDirectoryNameInAzure).ListFilesAndDirectories().OfType<CloudFileDirectory>();
                foreach (var installerDir in installerDirs)
                {
                    insDirName = installerDir.Name;
                }
                return insDirName; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong accessing Azure Clould File Share.\r\n" + ex.Message);
                return null;

            }
        }
    }
}
