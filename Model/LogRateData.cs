using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class LogRateData
    {
        // 添加节目名称及转换流量大小
        private int lrId;
        private int lrUserId;
        private int lrProgramId;
        private int lrChapterId;
        private DateTime lrBeginTime;
        private int lrStreamFlow;
        private int lrStreamFlowHigh;
        private int lrPersistTime;

        public LogRateData()
        {
        }

        public int LrId
        {
            get { return lrId; }
            set { lrId = value; }
        }
        public int LrUserId
        {
            get { return lrUserId; }
            set { lrUserId = value; }
        }
        public int LrProgramId
        {
            get { return lrProgramId; }
            set { lrProgramId = value; }
        }
        public int LrChapterId
        {
            get { return lrChapterId; }
            set { lrChapterId = value; }
        }
        public DateTime LrBeginTime
        {
            get { return lrBeginTime; }
            set { lrBeginTime = value; }
        }
        public int LrStreamFlow
        {
            get { return lrStreamFlow; }
            set { lrStreamFlow = value; }
        }
        public int LrStreamFlowHigh
        {
            get { return lrStreamFlowHigh; }
            set { lrStreamFlowHigh = value; }
        }
        public int LrPersistTime
        {
            get { return lrPersistTime; }
            set { lrPersistTime = value; }
        }


    }
}
