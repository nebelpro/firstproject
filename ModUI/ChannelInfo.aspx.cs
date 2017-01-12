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

namespace MOD.UI
{
    public partial class ChannelInfo : MOD.WebUtility.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = this.GetRes("INFO_CHANNEL_DETAIL");
            ltrTip.Text = this.GetRes("INFO_CHANNEL_DETAIL");
            if (this.UserID == 0)
                Response.Redirect("Default.aspx");
            
            Int32 nSort = this.GetIntParam("sort", 0);
            if (nSort == 0) {
                this.Master.Logo = "Images/depend/recorder_logo.gif";
                this.Master.CastSort = 0;
            } else {
                this.Master.Logo = "Images/depend/iptv_logo.gif";
                this.Master.CastSort = 1;
            }

            //Ƶ����ϸ��Ϣ
            Int32 nCid=WebHelper.GetRequest("id",0); 
            if (nCid == 0)
                Response.Redirect("ChannelList.aspx");

            ChannelData chda = (new BLL.Channel()).GetChannelInfoById(nCid);
            if (chda != null)
            {
                ltrCName.Text = chda.CName;
                ltrCInfo.Text = chda.CInfo;
                ltrCreateTime.Text = chda.CCreateTime.ToString();
                ltrBeginTime.Text = chda.CBeginTime.ToString();
                ltrUserName.Text = chda.UserName;
                //ltr = cd.CType;
                ltrStatus.Text = ChannelHelper.GetState(chda.CState);
                ltrLargeImg.Text = "<img src=\"" + ChannelHelper.GetChannelIcon(chda.CType, 0) + "\" />";
                ltrSmallImg.Text = "<img src=\"" + ChannelHelper.GetChannelIcon(chda.CType, 1) + "\" />";
                ltrPlay.Text = "<a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){" + ChannelHelper.GetChannelUrl(chda.CId, 0, 1) + "}\"><img src=\"Images/depend/btn_receive.gif\"/></a>";



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
                            if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.WMS) {
                                ltAddressList.Text += "<li><a href=\"" + cad.CaNetCard + "\">" + cad.CaNetCard + "</a></li>";
                            }else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.TCP) {
                                // tcp nat
                                String strIps = cad.CaNetCard;
                                if (strIps.Length != 0) {
                                    String[] arrIps = strIps.Split(':');
                                    strLinkName = ChannelHelper.GetType(cad.CaType);
                                    for (Int32 i = 0; i < arrIps.Length; i++) {
                                        if (arrIps[i] != "") {
                                            ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){"
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
                                            ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){"
                                                + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                                + md.MsName + "</a>" + " (<span title=\"" + this.GetRes("MS_Load") + "\">" + MediaServerHelper.GetLoad(md.MsRegister, md.MsAvgBand, md.MsMaxBand) + "</span>)</li>";
                                        }
                                    }

                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.BROAD) {
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaPort + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){"
                                    + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                    + strLinkName + "</a></li>";
                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.MASTER) {
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaIpAddress + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){"
                                    + ChannelHelper.GetChannelUrl(cad.CaChannelId, cad.CaId, 1) + "}\">"
                                    + strLinkName + "</a></li>";
                                } else if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.NAT) {
                                    strLinkName = ChannelHelper.GetType(cad.CaType) + "(" + cad.CaIpAddress + ")";
                                    ltAddressList.Text += "<li><a href=\"#\" onclick=\"javascript:if(CheckMediaPlayer()){"
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
