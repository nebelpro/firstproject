using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace mentougou {
    public partial class Default : MOD.WebUtility.UI.Page {
        public string strParam = "";
        public IniStructure IniOper;

        protected void Page_Load( object sender, EventArgs e ) {
            this.Page.Title = this.GetRes("Info_Default");            
            this.Master.CurJs = "<script type=\"text/javascript\" src=\"Scripts/playui.js\"></script>";

            IList<ChannelData> ChaList = (new Channel()).GetList(1, this.GetSession("GroupMask", 0), 1, 10, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
            if (ChaList.Count != 0) {
                ChannelData cha = (ChannelData)ChaList[0];
                strParam = ChannelHelper.GetCastUI(cha.CId, 0);
            } else {
                strParam = "-1";
            }
            ScrollInit();
            
        }


        protected void ScrollInit() {
            IniOper = IniStructure.ReadIni(Server.MapPath(".") + "\\UserConfig.ini");
            Setting STbll = new Setting();
            DateTime scrollTime = DateTime.Parse(STbll.GetValue("ScrollTime", DateTime.MinValue.ToString()));
            DateTime newTime = DateTime.Parse(STbll.GetValue("newTime", DateTime.MinValue.ToString()));

            //第一次运行程序初始化 第一次滚动的时间 scrollTime
            if (scrollTime == DateTime.MinValue) {
                scrollTime = DateTime.Now;
                STbll.Update(new SettingData(1, "ScrollTime", scrollTime.ToString()));
            }
            //有新节目或有节目删除 重置起始滚动时间
            if (newTime != Helper.GetDtNew()) {
                STbll.Update((new SettingData(1, "newTime", Helper.GetDtNew().ToString())));
                STbll.Update(new SettingData(1, "ScrollTime", Helper.GetDtNew().ToString()));
                STbll.Update((new SettingData(1, "count", "0")));
            }
            Int32 nCount = int.Parse(STbll.GetValue("count", "0"));
            Int32 nMinutes = WebHelper.CompareDate(DateTime.Now, scrollTime);

            if (nMinutes >= int.Parse(IniOper.GetValue("Scroll", "interval"))) {
                nCount += int.Parse(IniOper.GetValue("Scroll", "number"));//起始滚动的位置 
                STbll.Update(new SettingData(1, "count", nCount.ToString()));
                STbll.Update(new SettingData(1, "ScrollTime", DateTime.Now.ToString()));
            }




        }
    }
}
/*
 */