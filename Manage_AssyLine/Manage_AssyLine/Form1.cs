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
    public partial class main_form : Form
    {
        int HeightScreen = Screen.PrimaryScreen.Bounds.Height;
        int WidthScreen = Screen.PrimaryScreen.Bounds.Width;
        ConnectSQL conn = new ConnectSQL();
        
        string sqlmacno ="";
        string sqlshift = "";
        string sqlline = "";        
        string sqlwodt = "";
        string sqlsearch = "";
        string sql_main = "";
        public main_form()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(WidthScreen, HeightScreen);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select distinct macno from txwprd order by macno";
            string sql2 = "select * from txwprd";
            conn.Connect();
            DataTable dt = conn.GetDataTable(sql);
            DataTable dt2 = conn.GetDataTable(sql2);
            
            //da.Fill(ds);
            comboBox1.DisplayMember = "macno";
            comboBox1.ValueMember = "macno";

            comboBox1.DataSource = dt;
            comboBox1.Enabled = true;
            dataGridView1.DataSource = dt2;
            conn.Disconnect();
        }
     

        private void main_form_MaximumSizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                int newh, neww, fontsize, child_w, child_h;

                newh = HeightScreen * c.Size.Height / 768;
                neww = WidthScreen * c.Size.Width / 1024;
                fontsize = Convert.ToInt32(c.Font.Size) * WidthScreen / 1024;
                c.Size = new Size(neww, newh);
                c.Location = new Point(c.Location.X * WidthScreen / 1024, c.Location.Y * HeightScreen / 768);
                c.Font = new Font(c.Font.FontFamily, fontsize);
                // MessageBox.Show("x =" + c.Location.X + "y = " + c.Location.Y + "dx = " + c.Size.Width + " dy = " + c.Size.Height);
                if (c.Controls.Count > 0)
                {

                    foreach (Control child_c in c.Controls)
                    {
                        // MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                        child_h = HeightScreen * child_c.Size.Height / 768;
                        child_w = WidthScreen * child_c.Size.Width / 1024;
                        child_c.Size = new Size(child_w, child_h);
                        child_c.Location = new Point(child_c.Location.X * WidthScreen / 1024, child_c.Location.Y * HeightScreen / 768);
                        //MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                    }
                }
            }

        }

        private void bt_finish_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Application.Exit();
            //this.Close();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.Text != "")
            {
                sqlshift = "and prdshift ='" + comboBox2.Text + "' ";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
                //MessageBox.Show("sql main ="+sql_main);
                
            conn.Connect();        
            DataTable dt2 = conn.GetDataTable(sql_main);

           
            dataGridView1.DataSource = dt2;
            conn.Disconnect();
            //MessageBox.Show("sql= "+ sql_main);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.Text != "")
            {
                sqlmacno = "and macno ='" + comboBox1.Text + "' ";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
               
                comboBox1.SelectedItem = comboBox1.Text;
                conn.Connect();
           
                DataTable dt2 = conn.GetDataTable(sql_main);

            
                dataGridView1.DataSource = dt2;
                conn.Disconnect();
               // MessageBox.Show("sql= " + sql_main);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyyMMdd"));
            //string sql2 = "select * from txwprd where wodt like'" + dateTimePicker1.Value.ToString("yyyyMMdd") + "'";
            //comboBox1.SelectedItem = comboBox1.Text;
          //  conn.Connect();
            if (dateTimePicker1.Value.ToString("yyyyMMdd") != "")
            {
                sqlwodt = "and wodt between '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "' ";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
                conn.Connect();

                DataTable dt2 = conn.GetDataTable(sql_main);

                dataGridView1.DataSource = dt2;
                conn.Disconnect();
               // MessageBox.Show("sql= " + sql_main);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //conn.Connect();
            if (dateTimePicker2.Value.ToString("yyyyMMdd") != "")
            {
                sqlwodt = "and wodt between '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "' ";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
                conn.Connect();

                DataTable dt2 = conn.GetDataTable(sql_main);

                dataGridView1.DataSource = dt2;
                conn.Disconnect();
               // MessageBox.Show("sql= " + sql_main);
            }
        }

        private void search_tx_TextChanged(object sender, EventArgs e)
        {
            if (search_tx.Text != "")
            {
                sqlsearch = "and prdempname = '" + search_tx.Text + "'";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
                // MessageBox.Show(sql_main);
                conn.Connect();

                DataTable dt2 = conn.GetDataTable(sql_main);

                dataGridView1.DataSource = dt2;
                conn.Disconnect();
                //MessageBox.Show("sql= " + sql_main);
            }
            else
            {
                sqlsearch = "";
                sql_main = "select * from txwprd where 1 = 1" + sqlmacno + sqlshift + sqlline + sqlwodt + sqlsearch + " order by starttime desc";
                conn.Connect();

                DataTable dt2 = conn.GetDataTable(sql_main);

                dataGridView1.DataSource = dt2;
                conn.Disconnect();
               // MessageBox.Show("sql= " + sql_main);
            }
        }

        private void bt_fixdef_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_input_Click(object sender, EventArgs e)
        {   
            //Form.ActiveForm.Close();
            this.Hide();
            //this.Close();
            main_form mfrm = new main_form();
            mfrm.Close();            
            pop_form frm = new pop_form();
            frm.Show();
            
        }

    }
}