using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Settings : ISetting {
        public String GetValueByKey(string strKey) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strKey);
            return DbHelper.ReaderString("m3_set_get", param);
        }

        public Int32 Update(SettingData settingdata) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, settingdata.SKey);
            param[1] = DbHelper.MakeParameter("@VALUE", SqlDbType.VarChar, settingdata.SValue);
            return DbHelper.ReaderInt32("m3_set_set", param);//2006-12-05 ExecNonQuery ¸Ä³É ReaderInt32
        }
    }
}
