using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor_Decryptor
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Encryptor e1 = new Encryptor();
            e1.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Decryptor d = new Decryptor();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
