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


namespace MOD.WebTd {
    public partial class Ajax : MOD.WebUtility.UI.Page {
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
                    GetHtmlCode("UC_ModifyPwd");
                    break;
                case "UserModifyPwd":
                    ChkLogin();
                    ChkPermit(PT.CanChangePwd(), "-11");
                    ModifyPwd();
                    break;
                #endregion 
                case "HtmlPointAdd":
                    ChkLogin();
                    GetHtmlCode("UC_AddPoint");
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
        public void GetHtmlCode( string ctrlName ) {
            AjaxControl myCtrl = new AjaxControl(ctrlName, this.Page);
            response = myCtrl.GetString();
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

            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nType = 0;

            DateTime begintime = DateTime.Now;
            DateTime endtime = DateTime.Now;            
            String strBt = this.GetStringParam("begin","");
            String strEt = this.GetStringParam("end","");
            if (strBt != "" || strEt != "") {
                nType = 1;
                try {
                    begintime = WebHelper.FormatDateTime(Convert.ToDateTime(strBt), 0);
                    endtime = WebHelper.FormatDateTime(Convert.ToDateTime(strEt), 1);
                } catch {
                    response = "-21";     
                    return;
                }
                if (begintime > endtime) {
                    response = "-22";                   
                    return;
                }
            }


            PointCard pcBll = new PointCard();
            AjaxControl myCtrl = new AjaxControl("UC_ChargeLog", this.Page);

            Int32 nPageCount = pcBll.GetUseCount(this.UserID, begintime, endtime, nType);
            if (nPageCount != 0) {
                Literal ltrListTop = myCtrl.AjaxLtr("ltrListTop");
                Repeater rptList = myCtrl.AjaxRpt("rptCardUse");  
                String strOnclick = "user.GetCharge({0})";
                ltrListTop.Text =string.Format(Helper.ListBar, WebHelper.AjaxPager(strOnclick, nPageCount, nPage, 10),"");
                rptList.DataSource = pcBll.GetUseList(this.UserID, begintime, endtime, nType, nPage, 10);
                rptList.DataBind(); 

            }  else {
                Literal ltrEmpty = myCtrl.AjaxLtr("ltrEmpty");
                ltrEmpty.Text = Helper.ListEmpty;
            }
            response = myCtrl.GetString();

        }

        public void GetPlayLogList() {
            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nType = 0;

            DateTime begintime = DateTime.Now;
            DateTime endtime = DateTime.Now;
            String strBt = this.GetStringParam("begin", "");
            String strEt = this.GetStringParam("end", "");
            if (strBt != "" || strEt != "") {
                nType = 1;
                try {
                    begintime = WebHelper.FormatDateTime(Convert.ToDateTime(strBt), 0);
                    endtime = WebHelper.FormatDateTime(Convert.ToDateTime(strEt), 1);
                } catch {
                    response = "-21";
                    return;
                }
                if (begintime > endtime) {
                    response = "-22";
                    return;
                }
            }


            PointCard pcBll = new PointCard();
            AjaxControl myCtrl = new AjaxControl("UC_PlayLog", this.Page);

            Int32 nPageCount = pcBll.GetPlayCount(this.UserID, begintime, endtime, nType);
            if (nPageCount != 0) {
                Literal ltrListTop = myCtrl.AjaxLtr("ltrListTop");
                Repeater rptList = myCtrl.AjaxRpt("rptList");
                String strOnclick = "user.GetPlayLog({0})";
                ltrListTop.Text = string.Format(Helper.ListBar, WebHelper.AjaxPager(strOnclick, nPageCount, nPage, 10), "");
                rptList.DataSource = pcBll.GetPlayList(this.UserID, begintime, endtime, nType, nPage, 10);
                rptList.DataBind();

            } else {
                Literal ltrEmpty = myCtrl.AjaxLtr("ltrEmpty");
                ltrEmpty.Text = Helper.ListEmpty;
            }
            response = myCtrl.GetString();

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
            Int32 nBid = this.GetIntParam("bid", 0);
            BulletinData bda = (new Bulletin()).GetBulletinByBid(nBid);
            if (bda != null) {
                AjaxControl myCtrl = new AjaxControl("UC_BulletinInfo", this.Page);
                Literal ltrName = myCtrl.AjaxLtr("ltrName");
                Literal ltrAddTime = myCtrl.AjaxLtr("ltrAddTime");
                Literal ltrUserName = myCtrl.AjaxLtr("ltrUserName");
                Literal ltrInfo = myCtrl.AjaxLtr("ltrInfo");
                ltrName.Text = bda.BName;
                ltrAddTime.Text = bda.BAddtime.ToString();
                ltrUserName.Text = bda.BUserName;
                ltrInfo.Text = bda.BInfo;
                response = myCtrl.GetString();
            } else {
                response = "-11";
            }
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
