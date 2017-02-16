using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace Manage_AssyLine
{
    public partial class pop_form : Form
    {
        int HeightScreen = Screen.PrimaryScreen.Bounds.Height;
        int WidthScreen = Screen.PrimaryScreen.Bounds.Width;
        int qtyOk, qtyNg, qtyTotal;        
        DateTime starttime, endtime;
        ConnectSQL conn = new ConnectSQL();
        public string key1upd { get; set; }
        public int key2upd { get; set; }
        public pop_form()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(WidthScreen, HeightScreen);
            start_bt.Enabled = false;
            save_bt.Enabled = false;
            
            fresh_bt.Enabled = true;
        }

        private void pop_form_MaximumSizeChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            main_form frm = new main_form();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            line_cb.Text = "";
            emp_tx.Text = "";
            shift_cb.Text = "";
            enter_code_tx.Text = "";
            code_check_tx.Text = "";
            ok_tx.Text = "";
            ng_tx.Text = "";
            total_tx.Text = "";
            result_bl.Text = "";
            start_bt.Enabled = false;
            save_bt.Enabled = false;
            button1.Enabled = true;
            line_cb.Enabled = true;
            emp_tx.Enabled = true;
            shift_cb.Enabled = true;
            enter_code_tx.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (line_cb.Text == "" && emp_tx.Text == "" && shift_cb.Text == "" && enter_code_tx.Text == "")
            {
                MessageBox.Show("Line number, Employee name, Shift, Enter code : cannot empty . Please enter these fields !");
                emp_tx.Focus();
            }
            else
            {
                line_cb.Enabled = false;
                emp_tx.Enabled = false;
                shift_cb.Enabled = false;
                enter_code_tx.Enabled = false;
                code_check_tx.Enabled = true;
                qtyOk = qtyNg = qtyTotal = 0;
                this.ActiveControl = code_check_tx;
                starttime = DateTime.Now;
                save_bt.Enabled = true;
                start_bt.Enabled = false;               
                fresh_bt.Enabled = false;
                button1.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            line_cb.Enabled = true;
            emp_tx.Enabled = true;
            shift_cb.Enabled = true;
            enter_code_tx.Enabled = true;
        }

       
        private void code_check_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SoundPlayer failed = new SoundPlayer(@"E:\C#\Manage_AssyLine\Manage_AssyLine\sound\failed.wav");
                SoundPlayer passed = new SoundPlayer(@"E:\C#\Manage_AssyLine\Manage_AssyLine\sound\pass.wav");
                if (enter_code_tx.Text == code_check_tx.Text && code_check_tx.Text != "")
                {
                    passed.Play();
                    qtyOk++;
                    code_check_tx.Text = "";
                    result_bl.Text = "OK";
                    result_bl.ForeColor = Color.Blue;
                    //result_tx.BackColor = Color.Blue;


                }
                else if (enter_code_tx.Text != code_check_tx.Text && code_check_tx.Text != "")
                {
                    failed.Play();
                    qtyNg++;
                    code_check_tx.Text = "";
                    result_bl.Text = "NG";
                    result_bl.ForeColor = Color.Red;
                    //result_tx.BackColor = Color.Red;
                }
                qtyTotal = qtyNg + qtyOk;
                ok_tx.Text = qtyOk.ToString();
                ng_tx.Text = qtyNg.ToString();
                total_tx.Text = qtyTotal.ToString();
            }
        }

        private void save_bt_Click(object sender, EventArgs e)
        {
            int number = 0;
            endtime = DateTime.Now;
            string strline, numbers;

            
            //MessageBox.Show(defect.ToString());
            switch (line_cb.Text)
            {
                case "Line 1":
                    strline = "P150001";
                    break;
                case "Line 2":
                    strline = "P150002";
                    break;
                case "Line 3":
                    strline = "P150003";
                    break;
                case "Line 4":
                    strline = "P150004";
                    break;
                case "Line 5":
                    strline = "P150005";
                    break;
                case "Line 6":
                    strline = "P150006";
                    break;
                case "Line 7":
                    strline = "P150007";
                    break;
                default:
                    strline = "";
                    break;
            }

            string sqlnum = "SELECT  prdno FROM txwprd where wodt ='" + starttime.ToString("yyyyMMdd") + "' and macno = '" + strline + "'";
            //conn.GetDataTable(sqlnum);
            number = conn.GetDataTable(sqlnum).Rows.Count;
            if (number == 0)
            {
                number = 1;
            }
            else
            {
                number = number + 1;
            }

            numbers = number.ToString("000");

            string sql3 = "insert into txwprd values(" +
            "'02'," +
            "'500'," +
            "'" + strline + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + numbers + "'," +
            "'" + enter_code_tx.Text + "'," +
            "'" + strline.Substring(0, 4) + "'," +
            "'" + strline+"'," +
            "'" + DateTime.Now.ToString("yyyyMMdd") + "'," +
            "'" + DateTime.Now.ToString("yyyyMMdd") + "'," +
            Int32.Parse(total_tx.Text) + "," +
            Int32.Parse(ok_tx.Text) + "," +
            0 + "," +
            Int32.Parse(ng_tx.Text) + "," +
            
            "'" + starttime + "'," +
            "'" + endtime + "'," +
            "'" + emp_tx.Text + "'," +
            "'" + shift_cb.Text + "'," +
            "'" + "" + "'," +
            "'HT" + strline.Substring(5, 2) + "'," +
            "'" + endtime + "')";
            save_bt.Enabled = false;
            fresh_bt.Enabled = true;
            button1.Enabled = true;
            conn.GetDataTable(sql3);

            key1upd = strline + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + numbers;
            key2upd = Int32.Parse(total_tx.Text);
            Form3 frm3 = new Form3(key1upd,key2upd);
            frm3.Show();
             
            
        }
              

        private void emp_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (line_cb.Text != "" && emp_tx.Text != "" && enter_code_tx.Text != "" && shift_cb.Text != "")
            {
                code_check_tx.Focus();
                start_bt.Enabled = true;
            }
        }

        private void shift_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (line_cb.Text != "" && emp_tx.Text != "" && enter_code_tx.Text != "" && shift_cb.Text != "")
            {
                code_check_tx.Focus();
                start_bt.Enabled = true;
            }
        }

        private void enter_code_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (line_cb.Text != "" && emp_tx.Text != "" && enter_code_tx.Text != "" && shift_cb.Text != "")
                {
                    code_check_tx.Focus();
                    start_bt.Enabled = true;
                }
            }
        }

        private void line_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (line_cb.Text != "" && emp_tx.Text != "" && enter_code_tx.Text != "" && shift_cb.Text != "")
            {
                code_check_tx.Focus();
                start_bt.Enabled = true;
            }
        }
    }
}
