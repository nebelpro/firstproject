using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IRemark
    {
        /// <summary>
        /// 插入评论
        /// </summary>
        /// <param name="remarkdata"></param>
        /// <returns></returns>
        Int32 Insert(RemarkData remarkdata);

        /// <summary>
        /// 更新评论状态
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <param name="nState">0 未通过，1通过审核</param>
        /// <returns></returns>
        Int32 UpdateState(Int32 nRemarkId, Int32 nState);

        /// <summary>
        /// 删除单条评论
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nRemarkId);

        /// <summary>
        /// 删除节目下所有评论,此方法在删除节目时调用
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        Int32 DeleteByProgram(Int32 nProgramId);

        /// <summary>
        /// 获取指定节目评论 分页列表
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<RemarkData> GetListByProgram(Int32 nProgramId,Int32 nState,Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 获取指定节目评论总数
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <returns></returns>
        Int32 GetCountByProgram(Int32 nProgramId,Int32 nState);

        /// <summary>
        /// 获取所有评论
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <returns></returns>
        IList<RemarkData> GetList(Int32 nPage, Int32 nPageSize,Int32 nState);

        /// <summary>
        /// 获取评论总数
        /// </summary>
        /// <param name="nState">0 未审核，1己审核</param>
        /// <returns></returns>
        Int32 GetCount(Int32 nState);

        /// <summary>
        /// 读取评论详情
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <returns></returns>
        RemarkData GetDetail(Int32 nRemarkId);
    }
}
