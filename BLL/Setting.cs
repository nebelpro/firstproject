using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.BLL {
    public class Setting {

        private static readonly MOD.IDAL.ISetting dal = MOD.DALFactory.DataAccess.CreateSetting();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <returns></returns>
        public String GetValue( String strKey ) {

            return dal.GetValueByKey(strKey);
        }

        /// <summary>
        /// 有则更新，没有则插入
        /// </summary>
        /// <param name="settingdata"></param>
        /// <returns>如果程序没有错误，始终是返回 1</returns>
        public Int32 Update( SettingData settingdata ) {

            return dal.Update(settingdata);
        }

        // 具体UI层需要时再增加

        public String GetValue( String strKey, string strDefaultValue ) {
            string strValue = dal.GetValueByKey(strKey);
            if (string.IsNullOrEmpty(strValue)) {
                Update(new SettingData(1, strKey, strDefaultValue));
                return strDefaultValue;
            } else {
                return strValue;
            }
        }


        public Int32 SetDefaultVisiter( string strUId ) {
            SettingData sd = new SettingData();
            sd.SId = 0;
            sd.SKey = SETTING_TYPE.KEY_DEFAULTUSER;
            sd.SValue = strUId;
            if (Update(sd) != 0) {
                if (strUId != "0") {
                    SettingData sd2 = new SettingData(1, SETTING_TYPE.KEY_B_SHOW_LOGIN, "0");
                    Update(sd2);
                }
                return 1;//success
            } else {
                return -1;
            }
        }

        public Int32 SetShowLogin( String strValue ) {

            if (Update(new SettingData(1, SETTING_TYPE.KEY_B_SHOW_LOGIN, strValue)) != 0) {
                if (int.Parse(strValue) != 0) {
                    Update(new SettingData(1, SETTING_TYPE.KEY_DEFAULTUSER, "0"));
                    //Session["defaultuser"]=0;
                    return 2;
                }
                return 1;
            } else {
                return -1;
            }
        }


        public Int32 SetAllowReg( String strValue ) {
            if (Update(new SettingData(1, SETTING_TYPE.KEY_B_ALLOW_REG, strValue)) == 1) {
                return 1;
            } else {
                return -1;
            }
        }
        public Int32 SetAllowRemark( String strValue ) {
            if (Update(new SettingData(1, SETTING_TYPE.KEY_ALLOW_REMARK, strValue)) == 1) {
                return 1;
            } else {
                return -1;
            }
        }

        public Int32 SetDefaultSort( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_DEFAULTSORT, strValue));
        }

        public Int32 SetDefaultCatalog( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_DEFAULT_CATALOG, strValue));
        }

        public Int32 SetWeigeView( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_WEIGE_VIEW, strValue));
        }

        public Int32 SetWeigeSort( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_WEIGE_SORT, strValue));
        }


        public Int32 SetViewModel( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_VIEWMODEL, strValue));
        }

        public Int32 SetMaxFreeTime( String strValue ) {
            return Update(new SettingData(1, SETTING_TYPE.KEY_FREETIME, strValue));
        }




    }
}
