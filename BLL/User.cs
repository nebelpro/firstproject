using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using NLog;
using MOD.Model;

namespace MOD.BLL {
    public class User {

        private static readonly MOD.IDAL.IUser dal = MOD.DALFactory.DataAccess.CreateUser();

        public enum ENUM_RET_LOGIN {
            RET_SUCCESS = 1,
            RET_ERR_PASSWD = 0,
            RET_ERR_ACCOUNT = -1,
            RET_ERR_GROUP = -2,
            RET_ERR_NOLOGIN = -3
        }

        public enum ENUM_RET_REGISTER {
            RET_SUCCESS = 1,
            RET_EXIST = -1,
            RET_FAILD_PRIVATE_FOLD = 0
        }
        public enum ENUM_RET_ADDPOINT {
            SUCCESS = 1,//�ɹ�
            NOT_EXIST = -1,//���Ų�����
            ERR_PWD = -2, //�������
            ERR_INVALID = -3, // ����
            HAS_USE = -4, // ��ʹ��
            ERR_TYPE = -5 // ���ʹ���
        }



        /// <summary>
        /// �û���½���� :  
        /// ����DAL���ص�nRet = 1ʱ,�����û��߼���֤,��Ȩ�ޡ����ȫ�Ե�
        /// ��֤ʧ��(0,-1)ʱ nRet ����ָ����ֵ����������NULL
        /// ��֤�ɹ��󣬷���USERDATA
        /// nRet = 1;
        /// return null;
        /// </summary>
        /// <param name="strMask"></param>
        /// <param name="strPassword"></param>
        /// <param name="nRet">1����DAL���óɹ���ʵ����ڣ�0 ������� -1 �˺Ŵ��� 2 ������  3  û�е�¼Ȩ�� </param>
        /// <returns></returns>
        public UserData Login( String strMask, String strPassword, out Int32 nRet ) {
            // check account is card no

            UserData userdata = dal.Login(strMask, strPassword, out nRet);//��� �������� 0,-1
            if (nRet == (Int32)ENUM_RET_LOGIN.RET_SUCCESS)//����nRet�ж�
            {
                if (GetUserPermit(ref userdata))//��� �������� 2
                {
                    if ((new Permit(userdata.UPermit, userdata.GroupPermit)).CanLogin())//���������� 3
                    {
                        return userdata;
                    } else {
                        nRet = (Int32)ENUM_RET_LOGIN.RET_ERR_NOLOGIN;
                        return null;
                    }
                } else {
                    nRet = (Int32)ENUM_RET_LOGIN.RET_ERR_GROUP;
                    return null;
                }
            } else {
                return null;
            }

        }

        /// <summary>
        /// �û�ע�ᣨ�����ṩ˽��Ŀ¼��
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns>-1 �û����Ѿ����ڣ�0:����˽��Ŀ¼ʧ�ܣ�����AddCatalog����ֵ�жϣ�,1���ɹ�</returns>
        public Int32 Register( UserData userdata ) {

            int nRet = AddUser(userdata);//���� -1 ��1
            /*if (nRet == (Int32)ENUM_RET_REGISTER.RET_SUCCESS)
            {
                //AddCatalog:-1,-2,1��
               // (new Catalog()).AddCatalog(10, userdata.UMask);

                  ����˽��Ŀ¼��Ӹ��������ƣ��۲�����˽��Ŀ¼����ʧ�ܵ����
                 * 
                 * if ((new Catalog()).AddCatalog(10, userdata.UMask) != 1)
                {
                    nRet = (Int32)ENUM_RET_REGISTER.RET_FAILD_PRIVATE_FOLD;
                }
            }*/
            return nRet;
        }

        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="strOldPassword">The STR old password.</param>
        /// <param name="strNewPassword">The STR new password.</param>
        /// <returns>0��ԭ�������1���ɹ�</returns>
        public Int32 ModifyPassword( Int32 nUserId, String strOldPassword, String strNewPassword ) {

            return dal.UpdateUserPwdById(nUserId, strOldPassword, strNewPassword);
        }

        /// <summary>
        /// �����û���ϸ��Ϣ,�����Ϣ�ȿ���Щ����һЩת��
        /// </summary>
        /// <param name="nUserId"></param>
        /// <returns></returns>
        public UserData GetDetail( Int32 nUserId ) {
            return dal.GetUserById(nUserId);
        }

        public UserData GetDetail( String strMask ) {
            return dal.GetUserByMask(strMask);
        }

        /// <summary>
        /// ������ ��ҳ��ȡ�û��б�
        /// </summary>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        public IList<UserData> GetList( Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {

            //��������ȷ��Ҫת����Щ��ͼ����
            return dal.GetList(nGroupMask, nPage, nPageSize);
        }

