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
    public partial class UC_CatalogView : MOD.WebUtility.UI.UserControl {

        protected void Page_Init( object sender, EventArgs e ) {
            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);
            Catalog CataBll = new Catalog();
            if (nCatalogId != this.DefaultCatalog) {
                if (CataBll.GetNeedCatalog(nCatalogId, this.DefaultCatalog) == -1) {
                    nCatalogId = this.DefaultCatalog;
                }
            }

            IList<CatalogData> subList = CataBll.GetList(nCatalogId, 0);
            if (subList.Count != 0) {
                rptCatalogList.DataSource = subList;
                rptCatalogList.DataBind();
                pnlCatalog.Visible = true;

            } else {
                pnlCatalog.Visible = false;
            }          
            


        }

        protected void Page_Load( object sender, EventArgs e ) {

        }
    }
}