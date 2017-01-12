using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class RemarkData
    {
        private int prId;
        private string prName;
        private string prInfo;
        private int prUserId;
        private int prProgramId;
        private DateTime prAddTime;
        private Int32 prState;

        //ÊÓÍ¼Êý¾Ý
        private string vUserName = string.Empty;

        public RemarkData() {
        }

        public RemarkData(int prId,string prName,string prInfo,int prUserId,int prProgramId,DateTime prAddTime,Int32 prState)
        {
            this.prId = prId;
            this.prName = prName;
            this.prInfo = prInfo;
            this.prUserId = prUserId;
            this.prProgramId = prProgramId;
            this.prAddTime = prAddTime;
            this.prState = prState;
        }

        public int PrId
        {
            get { return prId; }
            set { prId = value; }
        }
        public string PrName
        {
            get { return prName; }
            set { prName = value; }
        }
        public string PrInfo
        {
            get { return prInfo; }
            set { prInfo = value; }
        }
        public int PrUserId
        {
            get { return prUserId; }
            set { prUserId = value; }
        }
        public int PrProgramId
        {
            get { return prProgramId; }
            set { prProgramId = value; }
        }
        public DateTime PrAddTime
        {
            get { return prAddTime; }
            set { prAddTime = value; }
        }
        public string VUserName
        {
            get { return vUserName; }
            set { vUserName = value; }
        }
        public Int32 PrState {
            get {
                return prState;
            }
            set {
                prState = value;
            }
        }
    }
}
