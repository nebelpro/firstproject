using System;
using System.Collections.Generic;
using System.Text;
using MOD.Model;

namespace MOD.IDAL {
    public interface ISetting
    {

        /// <summary>
        /// ����keyȡֵ������һ������
        /// </summary>
        /// <param name="Skey"></param>
        /// <returns></returns>
        String GetValueByKey(string Skey);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="settingdata"></param>
        /// <returns></returns>
        Int32 Update(SettingData settingdata);

        
     
    }
}
