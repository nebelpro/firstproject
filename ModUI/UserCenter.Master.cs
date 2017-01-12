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

using System.Text;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI {
    public partial class UserCenter : MOD.WebUtility.UI.MasterPage {

        protected void Page_Init( object sender, EventArgs e ) {
            Toper1.Logo = "Images/depend/mod_logo.gif";

        }

        protected void Page_Load( object sender, EventArgs e ) {
            if (this.UserID != 0 && this.ReLogin != 0) {
                InitUserDetail();
                InitUserNav();
            } else {
                Response.Redirect("Default.aspx");
            }
        }

        public void InitUserNav() {
            //是否登陆 Relogin， UserID
            //是否 消费卡
            
            String strNav="";
            String strF = "<li><a href=\"{0}\">{1}</a></li>";
            
            if (this.UserID != 0) {
                if(this.GetSession(UserHelper.SESSION_TYPE.CardType) != "2"){
                    if ((new Permit()).CanChangePwd()) {
                        strNav += String.Format(strF, "ModifyPwd.aspx", this.GetRes("CHANGE_PWD"));
                    }
                    strNav += String.Format(strF, "Charge.aspx", this.GetRes("ADD_POINT"));
                    strNav += String.Format(strF, "ChargeLog.aspx", this.GetRes("POINTCARD_QUERY"));
                    strNav += String.Format(strF, "PlayLog.aspx", this.GetRes("PLAY_QUERY"));
                }
                ltrUserCenterNav.Text = strNav;
            }
        }

        public void InitUserDetail() {
            if (this.ReLogin != 0 && this.UserID != 0) {
                StringBuilder sb = new StringBuilder();
                String strF = "<tr><td class=\"w1\">{0}: </td><td class=\"w2\">{1}</td></tr>";           
                sb.Append("<table>");
                UserData uda = (new User()).GetDetail(this.UserID);
                
                sb.Append(String.Format(strF, this.GetRes("Info_UserMask"), this.UserMask));
                sb.Append(String.Format(strF, this.GetRes("Info_UserName"), this.UserName));
               sb.Append(String.Format(strF, this.GetRes("Info_UserClass"),this.GroupClass));
               

                string strGroupName = "";
                int i = 0;
                foreach (GroupData gda in (new Group().GetListByUserGroupMask(this.GroupMask))) {
                    strGroupName += gda.GName + "<br/>";
                    i++;
                }
                sb.Append(String.Format(strF, this.GetRes("Info_UserGroup"), strGroupName));
               
                if (this.GetSession(UserHelper.SESSION_TYPE.CardValid).IndexOf("1900") == -1) {
                    sb.Append(String.Format(strF, this.GetRes("Info_UserCardValid"), Session[UserHelper.SESSION_TYPE.CardValid]));
                }
             
                if (this.GetSession(UserHelper.SESSION_TYPE.CardType) != "2") {
                    sb.Append(String.Format(strF, this.GetRes("Info_UserPoint"), uda.UPoint));
                    if (!String.IsNullOrEmpty(uda.UInfo)) {
                        sb.Append(String.Format(strF, this.GetRes("Info_UserInfo"), uda.UInfo));
                    }
                }
                sb.Append(String.Format(strF, this.GetRes("Info_UserRequestIp"), Request.UserHostAddress));
                sb.Append("</table>");
                ltrUserDetail.Text = sb.ToString();  

            }


        }




    }
}
