using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace OS_Lab_1
{
    public partial class My_Files : Form
    {
        public static string filename = "";
        public static string PATH = "";
        public My_Files()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog gh = new FolderBrowserDialog();
            if (gh.ShowDialog() == DialogResult.OK)
            {
                PATH = gh.SelectedPath;
                FileName_frm h = new FileName_frm();
                h.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if(fb.ShowDialog()==DialogResult.OK)
            {
                string[] path = Directory.GetFiles(fb.SelectedPath);
                List<string> path2 = new List<string>();
                foreach (string file in path)
                {
                    path2.Add(Path.GetFileName(file)); 
                   
                }

                foreach (string f in path2)
                {
                    ListViewItem it = new ListViewItem(f );
                    listView1.Items.Add(it); 
                }  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fb = new OpenFileDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                Process.Start(fb.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                File.Delete(o.FileName);
                MessageBox.Show("File is successfuly Deleted...", "Delete Note");
            }
        }

    }
}
