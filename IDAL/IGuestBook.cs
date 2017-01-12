using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IGuestBook
    {
        
        /// <summary>
        /// 取得留言列表
        /// </summary>
        /// <param name="nType">留言类型0 公开，1全部(包括公开和私有)</param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<GuestBookData> GetList(Int32 nType, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 取得留言总数
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nType);

        /// <summary>
        /// 取得留言信息
        /// </summary>
        /// <param name="nGuestbookId"></param>
        /// <returns></returns>
        GuestBookData GetDetail(Int32 nGuestbookId);

        /// <summary>
        /// 插入新留言
        /// </summary>
        /// <param name="guestbookdata"></param>
        /// <returns></returns>
        Int32 Insert(GuestBookData guestbookdata);

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="nGuestbookId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nGuestbookId);

    }

}
