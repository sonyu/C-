using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;

namespace ObjectTool
{
   public class ToolCS
    {
        ConnectSQL conn = new ConnectSQL();
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);
 
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);        
 
        public void Write(string filePath,string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value.ToLower(),filePath);
        }
 
        public string Read(string filePath,string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255,filePath);
            return SB.ToString();
        }
       //Cắt dấu =
        public string ToolSubStringLast(string tmp,int point)
        {
            string result = "";
            if (tmp != "" && tmp != null && tmp.Contains('='))
                result = tmp.Split('=')[point];
            return result;
        }        
       //Lấy danh sách Section trong INI
       
        public List<string> GetListSection(string filePath, string section)
        {
            List<string> list = new List<string>();            
            string[]s = File.ReadAllLines(filePath);
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains(section) && s[i].Contains('['))
                {
                    flag = true;
                }
                else
                {
                    if (s[i].Contains('[') && s[i].Contains(section) == false)
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        list.Add(s[i]);
                    }
                }                
            }
            return list;
        }
        public string GetLanguage(string language)
        {
            string key = "";
            switch (language)
            {
                case "0":
                    key = "word_eng";
                    break;
                case "1":
                    key = "word_loc";
                    break;
                case "2":
                    key = "word_korea";
                    break;
                default: key = "word_def";
                    break;
            }
            return key;
        }
        public bool CheckLanguage(Control tmp)
        {
            string sql = "select * from tb_language where obj_name='" + tmp.Name+"'";
            DataTable dt = conn.GetDataTable(sql);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        public void ResetLanguage(Control tmp)
        {
            string sql = "delete from tb_language where obj_name='" + tmp.Name + "'";
            conn.GetDataTable(sql);            
        }

        public void TranslateControl(Control tmp,Control tmp1,string language)
        {
            string pathfile = Application.StartupPath + @"\option.ini";
            string servername_ = Read(pathfile, "DataBase", "Server");
            string database_ = Read(pathfile, "DataBase", "DataBase");
            string user_ = Read(pathfile, "DataBase", "User");
            conn = new ConnectSQL(servername_, database_, user_);
                if (tmp1 is DataGridView)
                {
                    
                    DataGridView tmp2 = (DataGridView)tmp1;
                    for (int i = 0; i < tmp2.Columns.Count; i++)
                    {
                        try
                        {
                            string headername = tmp2.Columns[i].Name;
                            string sql = "select  " + language + " as language from tb_language where obj_name='" + tmp.Name + "' and control_name='" + headername + "'";
                            DataTable dt = conn.GetDataTable(sql);
                            tmp2.Columns[i].HeaderText = dt.Rows[0]["language"].ToString();
                        }
                        catch(Exception ex)
                        {
                            string s = ex.ToString();
                        }
                    }
                }
                else
                {
                    if (tmp1 is MenuStrip)
                    {
                        MenuStrip tmp2 = (MenuStrip)tmp1;
                        foreach (ToolStripMenuItem tmp3 in tmp2.Items)
                        {
                            string sql = "select  " + language + " as language from tb_language where obj_name='" + tmp.Name + "' and control_name='" + tmp3.Name + "'";
                            DataTable dt = conn.GetDataTable(sql);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                tmp3.Text = dt.Rows[0]["language"].ToString();
                            }
                        }
                    }
                    else
                    {
                        string sql = "select  " + language + " as language from tb_language where obj_name='" + tmp.Name + "' and control_name='" + tmp1.Name + "'";
                        DataTable dt = conn.GetDataTable(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmp1.Text = dt.Rows[0]["language"].ToString();
                        }
                    }
                }            
        }
        public void InsertData(string objecname, string controlname, string controltype, string word_def, string word_eng, string word_loc, string word_korea)
        {
            string pathfile = Application.StartupPath + @"\option.ini";
            string servername_ = Read(pathfile, "DataBase", "Server");
            string database_ = Read(pathfile, "DataBase", "DataBase");
            string user_ = Read(pathfile, "DataBase", "User");
            conn = new ConnectSQL(servername_, database_, user_);
            string sql = "insert into tb_language values('" + objecname + "','" + controlname + "','" + controltype + "',N'" + word_def + "',N'" + word_eng + "',N'" + word_loc + "',N'" + word_korea + "')";
            conn.ExecuteNonQuery(sql);
        }

    }
}
