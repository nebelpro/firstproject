using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
   public class SettingData
    {
        private int sId;
        private string sKey;
        private string sValue;

       public SettingData() { }

       public SettingData(int sId, string sKey, string sValue)
       {
           this.sId = sId;
           this.sKey = sKey;
           this.sValue = sValue;
       }

        public int SId
        {
            get { return sId; }
            set { sId = value; }
        }
        public string SKey
        {
            get { return sKey; }
            set { sKey = value; }
        }
        public string SValue
        {
            get { return sValue; }
            set { sValue = value; }
        }
    }
}
