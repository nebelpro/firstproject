using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class PointCard {

        private static readonly MOD.IDAL.IPointCard dal = MOD.DALFactory.DataAccess.CreatePointCard();



        //Make Card Error
        public enum ENUM_MAKE_CARD {
            RET_SUCCESS = 1,
            RET_CARDNO_EXIST = -1
        }



        public Int32 GetMakeCardListCount( String strCardBegin, String strCardEnd ) {
            return dal.GetMakeCardListCount(strCardBegin, strCardEnd);
        }

        public IList<PointCardData> GetMakeCardList( String strCardBegin, String strCardEnd, Int32 nPage, Int32 nPageSize ) {
            return dal.GetMakeCardList(strCardBegin, strCardEnd, nPage, nPageSize);
        }

        /// <summary>
        /// 搜索卡列表,当字段为空不参与搜索
        /// </summary>
        public IList<PointCardData> Search( String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker, Int32 nPage, Int32 nPageSize ) {

            return dal.Search(strCardNo, dtBeginDate, dtEndDate, nState, nType, strMaker, nPage, nPageSize); ;
        }

        /// <summary>
        /// 搜索结果总数
        /// </summary>
        public Int32 SearchCount( String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker ) {
            return dal.SearchCount(strCardNo, dtBeginDate, dtEndDate, nState, nType, strMaker);
        }

        /// <summary>
        /// 生成卡号
        /// </summary>
        /// <param name="pcData"></param>
        /// <returns></returns>
        public Int32 InsertCard( PointCardData pcData ) {
            return dal.InsertCard(pcData);
        }


        /// <summary>
        /// 判断输入卡号前四位、起始数字和结束数字是否己经使用过
        /// 返回 -1 己经存在，1表示不存在
        /// </summary>
        /// <param name="strBegin">The STR begin.</param>
        /// <param name="strEnd">The STR end.</param>
        /// <returns></returns>
        public Int32 IsRepeat( String strBegin, String strEnd ) {
            //这里要对strBegin,strEnd进行组合
            return dal.IsRepeat(strBegin, strEnd);
        }



        public Int32 MakeCards( String strPrefix, Int32 nNoBegin, Int32 nNoEnd, DateTime dtValid, Int32 nCardValue, Int32 nCardType, string strMakeUser ) {
            Int32 nRet = IsRepeat(strPrefix + FormatNo(nNoBegin), strPrefix + FormatNo(nNoEnd));
            if (nRet == (Int32)ENUM_MAKE_CARD.RET_CARDNO_EXIST) {
                return (Int32)ENUM_MAKE_CARD.RET_CARDNO_EXIST;
            } else {
                for (int j = nNoBegin; j <= nNoEnd; j++) {

                    PointCardData pd = new PointCardData();

                    pd.PcMakeUser = strMakeUser;
                    pd.PcNumber = strPrefix + FormatNo(j);
                    pd.PcPasswd = MakeCardPwd(j);
                    pd.PcPointValue = nCardValue;
                    pd.PcState = 0;
                    pd.PcValidDate = dtValid;
                    pd.PcType = nCardType;

                    InsertCard(pd);
                }

                return (int)ENUM_MAKE_CARD.RET_SUCCESS;
            }
        }





        /// <summary>
        /// 删除卡号
        /// </summary>
        /// <param name="nCardId">The n card id.</param>
        public void Delete( Int32 nCardId ) {
            dal.Delete(nCardId);
        }


        /// <summary>
        /// 根据卡号获取该卡的详细信息
        /// </summary>
        /// <param name="strCardNo">The STR card no.</param>
        /// <returns></returns>
        public PointCardData GetPointCardByNo( String strCardNo ) {
            return dal.GetPointCardByNo(strCardNo);
        }

        /// <summary>
        /// 更新卡的状态
        /// </summary>
        public Int32 UpdateState( String strCardNo, Int32 nState ) {
            return dal.UpdateState(strCardNo, nState);
        }

        /// <summary>
        /// 添加点卡充值使用信息
        /// </summary>
        public Int32 InsertCardUseRecord( Int32 pcid, Int32 userid, DateTime dtnow ) {
            return dal.InsertCardUseRecord(pcid, userid, dtnow);
        }

        /// <summary>
        /// 添加消费卡点播记录
        /// </summary>
        public Int32 InsertCardPlayRecord( Int32 pid, Int32 userid, DateTime dtnow, Int32 usepoint ) {
            return dal.InsertCardPlayRecord(pid, userid, dtnow, usepoint);
        }
        public Int32 DeleteCardPlayRecord( Int32 pcpid ) {
            return dal.DeleteCardPlayRecord(pcpid);
        }

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
        public IList<PointCardUseData> GetUseList( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize ) {
            return dal.GetUseList(nUserId, dtBeginTime, dtEndTime, nType, nPage, nPageSize);
        }
        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>  
        public IList<PointCardUseData> GetUseList( String strUMask, DateTime dtBeginTime, DateTime dtEndTime,
           Int32 nPage, Int32 nPageSize ) {
            return dal.GetUseList(strUMask, dtBeginTime, dtEndTime, nPage, nPageSize);
        }

        /// <summary>
        /// 查询使用结果总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">操作类型:非0表示根据时间范围查询，0，查询全部</param>
        /// <returns></returns>
        public Int32 GetUseCount( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetUseCount(nUserId, dtBeginTime, dtEndTime, nType);
        }

        /// <summary>
        /// (重载)根据条件查询全部用户的充值记录
        /// </summary>       
        public Int32 GetUseCount( String strUMask, DateTime dtBeginTime, DateTime dtEndTime ) {
            return dal.GetUseCount(strUMask, dtBeginTime, dtEndTime);
        }

        /// <summary>
        /// 查询用户个人的点播使用卡的记录（lkw  2006-11-23modify）
        /// </summary>
        /// <param name="nUserId">0,表示查询全部用户</param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">操作类型:非0表示根据时间范围查询，0，查询全部</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<PointCardPlayData> GetPlayList( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize ) {
            return dal.GetPlayList(nUserId, dtBeginTime, dtEndTime, nType, nPage, nPageSize);
        }
        public IList<PointCardPlayData> GetPlayList( DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize ) {
            return dal.GetPlayList(dtBeginTime, dtEndTime, nType, nPage, nPageSize);
        }
        /// <summary>
        /// 查询点播结果总数
        /// </summary>
        public Int32 GetPlayCount( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetPlayCount(nUserId, dtBeginTime, dtEndTime, nType);
        }
        public Int32 GetPlayCount( DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetPlayCount(dtBeginTime, dtEndTime, nType);
        }
        /// <summary>
        /// 提取某个节目第一次播放的时间
        /// </summary>
        /// <param name="nPid">pid.</param>
        /// <param name="nUserId">userid.</param>
        /// <returns></returns>
        public String GetFirstPlayTimeByProgramId( Int32 nPid, Int32 nUserId ) {
            return dal.GetFirstPlayTimeByProgramId(nPid, nUserId);
        }





        #region  辅助函数

        public string FormatNo( Int32 nNo ) {
            string strNo = nNo.ToString();
            string strOut = "";
            for (int i = 0; i <= (5 - strNo.Length); i++) {
                strOut += "0";
            }

            return strOut + strNo;
        }

        public string MakeCardPwd( Int32 j ) {
            String strOut = "";

            string ser = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9";
            string[] arr = ser.Split(",".ToCharArray());
            Random rnd = new Random((int)DateTime.Now.Ticks + j);
            for (int i = 0; i < 10; ) {

                Int32 nRnd = rnd.Next(1, 36);
                if (nRnd >= 0 && nRnd <= 36) {
                    strOut = strOut + arr[nRnd];
                    i++;
                }
            }
            return strOut;
        }




        #endregion
    }
}
