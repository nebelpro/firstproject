using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class PointCardPlayData
    {
        private int pcpId;
        private string pcpUserMask;
        private string pcpProgramName;
        private int pcpProgramId;
        private DateTime pcpDateTime;
        private int pcpProgramPoint;


       
        public PointCardPlayData() { }
        public PointCardPlayData(string pcpProgramName, int pcpProgramId, DateTime pcpDateTime, int pcpProgramPoint)
        {
            this.pcpProgramName = pcpProgramName;
            this.pcpProgramId = pcpProgramId;
            this.pcpDateTime = pcpDateTime;
            this.pcpProgramPoint = pcpProgramPoint;
        }

        public int PcpId
        {
            get { return pcpId; }
            set { pcpId = value; }
        }

        public string PcpUserMask
        {
            get { return pcpUserMask; }
            set { pcpUserMask = value; }
        }

        public string PcpProgramName
        {
            get { return pcpProgramName; }
            set { pcpProgramName = value; }
        }
        public int PcpProgramId
        {
            get { return pcpProgramId; }
            set { pcpProgramId = value; }
        }
        public DateTime PcpDateTime
        {
            get { return pcpDateTime; }
            set { pcpDateTime = value; }
        }
        public int PcpProgramPoint
        {
            get { return pcpProgramPoint; }
            set { pcpProgramPoint = value; }
        }
    }
}
