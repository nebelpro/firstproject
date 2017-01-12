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

namespace mentougou {
    public partial class MasterPage : MOD.WebUtility.UI.MasterPage {

        public String CurPath {
            set { ltrPath.Text = value; }
        }
        public String CurJs {
            set { ltrJS.Text = value; }
        }


        public void Page_Init( object sender, EventArgs e ) {
            if (this.ReLogin == 0) {
                MOD.WebUtility.UserHelper.DefaultLogin();
            }

            if (this.ReLogin !=0 && this.UserID != 0) {
                pnlLogin.Visible = false;
                pnlIsLogon.Visible = true;
                ltrUserName.Text = this.UserName + "," + this.GetRes("INFO_LOGIN_WELCOME");
            } else {
                pnlLogin.Visible = true;
                pnlIsLogon.Visible = false;
            }


        }
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void ibtnSearch_Click( object sender, ImageClickEventArgs e ) {
            string strKeyInfo = tbSearchText.Text;
            Response.Redirect("SearchResult.aspx?key=" + strKeyInfo);
        }

        protected void ibtnLogin_Click( object sender, ImageClickEventArgs e ) {
            Int32 nRet = 0;
            String strMsg = "";
            String strAccount = tbUserName.Text;
            if (strAccount.Length == 0) {
                strMsg = this.GetRes("WARN_ACCOUNT_EMPTY");
                WebHelper.MsgBox(strMsg, true, "");
            }

            UserData ud = (new User()).Login(tbUserName.Text, WebHelper.PutPwd(tbPassWord.Text), out nRet);

            if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_SUCCESS) {
                UserHelper.SetUserSession(ud.UMask, ud.UName, ud.UGroupMask, ud.GroupClass,
                    ud.UId, ud.UPermit, ud.GroupPermit, ud.UPoint, ud.UMonthCardValid);
                UserHelper.SetUserCardSession(ud.UId);
                this.ReLogin = 1;
                Response.Redirect("Default.aspx");
            } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_ACCOUNT) {
                strMsg = this.GetRes("WARN_NO_USER");
            } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_PASSWD) {
                strMsg = this.GetRes("WARN_PWD_ERR");
            } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_GROUP) {
                strMsg = this.GetRes("WARN_USERGROUP_ERR");
            } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_NOLOGIN) {
                strMsg = this.GetRes("WARN_LOGIN_NOPERMIT");
            }
            if (strMsg.Length != 0) {
                WebHelper.MsgBox(strMsg, true, "");
            }
        }

        protected void ibtnExit_Click( object sender, ImageClickEventArgs e ) {           
            UserHelper.SetUserSession("", "", 2, 0, 0, 0, 0, 0, DateTime.Now);
            this.ReLogin = 0;
            Response.Redirect("Default.aspx");
        
        }
       
    }
}
