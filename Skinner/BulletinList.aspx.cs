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
    public partial class BulletinList : STPage {
        protected void Page_Load( object sender, EventArgs e ) {
            Response.Write(this.PageBulletinList());
            Response.End();
        }
    }
}
