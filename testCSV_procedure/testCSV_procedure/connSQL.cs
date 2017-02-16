using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace testCSV_procedure
{
    public  class connSQL
    {
        SqlConnection conn;

        public void connect() 
        {
            if (conn == null) conn = new SqlConnection(@"Data Source=(local);Initial Catalog=TestSQL;Persist Security Info=True;User ID=sa;Password=Ksystem!2013");
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        public void disConnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        //getdatatable
        public  DataTable getDataTable (string sql)
        {
            connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            disConnect();
            return dt;
        }

        //Excute sql command insert, update, delete
        public void excuteQuery(string sql)
        {
            connect();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            disConnect();
        }
        //get datareader
        public SqlDataReader getDataReader(string sql)
        {
            connect();
            SqlCommand cmd = new SqlCommand(sql);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
    }
}
