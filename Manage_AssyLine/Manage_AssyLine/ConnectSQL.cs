using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Manage_AssyLine
{
    public class ConnectSQL
    {
        SqlConnection conn;

        // Mở kết nối
        private string servername_ , database_ ;
        public ConnectSQL() { }
        public ConnectSQL(string servername, string database)
        {
            this.servername_ = servername;
            this.database_ = database;                 
        }

        public void Connect()
        {
            servername_ = "VXKHANH-PC"; database_ = "taixin_db";
            if (conn == null)

                conn = new SqlConnection(@"Data Source="+servername_+";Initial Catalog="+database_+";Persist Security Info=True;User ID=sa;Password=Ksystem!2013");

            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }

        // Đóng kết nối

        public void Disconnect()
        {

            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();

        }

        // Trả về một DataTable .

        public DataTable GetDataTable(string sql)
        {

            Connect();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            Disconnect();

            return dt;

        }

        // Thực thi câu lệnh truy vấn insert,delete,update

        public void ExecuteNonQuery(string sql)
        {

            Connect();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            Disconnect();

        }

        // Trả về DataReader

        public SqlDataReader getDataReader(string sql)
        {

            Connect();

            SqlCommand com = new SqlCommand(sql, conn);

            SqlDataReader dr = com.ExecuteReader();

            return dr;

        }
    }
}
