using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class CourseData
    {
        private int mcID;
        private string mcCourseName;
        private string mcCourseInfo;
        private int mcUserId;
        private DateTime mcCreateDate;


        public CourseData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public CourseData(int mcID,string mcCourseName,string mcCourseInfo,int mcUserId,DateTime mcCreateDate)
        {
            this.mcID = mcID;
            this.mcCourseName = mcCourseName;
            this.mcCourseInfo = mcCourseInfo;
            this.mcUserId = mcUserId;
            this.mcCreateDate = mcCreateDate;
        }

        public int McID
        {
            get { return mcID; }
            set { mcID = value; }
        }

        public string McCourseName
        {
            get { return  mcCourseName; }
            set {  mcCourseName = value; }
        }

        public string McCourseInfo
        {
            get { return  mcCourseInfo; }
            set {  mcCourseInfo = value; }
        }
        public int McUserId
        {
            get { return  mcUserId; }
            set {  mcUserId = value; }
        }

        public DateTime McCreateDate
        {
            get { return  mcCreateDate; }
            set {  mcCreateDate = value; }
        }




      
    }
}
