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

namespace MOD.WebTd.UserControls {
    public partial class UC_ProgramSearchList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = "";
            Int32 nPageSize = 21;
            string strkey = Server.UrlDecode(WebHelper.GetRequest("key"));            
            Int32 nFindKey = this.GetIntParam("fkey",(Int32)Define.ENUM_PROGRAM_SEARCH.ALL);
            Int32 nPage = this.GetIntParam("page",1);

            Int32 nCount = (new BLL.Program()).SearchCount(strkey, nFindKey,this.GroupClass, this.GroupMask,(Int32) Define.ENUM_PROGRAM_PROPERTY.p_check_pass,this.DefaultCatalog);
            if (nCount != 0) {
                lbPage_Top.Text = lbPage_Bottom.Text = WebHelper.PageList("SearchResult.aspx?key=" + Server.UrlEncode(strkey) + "&fkey=" + nFindKey, nCount, nPage, nPageSize);

                IList<ProgramData> pdList = (new BLL.Program()).Search(strkey, nFindKey, this.GroupClass, this.GroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,
                    nPage, nPageSize,(Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC,this.DefaultCatalog);
                if (pdList != null && pdList.Count != 0) {
                    rptPrmList.DataSource = pdList;
                    rptPrmList.DataBind();
                }
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }
    }
}