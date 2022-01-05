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
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            //de kda ele fe el design
            //userControl21.Hide();
//            userControl11.Hide();
      
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Display_keywords_form d1 = new Display_keywords_form();
            d1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Display_categories_form d1 = new Display_categories_form();
            d1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            add_Categories f1 = new add_Categories();
            f1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_file f1 = new add_file();
            f1.Show();
            this.Visible = false;
        }

        private void userControl23_Load(object sender, EventArgs e)
        {

        }

        private void userControl14_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {
      
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Search_form s1 = new Search_form();
            s1.Show();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Display_file_form f1 = new Display_file_form();
            f1.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Bouns b = new Bouns();
            b.Show();
        }
    }
}
