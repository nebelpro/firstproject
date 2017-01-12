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

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI {
    public partial class ModifyPwd : MOD.WebUtility.UI.Page {

        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("Info_UserCenter");

            if (this.UserID == 0) {
                Response.Redirect("Default.aspx");
            }
            if (!(new Permit()).CanChangePwd()) {
                Response.Write("<script>history.back();</script>");
            }
            


        }
        protected void ImageChangePwd_Click( object sender, ImageClickEventArgs e ) {
            lblPwdOld.Text = "";
            lblPwdNew.Text = "";
            lblPwdConfirm.Text = "";
            string oldpwd = txPdOld.Text;
            string newpwd = txPdDefault.Text;
            if (txPdConfirm.Text != txPdDefault.Text) {
                lblPwdConfirm.Text ="* "+ this.GetRes("INFO_PWD_CONFIRM_ERR");
            } else {
                Int32 nRet = (new BLL.User()).ModifyPassword(this.UserID, WebHelper.PutPwd(oldpwd), WebHelper.PutPwd(newpwd));
                String strMsg = "";
                if (nRet == 0) {
                    lblPwdOld.Text = "* " + this.GetRes("ERR_PWD_OLD");
                    
                } else if (nRet == 1) {
                    strMsg = this.GetRes("SUCC_CHANGE_PWD");
                    Response.Write("<script>alert(\"" + strMsg + "\");</script>");
                }

            }
        }
    }
}
