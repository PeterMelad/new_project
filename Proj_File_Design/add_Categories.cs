using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_File_Design
{
    public partial class add_Categories : Form
    {
        public add_Categories()
        {
            InitializeComponent();
        }
        Engine eng = new Engine();
            
        private void button5_Click(object sender, EventArgs e)
        {
            eng.WritIntoFile();

            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string n1 = textBox1.Text;
            string n2 = textBox2.Text;
            eng.done(n2,n1);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string n = textBox2.Text;
            
            eng.ke(n);
            textBox2.Text = "";
        }
    }
}
