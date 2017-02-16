using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AssyLineSystem;
using ObjectTool;
namespace Login
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();            
        }
        ToolCS tool = new ToolCS();
        ConnectSQL conn;
        private void frm_Login_Load(object sender, EventArgs e)
        {
           string servername_ = tool.Read(pathfile, "DataBase", "Server");
           string database_ = tool.Read(pathfile, "DataBase", "DataBase");
           string user_ = tool.Read(pathfile, "DataBase", "User");
           conn = new ConnectSQL(servername_, database_, user_);
            txtUser.Focus();
            ReadInfo();
            lbwarning1.Visible = false;
            lbwarning2.Visible = false;
            lbwarning3.Visible = false;
        }
        string pathfile = Application.StartupPath + @"\option.ini";
        public void CreateInfo()
        {
            tool.Write(pathfile, "Infor", "User", txtUser.Text);
            tool.Write(pathfile, "Infor", "Remember", cbRemember.Checked.ToString());            
        }
        public void ReadInfo()
        {
            try
            {
                string status = "";
                status = tool.Read(pathfile, "Infor", "Remember");
                if (status == "true")
                {
                    txtUser.Text = tool.Read(pathfile, "Infor", "User");
                    cbRemember.Checked = true;                    
                }
                cbbLanguage.SelectedIndex = int.Parse(tool.Read(pathfile, "Infor", "Language"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbRemember.Checked)
                CreateInfo();
            else
            {
                tool.Write(pathfile, "Infor", "User", "");
                tool.Write(pathfile, "Infor", "Remember", "false");
                tool.Write(pathfile, "Infor", "Language", "-1");
            }
            if (txtUser.Text == "")
            {
                lbwarning1.Visible = true;
                txtUser.Focus();
            }
            else
            {
                if (txtPassword.Text == "")
                {
                    lbwarning2.Visible = true;
                    txtPassword.Focus();
                }
                else
                {
                    if (cbbLanguage.Text == "")
                    {
                        lbwarning3.Visible = true;
                        cbbLanguage.Focus();
                    }
                    else
                    {
                        string sql = "select * from tb_User where Password='" + txtPassword.Text + "' and UserCode='" + txtUser.Text + "'";
                        MessageBox.Show("sql ="+sql);
                        DataTable dt = conn.GetDataTable(sql);
                        if (dt.Rows.Count == 1)
                        {
                            tool.Write(pathfile, "Infor", "Language", cbbLanguage.SelectedIndex.ToString());
                            this.Hide();
                            AssyLineSystem.frm_Main frm = new AssyLineSystem.frm_Main();
                            frm.user__ = txtUser.Text;
                            frm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            frm_MessageWarning warning = new frm_MessageWarning();
                            warning.index = 3;
                            warning.ShowDialog();
                        }
                    }
                }
            }
            
        }
       
    }
}
