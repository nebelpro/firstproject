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
using MOD.Model;
using MOD.BLL;
using MOD.WebUtility;
namespace MOD.WebTd {
    public partial class Recorder : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("INFO_RECORDER");
            this.Master.Logo = "Images/depend/recorder_logo.gif";
            this.Master.CastSort = 0;


            (new Helper()).BindChannelRpt((Int32)Define.CHANNEL_SHOW.LIVE, rptLive);
            (new Helper()).BindChannelRpt((Int32)Define.CHANNEL_SHOW.MIXC, rptMix);

        }
    }
}
