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

using System.IO;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;
namespace MOD.WebTd {
    public partial class MasterPage : MOD.WebUtility.UI.MasterPage {
        protected void Page_Load( object sender, EventArgs e ) {
            Toper1.Logo = "Images/depend/mod_logo.gif";
            Toper1.Info_Setting = (new Helper()).BindModule(1);  
        }
    }
}