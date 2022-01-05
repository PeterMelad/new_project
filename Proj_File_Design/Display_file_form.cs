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
    public partial class Display_file_form : Form
    {
        public Display_file_form()
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
            Engine eng = new Engine();
            eng.Counter();
        
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Columns.Add("File name");
            dt.Columns.Add("File path");
            dt.Columns.Add("Categories");
            dt.Columns.Add("Keywords");
           
            //counter -> hwa 3dd el 7agat ele gwa el file (content)
            for (int i = 0; i < eng.counter; i++)
            {
                eng.display(i);
                dr["File name"] = eng.File_name;
                dr["File path"] = eng.File_path;
                
                for (int j = 0; j < eng.Ca.Count; j++)
                {
                    dr["Categories"] = eng.Ca.ElementAt(j);
                    List<string> ls = new List<string>();
                    ls = eng.KeyWord[eng.Ca.ElementAt(j)];
                    for (int x = 0; x < ls.Count; x++)
                    {
                        dr["Keywords"] = ls.ElementAt(x);
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                    }

                }
            }
                
                dataGridView1.DataSource = dt;
        }

        else MessageBox.Show("The file does not exist");
      }
    }
}
