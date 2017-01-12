using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Remark {

        private static readonly MOD.IDAL.IRemark dal = MOD.DALFactory.DataAccess.CreateRemark();

        /// <summary>
        /// 插入评论
        /// </summary>
        /// <param name="remarkdata">The remarkdata.</param>
        /// <returns></returns>
        public Int32 Insert( RemarkData remarkdata ) {

            return dal.Insert(remarkdata);
        }

        /// <summary>
        /// 更新评论状态
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <param name="nState">0 未通过，1通过审核</param>
        /// <returns></returns>
        public void UpdateState( Int32 nRemarkId, Int32 nState ) {
            dal.UpdateState(nRemarkId, nState);
        }

        /// <summary>
        /// 删除单条评论
        /// </summary>
        /// <param name="nRemarkId">The n remark id.</param>
        public void Delete( Int32 nRemarkId ) {
            dal.Delete(nRemarkId);
        }

        /// <summary>
        /// 删除节目下所有评论,此方法在删除节目时调用
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public void DeleteByProgram( Int32 nProgramId ) {
            dal.DeleteByProgram(nProgramId);
        }

        /// <summary>
        /// 获取指定节目评论 分页列表
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<RemarkData> GetListByProgram( Int32 nProgramId, Int32 nState, Int32 nPage, Int32 nPageSize ) {
            return dal.GetListByProgram(nProgramId, nState, nPage, nPageSize);
        }

        /// <summary>
        /// 获取指定节目评论总数
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <returns></returns>
        public Int32 GetCountByProgram( Int32 nProgramId, Int32 nState ) {
            return dal.GetCountByProgram(nProgramId, nState);
        }

        /// <summary>
        /// 获取所有评论(后台统一审核)
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nState">0 未审核，1己审核 -1全部</param>
        /// <returns></returns>
        public IList<RemarkData> GetList( Int32 nPage, Int32 nPageSize, Int32 nState ) {
            return dal.GetList(nPage, nPageSize, nState);
        }

        /// <summary>
        /// 获取评论总数.
        /// </summary>
        /// <param name="nState">State(0:未审核 1:审核  -1全部)</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nState ) {
            return dal.GetCount(nState);
        }

        /// <summary>
        /// 读取评论详情
        /// </summary>
        /// <param name="nRemarkId">The n remark id.</param>
        /// <returns></returns>
        public RemarkData GetDetail( Int32 nRemarkId ) {
            return dal.GetDetail(nRemarkId);
        }
    }
}
