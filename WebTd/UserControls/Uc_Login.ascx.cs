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
    public partial class Uc_Login : MOD.WebUtility.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
          
                if (this.UserID!=0) {                    
                    lbUserName.Text = "<div class=login-item>"+this.UserMask +","+ Res.GetValue("INFO_LOGIN_WELCOME")+"</div>";
                    String strLeftPoint = "";
                    Int32 nPoint = (new BLL.User()).GetUserPoint(this.UserID);
                    String strUserValid = Session["CardValid"].ToString();
                    if (strUserValid != null && strUserValid != String.Empty) {
                        DateTime dtValid = DateTime.Parse(strUserValid);
                        if (dtValid > DateTime.Now) {
                            strLeftPoint = Res.GetValue("INFO_LOGIN_LEFTMONTH").Replace("{0}", "<br/>"+strUserValid);
                        } else {
                            strLeftPoint = Res.GetValue("INFO_LOGIN_LEFTPOINT").Replace("{0}", nPoint.ToString());
                        }
                    } else {
                        strLeftPoint = Res.GetValue("INFO_LOGIN_LEFTPOINT").Replace("{0}", nPoint.ToString());
                    }
                    lbInfo.Text = "<div class=login-item>" + strLeftPoint + "</div>";
                 
                    tbUserName.Visible = false;
                    tbPassWord.Visible = false;
                    btnLogin.Visible = false;
                } else {
                    btnLogout.Visible = false;
                    lbInfo.Visible = false;
                    lbUserName.Visible = false;
                    if (this.ReLogin==0) {
                        // 默认用户登陆
                        UserHelper.DefaultLogin();
                    }
                }
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e) {
            Int32 nRet = 0;
            String strMsg = "";
            String strAccount = tbUserName.Text;
            if (strAccount.Length == 0) {

                WebHelper.MsgBox(this.GetRes("WARN_ACCOUNT_EMPTY"), true, "");
            }


            PointCard ptBll = new PointCard();
            PointCardData ptcard = ptBll.GetPointCardByNo(strAccount);
            if (ptcard != null) {
                #region  临时卡用户登录
                if (ptcard.PcType != 2) {
                    WebHelper.MsgBox(this.GetRes("WARN_NO_USER"), true, "");
                }
                if (tbPassWord.Text != ptcard.PcPasswd) {
                    WebHelper.MsgBox(this.GetRes("WARN_PWD_ERR"), true, "");
                }
                if (ptcard.PcState == 0) {
                    ptBll.UpdateState(strAccount, 1);
                }
                if (DateTime.Now < WebHelper.FormatDateTime(ptcard.PcValidDate, 1)) {
                    UserData tempUser = (new User()).GetDetail(10);
                    if (tempUser != null) {
                        if ((new User()).GetUserPermit(ref tempUser)) {
                            if ((new Permit(tempUser.UPermit, tempUser.GroupPermit)).CanLogin()) {
                                UserHelper.SetUserSession(tempUser.UMask, tempUser.UName, tempUser.UGroupMask, tempUser.GroupClass,
                                    tempUser.UId, tempUser.UPermit, tempUser.GroupPermit, tempUser.UPoint, tempUser.UMonthCardValid);
                                UserHelper.SetConsumeCardSession(ptcard.PcType, ptcard.PcValidDate);
                                this.ReLogin = 1;
                                Response.Redirect("Default.aspx");
                            } else {
                                WebHelper.MsgBox(this.GetRes("WARN_LOGIN_NOPERMIT"), true, "");//d
                            }
                        } else {
                            WebHelper.MsgBox(this.GetRes("WARN_USERGROUP_ERR"), true, "");//c
                        }
                    } else {
                        WebHelper.MsgBox(this.GetRes("WARN_NO_USER"), true, "");//a
                    }

                } else {
                    WebHelper.MsgBox(this.GetRes("WARN_CARD_INVALID"), true, "");
                }
                #endregion
            } else {
                #region  用户登录
                UserData ud = (new User()).Login(tbUserName.Text, WebHelper.PutPwd(tbPassWord.Text), out nRet);

                if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_SUCCESS) {
                    UserHelper.SetUserSession(ud.UMask, ud.UName, ud.UGroupMask, ud.GroupClass,
                        ud.UId, ud.UPermit, ud.GroupPermit, ud.UPoint, ud.UMonthCardValid);
                    UserHelper.SetUserCardSession(ud.UId);
                    this.ReLogin = 1;
                    Response.Redirect("Default.aspx");
                } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_ACCOUNT) {
                    strMsg = this.GetRes("WARN_NO_USER");//a
                } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_PASSWD) {
                    strMsg = this.GetRes("WARN_PWD_ERR");//b
                } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_GROUP) {
                    strMsg = this.GetRes("WARN_USERGROUP_ERR");//c
                } else if (nRet == (Int32)User.ENUM_RET_LOGIN.RET_ERR_NOLOGIN) {
                    strMsg = this.GetRes("WARN_LOGIN_NOPERMIT");//d
                }
                if (strMsg.Length != 0) {
                    WebHelper.MsgBox(strMsg, true, "");
                }
                #endregion
            }
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e) {
            UserHelper.SetUserSession("","",2,0,0,0,0,0,DateTime.Now);
            this.ReLogin = 0;
            Response.Redirect("Default.aspx");
        }
    }
}