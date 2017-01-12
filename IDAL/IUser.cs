using System;
using System.Text;
using System.Collections.Generic;
using MOD.Model;

namespace MOD.IDAL {

    /// <summary>
    /// IUser �û�������ӿ�
    /// </summary>
    public interface IUser
    {

        /// <summary>
        /// �û���½
        /// </summary>
        /// <param name="strMask">�ʺ�</param>
        /// <param name="strPassword">����</param>
        /// <param name="nRet">�������,���ص�½״̬ 1�ɹ�,0 �������,-1 �ʺŲ���</param>
        /// <returns>�ɹ���½����û����ݶ���,��½ʧ����ΪNULL</returns>
        UserData Login(String strMask,String strPassword,out Int32 nRet);

        /// <summary>
        /// �����û�ID ��ȡ�û���Ϣ
        /// </summary>
        /// <param name="nUserId">�û�ID</param>
        /// <returns>�û����ݶ���</returns>
        UserData GetUserById(Int32 nUserId);

        /// <summary>
        /// �����û�MASK��ȡ�û���Ϣ
        /// </summary>
        /// <param name="strUserMask">�û��ʺ�</param>
        /// <returns>�û����ݶ���</returns>
        UserData GetUserByMask(String strUserMask);

       /// <summary>
       /// �޸��û�����
       /// </summary>
       /// <param name="nUserId">�û�id</param>
       /// <param name="strNewPassword">�û��µ�����</param>
       /// <returns>����Int32ֵ,1  �ɹ�,0ʧ��</returns>
       Int32 UpdateUserPwdById(Int32 nUserId, String strOldPassword,String strNewPassword);

        /// <summary>
        /// �������û���Ϣ
        /// </summary>
        /// <param name="userda">�û�ʵ��</param>
        /// <returns></returns>
        Int32 InsertUser(UserData userda);

        /// <summary>
        /// ����IDȡ�û���UserName
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        String GetUserNameById(Int32 nUserId);

       /// <summary>
       /// ȡ���û���ӵ�е�ʣ�����
       /// </summary>
       /// <param name="nUserId"></param>
       /// <returns></returns>
       Int32 GetUserPointById(Int32 nUserId);
        
        /// <summary>
       /// �����û��ĵ㿨��ֵ(�˺��������ӵ�ͼ��㣺���ô��ݵ�����ֵ��ʵ��)
       /// </summary>
       /// <param name="nUserId">�û�ID</param>
       /// <param name="nPoint">�㿨ֵ</param>
       /// <returns></returns>
       Int32 UpdateUserPointById(Int32 nUserId, Int32 nPoint); 

        /// <summary>
       /// ȡ���û����¿�/���ѿ�����Ч��
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns>�������ڵ��ַ���ʽ</returns>
        String GetUserMonthCardValid(Int32 nUserId);

        /// <summary>
        /// �����û����¿�/���ѿ�����Ч��
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="dtValid">��Ч����</param>
        /// <returns></returns>
        Int32 UpdateUserMonthCard(Int32 nUserId, DateTime dtValid);

      
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="nUserId">�û�id</param>
        /// <returns></returns>
        Int32 DelUserById(Int32 nUserId);

        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        /// <param name="userda"></param>
        /// <returns></returns>
        Int32 UpdateUserById(UserData userda);


        /// <summary>
        /// ͨ���û��ʺ�����
        /// </summary>
        /// <param name="strSearchKey"></param>
        /// <param name="nPage">��ǰҳ��</param>
        /// <param name="nPageSize">ÿҳ��ʾ����</param>
        /// <returns></returns>        
        IList<UserData> SearchUserByMask(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize);

        IList<UserData> SearchUserByName(Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize);
        /// <summary>
        /// ȡ��������¼����
        /// </summary>
        /// <param name="strSearchKey"></param>
        /// <returns></returns>       
        Int32 SearchUserByMaskCount(Int32 nGroupMask, String strSearchKey);

        Int32 SearchUserByNameCount(Int32 nGroupMask, String strSearchKey);
        /// <summary>
        /// �������ҳ��ȡ�û��б�
        /// </summary>
        /// <param name="nGroupMask">�������,0��ʾȫ��</param>
        /// <param name="nPage">��ǰҳ��</param>
        /// <param name="nPageSize">ÿҳ��ʾ����</param>
        /// <returns></returns>
        IList<UserData> GetList(Int32 nGroupMask,Int32 nPage,Int32 nPageSize);

         /// <summary>
        ///  ȡȫ���û�������ҳ��
        /// </summary>
        /// <returns></returns>
        IList<UserData> GetList();

        /// <summary>
        /// ȡ�ø������û�����
        /// </summary>
        /// <param name="nGroupMask">�������,0��ʾȫ��</param>
        /// <returns></returns>
        Int32 GetCount(Int32 nGroupMask);



    }
}
