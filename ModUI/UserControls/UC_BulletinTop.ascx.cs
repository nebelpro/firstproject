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

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_BulletinTop : MOD.WebUtility.UI.UserControl {
        protected void Page_Init( object sender, EventArgs e ) {
            IList<BulletinData> bullist = (new Bulletin()).GetList(1, 5);
            if (bullist.Count != 0) {
                rptBullist.DataSource = bullist;
                rptBullist.DataBind();
            }
        }
        protected void Page_Load( object sender, EventArgs e ) {
            
        }
    }
}