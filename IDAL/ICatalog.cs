using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface ICatalog
    {

        /// <summary>
        /// ɾ�����ࡣɾ�����༰���ӷ��࣬ͨ��Serialƥ��
        /// ��������ؽ�Ŀ�������� p_iskind --
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nCatalogId);

        /// <summary>
        /// ���ݸ�����ID,��ѯ��������
        /// </summary>
        /// <param name="parentid"></param>
        /// <param name="topcount">0 ��ʾ��ѯȫ��</param>
        /// <returns></returns>
        IList<CatalogData> GetCatalogByParentId(Int32 parentid, Int32 topcount);

        /// <summary>
        /// ȡ����ĸ���
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        Int32 GetParentByCId(Int32 nCatalogId);

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        CatalogData GetDetail(Int32 nCatalogId);

        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="catadata"></param>
        /// <returns></returns>
        Int32 InsertCatalog(CatalogData catadata);

        /// <summary>
        /// ���·�����Ϣ 
        /// </summary>
        /// <param name="catadata"></param>
        /// <returns></returns>
        Int32 UpdateCatalog(CatalogData catadata);

        /// <summary>
        /// �������ж�ȡ������Ϣ
        /// </summary>
        /// <param name="strSerial"></param>
        /// <returns></returns>
        CatalogData GetDetailBySerial(String strSerial);
    }
}
