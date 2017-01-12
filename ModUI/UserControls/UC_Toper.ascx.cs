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

namespace MOD.UI.UserControls {
    public partial class UC_Toper : MOD.WebUtility.UI.UserControl {

        public String Logo {
            set { imgLogo.ImageUrl = "~/"+value; }
        }
        public String Info_Setting {
            set { ltrSetting.Text = value; }
        }
        

        protected void Page_Init( object sender, EventArgs e ) {
            if (this.ReLogin == 0) {
                MOD.WebUtility.UserHelper.DefaultLogin();
            }
            
            if (this.ReLogin != 0 && this.UserID != 0) {
                pnlLogin.Visible = false;
                pnlIsLogon.Visible = true;
                InitHelpNav(ltrHelpNav);
            } else {
                pnlLogin.Visible = true;
                pnlIsLogon.Visible = false;                
            }
        }

        protected void Page_Load( object sender, EventArgs e ) {
           
        }

        /// <summary>
        /// 初始化帮助导航
        /// </summary>
        /// <param name="ltrText"></param>
        public void InitHelpNav( Literal ltrText ) {
            //string strFormat = "<li><a href=\"{0}\" onclick=\"{1}\">{2}</a></li>";

            if (this.UserID != 0) {
                //if (this.GetSession(UserHelper.SESSION_TYPE.CardType) != "2") {
                    ltrText.Text = "<li><a href=\"GuestBook.aspx\">" + this.GetRes("Info_UserCenter") + "</a></li>";
                    /*if ((new Permit()).CanChangePwd()) {
                        ltrText.Text = string.Format(strFormat, "#", "openwndex('ChangePwd.aspx','" + this.GetRes("CHANGE_PWD") + "','260','180')", this.GetRes("CHANGE_PWD"));
                    }*/                 
               // }                
            } else {
                ltrText.Text = "";
            }
        }
        public void InitHelpNav2( Literal ltrText ) {
            string strFormat = "<li><a href=\"#\" onclick=\"{0}\">{1}</a></li>";

            if (this.UserID != 0) {
                if ((new Permit()).CanChangePwd()) {
                    ltrText.Text = string.Format(strFormat, "dialog(260,180,'" + this.GetRes("CHANGE_PWD") + "');", this.GetRes("CHANGE_PWD"));
                }
                ltrText.Text += string.Format(strFormat, "dialog(260,150,'" + this.GetRes("ADD_POINT") + "');", this.GetRes("ADD_POINT")) +
                   string.Format(strFormat, "dialog(200,200,'" + this.GetRes("POINTCARD_QUERY") + "');", this.GetRes("POINTCARD_QUERY")) +
                   string.Format(strFormat, "dialog(300,300,'" + this.GetRes("PLAY_QUERY") + "');", this.GetRes("PLAY_QUERY")) +
                   "<li><a href=\"SoftDown.aspx\">" + this.GetRes("INFO_SOFTDOWN") + "</a></li>";

            } else {
                ltrText.Text = "";
            }
        }

        protected void ibtnLogin_Click( object sender, EventArgs e ) {
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
                if (DateTime.Now < WebHelper.FormatDateTime(ptcard.PcValidDate, 1) ) {
                    UserData tempUser = (new User()).GetDetail(10);
                    if (tempUser != null) {
                        if ((new User()).GetUserPermit(ref tempUser)) {
                            if ((new Permit(tempUser.UPermit, tempUser.GroupPermit)).CanLogin()) {
                                UserHelper.SetUserSession(strAccount, strAccount, tempUser.UGroupMask, tempUser.GroupClass,
                                    tempUser.UId, tempUser.UPermit, tempUser.GroupPermit, tempUser.UPoint, tempUser.UMonthCardValid);
                                UserHelper.SetConsumeCardSession(ptcard.PcType,ptcard.PcValidDate);
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

        protected void lbtnExit_Click( object sender, EventArgs e ) {
            UserHelper.SetUserSession("", "", 2, 0, 0, 0, 0, 0, DateTime.Now);
            this.ReLogin = 0;
            Session.Remove(UserHelper.SESSION_TYPE.CardType);
            Response.Redirect("Default.aspx");
        }
    }
}