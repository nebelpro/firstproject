using System;
using System.Text;
using System.Collections.Generic;
using MOD.Model;

namespace MOD.IDAL {

    /// <summary>
    /// IUser 用户操作类接口
    /// </summary>
    public interface IUser
    {

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="strMask">帐号</param>
        /// <param name="strPassword">密码</param>
        /// <param name="nRet">输出参数,返回登陆状态 1成功,0 密码错误,-1 帐号不存</param>
        /// <returns>成功登陆后的用户数据对象,登陆失败则为NULL</returns>
        UserData Login(String strMask,String strPassword,out Int32 nRet);

        /// <summary>
        /// 根据用户ID 获取用户信息
        /// </summary>
        /// <param name="nUserId">用户ID</param>
        /// <returns>用户数据对象</returns>
        UserData GetUserById(Int32 nUserId);

        /// <summary>
        /// 根据用户MASK获取用户信息
        /// </summary>
        /// <param name="strUserMask">用户帐号</param>
        /// <returns>用户数据对象</returns>
        UserData GetUserByMask(String strUserMask);

       /// <summary>
       /// 修改用户密码
       /// </summary>
       /// <param name="nUserId">用户id</param>
       /// <param name="strNewPassword">用户新的密码</param>
       /// <returns>返回Int32值,1  成功,0失败</returns>
       Int32 UpdateUserPwdById(Int32 nUserId, String strOldPassword,String strNewPassword);

        /// <summary>
        /// 插入新用户信息
        /// </summary>
        /// <param name="userda">用户实体</param>
        /// <returns></returns>
        Int32 InsertUser(UserData userda);

        /// <summary>
        /// 根据ID取用户名UserName
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        String GetUserNameById(Int32 nUserId);

       /// <summary>
       /// 取得用户所拥有的剩余点数
       /// </summary>
       /// <param name="nUserId"></param>
       /// <returns></returns>
       Int32 GetUserPointById(Int32 nUserId);
        
        /// <summary>
       /// 更新用户的点卡数值(此函数概括加点和减点：利用传递的正负值来实现)
       /// </summary>
       /// <param name="nUserId">用户ID</param>
       /// <param name="nPoint">点卡值</param>
       /// <returns></returns>
       Int32 UpdateUserPointById(Int32 nUserId, Int32 nPoint); 

        /// <summary>
       /// 取得用户包月卡/消费卡的有效期
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns>返回日期的字符形式</returns>
        String GetUserMonthCardValid(Int32 nUserId);

        /// <summary>
        /// 更新用户包月卡/消费卡的有效期
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtValid">有效日期</param>
        /// <returns></returns>
        Int32 UpdateUserMonthCard(Int32 nUserId, DateTime dtValid);

      
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="nUserId">用户id</param>
        /// <returns></returns>
        Int32 DelUserById(Int32 nUserId);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userda"></param>
        /// <returns></returns>
        Int32 UpdateUserById(UserData userda);


        /// <summary>
        /// 通过用户帐号搜索
        /// </summary>
        /// <param name="strSearchKey"></param>
        /// <param name="nPage">当前页数</param>
        /// <param name="nPageSize">每页显示数量</param>
        /// <returns></returns>        
        IList<UserData> SearchUserByMask(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize);

        IList<UserData> SearchUserByName(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize);
        /// <summary>
        /// 取得搜索记录总数
        /// </summary>
        /// <param name="strSearchKey"></param>
        /// <returns></returns>       
        Int32 SearchUserByMaskCount(Int32 nGroupMask, String strSearchKey);

        Int32 SearchUserByNameCount(Int32 nGroupMask, String strSearchKey);
        /// <summary>
        /// 根据组分页读取用户列表
        /// </summary>
        /// <param name="nGroupMask">组别掩码,0表示全部</param>
        /// <param name="nPage">当前页数</param>
        /// <param name="nPageSize">每页显示数量</param>
        /// <returns></returns>
        IList<UserData> GetList(Int32 nGroupMask,Int32 nPage,Int32 nPageSize);

         /// <summary>
        ///  取全部用户（不分页）
        /// </summary>
        /// <returns></returns>
        IList<UserData> GetList();

        /// <summary>
        /// 取得该组下用户总数
        /// </summary>
        /// <param name="nGroupMask">组别掩码,0表示全部</param>
        /// <returns></returns>
        Int32 GetCount(Int32 nGroupMask);



    }
}
