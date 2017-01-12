using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls
{
    public partial class UC_ProgramList : MOD.WebUtility.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e ) {

            String strUrlFormat = "<a href=\"ViewByClass.aspx?cid={0}\">{1}</a>";

            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);
            Catalog CataBll = new Catalog();
            if (nCatalogId != this.DefaultCatalog) {
                if (CataBll.GetNeedCatalog(nCatalogId, this.DefaultCatalog) == -1) {
                    nCatalogId = this.DefaultCatalog;
                }
            }

           
            CatalogData cata = (new Catalog()).GetDetail(nCatalogId);
            if (cata != null) {             
                ltrCatalogName.Text = ProgramHelper.GetCatalogStepByCId(nCatalogId, strUrlFormat);                
                this.Page.Title = cata.CName;
            } else {
                Response.Redirect("Default.aspx");
            }

            Int32 nPage = this.GetIntParam("page", 1);
            Program prmbll = new Program();           
            Int32 nSort = this.GetIntParam("sort", 6);
            Int32 nPrmCount = prmbll.GetCount(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask);

            if (nPrmCount != 0) {

                Int32 nViewModel = this.GetSession(SETTING_TYPE.KEY_VIEWMODEL, 1);
                Int32 nPageSize;
                Repeater rptList = new Repeater();
                if (nViewModel == 2) {//列表模式
                    nPageSize = Helper.PAGE_PROGRAMLIST_TWO_SIZE;
                    rptList = rptProgramList2;
                } else {//默认 详细模式
                    nPageSize = Helper.PAGE_PROGRAMLIST_ONE_SIZE;
                    rptList = rptCataloglist;
                }


                string strOrder = Helper.GetOrderInfo(nSort, nCatalogId);
                string strPageUrl = WebHelper.GetShowUrl() + "?cid=" + nCatalogId.ToString() + "&sort=" + nSort;
                ltrListTop.Text = String.Format(Helper.ListBar, strOrder, WebHelper.PageList(strPageUrl, nPrmCount, nPage,nPageSize,5));
                rptList.DataSource = prmbll.GetList(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, nPage, nPageSize, nSort);
                rptList.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }


       
    }
}