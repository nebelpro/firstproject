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

namespace MOD.UI {
    public partial class Download : MOD.WebUtility.UI.Page {
        public string strPlayUrl = "";

        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nUserId = this.GetSession("UserId", 0);
            if (nUserId == 0) {
                WebHelper.MsgBox(this.GetRes("WARN_NOLOGIN"), false, "", true);
            } else {
                
                Int32 nId = 0;
                if (WebHelper.GetRequest("id") != String.Empty)
                    nId = WebHelper.DecryptPid(WebHelper.GetRequest("id"));
                if (nId == 0) {
                    WebHelper.MsgBox(this.GetRes("ERR_PARAMS"), false, "", true);
                }                
                if ((new Permit()).CanDownMedia())
                    strPlayUrl = Server.UrlDecode(WebHelper.GetRequest("url"));
                else {
                    WebHelper.MsgBox(this.GetRes("WARING_NODOWNPERMIT"), false, "", true);
                }


            }
        }

       
    }
}
