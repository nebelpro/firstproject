using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MOD.UI.WMS {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start( object sender, EventArgs e ) {

        }

        protected void Application_End( object sender, EventArgs e ) {

        }

        protected void Session_Start( object sender, EventArgs e ) {
            // get webconfig.ini dbsetting
            (new WebUtility.WebConfig()).InitDbSetting();
            MOD.WebUtility.UserHelper.SetUserSession("","", 2, 0, 0, 0, 0, 0, DateTime.Now);
            MOD.WebUtility.SettingHelper.SetSetting();

        }
        protected void Session_End( object sender, EventArgs e ) {

        }
    }
}