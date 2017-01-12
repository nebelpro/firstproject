using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface ICatalog
    {

        /// <summary>
        /// 删除分类。删除分类及其子分类，通过Serial匹配
        /// 并更改相关节目分类属性 p_iskind --
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nCatalogId);

        /// <summary>
        /// 根据父分类ID,查询所有子类
        /// </summary>
        /// <param name="parentid"></param>
        /// <param name="topcount">0 表示查询全部</param>
        /// <returns></returns>
        IList<CatalogData> GetCatalogByParentId(Int32 parentid, Int32 topcount);

        /// <summary>
        /// 取子类的父类
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        Int32 GetParentByCId(Int32 nCatalogId);

        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="nCatalogId"></param>
        /// <returns></returns>
        CatalogData GetDetail(Int32 nCatalogId);

        /// <summary>
        /// 插入目录
        /// </summary>
        /// <param name="catadata"></param>
        /// <returns></returns>
        Int32 InsertCatalog(CatalogData catadata);

        /// <summary>
        /// 更新分类信息 
        /// </summary>
        /// <param name="catadata"></param>
        /// <returns></returns>
        Int32 UpdateCatalog(CatalogData catadata);

        /// <summary>
        /// 根据序列读取分类信息
        /// </summary>
        /// <param name="strSerial"></param>
        /// <returns></returns>
        CatalogData GetDetailBySerial(String strSerial);
    }
}
