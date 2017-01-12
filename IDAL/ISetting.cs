using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface ISetting
    {

        /// <summary>
        /// 根据key取值，返回一条数据
        /// </summary>
        /// <param name="Skey"></param>
        /// <returns></returns>
        String GetValueByKey(string Skey);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="settingdata"></param>
        /// <returns></returns>
        Int32 Update(SettingData settingdata);

        
     
    }
}
