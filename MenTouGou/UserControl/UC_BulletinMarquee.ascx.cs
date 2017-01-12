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

namespace mentougou.UserControl {
    public partial class UC_BulletinMarquee : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                IList<BulletinData> bullist = (new Bulletin()).GetList(1, 6);
                if (bullist.Count == 0) {

                } else {
                    rptBulletin.DataSource = bullist;
                    rptBulletin.DataBind();
                }
            }
        }
    }
}