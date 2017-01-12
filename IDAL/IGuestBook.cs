using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IGuestBook
    {
        
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <param name="nType">��������0 ������1ȫ��(����������˽��)</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<GuestBookData> GetList(Int32 nType, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ȡ����������
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nType);

        /// <summary>
        /// ȡ��������Ϣ
        /// </summary>
        /// <param name="nGuestbookId"></param>
        /// <returns></returns>
        GuestBookData GetDetail(Int32 nGuestbookId);

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="guestbookdata"></param>
        /// <returns></returns>
        Int32 Insert(GuestBookData guestbookdata);

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="nGuestbookId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nGuestbookId);

    }

}
