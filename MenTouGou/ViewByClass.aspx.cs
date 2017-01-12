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

namespace mentougou {
    public partial class ViewByClass : MOD.WebUtility.UI.Page {

        protected void Page_Init( object sender, EventArgs e ) {
            Int32 nCatalogId = this.GetIntParam("cid", 21);
            if (nCatalogId <= 21) {
                Response.Redirect("Default.aspx");
            }

            IList<CatalogData> subList = (new Catalog()).GetList(nCatalogId, 0);
            if (subList.Count != 0) {
                rptCatalogList.DataSource = subList;
                rptCatalogList.DataBind();
                pnlCatalog.Visible = true;

            } else {
                pnlCatalog.Visible = false;
            }
            this.Page.Title = this.GetRes("Info_CatalogView");
            String strUrlFormat = "<a href=\"ViewByClass.aspx?cid={0}\">{1}</a>";

            CatalogData cata = (new Catalog()).GetDetail(nCatalogId);
            if (cata.CParentId > 21) {
                this.Master.CurPath = ProgramHelper.GetCatalogStepByCId(nCatalogId, strUrlFormat, cata.CParentId);
            } else {
                this.Master.CurPath = " / " + cata.CName;
            }


        }

        protected void Page_Load( object sender, EventArgs e ) {
            
        }
    }
}
