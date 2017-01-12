using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserData
    {

        private int uId;
        private string uMask;
        private string uName;
        private string uPasswd;
        private string uInfo;
        private int uPermit;
        private int uGroupMask;
        private int uPoint;
        private DateTime uMonthCardValid; //  �û����¿�/���ѿ���Ч��


        //ת����Ĵ洢
        private int groupPermit = 0;
        private int groupClass = 0;
        private string groupName = string.Empty; // ��ȥ ������ʾ�û���Ϣʱ�Ż��ȡ�����Լ�ʱ��ȡ


        /// <summary>
        /// 
        /// </summary>
        public UserData() { }


        public UserData(int uId,string uMask,string uName)
        {
            this.uId = uId;
            this.uMask = uMask;
            this.uName = uName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="uMask"></param>
        /// <param name="uName"></param>
        /// <param name="uPasswd"></param>
        /// <param name="uInfo"></param>
        /// <param name="uPermit"></param>
        /// <param name="uGroupMask"></param>
        public UserData(int uId, string uMask, string uName, string uPasswd, string uInfo, int uPermit, 
            int uGroupMask,int uPoint,DateTime uMonthCardValid)
        {
            this.uId = uId;
            this.uMask = uMask;
            this.uName = uName;
            this.uPasswd = uPasswd;
            this.uInfo = uInfo;
            this.uPermit = uPermit;
            this.uGroupMask = uGroupMask;
            this.uPoint = uPoint;
            this.uMonthCardValid = uMonthCardValid;
        }

        //Properties

        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }

        public string UMask
        {
            get { return uMask; }
            set { uMask = value; }
        }

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }

        public string UPasswd 
        {
            get { return uPasswd ; }
            set { uPasswd = value; }
        }
        public string UInfo
        {
            get { return uInfo; }
            set { uInfo = value; }
        }

        public int UPermit
        {
            get { return uPermit; }
            set { uPermit = value; }
        }
        public int UGroupMask
        {
            get { return uGroupMask; }
            set { uGroupMask = value; }
        }

        public int UPoint
        {
            get { return uPoint; }
            set { uPoint = value; }
        }
        public DateTime UMonthCardValid {
            get {
                return uMonthCardValid;
            }
            set {
                uMonthCardValid = value;
            }
        }


        //����Ҫ����ͼ����
        public int GroupPermit
        {
            get { return groupPermit; }
            set { groupPermit = value; }
        }
        public int GroupClass
        {
            get { return groupClass; }
            set { groupClass = value; }
        }        
      
    }
}
