using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;
namespace MOD.BLL {
    public class LogRateex {

        private static readonly MOD.IDAL.ILogRateex dal = MOD.DALFactory.DataAccess.CreateLogRateex();


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="nUserId">The user id.</param>
        /// <param name="strBeginTime">The begin time.</param>
        /// <param name="strEndTime">The end time.</param>
        /// <param name="nPage">The page.</param>
        /// <param name="nPageSize">Size of the page.</param>
        /// <returns></returns>
        public IList<ProgramData> GetList( DateTime strBeginTime, DateTime strEndTime, Int32 nType, Int32 nPage, Int32 nPageSize ) {
            // ÐèÊÓÍ¼×ª»»
            return (new Program()).TransToViewData(dal.GetList(strBeginTime, strEndTime, nType, nPage, nPageSize));
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="strBeginTime">The STR begin time.</param>
        /// <param name="strEndTime">The STR end time.</param>
        /// <returns></returns>
        public Int32 GetCount( DateTime strBeginTime, DateTime strEndTime, Int32 nType ) {
            return dal.GetCount(strBeginTime, strEndTime, nType);
        }
    }

}
