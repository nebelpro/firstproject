using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class LogRateExData
    {
        private int lreId;
        private int lreUserId;
        private int lreProgramId;
        private int lreSessionId;
        private DateTime lreBeginTime;
        private int lreStreamFlow;
        private int lreStreamFlowHigh;
        private int lrePersistTime;

        //视图数据

        private int playCount; //Count(lreUserID)
        private int lastTime;//Sum(lrePersistTime)
        private int streamFlow; //Sum(streamFlow)
        private int streamFlowHigh;//Sum(streamFlowHigh)

        private string flowMb;
        private string uName;
        private string uMask;
        private int allBill;

        public LogRateExData()
        {
        }

        public LogRateExData(int lreUserId,int playCount,int lastTime,int streamFlow,int streamFlowHigh)
        {
            this.lreUserId = lreUserId;
            this.playCount = playCount;
            this.lastTime = lastTime;
            this.streamFlow = streamFlow;
            this.streamFlowHigh = streamFlowHigh;
        }

        public int LreId
        {
            get { return lreId; }
            set { lreId = value; }
        }
        public int LreUserId
        {
            get { return lreUserId; }
            set { lreUserId = value; }
        }
        public int LreProgramId
        {
            get { return lreProgramId; }
            set { lreProgramId = value; }
        }
        public int LreSessionId
        {
            get { return lreSessionId; }
            set { lreSessionId = value; }
        }
        public DateTime LreBeginTime
        {
            get { return lreBeginTime; }
            set { lreBeginTime = value; }
        }
        public int LreStreamFlow
        {
            get { return lreStreamFlow; }
            set { lreStreamFlow = value; }
        }
        public int LreStreamFlowHigh
        {
            get { return lreStreamFlowHigh; }
            set { lreStreamFlowHigh = value; }
        }
        public int LrePersistTime
        {
            get { return lrePersistTime; }
            set { lrePersistTime = value; }
        }

        //视图数据
        public int PlayCount
        {
            get { return playCount; }
            set { playCount = value; }
        }
        public int LastTime
        {
            get { return lastTime; }
            set { lastTime = value; }
        }
        public int StreamFlow
        {
            get { return streamFlow; }
            set { streamFlow = value; }
        }
        public int StreamFlowHigh
        {
            get { return streamFlowHigh; }
            set { streamFlowHigh = value; }
        }

        public string FlowMb
        {
            get { return flowMb; }
            set { flowMb = value; }
        }

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }
        public string UMask
        {
            get { return uMask; }
            set { uMask = value; }
        }

        public int AllBill
        {
            get { return allBill; }
            set { allBill = value; }
        }

       

    }
}
