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

using MOD.Model;
using MOD.BLL;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_ProgramNew : MOD.WebUtility.UI.UserControl {
        protected void Page_Init(object sender, EventArgs e){
              //绑定最新的节目
            rptNewList.DataSource = (new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, 1, 6, (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
            rptNewList.DataBind();
        }

        protected void Page_Load( object sender, EventArgs e ) {

        }
    }
}