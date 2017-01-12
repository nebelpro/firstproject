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


namespace MOD.WebTd
{
    public partial class SearchResult : MOD.WebUtility.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = this.GetRes("INFO_SEARCH_RESULT");

           
        }
    }
}