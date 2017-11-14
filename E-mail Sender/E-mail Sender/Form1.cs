using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace E_mail_Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show("fc");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {

                if (!textBox5.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("You can only send email through G-mail...");
                }
                else
                {
                    MailMessage messagge = new MailMessage();
                    messagge.Body = textBox3.Text;
                    messagge.Subject = textBox2.Text;
                    messagge.From = new MailAddress(textBox5.Text);
                    foreach (string s in textBox1.Text.Split(';'))
                    {
                        messagge.To.Add(s);
                    }

                    SmtpClient d = new SmtpClient();
                    d.Port = 587;
                    d.EnableSsl = true;
                    d.Host = "smtp.gmail.com";
                    d.Send(messagge);



                } }
            catch 
            {
                MessageBox.Show("pl, make sure that, U have typed in all the fields correctly & U have proper internet connection","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
               
            }

            
            }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
