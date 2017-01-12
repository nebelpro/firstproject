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
using System.Web.Caching;
using Antlr.StringTemplate;
using Antlr.StringTemplate.Collections;
using Antlr.StringTemplate.Language;
using Antlr.StringTemplate.Utils;
using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.SkinFactory {
    public partial class STPage : MOD.WebUtility.UI.Page {
       

        #region 公共模块
        /// <summary>
        /// 节目搜索框 
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetSearchBox() {
            View Vw = mySkin.GetView("SearchBox");
                    
            StringTemplate stBox = Groups.GetInstanceOf(Vw.File);
            return stBox;
        }

        /// <summary>
        /// 下载部分
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetSoftDown() {
            View Vw = mySkin.GetView("SoftDown");
            StringTemplate stSoft = Groups.GetInstanceOf(Vw.File);
            Hashtable RS = new Hashtable();
            RS.Add("Directx9", this.GetRes("Down_MiniPlay"));
            RS.Add("MiniPlayer", this.GetRes("Down_Directx9"));

            stSoft.SetAttribute("RS", RS);
            return stSoft;
        }

        /// <summary>
        /// 设置模块（视频点播，网络电视台，直录系统）
        /// </summary>
        /// <param name="iMark"></param>
        /// <returns></returns>
        public StringTemplate SetModule() {
            View Vw = mySkin.GetView("Module");
            StringTemplate stModule = Groups.GetInstanceOf(Vw.File);

            Product product = new Product();

            int iMark = 1;
            string pageUrl = WebHelper.GetShowUrl().ToLower();
            if (pageUrl == "iptv.aspx") iMark = 2;
            else if (pageUrl == "recorder.aspx") iMark = 3;


            Int32 i = 0;
            if (product.Module_Program) {
                stModule.SetAttribute("Program", true);
                if (iMark == 1) {
                    stModule.SetAttribute("pImg", true);
                }
                i++;
            }
            if (product.Module_Iptv) {
                stModule.SetAttribute("Iptv", true);
                if (iMark == 2) {
                    stModule.SetAttribute("iImg", true);
                }
                i++;
            }
            if (product.Module_Recorder) {
                stModule.SetAttribute("Recorder", true);
                if (iMark == 3) {
                    stModule.SetAttribute("rImg", true);
                }
                i++;
            }

            if (i > 1) {
                stModule.SetAttribute("HasModule", true);
            }

            return stModule;
        }

        /// <summary>
        /// 登录模块
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetLogin() {
            View Vw = mySkin.GetView("LoginBox");
            Hashtable Res = new Hashtable();           

            StringTemplate stLogin = Groups.GetInstanceOf(Vw.File);
            if (this.ReLogin != 0 && this.UserID != 0) {
                stLogin.SetAttribute("ShowOn", true);

                Res.Add("Exit", this.GetRes("Info_Exit"));
                Res.Add("Welcome", this.GetRes("Info_Welcome"));

                stLogin.SetAttribute("mask", this.UserMask);
                stLogin.SetAttribute("UserNav", this.InitUserNav());
                stLogin.SetAttribute("RS", Res);
            } else {
                Res.Add("Username", this.GetRes("Info_Username"));
                Res.Add("Password", this.GetRes("Info_Password"));
                stLogin.SetAttribute("RS", Res);
            }

            return stLogin;

        }
        /// <summary>
        /// 页脚
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetFooter() {
            View Vw = mySkin.GetView("Footer");
            StringTemplate stFooter = Groups.GetInstanceOf(Vw.File);
            string strCopyRight = String.Format(this.GetRes("Info_CopyRight"), DateTime.Now.Year);
            stFooter.SetAttribute("CopyRight", strCopyRight);
            return stFooter;
        }

        #endregion 

        #region  ===视频点播首页
        /// <summary>
        /// 分类导航设置
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetCatalogNav() {
            View Vw = mySkin.GetView("CatalogNav");
            StringTemplate stNav = Groups.GetInstanceOf(Vw.File);

            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);
            Int32 i = 0;
            foreach (CatalogData cda in (new Catalog()).GetList(this.DefaultCatalog, Vw.GetInt32("count"))) {
                String strStyle = "";               
                if (i == 0 ) {
                    strStyle = "nobg ";
                }
                i++;

                if (cda.CId == nCatalogId) {
                    strStyle += "hot";
                }

                if (strStyle != "") {
                    strStyle = "class=\"" + strStyle + "\"";
                }

                stNav.SetAttribute("CatalogNav.{Style,CId,CName}",
                    new String[]{
                        strStyle,
                        cda.CId.ToString(),
                        cda.CName
                    
                    });     
            }
            
            return stNav;
           
        }
        ///<summary>
        /// 最新公告
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetTopBulletin() {
            View Vw = mySkin.GetView("BulletinTop");
            Int32 vLength=Vw.GetInt32("length");
            StringTemplate stTopBulletin = Groups.GetInstanceOf(Vw.File);
            IList<BulletinData> bList = (new Bulletin()).GetList(1, Vw.GetInt32("count"));
            for (int i = 0; i < bList.Count; i++) {
                BulletinData bda = (BulletinData)bList[i];
                stTopBulletin.SetAttribute("BulletinList.{BId,BName,bName,BAddTime}",
                    new String[] { 
                        bda.BId.ToString(),
                        bda.BName, 
                        this.SubMixText(bda.BName,vLength,"..."),
                        bda.BAddtime.ToShortDateString()
                    });
            }
            return stTopBulletin;
        }
        /// <summary>
        /// Top点击排行
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetTopProgram() {
            View Vw = mySkin.GetView("ProgramTop");
            StringTemplate stTopProgram = Groups.GetInstanceOf(Vw.File);
            IList<ProgramData> pgdList =(new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, 1, Vw.GetInt32("count"), (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC);
            for (int i = 0; i < pgdList.Count; i++) {
                ProgramData pda = (ProgramData)pgdList[i];
                stTopProgram.SetAttribute("TopProgram.{PId,PName,Name,PReadCount}",
                    new String[] {
                        pda.PId.ToString(),                       
                        pda.PName,
                         this.SubMixText(pda.PName, Vw.GetInt32("length"),"..."),
                        pda.PReadCount.ToString()
                    });
            }
            return stTopProgram;
        }

        /// <summary>
        /// Top点击排行 2
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetTopProgramImg() {
            View Vw = mySkin.GetView("ProgramTopImg");
            Int32 vLength = Vw.GetInt32("length");
            StringTemplate stProgramList = Groups.GetInstanceOf(Vw.File);

            Hashtable RS = new Hashtable();
            RS.Add("Play", this.GetRes("Info_Program_Play"));
            RS.Add("Length", this.GetRes("Info_Program_Length"));
            RS.Add("Point", this.GetRes("Info_Program_Point"));
            RS.Add("View", this.GetRes("Info_Program_View"));

            IList<ProgramData> pList = (new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,
                this.GroupClass, this.GroupMask, 1, Vw.GetInt32("count"), (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC);
            for (int i = 0; i < pList.Count; i++) {
                ProgramData pda = (ProgramData)pList[i];
                stProgramList.SetAttribute("Program.{PId,PName,PMediaKind,nTime,PPoint,PReadCount,Image,Style,Id,TypeImg,Name}",
                        new String[] {
                                pda.PId.ToString(),
                                pda.PName,
                                pda.PMediaKind.ToString(),
                                pda.nTime,
                                pda.PPoint.ToString(),
                                pda.PReadCount.ToString(),
                                ProgramHelper.GetProgramImage(pda.PImageId),
                                ProgramHelper.OutImageWidthHeight(Vw.GetInt32("width"),Vw.GetInt32("height"),pda.PImageId),
                                WebHelper.EncryptPid(pda.PId),
                                WebHelper.GetMediaType(pda.PMediaKind),
                               this.SubMixText(pda.PName,vLength,"...")
                            });

            }
            stProgramList.SetAttribute("RS", RS);
            return stProgramList;
        }
        /// <summary>
        /// 最新节目List
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetNewProgram() {
            View Vw = mySkin.GetView("ProgramNew");
            StringTemplate stNewProgram = Groups.GetInstanceOf(Vw.File);
            IList<ProgramData> pdaList = (new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, 1, Vw.GetInt32("count"), (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
            for (int i = 0; i < pdaList.Count; i++) {
                ProgramData pda = (ProgramData)pdaList[i];
                stNewProgram.SetAttribute("ProgramNewList.{PId,PName,Name}",
                    new String[] {
                        pda.PId.ToString(),
                        pda.PName,
                        this.SubMixText(pda.PName,Vw.GetInt32("length"),"...") 
                    });
            }
            return stNewProgram;
        }
        /// <summary>
        /// 最新节目List 2
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetNewProgramImg() {
            View Vw = mySkin.GetView("ProgramNewImg");
            StringTemplate stNewProgram = Groups.GetInstanceOf(Vw.File);
            IList<ProgramData> pdaList = (new Program()).GetList(this.DefaultCatalog, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, 1, Vw.GetInt32("count"), (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC);
            for (int i = 0; i < pdaList.Count; i++) {
                ProgramData pda = (ProgramData)pdaList[i];
                stNewProgram.SetAttribute("ProgramNewImgList.{PId,PName,Image}",
                    new String[] {
                        pda.PId.ToString(),
                        pda.PName,
                        ProgramHelper.GetProgramImage(pda.PImageId)
                    });
            }

            return stNewProgram;

        }

        /// <summary>
        /// 取前100节目,然后归类 
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetNewProgramView() {
            View Vw = mySkin.GetView("ProgramNewView");
            StringTemplate stNewView = Groups.GetInstanceOf(Vw.File);
            Int32 nLength = Vw.GetInt32("length");

            #region  取视图

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            SortedList SortList = new SortedList();
            IList<ProgramData> prmlist = (new Program()).GetTopNewGroupByCataLog(this.GroupClass, this.GroupMask);
            #region ===归类节目
            IEnumerator myEnum = prmlist.GetEnumerator();
            while (myEnum.MoveNext()) {
                ProgramData pda = (ProgramData)myEnum.Current;
                pda.PMediaKind = (new Catalog()).GetNeedCatalog(pda.PMediaKind, this.DefaultCatalog);
                if (pda.PMediaKind != -1) {
                    IList<ProgramData> psort = new List<ProgramData>();

                    if (SortList.Contains(pda.PMediaKind)) {
                        psort = (IList<ProgramData>)SortList[pda.PMediaKind];
                        psort.Add(pda);
                        SortList.Remove(pda.PMediaKind);
                    } else {
                        psort.Add(pda);
                    }
                    SortList.Add(pda.PMediaKind, psort);
                }
            }
            #endregion

            #region ===转化未HTML
            for (int i = 0; i < SortList.Count; i++) {
                Int32 nCatalogID = (Int32)SortList.GetKey(i);
                IList<ProgramData> pList = (IList<ProgramData>)SortList.GetByIndex(i);
                if ((new Catalog()).GetDetail(nCatalogID) != null) {
                    sb.Append("<tr><td class=\"cataname\"><img src=\"" + this.PageTheme + "Images/nodepend/bg_cata.gif\" alt=\"\"/><a href=\"ViewByClass.aspx?cid=" + nCatalogID.ToString() + "\">" +
                        (new Catalog()).GetDetail(nCatalogID).CName + "</a></td> <td class=\"cataprolst\">");
                }
                foreach (ProgramData pda in pList) {
                    sb.Append("<a href=\"ProgramInfo.aspx?pid=" + pda.PId.ToString() + "\">" + this.SubMixText(pda.PName, nLength, "...") + "</a>");
                }
                sb.Append("</td></tr>");
            }
            #endregion
            sb.Append("</table>");
            #endregion 
            stNewView.SetAttribute("NewProgramView", sb.ToString());
            return stNewView;
        }
        #endregion


        #region ===分类浏览页面
        /// <summary>
        /// 分类浏览模式
        /// </summary>
        /// <returns></returns>
        public String SetCatalogView() {
            View Vw = mySkin.GetView("CatalogView");
            Int32 vLength = Vw.GetInt32("length");

            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);       
            Catalog CataBll = new Catalog();
            if (nCatalogId != this.DefaultCatalog) {
                if (CataBll.GetNeedCatalog(nCatalogId, this.DefaultCatalog) == -1) {
                    nCatalogId = this.DefaultCatalog;
                }
            }  

            IList<CatalogData> subList = (new Catalog()).GetList(nCatalogId, 0);
            StringTemplate stCatalogView = Groups.GetInstanceOf("CatalogView");
            if (subList.Count != 0) {

                stCatalogView.SetAttribute("HasCount", true);
                for (int i = 0; i < subList.Count; i++) {
                    CatalogData cda = (CatalogData)subList[i];
                    stCatalogView.SetAttribute("Catalog.{CId,CName,Count}", new String[] {cda.CId.ToString(),this.SubMixText(cda.CName,vLength),
                                        ProgramHelper.GetProgramCountByCatalogId(cda.CId).ToString()});
                }

            }
            return stCatalogView.ToString();
        }
        /// <summary>
        /// 排序模块
        /// </summary>
        /// <returns></returns>
        public String GetOrderInfo() {
            Int32 nSort = this.GetIntParam("sort", 6);
            Int32 cId = this.GetIntParam("cid", 21);
            string strOrder = "";
            string OrderFormat0 = "<img src=\"" + this.PageTheme + "Images/depend/{0}\" alt=\"\"/>";
            string OrderFormat = "<a href=\"ViewByClass.aspx?cid=" + cId + "&sort={0}\"><img src=\"" + this.PageTheme + "Images/depend/{1}\" alt=\"\"/></a>";
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC) {
                strOrder = string.Format(OrderFormat0, "sort_time_sel.gif");
            } else {
                strOrder = string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC, "sort_time.gif");
            }
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.NAME_DESC) {
                strOrder += string.Format(OrderFormat0, "sort_name_sel.gif");
            } else {
                strOrder += string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.NAME_DESC, "sort_name.gif");
            }
            if (nSort == (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC) {
                strOrder += string.Format(OrderFormat0, "sort_play_sel.gif");
            } else {
                strOrder += string.Format(OrderFormat, (Int32)Define.ENUM_PROGRAM_SORT.PLAYCOUNT_DESC, "sort_play.gif");
            }

            strOrder = "<span class=\"order\">" + strOrder + "</span>";

            return strOrder;

        }
        /// <summary>
        /// 节目列表模块
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetPromgramList() {
            View Vw = mySkin.GetView("ProgramList");
            Int32 nPageSize = Vw.GetInt32("page");
            Int32 nLength = Vw.GetInt32("length");

            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);
            Catalog CataBll = new Catalog();
            if (nCatalogId != this.DefaultCatalog) {
                if (CataBll.GetNeedCatalog(nCatalogId, this.DefaultCatalog) == -1) {
                    nCatalogId = this.DefaultCatalog;
                }
            }

            Int32 nSort = this.GetIntParam("sort", 6);

            Program prmbll = new Program();
            Int32 nPrmCount = prmbll.GetCount(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask);
            StringTemplate stProgramList = Groups.GetInstanceOf(Vw.File);
            if (nPrmCount != 0) {
                Hashtable RS = new Hashtable();
                RS.Add("Play", this.GetRes("Info_Program_Play"));
                RS.Add("Length", this.GetRes("Info_Program_Length"));
                RS.Add("Point", this.GetRes("Info_Program_Point"));
                RS.Add("View", this.GetRes("Info_Program_View"));

                stProgramList.SetAttribute("HasCount", true);
                String strPageUrl = WebHelper.GetShowUrl() + "?cid=" + nCatalogId.ToString() + "&sort=" + nSort;
                String strListNav = String.Format(Helper.ListBar, "", WebHelper.PageList(strPageUrl, nPrmCount, nPage, nPageSize));
                stProgramList.SetAttribute("ListNav", strListNav);

                IList<ProgramData> pList = prmbll.GetList(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, this.GroupClass, this.GroupMask, nPage, nPageSize, nSort);
                for (int i = 0; i < pList.Count; i++) {
                    ProgramData pda = (ProgramData)pList[i];
                    stProgramList.SetAttribute("Program.{PId,PName,PMediaKind,nTime,PPoint,PReadCount,Image,Style,Id,TypeImg,Name}",
                            new String[] {
                                pda.PId.ToString(),
                                pda.PName,
                                pda.PMediaKind.ToString(),
                                pda.nTime,
                                pda.PPoint.ToString(),
                                pda.PReadCount.ToString(),
                                ProgramHelper.GetProgramImage(pda.PImageId),
                                ProgramHelper.OutImageWidthHeight(Vw.GetInt32("width"),Vw.GetInt32("height"),pda.PImageId),
                                WebHelper.EncryptPid(pda.PId),
                                WebHelper.GetMediaType(pda.PMediaKind),
                                this.SubMixText(pda.PName,nLength,"...")
                            });

                }

                stProgramList.SetAttribute("RS", RS);

            } else {
                stProgramList.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }

            return stProgramList;

        }

        /// <summary>
        /// 节目搜索列表
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetSearchList() {
            View Vw = mySkin.GetView("ProgramList");
            Int32 nPageSize = Vw.GetInt32("page");
            Int32 nLength = Vw.GetInt32("length");

            String strKey = this.GetStringParam("txtKey", "").Trim();
            Int32 nFindKey = this.GetIntParam("fkey", (Int32)Define.ENUM_PROGRAM_SEARCH.ALL);
            Int32 nPage = this.GetIntParam("page", 1);

            Program prmbll = new Program();
            Int32 nPrmCount = prmbll.SearchCount(strKey, nFindKey, this.GroupClass, this.GroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,this.DefaultCatalog);

            StringTemplate stProgramList = Groups.GetInstanceOf(Vw.File);
            if (nPrmCount != 0) {
                Hashtable RS = new Hashtable();
                RS.Add("Play", this.GetRes("Info_Program_Play"));
                RS.Add("Length", this.GetRes("Info_Program_Length"));
                RS.Add("Point", this.GetRes("Info_Program_Point"));
                RS.Add("View", this.GetRes("Info_Program_View"));

                stProgramList.SetAttribute("HasCount", true);
                string strPageUrl = WebHelper.GetShowUrl() + "?txtKey=" + strKey;
                String strListNav = String.Format(Helper.ListBar, "", WebHelper.PageList(strPageUrl, nPrmCount, nPage, nPageSize));
                stProgramList.SetAttribute("ListNav", strListNav);

                IList<ProgramData> pList = prmbll.Search(strKey, nFindKey, this.GroupClass, this.GroupMask,(Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass,
                    nPage, nPageSize,(Int32)Define.ENUM_PROGRAM_SORT.ADDTIME_DESC,this.DefaultCatalog);
                for (int i = 0; i < pList.Count; i++) {
                    ProgramData pda = (ProgramData)pList[i];
                    stProgramList.SetAttribute("Program.{PId,PName,PMediaKind,nTime,PPoint,PReadCount,Image,Style,Id,TypeImg,Name}",
                            new String[] {
                                pda.PId.ToString(),
                                pda.PName,
                                pda.PMediaKind.ToString(),
                                pda.nTime,
                                pda.PPoint.ToString(),
                                pda.PReadCount.ToString(),
                                ProgramHelper.GetProgramImage(pda.PImageId),
                                ProgramHelper.OutImageWidthHeight(Vw.GetInt32("width"),Vw.GetInt32("height"),pda.PImageId),
                                WebHelper.EncryptPid(pda.PId),
                                WebHelper.GetMediaType(pda.PMediaKind),
                                this.SubMixText(pda.PName,nLength,"...")
                            });

                }

                stProgramList.SetAttribute("RS", RS);

            } else {
                stProgramList.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }

            return stProgramList;

        }
        #endregion

        #region===节目详细信息页
        /// <summary>
        /// 节目的详细信息
        /// </summary>
        /// <param name="pda"></param>
        /// <returns></returns>
        public StringTemplate SetProgramDetail( ProgramData pda ) {
            View Vw = mySkin.GetView("ProgramDetail");
            StringTemplate stDetail = Groups.GetInstanceOf(Vw.File);
            Hashtable RS = new Hashtable();
            RS.Add("Detail", this.GetRes("Info_Program_Detail"));
            RS.Add("Name", this.GetRes("Info_Program_Name"));
            RS.Add("Point", this.GetRes("Info_Program_Point"));
            RS.Add("Director", this.GetRes("Info_Program_Director"));
            RS.Add("Actor", this.GetRes("Info_Program_Actor"));
            RS.Add("Length", this.GetRes("Info_Program_Length"));
            RS.Add("Class", this.GetRes("Info_Program_Class"));
            RS.Add("Kbps", this.GetRes("Info_Program_Kbps"));
            RS.Add("AddTime", this.GetRes("Info_Program_AddTime"));
            RS.Add("View", this.GetRes("Info_Program_View"));

            String strPlay = "";
            String strDown = "";
            String strImage = "<img src=\"" + ProgramHelper.GetProgramImage(pda.PImageId) + "\"  "
                                + ProgramHelper.OutImageWidthHeight(Vw.GetInt32("width"), Vw.GetInt32("height"), pda.PImageId) + " class=\"image\" alt=\"" + pda.PName + "\"/>";
            if ((new Permit()).CanPlay()) {
                strPlay = "<img src=\"" + this.PageTheme + "Images/depend/btn_play_big.gif\" class=\"hand\" onclick=\"OpenPlay('" + WebHelper.EncryptPid(pda.PId) + "',0," + pda.PMediaKind + ");\" alt=\"\">";
            }
            if ((new Permit()).CanDownMedia()) {
                strDown = "<img src=\"" + this.PageTheme + "Images/depend/btn_down_big.gif\" class=\"hand\" onclick=\"OpenDown('" + WebHelper.EncryptPid(pda.PId) + "',0);\" alt=\"\">";
            }
            #region ===取是否在免费点播时间内
            String strTimeLeft = "";
            if ((new Permit()).CanPlay() && pda.PPoint != 0) {
                int maxfreetime = SettingHelper.GetFreeTime();
                if (maxfreetime != 0) {
                    Boolean bUseMonthCard = false;
                    if (this.GetSession("CardValid").Length != 0) {
                        DateTime dt = WebHelper.FormatDateTime(DateTime.Parse(this.GetSession("CardValid")), 1);
                        bUseMonthCard = (dt >= DateTime.Now) ? true : false;
                    }
                    if (!bUseMonthCard) {
                        string strFirstPlayTime = (new PointCard()).GetFirstPlayTimeByProgramId(pda.PId, this.UserID);
                        if (BLLHelper.BoolFreeTime(DateTime.Now, strFirstPlayTime)) {
                            DateTime dtbefore = (DateTime.Parse(strFirstPlayTime)).AddMinutes(maxfreetime);
                            strTimeLeft = " <span style=\"color:red\">(" + string.Format(this.GetRes("Info_Program_FreeTime"), dtbefore.ToString()) + ")</span>";
                        }
                    }
                }
            }

            #endregion

            stDetail.SetAttribute(
                "Program.{Image,Name,Point,Director,Actor,Time,Class,Kbps,AddTime,ReadCount,Play,Download,TimeLeft}",
                new String[]{
                    strImage,
                    pda.PName,
                    pda.PPoint.ToString(),
                    pda.PDirector,
                    pda.PActor,
                    pda.nTime,
                    pda.PClass.ToString(),
                    pda.nKbps+" Kbps",
                    pda.PAddTime.ToShortDateString(),
                    pda.PReadCount.ToString(),
                    strPlay,
                    strDown,
                    strTimeLeft
                });

            stDetail.SetAttribute("RS", RS);

            return stDetail;
        }
        /// <summary>
        /// 节目的介绍
        /// </summary>
        /// <param name="strIntro"></param>
        /// <returns></returns>
        public String SetProgramIntro( String strIntro ) {
            View Vw = mySkin.GetView("ProgramIntro");
            if (!String.IsNullOrEmpty(strIntro)) {
                StringTemplate stIntro = Groups.GetInstanceOf(Vw.File);
                Hashtable RS = new Hashtable();
                RS.Add("Intro", this.GetRes("Info_Program_Intro"));

                stIntro.SetAttribute("Intro", strIntro);
                stIntro.SetAttribute("RS", RS);
                return stIntro.ToString();
            } else {
                return "";
            }

        }
        /// <summary>
        /// 节目片段 
        /// </summary>
        /// <returns></returns>
        public String SetProgramChapter() {
            View Vw = mySkin.GetView("Chapter");
            int nPid = this.GetIntParam("pid", 0);
            Hashtable RS = new Hashtable();
            RS.Add("Chapter", this.GetRes("Info_Chapter"));

            IList<ChapterData> cdList = (new Program()).GetChapterByProgramId(nPid);
            if (cdList.Count != 0) {
                StringTemplate stChapter = Groups.GetInstanceOf(Vw.File);
                for (Int32 i = 0; i < cdList.Count; i++) {
                    ChapterData chda = (ChapterData)cdList[i];
                    stChapter.SetAttribute("Chapter.{ProgramID,Order,MediaKind,Name,Time}",
                        new String[]{
                            WebHelper.EncryptPid(chda.PcProgramId),
                            chda.PcOrder.ToString(),
                            chda.PcMediaKind.ToString(),
                            chda.PcName,
                            chda.nTime                        
                        });

                }
                stChapter.SetAttribute("RS", RS);
                return stChapter.ToString();
            } else {
                return "";
            }

        }
        public String SetRemarkArea() {
            View Vw = mySkin.GetView("RemarkArea");           

            StringTemplate stArea = Groups.GetInstanceOf(Vw.File);
            foreach (String ViewName in mySkin.GetControl("RemarkArea")) {
                switch (ViewName) {
                    case "RemarkList":
                        stArea.SetAttribute(ViewName, this.SetRemarkList());
                        break;
                    case "RemarkForm":
                        stArea.SetAttribute(ViewName, this.SetRemarkForm());
                        break;
                }
            }

            Hashtable RS = new Hashtable();
            RS.Add("Remark", this.GetRes("Info_Remark"));
            stArea.SetAttribute("RS", RS);

            return stArea.ToString();
        }
        /// <summary>
        /// 节目评论列表
        /// </summary>
        /// <returns></returns>
        public String SetRemarkList() {
            View Vw = mySkin.GetView("RemarkList");
            Int32 vPageSize = Vw.GetInt32("page");
           

            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nProgramId = this.GetIntParam("pid", 0);
            StringTemplate stRemarkList = Groups.GetInstanceOf(Vw.File);
            Remark rmBll = new Remark();
            Int32 nPageCount = rmBll.GetCountByProgram(nProgramId, 1);
            if (nPageCount != 0) {
                stRemarkList.SetAttribute("HasCount", true);
                String strPageUrl = "user.GetRemark(" + nProgramId.ToString() + ",{0});";
                String strListNav = string.Format(Helper.ListBar, "", WebHelper.AjaxPager2(strPageUrl, nPageCount, nPage, vPageSize, 10));
                stRemarkList.SetAttribute("ListNav", strListNav);
                IList<RemarkData> rmkList = rmBll.GetListByProgram(nProgramId, 1, nPage, vPageSize);
                for (int i = 0; i < rmkList.Count; i++) {
                    RemarkData rda = (RemarkData)rmkList[i];
                    stRemarkList.SetAttribute("Remark.{Title,AddUser,AddTime,Info}",
                        new String[]{
                            rda.PrName,
                            rda.VUserName,
                            rda.PrAddTime.ToString(),
                            rda.PrInfo
                        });
                }
            } else {
                stRemarkList.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }

            

            return stRemarkList.ToString();

        }
        /// <summary>
        /// 节目评论模块(列表,发表表单)
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetRemarkForm() {
            View Vw = mySkin.GetView("RemarkForm");
            Int32 nProgramId = this.GetIntParam("pid", 0);

            Hashtable RS = new Hashtable();
            RS.Add("RemarkTitle", this.GetRes("Info_Remark_Title"));
            RS.Add("RemarkContent", this.GetRes("Info_Remark_Content"));
            RS.Add("NewRemark", this.GetRes("Info_Remark_Add"));

            StringTemplate stRemark = Groups.GetInstanceOf(Vw.File);

            stRemark.SetAttribute("PID", nProgramId);
            stRemark.SetAttribute("RS", RS);

            return stRemark;
        }

        #endregion

        #region ===频道部分
        /// <summary>
        /// 滚动的公告
        /// </summary>
        /// <returns></returns>
        public String SetMarqueeBulletin() {
            View Vw = mySkin.GetView("BulletinMarquee");
            IList<BulletinData> bullist = (new Bulletin()).GetList(1, Vw.GetInt32("count"));
            if (bullist.Count != 0) {
                StringTemplate stMarquee = Groups.GetInstanceOf(Vw.File);
                stMarquee.SetAttribute("HasCount", true);
                for (Int32 i = 0; i < bullist.Count; i++) {
                    BulletinData bda = (BulletinData)bullist[i];
                    stMarquee.SetAttribute("Bulletin.{BAddTime,Name}",
                        new String[]{
                            bda.BAddtime.ToString(),
                           this.SubMixText(bda.BName,Vw.GetInt32("length"),"...")
                    });
                }
                return stMarquee.ToString();
            } else {
                return "";
            }
        }
        /// <summary>
        /// 频道列表
        /// </summary>
        /// <param name="channelType"></param>
        /// <returns></returns>
        public String SetChannelList( Int32 channelType ) {
            View Vw = mySkin.GetView("ChannelList");
            Int32 nCount = (new Channel()).GetCount(channelType, this.GroupMask);
            if (nCount != 0) {
                StringTemplate stList = Groups.GetInstanceOf(Vw.File);
                stList.SetAttribute("HasCount", true);
                IList<ChannelData> cdList = (new Channel()).GetList(channelType, this.GroupMask, 1, 100, WebHelper.GetSession(SETTING_TYPE.KEY_WEIGE_SORT, 0));
                for (Int32 i = 0; i < cdList.Count; i++) {
                    ChannelData cda = (ChannelData)cdList[i];
                    stList.SetAttribute("Channel.{CId,CName}",
                        new String[] { 
                            cda.CId.ToString(),
                            cda.CName
                        });
                }

                return stList.ToString();
            } else {
                return "";
            }
        }
        #endregion
        #region  ===公告

        /// <summary>
        /// 公告列表 
        /// </summary>
        /// <returns></returns>
        public StringTemplate SetBulletinList() {
            View Vw = mySkin.GetView("BulletinList");

            Int32 nPage = this.GetIntParam("page", 1);
            Bulletin bl = new Bulletin();

            StringTemplate stBulletinList = Groups.GetInstanceOf(Vw.File);
            Int32 nPageCount = bl.GetCount();
            if (nPageCount != 0) {
                stBulletinList.SetAttribute("HasCount", true);
                String strListNav = string.Format(Helper.ListBar, "", WebHelper.PageList("BulletinList.aspx", nPageCount, nPage, Helper.PAGE_BULLETIN_SIZE));
                stBulletinList.SetAttribute("ListNav", strListNav);
                IList<BulletinData> bList = bl.GetList(nPage, Helper.PAGE_BULLETIN_SIZE);
                for (int i = 0; i < bList.Count; i++) {
                    BulletinData bda = (BulletinData)bList[i];
                    stBulletinList.SetAttribute("BulletinList.{BId,BName,BAddTime}",
                        new String[] {
                            bda.BId.ToString(),
                            bda.BName, 
                            bda.BAddtime.ToString() 
                        });
                }
            } else {
                stBulletinList.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }

            return stBulletinList;
        }
        #endregion

        #region ===模态窗口
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public String SetModifyPwd() {
            Hashtable RS = new Hashtable();
            RS.Add("OldPwd", this.GetRes("Info_PasswordOld"));
            RS.Add("NewPwd", this.GetRes("Info_PasswordNew"));
            RS.Add("Confirm", this.GetRes("Info_PasswordConfirm"));
            StringTemplate stModifyPwd = Groups.GetInstanceOf("UserModifyPwd");
            stModifyPwd.SetAttribute("RS", RS);
            return stModifyPwd.ToString();
        }
        /// <summary>
        /// 充值 
        /// </summary>
        /// <returns></returns>
        public String SetAddPoint() {
            Hashtable RS = new Hashtable();
            RS.Add("CardNo", this.GetRes("Info_CardNo"));
            RS.Add("CardPwd", this.GetRes("Info_CardPwd"));
            StringTemplate stAddPoint = Groups.GetInstanceOf("UserAddPoint");
            stAddPoint.SetAttribute("RS", RS);
            return stAddPoint.ToString();
        }
        /// <summary>
        /// 点播日志 
        /// </summary>
        /// <returns></returns>
        public String SetPlayLog() {
            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nType = 0;

            DateTime begintime = DateTime.Now;
            DateTime endtime = DateTime.Now;
            String strBt = this.GetStringParam("begin", "");
            String strEt = this.GetStringParam("end", "");
            if (strBt != "" || strEt != "") {
                nType = 1;
                try {
                    begintime = WebHelper.FormatDateTime(Convert.ToDateTime(strBt), 0);
                    endtime = WebHelper.FormatDateTime(Convert.ToDateTime(strEt), 1);
                } catch {
                    return "-21";
                }
                if (begintime > endtime) {
                    return "-22";
                }
            }

            Hashtable RS = new Hashtable();
            PointCard pcBll = new PointCard();
            StringTemplate stLog = Groups.GetInstanceOf("UserPlayLog");
            RS.Add("PlayTime", this.GetRes("Info_PlayTime"));

            Int32 nPageCount = pcBll.GetPlayCount(this.UserID, begintime, endtime, nType);
            if (nPageCount != 0) {
                RS.Add("ProgramName", this.GetRes("Info_Program_Name"));
                RS.Add("CardValue", this.GetRes("Info_CardValue"));

                String strOnclick = "user.GetPlayLog({0})";
                String strListTop = string.Format(Helper.ListBar, WebHelper.AjaxPager(strOnclick, nPageCount, nPage, 10), "");
                stLog.SetAttribute("ListTop", strListTop);
                stLog.SetAttribute("Log", pcBll.GetPlayList(this.UserID, begintime, endtime, nType, nPage, 10));
                stLog.SetAttribute("hasCount", true);
            } else {
                stLog.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }
            stLog.SetAttribute("RS", RS);
            return stLog.ToString();
        }
        /// <summary>
        /// 充值日志
        /// </summary>
        /// <returns></returns>
        public String SetChargeLog() {
            Int32 nPage = this.GetIntParam("page", 1);
            Int32 nType = 0;

            DateTime begintime = DateTime.Now;
            DateTime endtime = DateTime.Now;
            String strBt = this.GetStringParam("begin", "");
            String strEt = this.GetStringParam("end", "");
            if (strBt != "" || strEt != "") {
                nType = 1;
                try {
                    begintime = WebHelper.FormatDateTime(Convert.ToDateTime(strBt), 0);
                    endtime = WebHelper.FormatDateTime(Convert.ToDateTime(strEt), 1);
                } catch {
                    return "-21";
                }
                if (begintime > endtime) {
                    return "-22";
                }
            }

            Hashtable RS = new Hashtable();
            PointCard pcBll = new PointCard();
            StringTemplate stChargeLog = Groups.GetInstanceOf("UserChargeLog");
            RS.Add("UseDate", this.GetRes("Info_CardUserDate"));
            Int32 nPageCount = pcBll.GetUseCount(this.UserID, begintime, endtime, nType);
            if (nPageCount != 0) {
                RS.Add("CardNo", this.GetRes("Info_CardNo"));
                String strOnclick = "user.GetCharge({0})";
                String strListTop = string.Format(Helper.ListBar, WebHelper.AjaxPager(strOnclick, nPageCount, nPage, 10), "");
                stChargeLog.SetAttribute("ListTop", strListTop);

                IList<PointCardUseData> chargeList = pcBll.GetUseList(this.UserID, begintime, endtime, nType, nPage, 10);
                for (int i = 0; i < chargeList.Count; i++) {
                    PointCardUseData pud = (PointCardUseData)chargeList[i];
                    stChargeLog.SetAttribute("Log.{CuNumber,CuDateTime,CuPointValue,CuType}", new String[] { pud.CuNumber, pud.CuDateTime.ToString(), pud.CuPointValue.ToString(), CardHelper.GetCardUnit(pud.CuType) });
                }
                stChargeLog.SetAttribute("hasCount", true);

            } else {
                stChargeLog.SetAttribute("ListEmpty", String.Format(Helper.ListEmpty, this.PageTheme));
            }

            stChargeLog.SetAttribute("RS", RS);
            return stChargeLog.ToString();
        }
        /// <summary>
        /// 公告详细信息
        /// </summary>
        /// <returns></returns>
        public String SetBulletinInfo() {
            Int32 nBid = this.GetIntParam("bid", 0);
            BulletinData bda = (new Bulletin()).GetBulletinByBid(nBid);

            if (bda != null) {
                StringTemplate stBulletinInfo = Groups.GetInstanceOf("BulletinInfo");
                stBulletinInfo.SetAttribute("Bulletin", bda);
                return stBulletinInfo.ToString();
            } else {
                return "-11";
            }
        }
        #endregion


        #region ===功能函数
        /// <summary>
        /// 返回当前分类名称 及 分类等级
        /// </summary>
        /// <param name="CatalogName"></param>
        /// <param name="CatalogStep"></param>
        public void GetCatalogName( ref String CatalogName, ref String CatalogStep ) {
            Int32 nCatalogId = this.GetIntParam("cid", this.DefaultCatalog);
             Catalog CataBll= new Catalog();
            if (nCatalogId != this.DefaultCatalog) {
                if (CataBll.GetNeedCatalog(nCatalogId, this.DefaultCatalog) == -1) {
                    nCatalogId = this.DefaultCatalog;
                }
            }

            String strUrlFormat = "<a href=\"ViewByClass.aspx?cid={0}\">{1}</a>";
            CatalogData cata = CataBll.GetDetail(nCatalogId);
            if (cata != null) {
                CatalogStep = ProgramHelper.GetCatalogStepByCId(nCatalogId, strUrlFormat);
                CatalogName = cata.CName;
            }
        }
        /// <summary>
        /// 用户信息导航
        /// </summary>
        /// <returns></returns>
        public String InitUserNav() {
            string strRet = "";
            string strFormat = "<li><a href=\"javascript://\" onclick=\"{0}\">{1}</a></li>";

            if (this.UserID != 0) {
                if (this.GetSession(UserHelper.SESSION_TYPE.CardType) != "2") {
                    if ((new Permit()).CanChangePwd()) {
                        strRet = string.Format(strFormat, "user.CtrlModifyPwd(260,130,'" + this.GetRes("Info_ChangePwd") + "');", this.GetRes("Info_ChangePwd"));
                    }
                    strRet += string.Format(strFormat, "user.CtrlPointAdd(260,110,'" + this.GetRes("Info_AddPoint") + "');", this.GetRes("Info_AddPoint")) +
                       string.Format(strFormat, "user.ChargeQuery(540,400,'" + this.GetRes("Info_ChargeQuery") + "');", this.GetRes("Info_ChargeQuery")) +
                       string.Format(strFormat, "user.PlayLogQuery(540,400,'" + this.GetRes("Info_PlayQuery") + "');", this.GetRes("Info_PlayQuery"));
                }
            }
            return strRet;
        }
        #endregion


    }
}
