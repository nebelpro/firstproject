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

using MOD.Model;
using MOD.BLL;
using MOD.WebUtility;

namespace MOD.UI {
    public partial class IpTV : MOD.WebUtility.UI.Page {
        protected void Page_Init( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("INFO_IPTV");
        }

        protected void Page_Load( object sender, EventArgs e ) {

            this.Master.Logo = "Images/depend/iptv_logo.gif";
            this.Master.CastSort = 1;
      
            if (this.GetSession("UserId", 0) == 0)
                Response.Redirect("Default.aspx");
            ltrTip.Text = this.GetRes("INFO_IpTVTitle");

            Int32 nType = this.GetIntParam("type", (int)Define.CHANNEL_SHOW.BROAD);

            string cssTptv = (nType == (int)Define.CHANNEL_SHOW.IPTV) ? "style=\"font-weight:bold;color:#000;\"" : "";
            string cssBroad = (nType == (int)Define.CHANNEL_SHOW.BROAD) ? "style=\"font-weight:bold;color:#000;\"" : "";
            
            ltrIptv.Text="<a "+cssTptv+" href=\"IpTV.aspx?type="+(int)Define.CHANNEL_SHOW.IPTV+"\">"+this.GetRes("INFO_CHANNEL_LIVE")+"</a>";
            ltrBroad.Text = "<a " + cssBroad + " href=\"IpTV.aspx?type=" + (int)Define.CHANNEL_SHOW.BROAD + "\">" + this.GetRes("INFO_CHANNEL_BROAD") + "</a>";



            Int32 nPage = this.GetIntParam("page", 1);

            Int32 nCount = (new Channel()).GetCount(nType, this.GroupMask);
            if (nCount != 0) {
                IList<ChannelData> cdList = (new Channel()).GetList(nType, this.GroupMask, nPage, 5, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
                if (cdList != null && cdList.Count != 0) {
                    rptChannelList.DataSource = cdList;
                    rptChannelList.DataBind();
                }
                ltrListTop.Text = WebHelper.PageList("IpTV.aspx?type=" + nType, nCount, nPage, 5);
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }
    }
}
