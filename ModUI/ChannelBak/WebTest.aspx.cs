using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
    public partial class WebTest : MOD.WebUtility.UI.Page {
        public string strParam = "";

        protected void Page_Load( object sender, EventArgs e ) {
            IList<ChannelData> ChaList = (new Channel()).GetList(1, this.GetSession("GroupMask", 0), 1, 10);
            if (ChaList.Count != 0) {
                ChannelData cha = (ChannelData)ChaList[0];
                strParam = ChannelHelper.GetCastUI(cha.CId, 0);
                ltrCastPlay.Text = "<li><a href=\"javascript://\" onclick=\"CastPlay(" + cha.CId + ");\">Play</a></li>";
            } else {
                strParam = "-1";
            }
        }
    }
}
