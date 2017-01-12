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
    public partial class UC_ProgramSearch : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void btnSearch_Click( object sender, ImageClickEventArgs e ) {
            String strKey = WebHelper.InputText(tbKey.Text);
            Response.Redirect("SearchResult.aspx?key=" + Server.UrlEncode(strKey));
           

        }

    }
}