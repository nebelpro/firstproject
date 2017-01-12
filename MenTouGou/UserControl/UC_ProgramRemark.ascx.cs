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

namespace mentougou.UserControl {
    public partial class UC_ProgramRemark : MOD.WebUtility.UI.UserControl {

        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                GetProgramRemark();
            }
        }


        public void GetProgramRemark() {
            Int32 nPId = this.GetIntParam("pid", 0);
            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nPageCount = (new Remark()).GetCountByProgram(nPId, 1);
            if (nPageCount != 0) {  
                String strOnclick = "ProgramInfo.aspx?pid="+nPId+"";
                ltrListTop.Text = ltrListBtm.Text = WebHelper.PageList(strOnclick, nPageCount, nPage, UC_Helper.PAGE_PROGRAMREMARKLIST_SIZE);
                rptRemarkList.DataSource = (new Remark()).GetListByProgram(nPId, -1, nPage, UC_Helper.PAGE_PROGRAMREMARKLIST_SIZE);
                rptRemarkList.DataBind();                
            } else {                
                ltrEmpty.Text = UC_Helper.ListEmpty;
            }
           
        }
    }
}