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
    public partial class UC_ProgramChater : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {            
            int nPid = this.GetIntParam("pid",0);
            IList<ChapterData> cdList = (new BLL.Program()).GetChapterByProgramId(nPid);
            if (cdList != null && cdList.Count != 0) {
                rptChapter.DataSource = cdList;
                rptChapter.DataBind();
            }
        }       
    }
}