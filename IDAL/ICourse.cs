using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;
namespace MOD.IDAL
{
    public interface ICourse
    {
        // *** 此接口暂不实现

        /// <summary>
        /// 分页显示课程列表
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<CourseData> GetList(Int32 nUserId, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 课程总数
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nUserId);

        Int32 Insert(CourseData coursedata);

        Int32 Update(CourseData coursedata);

        Int32 Delete(Int32 nCourseId);

        /// <summary>
        /// 取某个用户的某个课程详细信息
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        CourseData GetDetail(Int32 nCourseId);


    }
}
