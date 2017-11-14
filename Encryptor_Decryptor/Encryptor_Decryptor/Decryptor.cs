using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Encryptor_Decryptor
{
    public partial class Decryptor : Form
    {
        public Decryptor()
        {
            InitializeComponent();
        }
       
        byte[] read;
        string path;
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Title = "Save the Decrypted file to ...";
            ofd.Filter = "Text Files|*.txt|XML Files|*.xml|HTML Files|*.html|Dat Files|*.dat";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                StreamWriter st = new StreamWriter(File.Create(path));
                st.Write(write);

                st.Close();

                MessageBox.Show("Thank you so much,,,,", "Encryptor_Decryptor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
                

                // b.Close();

            }
        }
        string write;

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                UTF8Encoding uutf8 = new UTF8Encoding();
                TripleDESCryptoServiceProvider tri = new TripleDESCryptoServiceProvider();
                tri.Key = md5.ComputeHash(uutf8.GetBytes(textBox1.Text));
                tri.Mode = CipherMode.ECB;
                tri.Padding = PaddingMode.PKCS7;
                //  encrypt = uutf8.GetBytes(read);

                ICryptoTransform ic = tri.CreateDecryptor();
                write = uutf8.GetString(ic.TransformFinalBlock(Encryptor.load, 0, Encryptor.load.Length));
                MessageBox.Show("Your Encrypted file is Decrypted successfully... ", "Decryption succeeded", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception n){
                MessageBox.Show(n.Message);
            }
                       
            /*catch(Exception v)
            {
                MessageBox.Show(v.Message);
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
