using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MOD.Model;
using MOD.IDAL;

namespace MOD.SQLServerDAL {
    public class Programs : IProgram {

        public IList<ProgramData> GetList(Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize, Int32 nOrder) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            param[1] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            param[2] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[4] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[5] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[6] = DbHelper.MakeParameter("@ORDER", SqlDbType.Int, nOrder);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getlist", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read()) {
   
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PDirector = dr["p_director"].ToString();
                pd.PPublish =  dr["p_publish"].ToString();
                pd.PActor = dr["p_actor"].ToString();
                pd.PInfo =  dr["p_info"].ToString();
                pd.PAddUser =  dr["p_adduser"].ToString();
                pd.PCommend = (Int32)dr["p_commend"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PClass = (Int32)dr["p_class"];
                pd.PCheck = (Int32)dr["p_check"];
                pd.PGroupMask = (Int32)dr["p_groupmask"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PIsKind = (Int32)dr["p_iskind"];
                pd.PRemarkCount = (Int32)dr["p_remarkcount"];
                pd.PRemarkScore = float.Parse(dr["p_remarkscore"].ToString());
                pd.PDuration = (Int32)dr["p_duration"];
                pd.PSizeHigh = (Int32)dr["p_size_high"];
                pd.PMediaKind = (Int32)dr["p_mediakind"];
                pd.PSizeLow = (Int32)dr["p_size_low"];
                pd.PSize =  dr["p_size"].ToString();
                pd.PCourseId = (Int32)dr["p_course_id"];
                pd.PPoint = (Int32)dr["p_point"];
                pdList.Add(pd);
               
            }
            dr.Close();
            return pdList;
        }

        public Int32 GetCount(Int32 nCatalogId, Int32 nCheck, Int32 nClass, Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            param[1] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            param[2] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_program_getcount", param);
        }

        public IList<ProgramData> GetListByCourse(Int32 nCourseId, Int32 nPage, Int32 nPageSize) {
            // 未实现
            return null;
        }


        public Int32 Delete(Int32 nProgramId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ExecNonQuery("m3_program_delete", param);
        }

        public Int32 GetCountByCourse(Int32 nCourseId) {
            return 0;
        }

        public ProgramData GetDetail(Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getdetail", param);
            if (dr.Read()) {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PDirector =   dr["p_director"].ToString();
                pd.PPublish =  dr["p_publish"].ToString();
                pd.PActor =  dr["p_actor"].ToString();
                pd.PInfo = dr["p_info"].ToString();
                pd.PAddUser =  dr["p_adduser"].ToString();
                pd.PCommend = (Int32)dr["p_commend"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PClass = (Int32)dr["p_class"];
                pd.PCheck = (Int32)dr["p_check"];
                pd.PGroupMask = (Int32)dr["p_groupmask"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PIsKind = (Int32)dr["p_iskind"];
                pd.PRemarkCount = (Int32)dr["p_remarkcount"];
                pd.PRemarkScore = float.Parse(dr["p_remarkscore"].ToString());
                pd.PDuration = (Int32)dr["p_duration"];
                pd.PSizeHigh = (Int32)dr["p_size_high"];
                pd.PMediaKind = (Int32)dr["p_mediakind"];
                pd.PSizeLow = (Int32)dr["p_size_low"];
                pd.PSize = (String)dr["p_size"];
                pd.PCourseId = (Int32)dr["p_course_id"];
                pd.PPoint = (Int32)dr["p_point"];
                dr.Close();
                return pd;
            }
            return null;
        }

        public Int32 UpdateProgramCheck(Int32 nPId, Int32 nCheck)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nPId);
            param[1] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            return DbHelper.ExecNonQuery("m3_program_updatecheck", param);

        }

