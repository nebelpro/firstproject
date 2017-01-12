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
    public partial class UC_ProgramList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 nPageSize = 21;
            Int32 nId = this.GetIntParam("cid", 0);  
            Int32 nOrder = this.GetIntParam("sort", 0);
            lbSort.Text = Helper.GetOrderInfo(nOrder, nId);

            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nCount = (new BLL.Program()).GetCount(nId, 1, this.GroupClass, this.GroupMask);
            if (nCount != 0) {
                lbPage_Top.Text = lbPage_Bottom.Text = WebHelper.PageList("ViewByClass.aspx?cid=" + nId + "&sort=" + nOrder, nCount, nPage, nPageSize);

                IList<ProgramData> pdList = (new BLL.Program()).GetList(nId, 1, this.GroupClass, this.GroupMask, nPage, nPageSize, nOrder);
                if (pdList != null && pdList.Count != 0) {
                    rptPrmList.DataSource = pdList;
                    rptPrmList.DataBind();
                }
            } else {
                ltrEmpty.Text = Helper.ListEmpty;
            }

        }
    }
}