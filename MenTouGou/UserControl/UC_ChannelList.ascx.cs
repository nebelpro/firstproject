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

namespace mentougou.UserControl {
    public partial class UC_ChannelList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {

            if (!Page.IsPostBack) {
                BindSelType();
                BindChannelList();
            }
            
        }


        public void BindSelType() {
            Int32 nType = this.GetIntParam("type", -1);
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelAll"), Convert.ToString((int)Define.CHANNEL_SHOW.ALL)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelBroad"), Convert.ToString((int)Define.CHANNEL_SHOW.BROAD)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelLive"), Convert.ToString((int)Define.CHANNEL_SHOW.LIVE)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelRebroad"), Convert.ToString((int)Define.CHANNEL_SHOW.REBROAD)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelMix"), Convert.ToString((int)Define.CHANNEL_SHOW.MIXC)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelLink"),"5"));            
            ddlType.SelectedValue = nType.ToString();
        }


        public void BindChannelList() {
            Int32 nType = this.GetIntParam("type", 0);
            Int32 nPage = this.GetIntParam("page", 1);
            

            Int32 nPageCount = (new Channel()).GetCount(nType, this.GroupMask);
            if (nPageCount != 0) {
                String strUrl = WebHelper.GetShowUrl()+"?type="+nType;
                ltrListTop.Text = ltrListBtm.Text = WebHelper.PageList(strUrl, nPageCount, nPage, UC_Helper.PAGE_CHANNELLIST_SIZE);
                rptChannelList.DataSource = (new Channel()).GetList(nType, this.GroupMask, nPage, UC_Helper.PAGE_CHANNELLIST_SIZE, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
                rptChannelList.DataBind();
            } else {               
                ltrEmpty.Text = UC_Helper.ListEmpty;
            } 

        }

        protected void ddlType_SelectedIndexChanged( object sender, EventArgs e ) {          
            if (ddlType.SelectedValue == "5") {
               Response.Redirect("ChannelLink.aspx?type=5");
            } else {
                Response.Redirect(WebHelper.GetShowUrl() + "?type=" + ddlType.SelectedValue);
            }
        }
    }
}