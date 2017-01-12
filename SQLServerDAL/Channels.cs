using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Channels : IChannel {

        public IList<ChannelData> GetList(Int32 nType, Int32 nGroupMask, Int32 nPage, Int32 nPageSize,Int32 nOrder) {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);
            param[2] = DbHelper.MakeParameter("@PAGE", SqlDbType.Int, nPage);
            param[3] = DbHelper.MakeParameter("@PAGESIZE", SqlDbType.Int, nPageSize);
            param[4] = DbHelper.MakeParameter("@ORDER", SqlDbType.Int, nOrder);
            IDataReader dr = DbHelper.ExecQuery("m3_channel_getlist", param);
            IList<ChannelData> cdList = new List<ChannelData>();
            while (dr.Read()) {
                ChannelData cd = new ChannelData();
                cd.CId = (Int32)dr["c_id"];
                cd.CName = (String)dr["c_name"];
                cd.CInfo = dr["c_info"].ToString();
                cd.CType = (Int32)dr["c_type"];
                cd.CState = (dr["c_state"].ToString() == "")?-1:Int32.Parse(dr["c_state"].ToString());
                cd.CAllowGroup = dr["c_allow_group"].ToString();
                cd.CBeginTime = (dr["c_begin_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_begin_time"];
                cd.CStateTime = (dr["c_state_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_state_time"];
                cd.CCreateTime = (dr["c_create_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_create_time"];
                cd.CUploadMediaServer = dr["c_upload_mediaserver"].ToString();
                cd.CUserId = (Int32)dr["c_user_id"];
                cd.CGuid = dr["c_guid"].ToString();
                cd.CBroadcasterId = (dr["c_broadcaster_id"].ToString() == "")?-1:Int32.Parse(dr["c_broadcaster_id"].ToString());
                cd.CProperty = (dr["c_property"].ToString() == "")?-1:Int32.Parse(dr["c_property"].ToString());
                cd.CForbidGroup = dr["c_forbid_group"].ToString();
                cd.CForbidUser = dr["c_forbid_user"].ToString();
                cd.CAllowUser = dr["c_allow_user"].ToString();
                cdList.Add(cd);
            }
            dr.Close();
            return cdList;
        }

        public Int32 GetCount(Int32 nType, Int32 nGroupMask) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, nType);
            param[1] = DbHelper.MakeParameter("@GROUPMASK", SqlDbType.Int, nGroupMask);            
            return DbHelper.ReaderInt32("m3_channel_getcount", param);
        }

        public IList<ChannelAddressData> GetAddress(Int32 nChannelId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nChannelId);
            IDataReader dr = DbHelper.ExecQuery("m3_channel_getaddr", param);
            IList<ChannelAddressData> cadList = new List<ChannelAddressData>();
            while (dr.Read()) {
                ChannelAddressData cad = new ChannelAddressData();
                cad.CaId = (Int32)dr["ca_id"];
                cad.CaType = (Int32)dr["ca_type"];
                cad.CaIpAddress = dr["ca_ipaddress"].ToString();
                cad.CaPort = (Int32)dr["ca_port"];
                cad.CaTtl = (Int32)dr["ca_ttl"];
                cad.CaNetCard = dr["ca_netcard"].ToString();
                cad.CaChannelId = (Int32)dr["ca_channel_id"];
                cadList.Add(cad);
            }
            dr.Close();
            return cadList;
        }

        public ChannelData GetChannelInfoById(int cid) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, cid);
            IDataReader dr = DbHelper.ExecQuery("m3_channel_getdetail", param);
            if (dr.Read()) {
                ChannelData cd = new ChannelData();
                cd.CId = (Int32)dr["c_id"];
                cd.CName = (String)dr["c_name"];
                cd.CInfo = dr["c_info"].ToString();
                cd.CType = (Int32)dr["c_type"];
                cd.CState = (dr["c_state"].ToString() == "")?-1:Int32.Parse(dr["c_state"].ToString());
                cd.CAllowGroup = dr["c_allow_group"].ToString();
                cd.CBeginTime = (dr["c_begin_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_begin_time"];
                cd.CStateTime = (dr["c_state_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_state_time"];
                cd.CCreateTime = (dr["c_create_time"].ToString() == "")?DateTime.Now:(DateTime)dr["c_create_time"];
                cd.CUploadMediaServer = dr["c_upload_mediaserver"].ToString();
                cd.CUserId = (Int32)dr["c_user_id"];
                cd.CGuid = dr["c_guid"].ToString();
                cd.CBroadcasterId = (dr["c_broadcaster_id"].ToString() == "")?-1:Int32.Parse(dr["c_broadcaster_id"].ToString());
                cd.CProperty = (dr["c_property"].ToString() == "")?-1:Int32.Parse(dr["c_property"].ToString());
                cd.CForbidGroup = dr["c_forbid_group"].ToString();
                cd.CForbidUser = dr["c_forbid_user"].ToString();
                cd.CAllowUser = dr["c_allow_user"].ToString();
                cd.CSsrc = (dr["c_ssrc"].ToString() == "") ? 0 : Int32.Parse(dr["c_ssrc"].ToString());
                dr.Close();
                return cd;
            }
            return null;
        }

        public Int32 Insert(ChannelData channeldata) {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, channeldata.CName);
            param[1] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, channeldata.CInfo);
            param[2] = DbHelper.MakeParameter("@CREATETIME", SqlDbType.DateTime, channeldata.CCreateTime);
            param[3] = DbHelper.MakeParameter("@UID", SqlDbType.Int, channeldata.CUserId);
            param[4] = DbHelper.MakeParameter("@TYPE", SqlDbType.Int, channeldata.CType);
            return DbHelper.ReaderInt32("m3_channel_insert", param);
        }

        public Int32 Update(ChannelData channeldata) {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, channeldata.CId);
            param[1] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, channeldata.CName);
            param[2] = DbHelper.MakeParameter("@INFO", SqlDbType.VarChar, channeldata.CInfo);
            return DbHelper.ReaderInt32("m3_channel_update", param);
        }

        public Int32 UpdateSubChannelState(Int32 nChannelId, String strState) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nChannelId);
            param[1] = DbHelper.MakeParameter("@UPDATESTR", SqlDbType.VarChar, strState);
            return DbHelper.ExecNonQuery("m3_channel_updatesubstate", param);
        }

        public Int32 Delete(Int32 nChannelId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nChannelId);
            return DbHelper.ExecNonQuery("m3_channel_del", param);
        }
        public ChannelAddressData GetAddressDetail(Int32 nAddressId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CAID", SqlDbType.Int, nAddressId);
            IDataReader dr = DbHelper.ExecQuery("m3_program_getaddressbyid", param);
            if (dr.Read()) {
                ChannelAddressData cad = new ChannelAddressData();
                cad.CaId = nAddressId;
                cad.CaIpAddress = dr["ca_ipaddress"].ToString();
                cad.CaType = (Int32)dr["ca_type"];
                cad.CaPort = (Int32)dr["ca_port"];
                cad.CaTtl = (Int32)dr["ca_ttl"];
                cad.CaNetCard = dr["ca_netcard"].ToString();
                cad.CaChannelId = (Int32)dr["ca_channel_id"];
                dr.Close();
                return cad;
            }
            return null;
        }
        public MediaServerData GetMediaServer(Int32 nMediaServerId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@MSID", SqlDbType.Int, nMediaServerId);
            IDataReader dr = DbHelper.ExecQuery("m3_channel_getmediaserver", param);
            if (dr.Read()) {
                MediaServerData md = new MediaServerData();
                md.MsId = (Int32)dr["ms_id"];
                md.MsName = dr["ms_name"].ToString();
                md.MsRegister = (Int32)dr["ms_isregister"];
                md.MsInfo = (String)dr["ms_info"];
                md.MsMaxBand = (Int32)dr["ms_maxbandwidth"];
                md.MsAvgBand = (Int32)dr["ms_avgbandwidth"];
                dr.Close();
                return md;
            }
            return null;  
        }

    }
}
