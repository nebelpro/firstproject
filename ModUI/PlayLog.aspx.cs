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
    public partial class PlayLog : MOD.WebUtility.UI.Page {

        protected void Page_Load( object sender, EventArgs e ) {
            if (this.UserID == 0) {
                Response.Write("<script>alert('" + this.GetRes("WARN_NOLOGIN") + "!');</script>");
                Response.End();
            }
            Int32 nType = 0;
            if (WebHelper.GetRequest("type") != String.Empty)
                nType = Int32.Parse(WebHelper.GetRequest("type"));
            if (!Page.IsPostBack) {
                BindCardPlay(nType);
            }
            this.Page.Title = this.GetRes("Info_UserCenter");
        }

        /// <summary>
        /// �󶨵㲥��¼�б�
        /// </summary>
        /// <param name="selectType"></param>
        public void BindCardPlay( int selectType ) {
            DateTime begintime = DateTime.Now;
            DateTime endtime = DateTime.Now;

            Int32 nPage = this.GetIntParam("page", 1);

            String strBt = WebHelper.GetRequest("bt");
            String strEt = WebHelper.GetRequest("et");
            if (selectType != 0) {

                if (strBt.Length != 0 && strEt.Length != 0) {
                    try {
                        begintime = WebHelper.FormatDateTime(Convert.ToDateTime(strBt), 0);
                        endtime = WebHelper.FormatDateTime(Convert.ToDateTime(strEt), 1);
                    } catch {
                        WebHelper.MsgBox(this.GetRes("ERR_TIME"), false, "PlayLog.aspx");
                    }
                } else {
                    WebHelper.MsgBox(this.GetRes("WARN_NOTIME"), false, "PlayLog.aspx");
                }
                if (begintime > endtime) {
                    WebHelper.MsgBox(this.GetRes("WARN_TIMERANGE"), false, "PlayLog.aspx");
                }
            }

            Int32 nCount = (new BLL.PointCard()).GetPlayCount(this.UserID, begintime, endtime, selectType);
            if (nCount != 0) {
                ltrNavBottom.Text = WebHelper.PageList("PlayLog.aspx?type=" + selectType + "&bt=" + strBt + "&et=" + strEt, nCount, nPage, 10);
                IList<PointCardPlayData> RptDataList = (new PointCard()).GetPlayList(this.UserID, begintime, endtime, selectType, nPage, 10);
                rptCardPlay.DataSource = RptDataList;
                rptCardPlay.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }

        }


        protected void ibtnSearchCardUser_Click( object sender, ImageClickEventArgs e ) {
            Response.Redirect("PlayLog.aspx?type=1&bt=" + tbDateBegin.Text + "&et=" + tbDateEnd.Text);
        }
    }
}
