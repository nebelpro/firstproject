using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.Model;
using MOD.BLL;
using MOD.WebUtility;

namespace mentougou.UserControl {
    public partial class UC_CatalogMix : MOD.WebUtility.UI.UserControl {
       

        private int nParentId = 21;
        public String ParentId {
            set { nParentId = Convert.ToInt32(value); }
            get { return nParentId.ToString(); }
        }
        public String TitlePic {
            set { TitleImage.ImageUrl = "~/" + value; }
        }
        public String CatalogPic {
            set { CatalogImage.ImageUrl = "~/" + value; }
        }


        protected void Page_Load( object sender, EventArgs e ) {
           
            //=================
            IList<CatalogData> subList = (new Catalog()).GetList(nParentId, 6);
            rptCatalog.DataSource = subList;
            rptCatalog.DataBind();
            //===========================
        }

        protected void rptCatalog_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Repeater rptProgram = (Repeater)e.Item.FindControl("rptSubProgram");
                Repeater rptCatalog = (Repeater)e.Item.FindControl("rptCatalogList");
                //找到分类Repeater关联的数据项 
                CatalogData catalog = (CatalogData)e.Item.DataItem;
                //提取分类ID 
                int catalogId = Convert.ToInt32(catalog.CId);
                //根据分类ID查询该分类下的产品，并绑定产品Repeater 
                rptProgram.DataSource = GetDataList(catalogId);// GetDataSource(catalogId);//(new Program()).GetList(catalogId, 1, this.GroupClass, this.GroupMask, 1, 2, (int)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);           //GetDataSource(catalogId);
                rptProgram.DataBind();
                IList<CatalogData> subList = (new Catalog()).GetList(catalog.CId, 0);
                if (subList.Count != 0) {
                    rptCatalog.DataSource = subList;
                    rptCatalog.DataBind();
                }
            }
        }

        #region
        protected IList<ProgramData> GetDataList( Int32 nCatalogId ) {
            //滚动了多少格子
            Setting STbll = new Setting();
            Int32 nCount = int.Parse(STbll.GetValue("count", "0"));
           
            IList<ProgramData> retList = new List<ProgramData>();
            Int32 TpCount = (new Program()).GetCount(nCatalogId, 1, this.GroupClass, this.GroupMask);
            if (TpCount != 0) {
                IList<ProgramData> pdaList = (new Program()).GetList(nCatalogId, 1, this.GroupClass, this.GroupMask,1, TpCount, (int)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
                //nCount ==0 第一次加载， 或者到了滚动的时间（目前时间减去上次滚动时间大于间隔）
                //首页现在是一个子类下放两个节目
                ProgramData[] pArray = new ProgramData[pdaList.Count * 2];
                pdaList.CopyTo(pArray,0);
                pdaList.CopyTo(pArray, pdaList.Count);
                Int32 nStep = nCount % TpCount;
                retList.Add(pArray[nStep]);
                retList.Add(pArray[nStep + 1]);
               
            }

            return retList;

        }
        #endregion








    }
}