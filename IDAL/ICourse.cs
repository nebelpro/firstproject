using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;
namespace MOD.IDAL
{
    public interface ICourse
    {
        // *** �˽ӿ��ݲ�ʵ��

        /// <summary>
        /// ��ҳ��ʾ�γ��б�
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<CourseData> GetList(Int32 nUserId, Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// �γ�����
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        Int32 GetCount(Int32 nUserId);

        Int32 Insert(CourseData coursedata);

        Int32 Update(CourseData coursedata);

        Int32 Delete(Int32 nCourseId);

        /// <summary>
        /// ȡĳ���û���ĳ���γ���ϸ��Ϣ
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        CourseData GetDetail(Int32 nCourseId);


    }
}
