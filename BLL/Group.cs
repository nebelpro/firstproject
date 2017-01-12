using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Group {

        private static readonly MOD.IDAL.IGroup dal = MOD.DALFactory.DataAccess.CreateGroup();

        public enum Enum_Group_WARN {
            GROUP_COUNTOUT = -2,
            GROUP_EXIST = -1,
            GROUP_SUCCESS = 1
        }


        /// <summary>
        /// 添加新组
        /// </summary>
        /// <param name="groupdata">The groupdata.</param>
        /// <returns></returns>
        public Int32 AddGroup( GroupData groupdata ) {

            Int32 nGroupCount = GetCount();
            if (nGroupCount >= 32) {
                return (Int32)Enum_Group_WARN.GROUP_COUNTOUT;
            } else {
                groupdata.GMask = GetGroupMask();
                return dal.Insert(groupdata);
            }


        }

        public GroupData GetDetailById( Int32 gid ) {
            return dal.GetDetailById(gid);
        }
        /// <summary>
        /// 删除组，并更改该组下的组别掩码（存储过程中处理）
        /// </summary>
        /// <param name="nGroupId">The n group id.</param>
        public void DelGroup( Int32 nGroupId ) {
            dal.Delete(nGroupId);
        }

        /// <summary>
        /// 更新组信息
        /// </summary>
        /// <param name="groupdata">The groupdata.</param>
        /// <returns></returns>
        public Int32 UpdateGroup( GroupData groupdata ) {

            return dal.Update(groupdata);
        }

        /// <summary>
        /// 分页读取组列表.
        /// </summary>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        public IList<GroupData> GetList( Int32 nPage, Int32 nPageSize ) {

            return dal.GetList(nPage, nPageSize);
        }

        /// <summary>
        /// 组总数
        /// </summary>
        /// <returns></returns>
        public Int32 GetCount() {
            return dal.GetCount();
        }

        /// <summary>
        /// 根据用户GroupMask提取用户属的组别
        /// </summary>
        /// <param name="nUserGroupMask">The user group mask.</param>
        /// <returns></returns>
        public IList<GroupData> GetListByUserGroupMask( Int32 nUserGroupMask ) {

            return dal.GetGroupByUserGroupMask(nUserGroupMask);
        }




        /// <summary>
        /// 添加组别时，寻找合适的插空位置
        /// </summary>
        /// <returns></returns>
        private int GetGroupMask() {
            Int32 nMask = -1;

            IList<GroupData> gdList = (new Group()).GetList(1, 100);
            System.Collections.IEnumerator myEnum = gdList.GetEnumerator();
            if (gdList.Count != 0) {
                string strGroupMask = "";
                int j = 0;
                while (myEnum.MoveNext()) {
                    GroupData gd = (GroupData)myEnum.Current;
                    if (j == 0) {
                        strGroupMask = gd.GMask.ToString();
                        j++;
                    } else {
                        strGroupMask = strGroupMask + "," + gd.GMask.ToString();
                        j++;
                    }
                }
                Int32 nTmpMask = 1;
                for (int i = 0; i <= 31; i++) {
                    if (i == 0)
                        nTmpMask = 1;
                    else
                        nTmpMask = nTmpMask * 2;
                    if (strGroupMask.IndexOf(nTmpMask.ToString()) == -1) {
                        nMask = nTmpMask;
                        break;
                    }
                }
            } else {
                nMask = 1;
            }
            if (nMask == 2147483648)   //?????????编译时警告超出范围
                nMask = -2147483648;

            return nMask;
        }

    }
}
