using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Users : IUser {

        public UserData Login(String strMask, String strPassword, out Int32 nRet) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@MASK", SqlDbType.VarChar, strMask);
            param[1] = DbHelper.MakeParameter("@PASSWORD", SqlDbType.VarChar, strPassword);
            param[2] = new SqlParameter("@RET",SqlDbType.Int);
            param[2].Direction = ParameterDirection.Output;
            IDataReader dr = DbHelper.ExecQuery("m3_user_login", param);
          
            UserData ud = new UserData();
            if(dr.Read()){               
                ud.UId = (Int32)dr["u_id"];
                ud.UMask = (String)dr["u_mask"];
                ud.UName = (String)dr["u_name"];
                ud.UPermit = (Int32)dr["u_permit"];
                ud.UGroupMask = (Int32)dr["u_groupmask"];
                ud.UPoint = (Int32)dr["u_point"];
                ud.UMonthCardValid = DateTime.Parse(dr["u_monthcard_valid"].ToString());
            }
            dr.Close();
            nRet = (Int32)param[2].Value;
            if (nRet > 0)
                return ud;
            return null;
        }

        public UserData GetUserById(Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            IDataReader dr = DbHelper.ExecQuery("m3_user_getdetailbyid", param);
            if (dr.Read()) {
                UserData ud = new UserData();
                ud.UId = nUserId;
                ud.UMask = (String)dr["u_mask"];
                ud.UName = (String)dr["u_name"];
                ud.UPermit = (Int32)dr["u_permit"];
                ud.UGroupMask = (Int32)dr["u_groupmask"];
                ud.UInfo = dr["u_info"].ToString();
                ud.UPasswd = dr["u_passwd"].ToString();
                ud.UPoint = (Int32)dr["u_point"];
                ud.UMonthCardValid = DateTime.Parse(dr["u_monthcard_valid"].ToString());
                dr.Close();
                return ud;
            } else {
                dr.Close();
                return null;
            }
        }

        public UserData GetUserByMask(String strUserMask) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@MASK", SqlDbType.VarChar, strUserMask);
            IDataReader dr = DbHelper.ExecQuery("m3_user_getdetailbymask", param);
            if (dr.Read()) {
                UserData ud = new UserData();
                ud.UId = (Int32)dr["u_id"];
                ud.UMask = strUserMask;
                ud.UName = (String)dr["u_name"];
                ud.UPermit = (Int32)dr["u_permit"];
                ud.UGroupMask = (Int32)dr["u_groupmask"];
                ud.UInfo =  dr["u_info"].ToString();
                ud.UPasswd = dr["u_passwd"].ToString();
                ud.UPoint = (Int32)dr["u_point"];
                ud.UMonthCardValid = DateTime.Parse(dr["u_monthcard_valid"].ToString());
                dr.Close();
                return ud;
            } else {
                dr.Close();
                return null;
            }
        }

        public Int32 UpdateUserPwdById(Int32 nUserId, String strOldPassword, String strNewPassword) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@OLDPWD", SqlDbType.VarChar, strOldPassword);
            param[2] = DbHelper.MakeParameter("@NEWPWD", SqlDbType.VarChar, strNewPassword);
            return DbHelper.ReaderInt32("m3_user_motifypassword", param);
        }


        public Int32 InsertUser(UserData userda) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@MASK", SqlDbType.VarChar, userda.UMask);
            param[1] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, userda.UName);
            param[2] = DbHelper.MakeParameter("@PASSWORD", SqlDbType.VarChar, userda.UPasswd);
            param[3] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, userda.UInfo);
            param[4] = DbHelper.MakeParameter("@PERMIT", SqlDbType.VarChar, userda.UPermit);
            param[5] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.VarChar, userda.UGroupMask);
            return DbHelper.ReaderInt32("m3_user_insert", param);
        }


        public String GetUserNameById(Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            return DbHelper.ReaderString("m3_user_getusername", param);
        }

        public Int32 GetUserPointById(Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            return DbHelper.ReaderInt32("m3_user_getuserpoint", param);
        }

        public Int32 UpdateUserPointById(Int32 nUserId, Int32 nPoint) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@VALUE", SqlDbType.Int, nPoint);
            return DbHelper.ExecNonQuery("m3_user_updateuserpoint", param);
        }

        public String GetUserMonthCardValid(Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            return DbHelper.ReaderString("m3_user_getusermonthcard", param);
        }

        public Int32 UpdateUserMonthCard(Int32 nUserId, DateTime dtValid) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@VALUE", SqlDbType.DateTime, dtValid);
            return DbHelper.ExecNonQuery("m3_user_updateusermonthcard", param);
        }

        public Int32 DelUserById(Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            return DbHelper.ExecNonQuery("m3_user_delete", param);
        }

        public Int32 UpdateUserById(UserData userda) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, userda.UId);
            param[1] = DbHelper.MakeParameter("@MASK", SqlDbType.VarChar, userda.UMask);
            param[2] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, userda.UName);
            param[3] = DbHelper.MakeParameter("@PASSWORD", SqlDbType.VarChar, userda.UPasswd);
            param[4] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, userda.UInfo);
            param[5] = DbHelper.MakeParameter("@PERMIT", SqlDbType.VarChar, userda.UPermit);
            param[6] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.VarChar, userda.UGroupMask);
            return DbHelper.ExecNonQuery("m3_user_update", param);
        }


        public IList<UserData> SearchUserByMask(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strSearchKey);
            param[1] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[2] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            
            IDataReader dr = DbHelper.ExecQuery("m3_user_searchbymask", param);
            IList<UserData> udList = new List<UserData>();
            while (dr.Read()) {
                    udList.Add(new UserData((Int32)dr["u_id"], (String)dr["u_mask"], (String)dr["u_name"]));             
            }
            dr.Close();
            return udList;
        }
        public IList<UserData> SearchUserByName(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strSearchKey);
            param[1] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[2] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);

            IDataReader dr = DbHelper.ExecQuery("m3_user_searchbyname", param);
            IList<UserData> udList = new List<UserData>();
            while (dr.Read())
            {
                udList.Add(new UserData((Int32)dr["u_id"], (String)dr["u_mask"], (String)dr["u_name"]));
            }
            dr.Close();
            return udList;
        }

        public Int32 SearchUserByMaskCount(Int32 nGroupMask, String strSearchKey) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strSearchKey);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_user_searchcountbymask", param);
        }

        public Int32 SearchUserByNameCount(Int32 nGroupMask, String strSearchKey)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strSearchKey);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_user_searchcountbyname", param);
        }

        public IList<UserData> GetList(Int32 nGroupMask, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[1] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[2] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            
            IDataReader dr = DbHelper.ExecQuery("m3_user_getlist", param);
            IList<UserData> udList = new List<UserData>();
            while (dr.Read()) {
                    udList.Add(new UserData((Int32)dr["u_id"],(String)dr["u_mask"],(String)dr["u_name"]));
               
            }
            dr.Close();
            return udList;
        }


        /// <summary>
        ///  取全部用户（不分页）
        /// </summary>
        /// <returns></returns>
        public IList<UserData> GetList()
        {
            SqlParameter[] param = null;

            IDataReader dr = DbHelper.ExecQuery("m3_user_getall", param);
            IList<UserData> udList = new List<UserData>();
            while (dr.Read())
            {
                UserData ud = new UserData();
                ud.UId = (Int32)dr["u_id"];
                ud.UMask = (String)dr["u_mask"];
                ud.UGroupMask = (Int32)dr["u_groupmask"];
                udList.Add(ud);

            }
            dr.Close();
            return udList;
        }



        public Int32 GetCount(Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_user_getcount", param);
        }
    }
}
