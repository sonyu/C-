using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectTool;
namespace AssyLineSystem
{
    public partial class frm_EditDeff : Form
    {
        public frm_EditDeff()
        {
            InitializeComponent();
        }
        public string keycode;
        ConnectSQL conn = new ConnectSQL();
        ToolCS tool = new ToolCS();
        string pathfile = Application.StartupPath + @"\option.ini";
        Control frm;
        int deftmp = 0,totaltmp=0;
        private void frm_EditDeff_Load(object sender, EventArgs e)
        {
            string servername_ = tool.Read(pathfile, "DataBase", "Server");
            string database_ = tool.Read(pathfile, "DataBase", "DataBase");
            string user_ = tool.Read(pathfile, "DataBase", "User");
            conn = new ConnectSQL(servername_, database_, user_);
            frm = this;
            if (keycode != "")
            {
                string sql = "select Wodate,shift,keycode,modelcode,goodqty,defqty,mixqty,total,starttime,endtime,linename,empname from tb_datachecked where keycode='" + keycode + "'";
                DataTable dt = conn.GetDataTable(sql);
                if (dt.Rows.Count == 1)
                {
                    try
                    {
                    txtdef.Text = dt.Rows[0]["defqty"].ToString();
                    
                    int.TryParse(txtdef.Text, out deftmp);
                   
                    txtempname.Text = dt.Rows[0]["empname"].ToString();
                    txtendtime.Text = dt.Rows[0]["endtime"].ToString();
                    txtgood.Text = dt.Rows[0]["goodqty"].ToString(); 
                    txtkeycode.Text = dt.Rows[0]["keycode"].ToString();
                    txtlinename.Text = dt.Rows[0]["linename"].ToString();
                    txtmix.Text = dt.Rows[0]["mixqty"].ToString();
                    txtmodelcode.Text = dt.Rows[0]["modelcode"].ToString();
                    txtshift.Text = dt.Rows[0]["shift"].ToString();
                    txtstarttime.Text = dt.Rows[0]["starttime"].ToString();
                    txttotal.Text = dt.Rows[0]["total"].ToString();
                    int.TryParse(txttotal.Text, out totaltmp);
                    txtwodate.Text = dt.Rows[0]["wodate"].ToString();
                    }
                    catch
                    {
                        frm_MessageWarning warning = new frm_MessageWarning();
                        warning.index = 6;
                        warning.ShowDialog();
                    }
                }
            }
            GetAllControls(this);
            foreach (Control c in ControlList)
            {
                tool.TranslateControl(this, c, tool.GetLanguage(tool.Read(pathfile, "Infor", "Language")));
            }           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdef.Text != "")
                {
                    string sql = "update tb_datachecked set defqty=" + txtdef.Text.Trim() + ", total="+(totaltmp-deftmp+int.Parse(txtdef.Text.Trim()))+" where keycode='" + keycode + "'";
                    conn.ExecuteNonQuery(sql);
                    txttotal.Text = (totaltmp - deftmp + int.Parse(txtdef.Text.Trim())).ToString();
                    lbmassage.Visible = true;

                }
            }
            catch {
                txtdef.Focus();
            }
        }
        List<Control> ControlList = new List<Control>();
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is MenuStrip || c is Button || c is Label || c is LinkLabel || c is DataGridView) ControlList.Add(c);
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

        private void txtdef_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            catch
            { }
        }
    }
}
