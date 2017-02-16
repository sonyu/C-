using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manage_AssyLine
{
    public partial class Form3 : Form
    {
        private int totalupd;
        private string sqltest;
        ConnectSQL conn = new ConnectSQL();
        public Form3(string key1upd, int key2upd)
        {
            InitializeComponent();
            sqltest = key1upd;
            totalupd = key2upd;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            int n,updsql;
            //string readkey;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Please enter digital only !");
                textBox1.Text = "";
            }
            else {
               // pop_form f3defect = new pop_form();
                 updsql= Int32.Parse(textBox1.Text);

                 //MessageBox.Show("up=" + updsql.ToString() + "check key=" + sqltest);
                 string sql = "update txwprd set defqty = "+updsql+",prdqty ="+(totalupd+updsql)+" where cmpcode ='02' and bizdiv ='500'and prdno='"+sqltest+"'";
                 conn.GetDataTable(sql);
                this.Close();
            }
            
        }
    }
}
