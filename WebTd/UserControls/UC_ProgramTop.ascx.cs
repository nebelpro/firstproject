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
    public partial class UC_ProgramTop : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            IList<ProgramData> pdList = (new BLL.Program()).GetTopPlay(10, this.GroupClass, this.GroupMask);
            if (pdList.Count != 0) {
                rptPopList.DataSource = pdList;
                rptPopList.DataBind();
            }
        }
    }
}