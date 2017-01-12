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

namespace mentougou {
    public partial class SearchResult : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
             this.Page.Title = this.GetRes("Info_SearchResult");
            String strKey=this.GetStringParam("key","");
            if (strKey == "") {
                this.Master.CurPath = " / " + this.GetRes("Info_ProgramAll");
            } else {
                this.Master.CurPath = " / " + this.GetRes("Info_SearchResult")
                        + " - " + String.Format(this.GetRes("Info_SearchKey"), strKey);
            }
        }
    }
}
