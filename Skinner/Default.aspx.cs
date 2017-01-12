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
using MOD.WebUtility;

namespace MOD.UI.SkinFactory {
    public partial class Default : MOD.WebUtility.UI.Page {
        public string strGoUrl = "";

        protected void Page_Load( object sender, EventArgs e ) {
            Product product = new Product();

            if (product.Module_Program) {
                strGoUrl = "Program.aspx";
            } else if (product.Module_Iptv) {
                strGoUrl = "Iptv.aspx";
            } else if (product.Module_Recorder) {
                strGoUrl = "Recorder.aspx";
            }

            
        }
    }
}
