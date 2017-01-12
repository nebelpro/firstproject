using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace mentougou {
    public class Helper:MOD.WebUtility.UI.Page {
        public static int GetProgramCountByCatalogId( Int32 nCatalogId ) {
              int nGroupMask = WebHelper.GetSession("GroupMask", 0);
            int nGroupClass = WebHelper.GetSession("GroupClass", 0);

            return (new Program()).GetCount(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, nGroupClass, nGroupMask);
        }

        public static String GetNewTip(Int32 nProgramId) {
            int nGroupMask = WebHelper.GetSession("GroupMask", 0);
            int nGroupClass = WebHelper.GetSession("GroupClass", 0);
            Program prmBll = new Program();
            DateTime TpDate=DateTime.Now;
            IList<ProgramData> prolist = prmBll.GetTopNew(20, nGroupClass, nGroupMask);
            if (prolist.Count != 0) TpDate =((ProgramData)prolist[prolist.Count - 1]).PAddTime;
            ProgramData pda = prmBll.GetDetail(nProgramId);
            if (pda.PAddTime > WebHelper.FormatDateTime(TpDate, 0)) {
                return "new";
            } else {
                return "";
            }
        }

        public static String GetHotTip(Int32 nProgramId) {
            int nGroupMask = WebHelper.GetSession("GroupMask", 0);
            int nGroupClass = WebHelper.GetSession("GroupClass", 0);
            Program prmBll = new Program();
            Int32 TpCount = 10;
            IList<ProgramData> prolist = prmBll.GetTopPlay(20, nGroupClass, nGroupMask);
            if (prolist.Count != 0) TpCount = ((ProgramData)prolist[prolist.Count - 1]).PReadCount;
            ProgramData pda = prmBll.GetDetail(nProgramId);
            if (pda.PReadCount > TpCount) {
                return "<img src=\"images/nodepend/hot.gif\" alt=\"\"/>";
            } else {
                return "";
            }
        }



        public static string GetEditUrl( string bid, string strName ) {
            if ((new Permit()).CanBulletinMng()) {
                return "<a href=\"#\" onclick=\"openwndex('addBulletin.aspx?bid=" + bid + "','" +Res.GetValue("Oper_BulletinEdit") + "',560,210);return false;\">" + WebHelper.SubMixText(strName, 64, "") +"</a>";
            } else {
                return WebHelper.SubMixText(strName, 64,"");
            }
        }

        /// <summary>
        /// Settings the scroll.
        /// </summary>
        public static void SettingScroll(){           
            Setting stBll = new Setting();
            stBll.GetValue("count", "0");
            stBll.GetValue("ScrollTime", DateTime.MinValue.ToString());
            DateTime dtNew = GetDtNew();        
            stBll.GetValue("newTime",dtNew.ToString());
        }

        public static DateTime GetDtNew() {
            IList<ProgramData> pdaList = (new Program()).GetTopNew(1, 255, 1);
            DateTime dtNew = DateTime.MinValue;
            if (pdaList.Count != 0) {
                dtNew = pdaList[0].PAddTime;
            }
            return dtNew;
        }

    }
}
