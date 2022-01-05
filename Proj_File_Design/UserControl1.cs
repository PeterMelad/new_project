using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj_File_Design
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserControl1 c1 = new UserControl1();
            
            //c1.Visible = false;
            //Form1 f1 = new Form1();
            //f1.Show();
            this.Width = 0;
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
     
        }
    }
}
