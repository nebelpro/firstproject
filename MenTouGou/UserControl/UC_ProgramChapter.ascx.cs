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
    public partial class UC_ProgramChapter : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                BindChapterList();
            }
        }

        public void BindChapterList() {
            Int32 nPid = this.GetIntParam("pid", 0);
            IList<ChapterData> chpList = (new Program()).GetChapterByProgramId(nPid);
            if (chpList.Count != 0) {
                rptChapterList.DataSource = chpList;
                rptChapterList.DataBind();                
            } 

        }

        protected void rptChapterList_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Literal ltrChapterPlay = (Literal)e.Item.FindControl("ltrChapterPlay");
                Literal ltrChapterDown = (Literal)e.Item.FindControl("ltrChapterDown");
                
                ChapterData chdta = (ChapterData)e.Item.DataItem;
                ProgramData pda = (new Program()).GetDetail(chdta.PcProgramId);
                ltrChapterPlay.Text = "<a href=\"#\" onclick=\"javascript:"+ProgramHelper.GetPlayUrl(chdta.PcProgramId,0,chdta.PcOrder)+"\">"+GetRes("Info_ChapterPlay")+"</a>";


                ltrChapterDown.Text = ProgramHelper.Download(pda.PId, 0, chdta.PcId);
                
               
            } 
        }
    }
}