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

namespace MOD.WebTd.UserControls {
    public partial class Uc_Login : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
          
                if (Session["UserId"] != null && Session["UserId"].ToString() != "0") {                    
                    lbUserName.Text = "<div class=login-item>"+Session["UserMask"].ToString() +","+ Res.GetValue("INFO_LOGIN_WELCOME")+"</div>";
                    Int32 nPoint = (new BLL.User()).GetUserPoint(Int32.Parse(Session["UserId"].ToString()));
                    String strLeftPoint = Res.GetValue("INFO_LOGIN_LEFTPOINT").Replace("{0}",nPoint.ToString());
                    lbInfo.Text = "<div class=login-item>" + strLeftPoint + "</div>";
                 
                    tbUserName.Visible = false;
                    tbPassWord.Visible = false;
                    btnLogin.Visible = false;
                } else {
                    btnLogout.Visible = false;
                    lbInfo.Visible = false;
                    lbUserName.Visible = false;
                }
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e) {
            Int32 nRet = 0;
            String strMsg = "";
            String strAccount = tbUserName.Text;
            if (strAccount.Length == 0) {
                strMsg = Res.GetValue("WARN_ACCOUNT_EMPTY");
                WebHelper.MsgBox(strMsg, true, ""); 
            }

            UserData ud = (new BLL.User()).Login(tbUserName.Text,WebHelper.PutPwd(tbPassWord.Text),out nRet);
            
            if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_SUCCESS) {
                UserHelper.SetUserSession(ud.UMask,ud.UName,ud.UGroupMask,ud.GroupClass,
                    ud.UId,ud.UPermit,ud.GroupPermit,ud.UPoint,ud.UMonthCardValid);
                Response.Redirect("Default.aspx");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_ACCOUNT) {
                strMsg = Res.GetValue("WARN_NO_USER");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_PASSWD) {
                strMsg = Res.GetValue("WARN_PWD_ERR");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_GROUP) {
                strMsg = Res.GetValue("WARN_USERGROUP_ERR");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_NOLOGIN) {
                strMsg = Res.GetValue("WARN_LOGIN_NOPERMIT");
            }
            if (strMsg.Length != 0) {
                WebHelper.MsgBox(strMsg, true, "");
            }
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e) {
            UserHelper.SetUserSession("","",2,0,0,0,0,0,DateTime.Now);
            Response.Redirect("Default.aspx");
        }
    }
}