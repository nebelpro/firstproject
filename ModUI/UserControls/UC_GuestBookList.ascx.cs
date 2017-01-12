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

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_GuestBookList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nPage = this.GetIntParam("page", 1);

            BLL.GuestBook gb = new BLL.GuestBook();
            Int32 nPageCount = gb.GetCount(0);
            if (nPageCount != 0) {               
                
                String strPlayUrl = "GuestBook.aspx";
                ltrListBtm.Text = ltrListTop.Text = WebHelper.PageList(strPlayUrl, nPageCount, nPage, Helper.PAGE_GUESTBOOKLIST_SIZE);
                rptList.DataSource = gb.GetList(0, nPage, Helper.PAGE_GUESTBOOKLIST_SIZE);
                rptList.DataBind();
            } else {               
                ltrEmpty.Text = Helper.ListEmpty;
            }           
        }
    }
}