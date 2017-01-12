using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface IProgram
    {

        /// <summary>
        /// �������ҳ��ȡ��Ŀ�б�
        /// </summary>
        /// <param name="nCatalogId">Ϊ0ʱ��ȡδ�����Ŀ�б�</param>
        /// <param name="nCheck">��Ŀ״̬</param>
        /// <param name="nClass">��ǰ�û�����</param>
        /// <param name="nGroupMask">��ǰ�û���Ȩ��</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nOrder">����ʽ0 ����ʱ�� 1��Ŀ���� 2�㲥���� ������</param>
        /// <returns></returns>
        IList<ProgramData> GetList(Int32 nCatalogId, Int32 nCheck,Int32 nClass,Int32 nGroupMask,Int32 nPage, Int32 nPageSize,Int32 nOrder);

        /// <summary>
        /// ��ȡ�����Ŀ����
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <param name="nCheck"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nCatalogId, Int32 nCheck,Int32 nClass,Int32 nGroupMask);

        /// <summary>
        /// ��ȡ�γ̽�Ŀ�б�
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetListByCourse(Int32 nCourseId, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ȡ�ÿγ̽�Ŀ����
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        Int32 GetCountByCourse(Int32 nCourseId);

        /// <summary>
        /// ȡ�ý�Ŀ����
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        ProgramData GetDetail(Int32 nProgramId);

        Int32 Delete(Int32 nProgramId);


        /// <summary>
        ///  �޸Ŀ��ĵ���ֵ
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pointvalue"></param>
        /// <returns></returns>
        Int32 UpdateProgramPoint(Int32 pid, Int32 pointvalue);

        Int32 UpdateProgramCheck(Int32 nPId, Int32 nCheck);
        
        /// <summary>
        /// ȡ�ø����ղؽ�Ŀ������ҳ��ʾ
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetFavList(Int32 nUserId, Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ȡ�ø����ղؽ�Ŀ����
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetFavCount(Int32 nUserId, Int32 nClass, Int32 nGroupMask);

        /// <summary>
        /// ɾ���ղ�
        /// </summary>
        /// <param name="nMarkId"></param>
        /// <returns></returns>
        Int32 DelFav(Int32 nMarkId);

        Int32 AddFav(Int32 nUserId, Int32 nProgramId);

        /// <summary>
        /// ��ȡ�Ƽ���Ŀ
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<ProgramData> GetRecommendList(Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ��ȡ�Ƽ���Ŀ����
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        Int32 GetRecommendCount(Int32 nClass, Int32 nGroupMask);

        /// <summary>
        /// ɾ���Ƽ�
        /// </summary>
        /// <param name="nRecommendId"></param>
        /// <returns></returns>
        Int32 DelRecommend(Int32 nProgramId);

        Int32 AddRecommend(Int32 nUserId, Int32 nProgramId);


        Int32 IsRecommend(Int32 nProgramId);

        /// <summary>
        /// ������Ŀ
        /// </summary>
        /// <param name="strKey">��������</param>
        /// <param name="nType">�������� 0 ���� 1 ��� 2 ���� 3 ���� 4 ���浥λ 5 ������ 6 All</param>
        /// <param name="nClass">��ǰ�û�����</param>
        /// <param name="nGroupMask">��ǰ�û�������</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>       
        IList<ProgramData> Search( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize, Int32 nCheck, Int32 nOrder, Int32 nCatalogId );

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="strKey">��������</param>
        /// <param name="nType">�������� 0 ���� 1 ��� 2 ���� 3 ���� 4 ���浥λ 5 ������ 6 All</param>
        /// <param name="nClass">��ǰ�û�����</param>
        /// <param name="nGroupMask">��ǰ�û�������</param>
        /// <returns></returns>        
        Int32 SearchCount( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask, Int32 nCheck, Int32 nCatalogId );


        /// <summary>
        /// ���½�Ŀ�ĵ㲥���� 
        /// </summary>
        /// <param name="nPid"></param>
        /// <returns></returns>
        Int32 UpdateReadCount(Int32 nPid);
     

        /// <summary>
        /// ���ݽ�Ŀid��ȡ��ĿƬ��
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        IList<ChapterData> GetChapterByProgramId(int pid);

        /// <summary>
        /// ����ý���������Ϣ
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        IList<MediaServerData> GetMediaServer( Int32 nProgramId );


        /// <summary>
        /// ȡͼ������
        /// </summary>
        /// <param name="nImgId"></param>
        /// <returns></returns>
        ImageData GetImage(Int32 nImgId);

        /// <summary>
        /// ��ȡ��Ŀ���������б�
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        IList<CatalogData> GetCatalogList(Int32 nProgramId);

        Int32 GetCatalogByProgramId(Int32 nProgramId);

        IList<ProgramData> GetTop(Int32 nCount,Int32 nType,Int32 nClass,Int32 nGroupMask);

        IList<ProgramData> GetTopNewGroupByCataLog(Int32 nCheck, Int32 nClass, Int32 nGroupMask);
    
    }
}
