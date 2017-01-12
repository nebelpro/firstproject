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
    public partial class UC_BulletinList : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                if ((new Permit()).CanBulletinMng()) {
                    ltrOper.Text = "<a href=\"#\" onclick=\"openwndex('addBulletin.aspx','" + this.GetRes("Oper_BulletinAdd") + "',560,210);return false;\">" + this.GetRes("Oper_BulletinAdd") + "</a>";
                }
            }


            Int32 nPage = this.GetIntParam("page", 1);
            Bulletin bl = new Bulletin();
            Int32 nPageCount = bl.GetCount();
            if (nPageCount != 0) {
                ltrListTop.Text=ltrListBtm.Text = WebHelper.PageList("BulletinList.aspx", nPageCount, nPage, UC_Helper.PAGE_BULLETIN_SIZE);
                rptBullist.DataSource = bl.GetList(nPage, UC_Helper.PAGE_BULLETIN_SIZE);
                rptBullist.DataBind();
            } else {
                ltrEmpty.Text = UC_Helper.ListEmpty;
            }
        }


       
    }
}