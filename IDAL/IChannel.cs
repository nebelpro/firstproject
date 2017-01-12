using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL
{
   public interface IChannel
    {
       /// <summary>
       /// 获取频道分页列表
       /// </summary>
       /// <param name="nType">0 - All 1-广播 2-直播 3-转播</param>
       /// <param name="nGroupMask"></param>
       /// <param name="nPage"></param>
       /// <param name="nPageSize"></param>
       /// <returns></returns>
       IList<ChannelData> GetList(Int32 nType, Int32 nGroupMask, Int32 nPage, Int32 nPageSize,Int32 nOrder);

       /// <summary>
       /// 获取频道总数
       /// </summary>
       /// <param name="nType"></param>
       /// <param name="nGroupMask"></param>
       /// <returns></returns>
       Int32 GetCount( Int32 nType, Int32 nGroupMask);

       /// <summary>
       /// 获取频道地址
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <returns></returns>
       IList<ChannelAddressData> GetAddress(Int32 nChannelId);

       /// <summary>
       /// 获取指定地址
       /// </summary>
       /// <param name="nAddressId"></param>
       /// <returns></returns>
       ChannelAddressData GetAddressDetail(Int32 nAddressId);

       /// <summary>
       /// 根据id提取频道的详细信息
       /// </summary>
       /// <param name="cid"></param>
       /// <returns></returns>
       ChannelData GetChannelInfoById(int cid);

       /// <summary>
       /// 插入频道信息(目前为复合频道)
       /// </summary>
       /// <param name="channeldata"></param>
       /// <returns></returns>
       Int32 Insert(ChannelData channeldata);

       /// <summary>
       /// 更新复合频道信息
       /// </summary>
       /// <param name="channeldata"></param>
       /// <returns></returns>
       Int32 Update(ChannelData channeldata);

         /// <summary>
       /// 更新c_upload_mediaserver字段
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <param name="strState"></param>
       /// <returns></returns>
       Int32 UpdateSubChannelState(Int32 nChannelId, String strState);

       /// <summary>
       /// 删除复合频道
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <returns></returns>
       Int32 Delete(Int32 nChannelId);

       MediaServerData GetMediaServer(Int32 nMediaServerId);

    }
}