        /// <summary>
        ///  ȡȫ���û�������ҳ��
        /// </summary>
        /// <returns></returns>
        public IList<UserData> GetList() {
            return dal.GetList();
        }

        public IList<UserData> SearchUserByMask( Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize ) {
            return dal.SearchUserByMask(nGroupMask, strSearchKey, nPage, nPageSize);
        }

        public IList<UserData> SearchUserByName( Int32 nGroupMask, String strSearchKey, Int32 nPage, Int32 nPageSize ) {
            return dal.SearchUserByName(nGroupMask, strSearchKey, nPage, nPageSize);
        }
        /// <summary>
        /// ȡ��������¼����
        /// </summary>
        /// <param name="strSearchKey"></param>
        /// <returns></returns>       
        public Int32 SearchUserByMaskCount( Int32 nGroupMask, String strSearchKey ) {
            return dal.SearchUserByMaskCount(nGroupMask, strSearchKey);
        }

        public Int32 SearchUserByNameCount( Int32 nGroupMask, String strSearchKey ) {
            return dal.SearchUserByNameCount(nGroupMask, strSearchKey);
        }


        /// <summary>
        /// ȡ��ĳһ������û����� 0:��ʾȫ��
        /// </summary>
        /// <param name="nGroupMask">The group mask.</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nGroupMask ) {

