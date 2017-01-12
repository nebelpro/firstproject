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
    public partial class Weige : MOD.WebUtility.UI.Page {
        protected void Page_Init( object sender, EventArgs e ) {

            Toper1.Logo = "Images/depend/mod_logo.gif";
            Toper1.Info_Setting = (new Helper()).BindModule(4);
        }

        protected void Page_Load( object sender, EventArgs e ) {
            if (!(new Permit()).CanWeigeReceive()) {
                Response.Redirect("Default.aspx");
            }

            Int32 nView = this.GetIntParam("v", -1);
            Int32 nOrder = this.GetIntParam("s", -1);
            if (nView != -1) {
                Session[SETTING_TYPE.KEY_WEIGE_VIEW] = nView;
            }
            if (nOrder != -1) {
                Session[SETTING_TYPE.KEY_WEIGE_SORT] = nOrder;
            }


        }
    }
}
