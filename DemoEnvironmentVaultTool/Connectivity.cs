using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace DemoEnvironmentVaultTool
{
    public class Connectivity
    {

        public static bool ConnectivityStatus(Label connectivityLabel)
        {
            connectivityLabel.Visible = true;
            if (InternetConnectivity())
            {
                connectivityLabel.Text = Constants.statusConnected;
                connectivityLabel.Font = new Font(connectivityLabel.Font, FontStyle.Regular);
                connectivityLabel.ForeColor = Color.Green;
                return true;
            }
            else
            {
                connectivityLabel.Text = Constants.statusNotConnected;
                connectivityLabel.Font = new Font(connectivityLabel.Font, FontStyle.Bold);
                connectivityLabel.ForeColor = Color.Red;
                return false;
            }
        }


        public static bool InternetConnectivity()
        {
            try
            {
                Ping myPing = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(Constants.connectivityTestSite, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internet Connectivity can not be checked!\r\n" + ex.Message);
                return false;
            }
        }
    }
}
