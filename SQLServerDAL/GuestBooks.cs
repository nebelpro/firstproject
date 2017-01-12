using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class GuestBooks : IGuestBook {

        public IList<GuestBookData> GetList(Int32 nType, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[1] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[2] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_guestbook_getlist", param);
            IList<GuestBookData> gbList = new List<GuestBookData>();
            while (dr.Read()) {
                 gbList.Add(new GuestBookData((Int32)dr["gb_id"], (String)dr["gb_subject"],
                        (String)dr["gb_info"], (DateTime)dr["gb_date"], (String)dr["gb_user"], (Int32)dr["gb_type"]));
            }
            dr.Close();
            return gbList;
        }


        public Int32 GetCount(Int32 nType) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            return DbHelper.ReaderInt32("m3_guestbook_getcount", param);
        }

        public GuestBookData GetDetail(Int32 nGuestbookId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@GBID", SqlDbType.Int, nGuestbookId);
            IDataReader dr = DbHelper.ExecQuery("m3_guestbook_getdetail", param);
            if (dr.Read()) {
                GuestBookData gb = new GuestBookData();
                gb.GbId = nGuestbookId;
                gb.GbSubject = (String)dr["gb_subject"];
                gb.GbInfo = (String)dr["gb_info"];
                gb.GbType = (Int32)dr["gb_type"];
                gb.GbUser = (String)dr["gb_user"];
                gb.GbDate = (DateTime)dr["gb_date"];
                dr.Close();
                return gb;
            }
            return null;
        }

        public Int32 Insert(GuestBookData guestbookdata) {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@SUBJECT", SqlDbType.VarChar, guestbookdata.GbSubject);
            param[1] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, guestbookdata.GbInfo);
            param[2] = DbHelper.MakeParameter("@DATE", SqlDbType.DateTime, guestbookdata.GbDate);
            param[3] = DbHelper.MakeParameter("@USER", SqlDbType.VarChar, guestbookdata.GbUser);
            param[4] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, guestbookdata.GbType);
            return DbHelper.ExecNonQuery("m3_guestbook_insert", param);
        }

        public Int32 Delete(Int32 nGuestbookId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@GBID", SqlDbType.Int, nGuestbookId);
            return DbHelper.ExecNonQuery("m3_guestbook_del", param);
        }

    }
}