        public Int32 UpdateProgramPoint(Int32 nPId, Int32 nPoint)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nPId);
            param[1] = DbHelper.MakeParameter("@VALUE", SqlDbType.Int, nPoint);
            return DbHelper.ExecNonQuery("m3_program_updatepoint", param);
        }

        public IList<ProgramData> GetFavList(Int32 nUserId, Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[2] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[3] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[4] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getfavlist", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read()) {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PDirector =  dr["p_director"].ToString();
                pd.PPublish =  dr["p_publish"].ToString();
                pd.PActor =  dr["p_actor"].ToString();
                pd.PInfo =  dr["p_info"].ToString();
                pd.PAddUser =  dr["p_adduser"].ToString();
                pd.PCommend = (Int32)dr["p_commend"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PClass = (Int32)dr["p_class"];
                pd.PCheck = (Int32)dr["p_check"];
                pd.PGroupMask = (Int32)dr["p_groupmask"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PIsKind = (Int32)dr["p_iskind"];
                pd.PRemarkCount = (Int32)dr["p_remarkcount"];
                pd.PRemarkScore = float.Parse(dr["p_remarkscore"].ToString());
                pd.PDuration = (Int32)dr["p_duration"];
                pd.PSizeHigh = (Int32)dr["p_size_high"];
                pd.PMediaKind = (Int32)dr["p_mediakind"];
                pd.PSizeLow = (Int32)dr["p_size_low"];
                pd.PSize =  dr["p_size"].ToString();
                pd.PCourseId = (Int32)dr["p_course_id"];
                pd.PPoint = (Int32)dr["p_point"];
                pdList.Add(pd);
               
            }
             dr.Close();
             return pdList;
        }

        public Int32 GetFavCount(Int32 nUserId, Int32 nClass, Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[2] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_program_getfavcount", param);
        }

        public Int32 DelFav(Int32 nMarkId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@@MARKID", SqlDbType.Int, nMarkId);
            return DbHelper.ExecNonQuery("m3_program_delfav", param);
        }

        public Int32 AddFav(Int32 nUserId, Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ExecNonQuery("m3_program_addfav", param);
        }

        

        public IList<ProgramData> GetRecommendList(Int32 nClass, Int32 nGroupMask, Int32 nPage, Int32 nPageSize) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[2] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[3] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getrecommendlist", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read()) {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PDirector = dr["p_director"].ToString();
                pd.PPublish = dr["p_publish"].ToString();
                pd.PActor = dr["p_actor"].ToString();
                pd.PInfo = dr["p_info"].ToString();
                pd.PAddUser = dr["p_adduser"].ToString();
                pd.PCommend = (Int32)dr["p_commend"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PClass = (Int32)dr["p_class"];
                pd.PCheck = (Int32)dr["p_check"];
                pd.PGroupMask = (Int32)dr["p_groupmask"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PIsKind = (Int32)dr["p_iskind"];
                pd.PRemarkCount = (Int32)dr["p_remarkcount"];
                pd.PRemarkScore = float.Parse(dr["p_remarkscore"].ToString());
                pd.PDuration = (Int32)dr["p_duration"];
                pd.PSizeHigh = (Int32)dr["p_size_high"];
                pd.PMediaKind = (Int32)dr["p_mediakind"];
                pd.PSizeLow = (Int32)dr["p_size_low"];
                pd.PSize = dr["p_size"].ToString();
                pd.PCourseId = (Int32)dr["p_course_id"];
                pd.PPoint = (Int32)dr["p_point"];
                pdList.Add(pd);

            }
            dr.Close();
            return pdList;
        }

        public Int32 GetRecommendCount(Int32 nClass, Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            return DbHelper.ReaderInt32("m3_program_getrecommendcount", param);
        }

        public Int32 DelRecommend(Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ExecNonQuery("m3_program_delrecommend", param);
        }

        public Int32 AddRecommend(Int32 nUserId, Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@UID", SqlDbType.Int, nUserId);
            param[1] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ExecNonQuery("m3_program_addrecommend", param);
        }

        public Int32 IsRecommend(Int32 nProgramId)
        {
            SqlParameter[] param = new SqlParameter[1];            
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            return DbHelper.ReaderInt32("m3_program_isrecommend", param);
        }
       
        public IList<ProgramData> Search(String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,
            Int32 nPage, Int32 nPageSize,Int32 nCheck,Int32 nOrder, Int32 nCatalogId) {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strKey);
            param[1] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[2] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[4] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[5] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[6] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            param[7] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            param[8] = DbHelper.MakeParameter("@ORDER", SqlDbType.Int, nOrder);
            IDataReader dr = DbHelper.ExecQuery("m3_program_search", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read()) {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PDirector = dr["p_director"].ToString();
                pd.PPublish = dr["p_publish"].ToString();
                pd.PActor = dr["p_actor"].ToString();
                pd.PInfo = dr["p_info"].ToString();
                pd.PAddUser = dr["p_adduser"].ToString();
                pd.PCommend = (Int32)dr["p_commend"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PClass = (Int32)dr["p_class"];
                pd.PCheck = (Int32)dr["p_check"];
                pd.PGroupMask = (Int32)dr["p_groupmask"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PIsKind = (Int32)dr["p_iskind"];
                pd.PRemarkCount = (Int32)dr["p_remarkcount"];
                pd.PRemarkScore = float.Parse(dr["p_remarkscore"].ToString());
                pd.PDuration = (Int32)dr["p_duration"];
                pd.PSizeHigh = (Int32)dr["p_size_high"];
                pd.PMediaKind = (Int32)dr["p_mediakind"];
                pd.PSizeLow = (Int32)dr["p_size_low"];
                pd.PSize = dr["p_size"].ToString();
                pd.PCourseId = (Int32)dr["p_course_id"];
                pd.PPoint = (Int32)dr["p_point"];
                pdList.Add(pd);

            }
            dr.Close();
            return pdList;
        }
     

        public Int32 SearchCount(String strKey, Int32 nType, Int32 nClass, Int32 nGroupMask,Int32 nCheck,Int32 nCatalogId) {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DbHelper.MakeParameter("@KEY", SqlDbType.VarChar, strKey);
            param[1] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[2] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[4] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            param[5] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            return DbHelper.ReaderInt32("m3_program_searchcount", param);
        }

        public Int32 UpdateReadCount(Int32 nPid) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nPid);
            return DbHelper.ExecNonQuery("m3_program_updateplaycount", param);
        }

        public IList<ChapterData> GetChapterByProgramId(int pid) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, pid);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getchapter", param);
            IList<ChapterData> cdList = new List<ChapterData>();
            while (dr.Read()) {
                ChapterData cd = new ChapterData();
                cd.PcId = (Int32)dr["pc_id"];
                cd.PcName = (String)dr["pc_name"];
                cd.PcOrder = (Int32)dr["pc_order"];
                cd.PcBitrate = (Int32)dr["pc_bitrate"];
                cd.PcSizeHigh = (Int32)dr["pc_size_high"];
                cd.PcSizeLow = (Int32)dr["pc_size_low"];
                cd.PcDuration = (Int32)dr["pc_duration"];
                cd.PcProgramId = (Int32)dr["pc_program_id"];
                cd.PcMediaKind = (Int32)dr["pc_mediakind"];
                cdList.Add(cd);
            }
           dr.Close();
           return cdList;
        }

        public IList<MediaServerData> GetMediaServer(Int32 nProgramId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getmediaserver", param);
            IList<MediaServerData> msdList = new List<MediaServerData>();
            while (dr.Read()) {
                MediaServerData msd = new MediaServerData();
                msd.MsId = (Int32)dr["ms_id"];
                msd.MsName = (String)dr["ms_name"];
                msd.MsRegister = (Int32)dr["ms_isregister"];
                msd.MsInfo = (String)dr["ms_info"];
                msd.MsMaxBand = (Int32)dr["ms_maxbandwidth"];
                msd.MsAvgBand = (Int32)dr["ms_avgbandwidth"];
                msdList.Add(msd);
            }
            dr.Close();
            return msdList;          
        }

        public ImageData GetImage(Int32 nImgId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@IMGID", SqlDbType.Int, nImgId);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getimage", param);
            if (dr.Read()) {
                ImageData id = new ImageData((Int32)dr["i_height"],(Int32)dr["i_width"],(byte[])dr["i_data"]);
                dr.Close();
                return id;
            } else
                dr.Close();
            return null;
        }

        public IList<ProgramData> GetTop(Int32 nCount, Int32 nType, Int32 nClass, Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = DbHelper.MakeParameter("@COUNT", SqlDbType.Int, nCount);
            param[1] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[2] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[3] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            
            IDataReader dr = DbHelper.ExecQuery("m3_program_gettop", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read()) {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PImageId = (Int32)dr["p_imageid"];
                pd.PReadCount = (Int32)dr["p_readcount"];
                pd.PAddTime = (DateTime)dr["p_addtime"];
                pdList.Add(pd);

            }
            dr.Close();
            return pdList;
        }

        /// <summary>
        /// 取１００条最新记录，并在ＵＩ层归类显示
        /// -------------------------
        /// 如：取100条,属于两类
        /// 爱情片：　a,b,c,d ...
        /// 动作片：　aa,bb,bb ...
        /// ----------------------------
        /// </summary>
        /// <returns></returns>
        public IList<ProgramData> GetTopNewGroupByCataLog(Int32 nCheck, Int32 nClass, Int32 nGroupMask)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@CHECK", SqlDbType.Int, nCheck);
            param[1] = DbHelper.MakeParameter("@CLASS", SqlDbType.Int, nClass);
            param[2] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);

            IDataReader dr = DbHelper.ExecQuery("m3_program_gettopnewgroupbycatalog", param);
            IList<ProgramData> pdList = new List<ProgramData>();
            while (dr.Read())
            {
                ProgramData pd = new ProgramData();
                pd.PId = (Int32)dr["p_id"];
                pd.PName = (String)dr["p_name"];
                pd.PMediaKind = (Int32)dr["catalogid"];  // 采用未用的字段存储 catalogid            

                pdList.Add(pd);
            } 
            dr.Close();
            return pdList;
        }

        public IList<CatalogData> GetCatalogList(Int32 nProgramId) {
            // 未实现
            return null;
        }


        public Int32 GetCatalogByProgramId(Int32 nProgramId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@PID", SqlDbType.Int, nProgramId);

            return DbHelper.ReaderInt32("m3_program_catalog", param);

        }


        
    }
}
