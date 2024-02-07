using System;
using System.Drawing;
using Microsoft.Win32;

using System.Windows.Forms;

namespace DemoEnvironmentVaultTool
{
    public partial class DescriptionViewer : Form
    {
        public DescriptionViewer(string fileName)
        {
            InitializeComponent();
            this.MaximumSize = new Size(1100, 750);
            this.MinimumSize = new Size(1100, 750);
            viewPDF.LoadFile(fileName);
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
