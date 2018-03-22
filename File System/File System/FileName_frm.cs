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

namespace OS_Lab_1
{
    public partial class FileName_frm : Form
    {
        public FileName_frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] gfd = textBox1.Text.Split('.');

            // Check to find a proper File-Name with valid extension
            if (!textBox1.Text.Contains(".") || gfd.Length > 2)
            {
                MessageBox.Show("Pl, Enter a Filename with valid Extension...", "File-Name Error");
            }
            else
            {
                My_Files.filename = textBox1.Text;

                // Checking if File to be created already exists
                if (File.Exists(My_Files.PATH + "/" + My_Files.filename))
                {
                    string[] naem1 = My_Files.filename.Split('.');
                    List<string> path2 = new List<string>();

                    /* here getting only names of all files in the specified folder 
                       where we want to create file to Repeatition */
                    foreach (string fd in Directory.GetFiles(My_Files.PATH))
                    {
                        path2.Add(Path.GetFileName(fd));
                    }

                    My_Files.filename = naem1[0];
                    string no = "1";
                    int d = Convert.ToInt32(no);

                    // here checking if already a File Repeatition exists
                    foreach (string file in path2)
                    {
                        string[] naem2 = file.Split('.');

                        if (naem1[0] == naem2[0])
                        {
                            break;
                        }
                        else
                        {
                            string[] naem3 = null;
                            string[] naem4 = null;

                            if (naem2[0].Contains(naem1[0] + "("))
                            {
                                naem3 = naem2[0].Split('(');
                                if (naem3[1].Contains(")"))
                                {
                                    naem4 = naem3[1].Split(')');
                                    no = naem4[0];
                                }
                            }

                            /* if 2 or more copies of File to be created exist then 
                               Setting the integer to create next copy with same name*/
                            if (naem2[0].Contains(My_Files.filename + "(" + no + ")"))
                            {
                                ++d;
                            }
                        }
                    }

                    My_Files.filename = My_Files.filename + "(" + d + ")." + naem1[1];
                    File.Create(My_Files.PATH + "/" + My_Files.filename);
                }

                // if File already doesn't exist then Create it simply without checking Repeatition
                else
                {
                    File.Create(My_Files.PATH + "/" + My_Files.filename);
                }

                this.Close();
                MessageBox.Show("File is Successfully created....", "Success Message");
            }
        }
       
    }
}
