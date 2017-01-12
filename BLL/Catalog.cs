using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Catalog {

        private static readonly MOD.IDAL.ICatalog dal = MOD.DALFactory.DataAccess.CreateCatalog();

        /// <summary>
        /// ȡ��ָ������������ӷ���
        /// </summary>
        /// <param name="nCatalogId">����ID</param>
        /// <param name="nCount">ȡָ������������( 0: ȫ��)</param>
        /// <returns></returns>
        public IList<CatalogData> GetList( Int32 nCatalogId, Int32 nCount ) {

            return dal.GetCatalogByParentId(nCatalogId, nCount);
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="nCatalog">The n catalog.</param>
        /// <returns></returns>
        public CatalogData GetDetail( Int32 nCatalog ) {

            return dal.GetDetail(nCatalog);
        }

        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="nParentId"></param>
        /// <param name="strName">�������ƣ�˽��Ŀ¼��Ϊ��¼����</param>
        /// <returns>-3 ����32 ����-2������9999��-1������ͬ����1�ɹ�</returns>
        public Int32 AddCatalog( Int32 nParentId, String strName ) {
            // 1 ȡ�ø��������ӷ����б�(GetList)���ҳ����п���index�������������index��+1
            IList<CatalogData> catalist = dal.GetCatalogByParentId(nParentId, 0);
            //��catalist������ȡSerialIndex
            int[] nArray = new int[catalist.Count];
            for (int i = 0; i <= catalist.Count - 1; i++) {
                nArray[i] = catalist[i].CSerialIndex;
            }
            int nIndex = BLLHelper.GetIndex(nArray); //ȡ�յ�indexֵλ

            // 2 ����index�Ƿ񳬹�9999�������򷵻�0
            if (nIndex > 9999) {
                return -2;
            }
            // 3 ��� CatalogData 
            String strParentSerial = (nParentId == 0) ? string.Empty : GetDetail(nParentId).CSerial;
            if (strParentSerial.Length >= 128) {
                return -3;
            }
            CatalogData catadata = new CatalogData();
            catadata.CSerialIndex = nIndex;
            catadata.CName = strName;

            string strCurIndex = nIndex.ToString();
            Int32 nLength = strCurIndex.Length;
            for (int m = 0; m < 4 - nLength; m++) {
                strCurIndex = "0" + strCurIndex;
            }
            catadata.CSerial = strParentSerial + strCurIndex;
            catadata.CParentId = nParentId;

            //���������ֶγ�������δ���ã�����Ĭ��ֵ��
            catadata.CIsDefault = 0;
            catadata.CDefClass = 0;
            catadata.CDefGroup = 0;


            // 4 ���� Insert
            return dal.InsertCatalog(catadata);
        }

        /// <summary>
        /// ���·�����Ϣ���Ƿ���Ҫ���ݵ�ת����
        /// </summary>
        /// <param name="catalogdata"></param>
        /// <returns></returns>
        public Int32 Update( CatalogData catalogdata ) {
            return dal.UpdateCatalog(catalogdata);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="nCatalogId"></param>
        public void Delete( Int32 nCatalogId ) {
            dal.Delete(nCatalogId);
        }


        public Int32 GetParentByCId( Int32 nCatalogId ) {
            return dal.GetParentByCId(nCatalogId);
        }


        /// <summary>
        /// �ݹ����������ӷ���(06-11-13)
        /// </summary>
        /// <param name="nCatalogId">nParentId�����һ����/�����.</param>
        /// <param name="nParentId">ָ���ĸ���</param>
        /// <returns></returns>
        public int GetNeedCatalog( int nCatalogId, int nParentId ) {
            //
            //?���յ�û�пɷ��صĴ���
            //

            // ���������parentid2�����������parentid��secondCatalogid����һ������
            //ȡcid��parentid
            int nParentId2 = dal.GetParentByCId(nCatalogId);

            //�����ǰ�ķ���cid�ĸ���������������һ������cid������ķ���
            if (nParentId2 > nParentId) {
                //�����򣬵ݹ����0
                nCatalogId = GetNeedCatalog(nParentId2, nParentId);
            } else if (nParentId2 < nParentId) {
                return -1;//����-1��ԭ�� ��  ��nParentId ��������� nCatalogId���� nParentId
            }
            return nCatalogId;
            
        }

        public CatalogData GetDetailBySerial( String strSerial ) {
            return dal.GetDetailBySerial(strSerial);
        }
    }
}