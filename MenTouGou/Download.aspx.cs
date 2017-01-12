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

namespace mentougou {
    public partial class Download : MOD.WebUtility.UI.Page {
        public string strPlayUrl = "";
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nUserId = WebHelper.GetSession("UserId", 0);
            if (nUserId == 0) {
                WebHelper.MsgBox(Res.GetValue("WARING_NOLOGIN"), false, "", true);
            } else {
                //检测节目/频道id，如果ID参数出错，则关闭窗口
                Int32 nId = 0;
                if (WebHelper.GetRequest("id") != String.Empty)
                    nId = WebHelper.DecryptPid(WebHelper.GetRequest("id"));
                if (nId == 0) {
                    WebHelper.MsgBox(Res.GetValue("ERR_PARAMS"), false, "", true);
                }

                 ProgramDownload( WebHelper.GetRequest("url"));
               
            }
        }



       
       
        private void ProgramDownload( String strUrl ) {
            if ((new Permit()).CanDownMedia())
                strPlayUrl = Server.UrlDecode(strUrl);
            else {
                WebHelper.MsgBox(this.GetRes("WARING_NODOWNPERMIT"), false, "", true);
            }
        }
    }
}
