using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;
namespace MOD.IDAL
{
    public interface IPointCard
    {
        /// <summary>
        /// �������б�,���ֶ�Ϊ�ղ���������
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
        /// �����������
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
        /// ���ɿ���
        /// </summary>
        /// <param name="pcData"></param>
        /// <returns></returns>
        Int32 InsertCard(PointCardData pcData);

        /// <summary>
        /// �ж����뿨��ǰ��λ����ʼ���ֺͽ��������Ƿ񼺾�ʹ�ù�
        /// ���� -1 �������ڣ�1��ʾ������
        /// </summary>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <returns></returns>
        Int32 IsRepeat(String strBegin, String strEnd);

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="nCardId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nCardId);


        /// <summary>
        /// ���ݿ��Ż�ȡ�ÿ�������Ϣ
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <returns></returns>
        PointCardData GetPointCardByNo(String strCardNo);

        /// <summary>
        /// ���¿���״̬
        /// </summary>
        /// <param name="strCardNo"></param>
        /// <param name="nState"></param>
        /// <returns></returns>
        Int32 UpdateState(String strCardNo, Int32 nState);

        /// <summary>
        /// ��ӵ㿨��ֵʹ����Ϣ
        /// </summary>
        /// <param name="pcid">����ID</param>
        /// <param name="userid">�û�ID</param>
        /// <param name="dtnow">��ֵʹ��ʱ��</param>
        /// <returns></returns>
        Int32 InsertCardUseRecord(Int32 pcid, Int32 userid, DateTime dtnow);

        /// <summary>
        /// ������ѿ��㲥��¼
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="userid"></param>
        /// <param name="dtnow"></param>
        /// <returns></returns>
        Int32 InsertCardPlayRecord(Int32 pid, Int32 userid, DateTime dtnow, Int32 usepoint);

        Int32 DeleteCardPlayRecord(Int32 pcpid);
       

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
        IList<PointCardUseData> GetUseList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType,Int32 nPage,Int32 nPageSize);

        /// <summary>
        /// (����)����������ѯȫ���û��ĳ�ֵ��¼
        /// </summary>  
        IList<PointCardUseData> GetUseList(String strUMask, DateTime dtBeginTime, DateTime dtEndTime,
           Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ��ѯʹ�ý������
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">��������:��0��ʾ����ʱ�䷶Χ��ѯ��0����ѯȫ��</param>
        /// <returns></returns>
        Int32 GetUseCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);

        /// <summary>
        /// (����)����������ѯȫ���û��ĳ�ֵ��¼
        /// </summary>       
        Int32 GetUseCount(String strUMask, DateTime dtBeginTime, DateTime dtEndTime);

        /// <summary>
        /// ��ѯ�û����˵ĵ㲥ʹ�ÿ��ļ�¼
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType">��������:��0��ʾ����ʱ�䷶Χ��ѯ��0����ѯȫ��</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<PointCardPlayData> GetPlayList(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType, Int32 nPage, Int32 nPageSize);


        /// <summary>
        /// ��ѯȫ���û��ĵ㲥ʹ�ü�¼�����أ�
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
        /// ��ѯ�㲥�������
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        Int32 GetPlayCount(Int32 nUserId, DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);
        Int32 GetPlayCount(DateTime dtBeginTime, DateTime dtEndTime, Int32 nType);
        /// <summary>
        /// ��ȡĳ����Ŀ��һ�β��ŵ�ʱ��
        /// </summary>
        /// <param name="nPid"></param>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        String GetFirstPlayTimeByProgramId(Int32 nPid, Int32 nUserId);
    }
}
