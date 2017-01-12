using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using MOD.BLL;
using MOD.Model;

using System.Globalization;

namespace MOD.WebUtility {
    public class ChannelHelper {       

        #region ===== 参数转换
        public static String GetChannelIcon(Int32 nType,Int32 nSize){
            String strPath = "Images/nodepend/";
            if (nType == (Int32)Define.CHANNEL_TYPE.BROADCAST) {
                strPath += (nSize == 0) ? "m_icon_broadcast_large.gif" : "m_icon_broadcast_small.gif";
            }else if (nType == (Int32)Define.CHANNEL_TYPE.LIVE||nType ==(Int32) Define.CHANNEL_TYPE.IPTV) {
                strPath += (nSize == 0) ? "m_icon_onlive_large.gif" : "m_icon_onlive_small.gif";
            }else if (nType == (Int32)Define.CHANNEL_TYPE.REBROAD) {
                strPath += (nSize == 0) ? "m_icon_rebroadcast_large.gif" : "m_icon_rebroadcast_small.gif";
            }else if (nType == (Int32)Define.CHANNEL_TYPE.MIXC) {
                strPath += (nSize == 0) ? "m_icon_mixchannel_large.gif" : "m_icon_mixchannel_small.gif";
            }
            return strPath;
        }
        public static String GetState(Int32 nState) {
            String strKey = "";
            switch (nState) {
                case (Int32)Define.CHANNEL_STATE.NOACTIVE:
                    strKey = "CHANNEL_STATE_NOACTIVE";
                    break;
                case (Int32)Define.CHANNEL_STATE.NORMARL:
                    strKey = "CHANNEL_STATE_NORMARL";
                    break;
                case (Int32)Define.CHANNEL_STATE.PAUSE:
                    strKey = "CHANNEL_STATE_PAUSE";
                    break;
                case (Int32)Define.CHANNEL_STATE.STOP:
                    strKey = "CHANNEL_STATE_STOP";
                    break;
                case (Int32)Define.CHANNEL_STATE.MIXCHANNEL:
                    strKey = "CHANNEL_STATE_MIX";
                    break;
            }
            return Res.GetValue(strKey);
        }
        /// <summary>
        /// Gets Channel Address Type.
        /// </summary>       
        public static String GetType( Int32 nCaType ) {
            string strType = string.Empty;

            switch (nCaType) {
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.INVALID:
                    strType = Res.GetValue("ADDRESS_INVALID");
                    break;
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.UDP:
                    strType = Res.GetValue("ADDRESS_UDP");
                    break;
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.TCP:
                    strType = Res.GetValue("ADDRESS_TCP");
                    break;
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.MASTER:
                    strType = Res.GetValue("ADDRESS_MASTER");
                    break;
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.BROAD:
                    strType = Res.GetValue("ADDRESS_BROAD");
                    break;
                case (Int32)Define.CHANNEL_ADDRESS_TYPE.NAT:
                    strType = Res.GetValue("ADDRESS_NAT");
                    break;
            }
            return strType;
        }
        public static String OutChannelDetailLink( Int32 nChannelId, Int32 nType ) {
            string strDetail = "<a href=\"ChannelInfo.aspx?id=" + nChannelId + "\"><img src=\"Images/depend/btn_channel_info.gif\" border=\"0\" /></a> ";
            
            return (nType != (Int32)Define.CHANNEL_TYPE.MIXC) ? strDetail : string.Empty;
        }
        public static String OutChannelDetailLink( Int32 nChannelId, Int32 nType, int sort ) {
            string strDetail = "<a href=\"ChannelInfo.aspx?sort=" + sort.ToString() + "&id=" + nChannelId + "\"><img src=\"Images/depend/btn_channel_info.gif\" border=\"0\" /></a> ";

            return (nType != (Int32)Define.CHANNEL_TYPE.MIXC) ? strDetail : String.Empty;
        }
        public static String OutChannelDetailLink( Int32 nChannelId, Int32 nType, String ImgUrl ) {
            string strDetail = "<a href=\"ChannelInfo.aspx?id=" + nChannelId + "\"><img src=\"Images/depend/" + ImgUrl + "\" border=\"0\" /></a> ";

            return nType != (Int32)Define.CHANNEL_TYPE.MIXC ? strDetail : String.Empty;
        }
        #endregion 

        /// <summary>
        /// 频道播放地址
        /// </summary>
        /// <param name="nChannelId">频道ID</param>
        /// <param name="nAddressId">地址ID.自动接收为0</param>
        /// <param name="nIndex">多网卡序列,一般只有TCP方式才有，从ca_netcard分切成数组，下标为0.默认为1</param>
        /// <returns></returns>
        public static String GetChannelUrl( Int32 nChannelId, Int32 nAddressId, Int32 nIndex ) {
            return "openwndex('ChannelPlay.aspx?id=" + WebHelper.EncryptPid(nChannelId) + "&addressid=" + nAddressId + "&index=" + nIndex + "','" + Res.GetValue("INFO_POP_PLAY") + "',2,20)";
        }
      
