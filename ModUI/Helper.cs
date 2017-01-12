using System;
using System.Data;
using System.Configuration;
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

namespace MOD.UI
{
    public class Helper:MOD.WebUtility.UI.Page {

        #region  List Size
        public const Int32 PAGE_BULLETIN_SIZE = 6;
        public const Int32 PAGE_LOG_SIZE = 10;
        public const Int32 PAGE_CARDLIST_SIZE = 10;
        public const Int32 PAGE_CARDUSRLIST_SIZE = 10;
        public const Int32 PAGE_USERLIST_SIZE = 10;
        public const Int32 PAGE_GROUPLIST_SIZE = 10;
        public const Int32 PAGE_CHANNELLIST_SIZE = 10;

        public const Int32 PAGE_PROGRAMLIST_SIZE = 12;
        public const Int32 PAGE_PROGRAMLIST_ONE_SIZE = 12;
        public const Int32 PAGE_PROGRAMLIST_TWO_SIZE = 25;
        public const Int32 PAGE_PROGRAMLIST_THREE_SIZE = 15;

        public const Int32 PAGE_REMARKLIST_SIZE = 5;
        public const Int32 PAGE_CATALOGLIST_SIZE = 15;
        public const Int32 PAGE_GUESTBOOKLIST_SIZE = 6; 
        #endregion 

        public const string ListEmpty = "<div id=\"empty\"><img src=\"Images/depend/empty.gif\" /></div>";
        //public const string ListEmpty = "<div id=\"empty\"></div>";
        public const string ListBar = "<div class=\"ListBar\"><div class=\"left\">{0}</div><div class=\"right\">{1}</div></div>";
        
        
        
        
        public static string GetItemString(Int32 nCount)
        {
            return nCount < 10 ? "0" + nCount.ToString() : nCount.ToString();
        }


        public void BindChannelRpt( Int32 nType, Repeater rptList ) {
            rptList.DataSource = (new Channel()).GetList(nType, this.GroupMask, 1, 100, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
                rptList.DataBind(); 
        }

        public String BindModule(int iMark) {
            
            String strFormat = "<li><a href=\"{0}\"><img src=\"Images/depend/{1}\" alt=\"\" /></a></li>";
            Product product = new Product();
           
            String strRet = "";
            Int32 i = 0;

            if (product.Module_Program) {
                if (iMark == 1) {
                    strRet += string.Format(strFormat, "Program.aspx", "programhot.gif");
                } else {
                    strRet += string.Format(strFormat, "Program.aspx", "program.gif");
                }
                i++;
            }
            if (product.Module_Iptv) {
                if (iMark == 2) {
                    strRet += string.Format(strFormat, "Iptv.aspx", "iptvhot.gif");
                } else {
                    strRet += string.Format(strFormat, "Iptv.aspx", "iptv.gif");
                }
                i++;
            }
            if (product.Module_Recorder) {
                if (iMark == 3) {
                    strRet += string.Format(strFormat, "Recorder.aspx", "recorderhot.gif");
                } else {
                    strRet += string.Format(strFormat, "Recorder.aspx", "recorder.gif");
                }                
                i++;
            }
            if (product.Module_Weige) {
                if (iMark == 4) {
                    strRet += string.Format(strFormat, "Weige.aspx", "weigehot.gif");
                } else {
                    strRet += string.Format(strFormat, "Weige.aspx", "weige.gif");
                }
                i++;
            }

            if (i > 1) {
                return "<ul id=\"module\">" + strRet + "</ul>";
            } else {
                return "";
            }

        }

        public static string GetOrderInfo( Int32 nSort, Int32 cId ) {

            string strOrder = "";
            string OrderFormat0 = "<img src=\"Images/depend/{0}\" alt=\"\"/>";
            string OrderFormat = "<a href=\"ViewByClass.aspx?cid=" + cId + "&sort={0}\"><img src=\"Images/depend/{1}\" alt=\"\"/></a>";
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC) {
                strOrder = string.Format(OrderFormat0, "sort_time_sel.gif");
            } else {
                strOrder = string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC, "sort_time.gif");
            }
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.NAME_DESC) {
                strOrder += string.Format(OrderFormat0, "sort_name_sel.gif");
            } else {
                strOrder += string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.NAME_DESC, "sort_name.gif");
            }
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC) {
                strOrder += string.Format(OrderFormat0, "sort_play_sel.gif");
            } else {
                strOrder += string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC, "sort_play.gif");
            }

            strOrder = "<span class=\"order\">" + strOrder + "</span>";

            return strOrder;

        }

        public static String WeigeViewSelected( int VmValue ) {
            if (WebHelper.GetSession(MOD.BLL.SETTING_TYPE.KEY_WEIGE_VIEW, 1) == VmValue) {
                return "selected=\"selected\"";
            }
            return string.Empty;
        }

        public static String WeigeSortSelected( Int32 VmSort ) {
            if (WebHelper.GetSession(MOD.BLL.SETTING_TYPE.KEY_WEIGE_SORT, 0) == VmSort) {
                return "selected=\"selected\"";
            }
            return string.Empty;
        }


       
    }

    



    /*
    public class CatalogRepeater: System.Web.UI.Page {
        private string strItem="";
        private string strFormat = "<li>{0}</li>";
        Repeater rpt = new Repeater();
        public  CatalogRepeater() {
           
            TemplateBuilder rptHeader = new TemplateBuilder();
            TemplateBuilder rptItem = new TemplateBuilder();
            TemplateBuilder rptFooter = new TemplateBuilder();
            rptHeader.AppendLiteralString("<ul>");
            rptItem.AppendLiteralString(strItem);
            rptFooter.AppendLiteralString("</ul>");

            rpt.HeaderTemplate = rptHeader;
            rpt.ItemTemplate = rptItem;
            rpt.FooterTemplate = rptFooter;            
            rpt.ItemDataBound +=new RepeaterItemEventHandler(rpt_ItemDataBound);
            rpt.ItemCreated += new RepeaterItemEventHandler(rpt_ItemCreated);
            rpt.DataSource = (new Catalog()).GetList(21, 11);
            rpt.DataBind();
        }
        public string GetString() {
            return WebHelper.GetStringByControl(rpt);
        }

        private void rpt_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item) {
                //   
            }
        }

        private void rpt_ItemCreated( object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item) {
                CatalogData cat = (CatalogData)e.Item.DataItem;
                LiteralControl lc = new LiteralControl(cat.CName);
                e.Item.Controls.Add(lc);
                strItem = string.Format(strFormat, lc.Text);
            }
        }   
    }*/




  
}
