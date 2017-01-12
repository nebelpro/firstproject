using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;
namespace MOD.IDAL
{
    public interface IPointCard
    {
        /// <summary>
        /// 搜索卡列表,当字段为空不参与搜索
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="nState"></param>
        /// <param name="nType"></param>
        /// <param name="strMaker"></param>
        /// <returns></returns>
        IList<PointCardData> Search(String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker,Int32 nPage,Int32 nPageSize);

        IList<PointCardData> GetMakeCardList(String strCardBegin, String strCardEnd, Int32 nPage, Int32 nPageSize);
        Int32 GetMakeCardListCount(String strCardBegin, String strCardEnd);

        /// <summary>
        /// 搜索结果总数
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="nState"></param>
        /// <param name="nType"></param>
        /// <param name="strMaker"></param>
        /// <returns></returns>
        Int32 SearchCount(String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker);

        /// <summary>
        /// 生成卡号
        /// </summary>
        /// <param name="pcData"></param>
        /// <returns></returns>
        Int32 InsertCard(PointCardData pcData);

        /// <summary>
        /// 判断输入卡号前四位、起始数字和结束数字是否己经使用过
        /// 返回 -1 己经存在，1表示不存在
        /// </summary>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <returns></returns>
        Int32 IsRepeat(String strBegin, String strEnd);

        /// <summary>
        /// 删除卡号
        /// </summary>
        /// <param name="nCardId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nCardId);


        /// <summary>
        /// 根据卡号获取该卡所有信息
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <returns></returns>
        PointCardData GetPointCardByNo(String strCardNo);

        /// <summary>
        /// 更新卡的状态
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <param name="nState"></param>
        /// <returns></returns>
        Int32 UpdateState(String strCardNo, Int32 nState);

        /// <summary>
        /// 添加点卡充值使用信息
        /// </summary>
        /// <param name="pcid">卡号ID</param>
        /// <param name="userid">用户ID</param>
        /// <param name="dtnow">充值使用时间</param>
        /// <returns></returns>
        Int32 InsertCardUseRecord(Int32 pcid, Int32 userid, DateTime dtnow);

        /// <summary>
        /// 添加消费卡点播记录
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="userid"></param>
        /// <param name="dtnow"></param>
        /// <returns></returns>
        Int32 InsertCardPlayRecord(Int32 pid, Int32 userid, DateTime dtnow, Int32 usepoint);

        Int32 DeleteCardPlayRecord(Int32 pcpid);
       

        /// <summary>
        /// 查询用户个人的充值记录
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">操作类型:非0表示根据时间范围查询，0，查询全部</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<PointCardUseData> GetUseList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType,Int32 nPage,Int32 nPageSize);

        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>  
        IList<PointCardUseData> GetUseList(String strUMask, DateTime dtBeginTime, DateTime dtEndTime,
           Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 查询使用结果总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">操作类型:非0表示根据时间范围查询，0，查询全部</param>
        /// <returns></returns>
        Int32 GetUseCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);

        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>       
        Int32 GetUseCount(String strUMask, DateTime dtBeginTime, DateTime dtEndTime);

        /// <summary>
        /// 查询用户个人的点播使用卡的记录
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">操作类型:非0表示根据时间范围查询，0，查询全部</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<PointCardPlayData> GetPlayList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType, Int32 nPage, Int32 nPageSize);


        /// <summary>
        /// 查询全部用户的点播使用记录（重载）
        /// </summary>
        /// <param name="dtBeginTime">The dt begin time.</param>
        /// <param name="dtEndTime">The dt end time.</param>
        /// <param name="nType">Type of the n.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        IList<PointCardPlayData> GetPlayList(DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize);
        /// <summary>
        /// 查询点播结果总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        Int32 GetPlayCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);
        Int32 GetPlayCount(DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);
        /// <summary>
        /// 提取某个节目第一次播放的时间
        /// </summary>
        /// <param name="nPid"></param>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        String GetFirstPlayTimeByProgramId(Int32 nPid, Int32 nUserId);
    }
}
