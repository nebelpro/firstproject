using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Channel {
        private static readonly MOD.IDAL.IChannel dal = MOD.DALFactory.DataAccess.CreateChannel();


        #region ���ݿ��������
        /// <summary>
        /// ��ȡƵ����ҳ�б�
        /// </summary>
        /// <param name="nType">
        /// SHOW_ALL = -1,SHOW_LIVE = 0,SHOW_BROAD = 1
        /// SHOW_REBROAD = 2,SHOW_MIXC = 3,SHOW_IPTV = 4</param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ChannelData> GetList( Int32 nType, Int32 nGroupMask, Int32 nPage, Int32 nPageSize,Int32 nOrder ) {
            IList<ChannelData> chlist = dal.GetList(nType, nGroupMask, nPage, nPageSize,nOrder);
            IList<ChannelData> ChannelList = new List<ChannelData>();
            foreach(ChannelData cd in chlist){
                if (cd != null) {
                    cd.UserName = (new User()).GetName(cd.CUserId);
                }
                ChannelList.Add(cd);
            }
            return ChannelList;
        }
        /// <summary>
        /// ��ȡĳ�����͵�Ƶ����Ϊms���ͱ�д��
        /// </summary>       
        public IList<ChannelData> GetList( Int32 nType, Int32 nGroupMask, Int32 nPage, Int32 nPageSize, Int32 AddressType, Boolean bNeed ) {
            IList<ChannelData> chlist = dal.GetList(nType, nGroupMask, nPage, nPageSize,0);
            IList<ChannelData> ChannelList = new List<ChannelData>();
            foreach (ChannelData cd in chlist) {
                IList<ChannelAddressData> ChaddrList = GetAddress(cd.CId);
                Int32 nCount = 0;
                Int32 nCount2 = 0;
                foreach (ChannelAddressData chaddr in ChaddrList) {
                    if (chaddr.CaType == AddressType) {
                        nCount++;
                    }
                    nCount2++;
                }
                if (bNeed) {//bNeed���ó�True,��ʾֻ��ȡӵ�иõ�ַ�����͵�Ƶ������ nCount!=0
                    if (nCount != 0)
                        ChannelList.Add(cd);
                } else {//���򣬲���ӵ�иõ�ַ������񣬶���ȡ
                    if (nCount2 != 0)
                        ChannelList.Add(cd);
                }
            }
            return ChannelList;
        }

        /// <summary>
        /// ��ȡƵ������
        /// </summary>       
        public Int32 GetCount( Int32 nType, Int32 nGroupMask) {
            return dal.GetCount(nType, nGroupMask);
        }

        /// <summary>
        /// ��ȡƵ����ַ
        /// </summary>      
        public IList<ChannelAddressData> GetAddress( Int32 nChannelId ) {
            return dal.GetAddress(nChannelId);
        }

        /// <summary>
        /// ����id��ȡƵ������ϸ��Ϣ
        /// </summary>       
        public ChannelData GetChannelInfoById( int cid ) {
            ChannelData cd = dal.GetChannelInfoById(cid);
            if (cd != null) {
                cd.UserName = (new User()).GetName(cd.CUserId);
            }
            return cd;
        }

        /// <summary>
        /// ����Ƶ��
        /// </summary>
        /// <param name="channeldata"></param>
        /// <returns>-1�Ѿ�����,1</returns>
        public Int32 Insert( ChannelData channeldata ) {
            return dal.Insert(channeldata);
        }

        /// <summary>
        /// ����Ƶ��(ֻ���¼����ֶ�)
        /// </summary>
        /// <param name="channeldata">The channeldata.</param>
        /// <returns>-1������ 1</returns>
        public Int32 Update( ChannelData channeldata ) {
            return dal.Update(channeldata);
        }

        /// <summary>
        /// ���Ӹ���Ƶ����Ϣ
        /// </summary>
        /// <param name="nChannelId">The n channel id.</param>
        /// <param name="nSubChannelId">The n sub channel id.</param>
        /// <returns>-1:����������Ƶ���������ɹ�</returns>
        public Int32 AddSubChannel( Int32 nChannelId, Int32 nSubChannelId ) {
            //
            ChannelData chadata = GetChannelInfoById(nChannelId);
            string strHave = chadata.CUploadMediaServer;


            if (string.IsNullOrEmpty(strHave))//
            {
                //������������ֱ����Ŀ��UploadMediaServer�ֶ�
                dal.UpdateSubChannelState(nSubChannelId, "0");
                //���¸���Ƶ���ĸ��ֶ�
                dal.UpdateSubChannelState(nChannelId, nSubChannelId.ToString());
                return 1;
            }

            string[] strHave2 = chadata.CUploadMediaServer.Split(",".ToCharArray());
            if (strHave2.Length < 2)//Ҳ���ǣ���split��Ľ�����ڣ�
            {
                dal.UpdateSubChannelState(nSubChannelId, "0");
                dal.UpdateSubChannelState(nChannelId, strHave + "," + nSubChannelId.ToString());

                return 1;
            } else {
                return -1;//���ֻ������������Ƶ��
            }


        }

        /// <summary>
        /// ɾ������Ƶ������Ƶ��
        /// </summary>
        /// <param name="nChannelId">����Ƶ����ID</param>
        /// <param name="nSubChannelId">��Ƶ����ֱ��Ƶ����ID</param>
        /// <returns>-2������Ƶ�����ֶ�Ϊ�գ�-1����Ƶ���������ڸ���Ƶ���У�</returns>
        public Int32 DeleteSubChannel( Int32 nChannelId, Int32 nSubChannelId ) {
            ChannelData chadata = GetChannelInfoById(nChannelId);
            string strHave = chadata.CUploadMediaServer;
            if (string.IsNullOrEmpty(strHave))//�жϸ���Ƶ�����ֶ��Ƿ�Ϊ��
            {
                return -2;//��Ϊ�գ�������
            }

            int nIndex = strHave.IndexOf(nSubChannelId.ToString());
            if (nIndex < 0)//��Ƶ���Ƿ�����ڸ���Ƶ���С���
            {
                return -1;//�ӽ�Ŀ�������ڸ���Ƶ����
            } else//������channel
            {
                string[] strHave2 = chadata.CUploadMediaServer.Split(",".ToCharArray());
                if (strHave2.Length == 1)//ֻ��һ��ֵ
                {
                    strHave = string.Empty;//��Ϊ�ջ��ǣΣգ̣̣�
                } else//�ǣ�����
                {
                    if (strHave2[0] == nSubChannelId.ToString()) {
                        strHave = strHave2[1];
                    } else {
                        strHave = strHave2[0];
                    }
                }
                dal.UpdateSubChannelState(nSubChannelId, "-1");
                dal.UpdateSubChannelState(nChannelId, strHave);

                return 1;
            }
        }


        /// <summary>
        /// ɾ������Ƶ��
        /// ����ChannelId��ȡ����Ƶ���� c_upload_mediaserver�ֶ�
        /// ����c_upload_mediaserver,��������������ֱ��,�����Լ���c_upload_mediaserver
        /// </summary>
        /// <param name="nChannelId">The n channel id.</param>
        public void Delete( Int32 nChannelId ) {

            ChannelData chadata = GetChannelInfoById(nChannelId);

            //������������ֱ����c_upload_mediaserver�ֶ�ֵ
            if (!string.IsNullOrEmpty(chadata.CUploadMediaServer)) {
                string[] strHave = chadata.CUploadMediaServer.Split(",".ToCharArray());
                for (int i = 0; i <= strHave.Length - 1; i++) {
                    dal.UpdateSubChannelState(int.Parse(strHave[i]), "-1");
                }
            }

            //������,ɾ������Ƶ��
            dal.Delete(nChannelId);
        }

        public ChannelAddressData GetAddressById( Int32 nAddressId ) {
            return dal.GetAddressDetail(nAddressId);
        }
        public MediaServerData GetMediaServer( Int32 nMsId ) {
            return dal.GetMediaServer(nMsId);
        }

        #endregion 


        #region  �㲥Ƶ���ĺ���
        /// <summary>
        /// 
        /// </summary>
        public enum PlayRet {          
            Suc = 0,
            ErrMix = 1,
            ErrGroup = 2,
            ErrUser = 3,
            ErrAddress = 4,
            ErrChannel =5


        };


        /// <summary>
        /// // ����Ƶ��ERR_MIXCHANNEL
        /// </summary>       
        public String GetMixChannelUrl( String strUploadMedia, String strHomeServer, String strHomePort, out Int32 nRet ) {

            nRet = (Int32)PlayRet.Suc;
            if (strUploadMedia.Length != 0) {
                strUploadMedia = strUploadMedia.Replace(",", ".");
                String[] arrMix = strUploadMedia.Split('.');
                if (arrMix.Length == 2) {
                    return "ummq://" + strHomeServer + ":" + strHomePort + "/" + strHomeServer + ":" + strHomePort + "/" + strUploadMedia;
                } else if (arrMix.Length == 1) {
                    return "ummp://127.0.0.1:101/" + strHomeServer + ":" + strHomePort + "/" + arrMix[0] + ".0.0.0.0";
                } else {
                    nRet = (Int32)PlayRet.ErrMix;
                    return "";
                }
            } else {
                nRet = (Int32)PlayRet.ErrMix;
                return "";
            }
        }
        /// <summary>
        /// ��ȡƵ��Ȩ�����
        /// <para>-1 ��ʾ��ǰ�û����ڽ�ֹ�鿴�����</para>
        /// <para>-2 ��ʾ��ǰ�û����ڽ�ֹ���ʵ��û�</para>
        /// <para>0 ��ʾ����</para>
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        public Int32 ChannelPermit( Int32 nChannelId, Int32 nUserId, Int32 nGroupMask ) {
            ChannelData cd = this.GetChannelInfoById(nChannelId);

            Boolean bIsGroupAllow = false;
            IList<GroupData> gdList = (new Group()).GetListByUserGroupMask(nGroupMask);            
            foreach (GroupData gd in gdList) {
                if (gd != null) {
                    if (cd.CAllowGroup.IndexOf(":" + gd.GId.ToString() + ":") != -1) {
                        bIsGroupAllow = true;
                        break;
                    }
                }
            }
            Boolean bIsUserForbin = cd.CForbidUser.IndexOf(":" + nUserId.ToString() + ":") != -1;

            Permit pmt = new Permit();
            if (cd.CType == (Int32)Define.CHANNEL_TYPE.BROADCAST) {
                bIsUserForbin = !pmt.CanBroadCastPaly();
            } else if (cd.CType == (Int32)Define.CHANNEL_TYPE.LIVE) {
                bIsUserForbin = !pmt.CanLiveCastPaly();
            } else if (cd.CType == (Int32)Define.CHANNEL_TYPE.REBROAD) {
                bIsUserForbin = !pmt.CanReBroadCastPaly();
            } else if (cd.CType == (Int32)Define.CHANNEL_TYPE.IPTV) {
                bIsUserForbin = !pmt.CanLiveCastPaly();
            }

            if (!bIsGroupAllow) return (Int32)PlayRet.ErrGroup;
            else if (bIsUserForbin) return (Int32)PlayRet.ErrUser;
            else return (Int32)PlayRet.Suc;

        }
        public String GetCastChannelUrl( Int32 nChannelId, Int32 nAddressId, Int32 nIndex, Int32 nUserId, Int32 nGroupMask, String strHomeServer, String strHomePort, out Int32 nRet ) {
            nRet = this.ChannelPermit(nChannelId,nUserId,nGroupMask);

            if (nRet != (Int32)PlayRet.Suc) {
                return "";
            }


            String strCanRec = !(new Permit()).CanPlayerRecord() ? "0" : "1";
            if (nAddressId != 0) {
                ChannelAddressData cad = (new Channel()).GetAddressById(nAddressId);
                if (cad != null) {

                    String strIp = "";
                    String strPort = cad.CaPort.ToString();
                    String strNit = cad.CaType.ToString();
                    if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.MS) {
                        strPort = cad.CaTtl.ToString();
                    }

                    if (cad.CaType == (Int32)Define.CHANNEL_ADDRESS_TYPE.TCP) {
                        if (cad.CaNetCard.Length != 0) {
                            String[] arrIps = cad.CaNetCard.Split(':');
                            for (Int32 i = 0; i < arrIps.Length; i++) {
                                if (i == nIndex) {
                                    strIp = arrIps[i];
                                }
                            }
                        }
                        if (strIp.Length == 0) {
                            nRet = (Int32)PlayRet.ErrAddress;
                        }
                    } else {// UPD BROAD,MS,Nat                        
                        strIp = cad.CaIpAddress;
                    }
                    if (nRet == (Int32)PlayRet.Suc) {
                        return "ummp://" + strIp + ":" + strPort + "/" + strHomeServer + ":" + strHomePort
                                    + "/" + nChannelId + "." + strNit + ".0." + strCanRec + ".0";
                    } else {
                        return "";
                    }
                } else {
                    nRet = (Int32)PlayRet.ErrAddress;
                    return "";
                } 
            } else {// �Զ�ѡ��
                return "ummp://127.0.0.1:0/" + strHomeServer + ":" + strHomePort + "/" + nChannelId + ".0.0." + strCanRec + ".0";
            }

        }

        public  String GetUrl(Int32 nChannelId, Int32 nAddressId, Int32 nIndex,Int32 nUserId, Int32 nGroupMask, out Int32 nRet ) {

            String strUrl = "";
            ChannelData cd = GetChannelInfoById(nChannelId);
            if (cd != null) {
                String strHomeServer = System.Web.HttpContext.Current.Session["HSServer"].ToString();
                String strHomePort = System.Web.HttpContext.Current.Session["HSPort"].ToString();

                if (cd.CType == (Int32)Define.CHANNEL_TYPE.MIXC) {
                    strUrl = GetMixChannelUrl(cd.CUploadMediaServer, strHomeServer, strHomePort, out nRet);
                    
                } else {
                    strUrl = GetCastChannelUrl(nChannelId, nAddressId, nIndex, nUserId, nGroupMask, strHomeServer, strHomePort, out nRet);
                }

            } else {
                nRet = (Int32)PlayRet.ErrChannel;
            }
            return strUrl;
        }

        #endregion 


    }
}
