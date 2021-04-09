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
            // MFilesServerApplication mFilesServer = new MFilesServerApplication();
            MFilesServerApplication oMFServerApp = GetMFServerConnection();
            return oMFServerApp.GetServerVersion().Display;
        }
    }
}
