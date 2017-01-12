using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL
{
   public interface IBulletin
    {

        /// <summary>
        /// 分页读取公告信息，默认按时间排序
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<BulletinData> GetList(Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 取得公告总数
        /// </summary>
        /// <returns></returns>
        Int32 GetCount();

        /// <summary>
        /// 根据ID删除一条公告
        /// </summary>
        /// <param name="bid"></param>
        int Delete(int bid);

        /// <summary>
        /// 根据ID取公告数据
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        BulletinData GetBulletinByBid(int bid);

        /// <summary>
        /// 根据ID更新公告信息
        /// </summary>
        /// <param name="bda">更新的数据实体</param>
        int Update(BulletinData bda);

        /// <summary>
        /// 插入一条公告
        /// </summary>
        /// <param name="bda"></param>
        int Insert(BulletinData bda);

   
    }
}
