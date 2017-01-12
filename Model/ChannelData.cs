using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{

    [Serializable]
    public class ChannelData
    {
        private int cId;
        private string cName;
        private string cInfo;
        private string cRebroadCaster;
        private int cType;
        private int cState;
        private DateTime cStateTime;
        private string cAllowUser;
        private string cAllowGroup;
        private string cForbidUser;
        private string cForbidGroup;
        private int cProperty;
        private int cBroadcasterId;
        private string cGuid;
        private int cUserId;
        private DateTime cCreateTime;
        private DateTime cBeginTime;
        private int cSsrc;
        private string cUploadMediaServer;
        private int cControlState;
        private int cNeedReload;
        private int cChannelAddressId;
        private int cRebroadChannelId;
        private int cControlMask;


        //视图数据
        private string beginTime = string.Empty;
        private string status = string.Empty;
        private string userName = string.Empty;


      
       


        public ChannelData()
        {

        }

        public ChannelData(int cId, string cName, string cInfo, int cState,
            int cUserId, DateTime cCreateTime, DateTime cBeginTime, int cType,
            string cAllowGroup, string cForbidUser, string cGuid, int cSsrc, string cUploadMediaServer)
        {
            this.cId = cId;
            this.cName = cName;
            this.cInfo = cInfo;
            this.cState = cState;
            this.cUserId = cUserId;
            this.cCreateTime = cCreateTime;
            this.cBeginTime = cBeginTime;
            this.cType = cType;
            this.cAllowGroup = cAllowGroup;
            this.cForbidUser = cForbidUser;
            this.cGuid = cGuid;
            this.cSsrc = cSsrc;
            this.cUploadMediaServer = cUploadMediaServer;
        }



        public int CId
        {
            get { return cId; }
            set { cId = value; }
        }
        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }
        public string CInfo
        {
            get { return cInfo; }
            set { cInfo = value; }
        }
        public string CRebroadCaster
        {
            get { return cRebroadCaster; }
            set { cRebroadCaster = value; }
        }
        public int CType
        {
            get { return cType; }
            set { cType = value; }
        }
        public int CState
        {
            get { return cState; }
            set { cState = value; }
        }
        public DateTime CStateTime
        {
            get { return cStateTime; }
            set { cStateTime = value; }
        }
        public string CAllowUser
        {
            get { return cAllowUser; }
            set { cAllowUser = value; }
        }
        public string CAllowGroup
        {
            get { return cAllowGroup; }
            set { cAllowGroup = value; }
        }
        public string CForbidUser
        {
            get { return cForbidUser; }
            set { cForbidUser = value; }
        }
        public string CForbidGroup
        {
            get { return cForbidGroup; }
            set { cForbidGroup = value; }
        }
        public int CProperty
        {
            get { return cProperty; }
            set { cProperty = value; }
        }
        public int CBroadcasterId
        {
            get { return cBroadcasterId; }
            set { cBroadcasterId = value; }
        }
        public string CGuid
        {
            get { return cGuid; }
            set { cGuid = value; }
        }
        public int CUserId
        {
            get { return cUserId; }
            set { cUserId = value; }
        }
        public DateTime CCreateTime
        {
            get { return cCreateTime; }
            set { cCreateTime = value; }
        }
        public DateTime CBeginTime
        {
            get { return cBeginTime; }
            set { cBeginTime = value; }
        }
        public int CSsrc
        {
            get { return cSsrc; }
            set { cSsrc = value; }
        }
        public string CUploadMediaServer
        {
            get { return cUploadMediaServer; }
            set { cUploadMediaServer = value; }
        }
        public int CControlState
        {
            get { return cControlState; }
            set { cControlState = value; }
        }
        public int CNeedReload
        {
            get { return cNeedReload; }
            set { cNeedReload = value; }
        }
        public int CChannelAddressId
        {
            get { return cChannelAddressId; }
            set { cChannelAddressId = value; }
        }
        public int CRebroadChannelId
        {
            get { return cRebroadChannelId; }
            set { cRebroadChannelId = value; }
        }
        public int CControlMask
        {
            get { return cControlMask; }
            set { cControlMask = value; }
        }

        //视图数据
        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
