using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
   public class GroupData
    {
        private int gId;
        private string gName;
        private string gInfo;
        private int gPermit;
        private int gPermit2;
        private int gMask;
        private int gClass;

       /// <summary>
       /// 
       /// </summary>
       public GroupData() { }

       public GroupData(int gMask,string gName,int gId)
       {
           this.gMask = gMask;
           this.gName = gName;
           this.gId = gId;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="gId"></param>
       /// <param name="gName"></param>
       /// <param name="gInfo"></param>
       /// <param name="gPermit"></param>
       /// <param name="gPermit2"></param>
       /// <param name="gMask"></param>
       /// <param name="gClass"></param>
       public GroupData(int gId, string gName, string gInfo, int gPermit, int gPermit2, int gMask, int gClass)
       {
           this.gId = gId;
           this.gName = gName;
           this.gInfo = gInfo;
           this.gPermit = gPermit;
           this.gPermit2 = gPermit2;
           this.gMask = gMask;
           this.gClass = gClass;
       }
       /// <summary>
       /// 
       /// </summary>
       public int GId
       {
           get { return gId; }
           set { gId = value; }
       }

       public string GName
       {
           get { return gName; }
           set { gName = value; }
       }

       public int GPermit
       {
           get { return gPermit; }
           set { gPermit = value; }
       }
       public int GPermit2
       {
           get { return gPermit2; }
           set { gPermit2 = value; }
       }

       public int GMask
       {
           get { return gMask; }
           set { gMask = value; }
       }

       public int GClass
       {
           get { return gClass; }
           set { gClass = value; }
       }
       public String GInfo {
           get {
               return gInfo;
           }
           set {
               gInfo = value;
           }
       }


    }
}
