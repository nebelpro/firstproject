using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Web;

namespace MOD.WebUtility {
    public class SqlPager {

        #region 
        private int pageSize = 0;
        private int curPage = 0;
        private string selItem = "";
        private string selTable = "";
        private string selCondition = "";
        private string selTip = "";
        private string selSort = "";//desc降序 asc升序

        public SqlPager() {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public SqlPager( int size, int page, string item, string table, string condition, string tip, string sort ) {
            this.pageSize = size;
            this.curPage = page;
            this.selItem = item;
            this.selTable = table;
            this.selCondition = condition;
            this.selTip = tip;
            this.selSort = sort;
        }

        public int pSize {
            get { return pageSize; }
            set { pageSize = value; }

        }

        public int pPage {
            get { return curPage; }
            set { curPage = value; }
        }

        public int Top {
            get { return (curPage - 1) * pageSize; }

        }
        /// <summary>
        /// eg:  name,password
        /// </summary>
        public string pItem {
            get { return selItem; }
            set { selItem = value; }
        }
        /// <summary>
        /// eg: userTable,userInfoTable
        /// </summary>
        public string pTable {
            get { return selTable; }
            set { selTable = value; }
        }
        /// <summary>
        /// where 后面的内容
        /// </summary>
        public string pCondition {
            get { return selCondition; }
            set { selCondition = value; }

        }
        /// <summary>
        /// 根据排序的字段
        /// </summary>
        public string pTip {
            get { return selTip; }
            set { selTip = value; }
        }
        public string pSort {
            get { return selSort; }
            set { selSort = value; }
        }
        public string Order {
            get { return "order by " + selTip + " " + selSort; }
        }
        public string SQL {
            get {
                string strCondition2 = "";
                string strCondition1 = "";
                if (this.pCondition.Trim() != string.Empty) {
                    strCondition1 = " where " + this.pCondition + " and ";
                    strCondition2 = " where " + this.pCondition + " ";
                } else {
                    strCondition1 = " where ";
                    strCondition2 = " ";
                }
                string sqlTemp = "select top " + this.pSize.ToString() + " " + this.pItem + " from " + this.pTable +
                                strCondition1 +
                                this.pTip + " not in" + "(	" +
                                "select top " + this.Top.ToString() + " " + this.pTip + " " +
                                " from " +  this.pTable +
                                strCondition2 +
                                " " + this.Order + ") " + this.Order + "";
                return sqlTemp;

            }
        }
        public string SqlCount {
            get {
                return "select count(1) from " + this.pTable + " where " + this.pCondition;
            }
        }
        #endregion 

        #region 
        private String GetConnectionString() {
            String strServer, strUid, strPwd;
            strServer = strUid = strPwd = "";
            strServer = HttpContext.Current.Session["SQLServer"].ToString();
            strUid = HttpContext.Current.Session["SQLUid"].ToString();
            strPwd = HttpContext.Current.Session["SQLPwd"].ToString();
            return "server=" + strServer + ";Initial Catalog=mod31;UID=" + strUid + ";PWD=" + strPwd;
        }
        public SqlParameter MakeParameter( String strParam, SqlDbType dbType, Object objValue ) {
            SqlParameter param = new SqlParameter(strParam, dbType);
            param.Value = objValue;
            return param;
        }
        private SqlCommand BuildCommand( SqlConnection conn, String strProcName, SqlParameter[] paramLists ) {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strProcName;
            if (paramLists != null) {
                foreach (SqlParameter p in paramLists) {
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }
        private SqlCommand BuildCommand( SqlConnection conn, String strSql ) {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            return cmd;
        }
        public Int32 ReaderInt32( String strProcName, SqlParameter[] paramLists ) {
            Int32 nRet = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                SqlCommand cmd = BuildCommand(conn, strProcName, paramLists);
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
        public Int32 ReaderInt32( String strSql ) {
            Int32 nRet = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                SqlCommand cmd = BuildCommand(conn, strSql);
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
        public String ReaderString( String strProcName, SqlParameter[] paramLists ) {
            String strRet = String.Empty;
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                SqlCommand cmd = BuildCommand(conn, strProcName, paramLists);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read()) {
                    strRet = sdr.GetString(0);
                }
                sdr.Close();
                cmd.Dispose();
            }
            return strRet;
        }
        public Int32 ExecNonQuery( String strProcName, SqlParameter[] paramLists ) {
            Int32 nRet = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                SqlCommand cmd = BuildCommand(conn, strProcName, paramLists);
                conn.Open();
                nRet = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return nRet;
        }
        public Int32 ExecNonQuery( String strSql ) {
            Int32 nRet = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                SqlCommand cmd = BuildCommand(conn, strSql);
                conn.Open();
                nRet = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return nRet;
        }
        public SqlDataReader ExecQuery( String strProcName, SqlParameter[] paramLists ) {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = BuildCommand(conn, strProcName, paramLists);
            conn.Open();
            SqlDataReader drData = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Dispose();
            return drData;
            //  return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }
        public SqlDataReader ExecQuery( String strSql ) {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = BuildCommand(conn, strSql);
            conn.Open();
            SqlDataReader drData = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Dispose();
            return drData;
        }

        #endregion 
    }
}
