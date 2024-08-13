﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SupermarketWebService
{
    public class OperadorDb
    {
        private static string conStr = "Data Source=.;Initial Catalog=Supermarket;User ID=sa;Password=slaves123#";
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);//ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool ExecCmd(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);//ConfigurationManager.AppSettings["conStr"]);
                                                          //启用事务实现       
            con.Open();
            SqlTransaction st = con.BeginTransaction();
            SqlCommand com = con.CreateCommand();
            com.Transaction = st;
            try
            {
                com.CommandText = sql;
                com.ExecuteNonQuery();
                st.Commit();
                con.Close();
                return true;
            }
            catch
            {
                st.Rollback();
                con.Close();
                return false;
            }
        }
    }
}
