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
using MOD.WebUtility;
namespace MOD.WebTd.UserControls {
    public partial class Uc_SoftDown : System.Web.UI.UserControl {

        public String strDirectx9, strMiniPlayer;
        protected void Page_Load(object sender, EventArgs e) {
           
           strDirectx9 = Res.GetValue("DOWN_DIRECTX9");
           strMiniPlayer = MOD.WebUtility.Res.GetValue("DOWN_MINIPLAY");
        }

    }
}