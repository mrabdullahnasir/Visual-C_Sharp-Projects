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
using System.Xml;

namespace Address_Book_AFRAZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string n="";

            foreach (ListViewItem h1 in listView1.SelectedItems)
            {
                n = h1.Text;
                h1.Remove();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                XmlDocument h = new XmlDocument();
                h.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
                foreach (XmlNode n1 in h.SelectNodes("people/Person"))
                {
                    if (n == n1.SelectSingleNode("Name").InnerText)
                    {
                        n1.ParentNode.RemoveChild(n1);
                    }
                }
                h.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
            }

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            if (!Directory.Exists("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook"))
            {
                Directory.CreateDirectory("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook");
            }
            if (!File.Exists("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml"))
            {
                File.Create("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
                }

            XmlDocument g = new XmlDocument();
            g.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
           if(g.DocumentElement.HasChildNodes)
            {
                foreach(XmlNode h in g.SelectNodes("people/Person"))
                {
                    
                    string namE = h.SelectSingleNode("Name").InnerText;
                    string emaiL = h.SelectSingleNode("E-mail").InnerText;
                    string addresS = h.SelectSingleNode("Address").InnerText;
                    string addnotE = h.SelectSingleNode("Additional_Notes").InnerText;
                    DateTimeConverter m = new DateTimeConverter();
                    
                    string d = (h.SelectSingleNode("Birthday").InnerText);
                    Person p = new Person();
                    p.name = namE;
                    p.email = emaiL;
                    p.address = addresS;
                    p.addnote = addnotE;
                    p.dob = DateTime.FromFileTime(Convert.ToInt64(d));
                    people.Add(p);
                    listView1.Items.Add(p.name);
                    
                }
            }


            g.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
            
        }
        List<Person> people = new List<Person>();
        private void button2_Click(object sender, EventArgs e)
        {
            Person h = new Person();
            h.name = textBox1.Text;
            h.email = textBox2.Text;
            h.address = textBox3.Text;
            h.addnote = textBox4.Text;
            h.dob = dateTimePicker1.Value;
            people.Add(h);
            listView1.Items.Add(h.name);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;

           // StreamWriter sw = new StreamWriter(File.OpenWrite("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml"));
            XmlDocument xd = new XmlDocument();
            xd.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
            
            XmlNode person = xd.CreateElement("Person");
            XmlNode Name = xd.CreateElement("Name");
            XmlNode EMAIL = xd.CreateElement("E-mail");
            XmlNode ADDRESS = xd.CreateElement("Address");
            XmlNode ADDNOTE = xd.CreateElement("Additional_Notes");
            XmlNode DATE = xd.CreateElement("Birthday");
            Name.InnerText = h.name;
            EMAIL.InnerText = h.email;
            ADDRESS.InnerText = h.address;
            ADDNOTE.InnerText = h.addnote;
            DATE.InnerText = h.dob.ToFileTime().ToString();
            person.AppendChild(Name);
            person.AppendChild(EMAIL);
            person.AppendChild(ADDRESS);
            person.AppendChild(ADDNOTE);
            person.AppendChild(DATE);
            xd.DocumentElement.AppendChild(person);
            xd.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem n in listView1.SelectedItems)
            {
                textBox1.Text = people[n.Index].name;
                textBox2.Text = people[n.Index].email;
                textBox3.Text = people[n.Index].address;
                textBox4.Text = people[n.Index].addnote;
                dateTimePicker1.Value = people[n.Index].dob;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NaMe="";
            

            MessageBox.Show("Pl, make sure", "Security", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
            
            foreach(Person p in people)
            {
                foreach(ListViewItem n in listView1.SelectedItems)
                {
                    if(p.name==n.Text)
                    {
                        NaMe = p.name;
                        p.name = textBox1.Text;
                        p.email = textBox2.Text;
                        p.address = textBox3.Text;
                        p.addnote = textBox4.Text;
                        p.dob = dateTimePicker1.Value;

                        foreach(ListViewItem  m in listView1.SelectedItems)
                        {
                            if(m.Text==NaMe)
                            {
                                m.Text = textBox1.Text;

                            }
                        }

                        XmlDocument l = new XmlDocument();
                        l.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
                        foreach(XmlNode m in l.SelectNodes("people/Person"))
                        {
                            if(m.SelectSingleNode("Name").InnerText==NaMe)
                            {
                                m.SelectSingleNode("Name").InnerText = textBox1.Text;
                                m.SelectSingleNode("E-mail").InnerText = textBox2.Text;
                                m.SelectSingleNode("Address").InnerText = textBox3.Text;
                                m.SelectSingleNode("Additional_Notes").InnerText = textBox4.Text;
                                m.SelectSingleNode("Birthday").InnerText = dateTimePicker1.Value.ToFileTime().ToString();
                            }
                        }
                        l.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
                    }
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string n = "";

            foreach (ListViewItem h1 in listView1.SelectedItems)
            {
                n = h1.Text;
                h1.Remove();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = DateTime.Now;
            }

            XmlDocument h = new XmlDocument();
            h.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
            foreach (XmlNode n1 in h.SelectNodes("people/Person"))
            {
                if (n == n1.SelectSingleNode("Name").InnerText)
                {
                    n1.ParentNode.RemoveChild(n1);
                }
            }
            h.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");
        }
        int NewPerson = 0;
        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPerson++;
            //MessageBox.Show("Pl, 1st Enter Credentials for the NEW PERSON", "Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            Person m = new Person();
            m.name = "New Person" + NewPerson.ToString();
            m.email = textBox2.Text;
            m.address = textBox3.Text;
            m.addnote = textBox4.Text;
            m.dob = DateTime.Now;

            people.Add(m);
            listView1.Items.Add(m.name);

            XmlDocument xd = new XmlDocument();
            xd.Load("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");

            XmlNode person = xd.CreateElement("Person");
            XmlNode Name = xd.CreateElement("Name");
            XmlNode EMAIL = xd.CreateElement("E-mail");
            XmlNode ADDRESS = xd.CreateElement("Address");
            XmlNode ADDNOTE = xd.CreateElement("Additional_Notes");
            XmlNode DATE = xd.CreateElement("Birthday");
            Name.InnerText = m.name;
            EMAIL.InnerText = m.email;
            ADDRESS.InnerText = m.address;
            ADDNOTE.InnerText = m.addnote;
            DATE.InnerText = m.dob.ToFileTime().ToString();
            person.AppendChild(Name);
            person.AppendChild(EMAIL);
            person.AppendChild(ADDRESS);
            person.AppendChild(ADDNOTE);
            person.AppendChild(DATE);
            xd.DocumentElement.AppendChild(person);
            xd.Save("G:/drive/4th semester/00ad proj/web/Address Book-AFRAZ/Address Book-AFRAZ/addressbook/people.xml");




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}