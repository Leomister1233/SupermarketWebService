using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SupermarketWebService
{
    /// <summary>
    /// Summary description for SupermarketWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SupermarketWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetUserInfoByCondition(string username, string password,string usertype, string phone, string gender, string email, string address)
        {
            string sqlstr = "";
            if (username != "")
                sqlstr += "username='" + username + "' and ";
            if (password != "")
                sqlstr += "password like'" + password + "%' and ";
            if (usertype != "")
                sqlstr += "phone ='" + usertype + "' and ";
            if (phone != "")
                sqlstr += "phone ='" + phone + "' and ";
            if (gender != "")
                sqlstr += "gender='" + gender + "' and ";
            if (email != "")
                sqlstr += "email='" + email + "' and ";
            if (address != "")
                sqlstr += "address='" + address + "' and ";
            if (sqlstr != "")
            {
                sqlstr = sqlstr.Substring(0, sqlstr.Length - 4);
                sqlstr = "select [username],[password],[usertype] ,[phone] ,[gender],[email],[address] from Username where " + sqlstr;
            }
            else
                sqlstr = "select [username],[password] ,[usertype],[phone] ,[gender],[email],[address] from  Username";
            DataTable dt = OperadorDb.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["username"].ToString());
                    list.Add(dt.Rows[i]["password"].ToString());
                    list.Add(dt.Rows[i]["usertype"].ToString());
                    list.Add(dt.Rows[i]["phone"].ToString());
                    list.Add(dt.Rows[i]["gender"].ToString());
                    list.Add(dt.Rows[i]["email"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetUserInfoByUsername(string username)
        {
            string sql = "select * from UserName where username='" + username + "'";
            DataTable dt = OperadorDb.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["username"].ToString());
                list.Add(dt.Rows[0]["password"].ToString());
                list.Add(dt.Rows[0]["usertype"].ToString());
                list.Add(dt.Rows[0]["phone"].ToString());
                list.Add(dt.Rows[0]["gender"].ToString());
                list.Add(dt.Rows[0]["email"].ToString());
                list.Add(dt.Rows[0]["address"].ToString());
                return list;
            }
            return null;
        }
        [WebMethod]
        public List<string> GetUserInfoByIdPassWord(string username)
        {
            string sql = "select username ,password from UserName where username='" + username + "'";
            DataTable dt = OperadorDb.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["username"].ToString());
                list.Add(dt.Rows[0]["password"].ToString());
                list.Add(dt.Rows[0]["usertype"].ToString());
                return list;
            }
            return null;
        }
        [WebMethod]
        public List<string> GetUserOrderInfoByUsername(string username)
        {
            string sql = "select username,phone,email,address from UserName where username='" + username + "'";
            DataTable dt = OperadorDb.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["username"].ToString());
                list.Add(dt.Rows[0]["phone"].ToString());
                list.Add(dt.Rows[0]["email"].ToString());
                list.Add(dt.Rows[0]["address"].ToString());
                return list;
            }
            return null;
        }
        [WebMethod]
        public List<string> GetUserPassWordInfoReset(string username)
        {
            string sql = "select username ,email from UserName where username='" + username + "'";
            DataTable dt = OperadorDb.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["username"].ToString());
                list.Add(dt.Rows[0]["email"].ToString());
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetAllUserInfo()
        {
            string sql = "select * from UserName ";
            DataTable dt = OperadorDb.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[0]["username"].ToString());
                    list.Add(dt.Rows[0]["password"].ToString());
                    list.Add(dt.Rows[0]["usertype"].ToString());
                    list.Add(dt.Rows[0]["phone"].ToString());
                    list.Add(dt.Rows[0]["gender"].ToString());
                    list.Add(dt.Rows[0]["email"].ToString());
                    list.Add(dt.Rows[0]["address"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public bool InsertUserInfo(string username, string password, string usertype, string phone, string gender, string email, string address)
        {
            string sqlstr = "INSERT INTO UserName  (username,password,usertype,phone,gender,email,address) VALUES ('" + username + "','" + password + "','" + usertype + "','" + phone + "','" + gender + "','" + email + "','" + address + "')";
            return OperadorDb.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool DeleteUserInfo(string username)
        {
            string sqlstr = "DELETE FROM UserName  WHERE username = '" + username + "'";

            return OperadorDb.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool UpdateUserInfoByUsername(string username, string password, string usertype, string phone, string gender, string email, string address)
        {
            string sqlstr = "UPDATE   UserName  SET password='" + password  +"',usertype='" +usertype +"',phone='" + phone + "',gender='" + gender + "',email='" + email + "', address='" + address + "' WHERE username='" + username + "'";
            return OperadorDb.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool UpdateUserPassword(string username, string password)
        {
            string sqlstr = "UPDATE   UserName  SET password='" + password + "' WHERE username='" + username + "'";
            return OperadorDb.ExecCmd(sqlstr);
        }
        [WebMethod]
        public bool InsertProductInfoById(string ProductId,string ProductName, string ProductPrice)
        {
            string sqlstr = "insert into Products values(ProductId,ProductName,ProductPrice) VALUES ('" + ProductId + "','" + ProductName + "','" + ProductPrice + "')";
            return OperadorDb.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool UpdateProductInfoById(string ProductId, string ProductName, string ProductPrice)
        {
            string sql = "";
            {
                sql = "UPDATE   Products  SET ProductName='" + ProductName + "',ProductPrice='" + ProductPrice + "' WHERE ProductId='" + ProductId + "'";
            }
            return OperadorDb.ExecCmd(sql);
        }
        [WebMethod]
        public List<string> GetProductInfoById(string ProductId)
        {
            string sqlstr = "select * from ManagerInventory where ProductId='" + ProductId + "'";
            DataTable dt = OperadorDb.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["ProductId"].ToString());
                    list.Add(dt.Rows[i]["ProductName"].ToString());
                    list.Add(dt.Rows[i]["ProductPrice"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public bool DeleteProductInfoById(string ProductId)
        {
            string sql = "DELETE FROM  Products  WHERE ProductId='" + ProductId + "'";

            return OperadorDb.ExecCmd(sql);
        } 
        [WebMethod]
        public bool InsertProdutCartInfoById(string username, string ProductId, string ProductName, string ProductPrice)
        {
            string sqlstr = "INSERT INTO ShoppingCart (username,ProductId,ProductName,ProductPrice) VALUES ('" + username + "','" + ProductId + "','" + ProductName + "')";
            return OperadorDb.ExecCmd(sqlstr);
        }
        [WebMethod]
        public bool DeleteProductCartInfoById(string username)
        {
            string sql = "DELETE FROM  [dbo].[ShoppingCart]  WHERE username='" + username + "'";

            return OperadorDb.ExecCmd(sql);
        }
        [WebMethod]
        public List<string> GetProductCartInfoById(string username)
        {
            string sqlstr = "select * from ShoppingCart where username='" + username + "'";
            DataTable dt = OperadorDb.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["ProductId"].ToString());
                    list.Add(dt.Rows[i]["ProductName"].ToString());
                    list.Add(dt.Rows[i]["ProductCategory"].ToString());
                }
                return list;
            }
            return null;
        }
        [WebMethod]
        public bool DeleteProductCartItemById(string ProductId)
        {
            string sql = "DELETE FROM  [dbo].[ShoppingCart]  WHERE BookId='" + ProductId + "'";

            return OperadorDb.ExecCmd(sql);
        }
    }
    
}
