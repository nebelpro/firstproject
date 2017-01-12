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
    public partial class UC_CatalogNav : MOD.WebUtility.UI.UserControl {
        protected void Page_Init( object sender, EventArgs e ) {
            IList<CatalogData> catalist = (new Catalog()).GetList(this.DefaultCatalog, 11);
            rptNavBar.DataSource = catalist;
            rptNavBar.DataBind();
        }
        protected void Page_Load( object sender, EventArgs e ) {

        }
        public string SetHotColor( string strCId ) {
            string temp = string.Empty;
            if (this.GetStringParam("cid", "") != string.Empty) {
                if (this.GetStringParam("cid", "") == strCId) {
                    temp = "class=\"selected\"";
                }
            }
            return temp;
        }

        protected void rptNavBar_ItemDataBound( Object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Repeater rptList = (Repeater)e.Item.FindControl("rptSubCatalogList");               
                
                CatalogData catalog = (CatalogData)e.Item.DataItem;
               
                IList<CatalogData> subList = (new Catalog()).GetList(catalog.CId, 0);
                if (subList.Count != 0) {
                    rptList.DataSource = subList;
                    rptList.DataBind();
                }
            }

        }
        public String SetNavStyle(Int32 rptCount) {
            if (rptCount == 0) {
                return " style=\"border:0;\" ";
            } else {
                return "";
            }
        }

    }
}