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

namespace MOD.Admin.UserControls
{
    public partial class UC_SysSetSystem : MOD.WebUtility.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*                      
            <option value="3" <%=MOD.Admin.Helper.ViewModelSelected(3) %>><%=GetRes("Info_SysViewIcon") %></option>
            */
        }

       
    }
}