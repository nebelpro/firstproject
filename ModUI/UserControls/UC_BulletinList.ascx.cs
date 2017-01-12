using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.WebUtility;
using MOD.BLL;
using MOD.Model;

namespace MOD.UI.UserControls {
    public partial class UC_BulletinList : MOD.WebUtility.UI.UserControl {
        protected void Page_Init( object sender, EventArgs e ) {
            ltrTip.Text = this.GetRes("INFO_BULLETIN_LIST");
            this.Page.Title = this.GetRes("INFO_BULLETIN_LIST");  
        }
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nPage = this.GetIntParam("page", 1);
            Bulletin bl = new Bulletin();
            Int32 nPageCount = bl.GetCount();
            if (nPageCount != 0) {
                ltrListTop.Text = string.Format(Helper.ListBar, "", WebHelper.PageList("BulletinList.aspx", nPageCount, nPage, Helper.PAGE_BULLETIN_SIZE,8));
                rptBullist.DataSource = bl.GetList(nPage, Helper.PAGE_BULLETIN_SIZE);
                rptBullist.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }
    }
}