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

using Antlr.StringTemplate;
using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;


namespace MOD.UI.SkinFactory {
    public partial class Ajax : STPage {
        protected string oper = string.Empty;
        protected string response = string.Empty;

        protected void Page_Load( object sender, System.EventArgs e ) {
            Permit PT = new Permit();
            oper = this.GetStringParam("oper", "");
            // -10
            switch (oper) {
                case "GetCastInfo":
                    ChkLogin();
                    GetCastInfo();
                    break;
                #region About User (-11,-12,-13)

                case "HtmlModifyPwd":
                    ChkLogin();
                    ChkPermit(PT.CanChangePwd(), "-11");
                    AreaModifyPwd();
                    break;
                case "UserModifyPwd":
                    ChkLogin();
                    ChkPermit(PT.CanChangePwd(), "-11");
                    ModifyPwd();
                    break;
                case "Login":
                    Login();
                    break;
                case "LogOut":
                    LogOut();
                    break;
                #endregion 

                case "HtmlPointAdd":
                    ChkLogin();
                    AreaAddPoint();
                    break;
                case "UserAddPoint": // -21
                    ChkLogin();
                    AddPoint();
                    break;
                case "GetChargeList":
                    ChkLogin();
                    GetChargeList();
                    break;
                case "GetPlayLogList":
                    ChkLogin();
                    GetPlayLogList();
                    break;
                case "ProgramPlayStep1":
                    ChkLogin();
                    ChkPermit(PT.CanPlay(), "-14");
                    ProgramPlayStep1();
                    break;
                case "ProgramPlayStep2":
                    ChkLogin();
                    ChkPermit(PT.CanPlay(), "-14");
                    ProgramPlayStep2();
                    break;
                case "ProgramDown":
                    ChkLogin();
                    ChkPermit(PT.CanDownMedia(), "-21");
                    ProgramDown();
                    break;
                case "GetBulletinInfo":                   
                    GetBulletinInfo();
                    break;
                case "GetRemarkList":
                    GetRemarkList();
                    break;
                case "AddRemark":
                    ChkLogin();
                    AddRemark();
                    break;
                default:
                    //参数不全的处理
                    break;
            }

            Response.Write(response);
        }

        public void ChkLogin() {
            if (this.UserID == 0) {
                Response.Write("-10");
                Response.End();
            }
        }
        public void ChkPermit( bool isTrue, string strRet ) {
            if (!isTrue) {
                Response.Write(strRet);
                Response.End();
            }
        }

        public void AreaModifyPwd() {
            response = this.SetModifyPwd();
        }

        public void GetHtmlCode( string ctrlName ) {
            AjaxControl myCtrl = new AjaxControl(ctrlName, this.Page);
            response = myCtrl.GetString();
        }

        public void AreaAddPoint() {
            response = this.SetAddPoint();
        }
        public void AddPoint() {
            string strCardNo = this.GetStringParam("cardno", "").Replace("'", "").Replace(";", "");
            string strCardPwd = this.GetStringParam("cardpwd", "");

            if (strCardNo.Length != 10 || strCardPwd.Length != 10) {
                response = "-21";                
            } else {
                Int32 nRet = (new User()).AddUserCard(this.UserID, strCardNo, strCardPwd);
                response = nRet.ToString();
                if (nRet == (Int32)BLL.User.ENUM_RET_ADDPOINT.SUCCESS) {
                    UserHelper.SetUserCardSession(this.UserID);
                }
            }
        }

        public void GetChargeList() {
            response = this.SetChargeLog();
        }

        public void GetPlayLogList() {
            response = this.SetPlayLog();
        }

        public void ProgramPlayStep1() {
            string strPid = this.GetStringParam("pid", "");
            string CardValid = this.GetSession(UserHelper.SESSION_TYPE.CardValid);
            DateTime dtValid =WebHelper.FormatDateTime( Convert.ToDateTime(CardValid),1);
            Consume consume = new Consume(this.UserID, WebHelper.DecryptPid(strPid), dtValid);
            Int32 nRet = consume.PrepareCharge();
            response = nRet.ToString();
        }

