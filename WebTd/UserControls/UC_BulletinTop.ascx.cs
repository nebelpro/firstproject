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

namespace MOD.WebTd.UserControls {
    public partial class UC_BulletinTop :MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            IList<BulletinData> bdList = (new BLL.Bulletin()).GetList(1, 10);
            if (bdList.Count != 0) {
                rptBullist.DataSource = bdList;
                rptBullist.DataBind();
            }
        }
    }
}