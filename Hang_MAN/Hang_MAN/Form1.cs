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

namespace Hang_MAN
{
    public partial class Form1 : Form
    {
        public static string WORD;
        List<Label> labes = new List<Label>();
        int remaining = 10;

        int value =-1;
        
        enum BodyParts
        {
            head, left_eye, right_eye, nose, mouth, body, left_arm, right_arm, left_leg, right_leg

        }
        public Form1()
        {
            
            InitializeComponent();
            label7.Text = remaining.ToString();

        }
        void draWBodyPart(BodyParts f)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Coral, 3);
            SolidBrush n = new SolidBrush(Color.SkyBlue);
            if (f == BodyParts.head)
            {
               
                g.DrawEllipse(p, 39, 31, 35, 30);
              
               
            }
            else if (f == BodyParts.left_eye)
            {
                Pen p1 = new Pen(Color.Red, 2);
                g.DrawEllipse(p1, 47, 38, 4, 6);
                g.FillEllipse(n, 47, 47, 2, 4);
                
                g.FillEllipse(n, 47, 51, 2, 4);
            }
            else if (f == BodyParts.right_eye)
            {
                Pen p1 = new Pen(Color.Red, 2);
                g.DrawEllipse(p1, 62, 38, 4, 6);
                g.FillEllipse(n, 65, 45, 2, 4);
                g.FillEllipse(n, 65, 52, 2, 4);
            }
            else if (f == BodyParts.nose)
            {
                Pen p1 = new Pen(Color.Red, 2);
                g.DrawArc(p, 54, 43, 5, 5, 0, 180);
            }
            else if (f == BodyParts.mouth)
            {
                Pen p1 = new Pen(Color.Red, 2);
                g.DrawArc(p, 54, 50, 25, 15, 180, 90);
            }
            else if (f == BodyParts.body)
            {
                Pen p1 = new Pen(Color.Orange,3);
                SolidBrush b = new SolidBrush(Color.Brown);
                g.DrawEllipse (p, 47, 62, 20, 70);
            }
            else if (f == BodyParts.left_arm)
            {
                SolidBrush b = new SolidBrush(Color.Brown);
                g.DrawLine(p, new Point(50, 80), new Point(15, 50));
            }
            else if (f == BodyParts.right_arm)
            {
                SolidBrush b = new SolidBrush(Color.Brown);
                g.DrawLine(p, new Point(65, 80), new Point(100, 50));
            }
            else if (f == BodyParts.left_leg)
            {
                SolidBrush b = new SolidBrush(Color.Brown);
                g.DrawLine(p, new Point(50, 120), new Point(30, 160));
            }
            else if (f == BodyParts.right_leg)
            {
                SolidBrush b = new SolidBrush(Color.Brown);
                g.DrawLine(p, new Point(64, 120), new Point(85, 160));
            }
        }
        void drawPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.SaddleBrown, 5);
            // g.DrawEllipse(p, 20, 20, 2, 2);
            g.DrawLine(p, new Point(110, 187), new Point(110, 5));
            g.DrawLine(p, new Point(110, 7), new Point(55, 7));
            g.DrawLine(p, new Point(57, 7), new Point(57, 30));
            g.DrawLine(p, new Point(100, 183), new Point(120, 183));

        }


        void getLables()
        {
           
            char[] chars = WORD.ToCharArray();
            int bet = (333 / chars.Length) - 1;
            label1.Text = WORD.Length.ToString();
            for (int h = 0; h < chars.Length; h++)
            {
                labes.Add(new Label());
                //labes[h].Height = 5;
                labes[h].Location = new Point(((h * bet) + 10), (132 / 2));
                labes[h].Text = "__";
                labes[h].Parent = groupBox2;
                labes[h].BringToFront();

                labes[h].CreateControl();
                // labes[h].Show();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // drawPost();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            WORD = getWord();
            drawPost();
         
            getLables();

        }


        string getWord()
        {
            StreamReader s = new StreamReader(File.OpenRead("G:/drive/4th semester/00ad proj/web/Hang_MAN/Hang_MAN/words.txt"));
            string read = s.ReadToEnd();
            string[] words = read.Split(' ');
            Random r = new Random();
            return words[r.Next(0, words.Length)];
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Pl, Enter a valid Letter...", "Letter missed...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                char letter = textBox1.Text.ToLower().ToCharArray()[0];
                if (!char.IsLetter(letter))
                {
                    MessageBox.Show("U can enter only a letter...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (WORD.Contains(letter))
                {
                    char[] Letters = WORD.ToCharArray();
                    for (int h = 0; h < Letters.Length; h++)
                    {
                        if (Letters[h] == letter)
                        {
                            if (labes[h].Text == letter.ToString())
                            {
                                MessageBox.Show("U have guessed this letter earlier..", "Repeated",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                textBox1.Text = "";
                                return;
                            }
                            else
                            {
                                labes[h].Text = letter.ToString();
                                textBox1.Text = "";
                            }
                        }
                    }
                   foreach(Label l in labes)
            {
                        if (l.Text == "__")
                        {
                            return;
                        }
                    }
                    WON w = new WON();
                    w.Show();
                    this.Visible = false;
                    //reset();



                }


                else
                {

                    MessageBox.Show("Letter isn't in the word to be guessed...", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    remaining--;
                    label7.Text = remaining.ToString();
                    value++;
                    label4.Text += " "+letter.ToString()+",";
                    draWBodyPart((BodyParts)value);
                    
                    if(value==9)
                    {
                        draWBodyPart((BodyParts)value);
                        LOSE l = new LOSE();
                        l.Show();
                        this.Visible = false;
                       // reset();
                    }
                }


                textBox1.Text = "";

            }
            

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void reset()
        {
            Graphics j = panel1.CreateGraphics();
            j.Clear(panel1.BackColor);
            WORD = getWord();
            getLables();
            drawPost();
            value = -1;
            label4.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Pl, enter a word to be guessed", "word missing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (textBox2.Text == WORD)
                {
                    WON qe = new WON();
                    qe.Show();
                    this.Visible = false;
                    textBox2.Text = "";


                }
                else
                {
                    MessageBox.Show("your guessed word isn't correct...", "Sorry",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    remaining--;
                    label7.Text = remaining.ToString();
                    textBox2.Text = "";
                    value++;
                    draWBodyPart((BodyParts)value);
                    if (value == 9)
                    {
                        remaining = 0;
                        label7.Text = remaining.ToString();
                        draWBodyPart((BodyParts)value);

                        LOSE l = new LOSE();
                        l.Show();
                        this.Visible = false;
                    }

                }

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_BackColorChanged(object sender, EventArgs e)
        {
            label7.Text = value.ToString();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
           
            if(e.KeyCode==Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Pl, Enter a valid Letter...", "Letter missed...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    char letter = textBox1.Text.ToLower().ToCharArray()[0];
                    if (!char.IsLetter(letter))
                    {
                        MessageBox.Show("U can enter only a letter...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (WORD.Contains(letter))
                    {
                        char[] Letters = WORD.ToCharArray();
                        for (int h = 0; h < Letters.Length; h++)
                        {
                            if (Letters[h] == letter)
                            {
                                if (labes[h].Text == letter.ToString())
                                {
                                    MessageBox.Show("U have guessed this letter earlier..", "Repeated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textBox1.Text = "";
                                    return;
                                }
                                else
                                {
                                    labes[h].Text = letter.ToString();
                                    textBox1.Text = "";
                                }
                            }
                        }
                        foreach (Label l in labes)
                        {
                            if (l.Text == "__")
                            {
                                return;
                            }
                        }
                        WON w = new WON();
                        w.Show();
                        this.Visible = false;
                        //reset();



                    }


                    else
                    {

                        MessageBox.Show("Letter isn't in the word to be guessed...", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        remaining--;
                        label7.Text = remaining.ToString();
                        value++;
                        label4.Text += " " + letter.ToString() + ",";
                        draWBodyPart((BodyParts)value);

                        if (value == 9)
                        {
                            draWBodyPart((BodyParts)value);
                            LOSE l = new LOSE();
                            l.Show();
                            this.Visible = false;
                            // reset();
                        }
                    }


                    textBox1.Text = "";

                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Pl, enter a word to be guessed...", "Word missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox2.Text == WORD)
                    {
                        WON qe = new WON();
                        qe.Show();
                        this.Visible = false;
                        textBox2.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("your guessed word isn't correct...", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        remaining--;
                        label7.Text = remaining.ToString();
                        textBox2.Text = "";
                        value++;
                        draWBodyPart((BodyParts)value);
                        if (value == 9)
                        {
                            remaining = 0;
                            label7.Text = remaining.ToString();
                            draWBodyPart((BodyParts)value);

                            LOSE l = new LOSE();
                            l.Show();
                            this.Visible = false;
                        }

                    }
                }


            }
        }
    }
}



