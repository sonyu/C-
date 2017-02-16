using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectTool;
using System.Media;

namespace AssyLineSystem
{
    public partial class frm_InputData : Form
    {
        public string shift, line;
        Control frm;
        ToolCS tool = new ToolCS();
        ConnectSQL conn;
        string pathfile = Application.StartupPath + @"\option.ini";
        int ok = 0, mix = 0, def = 0, total = 0;
        SoundPlayer pal = new SoundPlayer("Err.wav");
        string keychar = "ABCDEFGHIKLMNOPQRSTVXYZ";
        int countkeychar = -1;
        string keycode_ = "";
        string linecode,linename,endtime; 
        public frm_InputData()
        {
            InitializeComponent();
        }

        //public void LoadData()
        //{
        //    string sql = "select wodate,shift,modelcode,count(case when status ='G' then 1 end)as OK,count(case when status ='N' then 1 end)as NG,count(status) as Total,empname from tb_datachecked where wodate = '"+DateTime.Now.ToString("yyyyMMdd")+"' group by wodate,shift,modelcode,empname";
        //    DataTable dt = conn.GetDataTable(sql);
        //    dgvData.DataSource = dt;
        //}

        private void frm_InputData_Load(object sender, EventArgs e)
        {
            string servername_ = tool.Read(pathfile, "DataBase", "Server");
            string database_ = tool.Read(pathfile, "DataBase", "DataBase");
            string user_ = tool.Read(pathfile, "DataBase", "User");
            conn = new ConnectSQL(servername_, database_, user_);
            txtWorkDate.Text = DateTime.Now.ToString("yyyy.MM.dd");
            txtLine.Text = line;
            txtShift.Text = shift;
            linecode = tool.Read(pathfile, "LineConfig", "LineCode");
            linename = tool.Read(pathfile, "LineConfig", "LineName");

            frm = this;
            Status(false);
            btnSave.Visible = false;
            cboDef.Visible = false;
            //txtEmployee.Enabled = true;
            //txtProduct.Enabled = true;
            LoadData();
            GetAllControls(this);
            foreach (Control c in ControlList)
            {
                tool.TranslateControl(this, c, tool.GetLanguage(tool.Read(pathfile, "Infor", "Language")));
            }
            lbOK.Location = new Point(5, lbOK.Location.Y);
            lbMix.Location = new Point(5, lbMix.Location.Y);
            lbDeff.Location = new Point(5, lbDeff.Location.Y);
            lbTotal.Location = new Point(5, lbTotal.Location.Y);
            txtEmployee.Focus();
        }

        public void LoadData()
        {
            string sql = "SELECT Wodate,shift,keycode,modelcode,goodqty,defqty,mixqty,total,starttime,endtime,linename,empname FROM tb_datachecked where wodate='" + GetWorkDateTime() + "' and shift='" + txtShift.Text + "' order by starttime desc";
            DataTable dt = conn.GetDataTable(sql);
            dgvData.DataSource = dt;
        }


