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
namespace Proj_File_Design
{
    public partial class Display_keywords_form : Form
    {
        public Display_keywords_form()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string n = textBox1.Text;
            Engine eng = new Engine();
            if (File.Exists("Categories.xml"))
            {
                if (eng.search(n))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(n);

                    for (int i = 0; i < eng.innertext.Count; i++)
                    {
                        dt.Rows.Add(eng.innertext.ElementAt(i));
                    }

                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("The category does not exist");
                }
            }
            else MessageBox.Show("File does not exist");
        }
    }
}
