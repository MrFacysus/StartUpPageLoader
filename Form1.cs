using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupPageLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // make process start with windows
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // check if the key exists
            if (key.GetValue("StartupPageLoader") == null)
            {
                // if not, create the key
                key.SetValue("StartupPageLoader", Application.ExecutablePath.ToString());
            }
            // check if a file called previous.cfg exists
            if (System.IO.File.Exists("previous.cfg"))
            {
                // variable for line read
                string line = System.IO.File.ReadLines("previous.cfg").First();
                // set the textbox value to the first line of the file
                textBox1.Text = line;
                // open browser with url
                System.Diagnostics.Process.Start(line);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // write the textbox value to the file
            System.IO.File.WriteAllText("previous.cfg", textBox1.Text);
            System.Diagnostics.Process.Start("https://www.google.com");
        }
    }
}
