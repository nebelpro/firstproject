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

namespace MOD.UI {
    public partial class GuestBook : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            string oper = this.GetStringParam("oper","");
            if (string.IsNullOrEmpty(oper)) {
                Control uc = (Control)this.LoadControl("UserControls/UC_GuestBookList.ascx");
                this.phdGuest.Controls.Add(uc);
            } else {
                Control uc = (Control)this.LoadControl("UserControls/UC_GuestBookAdd.ascx");
                this.phdGuest.Controls.Add(uc);
            }
            this.Page.Title = this.GetRes("Info_UserCenter");
        }
    }
}
