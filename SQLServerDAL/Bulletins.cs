using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Bulletins : IBulletin {

        public IList<BulletinData> GetList(Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[1] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_bulletin_getlist", param);
            IList<BulletinData> bdList = new List<BulletinData>();
            while (dr.Read()) {
               bdList.Add(new BulletinData((Int32)dr["b_id"], (String)dr["b_name"], dr["b_info"].ToString(), (DateTime)dr["b_addtime"], (Int32)dr["b_user_id"],(String)dr["u_name"]));
            }
            dr.Close();
            return bdList;
        }

        public Int32 GetCount() {
            return DbHelper.ReaderInt32("m3_bulletin_getcount", null);
        }

        public int Delete(int bid) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@BID", SqlDbType.Int, bid);
            return DbHelper.ExecNonQuery("m3_bulletin_delete", param);
        }

        public BulletinData GetBulletinByBid(int bid) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@BID", SqlDbType.Int, bid);
            IDataReader dr = DbHelper.ExecQuery("m3_bulletin_getdetail", param);
            if (dr.Read())
                return (new BulletinData((Int32)dr["b_id"], (String)dr["b_name"], dr["b_info"].ToString(), (DateTime)dr["b_addtime"], (Int32)dr["b_user_id"],(String)dr["u_name"]));
            dr.Close();
            return null;
        }

        public int Update(BulletinData bda) {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@BID", SqlDbType.Int, bda.BId);
            param[1] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, bda.BName);
            param[2] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, bda.BInfo);
            param[3] = DbHelper.MakeParameter("@ADDTIME", SqlDbType.DateTime, bda.BAddtime);
            param[4] = DbHelper.MakeParameter("@UID", SqlDbType.Int, bda.BUserId);
            return DbHelper.ExecNonQuery("m3_bulletin_update",param);
        }

        public int Insert(BulletinData bda) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, bda.BName);
            param[1] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, bda.BInfo);
            param[2] = DbHelper.MakeParameter("@ADDTIME", SqlDbType.DateTime, bda.BAddtime);
            param[3] = DbHelper.MakeParameter("@UID", SqlDbType.Int, bda.BUserId);
            return DbHelper.ExecNonQuery("m3_bulletin_insert", param);
        }
    }
}
