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
    public partial class Search_form : Form
    {
        public Search_form()
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
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Columns.Add("File Name");
            dt.Columns.Add("Keywords");
            dt.Columns.Add("Line Number");
            dt.Columns.Add("Repetition Number");
            Engine eng = new Engine();
            for (int i = 0; i < eng.capacity; i++)
            {
                Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
               dic=eng.Display_search(i);
               dr["File Name"] = eng.f_n;
               for (int j = 0; j < dic.Keys.Count; j++)
               {
                   dr["Keywords"] = dic.ElementAt(j).Key;
                   dr["Repetition Number"] = dic.ElementAt(j).Value.Count;
                   for (int x = 0; x < dic.ElementAt(j).Value.Count;x++ )
                   {
                       dr["Line Number"] = dic.ElementAt(j).Value.ElementAt(x);
                       dt.Rows.Add(dr);
                       dr = dt.NewRow();
                   }
               
               }
            
            }
        dataGridView1.DataSource=dt;
        }
    }
}
