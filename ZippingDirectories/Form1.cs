using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZippingDirectories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dlgFolderBrowser = new FolderBrowserDialog())
            {
                if(dlgFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    ZipDirToParent(dlgFolderBrowser.SelectedPath);
                }
            }
        }
        //Zip Method
        private static void ZipDirToParent(string dir)
        {
            string parent = Path.GetDirectoryName(dir);
            Process.Start(parent);
            string name = Path.GetFileName(dir);
            string fileName = Path.Combine(parent, name + ".zip");
            ZipFile.CreateFromDirectory(dir, fileName, CompressionLevel.Fastest, true);

        }
    }
}
