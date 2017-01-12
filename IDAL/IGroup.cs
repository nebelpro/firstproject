using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL {
    public interface IGroup {

        /// <summary>
        /// 插入组
        /// </summary>
        /// <param name="groupdata"></param>
        /// <returns></returns>
        Int32 Insert(GroupData groupdata);


        /// <summary>
        /// 提取组别信息
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns></returns>
        GroupData GetDetailById(Int32 gid);

        /// <summary>
        /// 更新组信息
        /// </summary>
        /// <param name="groupdata"></param>
        /// <returns></returns>
        Int32 Update(GroupData groupdata);

        /// <summary>
        /// 删除组,并更新该组用户的组掩码(在存储过程处理)
        /// </summary>
        /// <param name="nGroupId"></param>
        /// <returns></returns>
        Int32 Delete(Int32 nGroupId);

        /// <summary>
        /// 根据用户权限值，提取用户所属的众多组别
        /// </summary>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        IList<GroupData> GetGroupByUserGroupMask(Int32 nGroupMask);

        /// <summary>
        /// 分页读取组列表
        /// </summary>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        IList<GroupData> GetList(Int32 nPage, Int32 nPageSize);

        /// <summary>
        /// 组总数
        /// </summary>
        /// <returns></returns>
        Int32 GetCount();    
    }
}
