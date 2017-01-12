using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MOD.WebUtility.UI {
    public class Page : System.Web.UI.Page {

        protected override void OnInit( EventArgs e ) {
            //  this.EnableViewState = false;
            base.OnInit(e);
        }
        /// <summary>
        /// 用户的GroupMask
        /// </summary>
        /// <value>The group mask.</value>
        public Int32 GroupMask {
            get { return GetSession("GroupMask", 0); }
        }
        /// <summary>
        /// 用户的GroupClass
        /// </summary>
        /// <value>The group class.</value>
        public Int32 GroupClass {
            get { return GetSession("GroupClass", 0); }
        }
        public String UserMask {
            get { return GetSession(UserHelper.SESSION_TYPE.UserMask); }
        }
        public String UserName {
            get { return GetSession(UserHelper.SESSION_TYPE.UserName); }
        }
        public Int32 UserID {
            get { return GetSession(UserHelper.SESSION_TYPE.UserId, 0); }
        }
        public Int32 ReLogin {
            get { return GetSession(UserHelper.SESSION_TYPE.ReLogin, 0); }
            set { Session[UserHelper.SESSION_TYPE.ReLogin] = value; }
        }
        public Int32 DefaultCatalog {
            get { return GetSession(MOD.BLL.SETTING_TYPE.KEY_DEFAULT_CATALOG, 21); }
            set { Session[MOD.BLL.SETTING_TYPE.KEY_DEFAULT_CATALOG] = value; }
        }
        public Int32 DefaultUser {
            get { return GetSession(MOD.BLL.SETTING_TYPE.KEY_DEFAULTUSER, 0); }
            set { Session[MOD.BLL.SETTING_TYPE.KEY_DEFAULTUSER] = value; }
        }
        protected String GetSession( string strkey ) {

            return WebHelper.GetSession(strkey);
        }

        protected Int32 GetSession( string strkey, int nDefaultNum ) {
            return WebHelper.GetSession(strkey, nDefaultNum);
        }


        /// <summary>
        /// 获取资源文件
        /// </summary>
        /// <param name="strKey">关键字</param>
        /// <returns></returns>
        protected string GetRes( String strKey ) {
            return Res.GetValue(strKey);
        }


        /// <summary>
        /// Gets the string param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        protected string GetStringParam( string paramName, string errorReturn ) {
            return WebHelper.GetStringParam(Request, paramName, errorReturn);
        }

        /// <summary>
        /// Gets the int param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        protected int GetIntParam( string paramName, int errorReturn ) {
            return WebHelper.GetIntParam(Request, paramName, errorReturn);
        }

        /// <summary>
        /// Gets the date time param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        protected DateTime GetDateTimeParam( string paramName, DateTime errorReturn ) {
            return WebHelper.GetDateTimeParam(Request, paramName, errorReturn);
        }

        protected String SubText( string text, int maxLength ) {
            return WebHelper.SubText(text, maxLength, "");
        }
        protected String SubText( string text, int maxLength, String replace ) {
            return WebHelper.SubText(text, maxLength, replace);
        }
        protected String SubMixText( string text, int maxLength ) {
            return WebHelper.SubMixText(text, maxLength, "");
        }
        protected String SubMixText( string text, int maxLength, String replace ) {
            return WebHelper.SubMixText(text, maxLength, replace);
        }

        /// <summary>
        /// 1.可以用于文本内容输入时替换特殊的ＨＴＭＬ字符，在ｈｔｍｌ输出时用TextOut 替换输出
        /// 2.如果文本输入内容没有替换就插入数据库，可用该函数处理并在ｈｔｍｌ上正确显示
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected String TextIn( String text ) {
            return WebHelper.TextIn(text);
        }

        /// <summary>
        /// 在ｈｔｍｌ输出时用TextOut 替换输出,可以用于文本内容输入时替换特殊的ＨＴＭＬ字符
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected String TextOut( String text ) {
            return WebHelper.TextOut(text);
        }
    }
}
