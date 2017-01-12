using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
   public class CatalogData
    {
       private int cId;
       private string cName;
       private string cSerial;
       private int cSerialIndex;
       private int cParentId;
       private int cIsDefault;
       private int cDefClass;
       private int cDefGroup;

       public CatalogData() { }
       public CatalogData(int cId,string cName,string cSerial,int cSerialIndex,int cParentId,int cIsDefault,
           int cDefClass,int cDefGroup)
       {
           this.cId = cId;
           this.cName = cName;
           this.cSerial = cSerial;
           this.cSerialIndex = cSerialIndex;
           this.cParentId = cParentId;
           this.cIsDefault = cIsDefault;
           this.cDefClass = cDefClass;
           this.cDefGroup = cDefGroup;
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
       public string CSerial
       {
           get { return cSerial; }
           set { cSerial = value; }
       }

       public int CSerialIndex
       {
           get { return cSerialIndex; }
           set { cSerialIndex = value; }
       }

       public int CParentId
       {
           get { return cParentId; }
           set { cParentId = value; }
       }
       public int CIsDefault
       {
           get { return cIsDefault; }
           set { cIsDefault = value; }
       }

       public int CDefClass
       {
           get { return cDefClass; }
           set { cDefClass = value; }
       }

       public int CDefGroup
       {
           get { return cDefGroup; }
           set { cDefGroup = value; }
       }

















    }
}
