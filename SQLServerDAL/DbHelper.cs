using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Web;

namespace MOD.SQLServerDAL
{
    //æ≤Ã¨∞Ô÷˙¿‡
	public class DbHelper
	{
		private static String GetConnectionString(){
			String strServer,strUid,strPwd;
			strServer = strUid = strPwd = "";			
			strServer = HttpContext.Current.Session["SQLServer"].ToString();
            strUid = HttpContext.Current.Session["SQLUid"].ToString();
            strPwd = HttpContext.Current.Session["SQLPwd"].ToString();			
			return "server="+strServer+";Initial Catalog=mod31;UID="+strUid+";PWD="+strPwd;
		}

		public static SqlParameter MakeParameter(String strParam,SqlDbType dbType,Object objValue){
			SqlParameter param = new SqlParameter(strParam,dbType);
			param.Value = objValue;
			return param;
		}

		private static SqlCommand BuildCommand(SqlConnection conn,String strProcName,SqlParameter[] paramLists){
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = strProcName;
			if(paramLists != null){
				foreach(SqlParameter p in paramLists){
					cmd.Parameters.Add(p);
				}
			}
			return cmd;
		}

		public static Int32 ReaderInt32(String strProcName,SqlParameter[] paramLists){
			Int32 nRet=0;
			using (SqlConnection conn = new SqlConnection(GetConnectionString())){
				SqlCommand cmd = BuildCommand(conn,strProcName,paramLists);
				conn.Open();
				SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read()) {
                    nRet = sdr.GetInt32(0);
                }
				sdr.Close();
				cmd.Dispose();
			}
			return nRet;
		}
		public static String ReaderString(String strProcName,SqlParameter[] paramLists){
			String strRet = String.Empty;
			using (SqlConnection conn = new SqlConnection(GetConnectionString())){
				SqlCommand cmd = BuildCommand(conn,strProcName,paramLists);
				conn.Open();
				SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if(sdr.Read()){
					strRet = sdr.GetString(0);
				}
				sdr.Close();
				cmd.Dispose();
			}
			return strRet;
		}

		public static Int32 ExecNonQuery(String strProcName,SqlParameter[] paramLists){
			Int32 nRet = 0;
			using (SqlConnection conn = new SqlConnection(GetConnectionString())){
				SqlCommand cmd = BuildCommand(conn,strProcName,paramLists);
				conn.Open();
				nRet = cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			return nRet;
		}

		public static SqlDataReader ExecQuery(String strProcName,SqlParameter[] paramLists){
			SqlConnection conn = new SqlConnection(GetConnectionString());
				SqlCommand cmd = BuildCommand(conn,strProcName,paramLists);
				conn.Open();
                SqlDataReader drData = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Dispose();
                return drData;
              //  return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			          
		}
	}
}
