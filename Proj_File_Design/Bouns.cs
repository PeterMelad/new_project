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
namespace Proj_File_Design
{
    public partial class Bouns : Form
    {
        public Bouns()
        {
            InitializeComponent();
        }

        
        List<string> keywords = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string path=null;
                bool exis = false;
                
            if (File.Exists("File.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("File.xml");
                XmlNodeList nls = doc.GetElementsByTagName("File");
                XmlNodeList ils = nls[0].ChildNodes;
                for (int i = 0; i < ils.Count; i++)
                {
                    XmlNodeList iils = ils[i].ChildNodes;
                    for (int j = 0; j < iils.Count; j++)
                    {
                        if (j == 0)
                        {
                            if (iils[0].InnerText != textBox1.Text)
                            {
                                break;
                            }
                        }

                        if (j ==1)
                        {
                            exis = true;

                        path =iils[1].InnerText + "\\" + "\\" + textBox1.Text + ".txt" ;
                        }
                        if (j > 1)
                        {
                            XmlNodeList l = iils[j].ChildNodes;
                            for (int x = 0; x < l.Count; x++)
                            {
                                if (x == 0)
                                {
                                    if (l[0].InnerText != textBox2.Text)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                   
                                    keywords.Add(l[x].InnerText);
                                }
                            }

                        }

                    }//end_nested_loop
                    if (exis) break;
                }//end_loop
                                       
            }//end if
            else MessageBox.Show("The file does not exist");
            if (exis)
            {
               // richTextBox1.Clear();
                FileStream fs = new FileStream(@path, FileMode.Open);
                StreamReader st = new StreamReader(fs);
                while (st.Peek() != -1)
                {
                    richTextBox1.Text += st.ReadLine() + "\r\n";
                }

                st.Close();
                fs.Close();
            }
            else MessageBox.Show("This file does not exist");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < keywords.Count; i++)
            {
                int index = 0;
                while (index < richTextBox1.Text.LastIndexOf(keywords.ElementAt(i)))
                {
                    richTextBox1.Find(keywords.ElementAt(i), index, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    index = richTextBox1.Text.IndexOf(keywords.ElementAt(i), index) + 1;
                }
            }

        }

    }
}
