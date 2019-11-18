using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EchartsWeb.SQL数据处理
{
    public class SQLClass
    {
        public static DataTable GetTable( string sqlstr) {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=10.114.113.2,1433;Initial Catalog=tab_ESD_MonitorDB;Persist Security Info=True;User ID=sa;Password=";
            conn.Open();
            SqlCommand com = new SqlCommand(sqlstr, conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            //SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;





        }



    }
}