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

namespace MOD.UI {
    public partial class SoftDown : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            ltrSetting.Text = (new Helper()).BindModule(0);

            if ((new MOD.BLL.Permit()).CanMngUser()) {
                ltrSoftManager.Text=" <li class=\"w1\" style=\"border-bottom:0;\"><img src=\"Images/nodepend/m_icon_sd_3.gif\" alt=\"\" /></li>"+
                    "<li class=\"w2\" style=\"border-bottom:0;\">"+
                        "<h3><img src=\"Images/nodepend/m_star.gif\" alt=\"\" />"+this.GetRes("Info_Manager")+"</h3>"+
                        "<p><script type=\"text/javascript\">GetVersion(4,'"+Session["MNVer"]+"')</script> <br />"+
                        this.GetRes("Info_ManagerIntro")+"<span><a href=\"Manager/Setup/Manager.exe\"><img src=\"Images/depend/btn_down.gif\" alt=\"\" /></a></span>"+"</p></li>";

            }
        }
    }
}
