using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace webservice
{
    /// <summary>
    /// Summary description for WebService_kanban
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService_kanban : System.Web.Services.WebService
    {
        [WebMethod()]
        public void insert_data_to_db_from_local(string partnumber, string srctcode, string dockcode, int pack, string error, string chk, string user, DateTime day, string ekb, string kbid)
        {
            using (SqlConnection conn = new SqlConnection("Server=172.16.16.1;UID=sa;PASSWORD=12345678;database=bds_pp_srct;Max Pool Size=400;Connect Timeout=600;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT  INTO Hanheld(Part_Number,SRCT_Code,Dock_Code,Package,Error_Code,Chk_Type,LogUser,LogDate,ekb_order_no,Kanban_ID) VALUES(@partnumber,@srctcode,@dockcode,@pack,@error,@chk,@user,@day,@ekb,@kbid)";
                    cmd.Parameters.AddWithValue("@partnumber", partnumber);
                    cmd.Parameters.AddWithValue("@srctcode", srctcode);
                    cmd.Parameters.AddWithValue("@dockcode", dockcode);
                    cmd.Parameters.AddWithValue("@pack", pack);
                    cmd.Parameters.AddWithValue("@error", error);
                    cmd.Parameters.AddWithValue("@chk", chk);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@ekb", ekb);
                    cmd.Parameters.AddWithValue("@kbid", kbid);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                       // MessgeBox.Show(e.Message.ToString(), "Error Message");
                    }

                }
            }
        }
        /*
        [WebMethod()]
        public DataTable count_rows_db()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();
            strConnString = "Server=localhost;UID=sa;PASSWORD=12345678;database=bds_pp_srct;Max Pool Size=400;Connect Timeout=600;";
            strSQL.Append("SELECT Part_Number,SRCT_Code,Dock_Code,Package,ISNULL(Error_Code,'unknow') AS Error_Code,Chk_Type,IsMatch,LogUser,LogDate,PDS_number,ekb_order_no,ISNULL(Kanban_ID,'unknow') AS Kanban_ID from t_shoping_export_log");
            //strSQL.Append(" WHERE [SRCT_Code] = '" + strCusID + "' ");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);
            dt = ds.Tables[0];
            dtAdapter = null;
            objConn.Close();
            objConn = null;
            return dt;
        }
    */
        [WebMethod()]
        public DataTable get_m_kanban()
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();
            strConnString = "Server=172.16.16.1;UID=sa;PASSWORD=12345678;database=bds_pp_srct;Max Pool Size=400;Connect Timeout=600;";
            strSQL.Append("SELECT ISNULL(SRCT_Code,' ') AS SRCT_Code,ISNULL(Customer_Code,' ') AS Customer_Code, ISNULL(Attension_point,' ') AS Attension_point,ISNULL(Part_Number,' ') AS Part_Number,ISNULL(Part_Name, ' ') AS Part_Name,ISNULL(Model,' ' ) AS Model ,ISNULL(Package,' ') AS Package,ISNULL (Customer, ' ') AS Customer,ISNULL(Line, ' ') AS Line,ISNULL(Store_Address, ' ') AS Store_Address,ISNULL(Part_Ilustration,' ') AS Part_Ilustration,ISNULL(Part_Ilustration_Path, ' ') AS Part_Ilustration_Path,ISNULL(Dock_Code, ' ') AS Dock_Code,ISNULL(Location, ' ') AS Location ,ISNULL(KB_running, ' ') AS KB_running FROM m_kanban");
            //strSQL.Append(" WHERE [SRCT_Code] = '" + strCusID + "' ");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);
            dt = ds.Tables[0];
            dtAdapter = null;
            objConn.Close();
            objConn = null;
            return dt;
        }
       
        [WebMethod()]
        public DataTable get_srct_kanban(string ekanban,string loca,string dock)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();
            strConnString = "Server=172.16.16.1;UID=sa;PASSWORD=12345678;database=bds_pp_srct;Max Pool Size=400;Connect Timeout=600;";
            strSQL.Append("SELECT * FROM [bds_pp_srct].[dbo].[m_kanban]   WHERE [Customer_Code] = '" + ekanban + "' AND Location ='" + loca + "' AND Dock_Code='" + dock + "'");
            //strSQL.Append(" WHERE [SRCT_Code] = '" + strCusID + "' ");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);
            dt = ds.Tables[0];
            dtAdapter = null;
            objConn.Close();
            objConn = null;
            return dt;
        }

        [WebMethod()]
        public DataTable login(string username)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();
            strConnString = "Server=172.16.16.1;UID=sa;PASSWORD=12345678;database=bds_pp_srct;Max Pool Size=400;Connect Timeout=600;";
            strSQL.Append("SELECT * FROM s_user  WHERE QRCode = '" + username + "' ");
            //strSQL.Append(" WHERE [SRCT_Code] = '" + strCusID + "' ");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);
            dt = ds.Tables[0];
            dtAdapter = null;
            objConn.Close();
            objConn = null;
            return dt;
        }

    }
}
