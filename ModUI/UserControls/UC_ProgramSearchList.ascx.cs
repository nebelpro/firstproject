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

namespace MOD.UI.UserControls {
    public partial class UC_ProgramSearchList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("INFO_SEARCH_RESULT"); 
            string strKey = this.GetStringParam("key","");

            if (strKey == null || strKey.Trim() == string.Empty) {
                ltrSearchKey.Text = this.GetRes("INFO_SEARCH_ALL");
            } else {
                ltrSearchKey.Text = this.GetRes("INFO_SEARCH_KEY") + strKey;
            }

            Int32 nPage = this.GetIntParam("page", 1);            
            Program prmbll = new Program();
            Int32 nPrmCount = prmbll.SearchCount(strKey, 6, this.GroupClass, this.GroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,this.DefaultCatalog);           
            if (nPrmCount != 0) {
                Int32 nViewModel = this.GetSession(SETTING_TYPE.KEY_VIEWMODEL, 1);
                Int32 nPageSize;
                Repeater rptList = new Repeater();
                if (nViewModel == 2) {//列表模式
                    nPageSize = Helper.PAGE_PROGRAMLIST_TWO_SIZE;
                    rptList = rptProgramList2;
                } else {//默认 详细模式
                    nPageSize = Helper.PAGE_PROGRAMLIST_ONE_SIZE;
                    rptList = rptResultlist;
                }



                string strPageUrl = WebHelper.GetShowUrl() + "?key=" + strKey;
                ltrListTop.Text = String.Format(Helper.ListBar, "", WebHelper.PageList(strPageUrl, nPrmCount, nPage, nPageSize, 5));
                rptList.DataSource = prmbll.Search(strKey, 6, this.GroupClass, this.GroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,
                    nPage, nPageSize,(Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC,this.DefaultCatalog);
                rptList.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }
    }
}