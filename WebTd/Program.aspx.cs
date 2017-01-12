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

using System.IO;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.WebTd
{
    public partial class ProgramVideo : MOD.WebUtility.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Res.GetProductName();
           
            
           
            IList<ProgramData> pdNewList = (new BLL.Program()).GetList(-1, 1, this.GroupClass, this.GroupMask, 1, 5, (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
            if (pdNewList != null && pdNewList.Count != 0) {
                rptNew.DataSource = pdNewList;
                rptNew.DataBind();
            }
            IList<ProgramData> pdHotList = (new BLL.Program()).GetList(-1, 1, this.GroupClass, this.GroupMask, 1, 15, (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC);
            if (pdHotList != null && pdHotList.Count != 0) {
                rptPop.DataSource = pdHotList;
                rptPop.DataBind();
            }

        }      
    }
}