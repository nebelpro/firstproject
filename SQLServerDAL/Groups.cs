using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Groups : IGroup {

        public Int32 Insert(GroupData groupdata) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, groupdata.GName);
            param[1] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, groupdata.GInfo);
            param[2] = DbHelper.MakeParameter("@PERMIT", SqlDbType.Int, groupdata.GPermit);
            param[3] = DbHelper.MakeParameter("@PERMIT2", SqlDbType.Int, groupdata.GPermit2);
            param[4] = DbHelper.MakeParameter("@MASK", SqlDbType.Int, groupdata.GMask);
            param[5] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, groupdata.GClass);
            return DbHelper.ReaderInt32("m3_group_insert", param);
        }

        public GroupData GetDetailById(Int32 gid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@GID", SqlDbType.Int, gid);
            IDataReader dr = DbHelper.ExecQuery("m3_group_getdetailbyid", param);
            if (dr.Read())
            {
                GroupData gd = new GroupData();
                gd.GId = (Int32)dr["g_id"];
                gd.GName = dr["g_name"].ToString();
                gd.GInfo = dr["g_info"].ToString();
                gd.GClass = (Int32)dr["g_class"];
                gd.GPermit = (Int32)dr["g_permit"];
                //gd.GPermit2 = int.Parse(dr["g_permit2"].ToString());
                gd.GMask = (Int32)dr["g_mask"];
                dr.Close();
                return gd;
            }
            else
            {
                dr.Close();
                return null;
            }
        }

        public Int32 Update(GroupData groupdata) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DbHelper.MakeParameter("@GID", SqlDbType.Int,groupdata.GId);
            param[1] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, groupdata.GName);
            param[2] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, groupdata.GInfo);
            param[3] = DbHelper.MakeParameter("@PERMIT", SqlDbType.Int, groupdata.GPermit);
            param[4] = DbHelper.MakeParameter("@PERMIT2", SqlDbType.Int, groupdata.GPermit2);
            param[5] = DbHelper.MakeParameter("@MASK", SqlDbType.Int, groupdata.GMask);
            param[6] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, groupdata.GClass);
            return DbHelper.ReaderInt32("m3_group_update", param);
        }

        public Int32 Delete(Int32 nGroupId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@GID", SqlDbType.Int, nGroupId);
            return DbHelper.ExecNonQuery("m3_group_delete", param);
        }

        public IList<GroupData> GetGroupByUserGroupMask(Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@MASK", SqlDbType.Int, nGroupMask);
            IDataReader dr = DbHelper.ExecQuery("m3_group_getlistbymask", param);
            IList<GroupData> gdList = new List<GroupData>();
            while (dr.Read()) {
                GroupData gd = new GroupData((Int32)dr["g_id"],(String)dr["g_name"],dr["g_info"].ToString(),
                    (Int32)dr["g_permit"], (Convert.IsDBNull(dr["g_permit2"]) ? 0 : (int)dr["g_permit2"]), (Int32)dr["g_mask"], (Int32)dr["g_class"]);
                gdList.Add(gd);
            }
            dr.Close();
            return gdList;
        }

        public IList<GroupData> GetList(Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[1] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_group_getlist", param);
            IList<GroupData> gdList = new List<GroupData>();
            while (dr.Read())
            {
                GroupData gd = new GroupData();
                gd.GMask = (Int32)dr["g_mask"];
                gd.GName = dr["g_name"].ToString();
                gd.GId = (Int32)dr["g_id"];
                gd.GClass = (Int32)dr["g_class"];
                gdList.Add(gd);
            }
            dr.Close();
            return gdList;
        }

        public Int32 GetCount() {
            return DbHelper.ReaderInt32("m3_group_getcount",null);
        }




   
    }
}