        public void ProgramPlayStep2() {
            //两种 
            //一种直接用刚才的返回的 Point 点播，不再检测 
            //2.再检测一次，再点播
            string strPid = this.GetStringParam("pid", "");
            Int32 nMediaType = this.GetIntParam("mtype", 0);
            string CardValid = this.GetSession(UserHelper.SESSION_TYPE.CardValid);
            DateTime dtValid = WebHelper.FormatDateTime(Convert.ToDateTime(CardValid), 1);
            Int32 nIndex = this.GetIntParam("index", 0);
            Consume consume = new Consume(this.UserID, WebHelper.DecryptPid(strPid),dtValid,nIndex);
            UserHelper.SetUserPointSession(this.UserID);
            response = consume.Play();
        }

        public void ProgramDown() {
            string strPid = this.GetStringParam("pid", "");
            Int32 nIndex = this.GetIntParam("index", 0);
            Consume consume = new Consume(this.UserID, WebHelper.DecryptPid(strPid),nIndex);
            response = consume.Download();
        }

        public void GetBulletinInfo() {
            response = this.SetBulletinInfo();
        }

        #region 用户

        public void ModifyPwd() {
            string oldpwd = this.GetStringParam("old", "");
            string newpwd = this.GetStringParam("pass", "");
            string strConfirm = this.GetStringParam("pconfirm", "");


            if (strConfirm != newpwd) {
                response = "-12";
                return;
            } else {
                Int32 nRet = (new User()).ModifyPassword(this.UserID, WebHelper.PutPwd(oldpwd)
                    , WebHelper.PutPwd(newpwd));
               
                if (nRet == 0) {
                   // strMsg = Res.GetValue("ERR_PWD_OLD");
                    response = "-13";
                    return;
                } else if (nRet == 1) {
                    //strMsg = Res.GetValue("SUCC_CHANGE_PWD");
                    response= "suc";
                    return;
                }

            }

        }

