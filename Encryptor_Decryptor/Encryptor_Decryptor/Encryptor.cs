using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Encryptor_Decryptor
{
    public partial class Encryptor : Form
    {
        public Encryptor()
        {
            InitializeComponent();
        }
        public static byte[] load;
        string read;
        string path;
        private void button1_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a file to Encrypt...";
            ofd.Filter = "Text Files|*.txt|XML Files|*.xml|HTML Files|*.html|Dat Files|*.dat";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;

                StreamReader g = new StreamReader(File.OpenRead(path));
                read = g.ReadToEnd();
                g.Close();
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] hash = utf8.GetBytes(textBox1.Text);
            TripleDESCryptoServiceProvider tri = new TripleDESCryptoServiceProvider();
            tri.Key = md5.ComputeHash(hash);
            tri.Mode = CipherMode.ECB;
            tri.Padding = PaddingMode.PKCS7;
            ICryptoTransform ict = tri.CreateEncryptor();
            load = ict.TransformFinalBlock(utf8.GetBytes(read), 0, read.Length);
            string encrypt = BitConverter.ToString(load);
            if(textBox1.Text=="")
            {
                MessageBox.Show("Pl, enter a key for protection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Congratulations, Encryption of file is completed successfully...", "Encryption Succeded", MessageBoxButtons.OK,MessageBoxIcon.None);


              
                    
                    StreamWriter sw = new StreamWriter(File.Create(path));
                    sw.Write(encrypt);
                    sw.Close();






                this.Visible = false;
                Start f = new Start();
                f.Show();
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
