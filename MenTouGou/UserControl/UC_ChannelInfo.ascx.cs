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
    public partial class UC_ChannelInfo : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            Int32 cid = this.GetIntParam("id", 0);
            if (cid == 0) {
                Response.Write("<script>history.back();</script>");
            } else {
                ChannelData chda = (new Channel()).GetChannelInfoById(cid);



                ltrTypeImg.Text = "<img src=\"" + ChannelHelper.GetChannelIcon(chda.CType, 0) + "\" alt=\"\" />";
                ltrName.Text = chda.CName;
                ltrState.Text = ChannelHelper.GetState(chda.CState);
                ltrBeginTime.Text = chda.CBeginTime.ToString();
                ltrUserName.Text = chda.UserName;
                ltrCreateTime.Text = chda.CCreateTime.ToString();
                ltrInfo.Text = chda.CInfo;

                ltrBtn.Text = "<a href=\"#\" onclick=\"javascript:if(CheckMedia()){" + ChannelHelper.GetChannelUrl(chda.CId, 0, 1) + "}\"><img src=\"Images/depend/btn_receive.gif\" alt=\"\" /> </a>";

                #region   ulcast Channel Address
                // show address list
                IList<ChannelAddressData> cadList = (new Channel()).GetAddress(chda.CId);
                if (cadList != null && cadList.Count != 0) {
                    System.Collections.IEnumerator enu = cadList.GetEnumerator();
                    ltAddressList.Text = "<ul class=\"ulcast\">";
                    while (enu.MoveNext()) {
                        ChannelAddressData cad = (ChannelAddressData)enu.Current;
                        String strLinkName = "";
                        if (cad != null) {
                            if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.TCP) {
                                // tcp nat
                                String strIps = cad.CaNetCard;
                                if (strIps.Length != 0) {
                                    String[] arrIps = strIps.Split(':');
                                    strLinkName = ChannelHelper.GetType(cad.CaType);
                                    for (Int32 i = 0; i < arrIps.Length; i++) {
                                        if (arrIps[i] != "") {
                                            ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMedia()){"
                                             + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                             + strLinkName + "(" + arrIps[i] + ")" + "</a></li>";
                                        }
                                    }
                                }

                            } else {
                                if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.MS) {
                                    // mediaserver
                                    MediaServerData md = (new Channel()).GetMediaServer(cad.CaTtl);
                                    if (md != null) {
                                        if (md.MsRegister == (Int32)Define.MEDIASEVER_STATE.NORMAL) {
                                            ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMedia()){"
                                                + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                                + md.MsName + "</a></li>";
                                        }
                                    }

                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.BROAD) {
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaPort + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMedia()){"
                                    + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                    + strLinkName + "</a></li>";
                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.MASTER) {
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaIpAddress + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMedia()){"
                                    + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                    + strLinkName + "</a></li>";
                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.NAT) {                                    
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaIpAddress + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMedia()){"
                                    + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                    + strLinkName + "</a></li>";
                                }
                            }

                        }
                    }
                    ltAddressList.Text += "</ul>";
                }
                #endregion


            }
        }
    }
}