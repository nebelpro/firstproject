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
    public partial class UserReg : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {

        }

        protected void ibtnAdd_Click( object sender, ImageClickEventArgs e ) {

            String strRegMask = tbRegMask.Text.Trim();
            String strRegName = tbRegName.Text.Trim();
            String strRegPwd = tbRegPwd.Text.Trim();
            String strConfirm = tbConfirm.Text.Trim();

            String strMsg = "";

            // 字符的检测
            if (strRegMask.Length == 0) {
                strMsg = this.GetRes("WARN_REG_NOLOGIN");
            } else if (strRegMask.Length > 32) {
                strMsg = this.GetRes("WARN_REG_OUTLEN");
            } else if (!WebHelper.QuickValidate("^\\w+$", strRegMask)) {
                strMsg = this.GetRes("WARN_REG_ERRDATA");
            } else if (strRegName.Length == 0) {
                strMsg = this.GetRes("WARN_REG_NOUSERNAME");
            } else if (strRegName.Length > 32) {
                strMsg = this.GetRes("WARN_REG_OUTLEN");
            } else if (!WebHelper.QuickValidate("^\\w+$", strRegName)) {
                strMsg = this.GetRes("WARN_REG_ERRDATA");
            } else if (strRegPwd != strConfirm) {
                strMsg = this.GetRes("WARN_REG_NOEQUALPWD");
            } else if (strRegPwd.Length != 0) {
                if (!WebHelper.QuickValidate("^\\w+$", strRegPwd)) {
                    strMsg = this.GetRes("WARN_REG_ERRDATA");
                }
            } else if (tbRegInfo.Text.Length > 1024) {
                strMsg = this.GetRes("WARN_REG_OUTINFOLEN");
            }

            if (strMsg != "") {
                WebHelper.MsgBox(strMsg, true, "UserReg.aspx?rnd=" + DateTime.Now.Ticks.ToString());
            } else // 字符形式检测通过，进行插入，并检查 逻辑错误
            {
                UserData ud = new UserData();
                ud.UMask = strRegMask;
                ud.UName = strRegName;
                ud.UPasswd = strRegPwd;
                ud.UInfo = tbRegInfo.Text;

                Int32 nRet = (new User()).Register(ud);

                if (nRet == (int)BLL.User.ENUM_RET_REGISTER.RET_SUCCESS) {
                    Response.Write("<script>alert('" + this.GetRes("WARN_REG_REGOK") + "'); parent.self.close();</script>");
                } else if (nRet == (int)BLL.User.ENUM_RET_REGISTER.RET_EXIST) {
                    WebHelper.MsgBox(this.GetRes("WARN_REG_EXISTLOGIN"), true, "UserReg.aspx?rnd=" + DateTime.Now.Ticks.ToString());
                } else if (nRet == (int)BLL.User.ENUM_RET_REGISTER.RET_FAILD_PRIVATE_FOLD) {
                    WebHelper.MsgBox(this.GetRes("WARN_REG_FALID_PRIVATE_FLOD"), true, "UserReg.aspx?rnd=" + DateTime.Now.Ticks.ToString());
                }


            }

        }
    }
}
