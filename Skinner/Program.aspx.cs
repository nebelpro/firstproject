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

namespace MOD.UI.SkinFactory {
    public partial class ProgramVideo : STPage {
        protected void Page_Load( object sender, EventArgs e ) {
            //Session["GroupClass"] = 255;
            //Session["GroupMask"] = 1;
            
            Response.Write(this.PageDefault());
        }
    }
}
