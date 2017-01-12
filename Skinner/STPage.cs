using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;

using System.Xml;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Collections;
using Antlr.StringTemplate.Language;
using Antlr.StringTemplate.Utils;
using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.SkinFactory {
    public partial class STPage : MOD.WebUtility.UI.Page {

        private StringTemplateGroup Groups;
        private readonly String PageTheme;
        

        protected Skin mySkin;

        public STPage() {
            string themeName = String.IsNullOrEmpty(Res.GetProductTheme()) ? "default" : Res.GetProductTheme().ToLower();
            mySkin = new Skin(themeName);
            PageTheme = mySkin.GetPath();           
            Groups = new StringTemplateGroup("mygroup", Server.MapPath(PageTheme));
           
        }


        #region  视频部分
        /// <summary>
        /// 主模板设置
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetMaster() {
            if (this.ReLogin == 0) {
                MOD.WebUtility.UserHelper.DefaultLogin();
            }

            StringTemplate pagest = Groups.GetInstanceOf("master");           

            foreach (String ViewName in mySkin.GetMaster("master")) {

                switch (ViewName) {
                    case "Module":
                        pagest.SetAttribute(ViewName, this.SetModule());
                        break;
                    case "CatalogNav":
                        pagest.SetAttribute(ViewName,this.SetCatalogNav());
                        break;
                    case "Footer":
                        pagest.SetAttribute(ViewName, this.SetFooter());
                        break;
                    case "SearchBox":
                        pagest.SetAttribute(ViewName, this.SetSearchBox());
                        break;
                    case "LoginBox":
                        pagest.SetAttribute(ViewName, this.SetLogin());
                        break;
                    case "SoftDown":
                        pagest.SetAttribute(ViewName, this.SetSoftDown());
                        break;
                    case "ProgramTop":
                        pagest.SetAttribute(ViewName, this.SetTopProgram().ToString());
                        break;

                    #region ===webtd 界面
                    case "BulletinTop":
                        pagest.SetAttribute(ViewName, this.SetTopBulletin());
                        break;
                    case "ProgramNew":
                        pagest.SetAttribute(ViewName, this.SetNewProgram());
                        break;
                    #endregion 


                }           
            }
            pagest.SetAttribute("logo", "mod_logo.gif");
            return pagest;
        }
        
        /// <summary>
        /// 视频点播首页
        /// </summary>
        /// <returns></returns>
        public String PageDefault() {
            StringTemplate stMaster = SetMaster();
            StringTemplate stDefault = Groups.GetInstanceOf("Program");            

            foreach (String ViewName in mySkin.GetPage("program")) {
                switch (ViewName) {
                    #region ===红色界面
                    case "BulletinTop":
                        stDefault.SetAttribute(ViewName, this.SetTopBulletin());
                        break;
                    case "ProgramNew":
                        stDefault.SetAttribute(ViewName, this.SetNewProgram());
                        break;
                    case "ProgramNewView":
                        stDefault.SetAttribute(ViewName, this.SetNewProgramView());
                        break;
                    #endregion 

                    #region ===webtd界面
                    case "ProgramNewImg":
                        stDefault.SetAttribute(ViewName, this.SetNewProgramImg());
                        break;
                    case "ProgramTopImg":
                        stDefault.SetAttribute(ViewName, this.SetTopProgramImg());
                        break;
                    #endregion 
                                      
                }
            }
            #region ===webtd界面

            stDefault.SetAttribute("position", this.GetRes("Info_HomePage"));

            #endregion 

            
            stMaster.SetAttribute("title", this.GetRes("Info_Program"));
            stMaster.SetAttribute("righter", stDefault);

            return stMaster.ToString();
        }
        /// <summary>
        /// 分类浏览页面
        /// </summary>
        /// <returns></returns>
        public String PageViewByClass() {
            StringTemplate stMaster = SetMaster();
            StringTemplate stViewByClass = Groups.GetInstanceOf("ViewByClass");

            #region ===共有部分
            String CatalogName = "";
            String CatalogStep = "";
            GetCatalogName(ref CatalogName, ref CatalogStep);
            stViewByClass.SetAttribute("catalogstep", CatalogStep);
            stViewByClass.SetAttribute("order", this.GetOrderInfo());
            #endregion 

            #region ===webtd界面
            String strPosition = this.GetRes("Info_HomePage");
            stViewByClass.SetAttribute("position", strPosition);
            #endregion 

            foreach (String ViewName in mySkin.GetPage("viewbyclass")) {
                switch (ViewName) {
                    case "CatalogView":
                        stViewByClass.SetAttribute(ViewName, this.SetCatalogView());
                        break;
                    case "ProgramList":
                        stViewByClass.SetAttribute(ViewName, this.SetPromgramList());
                        break;
                }
            }

            
            stMaster.SetAttribute("title", CatalogName);
            stMaster.SetAttribute("righter", stViewByClass);
            return stMaster.ToString();

        }

        /// <summary>
        /// 节目搜索页面
        /// </summary>
        /// <returns></returns>
        public String PageSearchResult() {
            StringTemplate stMaster = SetMaster();
            StringTemplate stResult = Groups.GetInstanceOf("SearchResult");
            #region ===webtd界面          
            stResult.SetAttribute("position", this.GetRes("Info_HomePage"));
            #endregion 
            Hashtable RS = new Hashtable();
            RS.Add("SearchResult", this.GetRes("Info_SearchResult"));

            String strKey = this.GetStringParam("txtKey", "").Trim();
            string strKeyTip = (string.IsNullOrEmpty(strKey) ? this.GetRes("Info_Program_All") : strKey);
            stResult.SetAttribute("key", strKeyTip);
            stResult.SetAttribute("RS", RS);

            foreach (String ViewName in mySkin.GetPage("searchresult")) {
                switch (ViewName) {
                    case "ProgramList":
                        stResult.SetAttribute(ViewName,this.SetSearchList());
                        break;
                }
            }

          
            stMaster.SetAttribute("title", RS["SearchResult"].ToString() + strKeyTip);
            stMaster.SetAttribute("righter", stResult);

            return stMaster.ToString();
        }
        /// <summary>
        /// 公告列表页面
        /// </summary>
        /// <returns></returns>
        public String PageBulletinList() {
            StringTemplate stMaster = SetMaster();           
            
            Hashtable RS = new Hashtable();
            RS.Add("Bulletin", this.GetRes("Info_Bulletin_List"));

            StringTemplate stBulletinList = this.SetBulletinList();

            #region ===webtd界面 
            stBulletinList.SetAttribute("position", this.GetRes("Info_HomePage"));
            #endregion 
            stBulletinList.SetAttribute("RS", RS);
            foreach (String ViewName in mySkin.GetPage("BulletinList")) {
                switch (ViewName) {
                    case "BulletinList":
                        stMaster.SetAttribute("righter", stBulletinList);
                        break;
                }
            }
            
            stMaster.SetAttribute("title", RS["Bulletin"].ToString());
            
            return stMaster.ToString();
        }
        /// <summary>
        /// 节目详细信息页面
        /// </summary>
        /// <returns></returns>
        public String PageProgramInfo() {
            StringTemplate stMaster = SetMaster();
            Int32 nProgramId = this.GetIntParam("pid", 0);
            ProgramData pda = (new Program()).GetDetail(nProgramId);

            StringTemplate stProgramInfo = Groups.GetInstanceOf("ProgramInfo");
            
            stProgramInfo.SetAttribute("detail", pda.PName);
            #region ===webtd界面
            stProgramInfo.SetAttribute("position", this.GetRes("Info_HomePage"));
            #endregion 

            foreach (String ViewName in mySkin.GetPage("ProgramInfo")) {
                switch (ViewName) {
                    case "ProgramDetail":
                        stProgramInfo.SetAttribute(ViewName,this.SetProgramDetail(pda));
                        break;
                    case "ProgramIntro":
                        stProgramInfo.SetAttribute(ViewName,this.SetProgramIntro(pda.PInfo));
                        break;
                    case "Chapter":
                        stProgramInfo.SetAttribute(ViewName,this.SetProgramChapter());
                        break;
                    case "RemarkArea":
                        stProgramInfo.SetAttribute(ViewName, this.SetRemarkArea());
                        break;                   
                }
            }

            
            stMaster.SetAttribute("title", pda.PName);
            stMaster.SetAttribute("righter", stProgramInfo);
            return stMaster.ToString();
        }
        #endregion

        #region ===频道部分
        /// <summary>
        /// Tv母板设置
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetTvMaster() {
            if (this.ReLogin == 0) {
                MOD.WebUtility.UserHelper.DefaultLogin();
            }

            StringTemplate pagest = Groups.GetInstanceOf("MasterTv");            

            foreach (String ViewName in mySkin.GetMaster("Channel")) {
                switch (ViewName) {
                   
                    case "Module":
                        pagest.SetAttribute(ViewName, this.SetModule());
                        break;
                    case "BulletinMarquee":
                        pagest.SetAttribute(ViewName, this.SetMarqueeBulletin());
                        break;
                    case "Footer":
                        pagest.SetAttribute(ViewName, this.SetFooter());
                        break;

                    #region ===webtd界面
                    case "LoginBox":
                        pagest.SetAttribute(ViewName, this.SetLogin());
                        break;
                    #endregion 
                   

                }
            }
            pagest.SetAttribute("logo", "mod_logo.gif");
            return pagest;
        }

        /// <summary>
        /// 网络电视台页面
        /// </summary>
        /// <returns></returns>
        public String PageIptv() {
            StringTemplate stMaster = SetTvMaster();
            foreach (String ViewName in mySkin.GetPage("Iptv")) {
                switch (ViewName) {
                    case "ChannelList":
                        stMaster.SetAttribute(ViewName,this.SetChannelList((Int32)Define.CHANNEL_SHOW.BROAD));
                        stMaster.SetAttribute(ViewName,this.SetChannelList((Int32)Define.CHANNEL_SHOW.IPTV));
                        break;
                }
            }
            stMaster.SetAttribute("title", this.GetRes("Info_Iptv"));
            return stMaster.ToString();
        }
        /// <summary>
        /// 直录系统页面
        /// </summary>
        /// <returns></returns>
        public String PageRecorder() {
            StringTemplate stMaster = SetTvMaster();

            foreach (String ViewName in mySkin.GetPage("Recorder")) {
                switch (ViewName) {
                    case "ChannelList":
                        stMaster.SetAttribute(ViewName, this.SetChannelList((Int32)Define.CHANNEL_SHOW.LIVE));
                        stMaster.SetAttribute(ViewName, this.SetChannelList((Int32)Define.CHANNEL_SHOW.MIXC));
                        break;
                }
            }           
           
            stMaster.SetAttribute("title", this.GetRes("Info_Recorder"));
            return stMaster.ToString();
        }
        #endregion

        


    }
}
