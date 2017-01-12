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

namespace MOD.WebTd.UserControls {
    public partial class UC_ProgramRemark : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nPage = this.GetIntParam("page", 1);
            int nPid = this.GetIntParam("pid", 0);
            Int32 nCount = (new Remark()).GetCountByProgram(nPid,1);
            if (nCount != 0) {
                IList<RemarkData> rdList = (new BLL.Remark()).GetListByProgram(nPid, 1, nPage, 10);
                if (rdList != null && rdList.Count != 0) {
                    rptPrmRemark.DataSource = rdList;
                    rptPrmRemark.DataBind();
                }
            }
            ltPage.Text = WebHelper.PageList("ProgramInfo.aspx?pid=" + nPid.ToString(), nCount, nPage, 10);
        }

        protected void btnComment_Click( object sender, ImageClickEventArgs e ) {
            
           int nPid = this.GetIntParam("pid", 0);
            String strCommentInfo = tbPrInfo.Text;
            if (this.UserID==0) {
                WebHelper.MsgBox(Res.GetValue("WARING_NOLOGIN"), true, "");
            }
            if (strCommentInfo.Length == 0 || strCommentInfo.Length > 1024) {                
                WebHelper.MsgBox(Res.GetValue("WARING_NEWCOMMENT"), true, "");
            } else {
                RemarkData rd = new RemarkData();
                rd.PrUserId =this.UserID;
                rd.PrName = "No Title";
                rd.PrInfo = strCommentInfo;
                if ((new Permit()).CanMngProgram()) {
                    rd.PrState = 1;
                } else {
                    rd.PrState = 0;
                }
                rd.PrAddTime = DateTime.Now;
                rd.PrProgramId = nPid;

                (new BLL.Remark()).Insert(rd);

                if (!(new Permit()).CanMngProgram()) {
                    WebHelper.MsgBox(this.GetRes("INFO_ADDREMARK"), false, "ProgramInfo.aspx?pid=" + nPid);
                } else {
                    Response.Redirect("ProgramInfo.aspx?pid=" + nPid);
                }

            }
        }
    }
}