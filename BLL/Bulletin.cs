using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Bulletin {

        private static readonly MOD.IDAL.IBulletin dal = MOD.DALFactory.DataAccess.CreateBulletin();


        /// <summary>
        /// ��ҳ��ȡ������Ϣ��Ĭ�ϰ�ʱ������
        /// </summary>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        public IList<BulletinData> GetList( Int32 nPage, Int32 nPageSize ) {
            return dal.GetList(nPage, nPageSize);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public Int32 GetCount() {
            return dal.GetCount();
        }

        /// <summary>
        /// ����IDɾ��һ������
        /// </summary>
        /// <param name="bid">The bid.</param>
        public void Delete( int bid ) {
            dal.Delete(bid);
        }

        /// <summary>
        /// ����ID��ȡ��������
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns></returns>
        public BulletinData GetBulletinByBid( int bid ) {
            return dal.GetBulletinByBid(bid);
        }

        /// <summary>
        /// ����ID���¹�������
        /// </summary>
        /// <param name="bda">The bda.</param>
        /// <returns></returns>
        public int Update( BulletinData bda ) {
            return dal.Update(bda);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="bda">The bda.</param>
        /// <returns></returns>
        public int Insert( BulletinData bda ) {
            return dal.Insert(bda);
        }
    }
}