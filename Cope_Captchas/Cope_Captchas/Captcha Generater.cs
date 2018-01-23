using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cope_Captchas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        List<string> md5strings = new List<string>();
        string path = "";

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Text == "")
            {
                MessageBox.Show("Pl, choose a folder first, to which you want to save Captchas.", "Location Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                char[] c = (textBox1.Text).ToCharArray() ;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Pl, enter a valid number in right textbox to let us know, How many Captchas, you want to generate. ", "Amount not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!(c[0] == '0') && !(c[0] == '1') && !(c[0] == '2') && !(c[0] == '3') && !(c[0] == '4') &&
                   !(c[0] == '5') && !(c[0] == '6') && !(c[0] == '7') && !(c[0] == '8') && !(c[0] == '9'))
                {
                    MessageBox.Show("Pl, enter only digits. ", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int f = 0;
                    foreach (Image i in GenerateCaptchas(Convert.ToInt32(textBox1.Text)))
                    {
                        panel1.BackgroundImage = i;
                        MessageBox.Show("Captcha: " + (f + 1), "Your Captchas here...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        i.Save(path + "\\" + "Captcha-" + md5strings[f] + ".png");
                       
                        f++;
                    }
                }
            }
                
            
        }

        Image[] GenerateCaptchas(int amount)
        {
         

            Random r = new Random();
            Image[] Images = new Image[amount];
            for (int w = 0; w < amount; w++)
            {
                Bitmap bm = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(bm);
                g.Clear(panel1.BackColor);

                
                SolidBrush b = new SolidBrush(Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                Pen p = new Pen(Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

                char[] chars = "qwertyuiopasdfghjklmnzbxcv1234567890".ToCharArray();
                string rand = "";


                for (int d = 0; d < 6; d++)
                {
                    rand += chars[r.Next(0, 35)];
                }

                byte[] buffer = new byte[rand.Length];
                int x = 0;
                foreach (char q in rand)
                {
                    buffer[x] = (byte)q;
                }
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                string hash = BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-", "");
                md5strings.Add(hash);


                FontFamily ff = new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif);
                Font f = new Font(ff, 50);
                g.DrawString(rand, f, b, 50, 50);

                for (int v = 0; v < 50; v++)
                {
                    int m = r.Next(0, 2);
                    if (m == 0)
                    {
                        g.DrawRectangle(p, r.Next(0, 152), r.Next(0, 85), r.Next(0, 152), r.Next(0, 85));
                    }
                    else if (m == 1)
                    {
                        g.DrawEllipse(p, r.Next(0, 152), r.Next(0, 85), r.Next(0, 152), r.Next(0, 85));
                    }
                    else
                    {
                        g.DrawLine(p, r.Next(0, 152), r.Next(0, 85), r.Next(0, 152), r.Next(0, 85));
                    }
                    p.Color = Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                }

                FontFamily fff = new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif);
                Font ffff = new Font(fff, 10,FontStyle.Bold);
                
                SolidBrush bb = new SolidBrush(Color.Gray);
                g.DrawString("Afraz-Captchas", ffff, bb, 180, 140);
                //panel1.BackgroundImage = bm;
                Images[w] = bm;
            }
            return Images;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == DialogResult.OK)
            {
                path=label3.Text = fld.SelectedPath;
                
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test_Captchas t = new Test_Captchas();
            this.Visible = false;
            t.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can only open Captchas generated from this App  without any editing i.e, Color Change , renaming.", "Test_Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
