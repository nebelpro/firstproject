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
    public partial class Recorder : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("INFO_RECORDER");
            this.Master.Logo = "Images/depend/recorder_logo.gif";
            this.Master.CastSort = 0;

           
            if (this.GetSession("UserId", 0) == 0)
                Response.Redirect("Default.aspx");

            ltrTip.Text = this.GetRes("INFO_RecorderTitle");

            Int32 nType = this.GetIntParam("type", (int)Define.CHANNEL_SHOW.LIVE);


            string cssLive = (nType == (int)Define.CHANNEL_SHOW.LIVE) ? "style=\"font-weight:bold;color:#000;\"" : "";
            string cssMixc = (nType == (int)Define.CHANNEL_SHOW.MIXC) ? "style=\"font-weight:bold;color:#000;\"" : "";

            ltrLive.Text = "<a " + cssLive + " href=\"Recorder.aspx?type=" + 
                            (int)Define.CHANNEL_SHOW.LIVE +
                            "\">" + this.GetRes("INFO_CHANNEL_LIVE") + "</a>";

            ltrMixc.Text = "<a " + cssMixc + " href=\"Recorder.aspx?type=" +
                            (int)Define.CHANNEL_SHOW.MIXC +
                            "\">" + this.GetRes("INFO_CHANNEL_MIX") + "</a>";




            Int32 nPage = this.GetIntParam("page", 1);

            Int32 nCount = (new Channel()).GetCount(nType, this.GroupMask);
            if (nCount != 0) {
                IList<ChannelData> cdList = (new Channel()).GetList(nType, this.GroupMask, nPage, 5, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
                
                if (cdList != null && cdList.Count != 0) {
                    rptChannelList.DataSource = cdList;
                    rptChannelList.DataBind();
                }
                ltrListTop.Text = WebHelper.PageList("Recorder.aspx?type=" + nType, nCount, nPage, 5);
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }


    }
}
