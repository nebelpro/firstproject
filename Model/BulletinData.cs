using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    /// <summary>
    /// Summary description for BulletinData
    /// </summary>
    /// 
    [Serializable]
    public class BulletinData
    {
        private int bId;
        private string bName;
        private string bInfo;
        private DateTime bAddtime;
        private int bUserId;
        private String bUserName;


        public BulletinData()
        {

        }

        public BulletinData(int bId,string bName,string bInfo,DateTime bAddtime,int bUserId,String bUserName)
        {
            this.bId = bId;
            this.bName = bName;
            this.bInfo = bInfo;
            this.bAddtime = bAddtime;
            this.bUserId = bUserId;
            this.bUserName = bUserName;
        }

        public int BId
        {
            get { return bId; }
            set { bId = value; }
        }
        public string BName
        {
            get { return bName; }
            set { bName = value; }
        }
        public string BInfo
        {
            get { return bInfo; }
            set { bInfo = value; }
        }
        public DateTime BAddtime
        {
            get { return bAddtime; }
            set { bAddtime = value; }
        }

        public int BUserId
        {
            get { return bUserId; }
            set { bUserId = value; }
        }
        public String BUserName {
            get {
                return bUserName;
            }
            set {
                bUserName = value;
            }
        }





      



    }
}
