using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            toolStripStatusLabel1.Text = "......";
            p = Color.White;
            toolStripButton5.BackColor = p; 
        }
        Color p;
        bool canPaint = false;
        Graphics g;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canPaint = true;


            if (cir)
            {
                if (toolStripTextBox4.Text == "" || toolStripTextBox5.Text == "")
                {
                    MessageBox.Show("pl, enter size for the shape...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    canPaint = false;
                }
                else
                {
                    SolidBrush s = new SolidBrush(p);
                   
                    g.FillEllipse(s, e.X, e.Y, float.Parse(toolStripTextBox4.Text), float.Parse(toolStripTextBox5.Text));
                    toolStripStatusLabel1.Text = "a Circle is drawn.....";
                    timer1.Start();

                    canPaint = false;
                }
            }
            else if (sq)
            {
                if (toolStripTextBox4.Text == "" || toolStripTextBox5.Text == "")
                {
                    MessageBox.Show("pl, enter size for the shape...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    canPaint = false;
                }
                else
                {
                    SolidBrush s = new SolidBrush(p);
                    g.FillRectangle(s, e.X, e.Y, float.Parse(toolStripTextBox5.Text), float.Parse(toolStripTextBox5.Text));
                    toolStripStatusLabel1.Text = "a Square is drawn.....";
                    timer1.Start();

                    canPaint = false;
                }
            }
            else if (rect)
            {
                if (toolStripTextBox4.Text == "" || toolStripTextBox5.Text == "")
                {
                    MessageBox.Show("pl, enter size for the shape...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    canPaint = false;
                }
                else
                {
                    SolidBrush s = new SolidBrush(p);
                    g.FillRectangle(s, e.X, e.Y, float.Parse(toolStripTextBox4.Text), float.Parse(toolStripTextBox5.Text));
                    toolStripStatusLabel1.Text = "a Rectangle is drawn.....";
                    timer1.Start();

                    canPaint = false;
                }
            }
            //sq = false; rect = false; cir = false;

        }
        int? pre = null;
        int? post = null;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            canPaint = false;
            pre = null;
            post = null;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            Exception w = new Exception("Pl, enter a valid \"TipSize\" for pen...");
            try
            {
                if (canPaint)
                {

                    Pen p1 = new Pen(p, float.Parse(toolStripTextBox1.Text));
                    g.DrawLine(p1, new Point(pre ?? e.X, post ?? e.Y), new Point(e.X, e.Y));
                    pre = e.X;
                    post = e.Y;
                }
            }

            catch
            {
                MessageBox.Show(w.Message);
                toolStripTextBox1.Text = "0";
            }
        }
        int tima = 0;
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
  
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                p = c.Color;
                //toolStripTextBox3.BackColor = c.Color;
                toolStripButton5.BackColor = c.Color;
                timer1.Start();
                toolStripStatusLabel1.Text = "color is changed...";
                timer1.Tick += Timer1_Tick;


            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ++tima;
            if (tima == 4)
            {
                toolStripStatusLabel1.Text = "............";
                timer1.Stop();
                tima = 0;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {

                //toolStripTextBox2.BackColor = c.Color;
                timer1.Start();
                panel1.BackColor = c.Color;
                toolStripButton6.BackColor = c.Color;
                toolStripStatusLabel1.Text = "canvas color is changed...";

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
            toolStripStatusLabel1.Text = "canvas is cleared...";
            timer1.Start();
        }
        bool cir = false;
        bool rect = false;
        bool sq = false;
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cir = true;
            sq = false;
            rect = false;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sq = true;
            cir = false;
            rect = false;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rect = true;
            sq = false;
            cir = false;
        }

        private void toolStripTextBox1_MouseLeave(object sender, EventArgs e)
        {
            cir = false;
            sq = false;
            rect = false;
        }

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cir = false;
            sq = false;
            rect = false;
            toolStripStatusLabel1.Text = "back to Pen.....";
            timer1.Start();
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string i in files)
            {
                g.DrawImage(Image.FromFile(i), new Point(0, 0));
                toolStripStatusLabel1.Text = "image is loaded.....";
                timer1.Start();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            canPaint = false;
            OpenFileDialog g1 = new OpenFileDialog();
            g1.Title = "select a picture...";
            g1.Filter = "PNG files|*.png|JPEG files|*.jpeg|JPG files|*.jpg";
            if (g1.ShowDialog() == DialogResult.OK)
            {
                g.DrawImage(Image.FromFile(g1.FileName), new Point(0, 0));
                toolStripStatusLabel1.Text = "image is loaded.....";
                timer1.Start();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            cir = false;
            sq = false;
            rect = false;
            toolStripStatusLabel1.Text = "Pen.....";
            timer1.Start();
        }
    }
}
