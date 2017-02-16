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
    public partial class frm_MessageWarning : Form
    {
        public frm_MessageWarning()
        {
            InitializeComponent();
        }
        public int index = 0;
        Point point = new Point(61, 29);
        ToolCS tool = new ToolCS();
        string pathfile = Application.StartupPath + @"\option.ini";
        Control frm;

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_MessageWarning_Load(object sender, EventArgs e)
        {
            frm = this;
            switch (index)
            { 
                case 0:
                    DisableMessage();
                    lbmassage1.Visible = true;
                    lbmassage1.Location = point;
                    break;
                case 1:
                    DisableMessage();
                    lbmassage2.Visible = true;
                    lbmassage2.Location = point;
                    break;
                case 2:
                    DisableMessage();
                    lbmassage3.Visible = true;
                    lbmassage3.Location = point;
                    break;
                case 3:
                    DisableMessage();
                    lbmassage4.Visible = true;
                    lbmassage4.Location = point;
                    break;
                case 4:
                    DisableMessage();
                    lbmassage5.Visible = true;
                    lbmassage5.Location = point;
                    break;
                case 5:
                    DisableMessage();
                    lbmassage6.Visible = true;
                    lbmassage6.Location = point;
                    break;
                case 6:
                    DisableMessage();
                    lbmassage7.Visible = true;
                    lbmassage7.Location = point;
                    break;
            }
            GetAllControls(this);
            foreach (Control c in ControlList)
            {
                tool.TranslateControl(this, c, tool.GetLanguage(tool.Read(pathfile, "Infor", "Language")));
            }           
        }
        public void DisableMessage()
        {
            lbmassage1.Visible = false;
            lbmassage2.Visible = false;
            lbmassage3.Visible = false;
            lbmassage4.Visible = false;
            lbmassage5.Visible = false;
            lbmassage6.Visible = false;
            lbmassage7.Visible = false;
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
