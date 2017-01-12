using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model {

    [Serializable]
    public class MediaServerData {

        private int msId;
        private string msName;
        private String msInfo;
        private Int32 msRegister;
        private Int32 msMaxBand;
        private Int32 msAvgBand;


     

        public MediaServerData()
        {

        }

        public int MsId
        {
            get { return msId; }
            set { msId = value; }
        }

        public string MsName
        {
            get { return msName; }
            set { msName = value; }
        }
        public Int32 MsRegister {
            get {return msRegister;}
            set {msRegister = value;}
        }

        public String MsInfo {
            get { return msInfo; }
            set { msInfo = value; }
        }
        public Int32 MsMaxBand {
            get { return msMaxBand; }
            set { msMaxBand = value; }
        }
        public Int32 MsAvgBand {
            get { return msAvgBand; }
            set { msAvgBand = value; }
        }




    }
}
