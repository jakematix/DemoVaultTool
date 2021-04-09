using System;
using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }
        Timer timer;
        private void WelcomeScreen_Shown(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += timer_Tick;


        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
