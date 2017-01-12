using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.BLL {
    public class Program {

        private static readonly MOD.IDAL.IProgram dal = MOD.DALFactory.DataAccess.CreateProgram();

        /// <summary>
        /// ��ȡ��Ŀ�б�
        /// order ֵ�� define.enmu_program_sort
        /// </summary>
        /// <param name="nCatalogId">-1ȫ�������Ŀ��0 ��ȡδ����, > 0 �����ID��-2��ȫ����Ŀ</param>
        /// <param name="nCheck">0:δ��ˣ�1ͨ�����</param>
        /// <param name="nClass">1-255</param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nOrder">����</param>
        /// <returns></returns>
        public IList<ProgramData> GetList( Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize, Int32 nOrder ) {
            // ��Ҫ����ͼת���������Ŀλ��ʱ����
            return TransToViewData(dal.GetList(nCatalogId, nCheck, nClass, nGroupMask, nPage, nPageSize, nOrder));
        }

        public Int32 UpdateProgramPoint( Int32 nPId, Int32 nPoint ) {
            return dal.UpdateProgramPoint(nPId, nPoint);
        }

        /// <summary>
        /// ���½�Ŀ�ĵ㲥����
        /// </summary>
        /// <param name="nPid">The n pid.</param>
        public void UpdateReadCount( Int32 nPid ) {
            dal.UpdateReadCount(nPid);
        }

        public Int32 Delete( Int32 nProgramId ) {
            return dal.Delete(nProgramId);
        }

        /// <summary>
        /// Updates the program check.
        /// </summary>
        /// <param name="nPId">The n P id.</param>
        /// <param name="nCheck">1YES 0 NO </param>
        /// <returns></returns>
        public Int32 UpdateProgramCheck( Int32 nPId, Int32 nCheck ) {
            return dal.UpdateProgramCheck(nPId, nCheck);
        }
        /// <summary>
        /// ��DAL���ص���������ͼת��
        /// </summary>
        /// <param name="prmlist">��Ŀ���ݵļ���</param>
        /// <returns></returns>
        public IList<ProgramData> TransToViewData( IList<ProgramData> prmlist ) {
            IList<ProgramData> programlist = new List<ProgramData>();
            System.Collections.IEnumerator myEnum = prmlist.GetEnumerator();
            while (myEnum.MoveNext()) {
                ProgramData pda = (ProgramData)myEnum.Current;
                //��ʼת����Ҫ����ͼ����               
                pda.nTime = BLLHelper.FormatTime(pda.PDuration);
                pda.nKbps = BLLHelper.GetKbps(pda.PSizeHigh, pda.PSizeLow, pda.PDuration);
                programlist.Add(pda);
            }
            return programlist;
        }

        /// <summary>
        /// ��ȡָ�������Ŀ����
        /// </summary>
        /// <param name="nCatalogId">The n catalog id.</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nClass">The n class.</param>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetCount(nCatalogId, nCheck, nClass, nGroupMask);
        }

        /// <summary>
        /// ��ȡ��Ŀ����
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public ProgramData GetDetail( Int32 nProgramId ) {

            // ��Ҫ����ͼת���������Ŀλ��ʱ����
            ProgramData prmdata = dal.GetDetail(nProgramId);
            if (prmdata != null) {
                prmdata.nTime = BLLHelper.FormatTime(prmdata.PDuration);
                prmdata.nKbps = BLLHelper.GetKbps(prmdata.PSizeHigh, prmdata.PSizeLow, prmdata.PDuration);
            }

            return prmdata;
        }


        #region  �γ̽�Ŀ

        /// <summary>
        /// ��ȡ�γ̽�Ŀ�б�(�ݲ�ʵ��)
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetListByCourse( Int32 nCourseId, Int32 nPage, Int32 nPageSize ) {

            return null;
        }

        /// <summary>
        /// ȡ�ÿγ̽�Ŀ����(�ݲ�ʵ��)
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        public Int32 GetCountByCourse( Int32 nCourseId ) {

            return 0;
        }
        #endregion

        #region  �ղؽ�Ŀ

        /// <summary>
        /// ȡ�ø����ղؽ�Ŀ������ҳ��ʾ
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetFavList( Int32 nUserId, Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {
            //��Ҫ��ͼת��
            return TransToViewData(dal.GetFavList(nUserId, nClass, nGroupMask, nPage, nPageSize));
        }

        /// <summary>
        /// ȡ�ø����ղؽ�Ŀ����
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nClass">The n class.</param>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <returns></returns>
        public Int32 GetFavCount( Int32 nUserId, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetFavCount(nUserId, nClass, nGroupMask);
        }

        /// <summary>
        /// ɾ���ղ�
        /// </summary>
        /// <param name="nMarkId">The n mark id.</param>
        public void DelFav( Int32 nMarkId ) {
            dal.DelFav(nMarkId);
        }
        /// <summary>
        /// �����ղ�.
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nProgramId">The n program id.</param>
        public void AddFav( Int32 nUserId, Int32 nProgramId ) {
            dal.AddFav(nUserId, nProgramId);
        }

        #endregion

        #region �Ƽ���Ŀ

        /// <summary>
        /// ��ȡ�Ƽ���Ŀ
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetRecommendList( Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {
            return TransToViewData(dal.GetRecommendList(nClass, nGroupMask, nPage, nPageSize));
        }

        /// <summary>
        /// ��ȡ�Ƽ���Ŀ����
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        public Int32 GetRecommendCount( Int32 nClass, Int32 nGroupMask ) {

            return dal.GetRecommendCount(nClass, nGroupMask);
        }

        /// <summary>
        /// ɾ���Ƽ�
        /// </summary>
        /// <param name="nRecommendId"></param>
        /// <returns></returns>
        public Int32 DelRecommend( Int32 nProgramId ) {
            return dal.DelRecommend(nProgramId);

        }
        /// <summary>
        /// �����Ƽ���Ŀ
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nProgramId">The n program id.</param>
        public void AddRecommend( Int32 nUserId, Int32 nProgramId ) {
            dal.AddRecommend(nUserId, nProgramId);
        }

        public Int32 IsRecommend( Int32 nProgramId ) {
            return dal.IsRecommend(nProgramId);
        }
        #endregion

        #region   ������Ŀ
        /// <summary>
        /// ������Ŀ
        /// </summary>
        /// <param name="strKey">��������</param>
        /// <param name="nType">�������� define.eumu_program_search</param>
        /// <param name="nClass">��ǰ�û�����</param>
        /// <param name="nGroupMask">��ǰ�û�������</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <param name="nOrder">The n order.</param>
        /// <param name="nCatalogId">-1ȫ�������Ŀ��0 ��ȡδ����, > 0 �����ID��-2��ȫ����Ŀ</param>
        /// <returns></returns>
        public IList<ProgramData> Search( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,Int32 nCheck, Int32 nPage, Int32 nPageSize ,Int32 nOrder, Int32 nCatalogId) {

            return TransToViewData(dal.Search(strKey, nType, nClass, nGroupMask, nPage, nPageSize, nCheck, nOrder, nCatalogId));
            //������ check��iskind �ֶ�
        }
        // ��������δ��˽�Ŀ
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="strKey">��������</param>
        /// <param name="nType">��������</param>
        /// <param name="nClass">��ǰ�û�����</param>
        /// <param name="nGroupMask">��ǰ�û�������</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nCatalogId">-1ȫ�������Ŀ��0 ��ȡδ����, > 0 �����ID��-2��ȫ����Ŀ</param>
        /// <returns></returns>
        public Int32 SearchCount( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,Int32 nCheck,Int32 nCatalogId ) {
            return dal.SearchCount(strKey, nType, nClass, nGroupMask, nCheck,nCatalogId);        
        }

        #endregion



        /// <summary>
        /// ���ݽ�Ŀid��ȡ��ĿƬ��
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IList<ChapterData> GetChapterByProgramId( Int32 pid ) {
            IList<ChapterData> chplist = dal.GetChapterByProgramId(pid);
            IList<ChapterData> chpnewlist = new List<ChapterData>();
            System.Collections.IEnumerator myEnum = chplist.GetEnumerator();
            while (myEnum.MoveNext()) {

                ChapterData chpdta = (ChapterData)myEnum.Current;

                //chpdta.PcName = chpdta.PcName.Split(".".ToCharArray())[0];
                chpdta.nTime = BLLHelper.FormatTime(chpdta.PcDuration);
                chpdta.nKbps = BLLHelper.GetKbps(chpdta.PcSizeHigh, chpdta.PcSizeLow, chpdta.PcDuration);
                chpnewlist.Add(chpdta);
            }

            return chpnewlist;
        }

        /// <summary>
        /// ����ý���������Ϣ
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public IList<MediaServerData> GetMediaServer( Int32 nProgramId ) {
            return dal.GetMediaServer(nProgramId);
        }

        /// <summary>
        /// ȡͼ������
        /// </summary>
        /// <param name="nImgId"></param>
        /// <returns></returns>
        public ImageData GetImage( Int32 nImgId ) {
            return dal.GetImage(nImgId);
        }


        public IList<ProgramData> GetTopPlay( Int32 nCount, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTop(nCount, 1, nClass, nGroupMask);
        }
        public IList<ProgramData> GetTopNew( Int32 nCount, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTop(nCount, 0, nClass, nGroupMask);
        }

        public IList<ProgramData> GetTopNewGroupByCataLog( Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTopNewGroupByCataLog((Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, nClass, nGroupMask);
        }

        #region  ��Ŀ����
        /// <summary>
        /// ��ȡ��Ŀ���������б�
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public IList<CatalogData> GetCatalogList( Int32 nProgramId ) {
            // ��Ҫ�ݹ���� Catalog��GetDetail����ʾ�����ķ���·��
            // ��������ṹ��JSON������
            return dal.GetCatalogList(nProgramId);
        }


        public Int32 GetCatalogByProgramId( Int32 nProgramId ) {
            return dal.GetCatalogByProgramId(nProgramId);
        }

        #endregion


        #region ȡ��Ŀ�Ĳ�����ַ

        /// <summary>
        /// ȡ���ص�ַ
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nPid"></param>
        /// <param name="nMsid"></param>
        /// <param name="nPcindex">��Ŀ����ΪƬ��ID</param>
        /// <returns></returns>
        public String DownloadUrl( Int32 nUserId, Int32 nPid, Int32 nMsid, Int32 nPcindex ) {

            String strHomeServer = System.Web.HttpContext.Current.Session["HSServer"].ToString();
            String strHomePort = System.Web.HttpContext.Current.Session["HSPort"].ToString();
            System.Random rnd = new Random();
            int nRnd = Convert.ToInt32(rnd.NextDouble() * 1000);
            int nTemp1 = nRnd;
            int nTemp2 = nUserId ^ nRnd;
            int nTemp3 = nPid ^ nRnd;
            int nTemp4 = nPcindex ^ nRnd;
            int nTemp5 = nMsid ^ nRnd;

            return "ummd://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + "." + nTemp3.ToString()
                    + "." + nTemp2.ToString() + "." + nTemp5.ToString() + "." + nTemp4.ToString();

        }


        /// <summary>
        /// ȡ���ŵ�ַ
        /// </summary>
        /// <param name="nPid"></param>
        /// <param name="nMsid"></param>
        /// <param name="nPcindex">������Ϊindex</param>
        /// <param name="nMediatype"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public String PlayUrl( Int32 nUserId, Int32 nPid, Int32 nMsid, Int32 nPcindex, Int32 nMediatype ) {
            String strHomeServer = System.Web.HttpContext.Current.Session["HSServer"].ToString();
            String strHomePort = System.Web.HttpContext.Current.Session["HSPort"].ToString();

            System.Random rnd = new Random();
            int nRnd = Convert.ToInt32(rnd.NextDouble() * 1000);
            int nTemp1 = nRnd;
            int nTemp2 = nUserId ^ nRnd;
            int nTemp3 = nPid ^ nRnd;
            int nTemp4 = nPcindex ^ nRnd;
            int nTemp5 = nMsid ^ nRnd;

            if (nMediatype == (int)Define.ENUM_PROGRAM_TYPE.t_course) {
                return "ummd://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + ":" + nTemp3.ToString() + ":" + nTemp5.ToString();
            } else {
                return "ummp://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + "." + nTemp2.ToString()
               + "." + nTemp3.ToString() + "." + nTemp4.ToString() + ":" + nTemp5.ToString();
            }
        }


        /// <summary>
        /// ��Ŀ�ı༭URL 
        /// <para>1.�ϴ��ҵĿγ̣�2.��Ŀ�༭</para>
        ///</summary>
        /// <param name="nProgramId">The n program id.</param>
        /// <param name="nCourseId">COURId ��Ϊ�㣬��ʾΪ �γ̵Ľ�Ŀ</param>
        /// <returns></returns>
        public  String EditUrl(String strServer,String strPort,Int32 nUserId,Int32 nProgramId, Int32 nCourseId ) {
            return "ummu://" + strServer + ":" + strPort + "/" + nProgramId + "." + nUserId + "." + nCourseId;             
        }





        #endregion 

    }
}