            return dal.GetCount(nGroupMask);
        }

        /// <summary>
        /// �������û���Ϣ
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns>-1:�˺��Ѿ����ڣ�1���ɹ�</returns>
        public Int32 AddUser( UserData userdata ) {

            return dal.InsertUser(userdata);

        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        public void DelUser( Int32 nUserId ) {

            dal.DelUserById(nUserId);
        }

        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns></returns>
        public Int32 UpdateUser( UserData userdata ) {

            return dal.UpdateUserById(userdata);
        }


        /// <summary>
        /// ȡ�û�ӵ�е�ʣ�����
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <returns></returns>
        public Int32 GetUserPoint( Int32 nUserId ) {

            return dal.GetUserPointById(nUserId);
        }
        /// <summary>
        /// ȡ�û��İ��¿�/���ѿ�����Ч��
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <returns></returns>
        public String GetUserMonthCardValid( Int32 nUserId ) {

            return dal.GetUserMonthCardValid(nUserId);
        }

        /// <summary>
        /// ����IDȡ�û�����
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <returns></returns>
        public String GetName( Int32 nUserId ) {

            return dal.GetUserNameById(nUserId);
        }


        public Int32 UpdateUserPointById( Int32 nUserId, Int32 nPoint ) {
            return dal.UpdateUserPointById(nUserId, nPoint);
        }



        /// <summary>
        /// ��ֵ����
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="strCardNo"></param>
        /// <param name="strCardPwd"></param>
        /// <returns></returns>
        public Int32 AddUserCard( Int32 nUserId, String strCardNo, String strCardPwd ) {
            // �����ֵ���� 
            // ��鿨״̬��Ϣ���͵�
            // �����û���������Ч��
            // ���¿���״̬
            // ��¼��ֵ��¼

            /*
                ʡ���� ���˺���ʽ�ļ�⣬����UI��
             */

            string strUserMonthValue = GetUserMonthCardValid(nUserId);

            PointCard pointBll = new PointCard();

            PointCardData pointcdata = pointBll.GetPointCardByNo(strCardNo);
            if (pointcdata != null) {
                if (strCardPwd != pointcdata.PcPasswd) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_PWD;//�����������!
                }
                if (pointcdata.PcState == 1) {
                    return (Int32)ENUM_RET_ADDPOINT.HAS_USE; //���ż���ʹ�ù�
                }
                string Valid = pointcdata.PcValidDate.ToShortDateString() + " 23:59:59";
                DateTime dtValid = Convert.ToDateTime(Valid);
                if (dtValid < DateTime.Now) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_INVALID;//�㿨������
                }

                if (pointcdata.PcType == 2) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_TYPE;//�����ʹ���
                }
                //���ż���߼�����,�����ֵ�����м�¼

                //change state
                pointBll.UpdateState(strCardNo, 1);
                //add record
                pointBll.InsertCardUseRecord(pointcdata.PcId, nUserId, DateTime.Now);

                if (pointcdata.PcType == 0) {//add point
                    dal.UpdateUserPointById(nUserId, pointcdata.PcPointValue);
                } else {
                    DateTime nNewDate = DateTime.Now.AddMonths(pointcdata.PcPointValue);
                    TimeSpan nValue = Convert.ToDateTime(strUserMonthValue) - DateTime.Now;
                    if (nValue.TotalDays > 0) {
                        nNewDate = nNewDate.Add(nValue);
                    }
                    dal.UpdateUserMonthCard(nUserId, nNewDate);
                }
            } else {
                return (Int32)ENUM_RET_ADDPOINT.NOT_EXIST;//���Ų�����
            }


            return (Int32)ENUM_RET_ADDPOINT.SUCCESS;//��ֵ�ɹ�

        }


        #region    ת���߼�����

        /// <summary>
        /// ��ȡ�û������Ȩ�ޣ��Ͱ�ȫ��
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <param name="nRet">The n ret.</param>
        public bool GetUserPermit( ref UserData userdata ) {
            Group group = new Group();
            IList<GroupData> grouplist = group.GetListByUserGroupMask(userdata.UGroupMask);
            System.Collections.IEnumerator myEnum = grouplist.GetEnumerator();

            if (grouplist.Count != 0) {
                while (myEnum.MoveNext()) {
                    GroupData grpda = (GroupData)myEnum.Current;
                    int gPermit = grpda.GPermit;
                    int gClass = grpda.GClass;
                    if ((gPermit & PERMIT_TYPE.per_g_login) != 0) {
                        userdata.GroupPermit = userdata.GroupPermit | gPermit;

                        if (userdata.GroupClass < gClass)
                            userdata.GroupClass = gClass;
                    }
                }
                return true;
            } else {
                return false;//������
            }
        }

        #endregion
    }

    /// <summary>
    /// ���ѵ��߼�������۵㣬��Ҫ�۵������û�������Session
    /// </summary>
    public class Consume {
        private static Logger logger = LogManager.GetCurrentClassLogger(); 
        public enum RET {
            //Success  >= 0 (0: free , >0 not free )
            NoLogin = -10,
            ErrPermit = -14,
            ErrGroupMask = -15,           
            NoPoint = -16
             
        };

        private UserData uda;
        private ProgramData pda;

        public DateTime CardValid;//�û���¼�����õĿ���Ч�ڣ��㿨�û�����Ϊ 0��    ���¿�/���ѿ�һ����Session���� UserHelper.SESSION_TYPE.CardValid    
        public Int32 CardType;//��ʱ���ã�ϵͳ��ֻ�����ѿ�����������Ϊ����
        public Int32 consumePoint = 0;
        public Int32 pcIndex = 0;//��Ŀ����ʱ�� ����index������ʱ�� Ƭ�ε�Id
        public Int32 MediaType = 0;
        public Int32 MsId = 0;
       
        /// <summary>
        ///����ȫ���� 
        /// </summary>           
        public Consume( Int32 nUserId, Int32 nProgramId, DateTime dtCardValid, Int32 nPcIndex ):this(nUserId,nProgramId,dtCardValid,nPcIndex,0) {            
        }
        public Consume( Int32 nUserId, Int32 nProgramId, DateTime dtCardValid, Int32 nPcIndex, Int32 nMsId ) {
            this.uda = (new User()).GetDetail(nUserId);
            this.pda = (new Program()).GetDetail(nProgramId);
            (new User()).GetUserPermit(ref this.uda);
            this.CardValid = dtCardValid;
            this.pcIndex = nPcIndex;
            this.MediaType = this.pda.PMediaKind;
            this.MsId = nMsId;
        }
        /// <summary>
        /// ���ڼ���Ŀ�Ƿ�ɷ� 
        /// </summary>      
        public Consume( Int32 nUserId, Int32 nProgramId, DateTime dtCardValid) {
            this.uda = (new User()).GetDetail(nUserId);
            (new User()).GetUserPermit(ref this.uda);
            this.pda = (new Program()).GetDetail(nProgramId);
            this.CardValid = dtCardValid;          
        }
        /// <summary>
        /// ��������
        /// </summary>  
        public Consume( Int32 nUserId, Int32 nProgramId, Int32 nPcIndex )
            : this(nUserId, nProgramId, nPcIndex, 0) {
        }
        public Consume( Int32 nUserId, Int32 nProgramId,Int32 nPcIndex ,Int32 nMsId) {
            this.uda = (new User()).GetDetail(nUserId);
            (new User()).GetUserPermit(ref this.uda);
            this.pda = (new Program()).GetDetail(nProgramId);          
            this.pcIndex = nPcIndex;
            this.MsId = nMsId;
        }

        /// <summary>
        /// �û�������Ž�Ŀ���ѵ�ȫ����( ��һ��ֻ�ж����û�ʱ����Բ��Ų����� �����������Ҫ�۵ĵ���)
        /// <para>����5����־ -10û�е�¼��-15������-14û�в���Ȩ��,-16 �������� ,>=0  ��Ŀ��ѻ��û��г���ĵ��� </para>        
        /// </summary>
        /// <returns>
        /// Ȩ�޷��أ�-10û�е�¼��-15������-14û�в���Ȩ��
        /// ���ܲ��ţ��û��������� -16 ��ע����Ŀ������ѵģ����¿������ѿ���Ч���������ʱ�����ڡ���ת���ж��û��ĵ㿨��
        /// �ܲ��ţ������ÿ۵㣺��Ŀ��ѣ����¿������ѿ���Ч�������ʱ������,�۵㣨�벻�ܲ��ŵ�ԭ���뷴�� 
        /// </returns>
       
        public Int32 PrepareCharge() {
            Int32 nRetType  = PlayPermit();
            if (nRetType == 0 && !IsFreeProgram() && !IsValidCard() && !IsFreeTime()) {
                return IsPointEnough();
            } else {
                return nRetType;
            }
        }

        /// <summary>
        /// �㲥ȫ����
        /// </summary>
        /// <returns></returns>
        public string Play() {
            Int32 nRet = PrepareCharge();
            if (nRet >= 0) {
               // �۵�������ܿ۵����۵��¼,������

                if (this.consumePoint > 0)//�������: 3 ��۵� ; ʵ�ʲ��ۣ���ѽ�Ŀ1���ظ����ʱ���� 2,���¿���Ч 4��
                {//nRet=3 (��nPoint!=0ͬЧ)�����ܵ�����                    
                    (new User()).UpdateUserPointById(uda.UId, -this.consumePoint);
                    //UserHelper.SetUserCardSession(nUserId);
                }
                //�������Ӧ�����Ѽ�¼
                (new PointCard()).InsertCardPlayRecord(pda.PId,uda.UId, DateTime.Now, this.consumePoint);               
                (new Program()).UpdateReadCount(pda.PId);
                //�۵������ʼ����
                return (new Program()).PlayUrl(uda.UId, pda.PId, this.MsId, this.pcIndex, this.MediaType);                
                 

            } else {
                return nRet.ToString();               
            }
            
        }
        /// <summary>
        /// ���������������棺1.������Ȩ�� 2.��Ŀ���Ͳ��ǿμ�        
        /// <para>Ŀǰ�μ�ֻ������һ��Ƭ��(����Ŀ����),��Ŀ���治�����пμ�,�������ﲻ���ж�����Ƭ����Ƭ�ϵ������ǲ��ǿμ�����</para>    
        /// <returns>��ַ���</returns>     
        /// </summary>        
        public String Download() {

            if (new Permit(uda.UPermit, uda.GroupPermit).CanDownMedia() && this.MediaType != (Int32)Define.ENUM_PROGRAM_TYPE.t_course) {
                return (new Program()).DownloadUrl(uda.UId, pda.PId, this.MsId, this.pcIndex);
            } else {               
                return "";
            }
        }


     
        protected Int32 IsPointEnough() {
            if (uda.UPoint >= pda.PPoint) {
                this.consumePoint = pda.PPoint;
                return pda.PPoint;
            } else {
                return (int)RET.NoPoint;
            }

        }
        /// <summary>
        /// ��Ŀ��Ҫ���ѵĵ���Ϊ 0 �������;(��Ϊ0�ټ����¿�/���ѿ������Ƿ�۵� )      
        /// </summary>
        /// <returns></returns>
        public bool IsFreeProgram() {
            return !(pda.PPoint > 0) ;
        }

        /// <summary>
        /// ���ѿ�/���¿���Ч���ж�
        /// </summary>
        /// <returns></returns>
        public bool IsValidCard() {
            return CardValid > DateTime.Now ;
        }

        /// <summary>
        /// 1. ������ʱ��Ϊ0   2. �ظ��㲥ʱ��,������������ʱ����
        /// </summary>
        /// <returns></returns>
        public bool IsFreeTime() {
            string strFirstPlayTime = (new PointCard()).GetFirstPlayTimeByProgramId(pda.PId, uda.UId);
            return BLLHelper.BoolFreeTime(DateTime.Now, strFirstPlayTime) ;
        }

        /// <summary>
        /// �жϽ�Ŀ���ŵ�Ȩ��
        /// </summary>
        /// <returns>-10û�е�½,-15������ -14Ȩ�޴���</returns>
        public Int32 PlayPermit() {
            if (uda == null)
                return (int)RET.NoLogin;

            else if (uda.GroupClass < pda.PClass || (uda.UGroupMask & pda.PGroupMask) <= 0)
                return (int)RET.ErrGroupMask;

            else if (!(new Permit(uda.UPermit, uda.GroupPermit).CanPlay()))
                return (int)RET.ErrPermit;

            else
                return 0;

        }


    }
}