using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL
{
   public interface IBulletin
    {

        /// <summary>
        /// ��ҳ��ȡ������Ϣ��Ĭ�ϰ�ʱ������
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<BulletinData> GetList(Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// ȡ�ù�������
        /// </summary>
        /// <returns></returns>
        Int32 GetCount();

        /// <summary>
        /// ����IDɾ��һ������
        /// </summary>
        /// <param name="bid"></param>
        int Delete(int bid);

        /// <summary>
        /// ����IDȡ��������
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        BulletinData GetBulletinByBid(int bid);

        /// <summary>
        /// ����ID���¹�����Ϣ
        /// </summary>
        /// <param name="bda">���µ�����ʵ��</param>
        int Update(BulletinData bda);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="bda"></param>
        int Insert(BulletinData bda);

   
    }
}
