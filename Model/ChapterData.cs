using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class ChapterData
    {
        private int pcId;
        private string pcName;
        private int pcOrder;
        private int pcBitrate;
        private int pcSizeHigh;
        private int pcSizeLow;
        private int pcDuration;
        private int pcProgramId;
        private int pcMediaKind;

        //视图数据   
        private string Kbps;
        private string Time;



        public ChapterData() {
        }

        public ChapterData( int pcId,string pcName, int pcOrder,int pcBitrate,int pcSizeHigh,int pcSizeLow,int pcDuration, int pcProgramId,int pcMediaKind)
        {
            this.pcId = pcId;
            this.pcName = pcName;
            this.pcOrder = pcOrder;
            this.pcBitrate = pcBitrate;
            this.pcSizeHigh = pcSizeHigh;
            this.pcSizeLow = pcSizeLow;
            this.pcDuration = pcDuration;
            this.pcProgramId = pcProgramId;
            this.pcMediaKind = pcMediaKind;
        }

        public int PcId
        {
            get { return pcId; }
            set { pcId = value; }
        }
        public string PcName
        {
            get { return pcName; }
            set { pcName = value; }
        }
        public int PcOrder
        {
            get { return pcOrder; }
            set { pcOrder = value; }
        }
        public int PcBitrate
        {
            get { return pcBitrate; }
            set { pcBitrate = value; }
        }
        public int PcSizeHigh
        {
            get { return pcSizeHigh; }
            set { pcSizeHigh = value; }
        }
        public int PcSizeLow
        {
            get { return pcSizeLow; }
            set { pcSizeLow = value; }
        }
        public int PcDuration
        {
            get { return pcDuration; }
            set { pcDuration = value; }
        }
        public int PcProgramId
        {
            get { return pcProgramId; }
            set { pcProgramId = value; }
        }
        public int PcMediaKind
        {
            get { return pcMediaKind; }
            set { pcMediaKind = value; }
        }

        //视图数据
       

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
