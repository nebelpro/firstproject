using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;

using MOD.BLL;
using MOD.Model;

namespace MOD.WebUtility
{
   public class SettingHelper
    {

       public static void SetSetting()
       {
           Setting settingBll = new Setting();

           HttpContext.Current.Session[SETTING_TYPE.KEY_DEFAULTUSER] = settingBll.GetValue(SETTING_TYPE.KEY_DEFAULTUSER, "0");
           HttpContext.Current.Session[SETTING_TYPE.KEY_FREETIME] = settingBll.GetValue(SETTING_TYPE.KEY_FREETIME, "0");

           HttpContext.Current.Session[SETTING_TYPE.KEY_B_ALLOW_REG] = settingBll.GetValue(SETTING_TYPE.KEY_B_ALLOW_REG, "0");
           HttpContext.Current.Session[SETTING_TYPE.KEY_B_COMMEND] = settingBll.GetValue(SETTING_TYPE.KEY_B_COMMEND, "0");
           HttpContext.Current.Session[SETTING_TYPE.KEY_B_SHOW_LOGIN] = settingBll.GetValue(SETTING_TYPE.KEY_B_SHOW_LOGIN, "0");

           HttpContext.Current.Session[SETTING_TYPE.KEY_DEFAULT_SORT] = settingBll.GetValue(SETTING_TYPE.KEY_DEFAULT_SORT, "4");
           HttpContext.Current.Session[SETTING_TYPE.KEY_DEFAULTSORT] = settingBll.GetValue(SETTING_TYPE.KEY_DEFAULTSORT, "1");
           
           HttpContext.Current.Session[SETTING_TYPE.KEY_EDITION_MASK] = settingBll.GetValue(SETTING_TYPE.KEY_EDITION_MASK, "0");
           HttpContext.Current.Session[SETTING_TYPE.KEY_VIEWMODEL] = settingBll.GetValue(SETTING_TYPE.KEY_VIEWMODEL, "1");

           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_1_ICON] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_1_ICON, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_1_NAME] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_1_NAME, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_1_LINK] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_1_LINK, "");

           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_2_ICON] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_2_ICON, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_2_NAME] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_2_NAME, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_2_LINK] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_2_LINK, "");

           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_3_ICON] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_3_ICON, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_3_NAME] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_3_NAME, "");
           HttpContext.Current.Session[SETTING_TYPE.KEY_EXTFUNC_3_LINK] = settingBll.GetValue(SETTING_TYPE.KEY_EXTFUNC_3_LINK, "");

           //新增
           HttpContext.Current.Session[SETTING_TYPE.KEY_DEFAULT_CATALOG] = settingBll.GetValue(SETTING_TYPE.KEY_DEFAULT_CATALOG, "21");
           HttpContext.Current.Session[SETTING_TYPE.KEY_WEIGE_VIEW] = settingBll.GetValue(SETTING_TYPE.KEY_WEIGE_VIEW, "2");
           HttpContext.Current.Session[SETTING_TYPE.KEY_WEIGE_SORT] = settingBll.GetValue(SETTING_TYPE.KEY_WEIGE_SORT, "0");

           //是否允许发表评论  0 不可以 ，其他可以
           HttpContext.Current.Session[SETTING_TYPE.KEY_ALLOW_REMARK] = settingBll.GetValue(SETTING_TYPE.KEY_ALLOW_REMARK, "1");
           

       }

       public static Int32 GetFreeTime()
       {
           Int32 nFreeTime = int.Parse((new Setting()).GetValue(SETTING_TYPE.KEY_FREETIME, "0"));
           HttpContext.Current.Session[SETTING_TYPE.KEY_FREETIME] = nFreeTime;
           return nFreeTime;
       }

    


   }
}
