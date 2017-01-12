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
using System.Text;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.WMS {
    public partial class Ajax : MOD.WebUtility.UI.Page {
        protected string oper=string.Empty;
		protected string response=string.Empty;
 
		protected void Page_Load(object sender, System.EventArgs e)
		{           
            oper = this.GetStringParam("oper", "");
			switch(oper)
            {                
                case "GetCastInfo":
                    //ChkLogin();
                    GetCastInfo();
                    break;
                default:
					//参数不全的处理
					break;
			}

            Response.Write(response);
		}

        public void ChkLogin() {
            if (this.UserID == 0) {
                Response.Write("-10");
                Response.End();
            }
        }        

        public void GetCastInfo() {
            int CastId = this.GetIntParam("id", 0);
            Int32 nAddressId = this.GetIntParam("aid", 0);
            bool IsOk= false;
            string strParam="";
            string strInfo="";
            
            ChannelData cha = (new Channel()).GetChannelInfoById(CastId);
            if (cha != null) {
                IsOk=true;
                // 取wms的播放地址

                IList<ChannelAddressData> ChaddrList = (new Channel()).GetAddress(cha.CId);              
                foreach (ChannelAddressData chaddr in ChaddrList) {
                    if (nAddressId == 0 && chaddr.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.WMS) {
                        strParam = chaddr.CaNetCard;
                        break;
                    } else if (chaddr.CaId == nAddressId && chaddr.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.WMS) {
                        strParam = chaddr.CaNetCard;
                    }                   
                }

                //strParam = ChannelHelper.GetCastUI(cha.CId, 0);
                strInfo= cha.CInfo;
            }
            string strRet = "{ \"Suc\":\"" + IsOk + "\",\"Param\":\"" + strParam + "\",\"Info\":\"" +this.TextIn(strInfo) + "\"}";//
            response=strRet;
        }
       


   
    
  
  
  
 
  
 

    }
   
}


