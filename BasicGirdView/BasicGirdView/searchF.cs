using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGirdView
{
    public partial class searchF : Form
    {
        public string findf = "";
        Form1 fr1 = new Form1();
        public searchF()
        {
            InitializeComponent();
            
        }

        private void btsfind_Click(object sender, EventArgs e)
        {
           
           
            string find1="",find2="", find3="", find4="";
            if (txsname.Text == "")
            {
                find1 = "";

            }
            else
            { 
                find1="username like'%" + txsname.Text + "%'";
            }
            if (txsdeparment.Text == "")
            {
                find2 = null;
            }
            else
            {
                if (find1 == "")
                {
                    find2 = " maphong like '%" + txsdeparment.Text + "%'";
                }
                else
                {
                    find2 = "or maphong like '%" + txsdeparment.Text + "%'";
                }
            }

            if (txsposition.Text == "")
            {
                find3 = "";
            }
            else
            {
                if (find1 == "" && find2 == "")
                {
                    find3 = "manghe like '%" + txsposition.Text + "%'";
                }
                else
                {
                    find3 = "or manghe like '%" + txsposition.Text + "%'";
                }
            }
            if (txsmajor.Text == "")
            {
                find4 = "";
            }
            else
            {
                if (find1 == "" && find2 == "" && find3 == "")
                {
                    find4 = "mavt like '%" + txsmajor.Text + "%'";
                }
                else
                {
                    find4 = "mavt like '%" + txsmajor.Text + "%'";
                }
            }
            if (find1 == "" && find2 == "" && find3 == "" && find4=="") findf = "1";
            findf = find1 + find2 + find3 + find4;
         
            string sqlinsert="";                      
            try
            {
                sqlinsert = "select * from users where "+ findf;

               
                fr1.loadUser(sqlinsert);
               // MessageBox.Show(sqlinsert);
                fr1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
        }

    }
}
