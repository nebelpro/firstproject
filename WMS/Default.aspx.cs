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

using MOD.WebUtility;
using MOD.BLL;
using MOD.Model;

namespace MOD.UI.WMS {
    public partial class Default : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            this.Title = this.GetRes("Info_WMS");
            
            rptWMS.DataSource= (new Channel()).GetList((Int32)Define.CHANNEL_SHOW.IPTV,2,1,100,
                (Int32)Define.CHANNEL_ADDRESS_TYPE.WMS,true);
            rptWMS.DataBind();
        }



        protected void rptWMS_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Repeater rptAddress = (Repeater)e.Item.FindControl("rptAddress");                
                //找到分类Repeater关联的数据项 
                ChannelData cha = (ChannelData)e.Item.DataItem;
                IList<ChannelAddressData> addList = new List<ChannelAddressData>();
                foreach (ChannelAddressData address in (new Channel()).GetAddress(cha.CId)) {
                    if (address.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.WMS) {
                        addList.Add(address);
                    }
                }
                rptAddress.DataSource = addList;
                rptAddress.DataBind();
            }
        }
    }
}
