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
    public partial class frm_LineConfig : Form
    {
        public frm_LineConfig()
        {
            InitializeComponent();
        }
        Control frm;
        ToolCS tool = new ToolCS();
        string pathfile = Application.StartupPath + @"\option.ini";
        private void frm_LineConfig_Load(object sender, EventArgs e)
        {
            frm = this;
            lbMessage.Visible = false;
            txtLineCode.Text = tool.Read(pathfile, "LineConfig", "LineCode");
            txtLineName.Text = tool.Read(pathfile, "LineConfig", "LineName");
            GetAllControls(this);
            foreach (Control c in ControlList)
            {
                tool.TranslateControl(this, c, tool.GetLanguage(tool.Read(pathfile, "Infor", "Language")));
            }   
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            tool.Write(pathfile, "LineConfig", "LineCode",txtLineCode.Text);
            tool.Write(pathfile, "LineConfig", "LineName", txtLineName.Text);
            lbMessage.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
    }
}