        public void Status(bool flag)
        {
            pictureBox1.Visible = flag;
            btnStop.Visible = flag;
            lbWorking.Visible = flag;
            lbStartTime.Visible = flag;
            btnStart.Visible = !flag;
            txtEmployee.Enabled = !flag;
            txtProduct.Enabled = !flag;
            txtCodeCheck.Enabled = flag;
            btnSave.Visible = !flag;
            cboDef.Visible = !flag;
        }       
        List<Control> ControlList = new List<Control>();
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is MenuStrip || c is Button || c is Label || c is LinkLabel || c is DataGridView||c is CheckBox) ControlList.Add(c);
                else
                    if (c is TabPage)
                    {
                        ControlList.Add(c);
                        GetAllControls(c);
                    }
                    else
                        GetAllControls(c);
            }
        }

        private void btnSetLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                if (tool.CheckLanguage(frm))
                    tool.ResetLanguage(frm);
                foreach (Control c in ControlList)
                {
                    if (c is DataGridView)
                    {
                        DataGridView tmp = (DataGridView)c;
                        for (int i = 0; i < tmp.Columns.Count; i++)
                        {
                            string headername = tmp.Columns[i].Name;
                            string headertext = tmp.Columns[i].HeaderText;
                            string headertype = tmp.Columns[i].GetType().Name;
                            tool.InsertData(frm.Name, headername, headertype, headertext, headertext, headertext, headertext);
                        }
                    }
                    else
                        if (c is MenuStrip)
                        {
                            MenuStrip tmp = (MenuStrip)c;
                            foreach (ToolStripMenuItem tmp1 in tmp.Items)
                            {
                                tool.InsertData(frm.Name, tmp1.Name, tmp1.GetType().Name, tmp1.Text, tmp1.Text, tmp1.Text, tmp1.Text);
                            }
                        }
                        else
                            tool.InsertData(frm.Name, c.Name, c.GetType().Name, c.Text, c.Text, c.Text, c.Text);
                }
                MessageBox.Show("Insert Control OK, Please check and rewrite name Control");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        private void frm_InputData_FormClosed(object sender, FormClosedEventArgs e)
        {
           
                this.Hide();
                frm_Main frm_main = new frm_Main();
                frm_main.ShowDialog();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtEmployee.Text == "")
            {
                frm_MessageWarning warning = new frm_MessageWarning();
                warning.index = 1;
                warning.ShowDialog();
            }
            else
            {
                if (txtProduct.Text == "")
                {
                    frm_MessageWarning warning = new frm_MessageWarning();
                    warning.index = 2;
                    warning.ShowDialog();
                }
                else
                {
                    Status(true);                   
                    //txtLot.Text = (int.Parse(GetLot()) + 1).ToString();
                    txtDeff.Text = def.ToString();
                    txtOK.Text = ok.ToString();
                    txtTotal.Text = total.ToString();
                    txtMix.Text = mix.ToString();
                    keycode_ = GetKey();
                    lbStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtCodeCheck.Focus();
                }
            }
            
        }
        //public string GetLot()
        //{
        //    string result = "";
        //    string sql = "select top(1) lotgroup from tb_datachecked where wodate='" + DateTime.Now.ToString("yyyyMMdd") + "' order by lotgroup desc ";
        //    DataTable dt = conn.GetDataTable(sql);
        //    if (dt.Rows.Count == 1)
        //    {
        //        result = dt.Rows[0]["lotgroup"].ToString();
        //    }
        //    else
        //        result = "0";
        //    return result;
        //}
        public void WriteData(string key__, string indate__, string wodate__, string linecode__, string linename__, string shift__, string empname__, string modelcode__,string total__,string goodqty__,string mixqty__,string defqty__,string starttime__,string endtime__)
        {
            try
            {
                string sql = "Insert into tb_datachecked (keycode,indate,wodate,linecode,linename,shift,empname,modelcode,total,goodqty,mixqty,defqty,starttime,endtime)"
                             + " values('" + key__ + "','" + indate__ + "','" + wodate__ + "','" + linecode__ + "','" + linename__ + "','" + shift__ + "','" + empname__ + "','" + modelcode__ + "'," + total__ + "," + goodqty__ + "," + mixqty__ + "," + defqty__ + ",'" + starttime__ + "','" + endtime__ + "')";
                conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void WriteDataMix(string key__, string indate__, string wodate__, string linecode__, string linename__, string shift__, string empname__, string modelcode__, string modelcheck__, string checktime__)
        {
            try
            {
                string sql = "Insert into tb_datamix (keycode,indate,wodate,linecode,linename,shift,empname,modelcode,modelcheck,checktime)"
                             + " values('" + key__ + "','" + indate__ + "','" + wodate__ + "','" + linecode__ + "','" + linename__ + "','" + shift__ + "',N'" + empname__ + "','" + modelcode__ + "','" + modelcheck__ + "','" + checktime__ + "')";
                conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
        private void txtCodeCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodeCheck.Text.Trim() != "")
                {
                    if (txtCodeCheck.Text.Trim().ToUpper() == txtProduct.Text.Trim().ToUpper())
                    {
                        ok++;
                        total++;
                        lbCodeTempl.Text = txtCodeCheck.Text;
                        txtOK.Text = ok.ToString();
                        txtTotal.Text = total.ToString();
                        lbMassage.Text = "PASS";
                        lbMassage.Visible = true;
                        lbMassage.ForeColor = Color.Blue;
                        //WriteData(keycode_, DateTime.Now.ToString("yyyyMMdd"), GetWorkDateTime(), tool.Read(pathfile, "LineConfig", "LineCode"), tool.Read(pathfile, "LineConfig", "LineName"), txtShift.Text, txtEmployee.Text, txtProduct.Text, txtCodeCheck.Text, "G", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //keycode_ = GetKey(keycode_);
                        timer1.Enabled = true;
                        timer1.Start();
                        txtCodeCheck.ResetText();
                        txtCodeCheck.Focus();
                    }
                    else
                    {
                        mix++;
                        total++;
                        lbCodeTempl.Text = txtCodeCheck.Text;
                        txtMix.Text = mix.ToString();
                        txtTotal.Text = total.ToString();
                        lbMassage.Text = "NG";
                        lbMassage.Visible = true;
                        lbMassage.ForeColor = Color.Red;
                        WriteDataMix(keycode_, DateTime.Now.ToString("yyyyMMdd"), GetWorkDateTime(), linecode, linename, txtShift.Text, txtEmployee.Text, txtProduct.Text, txtCodeCheck.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //keycode_ = GetKey(keycode_);
                        pal.Play();
                        timer1.Enabled = true;
                        timer1.Start();
                        txtCodeCheck.ResetText();
                        txtCodeCheck.Focus();
                    }
                }
                else
                {
                    txtCodeCheck.ResetText();
                    txtCodeCheck.Focus();
                }
            }
        }
        public string GetWorkDateTime()
        {
            string kq = DateTime.Now.ToString("yyyyMMdd");
            string hourr_ = DateTime.Now.ToString("tt");
            int hour_ = int.Parse(DateTime.Now.ToString("HH"));
            if (hour_ < 8 && hourr_ == "AM")
            {
                DateTime tmp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                kq = tmp.ToString("yyyyMMdd");
            }
            return kq;
        }
        public string GetShortWorkDateTime()
        {
            string kq = DateTime.Now.ToString("yyMMdd");
            string hourr_ = DateTime.Now.ToString("tt");
            int hour_ = int.Parse(DateTime.Now.ToString("HH"));
            if (hour_ < 8 && hourr_ == "AM")
            {
                DateTime tmp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                kq = tmp.ToString("yyMMdd");
            }
            return kq;
        }
        public string GetKey()
        {
            string date_ = GetShortWorkDateTime();
            //string sql = "select max(keydata) from datachecked where wodate='" + date_ + "'order by keydata desc";
            string sql = "select top(1)* from tb_datachecked  order by keycode desc";
            DataTable getdata_ = conn.GetDataTable(sql);

            int count_ = getdata_.Rows.Count;
            if (count_ > 0)
            {
                string s = getdata_.Rows[count_ - 1]["keycode"].ToString();
                string[] s1 = s.Split('-');
                if (s1[0] != date_)
                    return date_ + "-000001";

                else return NextID(s1[1], date_);
            }
            else
            {
                return date_ + "-000001";
            }

        }
        public string GetKey(string oldKey)
        {
            string[] s = oldKey.Split('-');
            string date_ = GetShortWorkDateTime();
            if (s[0] != date_)
                return date_ + "-000001";

            else return NextID(s[1],date_);
        }
        public string NextID(string lastID, string prefixID)
        {
            countkeychar = GetPositionKeyChar(lastID);
            string tmp = "";
            lastID = ChuanHoaKey(lastID);
            int nextID = int.Parse(ChuanHoaKey(lastID)) + 1;
            int numberzero = lastID.Length - nextID.ToString().Length;
            if (numberzero > -1)
            {
                for (int i = 0; i < numberzero; i++)
                {
                    tmp += "0";
                }

            }
            else
            {
                countkeychar++;
                nextID = 1;
                for (int i = 0; i < 4; i++)
                {
                    tmp += "0";
                }
            }

            if (countkeychar == -1)
            {
                return prefixID + "-" + tmp + nextID;
            }
            else
            {
                char keychar_ = keychar[countkeychar];
                //countkeychar++;
                return prefixID + "-" + keychar_ + tmp + nextID;
            }
        }
        public int GetPositionKeyChar(string keychar_)
        {
            int kq = -1;
            if (keychar.Contains(keychar_[0]))
            {
                for (int i = 0; i < keychar.Length; i++)
                {
                    if (keychar_[0] == keychar[i])
                    {
                        kq = i;
                        break;
                    }
                }
            }
            return kq;
        }
        public string ChuanHoaKey(string keychar_)
        {
            string kq = "";
            for (int i = 0; i < keychar_.Length; i++)
            {
                if (keychar_[i] >= '0' && keychar_[i] <= '9')
                {
                    kq += keychar_[i];
                }
            }
            return kq;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //ok = 0; mix = 0; def = 0; total = 0;
            //txtDeff.Text = def.ToString();
            //txtOK.Text = ok.ToString();
            //txtTotal.Text = total.ToString();
            //txtMix.Text = mix.ToString();
            txtCodeCheck.Text = "";
            Status(false);
            endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtProduct.Focus();
            
        }
        int timer_ = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_++;
            if (timer_ == 3)
            {
                timer1.Stop();
                timer1.Enabled = false;                
                timer_ = 1;
                //if(lbMassage.Text=="NG")
                //pal.Stop();
                lbMassage.Text = "";
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0")
            {
                WriteData(keycode_, DateTime.Now.ToString("yyyyMMdd"), GetWorkDateTime(), linecode, linename, txtShift.Text, txtEmployee.Text, txtProduct.Text.Trim().ToUpper(), RemoveChar(txtTotal.Text), RemoveChar(txtOK.Text), RemoveChar(txtMix.Text), RemoveChar(txtDeff.Text), lbStartTime.Text, endtime);
                keycode_ = GetKey(keycode_);
                ok = 0; total = 0; mix = 0; def = 0;
                lbCodeTempl.Text = "";
                txtDeff.Text = def.ToString();
                txtOK.Text = ok.ToString();
                txtTotal.Text = total.ToString();
                txtMix.Text = mix.ToString();
                cboDef.Checked = false;
                txtDeff.ReadOnly = true;
                LoadData();
            }
            else
            {
                frm_MessageWarning frmwraning = new frm_MessageWarning();
                frmwraning.index = 5;
                frmwraning.ShowDialog();
            }

        }

        private void cboDef_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDef.Checked)
            {
                txtDeff.ReadOnly = false;
                txtDeff.Focus();
                txtDeff.Select(txtDeff.TextLength, 0);
            }
            else
            {
                txtDeff.ReadOnly = true;
            }
        }

        private void frm_InputData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtTotal.Text.Trim() != "0")
            {
                frm_MessageWarning frmwraning = new frm_MessageWarning();
                frmwraning.index = 4;
                frmwraning.ShowDialog();
                e.Cancel = true;
            }            
        }

        private void txtDeff_TextChanged(object sender, EventArgs e)
        {
            if (txtDeff.Text == "")
            {
                txtDeff.Text = "0";
            }
            int sum_ = int.Parse(RemoveChar(txtDeff.Text));
            total = sum_ + mix + ok;
            txtTotal.Text = total.ToString();
            if (txtDeff.Text.Length > 3)
            { 
                txtDeff.Text = String.Format("{0:0,0}", Decimal.Parse(txtDeff.Text));
                txtDeff.Select(txtDeff.TextLength, 0);
            }
        }

        //private void txtDeff_Leave(object sender, EventArgs e)
        //{
        //    for(int i=0;i<txtDeff.Text.Length;i++)
        //    {
        //        if (txtDeff.Text[i] < '0' || txtDeff.Text[i] > '9')
        //        {
        //            frm_MessageWarning frmwraning = new frm_MessageWarning();
        //            frmwraning.index = 6;
        //            frmwraning.ShowDialog();
        //            txtDeff.Focus();
        //        }
        //    }
        //}
        public string RemoveChar(string charremove)
        {
            string[] tmpchar = charremove.Split(',');
            string result = "";
            foreach (string s in tmpchar)
                result += s;
            return result;
        }

        private void txtDeff_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;               
            }
            catch
            { }
        }

        private void txtOK_TextChanged(object sender, EventArgs e)
        {
            if (txtOK.Text.Length > 3)
            {
                txtOK.Text = String.Format("{0:0,0}", Decimal.Parse(txtOK.Text));
                //txtOK.Select(txtDeff.TextLength, 0);
            }
        }

        private void txtMix_TextChanged(object sender, EventArgs e)
        {
            if (txtMix.Text.Length > 3)
            {
                txtMix.Text = String.Format("{0:0,0}", Decimal.Parse(txtMix.Text));
                //txtOK.Select(txtDeff.TextLength, 0);
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text.Length > 3)
            {
                txtTotal.Text = String.Format("{0:0,0}", Decimal.Parse(txtTotal.Text));
                //txtOK.Select(txtDeff.TextLength, 0);
            }
        }
        
        
    }
}
