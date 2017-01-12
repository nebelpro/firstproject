using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IGroup {

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="groupdata"></param>
        /// <returns></returns>
        Int32 Insert(GroupData groupdata);


        /// <summary>
        /// ��ȡ�����Ϣ
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns></returns>
        GroupData GetDetailById(Int32 gid);

        /// <summary>
        /// ��������Ϣ
        /// </summary>
        /// <param name="groupdata"></param>
        /// <returns></returns>
        Int32 Update(GroupData groupdata);

        /// <summary>
        /// ɾ����,�����¸����û���������(�ڴ洢���̴���)
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nGroupId);

        /// <summary>
        /// �����û�Ȩ��ֵ����ȡ�û��������ڶ����
        /// </summary>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        IList<GroupData> GetGroupByUserGroupMask(Int32 nGroupMask);

        /// <summary>
        /// ��ҳ��ȡ���б�
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<GroupData> GetList(Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        Int32 GetCount();    
    }
}
