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

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_ProgramTop : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            //绑定热播节目列表
            rptPopList.DataSource = (new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, 1, 20, (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC);//GetTopPlay(20, this.GroupClass, this.GroupMask);
            rptPopList.DataBind();
        }
    }
}