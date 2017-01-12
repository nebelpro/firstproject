using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;
namespace MOD.SQLServerDAL
{
   public class LogRateexs: ILogRateex
    {

       public IList<ProgramData> GetList(DateTime dtBeginTime, DateTime dtEndTime, Int32 nType, Int32 nPage, Int32 nPageSize)
       {
           SqlParameter[] param = new SqlParameter[5];
           param[0] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
           param[1] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
           param[2] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
           param[3] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
           param[4] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);

           IDataReader dr = DbHelper.ExecQuery("m3_lograteex_getlist", param);
           IList<ProgramData> pdList = new List<ProgramData>();
           while (dr.Read())
           {

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

               //pd.PPoint = (Int32)dr["p_point"];
               //½èÓÃ PPoint ×Ö¶Î´æ´¢ lre_count
               pd.PPoint = (Int32)dr["lre_count"];
               pdList.Add(pd);

           }
           dr.Close();
           return pdList;
       }


       public Int32 GetCount( DateTime dtBeginTime, DateTime dtEndTime, Int32 nType)
       {
           SqlParameter[] param = new SqlParameter[3];          
           param[0] = DbHelper.MakeParameter("@BEGINDATE", SqlDbType.DateTime, dtBeginTime);
           param[1] = DbHelper.MakeParameter("@ENDDATE", SqlDbType.DateTime, dtEndTime);
           param[2] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
           return DbHelper.ReaderInt32("m3_lograteex_getcount", param);

       }

    }
}
