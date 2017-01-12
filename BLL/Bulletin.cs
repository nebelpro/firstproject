using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Bulletin {

        private static readonly MOD.IDAL.IBulletin dal = MOD.DALFactory.DataAccess.CreateBulletin();


        /// <summary>
        /// 分页读取公告信息（默认按时间排序）
        /// </summary>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        public IList<BulletinData> GetList( Int32 nPage, Int32 nPageSize ) {
            return dal.GetList(nPage, nPageSize);
        }

        /// <summary>
        /// 获取公告总数
        /// </summary>
        /// <returns></returns>
        public Int32 GetCount() {
            return dal.GetCount();
        }

        /// <summary>
        /// 根据ID删除一条公告
        /// </summary>
        /// <param name="bid">The bid.</param>
        public void Delete( int bid ) {
            dal.Delete(bid);
        }

        /// <summary>
        /// 根据ID获取公告数据
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        public BulletinData GetBulletinByBid( int bid ) {
            return dal.GetBulletinByBid(bid);
        }

        /// <summary>
        /// 根据ID更新公告数据
        /// </summary>
        /// <param name="bda">The bda.</param>
        /// <returns></returns>
        public int Update( BulletinData bda ) {
            return dal.Update(bda);
        }

        /// <summary>
        /// 插入一条公告
        /// </summary>
        /// <param name="bda">The bda.</param>
        /// <returns></returns>
        public int Insert( BulletinData bda ) {
            return dal.Insert(bda);
        }
    }
}