        /// <summary>
        /// for channel 
        /// </summary>
        /// <param name="strIP"></param>
        /// <param name="nPort"></param>
        /// <param name="nNit"></param>
        /// <param name="bBroad"></param>
        /// <param name="nSsrc"></param>
        /// <param name="nChannelId"></param>
        /// <returns></returns>
        public static String MakeUrl( String strIP, Int32 nPort, Int32 nNit, Int32 bBroad, Int32 nSsrc, Int32 nChannelId ) {
            String strHomeServer = HttpContext.Current.Session["HSServer"].ToString();
            String strHomePort = HttpContext.Current.Session["HSPort"].ToString();
            Int32 nIsCanRc = ((new Permit()).CanLiveRecord()) ? 1 : 0;
            String strUrl = "ummp://" + strIP + ":" + nPort + "/" + strHomeServer + ":" + strHomePort + "/"
                + nChannelId + "." + nNit + ".0." + nIsCanRc + ".0";
            return "openwndex('AddPlayCount.aspx?t=cast&url="
                + HttpContext.Current.Server.UrlEncode(strUrl) + "','" + Res.GetValue("INFO_POP_PLAY") + "',2,20)";
        }

        #region  ===== 播放地址      
       
       
        
        public static String MakeLocalUrl( Int32 nChannelId, Int32 nAddressId, Int32 nIndex, Int32 nUserId, Int32 nGroupMask, out String strRet ) {
            Int32 nRet;
            string strUrl=(new Channel()).GetUrl(nChannelId, nAddressId, nIndex,nUserId,nGroupMask, out nRet);
            if (nRet == (Int32)Channel.PlayRet.ErrAddress) {
                strRet = Res.GetValue("ERR_CHANNELADDRESS");
            } else if (nRet == (Int32)Channel.PlayRet.ErrChannel) {
                strRet = Res.GetValue("ERR_CHANNELINFO");
            } else if (nRet == (Int32)Channel.PlayRet.ErrGroup) {
                strRet = Res.GetValue("ERR_NOTALLOWGROUP");
            } else if (nRet == (Int32)Channel.PlayRet.ErrMix) {
                strRet = Res.GetValue("ERR_MIXCHANNEL");
            } else if (nRet == (Int32)Channel.PlayRet.ErrUser) {
                strRet = Res.GetValue("ERR_FORBINUSER");
            } else {
                strRet = "";
            }
            return strUrl;
        }
      
        /// <summary>
        /// 获取频道播放实体(play_url) GetChannelObj
        /// </summary>
        /// <param name="cid">频道ID</param>
        /// <param name="caid">频道地址ID(0表示自动选择)</param>
        /// <returns></returns>
        public static String GetChannelObj( int cid, int caid ) {
            Channel chaBll = new Channel();

            int ssrc = 0;
            ChannelData subCha = chaBll.GetChannelInfoById(cid);
            if (subCha != null) {   ssrc = subCha.CSsrc; }
            string param = "{'cid':" + cid + ",'auto':'" + ((caid != 0) ? 0 : 1) + "','ssrc':" + ssrc + ",'name':'"+subCha.CName.Replace("'","\'")+"','receive':[";
            
            IList<ChannelAddressData> chAddressList = new List<ChannelAddressData>();

            
            if (caid == 0) {
                chAddressList = chaBll.GetAddress(cid);
            } else {
                ChannelAddressData chaddress = chaBll.GetAddressById(caid);
                chAddressList.Add(chaddress);
            }
            if (chAddressList.Count != 0) {
                IEnumerator myEnum = chAddressList.GetEnumerator();
                while (myEnum.MoveNext()) {
                    string strIp = "";
                    ChannelAddressData adrs = (ChannelAddressData)myEnum.Current;
                    if (adrs.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.TCP) {
                        // tcp                        
                        string[] accNc = adrs.CaNetCard.Split(":".ToCharArray());
                        for (int j = 0; j <= accNc.GetUpperBound(0); j++) {
                            strIp = accNc[j];
                            if (strIp != "") {
                                param = param + "{'type':'tcp','port':" + adrs.CaPort + ",'ip':'" + strIp + "','catype':"+adrs.CaType+"},";
                            }
                        }
                    } else if (adrs.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.MS) {
                        //   media server type,tcp
                        param = param + "{'type':'ms','port':" + WebHelper.GetSession("HSPort") + ",'ip':'" +
                            WebHelper.GetSession("HSServer") + "','msid':" + adrs.CaTtl + ",'uid':" + WebHelper.GetSession("UserId") + ",'catype':" + adrs.CaType + "},";
                    } else if (adrs.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.NAT) {
                        param = param + "{'type':'tcp','port':" + adrs.CaPort + ",'ip':'" + adrs.CaIpAddress + "','catype':" + adrs.CaType + "},";
                    } else {
                        //udp
                        if (adrs.CaIpAddress != "") {
                            param = param + "{'type':'udp','port':" + adrs.CaPort + ",'ip':'" + adrs.CaIpAddress + "','catype':" + adrs.CaType + "},";
                        }
                    }

                }
                if (param.Substring(param.Length - 1, 1) == ",") {
                    param = param.Substring(0, param.Length - 1);
                }
                param = param + "]}";

            }
            return param;
        }


