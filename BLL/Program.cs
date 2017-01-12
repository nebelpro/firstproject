using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.BLL {
    public class Program {

        private static readonly MOD.IDAL.IProgram dal = MOD.DALFactory.DataAccess.CreateProgram();

        /// <summary>
        /// 获取节目列表
        /// order 值见 define.enmu_program_sort
        /// </summary>
        /// <param name="nCatalogId">-1全部分类节目，0 获取未分类, > 0 则分类ID，-2，全部节目</param>
        /// <param name="nCheck">0:未审核，1通过审核</param>
        /// <param name="nClass">1-255</param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <param name="nOrder">排序</param>
        /// <returns></returns>
        public IList<ProgramData> GetList( Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize, Int32 nOrder ) {
            // 需要作视图转换处理，如节目位率时长等
            return TransToViewData(dal.GetList(nCatalogId, nCheck, nClass, nGroupMask, nPage, nPageSize, nOrder));
        }

        public Int32 UpdateProgramPoint( Int32 nPId, Int32 nPoint ) {
            return dal.UpdateProgramPoint(nPId, nPoint);
        }

        /// <summary>
        /// 更新节目的点播次数
        /// </summary>
        /// <param name="nPid">The n pid.</param>
        public void UpdateReadCount( Int32 nPid ) {
            dal.UpdateReadCount(nPid);
        }

        public Int32 Delete( Int32 nProgramId ) {
            return dal.Delete(nProgramId);
        }

        /// <summary>
        /// Updates the program check.
        /// </summary>
        /// <param name="nPId">The n P id.</param>
        /// <param name="nCheck">1YES 0 NO </param>
        /// <returns></returns>
        public Int32 UpdateProgramCheck( Int32 nPId, Int32 nCheck ) {
            return dal.UpdateProgramCheck(nPId, nCheck);
        }
        /// <summary>
        /// 将DAL返回的数据做视图转换
        /// </summary>
        /// <param name="prmlist">节目数据的集合</param>
        /// <returns></returns>
        public IList<ProgramData> TransToViewData( IList<ProgramData> prmlist ) {
            IList<ProgramData> programlist = new List<ProgramData>();
            System.Collections.IEnumerator myEnum = prmlist.GetEnumerator();
            while (myEnum.MoveNext()) {
                ProgramData pda = (ProgramData)myEnum.Current;
                //开始转换需要的视图数据               
                pda.nTime = BLLHelper.FormatTime(pda.PDuration);
                pda.nKbps = BLLHelper.GetKbps(pda.PSizeHigh, pda.PSizeLow, pda.PDuration);
                programlist.Add(pda);
            }
            return programlist;
        }

        /// <summary>
        /// 读取指定分类节目总数
        /// </summary>
        /// <param name="nCatalogId">The n catalog id.</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nClass">The n class.</param>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetCount(nCatalogId, nCheck, nClass, nGroupMask);
        }

        /// <summary>
        /// 获取节目详情
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public ProgramData GetDetail( Int32 nProgramId ) {

            // 需要作视图转换处理，如节目位率时长等
            ProgramData prmdata = dal.GetDetail(nProgramId);
            if (prmdata != null) {
                prmdata.nTime = BLLHelper.FormatTime(prmdata.PDuration);
                prmdata.nKbps = BLLHelper.GetKbps(prmdata.PSizeHigh, prmdata.PSizeLow, prmdata.PDuration);
            }

            return prmdata;
        }


        #region  课程节目

        /// <summary>
        /// 获取课程节目列表(暂不实现)
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetListByCourse( Int32 nCourseId, Int32 nPage, Int32 nPageSize ) {

            return null;
        }

        /// <summary>
        /// 取得课程节目总数(暂不实现)
        /// </summary>
        /// <param name="nCourseId"></param>
        /// <returns></returns>
        public Int32 GetCountByCourse( Int32 nCourseId ) {

            return 0;
        }
        #endregion

        #region  收藏节目

        /// <summary>
        /// 取得个人收藏节目，并分页显示
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetFavList( Int32 nUserId, Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {
            //需要视图转换
            return TransToViewData(dal.GetFavList(nUserId, nClass, nGroupMask, nPage, nPageSize));
        }

        /// <summary>
        /// 取得个人收藏节目总数
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nClass">The n class.</param>
        /// <param name="nGroupMask">The n group mask.</param>
        /// <returns></returns>
        public Int32 GetFavCount( Int32 nUserId, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetFavCount(nUserId, nClass, nGroupMask);
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="nMarkId">The n mark id.</param>
        public void DelFav( Int32 nMarkId ) {
            dal.DelFav(nMarkId);
        }
        /// <summary>
        /// 增加收藏.
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nProgramId">The n program id.</param>
        public void AddFav( Int32 nUserId, Int32 nProgramId ) {
            dal.AddFav(nUserId, nProgramId);
        }

        #endregion

        #region 推荐节目

        /// <summary>
        /// 读取推荐节目
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <param name="nPage"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        public IList<ProgramData> GetRecommendList( Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize ) {
            return TransToViewData(dal.GetRecommendList(nClass, nGroupMask, nPage, nPageSize));
        }

        /// <summary>
        /// 读取推荐节目总数
        /// </summary>
        /// <param name="nClass"></param>
        /// <param name="nGroupMask"></param>
        /// <returns></returns>
        public Int32 GetRecommendCount( Int32 nClass, Int32 nGroupMask ) {

            return dal.GetRecommendCount(nClass, nGroupMask);
        }

        /// <summary>
        /// 删除推荐
        /// </summary>
        /// <param name="nRecommendId"></param>
        /// <returns></returns>
        public Int32 DelRecommend( Int32 nProgramId ) {
            return dal.DelRecommend(nProgramId);

        }
        /// <summary>
        /// 增加推荐节目
        /// </summary>
        /// <param name="nUserId">The n user id.</param>
        /// <param name="nProgramId">The n program id.</param>
        public void AddRecommend( Int32 nUserId, Int32 nProgramId ) {
            dal.AddRecommend(nUserId, nProgramId);
        }

        public Int32 IsRecommend( Int32 nProgramId ) {
            return dal.IsRecommend(nProgramId);
        }
        #endregion

        #region   搜索节目
        /// <summary>
        /// 搜索节目
        /// </summary>
        /// <param name="strKey">搜索内容</param>
        /// <param name="nType">搜索类型 define.eumu_program_search</param>
        /// <param name="nClass">当前用户级别</param>
        /// <param name="nGroupMask">当前用户组掩码</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nPage">The n page.</param>
        /// <param name="nPageSize">Size of the n page.</param>
        /// <param name="nOrder">The n order.</param>
        /// <param name="nCatalogId">-1全部分类节目，0 获取未分类, > 0 则分类ID，-2，全部节目</param>
        /// <returns></returns>
        public IList<ProgramData> Search( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,Int32 nCheck, Int32 nPage, Int32 nPageSize ,Int32 nOrder, Int32 nCatalogId) {

            return TransToViewData(dal.Search(strKey, nType, nClass, nGroupMask, nPage, nPageSize, nCheck, nOrder, nCatalogId));
            //附加了 check，iskind 字段
        }
        // 增加搜索未审核节目
        /// <summary>
        /// 搜索结果总数
        /// </summary>
        /// <param name="strKey">搜索内容</param>
        /// <param name="nType">搜索类型</param>
        /// <param name="nClass">当前用户级别</param>
        /// <param name="nGroupMask">当前用户组掩码</param>
        /// <param name="nCheck">The n check.</param>
        /// <param name="nCatalogId">-1全部分类节目，0 获取未分类, > 0 则分类ID，-2，全部节目</param>
        /// <returns></returns>
        public Int32 SearchCount( String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,Int32 nCheck,Int32 nCatalogId ) {
            return dal.SearchCount(strKey, nType, nClass, nGroupMask, nCheck,nCatalogId);        
        }

        #endregion



        /// <summary>
        /// 根据节目id读取节目片断
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IList<ChapterData> GetChapterByProgramId( Int32 pid ) {
            IList<ChapterData> chplist = dal.GetChapterByProgramId(pid);
            IList<ChapterData> chpnewlist = new List<ChapterData>();
            System.Collections.IEnumerator myEnum = chplist.GetEnumerator();
            while (myEnum.MoveNext()) {

                ChapterData chpdta = (ChapterData)myEnum.Current;

                //chpdta.PcName = chpdta.PcName.Split(".".ToCharArray())[0];
                chpdta.nTime = BLLHelper.FormatTime(chpdta.PcDuration);
                chpdta.nKbps = BLLHelper.GetKbps(chpdta.PcSizeHigh, chpdta.PcSizeLow, chpdta.PcDuration);
                chpnewlist.Add(chpdta);
            }

            return chpnewlist;
        }

        /// <summary>
        /// 返回媒体服务器信息
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public IList<MediaServerData> GetMediaServer( Int32 nProgramId ) {
            return dal.GetMediaServer(nProgramId);
        }

        /// <summary>
        /// 取图像数据
        /// </summary>
        /// <param name="nImgId"></param>
        /// <returns></returns>
        public ImageData GetImage( Int32 nImgId ) {
            return dal.GetImage(nImgId);
        }


        public IList<ProgramData> GetTopPlay( Int32 nCount, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTop(nCount, 1, nClass, nGroupMask);
        }
        public IList<ProgramData> GetTopNew( Int32 nCount, Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTop(nCount, 0, nClass, nGroupMask);
        }

        public IList<ProgramData> GetTopNewGroupByCataLog( Int32 nClass, Int32 nGroupMask ) {
            return dal.GetTopNewGroupByCataLog((Int32)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, nClass, nGroupMask);
        }

        #region  节目分类
        /// <summary>
        /// 获取节目所属分类列表
        /// </summary>
        /// <param name="nProgramId"></param>
        /// <returns></returns>
        public IList<CatalogData> GetCatalogList( Int32 nProgramId ) {
            // 需要递归调用 Catalog中GetDetail来显示完整的分类路径
            // 返回树层结构或JSON，待定
            return dal.GetCatalogList(nProgramId);
        }


        public Int32 GetCatalogByProgramId( Int32 nProgramId ) {
            return dal.GetCatalogByProgramId(nProgramId);
        }

        #endregion


        #region 取节目的操作地址

        /// <summary>
        /// 取下载地址
        /// </summary>
        /// <param name="nUserId"></param>
        /// <param name="nPid"></param>
        /// <param name="nMsid"></param>
        /// <param name="nPcindex">节目下载为片断ID</param>
        /// <returns></returns>
        public String DownloadUrl( Int32 nUserId, Int32 nPid, Int32 nMsid, Int32 nPcindex ) {

            String strHomeServer = System.Web.HttpContext.Current.Session["HSServer"].ToString();
            String strHomePort = System.Web.HttpContext.Current.Session["HSPort"].ToString();
            System.Random rnd = new Random();
            int nRnd = Convert.ToInt32(rnd.NextDouble() * 1000);
            int nTemp1 = nRnd;
            int nTemp2 = nUserId ^ nRnd;
            int nTemp3 = nPid ^ nRnd;
            int nTemp4 = nPcindex ^ nRnd;
            int nTemp5 = nMsid ^ nRnd;

            return "ummd://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + "." + nTemp3.ToString()
                    + "." + nTemp2.ToString() + "." + nTemp5.ToString() + "." + nTemp4.ToString();

        }


        /// <summary>
        /// 取播放地址
        /// </summary>
        /// <param name="nPid"></param>
        /// <param name="nMsid"></param>
        /// <param name="nPcindex">播放中为index</param>
        /// <param name="nMediatype"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public String PlayUrl( Int32 nUserId, Int32 nPid, Int32 nMsid, Int32 nPcindex, Int32 nMediatype ) {
            String strHomeServer = System.Web.HttpContext.Current.Session["HSServer"].ToString();
            String strHomePort = System.Web.HttpContext.Current.Session["HSPort"].ToString();

            System.Random rnd = new Random();
            int nRnd = Convert.ToInt32(rnd.NextDouble() * 1000);
            int nTemp1 = nRnd;
            int nTemp2 = nUserId ^ nRnd;
            int nTemp3 = nPid ^ nRnd;
            int nTemp4 = nPcindex ^ nRnd;
            int nTemp5 = nMsid ^ nRnd;

            if (nMediatype == (int)Define.ENUM_PROGRAM_TYPE.t_course) {
                return "ummd://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + ":" + nTemp3.ToString() + ":" + nTemp5.ToString();
            } else {
                return "ummp://" + strHomeServer + ":" + strHomePort + "/" + nTemp1.ToString() + "." + nTemp2.ToString()
               + "." + nTemp3.ToString() + "." + nTemp4.ToString() + ":" + nTemp5.ToString();
            }
        }


        /// <summary>
        /// 节目的编辑URL 
        /// <para>1.上传我的课程，2.节目编辑</para>
        ///</summary>
        /// <param name="nProgramId">The n program id.</param>
        /// <param name="nCourseId">COURId 不为零，表示为 课程的节目</param>
        /// <returns></returns>
        public  String EditUrl(String strServer,String strPort,Int32 nUserId,Int32 nProgramId, Int32 nCourseId ) {
            return "ummu://" + strServer + ":" + strPort + "/" + nProgramId + "." + nUserId + "." + nCourseId;             
        }





        #endregion 

    }
}
