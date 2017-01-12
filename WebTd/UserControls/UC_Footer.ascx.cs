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

namespace MOD.WebTd.UserControls {
    public partial class UC_Footer : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            ltCopy.Text = "&copy; 2006 ";
            if (DateTime.Now.Year > 2006) {
                ltCopy.Text += "- " + DateTime.Now.Year + " ";
            }
            String strWebLink = Res.GetCompanyWebSite();
            String strWebName = Res.GetCompanyName();
            if (strWebLink != "" && strWebName != "") {
                ltCopy.Text += "<a href=\"" + strWebLink + "\" target=\"_blank\">" + strWebName + "</a> ";
            } else if (strWebLink == "" && strWebName != "") {
                ltCopy.Text += strWebName + " ";
            }
            ltCopy.Text += " " + Res.GetValue("Info_SaveAllRights");
        }
    }
}