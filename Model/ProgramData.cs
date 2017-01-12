using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class ProgramData
    {
        public ProgramData()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region  数据库表字段映射
        private int pId;
        private string pName;
        private string pDirector;
        private string pPublish;
        private string pActor;
        private string pInfo;
        private string pAddUser;
        private int pCommend;
        private int pImageId;
        private int pClass;
        private int pCheck;
        private int pGroupMask;
        private DateTime pAddTime;
        private int pReadCount;
        private int pIsKind;
        private int pRemarkCount;
        private float pRemarkScore;
        private int pDuration;
        private int pSizeHigh;
        private int pMediaKind;
        private int pSizeLow;
        private string pSize;
        private int pCourseId;
        private int pPoint;

        //视图数据
       
        private string Kbps = string.Empty;//播放速率
        private string Time = string.Empty;//播放时间长       



        public ProgramData(int pId, string pName, string pDirector, string pPublish, string pActor, string pInfo, string pAddUser, int pCommend,
            int pImageId, int pClass, int pCheck, int pGroupMask, DateTime pAddTime, int pReadCount, int pIsKind, int pRemarkCount, float pRemarkScore,
            int pDuration, int pSizeHigh, int pMediaKind, int pSizeLow, string pSize, int pCourseId,int pPoint)
        {
            
            this.pId = pId;
            this.pName = pName;
            this.pDirector = pDirector;
            this.pPublish = pPublish;
            this.pActor = pActor;
            this.pInfo = pInfo;
            this.pAddUser = pAddUser;
            this.pCommend = pCommend;
            this.pImageId = pImageId;
            this.pClass = pClass;
            this.pCheck = pCheck;
            this.pGroupMask = pGroupMask;
            this.pAddTime = pAddTime;
            this.pReadCount = pReadCount;
            this.pIsKind = pIsKind;
            this.pRemarkCount = pRemarkCount;
            this.pRemarkScore = pRemarkScore;
            this.pDuration = pDuration;
            this.pSizeHigh = pSizeHigh;
            this.pMediaKind = pMediaKind;
            this.pSizeLow = pSizeLow;
            this.pSize = pSize;
            this.pCourseId = pCourseId;
            this.pPoint = pPoint;
            //
        }
        public int PId
        {
            get { return pId; }
            set { pId = value; }
        }
        public string PName
        {
            get { return pName; }
            set { pName = value; }
        }

        public string PDirector
        {
            get { return pDirector; }
            set { pDirector = value; }
        }
        public string PPublish
        {
            get { return pPublish; }
            set { pPublish = value; }
        }
        public string PActor
        {
            get { return pActor; }
            set { pActor = value; }
        }
        public string PInfo
        {
            get { return pInfo; }
            set { pInfo = value; }
        }
        public string PAddUser
        {
            get { return pAddUser; }
            set { pAddUser = value; }
        }
        public int PCommend
        {
            get { return pCommend; }
            set { pCommend = value; }
        }
        public int PImageId
        {
            get { return pImageId; }
            set { pImageId = value; }
        }
        public int PClass
        {
            get { return pClass; }
            set { pClass = value; }
        }
        public int PCheck
        {
            get { return pCheck; }
            set { pCheck = value; }
        }
        public int PGroupMask
        {
            get { return pGroupMask; }
            set { pGroupMask = value; }
        }
        public DateTime PAddTime
        {
            get { return pAddTime; }
            set { pAddTime = value; }
        }
        public int PReadCount
        {
            get { return pReadCount; }
            set { pReadCount = value; }
        }
        public int PIsKind
        {
            get { return pIsKind; }
            set { pIsKind = value; }
        }
        public int PRemarkCount
        {
            get { return pRemarkCount; }
            set { pRemarkCount = value; }
        }
        public float PRemarkScore
        {
            get { return pRemarkScore; }
            set { pRemarkScore = value; }
        }
        public int PDuration
        {
            get { return pDuration; }
            set { pDuration = value; }
        }
        public int PSizeHigh
        {
            get { return pSizeHigh; }
            set { pSizeHigh = value; }
        }
        public int PMediaKind
        {
            get { return pMediaKind; }
            set { pMediaKind = value; }
        }
        public int PSizeLow
        {
            get { return pSizeLow; }
            set { pSizeLow = value; }
        }
        public string PSize
        {
            get { return pSize; }
            set { pSize = value; }
        }
        public int PCourseId
        {
            get { return pCourseId; }
            set { pCourseId = value; }
        }

        public int PPoint
        {
            get { return pPoint; }
            set { pPoint = value; }
        }
        #endregion




       
        public string nKbps
        {
            get { return Kbps; }
            set { Kbps = value; }
        }
        public string nTime
        {
            get { return Time; }
            set { Time = value; }
        }
        

    }
}
