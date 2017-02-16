using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Print_code
{
    public partial class Form1 : Form
    {
        int HeightScreen = Screen.PrimaryScreen.Bounds.Height;
        int WidthScreen = Screen.PrimaryScreen.Bounds.Width;
        SQLConnect conn = new SQLConnect();
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(WidthScreen, HeightScreen);
            putcbshift(cb_shift, 0);
            putcbshift(cb1_shift1,0);
            //cb_process.Text = "ALL";
            string sql1 = "select processname_eng, processcode from tmstprocess";
            string sql2 = "select macno,macname_eng from tmstprocmac";
            getdt_cb(sql1, "processname_eng", "processcode", cb_process);
            getdt_cb(sql2, "macname_eng", "macno", cb_macno);
            //putcbshift(cb_shift,1);

            //edit form 

            getdt_cb(sql1, "processname_eng", "processcode", cb1_process);
            //getdt_cb(sql1, "processname", "processcode", cb1_next_process);
            getdt_cb(sql2, "macname_eng", "macno", cb1_macno);

            getdt_cb(sql1, "processname_eng", "processcode", cb1_next_process);
            //string sql3 = "select workcode,workcodename from tmstprocwork";
            //getdt_cb(sql3, "workcodename", "workcode", cb1_next_work);
            //getdt_cb(sql3, "workcodename", "workcode", cb1_workname);
            //PopulateRows(); 
        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
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

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_codecheckedDataSet.tmstprocess' table. You can move, or remove it, as needed.
           // this.tmstprocessTableAdapter.Fill(this.db_codecheckedDataSet.tmstprocess);
            string sql = "SELECT a.wodt,a.prdshift,a.prddt,a.idno,b.macname_eng,a.prdno,a.lotno,a.prdqty,a.unit,a.macno,a.fmtcnt,a.packtype,a.pltqty,a.pltsts,a.process,a.nextprocess,a.nextworkcode,a.workcode,a.worker,a.remark,a.insdt,a.insemp,a.upddt,a.updemp,a.mixyn FROM tmwidt a,tmstprocmac b WHERE a.macno=b.macno";

            //conn.Connect();
            DataTable dt1 = conn.GetDataTable(sql);


            dataGridView1.DataSource = dt1;
           // conn.Disconnect();
           

           
        }
        public void getdt_cb(string sql,string displayname, string valuename,ComboBox cb)
        {
            conn.Connect();
            //cb.Items.Insert(0, "ALL");
            DataTable dt = conn.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[displayname] = "ALL";
            dr[valuename] = "%";
            dt.Rows.InsertAt(dr,0);
            cb.Items.Add(dr);
            
            cb.DataSource = dt;
            conn.Disconnect();
            cb.DisplayMember = displayname;
            cb.ValueMember = valuename;
        }
        public void getdt_cb_edit(string sql, string displayname, string valuename, ComboBox cb)
        {
            //conn.Connect();
            //cb.Items.Insert(0, "ALL");
            DataTable dt = conn.GetDataTable(sql);
            //DataRow dr = dt.NewRow();
            //dr[displayname] = "ALL";
            //dr[valuename] = "%";
            //dt.Rows.InsertAt(dr, 0);
            //cb.Items.Add(dr);

            cb.DataSource = dt;
            //conn.Disconnect();
            cb.DisplayMember = displayname;
            cb.ValueMember = valuename;
        }
        public void putcbshift(ComboBox cb, int selectnum)
        {
            cb.DisplayMember = "Text";
            cb.ValueMember = "Value";
            var items = new[] {
            new { Text = "ALL", Value = "%" },
            new { Text = "Day Shift", Value = "D" },
            new { Text = "Night Shift", Value = "N" }
            };
            //cb.Items.Add(new { Text = "ALL", Value = "%" });
            //cb.Items.Add(new { Text = "Day Shift", Value = "D" });
            //cb.Items.Add(new { Text = "Night Shift", Value = "N" });
            cb.DataSource = items;
            cb.SelectedIndex = selectnum;
            
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentCell != null)
           {
               int index = dataGridView1.CurrentRow.Index;
               if (dataGridView1.Rows[index].Cells[index].Value != null)
               {
                   dtp_date.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
                   //cb1_shift1.SelectedIndex = cb1_shift1.Items.IndexOf(dataGridView1.Rows[index].Cells[1].Value.ToString());
                   //cb1_shift1.SelectedItem = "1";
                   cb1_shift1.SelectedValue = "D";
                   //cb1_shift1.SelectedIndex = cb1_shift1.Items.IndexOf(dataGridView1.Rows[index].Cells[1].Value.ToString());
                  // cb1_shift1.SelectedItem = ComboBox.
                   string str1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
                   if (str1 == "D")
                   {
                       cb1_shift1.SelectedIndex = 1;
                   }
                   if (str1 == "N")
                   {
                       cb1_shift1.SelectedIndex = 2;
                   }
                   if (str1 == "%")
                   {
                       cb1_shift1.SelectedIndex = 0;
                   }
                   cb1_process.SelectedValue = dataGridView1.Rows[index].Cells[14].Value.ToString();
                   cb1_macno.SelectedValue = dataGridView1.Rows[index].Cells[9].Value.ToString();
                   cb1_workname.SelectedValue = dataGridView1.Rows[index].Cells[17].Value.ToString();
                   cb1_next_process.SelectedValue = dataGridView1.Rows[index].Cells[15].Value.ToString();
                   cb1_next_work.SelectedValue = dataGridView1.Rows[index].Cells[16].Value.ToString();
                   if (dataGridView1.Rows[index].Cells[24].Value.ToString() == "Y")
                   {
                       r1_y.Checked = true;
                       r1_n.Checked = false;
                   }
                   else
                   {
                       r1_y.Checked = false;
                       r1_n.Checked = true;
                   }
                   tx1_pno.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                   tx1_lot.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                   tx1_quantity.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                   tx1_page_imposition.Text = dataGridView1.Rows[index].Cells[10].Value.ToString();
                   tx1_palletno.Text = dataGridView1.Rows[index].Cells[12].Value.ToString();
                   tx1_worker.Text = dataGridView1.Rows[index].Cells[18].Value.ToString();
                   tx1_insert_emp.Text = dataGridView1.Rows[index].Cells[21].Value.ToString();
                   tx1_update_emp.Text = dataGridView1.Rows[index].Cells[23].Value.ToString();
                   tx1_remark.Text = dataGridView1.Rows[index].Cells[19].Value.ToString();
                   if(dataGridView1.Rows[index].Cells[8].Value.ToString()=="S")
                   {
                       r1_sheet.Checked= true;
                       r1_ea.Checked = false;
                   }
                   else
                   {
                       r1_sheet.Checked= false;
                       r1_ea.Checked = true;
                   }
                   if (dataGridView1.Rows[index].Cells[11].Value.ToString() == "PLT")
                   {
                       r1_plt.Checked = true;
                       r1_box.Checked = false;
                       r1_etc.Checked = false;
                   }
                   else if (dataGridView1.Rows[index].Cells[11].Value.ToString() == "BOX")
                   {
                       r1_plt.Checked = false;
                       r1_box.Checked = true;
                       r1_etc.Checked = false;
                   }
                   else
                   {
                       r1_plt.Checked = false;
                       r1_box.Checked = false;
                       r1_etc.Checked = true;
                   }
                   if (dataGridView1.Rows[index].Cells[13].Value.ToString() == "E")
                   {
                       r1_end.Checked = true;
                       r1_continue.Checked = false;
                   }
                   else if (dataGridView1.Rows[index].Cells[13].Value.ToString() == "C")
                   {
                       r1_end.Checked = false;
                       r1_continue.Checked = true;
                   }
               }
           }
        }

        private void bt1_clear1_Click(object sender, EventArgs e)
        {
            tx1_pno.Text = "";
        }

        private void bt1_clear2_Click(object sender, EventArgs e)
        {
            tx1_lot.Text = "";
        }

        private void bt_new_Click(object sender, EventArgs e)
        {
            dtp_date.Enabled = true;
            tx1_lot.Enabled = true;
            tx1_pno.Enabled = true;
            dtp_date.Value = DateTime.Today;
            cb1_shift1.SelectedIndex = 0;
            cb1_process.SelectedIndex = 0;
            cb1_workname.SelectedIndex = 0;
            cb1_macno.SelectedIndex = 0;
            r1_y.Checked = false;
            r1_n.Checked = false;
            tx1_pno.Text = "";
            tx1_lot.Text = "";
            tx1_quantity.Text = "";
            tx1_palletno.Text = "";
            tx1_page_imposition.Text = "";
            r1_sheet.Checked = false;
            r1_ea.Checked = false;
            r1_plt.Checked = false;
            r1_box.Checked = false;
            r1_etc.Checked = false;
            r1_continue.Checked = false;
            r1_end.Checked = false;
            cb1_next_process.SelectedIndex = 0;
            //cb1_next_work.SelectedIndex = 0;
            tx1_worker.Text = "";
            tx1_insert_emp.Text = "";
            tx1_update_emp.Text = "";
            tx1_remark.Text = "";
            flag = true;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (valInputForm() == true)
            {
                string sql;
                int index = dataGridView1.CurrentRow.Index;
                string _workcode,next_work;
                if (cb1_workname.SelectedIndex >= 0)
                {
                    _workcode = cb1_workname.SelectedValue.ToString().Trim();
                }
                else
                {
                    _workcode = " ";
                }
                if (cb1_next_work.SelectedIndex >=0)
                {
                    next_work = cb1_next_work.SelectedValue.ToString().Trim();
                }
                else
                {
                    next_work = " ";
                }
                if (flag == true)
                {
                    int number=0;
                    string sqlnum = "SELECT  prdno FROM tmwidt where wodt ='" + dtp_date.Value.ToString("yyyyMMdd") + "' and macno = '" + cb1_macno.SelectedValue.ToString() + "'";
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

                    string numbers = number.ToString("000");
                    string macno = cb1_macno.SelectedValue.ToString();
                    string mixyn, unit, packtype, pltsts;
                    mixyn = (r1_y.Checked == true) ? "Y" : "N";
                    unit = (r1_sheet.Checked == true) ? "S" : "E";
                    pltsts = (r1_continue.Checked == true) ? "C" : "E";
                    if (r1_box.Checked == true)
                    {
                        packtype = "BOX";
                    }
                    else if (r1_plt.Checked == true)
                    {
                        packtype = "PLT";
                    }
                    else
                    {
                        packtype = "ETC";
                    }
                    sql = " INSERT INTO tmwidt VALUES (" +
                       "'02'," +
                       "'500'," +
                       "'" + macno.Trim() + "-" + dtp_date.Value.ToString("yyMMdd") + "-" + numbers + "'," +
                       "'" + macno.Trim() + "'," +
                       "'" + cb1_macno.Text + "'," +
                       "'" + dtp_date.Value.ToString("yyyyMMdd") + "'," +
                       "'" + cb1_process.SelectedValue + "'," +
                       "'" + _workcode + "'," +
                       "'" + tx1_pno.Text + "'," +
                       "'" + tx1_lot.Text + "'," +
                       "'" + mixyn + "'," +
                       "" + Int32.Parse(tx1_quantity.Text) + "," +
                       "'" + unit + "'," +
                       "" + Int32.Parse(tx1_page_imposition.Text) + "," +
                       "" + 0 + "," +
                       "'" + packtype + "'," +
                       "" + Int32.Parse(tx1_palletno.Text) + "," +
                       "'" + pltsts + "'," +
                       "'" + tx1_worker.Text + "'," +
                       "'" + cb1_next_process.SelectedValue + "'," +
                       "'" + next_work + "'," +
                       "'" + dtp_date.Value + "'," +
                       "'" + cb1_shift1.SelectedValue + "'," +
                       "'" + tx1_remark.Text + "'," +
                       "'" + dtp_date.Value + "'," +
                       "'" + dtp_date.Value + "'," +
                       "'" + tx1_insert_emp.Text + "'," +
                       "'" + tx1_update_emp.Text + "')";
                    conn.ExecuteNonQuery(sql);
                    string sql1 = "SELECT a.wodt,a.prdshift,a.prddt,a.idno,b.macname_eng,a.prdno,a.lotno,a.prdqty,a.unit,a.macno,a.fmtcnt,a.packtype,a.pltqty,a.pltsts,a.process,a.nextprocess,a.nextworkcode,a.workcode,a.worker,a.remark,a.insdt,a.insemp,a.upddt,a.updemp,a.mixyn FROM tmwidt a,tmstprocmac b WHERE a.macno=b.macno";
                    DataTable dt1 = conn.GetDataTable(sql1);


                    dataGridView1.DataSource = dt1;
                }
                else
                {
                    
                    string macno = cb1_macno.SelectedValue.ToString();
                    string mixyn, unit, packtype, pltsts;
                    mixyn = (r1_y.Checked == true) ? "Y" : "N";
                    unit = (r1_sheet.Checked == true) ? "S" : "E";
                    pltsts = (r1_continue.Checked == true) ? "C" : "E";
                    if (r1_box.Checked == true)
                    {
                        packtype = "BOX";
                    }
                    else if (r1_plt.Checked == true)
                    {
                        packtype = "PLT";
                    }
                    else
                    {
                        packtype = "ETC";
                    }
                    sql = "UPDATE tmwidt" +
                       " Set " +
                       "wodt='" + dtp_date.Value.ToString("yyyyMMdd") + "'," +
                       "process='" + cb1_process.SelectedValue + "'," +
                       "workcode='" + _workcode + "'," +
                       "mixyn='" + mixyn + "'," +
                       "prdqty=" + Int32.Parse(tx1_quantity.Text) + "," +
                       "unit='" + unit + "'," +
                       "fmtcnt=" + Int32.Parse(tx1_page_imposition.Text) + "," +
                       "packtype='" + packtype + "'," +
                       "pltqty=" + Int32.Parse(tx1_palletno.Text) + "," +
                       "pltsts='" + pltsts + "'," +
                       "worker='" + tx1_worker.Text + "'," +
                       "nextprocess='" + cb1_next_process.SelectedValue + "'," +
                       "nextworkcode='" + next_work + "'," +
                       "prddt='" + dtp_date.Value + "'," +
                       "prdshift='" + cb1_shift1.SelectedValue + "'," +
                       "remark='" + tx1_remark.Text + "'," +
                       "insemp='" + tx1_insert_emp.Text + "'," +
                       "updemp='" + tx1_update_emp.Text + "' where idno=" +
                       "'" + dataGridView1.Rows[index].Cells[3].Value.ToString() + "'";
                    conn.ExecuteNonQuery(sql);
                   // this.tmstprocessTableAdapter.Fill(this.db_codecheckedDataSet.tmstprocess);
                    string sql1 = "SELECT a.wodt,a.prdshift,a.prddt,a.idno,b.macname_eng,a.prdno,a.lotno,a.prdqty,a.unit,a.macno,a.fmtcnt,a.packtype,a.pltqty,a.pltsts,a.process,a.nextprocess,a.nextworkcode,a.workcode,a.worker,a.remark,a.insdt,a.insemp,a.upddt,a.updemp,a.mixyn FROM tmwidt a,tmstprocmac b WHERE a.macno=b.macno";

                    //conn.Connect();
                    DataTable dt1 = conn.GetDataTable(sql1);


                    dataGridView1.DataSource = dt1;
                   // conn.Disconnect();

                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Enter data imput form please !");
            }
            
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            string sql = "DELETE FROM tmwidt WHERE idno='" + dataGridView1.Rows[index].Cells[3].Value.ToString() + "'";
            conn.ExecuteNonQuery(sql);
            MessageBox.Show("Delete success !");
            string sql1 = "SELECT a.wodt,a.prdshift,a.prddt,a.idno,b.macname_eng,a.prdno,a.lotno,a.prdqty,a.unit,a.macno,a.fmtcnt,a.packtype,a.pltqty,a.pltsts,a.process,a.nextprocess,a.nextworkcode,a.workcode,a.worker,a.remark,a.insdt,a.insemp,a.upddt,a.updemp,a.mixyn FROM tmwidt a,tmstprocmac b WHERE a.macno=b.macno";
            DataTable dt1 = conn.GetDataTable(sql1);
            dataGridView1.DataSource = dt1;
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            int timecopare= DateTime.Compare(dateTimePicker1.Value,dateTimePicker2.Value);
            if (timecopare > 0)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
            }

            string sql = "SELECT a.wodt,a.prdshift,a.prddt,a.idno,b.macname_eng,a.prdno,a.lotno,a.prdqty,a.unit,a.macno,a.fmtcnt,a.packtype,a.pltqty,a.pltsts,a.process,a.nextprocess,a.nextworkcode,a.workcode,a.worker,a.remark,a.insdt,a.insemp,a.upddt,a.updemp,a.mixyn FROM tmwidt a,tmstprocmac b WHERE a.macno=b.macno and "
                + "a.process like '"+cb_process.SelectedValue+"'  and "+
                "a.macno like'"+cb_macno.SelectedValue+"' and "+
                "a.prdshift like '"+cb_shift.SelectedValue+"' and "+
                "a.wodt between '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "' and '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "' and "+
                "a.prdno like '"+tx_pno.Text+"%'";
            //conn.Connect();
            DataTable dt1 = conn.GetDataTable(sql);


            dataGridView1.DataSource = dt1;
           // MessageBox.Show(sql);
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            reportForm frm = new reportForm();
            frm.stage = cb1_process.Text;
            frm.equiment = cb1_workname.Text;
            frm.pno = tx1_pno.Text;
            frm.pnocode = tx1_pno.Text;
            frm.lot = tx1_lot.Text;
            frm.lotcode = tx1_lot.Text;
            frm.quantity = tx1_quantity.Text;
            if (r1_sheet.Checked == true)
            {
                frm.sheet = "X";
                frm.ea = " ";
            }
            else
            {
                frm.sheet = " ";
                frm.ea = "X";
            }
            frm.worker = tx1_worker.Text;
            frm.next_process = cb1_next_work.Text;
            frm.wodt = dtp_date.Value.ToShortDateString();
            if (cb_shift.Text == "D")
            {
                frm.sd = "X";
                frm.sn = " ";
            }
            else
            {
                frm.sd = " ";
                frm.sn = "X";
            }
            if (tx1_remark.Text == "")
            {
                frm.remark = " ";
            }
            else
            {
                frm.remark = tx1_remark.Text;
            }
            
            frm.printday = DateTime.Today.ToString("yyyy-MM-dd");
            frm.Show();
            //MessageBox.Show(cb1_process.Text);
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            ExportToExcel(); 
        }
        private void ExportToExcel()
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           // xlWorkSheet.Cells[1, 5] = "Report Data";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
            xlWorkBook.SaveAs("d:\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int timecopare = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
            if (timecopare > 0)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
                MessageBox.Show("The time To must be greater than the time From !");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int timecopare = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
            if (timecopare > 0)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
                MessageBox.Show("The time To must be greater than the time From !");
            }
        }
        private bool valInputForm()
        {
            bool check = true;
            if (cb1_shift1.Text == "ALL")
            {
                check = false;
            }
            
            if (cb1_process.Text == "ALL")
            {
                check = false;
            }
            
            if (cb1_macno.Text == "ALL")
            {
                check = false;
            }
            
            if (r1_y.Checked == false && r1_n.Checked == false)
            {
                check = false;
            }
           
            if (tx1_pno.Text == "")
            {
                check = false;
            }
           
            if (tx1_lot.Text == "")
            {
                check = false;
            }
            
            if (tx1_quantity.Text == "")
            {
                check = false;
            }
            
            if (tx1_page_imposition.Text == "")
            {
                check = false;
            }
            
            if (tx1_palletno.Text == "")
            {
                check = false;
            }
            
            if (tx1_worker.Text == "")
            {
                check = false;
            }
            
            if (tx1_insert_emp.Text == "")
            {
                check = false;
            }
            
            if (r1_sheet.Checked == false && r1_ea.Checked == false)
            {
                check = false;
            }
            if (tx1_worker.Text == "")
            {
                MessageBox.Show("Please enter name of worker !");
                check = false;
            }
            
            //if (cb1_workname.SelectedIndex <=0)
            //{
            //    check = false;
            //}
           

            if (r1_continue.Checked == false && r1_end.Checked == false)
            {
                check = false;
            }
           
            if (r1_plt.Checked == false && r1_box.Checked == false&& r1_etc.Checked==false)
            {
                check = false;
            }
            
            if (cb1_next_process.Text == "ALL")
            {
                check = false;
            }
          
            if (cb1_next_work.Text == "ALL")
            {
                check = false;
            }
           
            return check;
        }

        private void cb1_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1_process.SelectedIndex == 0)
            {
                cb1_process.SelectedIndex = 1;                
            }
            string sql = "select workcode,workcodename_eng from tmstprocwork where processcode like'"+cb1_process.SelectedValue+"'";
            getdt_cb_edit(sql, "workcodename_eng", "workcode", cb1_workname);
        }

        private void cb1_shift1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1_shift1.SelectedIndex == 0)
            {
                cb1_shift1.SelectedIndex = 1;
            }
        }

        private void cb1_next_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1_process.SelectedIndex == 0)
            {
                cb1_process.SelectedIndex = 1;
            }
            string sql = "select workcode,workcodename_eng from tmstprocwork where processcode like'" + cb1_next_process.SelectedValue + "'";
            getdt_cb_edit(sql, "workcodename_eng", "workcode", cb1_next_work);
        }

        private void tx1_lot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string checkcode=(tx1_lot.Text).Substring(0, 1);
                if (checkcode == "T" || checkcode == "t")
                {
                    tx1_quantity.Focus();
                }                
                else
                {
                    MessageBox.Show("The first character code must be 'T' or 't'");
                   tx1_lot.Text="";
                }
                    
            }
        }

        private void tx1_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && char.IsControl(e.KeyChar)==false )
            {
                e.Handled = true;
                MessageBox.Show("Only enter digital please ! ");
                tx1_quantity.Text ="";
                //tx1_quantity.Focus();
                
            }
           
        }

        private void tx1_quantity_TextChanged(object sender, EventArgs e)
        {
            int count = tx1_quantity.Text.Length;
            if (count >10)
            {
                MessageBox.Show("the number you entered was too big. Enter again please !");
                tx1_quantity.Text = "";
            }
        }

        private void tx1_palletno_TextChanged(object sender, EventArgs e)
        {
            int count = tx1_palletno.Text.Length;
            if (count > 10)
            {
                MessageBox.Show("the number you entered was too big. Enter again please !");
                tx1_palletno.Text = "";
            }
        }

        private void tx1_palletno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Only enter digital please ! ");
                tx1_palletno.Text = "";             

            }
        }

        private void tx1_page_imposition_TextChanged(object sender, EventArgs e)
        {
            int count = tx1_page_imposition.Text.Length;
            if (count > 10)
            {
                MessageBox.Show("the number you entered was too big. Enter again please !");
                tx1_page_imposition.Text = "";
            }
        }

        private void tx1_page_imposition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Only enter digital please ! ");
                tx1_page_imposition.Text = "";

            }
        }

        private void engLishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql, sql1,temp1,temp2;
            //DataTable dt = conn.GetDataTable(sql);
            //int counttable = dt.Rows.Count;
            //Control name = new Control();
            //for (int i = 0; i < counttable; i++)
            //{
            //    name.Name = dt.Rows[i]["cname"].ToString();
            //    name.Text = dt.Rows[i]["vietnam"].ToString();
            //}

            foreach (Control c in this.Controls)
            {
                sql = "select * from language where cname='" + c.Name + "'";
                DataTable dt = conn.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    temp1 = dt.Rows[0]["cname"].ToString();
                    temp2 = c.Name.ToString();
                    //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                    if (temp1.Trim() == temp2.Trim())
                    {
                        c.Text = dt.Rows[0]["english"].ToString();
                        //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                    }
                    //c.Name.ToString();

                }


                foreach (Control child_c in c.Controls)
                {
                    sql1 = "select * from language where cname='" + child_c.Name + "'";
                    DataTable dt1 = conn.GetDataTable(sql1);
                    if (dt1.Rows.Count > 0)
                    {
                        temp1 = dt1.Rows[0]["cname"].ToString();
                        temp2=child_c.Name.ToString();
                        //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                        if (temp1.Trim() == temp2.Trim())
                        {
                           child_c.Text = dt1.Rows[0]["english"].ToString();
                            //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                        }
                        //child_c.Name.ToString();

                    }

                    //child_c.Text = dt1.Rows[0]["vietnam"].ToString();
                }
            }
        }

        private void vietnameseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql, sql1, temp1, temp2;
            //DataTable dt = conn.GetDataTable(sql);
            //int counttable = dt.Rows.Count;
            //Control name = new Control();
            //for (int i = 0; i < counttable; i++)
            //{
            //    name.Name = dt.Rows[i]["cname"].ToString();
            //    name.Text = dt.Rows[i]["vietnam"].ToString();
            //}

            foreach (Control c in this.Controls)
            {
                sql = "select * from language where cname='" + c.Name + "'";
                DataTable dt = conn.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    temp1 = dt.Rows[0]["cname"].ToString();
                    temp2 = c.Name.ToString();
                    //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                    if (temp1.Trim() == temp2.Trim())
                    {
                        c.Text = dt.Rows[0]["vietnam"].ToString();
                        //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                    }
                    //c.Name.ToString();

                }


                foreach (Control child_c in c.Controls)
                {
                    sql1 = "select * from language where cname='" + child_c.Name + "'";
                    DataTable dt1 = conn.GetDataTable(sql1);
                    if (dt1.Rows.Count > 0)
                    {
                        temp1 = dt1.Rows[0]["cname"].ToString();
                        temp2 = child_c.Name.ToString();
                        //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                        if (temp1.Trim() == temp2.Trim())
                        {
                            child_c.Text = dt1.Rows[0]["vietnam"].ToString();
                            //MessageBox.Show("control name =" + dt1.Rows[0]["vietnam"].ToString());
                        }
                        //child_c.Name.ToString();

                    }

                    //child_c.Text = dt1.Rows[0]["vietnam"].ToString();
                }
            }
        }
               
    }
}
