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

namespace MOD.UI.UserControls {
    public partial class UC_ProgramSearch : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {

        }
        protected void ibtnSearch_Click( object sender, EventArgs e ) {

           String strKey = tbKey.Text.Trim();
           Response.Redirect("SearchResult.aspx?key=" + Server.UrlEncode(strKey));
            
           
        }
    }
}