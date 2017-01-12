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

namespace MOD.UI.UserControls {
    public partial class UC_ProgramRemark : MOD.WebUtility.UI.UserControl {

        protected void Page_Init( object sender, EventArgs e ) {            
            ibtnPostComment.Attributes.Add("onclick", "document.getElementById('aspnetForm').action=document.getElementById('aspnetForm').action+'#remark'");
        }

        protected void Page_Load( object sender, EventArgs e ) {
            BindProgramRemark();
        }

        public void BindProgramRemark() {
            Int32 nPage = this.GetIntParam("page", 1);
            Remark rmBll = new Remark();
            int nProgramId = this.GetIntParam("pid", 0);
            Int32 nPageCount = rmBll.GetCountByProgram(nProgramId, 1);
            if (nPageCount != 0) {
                string strPageUrl = "ProgramInfo.aspx?pid=" + nProgramId.ToString();
                ltrListTop.Text = string.Format(Helper.ListBar, "", WebHelper.PageList(strPageUrl, nPageCount, nPage, Helper.PAGE_REMARKLIST_SIZE,8));
                rptPrmRemark.DataSource = rmBll.GetListByProgram(nProgramId, 1, nPage, Helper.PAGE_REMARKLIST_SIZE);
                rptPrmRemark.DataBind();
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }
        }

        protected void ibtnPostComment_Click( object sender, EventArgs e ) {

            Int32 nProgramId = this.GetIntParam("pid", 0);

            if (this.UserID == 0) {
                WebHelper.MsgBox(this.GetRes("WARN_REMARK_NOLOGIN"), true, "");
            } else if (tbPrName.Text.Trim().Length == 0) {
                WebHelper.MsgBox(this.GetRes("WARN_REMARK_NO_TITLE"), true, "");
            } else if (tbPrName.Text.Trim().Length > 32) {
                WebHelper.MsgBox(this.GetRes("WARN_REMARK_TITLE_ERR"), true, "");
            } else if (tbPrInfo.Text.Trim().Length == 0) {
                WebHelper.MsgBox(this.GetRes("WARN_REMARK_NO_INFO"), true, "");
            } else if (tbPrInfo.Text.Trim().Length > 512) {
                WebHelper.MsgBox(this.GetRes("WARN_REMARK_INFO_ERR"), true, "");
            } else {

                RemarkData rmdata = new RemarkData();
                rmdata.PrAddTime = DateTime.Now;
                rmdata.PrInfo = tbPrInfo.Text;
                rmdata.PrName = tbPrName.Text;
                rmdata.PrProgramId = nProgramId;
                if ((new Permit()).CanMngProgram()) {
                    rmdata.PrState = 1;
                } else {
                    rmdata.PrState = 0;
                }
                rmdata.PrUserId = this.UserID;

                (new Remark()).Insert(rmdata);
                if (!(new Permit()).CanMngProgram()) {
                    WebHelper.MsgBox(this.GetRes("INFO_ADDREMARK"), false, "ProgramInfo.aspx?pid=" + nProgramId);
                } else {
                    Response.Redirect("ProgramInfo.aspx?pid=" + nProgramId);
                }
            }

        }

    }
}