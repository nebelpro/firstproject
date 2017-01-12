using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    [Serializable]
    public class PointCardData
    {
        private int pcId;
        private string pcNumber;
        private string pcPasswd;
        private int pcState;
        private DateTime pcValidDate;
        private int pcPointValue;
        private string pcMakeUser;
        private int pcType;

        


        public PointCardData()
        {
        }
        public PointCardData(int pcId,string pcNumber,string pcPasswd,int pcState,DateTime pcValidDate,int pcPointValue,string pcMakeUser )
        {
            this.pcId = pcId;
            this.pcNumber = pcNumber;
            this.pcPasswd = pcPasswd;
            this.pcState = pcState;
            this.pcValidDate = pcValidDate;
            this.pcPointValue = pcPointValue;
            this.pcMakeUser = pcMakeUser;
        }

        public int PcId
        {
            get { return pcId; }
            set { pcId = value; }
        }

        public string PcNumber
        {
            get { return pcNumber; }
            set { pcNumber = value; }
        }

        public string PcPasswd
        {
            get { return pcPasswd; }
            set { pcPasswd = value; }
        }
        public int PcState
        {
            get { return pcState; }
            set { pcState = value; }
        }
        public DateTime PcValidDate
        {
            get { return pcValidDate; }
            set { pcValidDate = value; }
        }
        public string PcMakeUser
        {
            get { return pcMakeUser; }
            set { pcMakeUser = value; }
        }

        public int PcPointValue
        {
            get { return pcPointValue; }
            set { pcPointValue = value; }
        }

        public int PcType
        {
            get { return pcType; }
            set { pcType = value; }
        }

    }
}
