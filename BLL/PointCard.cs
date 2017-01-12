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
        /// �������б�,���ֶ�Ϊ�ղ���������
        /// </summary>
        public IList<PointCardData> Search( String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker, Int32 nPage, Int32 nPageSize ) {

            return dal.Search(strCardNo, dtBeginDate, dtEndDate, nState, nType, strMaker, nPage, nPageSize); ;
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Int32 SearchCount( String strCardNo, DateTime dtBeginDate, DateTime dtEndDate, Int32 nState,
            Int32 nType, String strMaker ) {
            return dal.SearchCount(strCardNo, dtBeginDate, dtEndDate, nState, nType, strMaker);
        }

        /// <summary>
        /// ���ɿ���
        /// </summary>
        /// <param name="pcData"></param>
        /// <returns></returns>
        public Int32 InsertCard( PointCardData pcData ) {
            return dal.InsertCard(pcData);
        }


        /// <summary>
        /// �ж����뿨��ǰ��λ����ʼ���ֺͽ��������Ƿ񼺾�ʹ�ù�
        /// ���� -1 �������ڣ�1��ʾ������
        /// </summary>
        /// <param name="strBegin">The STR begin.</param>
        /// <param name="strEnd">The STR end.</param>
        /// <returns></returns>
        public Int32 IsRepeat( String strBegin, String strEnd ) {
            //����Ҫ��strBegin,strEnd�������
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
        /// ɾ������
        /// </summary>
        /// <param name="nCardId">The n card id.</param>
        public void Delete( Int32 nCardId ) {
            dal.Delete(nCardId);
        }


        /// <summary>
        /// ���ݿ��Ż�ȡ�ÿ�����ϸ��Ϣ
        /// </summary>
        /// <param name="strCardNo">The STR card no.</param>
        /// <returns></returns>
        public PointCardData GetPointCardByNo( String strCardNo ) {
            return dal.GetPointCardByNo(strCardNo);
        }

        /// <summary>
        /// ���¿���״̬
        /// </summary>
        public Int32 UpdateState( String strCardNo, Int32 nState ) {
            return dal.UpdateState(strCardNo, nState);
        }

        /// <summary>
        /// ��ӵ㿨��ֵʹ����Ϣ
        /// </summary>
        public Int32 InsertCardUseRecord( Int32 pcid, Int32 userid, DateTime dtnow ) {
            return dal.InsertCardUseRecord(pcid, userid, dtnow);
        }

        /// <summary>
        /// ������ѿ��㲥��¼
        /// </summary>
        public Int32 InsertCardPlayRecord( Int32 pid, Int32 userid, DateTime dtnow, Int32 usepoint ) {
            return dal.InsertCardPlayRecord(pid, userid, dtnow, usepoint);
        }
        public Int32 DeleteCardPlayRecord( Int32 pcpid ) {
            return dal.DeleteCardPlayRecord(pcpid);
        }

        /// <summary>
        /// ��ѯ�û����˵ĳ�ֵ��¼
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">��������:��0��ʾ����ʱ�䷶Χ��ѯ��0����ѯȫ��</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<PointCardUseData> GetUseList( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime,
            Int32 nType, Int32 nPage, Int32 nPageSize ) {
            return dal.GetUseList(nUserId, dtBeginTime, dtEndTime, nType, nPage, nPageSize);
        }
        /// <summary>
        /// (����)����������ѯȫ���û��ĳ�ֵ��¼
        /// </summary>  
        public IList<PointCardUseData> GetUseList( String strUMask, DateTime dtBeginTime, DateTime dtEndTime,
           Int32 nPage, Int32 nPageSize ) {
            return dal.GetUseList(strUMask, dtBeginTime, dtEndTime, nPage, nPageSize);
        }

        /// <summary>
        /// ��ѯʹ�ý������
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">��������:��0��ʾ����ʱ�䷶Χ��ѯ��0����ѯȫ��</param>
        /// <returns></returns>
        public Int32 GetUseCount( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetUseCount(nUserId, dtBeginTime, dtEndTime, nType);
        }

        /// <summary>
        /// (����)����������ѯȫ���û��ĳ�ֵ��¼
        /// </summary>       
        public Int32 GetUseCount( String strUMask, DateTime dtBeginTime, DateTime dtEndTime ) {
            return dal.GetUseCount(strUMask, dtBeginTime, dtEndTime);
        }

        /// <summary>
        /// ��ѯ�û����˵ĵ㲥ʹ�ÿ��ļ�¼��lkw  2006-11-23modify��
        /// </summary>
        /// <param name="nUserId">0,��ʾ��ѯȫ���û�</param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">��������:��0��ʾ����ʱ�䷶Χ��ѯ��0����ѯȫ��</param>
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
        /// ��ѯ�㲥�������
        /// </summary>
        public Int32 GetPlayCount( Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetPlayCount(nUserId, dtBeginTime, dtEndTime, nType);
        }
        public Int32 GetPlayCount( DateTime dtBeginTime, DateTime dtEndTime, Int32 nType ) {
            return dal.GetPlayCount(dtBeginTime, dtEndTime, nType);
        }
        /// <summary>
        /// ��ȡĳ����Ŀ��һ�β��ŵ�ʱ��
        /// </summary>
        /// <param name="nPid">pid.</param>
        /// <param name="nUserId">userid.</param>
        /// <returns></returns>
        public String GetFirstPlayTimeByProgramId( Int32 nPid, Int32 nUserId ) {
            return dal.GetFirstPlayTimeByProgramId(nPid, nUserId);
        }





        #region  ��������

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
