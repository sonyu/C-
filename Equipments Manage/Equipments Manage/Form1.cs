using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Equipments_Manage
{

    public partial class Form1 : Form
    {
        ConnectSQL conn = new ConnectSQL();
        string sql;
       // bool clickflag = false;
        
        public Form1()
        {
            InitializeComponent();
           // int h = Screen.PrimaryScreen.WorkingArea.Height;
           // int w = Screen.PrimaryScreen.WorkingArea.Width;
           // this.ClientSize = new Size(w, h);
           // MessageBox.Show("h=" + h + "w= " + w);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string sql = "select * from tzjb";
            string sql2 = "select DISTINCT  place from tzjb order by place";
            string sql3 = "select DISTINCT  gubun from tzjb order by gubun";
            dtgv1.DataSource = conn.GetDataTable(sql);
            putdata(comboBox1, sql2);
            putdata(cb_place,sql2);
            putdata(cb_jbcode, sql3);
            insdt_time.CustomFormat = "dd-MM-yyyy";
            upddt_time.CustomFormat = "dd-MM-yyyy";
          //  MessageBox.Show("chuoi :" + catchuoi(3));
            
            
        }


        private void RefreshMyForm(string sql)
        {

           
            dtgv1.DataSource = conn.GetDataTable(sql);
            conn.Disconnect();
        }

        private void putdata(ComboBox cb, string sql)
        {
            
           SqlDataReader dr= conn.getDataReader(sql);
           while (dr.Read())
           {
               cb.Items.Add(dr[0]);

           }
           conn.Disconnect();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string search_department = comboBox1.SelectedItem.ToString();
           string sql = "select * from tzjb where place ='" + search_department + "'";
           RefreshMyForm(sql);
        }

     

        private void gb1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string msg = String.Format("Row: {0}, Column: {1}",
            dtgv1.CurrentCell.RowIndex,
            dtgv1.CurrentCell.ColumnIndex);
            int row = dtgv1.CurrentCell.RowIndex;
            int col = dtgv1.CurrentCell.ColumnIndex;
            cmpcode_tx.Text = dtgv1.Rows[row].Cells[0].Value.ToString();
            bizdiv_tx.Text = dtgv1.Rows[row].Cells[1].Value.ToString();
            jbcode_tx.Text = dtgv1.Rows[row].Cells[2].Value.ToString();
            cb_jbcode.SelectedItem = dtgv1.Rows[row].Cells[3].Value.ToString();            
            empcode_tx.Text = dtgv1.Rows[row].Cells[4].Value.ToString();
            wichi_tx.Text = dtgv1.Rows[row].Cells[5].Value.ToString();            
            cb_place.SelectedItem = dtgv1.Rows[row].Cells[6].Value.ToString();      
            lb_mkym.Text = dtgv1.Rows[row].Cells[7].Value.ToString();
            maker_lb.Text = dtgv1.Rows[row].Cells[8].Value.ToString();
            model_tx.Text = dtgv1.Rows[row].Cells[9].Value.ToString();
            cpu_tx.Text = dtgv1.Rows[row].Cells[10].Value.ToString();
            hdd1_tx.Text = dtgv1.Rows[row].Cells[11].Value.ToString();
            hdd2_tx.Text = dtgv1.Rows[row].Cells[12].Value.ToString();
            hdd3_tx.Text = dtgv1.Rows[row].Cells[13].Value.ToString();
            ram_tx.Text = dtgv1.Rows[row].Cells[14].Value.ToString();
            inch_tx.Text = dtgv1.Rows[row].Cells[15].Value.ToString();
            port_lb.Text = dtgv1.Rows[row].Cells[16].Value.ToString();
            bdos_lb.Text = dtgv1.Rows[row].Cells[17].Value.ToString();
            wkos_tx.Text = dtgv1.Rows[row].Cells[18].Value.ToString();
            ip_tx.Text = dtgv1.Rows[row].Cells[19].Value.ToString();
            ipgubun_tx.Text = dtgv1.Rows[row].Cells[20].Value.ToString();
            useyn_tx.Text = dtgv1.Rows[row].Cells[21].Value.ToString();
            pgyn_tx.Text = dtgv1.Rows[row].Cells[22].Value.ToString();
            pgdt_tx.Text = dtgv1.Rows[row].Cells[23].Value.ToString();
            pgreason_tx.Text = dtgv1.Rows[row].Cells[24].Value.ToString();
            etc1_tx.Text = dtgv1.Rows[row].Cells[25].Value.ToString();
            etc2_tx.Text = dtgv1.Rows[row].Cells[26].Value.ToString();
            remark_tx.Text = dtgv1.Rows[row].Cells[27].Value.ToString();
            buydt_tx.Text = dtgv1.Rows[row].Cells[28].Value.ToString();
            buycust_tx.Text = dtgv1.Rows[row].Cells[29].Value.ToString();
            buyamt_tx.Text = dtgv1.Rows[row].Cells[30].Value.ToString();
            insempcode_tx.Text = dtgv1.Rows[row].Cells[31].Value.ToString();
            insdt_time.Text = dtgv1.Rows[row].Cells[32].Value.ToString();
            updempcode_tx.Text = dtgv1.Rows[row].Cells[33].Value.ToString();
            upddt_time.Text = dtgv1.Rows[row].Cells[34].Value.ToString();
           
        }

        private void update_bt_Click(object sender, EventArgs e)
        {
            int row = dtgv1.CurrentCell.RowIndex;
            int col = dtgv1.CurrentCell.ColumnIndex;

            sql = "insert into tzjb value('" +
                 "01"+"','"+
            "200" +"','"+
            jbcode_tx.Text  +"','"+            
            empcode_tx.Text  +"','"+
            wichi_tx.Text  +"','"+            
            lb_mkym.Text  +"','"+
            maker_lb.Text  +"','"+
            model_tx.Text  +"','"+
            cpu_tx.Text   +"','"+
            hdd1_tx.Text   +"','"+
            hdd2_tx.Text   +"','"+
            hdd3_tx.Text   +"','"+
            ram_tx.Text   +"','"+
            inch_tx.Text   +"','"+
            port_lb.Text   +"','"+
            bdos_lb.Text   +"','"+
            wkos_tx.Text   +"','"+
            ip_tx.Text  +"','"+
            ipgubun_tx.Text  +"','"+
            useyn_tx.Text  +"','"+
            pgyn_tx.Text  +"','"+
            pgdt_tx.Text  +"','"+
            pgreason_tx.Text  +"','"+
            etc1_tx.Text  +"','"+
            etc2_tx.Text  +"','"+
            remark_tx.Text  +"','"+
            buydt_tx.Text  +"','"+
            buycust_tx.Text  +"','"+
            buyamt_tx.Text  +"','"+
            insempcode_tx.Text  +"','"+
            insdt_time.Value  +"','"+
            updempcode_tx.Text + "','" +
            upddt_time.Value + "','" +
            
            "')";
           
                conn.ExecuteNonQuery(sql);
                MessageBox.Show("Insert database success !");
              //  clickflag = false;
                //if (cmpcode_tx.Text == "" || bizdiv_tx.Text == "" || jbcode_tx.Text == "")
                //{
                //    MessageBox.Show("jbcode cannot empty. Please insert value !");
                //}
                //else {
                //    conn.ExecuteNonQuery(sql);
                //    MessageBox.Show("Insert database success !");
                //    clickflag = false;
                //}
           
        }

      

        private string catchuoi(string s,int i)
        {
            string jbcode = "";
            sql = "SELECT TOP 1 jbcode FROM tzjb where gubun ='" + s + "'  ORDER BY jbcode DESC";
           SqlDataReader reader= conn.getDataReader(sql);

           while (reader.Read())
           {
               jbcode = jbcode + reader[0];
               //MessageBox.Show("Im here"+ jbcode);
           }
               //jbcode = reader.GetString(1);
              // M/essageBox.Show(jbcode);
           jbcode = jbcode.Substring(i);          
           return jbcode;

        }

        private void insert_bt_Click(object sender, EventArgs e)
        {
            int row = dtgv1.CurrentCell.RowIndex;
            int col = dtgv1.CurrentCell.ColumnIndex;
            string jbcode = "";
            jbcode = cb_jbcode.SelectedItem.ToString();
            jbcode_tx.Text = jbcode + "-" + ghepchuoi((Int32.Parse(catchuoi(jbcode,3))+1).ToString());
            MessageBox.Show("jb = " + jbcode_tx.Text.ToString());
            sql = "insert into tzjb values('"+
            "01" + "','" +
            "200" + "','" +
            jbcode_tx.Text + "','" +
            cb_jbcode.SelectedItem + "','" +
            empcode_tx.Text + "','" +
            wichi_tx.Text + "','" +
            cb_place.SelectedItem + "','" +
            lb_mkym.Text + "','" +
            maker_lb.Text + "','" +
            model_tx.Text + "','" +
            cpu_tx.Text + "','" +
            hdd1_tx.Text + "','" +
            hdd2_tx.Text + "','" +
            hdd3_tx.Text + "','" +
            ram_tx.Text + "','" +
            inch_tx.Text + "','" +
            port_lb.Text + "','" +
            bdos_lb.Text + "','" +
            wkos_tx.Text + "','" +
            ip_tx.Text + "','" +
            ipgubun_tx.Text + "','" +
            useyn_tx.Text + "','" +
            pgyn_tx.Text + "','" +
            pgdt_tx.Text + "','" +
            pgreason_tx.Text + "','" +
            etc1_tx.Text + "','" +
            etc2_tx.Text + "','" +
            remark_tx.Text + "','" +
            buydt_tx.Text + "','" +
            buycust_tx.Text + "','" +
            buyamt_tx.Text + "','" +
            insempcode_tx.Text + "','" +
            insdt_time.Text + "','" +
            updempcode_tx.Text + "','" +
            upddt_time.Text + "')";

            conn.Disconnect();
            conn.ExecuteNonQuery(sql);
            MessageBox.Show("Insert database success !");
                
                //if (cmpcode_tx.Text == "" || bizdiv_tx.Text == "" || jbcode_tx.Text == "")
                //{
                //    MessageBox.Show("jbcode cannot empty. Please insert value !");
                //}
                //else {
                //    conn.ExecuteNonQuery(sql);
                //    MessageBox.Show("Insert database success !");
                //    clickflag = false;
                //}
           
        }
        private string ghepchuoi(string s)
        {
            int i = s.Length;
            switch (i)
            { 
                case 0:
                    s = "00000";
                    break;
                case 1:
                    s = "0000"+s;
                    break;
                case 2:
                    s = "000" + s;
                    break;
                case 3:
                    s = "00" + s;
                    break;
                case 4:
                    s = "0" + s;
                    break;              
                   
                default:
                    s = "ERROR";
                    break;
            }
            return s;
        }

        private void empcode_tx_Leave(object sender, EventArgs e)
        {
            if (empcode_tx.Text.ToString().Length >10)
            {
                MessageBox.Show("'empcode' field incorrect. Try again please !");
                empcode_tx.Text = "";
                empcode_tx.Focus();
            }
        }

        private void wichi_tx_Leave(object sender, EventArgs e)
        {
            if (wichi_tx.Text.ToString().Length >6)
            {
                MessageBox.Show("'wichi' field incorrect. Try again please !");
                wichi_tx.Text = "";
                wichi_tx.Focus();
            }
        }

        private void mkym_tx_Leave(object sender, EventArgs e)
        {
            if (mkym_tx.Text.ToString().Length > 6)
            {
                MessageBox.Show("'mkym' field incorrect. Try again please !");
                mkym_tx.Text = "";
                mkym_tx.Focus();
            }
        }

        private void maker_tx_Leave(object sender, EventArgs e)
        {

            if (maker_tx.Text.ToString().Length > 6)
            {
                MessageBox.Show("'maker' field incorrect. Try again please !");
                maker_tx.Text = "";
                maker_tx.Focus();
            }
        }

        private void model_tx_Leave(object sender, EventArgs e)
        {

            if (model_tx.Text.ToString().Length > 30)
            {
                MessageBox.Show("'model' field incorrect. Try again please !");
                model_tx.Text = "";
                model_tx.Focus();
            }
        }

        private void cpu_tx_Leave(object sender, EventArgs e)
        {

            if (cpu_tx.Text.ToString().Length > 30)
            {
                MessageBox.Show("'cpu' field incorrect. Try again please !");
                cpu_tx.Text = "";
                cpu_tx.Focus();
            }
        }

        private void hdd1_tx_Leave(object sender, EventArgs e)
        {
            if (hdd1_tx.Text.ToString().Length > 10)
            {
                MessageBox.Show("'hdd1' field incorrect. Try again please !");
                hdd1_tx.Text = "";
                hdd1_tx.Focus();
            }
        }

        private void hdd2_tx_Leave(object sender, EventArgs e)
        {
            if (hdd2_tx.Text.ToString().Length > 10)
            {
                MessageBox.Show("'hdd2' field incorrect. Try again please !");
                hdd2_tx.Text = "";
                hdd2_tx.Focus();
            }
        }

        private void hdd3_tx_Leave(object sender, EventArgs e)
        {
            if (hdd3_tx.Text.ToString().Length > 10)
            {
                MessageBox.Show("'hdd3' field incorrect. Try again please !");
                hdd3_tx.Text = "";
                hdd3_tx.Focus();
            }
        }

        private void ram_tx_Leave(object sender, EventArgs e)
        {
            if (ram_tx.Text.ToString().Length > 20)
            {
                MessageBox.Show("'ram' field incorrect. Try again please !");
                ram_tx.Text = "";
                ram_tx.Focus();
            }
        }

        private void inch_tx_Leave(object sender, EventArgs e)
        {
            if (inch_tx.Text.All(char.IsDigit) == false)
            {

                MessageBox.Show("'inch' field incorrect. This field only is digital please !");
                inch_tx.Text = "";
                inch_tx.Focus();
            }
            else
            {
                if (inch_tx.Text.Length>4)
                {
                    MessageBox.Show("'inch' field incorrect. This field can't is big size or less than rezo !");
                    inch_tx.Text = "";
                    inch_tx.Focus();
                }
            }
        }

        private void port_tx_Leave(object sender, EventArgs e)
        {
            if (port_tx.Text.All(char.IsDigit) == false)
            {

                MessageBox.Show("'port' field incorrect. This field only is digital please !");
                port_tx.Text = "";
                port_tx.Focus();
            }
            else
            {
                if (port_tx.Text.Length > 5)
                {
                    MessageBox.Show("'port' field incorrect. This field can't is big size or less than rezo !");
                    port_tx.Text = "";
                    port_tx.Focus();
                }
            }
        }


        private void bdos_tx_Leave(object sender, EventArgs e)
        {
            if (bdos_tx.Text.ToString().Length > 6)
            {
                MessageBox.Show("'bdos' field incorrect. Try again please !");
                bdos_tx.Text = "";
                bdos_tx.Focus();
            }
        }

        private void wkos_tx_Leave(object sender, EventArgs e)
        {
            if (wkos_tx.Text.ToString().Length > 6)
            {
                MessageBox.Show("'wkos' field incorrect. Try again please !");
                wkos_tx.Text = "";
                wkos_tx.Focus();
            }
        }

        private void ip_tx_Leave(object sender, EventArgs e)
        {
            string s1,s2,s3,s4, s =ip_tx.Text;
            if (s.Length != 15)
            {
                MessageBox.Show("'ip' field size must be 15 characters ! ");
                ip_tx.Text = "";
                ip_tx.Focus();
            }
            else
            {
                s1 = s.Substring(0, 3);
                s2 = s.Substring(4, 3);
                s3 = s.Substring(8, 3);
                s4 = s.Substring(12, 3);
                if (s[3] != 46 && s[7] != 46 && s[11] != 46)
                {
                    MessageBox.Show("'ip' field  must be 'dot' character in 4, 8,12 positions !");
                    ip_tx.Text = "";
                    ip_tx.Focus();
                }
                if (int.Parse(s1) > 255|| int.Parse(s2) > 255 || int.Parse(s3) > 255 || int.Parse(s4) > 255)
                {
                    MessageBox.Show("'ip' field  Cannot over 255 s1"+s1+"s2"+s2+"s3"+s3+"s4"+s4);
                    ip_tx.Text = "";
                    ip_tx.Focus();
                }
               // MessageBox.Show("'ip' field  Cannot over 255 s1" + s1 + "s2" + s2 + "s3" + s3 + "s4" + s4);
            }
        }

        private void ipgubun_tx_Leave(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s = ipgubun_tx.Text;
            if (s.Length != 15)
            {
                MessageBox.Show("'ip' field size must be 15 characters ! ");
                ipgubun_tx.Text = "";
                ipgubun_tx.Focus();
            }
            else
            {
                s1 = s.Substring(0, 3);
                s2 = s.Substring(4, 3);
                s3 = s.Substring(8, 3);
                s4 = s.Substring(12, 3);
                if (s[3] != 46 && s[7] != 46 && s[11] != 46)
                {
                    MessageBox.Show("'ip' field  must be 'dot' character in 4, 8,12 positions !");
                    ipgubun_tx.Text = "";
                    ipgubun_tx.Focus();
                }
                if (int.Parse(s1) > 255 || int.Parse(s2) > 255 || int.Parse(s3) > 255 || int.Parse(s4) > 255)
                {
                    MessageBox.Show("'ip' field  Cannot over 255 s1" + s1 + "s2" + s2 + "s3" + s3 + "s4" + s4);
                    ipgubun_tx.Text = "";
                    ipgubun_tx.Focus();
                }
                // MessageBox.Show("'ip' field  Cannot over 255 s1" + s1 + "s2" + s2 + "s3" + s3 + "s4" + s4);
            }
        }

        private void useyn_tx_Leave(object sender, EventArgs e)
        {
            if (useyn_tx.Text.ToString().Length > 1)
            {
                MessageBox.Show("'useyn' field incorrect. Try again please !");
                useyn_tx.Text = "";
                useyn_tx.Focus();
            }
        }

        private void pgyn_tx_Leave(object sender, EventArgs e)
        {
            if (pgyn_tx.Text.ToString().Length > 1)
            {
                MessageBox.Show("'pgyn' field incorrect. Try again please !");
                pgyn_tx.Text = "";
                pgyn_tx.Focus();
            }
        }

        private void pgdt_tx_Leave(object sender, EventArgs e)
        {
            if (pgdt_tx.Text.ToString().Length > 8)
            {
                MessageBox.Show("'pgd' field incorrect. Try again please !");
                pgdt_tx.Text = "";
                pgdt_tx.Focus();
            }
        }

        private void pgreason_tx_Leave(object sender, EventArgs e)
        {
            if (pgreason_tx.Text.ToString().Length > 30)
            {
                MessageBox.Show("'pgreason' field incorrect. Try again please !");
                pgreason_tx.Text = "";
                pgreason_tx.Focus();
            }
        }

        private void etc1_tx_Leave(object sender, EventArgs e)
        {
            if (etc1_tx.Text.ToString().Length > 100)
            {
                MessageBox.Show("'etc1' field cannot over 100 characters. Try again please !");
                etc1_tx.Text = "";
                etc1_tx.Focus();
            }
        }

        private void etc2_tx_Leave(object sender, EventArgs e)
        {
            if (etc2_tx.Text.ToString().Length > 100)
            {
                MessageBox.Show("'etc2' field cannot over 100 characters. Try again please !");
                etc2_tx.Text = "";
                etc2_tx.Focus();
            }
        }

        private void remark_tx_Leave(object sender, EventArgs e)
        {
            if (remark_tx.Text.ToString().Length > 300)
            {
                MessageBox.Show("'remark' field cannot over 300 characters. Try again please !");
                remark_tx.Text = "";
                remark_tx.Focus();
            }
        }

        private void buydt_tx_Leave(object sender, EventArgs e)
        {
            if (buydt_tx.Text.ToString().Length > 8)
            {
                MessageBox.Show("'buydt' field cannot over 8 characters. Try again please !");
                buydt_tx.Text = "";
                buydt_tx.Focus();
            }
        }

        private void buycust_tx_Leave(object sender, EventArgs e)
        {
            if (buycust_tx.Text.ToString().Length > 30)
            {
                MessageBox.Show("'buycust' field cannot over 30 characters. Try again please !");
                buycust_tx.Text = "";
                buycust_tx.Focus();
            }
        }

        private void buyamt_tx_Leave(object sender, EventArgs e)
        {
            if (buyamt_tx.Text.All(char.IsDigit) == false)
            {

                MessageBox.Show("'buyamt' field incorrect. This field only is digital please !");
                buyamt_tx.Text = "";
                buyamt_tx.Focus();
            }
            else
            {
                if (buyamt_tx.Text.Length > 8)
                {
                    MessageBox.Show("'buyamt' field incorrect. This field can't is big size or less than rezo !");
                    buyamt_tx.Text = "";
                    buyamt_tx.Focus();
                }
            }
        }

        private void insempcode_tx_Leave(object sender, EventArgs e)
        {

            if (insempcode_tx.Text.ToString().Length > 10)
            {
                MessageBox.Show("'insempcode' field cannot over 10 characters. Try again please !");
                insempcode_tx.Text = "";
                insempcode_tx.Focus();
            }
        }

        private void upddt_time_Leave(object sender, EventArgs e)
        {
            upddt_time.CustomFormat = "dd-MM-yyyy";
            insdt_time.CustomFormat = "dd-MM-yyyy";

            int result = DateTime.Compare(insdt_time.Value,upddt_time.Value);

            if (result > 0)
            {
                MessageBox.Show("time 'upddt' is cannot later than insdt !");
                upddt_time.Value = insdt_time.Value;
            }
            
        }
        
    }
    
}
