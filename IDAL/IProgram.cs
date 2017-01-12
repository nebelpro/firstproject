using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface IProgram
    {

        /// <summary>
        /// 按分类分页读取节目列表
        /// </summary>
        /// <param name="nCatalogId">为0时获取未分类节目列表</param>
        /// <param name="nCheck">节目状态</param>
        /// <param name="nClass">当前用户级别</param>
        /// <param name="nGroupMask">当前用户组权限</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nOrder">排序方式0 加入时间 1节目名称 2点播次数 。。。</param>
        /// <returns></returns>
        IList<ProgramData> GetList(Int32 nCatalogId, Int32 nCheck,Int32 nClass,Int32 nGroupMask,Int32 nPage, Int32 nPageSize,Int32 nOrder);

        /// <summary>
        /// 读取分类节目总数
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <param name="nCheck"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nCatalogId, Int32 nCheck,Int32 nClass,Int32 nGroupMask);

        /// <summary>
        /// 获取课程节目列表
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetListByCourse(Int32 nCourseId, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 取得课程节目总数
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        Int32 GetCountByCourse(Int32 nCourseId);

        /// <summary>
        /// 取得节目详情
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        ProgramData GetDetail(Int32 nProgramId);

        Int32 Delete(Int32 nProgramId);


        /// <summary>
        ///  修改卡的点数值
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pointvalue"></param>
        /// <returns></returns>
        Int32 UpdateProgramPoint(Int32 pid, Int32 pointvalue);

        Int32 UpdateProgramCheck(Int32 nPId, Int32 nCheck);
        
        /// <summary>
        /// 取得个人收藏节目，并分页显示
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetFavList(Int32 nUserId, Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 取得个人收藏节目总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetFavCount(Int32 nUserId, Int32 nClass, Int32 nGroupMask);

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="nMarkId"></param>
        /// <returns></returns>
        Int32 DelFav(Int32 nMarkId);

        Int32 AddFav(Int32 nUserId, Int32 nProgramId);

        /// <summary>
        /// 读取推荐节目
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetRecommendList(Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 读取推荐节目总数
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetRecommendCount(Int32 nClass, Int32 nGroupMask);

        /// <summary>
        /// 删除推荐
        /// </summary>
        /// <param name="nRecommendId"></param>
        /// <returns></returns>
        Int32 DelRecommend(Int32 nProgramId);

        Int32 AddRecommend(Int32 nUserId, Int32 nProgramId);


        Int32 IsRecommend(Int32 nProgramId);

        /// <summary>
        /// 搜索节目
        /// </summary>
        /// <param name="strKey">搜索内容</param>
        /// <param name="nType">搜索类型 0 标题 1 简介 2 主演 3 导演 4 出版单位 5 发布者 6 All</param>
        /// <param name="nClass">当前用户级别</param>
        /// <param name="nGroupMask">当前用户组掩码</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>       
        IList<ProgramData> Search( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize, Int32 nCheck, Int32 nOrder, Int32 nCatalogId );

        /// <summary>
        /// 搜索结果总数
        /// </summary>
        /// <param name="strKey">搜索内容</param>
        /// <param name="nType">搜索类型 0 标题 1 简介 2 主演 3 导演 4 出版单位 5 发布者 6 All</param>
        /// <param name="nClass">当前用户级别</param>
        /// <param name="nGroupMask">当前用户组掩码</param>
        /// <returns></returns>        
        Int32 SearchCount( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask, Int32 nCheck, Int32 nCatalogId );


        /// <summary>
        /// 更新节目的点播次数 
        /// </summary>
        /// <param name="nPid"></param>
        /// <returns></returns>
        Int32 UpdateReadCount(Int32 nPid);
     

        /// <summary>
        /// 根据节目id读取节目片断
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        IList<ChapterData> GetChapterByProgramId(int pid);

        /// <summary>
        /// 返回媒体服务器信息
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        IList<MediaServerData> GetMediaServer( Int32 nProgramId );


        /// <summary>
        /// 取图像数据
        /// </summary>
        /// <param name="nImgId"></param>
        /// <returns></returns>
        ImageData GetImage(Int32 nImgId);

        /// <summary>
        /// 获取节目所属分类列表
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        IList<CatalogData> GetCatalogList(Int32 nProgramId);

        Int32 GetCatalogByProgramId(Int32 nProgramId);

        IList<ProgramData> GetTop(Int32 nCount,Int32 nType,Int32 nClass,Int32 nGroupMask);

        IList<ProgramData> GetTopNewGroupByCataLog(Int32 nCheck, Int32 nClass, Int32 nGroupMask);
    
    }
}
