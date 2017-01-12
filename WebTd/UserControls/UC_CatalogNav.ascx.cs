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

namespace MOD.WebTd.UserControls {
    public partial class UC_CatalogNav :MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {            
            rptNavBar.DataSource = (new Catalog()).GetList(21, 11);
            rptNavBar.DataBind();
        }        
        protected String SetHotColor( String strCId ) {
            string temp = "navnor";
            if (this.GetStringParam("cid","") == strCId) {
                temp = "navcur";
            }
            return temp;
        }
        public String SetSubHotColor( String strCId ) {
            string temp = "color:#2EAED5";
            if (WebHelper.GetRequest("subid") == strCId) {
                temp = "color:red;";
            }
            return temp;
        }
        public String SetNavStyle( Int32 rptCount ) {
            if (rptCount == 0) {
                return " style=\"background:none;\" ";
            } else {
                return "";
            }
        }
    }
}