using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;

using MOD.BLL;
using MOD.Model;

namespace MOD.WebUtility {
    public class UserHelper {

        public class SESSION_TYPE {
            public const string UserMask = "UserMask";
            public const string UserName = "UserName";
            public const string GroupMask = "GroupMask";
            public const string GroupClass = "GroupClass";
            public const string UserId = "UserId";
            public const string UserPermit = "UserPermit";
            public const string GroupPermit = "GroupPermit";
            public const string Point = "Point";
            public const string CardValid = "CardValid";
            public const string CardType = "CardType";
            public const string MainKindId = "iMainKindId";
            public const string ViewModel = "ViewModel";
            public const string LoginTime = "LoginTime";
            public const String ReLogin = "Relogin";
        }


        /// <summary>
        /// 通过验证设置用户的Session，或默认Session
        /// </summary>      
        public static void SetUserSession( string umask, string uname, int ugroupmask, int groupclass, int uid,
            int upermit, int grouppermit, Int32 nPoint, DateTime dtCardValid ) {
            HttpContext.Current.Session[SESSION_TYPE.UserMask] = umask;
            HttpContext.Current.Session[SESSION_TYPE.UserName] = uname;
            HttpContext.Current.Session[SESSION_TYPE.GroupMask] = ugroupmask;
            HttpContext.Current.Session[SESSION_TYPE.GroupClass] = groupclass;
            HttpContext.Current.Session[SESSION_TYPE.UserId] = uid;
            HttpContext.Current.Session[SESSION_TYPE.UserPermit] = upermit;
            HttpContext.Current.Session[SESSION_TYPE.GroupPermit] = grouppermit;
            HttpContext.Current.Session[SESSION_TYPE.Point] = nPoint;
            HttpContext.Current.Session[SESSION_TYPE.CardValid] = dtCardValid;
            HttpContext.Current.Session[SESSION_TYPE.MainKindId] = 21;
            //HttpContext.Current.Session[SESSION_TYPE.ViewModel] = 1; 

            HttpContext.Current.Session[SESSION_TYPE.LoginTime] = DateTime.Now;
        }
        /// <summary>
        /// 用于登录的时候
        /// </summary>
        /// <param name="nUsreId"></param>
        public static void SetUserCardSession( Int32 nUsreId ) {
            HttpContext.Current.Session[SESSION_TYPE.Point] = (new User()).GetUserPoint(nUsreId);
            HttpContext.Current.Session[SESSION_TYPE.CardValid] = DateTime.Parse((new User()).GetUserMonthCardValid(nUsreId));
        }
        /// <summary>
        /// 用于点播过节目后更新用户点数
        /// </summary>
        /// <param name="nUserId"></param>
        public static void SetUserPointSession( Int32 nUserId ) {
            HttpContext.Current.Session[SESSION_TYPE.Point] = (new User()).GetUserPoint(nUserId);
        }
        /// <summary>
        /// 用于消费卡用户登录
        /// </summary>
        /// <param name="CardType"></param>
        /// <param name="dtCardValid"></param>
        public static void SetConsumeCardSession( Int32 CardType, DateTime dtCardValid ) {
            HttpContext.Current.Session[SESSION_TYPE.CardType] = CardType;
            HttpContext.Current.Session[SESSION_TYPE.CardValid] = dtCardValid;
        }

        public static void DefaultLogin() {
            Int32 nDefaultUser = WebHelper.GetSession(SETTING_TYPE.KEY_DEFAULTUSER, 0);
            if (nDefaultUser != 0) {
                Int32 nRet = 0;
                User uBll = new User();
                UserData ud = uBll.GetDetail(nDefaultUser);
                ud = uBll.Login(ud.UMask, ud.UPasswd, out nRet);

                if (nRet == (Int32)BLL.User.ENUM_RET_LOGIN.RET_SUCCESS) {
                    SetUserSession(ud.UMask, ud.UName, ud.UGroupMask, ud.GroupClass,
                        ud.UId, ud.UPermit, ud.GroupPermit, ud.UPoint, ud.UMonthCardValid);
                }                
            }

        }

    }
}
