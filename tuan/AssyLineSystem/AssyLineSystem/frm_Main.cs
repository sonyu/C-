using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using ObjectTool;

namespace AssyLineSystem
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        public string user__;
        ConnectSQL conn;        
        ToolCS tool = new ToolCS();
        string pathfile = Application.StartupPath + @"\option.ini";
        Control frm;
        string fromdate, todate;
        private void frm_Main_Load(object sender, EventArgs e)
        {
            
            string servername_ = tool.Read(pathfile, "DataBase", "Server");
            string database_ = tool.Read(pathfile, "DataBase", "DataBase");
            string user_ = tool.Read(pathfile, "DataBase", "User");
            conn = new ConnectSQL(servername_, database_, user_);            
            frm = this;
            fromdate=dtpFrom.Value.ToString("yyyyMMdd");
            todate=dtpTo.Value.ToString("yyyyMMdd");
            cboShift.SelectedIndex = 0;
            LoadData(); 
            //GetLotNumber(fromdate, todate);
            txtLine.Text = tool.Read(pathfile, "LineConfig", "LineName").ToUpper();
            GetAllControls(this);
            foreach (Control c in ControlList)
            {               
                tool.TranslateControl(this, c, tool.GetLanguage(tool.Read(pathfile,"Infor","Language")));
            }
            lbUser.Text = user__;
            txtCheck.Focus();
        }

        
        List<Control> ControlList = new List<Control>();       
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {                
                if ( c is MenuStrip||c is Button || c is Label ||c is LinkLabel ||c is DataGridView) ControlList.Add(c);
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
                            foreach(ToolStripMenuItem tmp1 in tmp.Items)
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

        private void btnInputData_Click(object sender, EventArgs e)
        {
            if (cboShift.Text == "" || cboShift.Text == "-ALL-")
            {
                frm_MessageWarning warning = new frm_MessageWarning();
                warning.index = 0;
                warning.ShowDialog();
            }
            else
            {
                frm_InputData frm1 = new frm_InputData();
                frm1.shift = cboShift.Text;                
                frm1.line = txtLine.Text;
                frm.Hide();
                frm1.ShowDialog();
            }
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void btnLineConfig_Click(object sender, EventArgs e)
        {
            frm_LineConfig lineconfig = new frm_LineConfig();
            lineconfig.ShowDialog();
            txtLine.Text = tool.Read(pathfile, "LineConfig", "LineName").ToUpper();
        }
        //DataTable datagood,datang;
        public void LoadData()
        {            
            frm_Loading loading = new frm_Loading();
            loading.ShowDialog();
            string sql = "SELECT Wodate,shift,keycode,modelcode,goodqty,defqty,mixqty,total,starttime,endtime,linename,empname FROM tb_datachecked where wodate between '" + fromdate + "' and '" + todate + "' and shift like '%" + GetShift() + "%' and modelcode like '%" + txtCheck.Text.Trim().ToUpper() + "%' order by wodate desc,starttime desc";
            DataTable dt = conn.GetDataTable(sql);
            dgvData.DataSource = dt;
        }
        public void LoadDataNG()
        {
            frm_Loading loading = new frm_Loading();
            loading.ShowDialog();
            string sql = "SELECT id,Wodate,shift,keycode,modelcode,modelcheck,checktime,linename,empname FROM tb_datamix where wodate between '" + fromdate + "' and '" + todate + "' and shift like '%" + GetShift() + "%' and modelcode like '%" + txtCheck.Text.Trim().ToUpper() + "%'";
            DataTable dt = conn.GetDataTable(sql);
            dgvNG.DataSource = dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                LoadData();
            else LoadDataNG();

        }
       
        public string GetShift()
        {
            if (cboShift.SelectedIndex == 0)
                return "";
            else return cboShift.SelectedItem.ToString();
        }
        
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > DateTime.Now)
            {
                dtpFrom.Value = DateTime.Now;
            }
            fromdate = dtpFrom.Value.ToString("yyyyMMdd");
            //GetLotNumber(fromdate, todate);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value > DateTime.Now)
            {
                dtpTo.Value = DateTime.Now;
            }
            todate = dtpTo.Value.ToString("yyyyMMdd");
            //GetLotNumber(fromdate, todate);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();            
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();

            
                //string sql = "select wodate as [Work Date],shift as Shift,keycode as [Key Code],modelcode as [Model Code],modelcheck as [Model Check],status as Status,checktime as [Check Time],lotgroup as Lot,linename as [Line Name],empname as Employee from tb_datachecked(nolock) where modelcode like '%" + txtCheck.Text + "%' and lotgroup like '%" + GetLot() + "%' and wodate between '" + fromdate + "' and '" + todate + "' and shift like '%" + GetShift() + "%'";
                //string sql = "Execute sp_LoadDataList '" + dtpFrom.Value.ToString("yyyyMMdd") + "','" + dtpTo.Value.ToString("yyyyMMdd") + "', '" + txtCheck.Text + "','" + cboLot.Text + "','%" + cboShift.Text + "%'";

                //data = conn.GetDataTable(sql);
                //if (saveFileDialog.FileName != "" &&data.Rows.Count>0)
                //{
                //    ExportTableToExcel.exportToExcel(data, saveFileDialog.FileName, "DATA CHECK BARCODE");
                //    MessageBox.Show("Export complete !");
                //}


            if (saveFileDialog.FileName != "")
            {
                string sql = "SELECT Wodate as [Work Date],shift as Shift,keycode as [Working Code],modelcode as [Model Code],goodqty as Good,defqty as Defect,mixqty as Mix,total as Total,starttime as [Start Time],endtime as [End Time],linename as [Line Name],empname as Employee FROM tb_datachecked where wodate between '" + fromdate + "' and '" + todate + "' and shift like '%" + GetShift() + "%' and modelcode like '%" + txtCheck.Text.Trim().ToUpper() + "%'";
                DataTable dt = conn.GetDataTable(sql);

                string sql1 = "SELECT id as No,Wodate as [Work Date],shift as Shift,keycode as [Working Code],modelcode as [Model Code],modelcheck as [Mixed Code],checktime as [Check Time],linename as [Line Name],empname as Employee FROM tb_datamix where wodate between '" + fromdate + "' and '" + todate + "' and shift like '%" + GetShift() + "%' and modelcode like '%" + txtCheck.Text.Trim().ToUpper() + "%'";
                DataTable dt1 = conn.GetDataTable(sql1);

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Sum Data");
                    wb.Worksheets.Add(dt1, "Mix Data");
                    wb.SaveAs(saveFileDialog.FileName);
                }

                //ExportTableToExcel.exportToExcel(dt, saveFileDialog.FileName, "DATA CHECK BARCODE NG");
                MessageBox.Show("Export complete !");
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                LoadData();
            else LoadDataNG();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                frm_EditDeff frmdef = new frm_EditDeff();
                frmdef.keycode = dgvData.CurrentRow.Cells["colkeycode"].Value.ToString();
                frmdef.ShowDialog();
                LoadData();
            }
            else
            {
                frm_MessageWarning warning = new frm_MessageWarning();
                warning.index = 5;
                warning.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Cal cal_ = new frm_Cal();
            cal_.ShowDialog();

        }














        //public void LoadMenu()
        //{
        //    try
        //    {               
        //        string sql = "SELECT * FROM pf_pgm_mst where parent_pgm='00000' and pgm_kind_code='M' and menu_use_yn='Y' order by sort_order";
        //        DataTable dt = conn.GetDataTable(sql);
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string name = dt.Rows[i]["pgm_name_loc"].ToString();
        //            string picture = dt.Rows[i]["picture"].ToString();
        //            ToolStripMenuItem tmn = new ToolStripMenuItem(name+ "/");
        //            tmn.Click += new EventHandler(toolStripClick);
        //            tmn.Tag = dt.Rows[i]["pgm_no"].ToString();
        //            tmn.ForeColor = Color.White;
        //            menuStripMain.Items.Add(tmn);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
                
        //    }
            
        //}        
        //string index_ = "";
        //void toolStripClick(object sender, EventArgs e)
        //{
        //    ToolStripItem item = (ToolStripItem)sender;
        //    if (item.Tag.ToString() != index_)
        //    {
        //        treeViewMenuLeft.Nodes.Clear();
        //        TreeNode node = new TreeNode();
        //        LoadMenuLeft(node, item.Text.Remove(item.Text.Length - 1, 1), item.Tag.ToString());
        //        treeViewMenuLeft.ExpandAll();
        //        index_ = item.Tag.ToString();
        //    }
        //}
        //public void LoadMenuLeft(TreeNode node_, string menuname, string menuid)
        //{
        //    node_ = new TreeNode(menuname);
        //    node_.ImageIndex = 1;
        //    string sql = "select * from pf_pgm_mst where parent_pgm='" + menuid + "' and menu_use_yn='Y' order by sort_order";
        //    DataTable dt = conn.GetDataTable(sql);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string name = dt.Rows[i]["pgm_name_loc"].ToString();
        //        string id = dt.Rows[i]["pgm_no"].ToString();
        //        string type = dt.Rows[i]["pgm_kind_code"].ToString();
        //        TreeNode chilnode = new TreeNode(name);
        //        node_.Nodes.Add(chilnode);
        //        if (type == "M")
        //        {
        //            chilnode.ImageIndex = 1;
        //            LoadMenuLeft(chilnode, name, id);
        //        }
        //        else chilnode.ImageIndex = 2;
        //    }
        //}
    }
}