        public void LogOut() {
            UserHelper.SetUserSession("", "", 2, 0, 0, 0, 0, 0, DateTime.Now);
            Session.Remove(UserHelper.SESSION_TYPE.CardType);
            this.ReLogin = 0;           
            Response.Redirect("Default.aspx");
        }
        /// <summary>
        /// 临时卡用户登录
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strPwd"></param>
        /// <param name="ptcard"></param>
        /// <returns></returns>
        public String CardLogin( String strAccount, String strPwd ) {
            PointCard ptBll = new PointCard();
            String strMsg = "";
            PointCardData ptcard = (new PointCard()).GetPointCardByNo(strAccount);
            if (ptcard != null) {
                if (ptcard.PcType != 2) strMsg = this.GetRes("Warn_UserNotExist");
                if (strPwd != ptcard.PcPasswd) strMsg = this.GetRes("Warn_PasswordError");
                if (ptcard.PcState == 0) ptBll.UpdateState(strAccount, 1);

                if (DateTime.Now < WebHelper.FormatDateTime(ptcard.PcValidDate, 1)) {
                    UserData tempUser = (new User()).GetDetail(10);
                    if (tempUser != null) {
                        if ((new User()).GetUserPermit(ref tempUser)) {
                            if ((new Permit(tempUser.UPermit, tempUser.GroupPermit)).CanLogin()) {
                                UserHelper.SetUserSession(strAccount, strAccount, tempUser.UGroupMask, tempUser.GroupClass,
                                    tempUser.UId, tempUser.UPermit, tempUser.GroupPermit, tempUser.UPoint, tempUser.UMonthCardValid);
                                UserHelper.SetConsumeCardSession(ptcard.PcType, ptcard.PcValidDate);
                                this.ReLogin = 1;
                                strMsg = "1";
                            } else {
                                strMsg = this.GetRes("Warn_NoLoginPermit");
                            }
                        } else {
                            strMsg = this.GetRes("Warn_UserGroupError");
                        }
                    } else {
                        strMsg = this.GetRes("Warn_UserNotExist");
                    }

                } else {
                    strMsg = this.GetRes("Warn_CardInvalid");
                }
            }
            return strMsg;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strAccount"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public String UserLogin( String strAccount, String strPwd ) {
            Int32 nRet = 0;
            String strMsg = "";
            UserData ud = (new User()).Login(strAccount, WebHelper.PutPwd(strPwd), out nRet);

            if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_SUCCESS) {
                UserHelper.SetUserSession(ud.UMask, ud.UName, ud.UGroupMask, ud.GroupClass,
                    ud.UId, ud.UPermit, ud.GroupPermit, ud.UPoint, ud.UMonthCardValid);
                UserHelper.SetUserCardSession(ud.UId);
                this.ReLogin = 1;
                strMsg = "1";
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_ACCOUNT) {
                strMsg = this.GetRes("Warn_UserNotExist");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_PASSWD) {
                strMsg = this.GetRes("Warn_PasswordError");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_GROUP) {
                strMsg = this.GetRes("Warn_UserGroupError");
            } else if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_ERR_NOLOGIN) {
                strMsg = this.GetRes("Warn_NoLoginPermit");
            }
            return strMsg;
        }
        public void Login() {
            String strAccount = this.GetStringParam("mask", "");
            String strPwd = this.GetStringParam("pwd", "");

            if (strAccount.Length == 0) {
                response = this.GetRes("Warn_AccountEmpty");
                return;
            }
            response = CardLogin(strAccount, strPwd);
            if (response == "") {
                response = UserLogin(strAccount, strPwd);
                return;
            }
        }

        #endregion 

        #region  ===Remark

        public void GetRemarkList() {
            response = this.SetRemarkList();
        }

        public void AddRemark() {
            Int32 nProgramId = this.GetIntParam("pid", 0);
            String strTitle = this.GetStringParam("name", "").Trim();
            String strContent = this.GetStringParam("info", "").Trim();
            if (strTitle.Length == 0) {
                response = "-11";
                return;
            } else if (strTitle.Length > 32) {
                response = "-12";
                return;
            } else if (strContent.Length == 0) {
                response = "-13";
                return;
               
            } else if (strContent.Length > 512) {
                response = "-14";
                return;
            } else {
                RemarkData rmdata = new RemarkData();
                rmdata.PrAddTime = DateTime.Now;
                rmdata.PrName = this.TextIn(strTitle);
                rmdata.PrInfo = this.TextIn(strContent);
                rmdata.PrProgramId = nProgramId;
                if ((new Permit()).CanMngProgram()) {
                    rmdata.PrState = 1;
                } else {
                    rmdata.PrState = 0;
                }
                rmdata.PrUserId = this.UserID;

                (new Remark()).Insert(rmdata);
                if (!(new Permit()).CanMngProgram()) {
                    response = "1";
                } else {
                    response = "2";
                }
            }


        }
        #endregion 

        #region iptv及直录系统
        public void GetCastInfo() {
            int CastId = this.GetIntParam("id", 0);
            bool IsOk = false;
            string strParam = "";
            string strInfo = "";
            ChannelData cha = (new Channel()).GetChannelInfoById(CastId);
            if (cha != null) {
                IsOk = true;
                strParam = ChannelHelper.GetCastUI(cha.CId, 0);
                strInfo = cha.CInfo;
            }
            string strRet = "{ \"Suc\":\"" + IsOk + "\",\"Param\":" + strParam + ",\"Info\":\"" + this.TextIn(strInfo) + "\"}";//
            response = strRet;
        }

        #endregion 





    }


}
