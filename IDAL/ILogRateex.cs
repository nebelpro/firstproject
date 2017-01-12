using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL
{
    public interface ILogRateex
    {
        /// <summary>
        /// 查询点播记录
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="strBeginTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetList(DateTime dtBeginTime, DateTime dtEndTime, Int32 nType, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 获取查询总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="strBeginTime"></param>
        /// <param name="strEndTime"></param>
        /// <returns></returns>
        Int32 GetCount(DateTime  dtBeginTime, DateTime  dtEndTime,Int32 nType);
    }
}
