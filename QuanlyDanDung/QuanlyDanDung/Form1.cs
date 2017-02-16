using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanlyDanDung
{
    public partial class Form1 : Form
    {
        ConnectSQL ketnoi = new ConnectSQL();    
        public Form1()
        {
            InitializeComponent();
           //s string sql = "Select * from Customers";
            //dataGridView1.DataSource = ketnoi.GetDataTable(sql);

            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //FormBorderStyle = FormBorderStyle.FixedSingle;
           // WindowState = FormWindowState.Maximized;
           // tabGenerate();
            
        }
       
    
        private void  tabGenerate(){

            string sql = "Select * from Category";            
            SqlDataReader reader = ketnoi.getDataReader(sql);        
            
            int i = 0;
            string a = "";
            while (reader.Read())
            {
                TabPage newPage= new TabPage(reader[1].ToString());                
                tabControl1.TabPages.Add(newPage);
                
                //MessageBox.Show(reader[0].ToString()); //The 0 stands for "the 0'th column", so the first column of the result.
                
                if (i == 3)
                {
                    a = reader[1].ToString();
                    tabControl1.TabPages.Remove(newPage);
                }
                i++;
            }            
            tabPage1.Text = a;
            //tabControl1.TabPages.Remove(newPage);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "Select * from Customers";
            dataGridView1.DataSource = ketnoi.GetDataTable(sql);
        }


    }
}
