using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class ChannelAddressData
    {
        private int caId;
        private int caType;
        private string caIpAddress;
        private int caPort;
        private int caTtl;
        private string caNetCard;
        private int caChannelId;


        //视图数据
        private string netCard = string.Empty;
        private string receive = string.Empty;      
        private string cType = string.Empty;

        public ChannelAddressData(int caId, int caType, string caIpAddress, int caPort, int caTtl, string caNetCard, int caChannelId)
        {
            this.caId = caId;
            this.caType = caType;
            this.caIpAddress = caIpAddress;
            this.caPort = caPort;
            this.caTtl = caTtl;
            this.caNetCard = caNetCard;
            this.caChannelId = caChannelId;
        }

        public ChannelAddressData()
        {

        }

        public int CaId
        {
            get { return caId; }
            set { caId = value; }
        }

        public int CaType
        {
            get { return caType; }
            set { caType = value; }
        }

        public string CaIpAddress
        {
            get { return caIpAddress; }
            set { caIpAddress = value; }
        }
        public int CaPort
        {
            get { return caPort; }
            set { caPort = value; }
        }
        public int CaTtl
        {
            get { return caTtl; }
            set { caTtl = value; }
        }
        public string CaNetCard
        {
            get { return caNetCard; }
            set { caNetCard = value; }
        }
        public int CaChannelId
        {
            get { return caChannelId; }
            set { caChannelId = value; }
        }


        //视图数据
        public string NetCard
        {
            get { return netCard; }
            set { netCard = value; }
        }

        public string Receive
        {
            get { return receive; }
            set { receive = value; }
        }
       
        public string CType
        {
            get { return cType; }
            set { cType = value; }
        }



    }
}
