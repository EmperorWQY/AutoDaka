using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var WeChatPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\微信\微信.lnk";
            System.Diagnostics.Process.Start(WeChatPath);
        }
    }
}
