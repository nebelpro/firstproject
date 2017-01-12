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
namespace mentougou.UserControl {
    public partial class UC_ProgramList : MOD.WebUtility.UI.UserControl {
        

        protected void Page_Load( object sender, EventArgs e ) {

            Int32 nPage = WebHelper.GetRequest("page", 1);
            Program prmbll = new Program();
            int nGroupMask = WebHelper.GetSession("GroupMask", 0);
            int nGroupClass = WebHelper.GetSession("GroupClass", 0);
            Int32 nPrmCount = 0;
            string strPageUrl = WebHelper.GetShowUrl();
            IList<ProgramData> prmlist = new List<ProgramData>();

            if (strPageUrl.ToLower() == "viewbyclass.aspx") {                
                Int32 nCatalogId = WebHelper.GetRequest("cid", 21);             
                nPrmCount = prmbll.GetCount(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,nGroupClass,  nGroupMask);
                strPageUrl = strPageUrl + "?cid=" + nCatalogId.ToString();                
                prmlist = prmbll.GetList(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, nGroupClass, nGroupMask, nPage, UC_Helper.PAGE_PROGRAMLIST_TWO_SIZE, (int)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
               
            } else if (strPageUrl.ToLower() == "searchresult.aspx") {               
                string strKey = WebHelper.GetRequest("key");
                nPrmCount = prmbll.SearchCount(strKey, 6, nGroupClass, nGroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,this.DefaultCatalog);
                strPageUrl = strPageUrl + "?key=" + strKey;                
                prmlist = prmbll.Search(strKey, 6, nGroupClass, nGroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,
                    nPage, UC_Helper.PAGE_PROGRAMLIST_TWO_SIZE,(Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC,this.DefaultCatalog);               
            }

            if (nPrmCount != 0) {
                ltrListBtm.Text = ltrListTop.Text = String.Format(UC_Helper.ListBar, "", WebHelper.PageList(strPageUrl, nPrmCount, nPage, UC_Helper.PAGE_PROGRAMLIST_TWO_SIZE));
                rptProgramList.DataSource = prmlist;
                rptProgramList.DataBind();
            } else {
                ltrEmpty.Text = UC_Helper.ListEmpty;
            }
        }

    }
}