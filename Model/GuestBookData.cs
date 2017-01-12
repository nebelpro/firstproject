using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model {
    [Serializable]
    public class GuestBookData {

        private int gbId;
        private string gbSubject;
        private string gbInfo;
        private DateTime gbDate;
        private string gbUser;
        private int gbType;

        public GuestBookData()
        {
        }

        public GuestBookData(int gbId,string gbSubject,string gbInfo,DateTime gbDate,string gbUser,int gbType)
        {
            this.gbId = gbId;
            this.gbSubject = gbSubject;
            this.gbInfo = gbInfo;
            this.gbDate = gbDate;
            this.gbUser = gbUser;
            this.gbType = gbType;

        }


        public int GbId
        {
            get { return gbId; }
            set { gbId = value; }
        }
        public string GbSubject
        {
            get { return gbSubject; }
            set { gbSubject = value; }
        }
        public string GbInfo
        {
            get { return gbInfo; }
            set { gbInfo = value; }
        }
        public DateTime GbDate
        {
            get { return gbDate; }
            set { gbDate = value; }
        }
        public string GbUser
        {
            get { return gbUser; }
            set { gbUser = value; }
        }
        public int GbType
        {
            get { return gbType; }
            set { gbType = value; }
        }

    }
}
