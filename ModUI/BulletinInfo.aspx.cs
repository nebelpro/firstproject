using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.Model;
using MOD.BLL;

namespace MOD.UI
{
    public partial class BulletinInfo : MOD.WebUtility.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            int bid = this.GetIntParam("bid",0);
            BulletinData bda = (new BLL.Bulletin()).GetBulletinByBid(bid);
            if (bda != null)
            {
                ltrName.Text = bda.BName;
                ltrInfo.Text = bda.BInfo;
                ltrAddTime.Text = bda.BAddtime.ToShortDateString() + " " + bda.BAddtime.ToLongTimeString();
                ltrUserName.Text = bda.BUserName;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
