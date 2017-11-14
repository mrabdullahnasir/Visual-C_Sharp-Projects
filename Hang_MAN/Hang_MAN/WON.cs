using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hang_MAN
{
    public partial class WON : Form
    {
        public WON()
        {
            InitializeComponent();

            //label1.Text = Form1.WORD;

            
            label2.Text = "\"" + Form1.WORD + "\"";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            h.Show();
            this.Visible = false;
        }

        private void WON_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
