using System;
using System.Data;
using System.Data.SqlClient;
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
    public partial class ChannelLink : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                if ((new Permit()).CanMngProgram()) {
                    ltrOper.Text = "<a href=\"#\" onclick=\"openwndex('AddLink.aspx','" + this.GetRes("Oper_ChannelLinkAdd") + "',560,160);return false;\">" + this.GetRes("Oper_ChannelLinkAdd") + "</a>";
                    LinkDelete.Visible = true;
                    LinkDelete.InnerText = this.GetRes("Oper_ChannelLinkDelete");
                    LinkDelete.Attributes["onclick"] = "if(!confirm('" + this.GetRes("Info_ConfirmDelete") + "')){return false;}";
                } else {
                    LinkDelete.Visible = false;
                }
                this.Page.Title = this.GetRes("Info_ChannelLink");
                this.Master.CurPath = " / <a href=\"ChannelList.aspx?type=-1\">" + this.GetRes("Info_ChannelList") + "</a> / " + this.GetRes("Info_ChannelLink");
                BindSelType();
            }
            BindChannelList();
        }



        public void BindSelType() {
            Int32 nType = this.GetIntParam("type", 5);
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelAll"), Convert.ToString((int)Define.CHANNEL_SHOW.ALL)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelBroad"), Convert.ToString((int)Define.CHANNEL_SHOW.BROAD)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelLive"), Convert.ToString((int)Define.CHANNEL_SHOW.LIVE)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelRebroad"), Convert.ToString((int)Define.CHANNEL_SHOW.REBROAD)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelMix"), Convert.ToString((int)Define.CHANNEL_SHOW.MIXC)));
            ddlType.Items.Add(new ListItem(this.GetRes("Info_ChannelLink"), "5"));
            ddlType.SelectedValue = nType.ToString();
        }

        public void BindChannelList() {
            Int32 nType = this.GetIntParam("type", 5);
            Int32 nPage = this.GetIntParam("page", 1);

            Int32 nPageCount = GetCount(nType);
            if (nPageCount != 0) {
                String strUrl = WebHelper.GetShowUrl() + "?type=" + nType;
                ltrListTop.Text = ltrListBtm.Text = WebHelper.PageList(strUrl, nPageCount, nPage, 21);
                rptChaLink.DataSource = GetList(nType, nPage, 21);
                rptChaLink.DataBind();
            } else {
                ltrEmpty.Text = UserControl.UC_Helper.ListEmpty;
            }

        }

        public SqlDataReader GetList( Int32 nType, Int32 nPage, Int32 nPageSize ) {
            SqlPager pager = new SqlPager();
            pager.pCondition = "c_type=" + nType;
            pager.pItem = "c_id,c_name,c_info";
            pager.pPage = nPage;
            pager.pSize = nPageSize;
            pager.pSort = "desc";
            pager.pTable = "m3_channel";
            pager.pTip = "c_id";
            return pager.ExecQuery(pager.SQL);

        }

        public Int32 GetCount( Int32 nType ) {
            SqlPager pager = new SqlPager();
            pager.pCondition = "c_type=" + nType;
            pager.pTable = "m3_channel";
            return pager.ReaderInt32(pager.SqlCount);
        }

        public string BindOper( string strId ) {
            string strOper = "";
            if ((new Permit()).CanMngProgram()) {

                strOper = "<span><a href=\"#\" onclick=\"openwndex('AddLink.aspx?cid=" + strId + "','" + this.GetRes("Oper_ChannelLinkEdit") + "',560,160);return false;\">" +
                    this.GetRes("Oper_ChannelLinkEdit") + "</a></span>";
            }
            return strOper;
        }
        public string BindOper2( string strId ) {
            string strOper = "";
            if ((new Permit()).CanMngProgram()) {
                strOper = "<input type=\"checkbox\" name=\"CId\" value=\"" + strId + "\" />";
            }
            return strOper;
        }

        protected void ddlType_SelectedIndexChanged( object sender, EventArgs e ) {
            if (ddlType.SelectedValue == "5") {
                Response.Redirect("ChannelLink.aspx?type=5");
            } else {
                Response.Redirect("ChannelList.aspx?type=" + ddlType.SelectedValue);
            }
        }

        protected void LinkDelete_Click( object sender, EventArgs e ) {
            if ((new Permit()).CanMngProgram()) {
                string strId = this.GetStringParam("CId", "");
                if (!string.IsNullOrEmpty(strId)) {
                    string[] AarryId = strId.Split(",".ToCharArray());
                    for (int i = 0; i < AarryId.Length; i++) {
                        DeleteLink(int.Parse(AarryId[i]));
                    }
                }
                Response.Redirect("ChannelLink.aspx");
            }

        }
        public void DeleteLink( Int32 nCid ) {
            String sql = "delete from m3_channel where c_id=" + nCid;
            SqlPager pager = new SqlPager();
            pager.ExecNonQuery(sql);
        }
    }
}
