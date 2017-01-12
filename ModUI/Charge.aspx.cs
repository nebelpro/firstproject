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
    public partial class Charge : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (this.UserID == 0) {
                Response.Redirect("Default.aspx");
            }
            this.Page.Title = this.GetRes("Info_UserCenter");
        }


        protected void ibtnAddPoint_Click( object sender, ImageClickEventArgs e ) {
            lblTips.Text = "";
            string strCardNo = tbCardNum.Text.Replace("'", "");
            string strCardPwd = tbCardPwd.Text.Replace(";", "");
            if (strCardNo.Length ==0 || strCardPwd.Length ==0) {
                lblTips.Text = "* " + this.GetRes("WARN_CardIsEmpty");
            } else {
                String strMsg = "";            
                Int32 nRet = (new BLL.User()).AddUserCard(this.UserID, strCardNo, strCardPwd);
                if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.SUCCESS) {
                    // ok,update user session
                    UserHelper.SetUserCardSession(this.UserID);
                    strMsg = "* " + this.GetRes("INFO_ADDPOINT");

                } else {
                    if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.NOT_EXIST) {
                        strMsg = this.GetRes("WARN_NOCARD");
                    } else if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.HAS_USE) {
                        strMsg = this.GetRes("WARN_CARD_HASUER");
                    } else if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.ERR_TYPE) {
                        strMsg = this.GetRes("WARN_ADDCARDTYPEERR");
                    } else if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.ERR_PWD) {
                        strMsg = this.GetRes("WARN_ERRPWD");
                    } else if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.ERR_INVALID) {
                        strMsg = this.GetRes("WARN_CARD_INVALID");
                    }
                }
                lblTips.Text ="* "+ strMsg;



            }
        }


    }
}
