using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IRemark
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="remarkdata"></param>
        /// <returns></returns>
        Int32 Insert(RemarkData remarkdata);

        /// <summary>
        /// ��������״̬
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <param name="nState">0 δͨ����1ͨ�����</param>
        /// <returns></returns>
        Int32 UpdateState(Int32 nRemarkId, Int32 nState);

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nRemarkId);

        /// <summary>
        /// ɾ����Ŀ����������,�˷�����ɾ����Ŀʱ����
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        Int32 DeleteByProgram(Int32 nProgramId);

        /// <summary>
        /// ��ȡָ����Ŀ���� ��ҳ�б�
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<RemarkData> GetListByProgram(Int32 nProgramId,Int32 nState,Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ��ȡָ����Ŀ��������
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <returns></returns>
        Int32 GetCountByProgram(Int32 nProgramId,Int32 nState);

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <returns></returns>
        IList<RemarkData> GetList(Int32 nPage, Int32 nPageSize,Int32 nState);

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <returns></returns>
        Int32 GetCount(Int32 nState);

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <returns></returns>
        RemarkData GetDetail(Int32 nRemarkId);
    }
}
