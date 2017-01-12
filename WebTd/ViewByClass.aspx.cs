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

namespace MOD.WebTd {
    public partial class ViewByClass : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nId = this.GetIntParam("cid", 0);
            if (nId == 0) Response.Redirect("Default.aspx");
            CatalogData cd = (new Catalog()).GetDetail(nId);
            if (cd == null) Response.Redirect("Default.aspx");
            Page.Title = cd.CName;
            string strFormat = "<a href=\"ViewByClass.aspx?cid={0}\">{1}</a> ";
            lbPosi.Text = ProgramHelper.GetCatalogStepByCId(nId, strFormat);

        }
    }
}