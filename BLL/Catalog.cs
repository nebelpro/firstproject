using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Catalog {

        private static readonly MOD.IDAL.ICatalog dal = MOD.DALFactory.DataAccess.CreateCatalog();

        /// <summary>
        /// 取得指定分类的所有子分类
        /// </summary>
        /// <param name="nCatalogId">父类ID</param>
        /// <param name="nCount">取指定个数的子类( 0: 全部)</param>
        /// <returns></returns>
        public IList<CatalogData> GetList( Int32 nCatalogId, Int32 nCount ) {

            return dal.GetCatalogByParentId(nCatalogId, nCount);
        }

        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="nCatalog">The n catalog.</param>
        /// <returns></returns>
        public CatalogData GetDetail( Int32 nCatalog ) {

            return dal.GetDetail(nCatalog);
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="nParentId"></param>
        /// <param name="strName">分类名称（私有目录即为登录名）</param>
        /// <returns>-3 超过32 级，-2：超过9999，-1：存在同名，1成功</returns>
        public Int32 AddCatalog( Int32 nParentId, String strName ) {
            // 1 取得父分类下子分类列表(GetList)，找出其中空余index，若无则在最大index的+1
            IList<CatalogData> catalist = dal.GetCatalogByParentId(nParentId, 0);
            //从catalist里面提取SerialIndex
            int[] nArray = new int[catalist.Count];
            for (int i = 0; i <= catalist.Count - 1; i++) {
                nArray[i] = catalist[i].CSerialIndex;
            }
            int nIndex = BLLHelper.GetIndex(nArray); //取空的index值位

            // 2 检查此index是否超过9999，超出则返回0
            if (nIndex > 9999) {
                return -2;
            }
            // 3 填充 CatalogData 
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

            //下面三个字段程序中暂未启用，设置默认值０
            catadata.CIsDefault = 0;
            catadata.CDefClass = 0;
            catadata.CDefGroup = 0;


            // 4 调用 Insert
            return dal.InsertCatalog(catadata);
        }

        /// <summary>
        /// 更新分类信息（是否需要数据的转化）
        /// </summary>
        /// <param name="catalogdata"></param>
        /// <returns></returns>
        public Int32 Update( CatalogData catalogdata ) {
            return dal.UpdateCatalog(catalogdata);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="nCatalogId"></param>
        public void Delete( Int32 nCatalogId ) {
            dal.Delete(nCatalogId);
        }


        public Int32 GetParentByCId( Int32 nCatalogId ) {
            return dal.GetParentByCId(nCatalogId);
        }


        /// <summary>
        /// 递归查找所需的子分类(06-11-13)
        /// </summary>
        /// <param name="nCatalogId">nParentId下面的一个子/孙分类.</param>
        /// <param name="nParentId">指定的父类</param>
        /// <returns></returns>
        public int GetNeedCatalog( int nCatalogId, int nParentId ) {
            //
            //?最终的没有可返回的处理
            //

            // 所需的子类parentid2，参数里面的parentid是secondCatalogid的上一级分类
            //取cid的parentid
            int nParentId2 = dal.GetParentByCId(nCatalogId);

            //如果当前的分类cid的父类是所需分类的上一级，则cid是所需的分类
            if (nParentId2 > nParentId) {
                //不是则，递归查找0
                nCatalogId = GetNeedCatalog(nParentId2, nParentId);
            } else if (nParentId2 < nParentId) {
                return -1;//返回-1的原因 ：  非nParentId 的子孙，或许 nCatalogId等于 nParentId
            }
            return nCatalogId;
            
        }

        public CatalogData GetDetailBySerial( String strSerial ) {
            return dal.GetDetailBySerial(strSerial);
        }
    }
}