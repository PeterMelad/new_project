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
    public partial class Display_categories_form : Form
    {
        public Display_categories_form()
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
            if (File.Exists("File.xml"))
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Product ID";
                dataGridView1.Columns[1].Name = "Product Name";
                dataGridView1.Columns[2].Name = "Product Price";

                string[] row = new string[] { "1", "Product 1", "1000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "2", "Product 2", "2000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "3", "Product 3", "3000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "4", "Product 4", "4000" };
                dataGridView1.Rows.Add(row);

                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Select Data";
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 4;
                cmb.Items.Add("True");
                cmb.Items.Add("False");
                dataGridView1.Columns.Add(cmb);

            }
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
