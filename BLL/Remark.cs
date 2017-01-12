using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Remark {

        private static readonly MOD.IDAL.IRemark dal = MOD.DALFactory.DataAccess.CreateRemark();

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="remarkdata">The remarkdata.</param>
        /// <returns></returns>
        public Int32 Insert( RemarkData remarkdata ) {

            return dal.Insert(remarkdata);
        }

        /// <summary>
        /// ��������״̬
        /// </summary>
        /// <param name="nRemarkId"></param>
        /// <param name="nState">0 δͨ����1ͨ�����</param>
        /// <returns></returns>
        public void UpdateState( Int32 nRemarkId, Int32 nState ) {
            dal.UpdateState(nRemarkId, nState);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="nRemarkId">The n remark id.</param>
        public void Delete( Int32 nRemarkId ) {
            dal.Delete(nRemarkId);
        }

        /// <summary>
        /// ɾ����Ŀ����������,�˷�����ɾ����Ŀʱ����
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public void DeleteByProgram( Int32 nProgramId ) {
            dal.DeleteByProgram(nProgramId);
        }

        /// <summary>
        /// ��ȡָ����Ŀ���� ��ҳ�б�
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<RemarkData> GetListByProgram( Int32 nProgramId, Int32 nState, Int32 nPage, Int32 nPageSize ) {
            return dal.GetListByProgram(nProgramId, nState, nPage, nPageSize);
        }

        /// <summary>
        /// ��ȡָ����Ŀ��������
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <param name="nState">0 δ��ˣ�1�����</param>
        /// <returns></returns>
        public Int32 GetCountByProgram( Int32 nProgramId, Int32 nState ) {
            return dal.GetCountByProgram(nProgramId, nState);
        }

        /// <summary>
        /// ��ȡ��������(��̨ͳһ���)
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nState">0 δ��ˣ�1����� -1ȫ��</param>
        /// <returns></returns>
        public IList<RemarkData> GetList( Int32 nPage, Int32 nPageSize, Int32 nState ) {
            return dal.GetList(nPage, nPageSize, nState);
        }

        /// <summary>
        /// ��ȡ��������.
        /// </summary>
        /// <param name="nState">State(0:δ��� 1:���  -1ȫ��)</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nState ) {
            return dal.GetCount(nState);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="nRemarkId">The n remark id.</param>
        /// <returns></returns>
        public RemarkData GetDetail( Int32 nRemarkId ) {
            return dal.GetDetail(nRemarkId);
        }
    }
}
