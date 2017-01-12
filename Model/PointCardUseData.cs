using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class PointCardUseData
    {

        private string cuNumber;
        private int cuPointValue;
        private string cuMask;
        private DateTime cuDateTime;
        private Int32 cuType;

        public PointCardUseData(){  }

        /// <summary>
        /// 用于客户端个人查询充值的构造函数
        /// </summary>       
        public PointCardUseData(string cuNumber, int cuPointValue, DateTime cuDateTime)
        {
            this.cuNumber = cuNumber;
            this.cuPointValue = cuPointValue;
            this.cuDateTime = cuDateTime;
        }

        public string CuNumber
        {
            get { return cuNumber; }
            set { cuNumber = value; }
        }
        public int CuPointValue
        {
            get { return cuPointValue; }
            set { cuPointValue = value; }
        }
        public string CuMask
        {
            get { return cuMask; }
            set { cuMask = value; }
        }
        public DateTime CuDateTime
        {
            get { return cuDateTime; }
            set { cuDateTime = value; }
        }
        public Int32 CuType {
            get {
                return cuType;
            }
            set {
                cuType = value;
            }
        }


    }
}
