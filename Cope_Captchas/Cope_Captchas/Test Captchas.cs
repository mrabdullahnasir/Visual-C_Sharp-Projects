using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Cope_Captchas
{
    public partial class Test_Captchas : Form
    {

        string pwath = "";
        public Test_Captchas()
        {
            InitializeComponent();
        }

        string name = "";
        string b = "";
        string[] f = new string[2];
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string b = "";
                b = null;
                pwath = null;
                pictureBox1.ImageLocation = null;
                pwath = op.FileName;
                pictureBox1.ImageLocation = pwath;
                b = Path.GetFileNameWithoutExtension(pwath);
                if (b.Contains("Captcha-"))
                {
                    string[] f = b.Split('-');

                    name = f[1];
                }
                else
                {
                    MessageBox.Show("Pl, select a Captcha generated from this App..", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Test_Captchas h = new Test_Captchas();
                    h.Show();
                    
                    this.Close();

                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("pl, select an Image", "Image Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text=="")
            {
                MessageBox.Show("pl, Enter your Guess first in left textbox to be checked...", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                byte[] buffer = new byte[textBox1.Text.Length];
                int g = 0;
                foreach (char n in textBox1.Text)
                {
                    buffer[g] = (byte)n;
                }

                string md5str = BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-", "");

                if (name == md5str)
                {
                    MessageBox.Show("You got it RIGHT!...", "Result (Success)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("You got it WRONG!...", "Result (Failed)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string b = "";
                b = null;
                pwath = null;
                pictureBox1.ImageLocation = null;
                pwath = op.FileName;
                pictureBox1.ImageLocation = pwath;
                b = Path.GetFileNameWithoutExtension(pwath);
                if (b.Contains("Captcha-"))
                {
                    string[] f = b.Split('-');

                    name = f[1];
                }
                else
                {
                    MessageBox.Show("Pl, select a Captcha generated from this App..", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Test_Captchas h = new Test_Captchas();
                    h.Show();

                    this.Close();

                }

            }

        } 

       

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromName("HotTrack");
        }

        private void youCanOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can only open Captchas generated from this App  without any editing i.e, Color Change , renaming.","Test_Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
