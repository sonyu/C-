using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BasicGirdView
{
    public partial class Form1 : Form
    {
        connSQL conn = new connSQL();
        public Form1()
        {
            InitializeComponent();
            loadUser("select * from users");
        }
        public void loadUser(string sql)
        {
            //string sql = "select * from Users";
            //conn.connect();
            dataGridView1.DataSource = conn.getDataTable(sql);

        }
        private bool checkKeyUser(string ukey)
        {
           string sql ="select id_u from Users where id_u='"+ ukey +"'";
           
           SqlDataReader checker = conn.getDataReader(sql);
           bool check = false;
           while(checker.Read())
           {
               //MessageBox.Show(checker["id_u"].ToString());
               return true;    
           }
           //MessageBox.Show("not found any rows");
           conn.disConnect();
           return check;           
        }

        private void btinsert_Click(object sender, EventArgs e)
        {
            int colGv = dataGridView1.CurrentCell.ColumnIndex;
            int rowGv = dataGridView1.CurrentCell.RowIndex;
            int countCol = dataGridView1.ColumnCount;
            string sqlinsert,chuoi = "";
            //MessageBox.Show(dataGridView1.Rows[rowGv].Cells[colGv].Value.ToString());
            //MessageBox.Show(countCol.ToString());
            string ukey = dataGridView1.Rows[rowGv].Cells[0].Value.ToString();
            string comma = "','";
            for (int i = 0; i < countCol; i++)
            {
                if (i == countCol - 1) comma = "";
                chuoi = chuoi + dataGridView1.Rows[rowGv].Cells[i].Value.ToString()+comma;
            }
                if (checkKeyUser(ukey))
                {

                    MessageBox.Show("NG");
                }
                else
                {
                    
                    sqlinsert = "insert into users values('" + chuoi + "')";
                    //conn.connect();
                    conn.excuteQuery(sqlinsert);
                    
                    MessageBox.Show("insert ok");
                    loadUser("select* from users");
                } 
        }

        private void btupdate_Click(object sender, EventArgs e)
        {

            int colGv = dataGridView1.CurrentCell.ColumnIndex;
            int rowGv = dataGridView1.CurrentCell.RowIndex;
            int countCol = dataGridView1.ColumnCount;
            string sqlinsert;
            //MessageBox.Show(dataGridView1.Rows[rowGv].Cells[colGv].Value.ToString());
            //MessageBox.Show(countCol.ToString());

            try
            {
                sqlinsert = "update users set  username ='" + dataGridView1.Rows[rowGv].Cells[1].Value.ToString() +
                   "',maphong='" + dataGridView1.Rows[rowGv].Cells[2].Value.ToString() +
                   "', manghe='" + dataGridView1.Rows[rowGv].Cells[3].Value.ToString() +
                   "', mavt='" + dataGridView1.Rows[rowGv].Cells[4].Value.ToString() + "' where id_u='" + dataGridView1.Rows[rowGv].Cells[0].Value.ToString() + "'";
                //conn.connect();
                conn.excuteQuery(sqlinsert);

                MessageBox.Show("update ok");
                loadUser("select * from users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
               
           
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            int colGv = dataGridView1.CurrentCell.ColumnIndex;
            int rowGv = dataGridView1.CurrentCell.RowIndex;
            int countCol = dataGridView1.ColumnCount;
            string sqlinsert;
            //MessageBox.Show(dataGridView1.Rows[rowGv].Cells[colGv].Value.ToString());
            //MessageBox.Show(countCol.ToString());

            try
            {
                sqlinsert = "delete from users where  id_u='" + dataGridView1.Rows[rowGv].Cells[0].Value.ToString() +"'";
                //conn.connect();
                conn.excuteQuery(sqlinsert);

                MessageBox.Show("delete ok");
                loadUser("select * from users");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
               
           
        
        }

        private void btsearch_Click(object sender, EventArgs e)
        {
            searchF findfr = new searchF();            
            findfr.Show();
            
        }

    }
}
