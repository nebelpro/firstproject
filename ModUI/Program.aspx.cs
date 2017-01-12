using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using MOD.WebUtility;
using MOD.BLL;
using MOD.Model;


namespace MOD.UI {
    public partial class ProgramVideo : MOD.WebUtility.UI.Page {

        public void Page_Init( object sender, EventArgs e ) {
            this.Page.Title = Res.GetProductName();
        }

        protected void Page_Load( object sender, EventArgs e ) {
          
        }

    }
}
