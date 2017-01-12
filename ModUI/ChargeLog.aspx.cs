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
    public partial class ChargeLog : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (this.UserID == 0) {
                Response.Redirect("Default.aspx");
            }
            Int32 nType = 0;
            if (this.GetIntParam("type", 0) != 0)
                nType = this.GetIntParam("type", 0);
            if (!Page.IsPostBack) {
                BindRptCardUse(nType);
            }
            this.Page.Title = this.GetRes("Info_UserCenter");
        }



        public void BindRptCardUse( int selectType ) {
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
                        WebHelper.MsgBox(this.GetRes("ERR_TIME"), false, "ChargeLog.aspx");
                    }
                } else {
                    WebHelper.MsgBox(this.GetRes("WARN_NOTIME"), false, "ChargeLog.aspx");
                }
                if (begintime > endtime) {
                    WebHelper.MsgBox(this.GetRes("WARN_TIMERANGE"), false, "ChargeLog.aspx");
                }
            }

            Int32 nCount = (new BLL.PointCard()).GetUseCount(this.UserID, begintime, endtime, selectType);
            if (nCount != 0) {
                ltrNavBottom.Text = WebHelper.PageList("ChargeLog.aspx?type=" + selectType + "&bt=" + strBt + "&et=" + strEt, nCount, nPage, 10);
                IList<PointCardUseData> pudList = (new PointCard()).GetUseList(this.UserID, begintime, endtime, selectType, nPage, 10);
                rptCardUse.DataSource = pudList;
                rptCardUse.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
            

        }
        protected void ibtnSearchCardUse_Click( object sender, ImageClickEventArgs e ) {
            Response.Redirect("ChargeLog.aspx?type=1&bt=" + tbDateBegin.Text + "&et=" + tbDateEnd.Text);
        }
    }
}
