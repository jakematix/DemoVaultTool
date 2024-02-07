using System;
using System.Windows.Forms;
using System.ServiceProcess;
using MFilesAPI;



namespace DemoEnvironmentVaultTool
{
    public class MFilesOperations
    {
        public static MFilesServerApplication GetMFServerConnection()
        {
            MFilesServerApplication serverConnection = new MFilesServerApplication();
            serverConnection.ConnectAdministrativeEx(null,
                                                     MFAuthType.MFAuthTypeSpecificMFilesUser,
                                                     Constants.userName, Constants.passWord, "", "",
                                                     Constants.protocolSequence, Constants.server,
                                                     Constants.endPoint, false, "");
            return serverConnection;
        }

        public void RestartMFClientService()
        {
            // Get M-Files Client version
            // MFilesAPI.MFilesClientApplication mFClient = new MFilesAPI.MFilesClientApplication();
            // string clientVersion = mFClient.GetClientVersion().Display;
            // Compose the name of M-Files Client service

            string serviceName = "MFClient " + GetMFClientVersion();


            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }

                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetMFClientVersion()
        {
            MFilesClientApplication mFClient = new MFilesClientApplication();
            return mFClient.GetClientVersion().Display;
        }

        public string GetMFServerVersion()
        {
            MFilesServerApplication oMFServerApp = GetMFServerConnection();
            return oMFServerApp.GetServerVersion().Display;
        }

        public LicenseStatus GetServerLicenseStatus()
        {
            MFilesServerApplication oMFServerApp = GetMFServerConnection();
            return oMFServerApp.LicenseManagementOperations.GetLicenseStatus();
        }

        public bool SetServerLicense(string serialNumber, string licenseCode)
        {
            try
            {
                MFilesServerApplication oMFServerApp = GetMFServerConnection();
                oMFServerApp.LicenseManagementOperations.SetLicenseCodeAndSerialNumber(serialNumber, licenseCode);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public ulong MFilesVersionWithPaddingZeros(string rawVersionNumber)
        {
            // Converts M-Files version number to number with padding zeros that can be compared to other one.
            String[] dot = { "." };
            int count = 4;
            string versionNumberWithPadding = string.Empty;

            String[] versionList = rawVersionNumber.Split(dot, count, StringSplitOptions.RemoveEmptyEntries);
            if (versionList[1].Length < 2)
                versionList[1] = string.Format("{0:00}", versionList[1].PadLeft(2, '0'));
            if (versionList.Length >= 4)
            {
                if (versionList[3].Length < 2)
                    versionList[3] = string.Format("{0:00}", versionList[3].PadLeft(2, '0'));
            }
            foreach (string s in versionList)
                versionNumberWithPadding = versionNumberWithPadding + s;
            return UInt64.Parse(versionNumberWithPadding);
        }
    }
}