        /// <summary>
        /// 提取WebPlayer播放器的播放参数，返回值作为IE端播放的参数
        /// </summary>
        /// <param name="cid">频道ID</param>
        /// <param name="caid">频道地址ID(0 表示自动选择)</param>
        /// <returns>-1，用于JS控件解析播放地址</returns>
        public static String GetCastUI( int cid, int caid ) {
           
            string strParam = "";
            Channel chaBll = new Channel();
            int iCurrUserId = WebHelper.GetSession("UserId", 0);
            int iGroupMask = WebHelper.GetSession("GroupMask", 0);
            //以上是获取参数

            ChannelData chada = chaBll.GetChannelInfoById(cid);
            if (chada == null) {
                return "-1";  //提取地址错误返回 错误信息 
            } else {
                // begin 复合频道的提取
                if (chada.CType == 3 && chada.CUploadMediaServer != "") { 
                    string[] arrC = chada.CUploadMediaServer.Split(",".ToCharArray());                               
                    if(arrC.GetUpperBound(0) == 0) {
                        strParam = "[" + GetChannelObj(int.Parse(arrC[0]), caid) + "]";
                    }else {                               
                        strParam = "[" + GetChannelObj(int.Parse(arrC[0]), caid)+ "," +
                                         GetChannelObj(int.Parse(arrC[1]), caid) + "]";
                    }
                } else if (chada.CType == 3 && chada.CUploadMediaServer == "") {
                    return "-1"; // 复合频道地址错误
                } else {
                    strParam = "[" + GetChannelObj(cid, caid) + "]";
                }
                return strParam;
            }    
        }

        public static String GetWeigeUI() {
            Int32 nCount = 12;
            Int32 nView = WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_VIEW, 2);
            if (nView == 0) nCount = 4;
            else if (nView == 1) nCount = 6;
            else if (nView == 2) nCount = 6;
            else if (nView == 3) nCount = 9;
            else if (nView == 4) nCount = 12;
            else if (nView == 5) nCount = 16;
            else if (nView == 6) nCount = 13;
            else nCount = 6;

            Int32 nOrder = WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0);
            Int32 caid = 0;

            Channel chaBll = new Channel();
            IList<ChannelData> chList = chaBll.GetList((Int32)Define.CHANNEL_TYPE.LIVE, WebHelper.GetSession("GroupMask", 0), 1, nCount, nOrder);

            if (chList.Count == 0) {
                return "-1";  //提取地址错误返回 错误信息 
            } else {
                string strParam = "[";
                foreach (ChannelData chda in chList) {
                    strParam += GetChannelObj(chda.CId, caid) + ",";
                }
                if (strParam.Substring(strParam.Length - 1, 1) == ",") {
                    strParam = strParam.Substring(0, strParam.Length - 1);
                }
                strParam += "]";
                return strParam;
            }
        }



        /// <summary>
        /// 是否允许录制，为js端提供参数
        /// </summary>
        /// <returns></returns>
        public static String IsCanRec() {
            return ((new Permit()).CanPlayerRecord()) ? "1" : "0";
        }

        #endregion 
    }

    public class MediaServerHelper {
        public static String GetState( Int32 nState ) {                
            if (nState == 1) {
                return Res.GetValue("MS_State1");
            } else if (nState == 2) {
                return Res.GetValue("MS_State2");
            } else {
                return Res.GetValue("MS_State3");
            }
        }
        public static String GetLoad(Int32 nState,Int32 nAvgBand,Int32 nMaxBand) {
            if (nState == 1) {
                NumberFormatInfo nfi = new CultureInfo(CultureInfo.CurrentCulture.Name, true).NumberFormat;
                nfi.PercentDecimalDigits = 3;

                Double dWork = 8 * Convert.ToDouble(nAvgBand) / 1024 * 1024 * Convert.ToDouble(nMaxBand);

                return dWork.ToString("P", nfi);
            } else {
                return "--";
            }
        }



    }


}
