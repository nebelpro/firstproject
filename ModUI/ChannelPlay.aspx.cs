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
    public partial class ChannelPlay : MOD.WebUtility.UI.Page {
        public string strPlayUrl = "";

        protected void Page_Load( object sender, EventArgs e ) {

            if (this.UserID == 0) {
                WebHelper.MsgBox(this.GetRes("WARN_NOLOGIN"), false, "", true);
            } else {
                //检测id
                Int32 nId = 0;
                if (WebHelper.GetRequest("id") != String.Empty)
                    nId = WebHelper.DecryptPid(WebHelper.GetRequest("id"));
                if (nId == 0) {
                    WebHelper.MsgBox(this.GetRes("ERR_PARAMS"), false, "", true);
                }
                String strUrl = WebHelper.GetRequest("url");
                // 频道播放
                Int32 nAddressId = 0;
                Int32 nIndex = 1;// :XX:,有效索引是1
                String strAddressId = WebHelper.GetRequest("addressid");
                String strIndex = WebHelper.GetRequest("index");

                if (strAddressId != String.Empty)
                    nAddressId = Int32.Parse(strAddressId);
                if (strIndex != String.Empty)
                    nIndex = Int32.Parse(strIndex);

                String strRet = "";
                strPlayUrl = ChannelHelper.MakeLocalUrl(nId, nAddressId, nIndex, this.UserID, this.GroupMask, out strRet);
                if (strRet != "") {
                    WebHelper.MsgBox(strRet, false, "", true);
                }
              
            }
        }
            
    }
}
