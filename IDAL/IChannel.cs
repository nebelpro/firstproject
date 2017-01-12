using System;
using System.Collections.Generic;
using System.Text;

using MOD.Model;

namespace MOD.IDAL
{
   public interface IChannel
    {
       /// <summary>
       /// ��ȡƵ����ҳ�б�
       /// </summary>
       /// <param name="nType">0 - All 1-�㲥 2-ֱ�� 3-ת��</param>
       /// <param name="nGroupMask"></param>
       /// <param name="nPage"></param>
       /// <param name="nPageSize"></param>
       /// <returns></returns>
       IList<ChannelData> GetList(Int32 nType, Int32 nGroupMask, Int32 nPage, Int32 nPageSize,Int32 nOrder);

       /// <summary>
       /// ��ȡƵ������
       /// </summary>
       /// <param name="nType"></param>
       /// <param name="nGroupMask"></param>
       /// <returns></returns>
       Int32 GetCount( Int32 nType, Int32 nGroupMask);

       /// <summary>
       /// ��ȡƵ����ַ
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <returns></returns>
       IList<ChannelAddressData> GetAddress(Int32 nChannelId);

       /// <summary>
       /// ��ȡָ����ַ
       /// </summary>
       /// <param name="nAddressId"></param>
       /// <returns></returns>
       ChannelAddressData GetAddressDetail(Int32 nAddressId);

       /// <summary>
       /// ����id��ȡƵ������ϸ��Ϣ
       /// </summary>
       /// <param name="cid"></param>
       /// <returns></returns>
       ChannelData GetChannelInfoById(int cid);

       /// <summary>
       /// ����Ƶ����Ϣ(ĿǰΪ����Ƶ��)
       /// </summary>
       /// <param name="channeldata"></param>
       /// <returns></returns>
       Int32 Insert(ChannelData channeldata);

       /// <summary>
       /// ���¸���Ƶ����Ϣ
       /// </summary>
       /// <param name="channeldata"></param>
       /// <returns></returns>
       Int32 Update(ChannelData channeldata);

         /// <summary>
       /// ����c_upload_mediaserver�ֶ�
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <param name="strState"></param>
       /// <returns></returns>
       Int32 UpdateSubChannelState(Int32 nChannelId, String strState);

       /// <summary>
       /// ɾ������Ƶ��
       /// </summary>
       /// <param name="nChannelId"></param>
       /// <returns></returns>
       Int32 Delete(Int32 nChannelId);

       MediaServerData GetMediaServer(Int32 nMediaServerId);

    }
}
