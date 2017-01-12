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
            SUCCESS = 1,//成功
            NOT_EXIST = -1,//卡号不存在
            ERR_PWD = -2, //密码错误
            ERR_INVALID = -3, // 过期
            HAS_USE = -4, // 己使用
            ERR_TYPE = -5 // 类型错误
        }



        /// <summary>
        /// 用户登陆处理 :  
        /// 当从DAL返回的nRet = 1时,进入用户逻辑验证,如权限、组别安全性等
        /// 验证失败(0,-1)时 nRet 返回指定数值，方法返回NULL
        /// 验证成功后，返回USERDATA
        /// nRet = 1;
        /// return null;
        /// </summary>
        /// <param name="strMask"></param>
        /// <param name="strPassword"></param>
        /// <param name="nRet">1：（DAL调用成功，实体存在）0 密码错误 -1 账号错误 2 组别错误  3  没有登录权限 </param>
        /// <returns></returns>
        public UserData Login( String strMask, String strPassword, out Int32 nRet ) {
            // check account is card no

            UserData userdata = dal.Login(strMask, strPassword, out nRet);//检查 错误类型 0,-1
            if (nRet == (Int32)ENUM_RET_LOGIN.RET_SUCCESS)//根据nRet判断
            {
                if (GetUserPermit(ref userdata))//检查 错误类型 2
                {
                    if ((new Permit(userdata.UPermit, userdata.GroupPermit)).CanLogin())//检查错误类型 3
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
        /// 用户注册（不再提供私有目录）
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns>-1 用户名已经存在，0:创建私有目录失败（根据AddCatalog返回值判断）,1：成功</returns>
        public Int32 Register( UserData userdata ) {

            int nRet = AddUser(userdata);//返回 -1 ，1
            /*if (nRet == (Int32)ENUM_RET_REGISTER.RET_SUCCESS)
            {
                //AddCatalog:-1,-2,1，
               // (new Catalog()).AddCatalog(10, userdata.UMask);

                  由于私有目录添加个数的限制，咱不处理私有目录创建失败的情况
                 * 
                 * if ((new Catalog()).AddCatalog(10, userdata.UMask) != 1)
                {
                    nRet = (Int32)ENUM_RET_REGISTER.RET_FAILD_PRIVATE_FOLD;
                }
            }*/
            return nRet;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="strOldPassword">The STR old password.</param>
        /// <param name="strNewPassword">The STR new password.</param>
        /// <returns>0：原密码错误，1：成功</returns>
        public Int32 ModifyPassword( Int32 nUserId, String strOldPassword, String strNewPassword ) {

            return dal.UpdateUserPwdById(nUserId, strOldPassword, strNewPassword);
        }

        /// <summary>
        /// 返回用户详细信息,组别信息等可在些进行一些转换
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
        /// 根据组 分页读取用户列表
        /// </summary>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <returns></returns>
        public IList<UserData> GetList( Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {

            //暂留，需确定要转换那些视图函数
            return dal.GetList(nGroupMask, nPage, nPageSize);
        }

        /// <summary>
        ///  取全部用户（不分页）
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
        /// 取得搜索记录总数
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
        /// 取得某一组别下用户总数 0:表示全部
        /// </summary>
        /// <param name="nGroupMask">The group mask.</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nGroupMask ) {

            return dal.GetCount(nGroupMask);
        }

        /// <summary>
        /// 插入新用户信息
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns>-1:账号已经存在，1：成功</returns>
        public Int32 AddUser( UserData userdata ) {

            return dal.InsertUser(userdata);

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        public void DelUser( Int32 nUserId ) {

            dal.DelUserById(nUserId);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userdata">The userdata.</param>
        /// <returns></returns>
        public Int32 UpdateUser( UserData userdata ) {

            return dal.UpdateUserById(userdata);
        }


        /// <summary>
        /// 取用户拥有的剩余点数
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <returns></returns>
        public Int32 GetUserPoint( Int32 nUserId ) {

            return dal.GetUserPointById(nUserId);
        }
        /// <summary>
        /// 取用户的包月卡/消费卡的有效期
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <returns></returns>
        public String GetUserMonthCardValid( Int32 nUserId ) {

            return dal.GetUserMonthCardValid(nUserId);
        }

        /// <summary>
        /// 根据ID取用户姓名
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
        /// 充值操作
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="strCardNo"></param>
        /// <param name="strCardPwd"></param>
        /// <returns></returns>
        public Int32 AddUserCard( Int32 nUserId, String strCardNo, String strCardPwd ) {
            // 处理充值操作 
            // 检查卡状态信息类型等
            // 更新用户点数或有效期
            // 更新卡的状态
            // 记录充值记录

            /*
                省率了 卡账号形式的检测，放在UI层
             */

            string strUserMonthValue = GetUserMonthCardValid(nUserId);

            PointCard pointBll = new PointCard();

            PointCardData pointcdata = pointBll.GetPointCardByNo(strCardNo);
            if (pointcdata != null) {
                if (strCardPwd != pointcdata.PcPasswd) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_PWD;//卡号密码错误!
                }
                if (pointcdata.PcState == 1) {
                    return (Int32)ENUM_RET_ADDPOINT.HAS_USE; //卡号己经使用过
                }
                string Valid = pointcdata.PcValidDate.ToShortDateString() + " 23:59:59";
                DateTime dtValid = Convert.ToDateTime(Valid);
                if (dtValid < DateTime.Now) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_INVALID;//点卡己过期
                }

                if (pointcdata.PcType == 2) {
                    return (Int32)ENUM_RET_ADDPOINT.ERR_TYPE;//卡类型错误
                }
                //卡号检查逻辑结束,下面充值并进行记录

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
                return (Int32)ENUM_RET_ADDPOINT.NOT_EXIST;//卡号不存在
            }


            return (Int32)ENUM_RET_ADDPOINT.SUCCESS;//充值成功

        }


        #region    转换逻辑函数

        /// <summary>
        /// 提取用户的组别权限，和安全性
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
                return false;//组别错误
            }
        }

        #endregion
    }

    /// <summary>
    /// 消费的逻辑，如果扣点，需要扣点后更新用户点数的Session
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

        public DateTime CardValid;//用户登录后设置的卡有效期，点卡用户设置为 0，    包月卡/消费卡一样的Session名称 UserHelper.SESSION_TYPE.CardValid    
        public Int32 CardType;//暂时不用，系统中只有消费卡设置了属性为２　
        public Int32 consumePoint = 0;
        public Int32 pcIndex = 0;//节目播放时是 排序index，下载时是 片段的Id
        public Int32 MediaType = 0;
        public Int32 MsId = 0;
       
        /// <summary>
        ///用于全过程 
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
        /// 用于检测节目是否可放 
        /// </summary>      
        public Consume( Int32 nUserId, Int32 nProgramId, DateTime dtCardValid) {
            this.uda = (new User()).GetDetail(nUserId);
            (new User()).GetUserPermit(ref this.uda);
            this.pda = (new Program()).GetDetail(nProgramId);
            this.CardValid = dtCardValid;          
        }
        /// <summary>
        /// 用于下载
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
        /// 用户点击播放节目消费的全过程( 这一步只判断了用户时候可以播放并返回 错误参数，和要扣的点数)
        /// <para>返回5个标志 -10没有登录，-15组别错误，-14没有播放权限,-16 点数不足 ,>=0  节目免费或用户有充足的点数 </para>        
        /// </summary>
        /// <returns>
        /// 权限返回：-10没有登录，-15组别错误，-14没有播放权限
        /// 不能播放：用户点数不足 -16 （注：节目不是免费的，包月卡／消费卡无效，不在免费时间间隔内　都转到判断用户的点卡）
        /// 能播放：　不用扣点：节目免费，包月卡／消费卡有效，在免费时间间隔内,扣点（与不能播放的原因想反） 
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
        /// 点播全过程
        /// </summary>
        /// <returns></returns>
        public string Play() {
            Int32 nRet = PrepareCharge();
            if (nRet >= 0) {
               // 扣点操作，能扣点作扣点记录,并播放

                if (this.consumePoint > 0)//四种情况: 3 需扣点 ; 实际不扣（免费节目1，重复免费时间内 2,包月卡有效 4）
                {//nRet=3 (与nPoint!=0同效)，才能到这里                    
                    (new User()).UpdateUserPointById(uda.UId, -this.consumePoint);
                    //UserHelper.SetUserCardSession(nUserId);
                }
                //并添加相应的消费记录
                (new PointCard()).InsertCardPlayRecord(pda.PId,uda.UId, DateTime.Now, this.consumePoint);               
                (new Program()).UpdateReadCount(pda.PId);
                //扣点结束开始播放
                return (new Program()).PlayUrl(uda.UId, pda.PId, this.MsId, this.pcIndex, this.MediaType);                
                 

            } else {
                return nRet.ToString();               
            }
            
        }
        /// <summary>
        /// 下载需有两个方面：1.有下载权限 2.节目类型不是课件        
        /// <para>目前课件只允许有一个片断(主节目本身),节目下面不允许有课件,所以这里不用判断下载片断是片断的类型是不是课件类型</para>    
        /// <returns>地址或空</returns>     
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
        /// 节目需要消费的点数为 0 ，则免费;(不为0再检测包月卡/消费卡、及是否扣点 )      
        /// </summary>
        /// <returns></returns>
        public bool IsFreeProgram() {
            return !(pda.PPoint > 0) ;
        }

        /// <summary>
        /// 消费卡/包月卡有效期判断
        /// </summary>
        /// <returns></returns>
        public bool IsValidCard() {
            return CardValid > DateTime.Now ;
        }

        /// <summary>
        /// 1. 最大免费时间为0   2. 重复点播时间,大于允许的最大时间间隔
        /// </summary>
        /// <returns></returns>
        public bool IsFreeTime() {
            string strFirstPlayTime = (new PointCard()).GetFirstPlayTimeByProgramId(pda.PId, uda.UId);
            return BLLHelper.BoolFreeTime(DateTime.Now, strFirstPlayTime) ;
        }

        /// <summary>
        /// 判断节目播放的权限
        /// </summary>
        /// <returns>-10没有登陆,-15组别错误 -14权限错误</returns>
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