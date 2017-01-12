using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class PointCards : IPointCard {

        public IList<PointCardData> Search(String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = DbHelper.MakeParameter("@NO", SqlDbType.VarChar, strCardNo);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginDate);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndDate);
            param[3] = DbHelper.MakeParameter("@STATE", SqlDbType.VarChar, nState);
            param[4] = DbHelper.MakeParameter("@TYPE", SqlDbType.VarChar, nType);
            param[5] = DbHelper.MakeParameter("@MAKER", SqlDbType.VarChar, strMaker);
            param[6] = DbHelper.MakeParameter("@PAGE", SqlDbType.VarChar, nPage);
            param[7] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.VarChar, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_card_search", param);
            IList<PointCardData> pcdList = new List<PointCardData>();
            while (dr.Read()) {
                PointCardData pcd = new PointCardData();
                pcd.PcId = (Int32)dr["pc_id"];
                pcd.PcNumber = (String)dr["pc_number"];
                pcd.PcPasswd = (String)dr["pc_passwd"];
                pcd.PcState = (Int32)dr["pc_state"];
                pcd.PcValidDate = (DateTime)dr["pc_valid_date"];
                pcd.PcPointValue = (Int32)dr["pc_point_value"];
                pcd.PcMakeUser = (String)dr["pc_make_user"];
                pcd.PcType = (Int32)dr["pc_type"];
                pcdList.Add(pcd);           
            }
            dr.Close();
            return pcdList;
        }

        public IList<PointCardData> GetMakeCardList(String strCardBegin, String strCardEnd, Int32 nPage, Int32 nPageSize)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@BEGINNO", SqlDbType.VarChar, strCardBegin);
            param[1] = DbHelper.MakeParameter("@ENDNO", SqlDbType.VarChar, strCardEnd);
            param[2] = DbHelper.MakeParameter("@PAGE", SqlDbType.VarChar, nPage);
            param[3] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.VarChar, nPageSize);

            IDataReader dr = DbHelper.ExecQuery("m3_card_getmakelist", param);
            IList<PointCardData> pcdList = new List<PointCardData>();
            while (dr.Read())
            {
                PointCardData pcd = new PointCardData();
                pcd.PcId = (Int32)dr["pc_id"];
                pcd.PcNumber = (String)dr["pc_number"];
                pcd.PcPasswd = (String)dr["pc_passwd"];
                pcd.PcState = (Int32)dr["pc_state"];
                pcd.PcValidDate = (DateTime)dr["pc_valid_date"];
                pcd.PcPointValue = (Int32)dr["pc_point_value"];
                pcd.PcMakeUser = (String)dr["pc_make_user"];
                pcd.PcType = (Int32)dr["pc_type"];
                pcdList.Add(pcd);
            }
            dr.Close();
            return pcdList;

        }

        public Int32 GetMakeCardListCount(String strCardBegin, String strCardEnd)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@BEGINNO", SqlDbType.VarChar, strCardBegin);
            param[1] = DbHelper.MakeParameter("@ENDNO", SqlDbType.VarChar, strCardEnd);

            return DbHelper.ReaderInt32("m3_card_getmakelistcount", param);

        }

        public Int32 SearchCount(String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@NO", SqlDbType.VarChar, strCardNo);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginDate);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndDate);
            param[3] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            param[4] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[5] = DbHelper.MakeParameter("@MAKER", SqlDbType.VarChar, strMaker);
            return DbHelper.ReaderInt32("m3_card_searchcount", param);
        }

        public Int32 InsertCard(PointCardData pcData) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DbHelper.MakeParameter("@NO", SqlDbType.VarChar, pcData.PcNumber);
            param[1] = DbHelper.MakeParameter("@PASSWORD", SqlDbType.VarChar,pcData.PcPasswd);
            param[2] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, pcData.PcState);
            param[3] = DbHelper.MakeParameter("@VALIDDATE", SqlDbType.DateTime, pcData.PcValidDate);
            param[4] = DbHelper.MakeParameter("@VALUE", SqlDbType.Int, pcData.PcPointValue);
            param[5] = DbHelper.MakeParameter("@MAKER", SqlDbType.VarChar, pcData.PcMakeUser);
            param[6] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, pcData.PcType);
            return DbHelper.ExecNonQuery("m3_card_insert", param);
        }

        public Int32 IsRepeat(String strBegin, String strEnd) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@BEGINNO", SqlDbType.VarChar, strBegin);
            param[1] = DbHelper.MakeParameter("@ENDNO", SqlDbType.VarChar, strEnd);
            return DbHelper.ReaderInt32("m3_card_check", param);
        }

        public Int32 Delete(Int32 nCardId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PCID", SqlDbType.Int, nCardId);
            return DbHelper.ExecNonQuery("m3_card_del", param);
        }

        public PointCardData GetPointCardByNo(String strCardNo) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@NO", SqlDbType.VarChar, strCardNo);
            IDataReader dr = DbHelper.ExecQuery("m3_card_getdetailbyno", param);
            if (dr.Read()) {
                PointCardData pcd = new PointCardData();
                pcd.PcId = (Int32)dr["pc_id"];
                pcd.PcNumber = (String)dr["pc_number"];
                pcd.PcPasswd = (String)dr["pc_passwd"];
                pcd.PcState = (Int32)dr["pc_state"];
                pcd.PcValidDate = (DateTime)dr["pc_valid_date"];
                pcd.PcPointValue = (Int32)dr["pc_point_value"];
                pcd.PcMakeUser = (String)dr["pc_make_user"];
                pcd.PcType = (Int32)dr["pc_type"];
                dr.Close();
                return pcd;
            }
            return null;
        }


        public Int32 UpdateState(String strCardNo, Int32 nState) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@NO", SqlDbType.VarChar, strCardNo);
            param[1] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            return DbHelper.ExecNonQuery("m3_card_updatestate", param);
        }


        public Int32 InsertCardUseRecord(Int32 pcid, Int32 userid, DateTime dtnow) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@PCID", SqlDbType.Int, pcid);
            param[1] = DbHelper.MakeParameter("@UID", SqlDbType.Int, userid);
            param[2] = DbHelper.MakeParameter("@ADDTIME", SqlDbType.DateTime, dtnow);
            return DbHelper.ExecNonQuery("m3_card_adduserecord", param);
        }

        public Int32 InsertCardPlayRecord(Int32 pid, Int32 userid, DateTime dtnow, Int32 usepoint) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, pid);
            param[1] = DbHelper.MakeParameter("@UID", SqlDbType.Int, userid);
            param[2] = DbHelper.MakeParameter("@ADDTIME", SqlDbType.DateTime, dtnow);
            param[3] = DbHelper.MakeParameter("@POINT", SqlDbType.Int, usepoint);
            return DbHelper.ExecNonQuery("m3_card_addplaylog", param);
        }
        public Int32 DeleteCardPlayRecord(Int32 pcpid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PCPID", SqlDbType.Int, pcpid);
            return DbHelper.ExecNonQuery("m3_card_playrecord_del", param);
        }

        public IList<PointCardUseData> GetUseList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[3] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[4] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[5] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_card_searchuse", param);
            IList<PointCardUseData> pcudList = new List<PointCardUseData>();
            while (dr.Read()) {
                PointCardUseData pud = new PointCardUseData();
                pud.CuNumber =(String)dr["pc_number"];
                pud.CuPointValue=(Int32)dr["pc_point_value"];
                pud.CuDateTime =(DateTime)dr["pcu_datetime"];
                pud.CuType = (Int32)dr["pc_type"];
               pcudList.Add(pud);
            }
            dr.Close();
            return pcudList;
        }

        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>  
        public IList<PointCardUseData> GetUseList(String strUMask, DateTime dtBeginTime, DateTime dtEndTime,
           Int32 nPage, Int32 nPageSize)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@UMASK", SqlDbType.VarChar, strUMask);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);          
            param[3] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[4] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_card_searchuseall", param);
            IList<PointCardUseData> pcudList = new List<PointCardUseData>();
            while (dr.Read())
            {
                PointCardUseData pcud = new PointCardUseData();
                pcud.CuNumber=(String)dr["pc_number"];
                pcud.CuPointValue=(Int32)dr["pc_point_value"];
                pcud.CuDateTime=(DateTime)dr["pcu_datetime"];
                pcud.CuMask=(String)dr["u_mask"];
                pcud.CuType = (Int32)dr["pc_type"];
                pcudList.Add(pcud);
            }
            dr.Close();
            return pcudList;
        }

        public Int32 GetUseCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[3] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            return DbHelper.ReaderInt32("m3_card_searchusecount", param);
        }

        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>       
        public Int32 GetUseCount(String strUMask, DateTime dtBeginTime, DateTime dtEndTime)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@UMASK", SqlDbType.VarChar, strUMask);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
           
            return DbHelper.ReaderInt32("m3_card_searchusecountall", param);
        }

        public IList<PointCardPlayData> GetPlayList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[3] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[4] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[5] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_card_searchplay", param);
            IList<PointCardPlayData> pcpdList = new List<PointCardPlayData>();
            while (dr.Read()) {                
                PointCardPlayData pcpd = new PointCardPlayData();
                pcpd.PcpUserMask = (String)dr["u_mask"];
                pcpd.PcpProgramPoint = (Int32)dr["pcp_point"];
                pcpd.PcpProgramName = (String)dr["p_name"];
                pcpd.PcpDateTime = (DateTime)dr["pcp_datetime"];
                pcpd.PcpProgramId = (Int32)dr["pcp_program_id"];
                pcpdList.Add(pcpd);          
            }
           dr.Close();
           return pcpdList;
        }

        public IList<PointCardPlayData> GetPlayList(DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize)
        {
            SqlParameter[] param = new SqlParameter[5];           
            param[0] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[1] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[2] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[3] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[4] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_card_searchplayall", param);
            IList<PointCardPlayData> pcpdList = new List<PointCardPlayData>();
            while (dr.Read())
            {
                PointCardPlayData pcpd = new PointCardPlayData();
                pcpd.PcpId = (Int32)dr["pcp_id"];
                pcpd.PcpUserMask = (String)dr["u_mask"];
                pcpd.PcpProgramPoint = (Int32)dr["pcp_point"];
                pcpd.PcpProgramName = (String)dr["p_name"];
                pcpd.PcpDateTime = (DateTime)dr["pcp_datetime"];
                pcpd.PcpProgramId = (Int32)dr["pcp_program_id"];
                pcpdList.Add(pcpd);
            }
            dr.Close();
            return pcpdList;
        }

        public Int32 GetPlayCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[2] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[3] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            return DbHelper.ReaderInt32("m3_card_searchplaycount", param);
        }
        public Int32 GetPlayCount(DateTime dtBeginTime, DateTime dtEndTime, Int32 nType)
        {
            SqlParameter[] param = new SqlParameter[3];           
            param[0] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
            param[1] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
            param[2] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            return DbHelper.ReaderInt32("m3_card_searchplaycountall", param);
        }



        public String GetFirstPlayTimeByProgramId(Int32 nPid, Int32 nUserId) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nPid);
            param[1] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            return DbHelper.ReaderString("m3_card_getlastplaytime", param);
        }
    }
}
