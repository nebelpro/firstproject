using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace mentougou {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start( object sender, EventArgs e ) {

        }
        protected void Session_Start( object sender, EventArgs e ) {
            (new MOD.WebUtility.WebConfig()).InitDbSetting();
            MOD.WebUtility.UserHelper.SetUserSession("", "", 2, 0, 0, 0, 0, 0, DateTime.Now);
            MOD.WebUtility.SettingHelper.SetSetting();
            Helper.SettingScroll();
        }

        protected void Application_End( object sender, EventArgs e ) {

        }
    }
}