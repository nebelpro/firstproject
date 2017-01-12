using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Remarks : IRemark {

        public Int32 Insert(RemarkData remarkdata) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, remarkdata.PrName);
            param[1] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, remarkdata.PrInfo);
            param[2] = DbHelper.MakeParameter("@UID", SqlDbType.Int, remarkdata.PrUserId);
            param[3] = DbHelper.MakeParameter("@PID", SqlDbType.Int, remarkdata.PrProgramId);
            param[4] = DbHelper.MakeParameter("@ADDTIME", SqlDbType.DateTime, remarkdata.PrAddTime);
            param[5] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, remarkdata.PrState);
            return DbHelper.ExecNonQuery("m3_remark_insert", param);
        }

        public Int32 UpdateState(Int32 nRemarkId, Int32 nState) {
            
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@REMARKID", SqlDbType.Int, nRemarkId);
            param[1] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            return DbHelper.ExecNonQuery("m3_remark_updatestate", param);
        }

        public Int32 Delete(Int32 nRemarkId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@REMARKID", SqlDbType.Int, nRemarkId);
            return DbHelper.ExecNonQuery("m3_remark_del", param);
        }


        public Int32 DeleteByProgram(Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ExecNonQuery("m3_remark_delbyprogram", param);
        }

        /// <summary>
        /// 获取指定节目评论 分页列表
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 未审核，1己审核, -1 全部</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<RemarkData> GetListByProgram(Int32 nProgramId, Int32 nState, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            param[1] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[2] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[3] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            IDataReader dr = DbHelper.ExecQuery("m3_remark_getlistbyprogram", param);
            IList<RemarkData> rdList = new List<RemarkData>();
            while (dr.Read()) {                
                RemarkData rd = new RemarkData();
                rd.PrId = (Int32)dr["pr_id"];
                rd.PrName = (String)dr["pr_name"];
                rd.PrInfo =  dr["pr_info"].ToString();
                rd.PrProgramId = (Int32)dr["pr_program_id"];
                rd.PrUserId = (Int32)dr["pr_user_id"];
                rd.PrState = (Int32)dr["pr_state"];
                rd.PrAddTime = (DateTime)dr["pr_addtime"];
                rd.VUserName = dr["u_mask"].ToString();
                rdList.Add(rd);
            }
            dr.Close();
            return rdList;
        }


        public Int32 GetCountByProgram(Int32 nProgramId, Int32 nState) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            param[1] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            return DbHelper.ReaderInt32("m3_remark_getcountbyprogram", param);
        }
        /// <summary>
        ///  获取所有评论（指定获取审核状态  -1 0 1 ）
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nState"></param>
        /// <returns></returns>
        public IList<RemarkData> GetList(Int32 nPage, Int32 nPageSize, Int32 nState) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[1] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[2] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            IDataReader dr = DbHelper.ExecQuery("m3_remark_getlist", param);
            IList<RemarkData> rdList = new List<RemarkData>();
            while (dr.Read()) {
                RemarkData rd = new RemarkData();
                rd.PrId = (Int32)dr["pr_id"];
                rd.PrName = (String)dr["pr_name"];
                rd.PrInfo =  dr["pr_info"].ToString();
                rd.PrProgramId = (Int32)dr["pr_program_id"];
                rd.PrUserId = (Int32)dr["pr_user_id"];
                rd.PrState = (Int32)dr["pr_state"];
                rd.PrAddTime = (DateTime)dr["pr_addtime"];
                rd.VUserName = dr["u_mask"].ToString();
                rdList.Add(rd);
            }
            dr.Close();
            return rdList;
        }

        public Int32 GetCount(Int32 nState) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@STATE", SqlDbType.Int, nState);
            return DbHelper.ReaderInt32("m3_remark_getcount", param);
        }

        public RemarkData GetDetail(Int32 nRemarkId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@REMARKID", SqlDbType.Int, nRemarkId);
            IDataReader dr = DbHelper.ExecQuery("m3_remark_getdetail", param);
            if (dr.Read()) {
                RemarkData rd = new RemarkData();
                rd.PrId = nRemarkId;
                rd.PrName = (String)dr["pr_name"];
                rd.PrInfo = (String)dr["pr_info"];
                rd.PrProgramId = (Int32)dr["pr_program_id"];
                rd.PrUserId = (Int32)dr["pr_user_id"];
               // rd.PrState = (Int32)dr["pr_state"];
                rd.PrAddTime = (DateTime)dr["pr_addtime"];
                rd.VUserName = dr["u_mask"].ToString();
                dr.Close();
                return rd;
            }
            return null;
        }
    }
}
