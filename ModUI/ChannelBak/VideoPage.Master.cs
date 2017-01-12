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

namespace MOD.UI {
    public partial class VideoPage : MOD.WebUtility.UI.MasterPage {

        public String Logo {
            set { Toper1.Logo = value; }
        }
        public Int32 CastSort {
            set {
                if (value == 1) {// 1 iptv selected 
                    Toper1.Info_Setting = (new Helper()).BindModule(2);
                } else {
                    Toper1.Info_Setting = (new Helper()).BindModule(3);
                }

            }
        }

        protected void Page_Init( object sender, EventArgs e ) {            
        }

        protected void Page_Load( object sender, EventArgs e ) {

        }
    }
}
