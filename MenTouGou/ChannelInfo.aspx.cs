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
    public partial class ChannelInfo : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Title = this.GetRes("Info_ChannelInfo");
            this.Master.CurPath = " / <a href=\"ChannelList.aspx?type=-1\">" + this.GetRes("Info_ChannelList") + "</a> / " + this.GetRes("Info_ChannelInfo");
        }
    }
}
