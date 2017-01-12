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
using System.Text;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_ProgramNewView : MOD.WebUtility.UI.UserControl {
        private readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);

        protected void Page_Load( object sender, EventArgs e ) {
            ltrCatalogProgram.Text = GetTopNewGroupByCataLog();
        }

        public string GetTopNewGroupByCataLog() {
            if (enableCaching&&HttpRuntime.Cache["GetTopNewGroupByCataLog"] != null) {
                return (String)HttpRuntime.Cache["GetTopNewGroupByCataLog"];
            } else {

                StringBuilder sb = new StringBuilder();
                sb.Append("<table>");
                SortedList SortList = new SortedList();
                IList<ProgramData> prmlist = (new Program()).GetTopNewGroupByCataLog(this.GroupClass, this.GroupMask);

                #region ===归类节目
                IEnumerator myEnum = prmlist.GetEnumerator();
                while (myEnum.MoveNext()) {
                    ProgramData pda = (ProgramData)myEnum.Current;
                    pda.PMediaKind = (new Catalog()).GetNeedCatalog(pda.PMediaKind, this.DefaultCatalog);
                    if (pda.PMediaKind != -1) {
                        IList<ProgramData> psort = new List<ProgramData>();

                        if (SortList.Contains(pda.PMediaKind)) {
                            psort = (IList<ProgramData>)SortList[pda.PMediaKind];
                            psort.Add(pda);
                            SortList.Remove(pda.PMediaKind);
                        } else {
                            psort.Add(pda);
                        }
                        SortList.Add(pda.PMediaKind, psort);
                    }

                }
                #endregion 

                #region  ===转为了页面字符
                for (int i = 0; i < SortList.Count; i++) {
                    Int32 nCatalogID = (Int32)SortList.GetKey(i);
                    IList<ProgramData> pList = (IList<ProgramData>)SortList.GetByIndex(i);
                    if ((new Catalog()).GetDetail(nCatalogID) != null) {
                        sb.Append("<tr><td class=\"cataname\"><a href=\"ViewByClass.aspx?cid=" + nCatalogID.ToString() + "\">" +
                            (new Catalog()).GetDetail(nCatalogID).CName + "</a></td> <td class=\"cataprolst\">");
                    }
                    foreach (ProgramData pda in pList) {
                        sb.Append("<a href=\"ProgramInfo.aspx?pid=" + pda.PId.ToString() + "\">" + this.SubMixText(pda.PName, 12, "...") + "</a>");
                    }
                    sb.Append("</td></tr>");
                }
                sb.Append("</table>");                
                #endregion 
                if (enableCaching) {
                    HttpRuntime.Cache.Insert("GetTopNewGroupByCataLog", sb.ToString(),
                   null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                   new TimeSpan(0, 2, 0));
                }
                return sb.ToString();

            }
        }
    }
}