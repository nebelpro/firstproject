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
    public partial class UC_CatalogView : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nId = this.GetIntParam("cid", 0);
            IList<CatalogData> cdList = (new Catalog()).GetList(nId, 0);
            if (cdList != null && cdList.Count != 0) {
                ltSubCataList.Text = "<div id=\"subCatalogList\"><table>";
                IEnumerator cds = cdList.GetEnumerator();
                Int32 i = 0;
                while (cds.MoveNext()) {
                    CatalogData cdCur = (CatalogData)cds.Current;
                    if (i % 4 == 0) ltSubCataList.Text += "<tr>";
                    ltSubCataList.Text += "<td class=\"w1\"><img src=\"Images/nodepend/cataicon.gif\" /></td><td class=\"w2\"><a href=\"ViewByClass.aspx?cid=" + cdCur.CId + "\">" + cdCur.CName + "</a></td>";
                    if (i % 4 == 3)  ltSubCataList.Text += "</tr>";
                    i++;
                }
                if (((i - 1) % 4) != 3) {
                    Int32 nLeft = 4 - (i - 1) % 3;
                    ltSubCataList.Text += "<td colspan=" + (nLeft * 2) + ">&nbsp;</td></tr>";
                }
                ltSubCataList.Text += "</table></div>";
            } else {
                ltSubCataList.Text = "<div id=\"banner\"><img src=\"Images/depend/banner.gif\" alt=\"banner\" /></div>";
            }

        }
    }
}