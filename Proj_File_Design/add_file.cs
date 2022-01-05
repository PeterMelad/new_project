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
    public partial class add_file : Form
    {
        public add_file()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            add_Categories f1 = new add_Categories();
            f1.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Categories.xml"))
            {
                Engine engin = new Engine();
                engin.set_filename_path(textBox1.Text, textBox2.Text);
                engin.search();
                engin.End();


                textBox1.Text = "";
                textBox2.Text = "";
            }
            else MessageBox.Show("You can not save a file , Write Categories first");
        }
    }
}
