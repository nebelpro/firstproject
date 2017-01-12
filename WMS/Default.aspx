<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MOD.UI.WMS.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <link rel="stylesheet" href="Style/public.css" type="text/css"/>    
    <link rel="stylesheet" href="Style/video.css" type="text/css"/> 
    <script type="text/javascript" src="Scripts/prototype.js"></script> 
    <script type="text/javascript" src="Scripts/mod.js"></script>
    <title></title>   
</head>
<body>
  <form id="form1" runat="server">        
    <div id="wrapper">            
        <div id="toper">
        <div id="logo"><img src="Images/depend/iptv_logo.gif" alt=""/></div>             
        </div> 
    <div id="sider"></div>           
    <div id="video_primary">
        <div class="video_list">
            <h3><img src="Images/depend/iptv_list.gif" alt="" /></h3>
            <div class="mider" id="chaList">
                <asp:Repeater ID="rptWMS" runat="server" OnItemDataBound="rptWMS_ItemDataBound">
                    <HeaderTemplate><ul></HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>,0)"><%#Eval("CName")%></a>
                            <asp:Repeater runat="server" ID="rptAddress">
                                <HeaderTemplate><ul></HeaderTemplate>
                                <ItemTemplate><li class="hand" onclick="CastPlay(<%#Eval("CaChannelId")%>,<%#Eval("CaId")%>);"><%#Eval("CaNetCard").ToString().Replace("mms://","")%></li></ItemTemplate>
                                <FooterTemplate></ul></FooterTemplate>
                            </asp:Repeater>                            
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>                            
            </div>                
            <div class="btmer"></div>               
         </div>
        <div class="video_player iptv_player">
        <object id="Player" height="446"  width="554" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6"> 
            <param name="uiMode" value="None"/>
        </object>
        
        <div id="divImg"><img src="Images/depend/novideo.gif" alt="" /></div>
        <div id="Oper">
            <img src="Images/player/play_nor.gif" style="cursor:pointer;" id="btnPlay" onclick="Play(this);" onmouseout="MMout_Play(this)" onmouseover="MMover_Play(this)" alt=""/>
            <img id="mid" src="Images/player/mid.gif" alt="" />
            <img src="Images/player/stop_nor.gif" id="btnStop" onmouseout="MMout_Stop(this)" onclick="Stop();" onmouseover="MMover_Stop(this)" class="hand" alt="" />           
            <span id="spMute" onclick="Mute()"><img src="Images/Player/mute_nor.gif"  title="<%=this.GetRes("Volume_Active") %>"  style="cursor:hand" alt="" /></span>
            <span id="spVolumeSlider" onclick="GoVolume()"><span id="spVolumeCur"></span></span>
            <span id="spVolumeBtn" class="hand"  onmousemove="SlideVolume(this)" onmouseup="SlideVolumeOver(this)"><img src="Images/Player/volume_3.gif" class="hand" alt=""/></span>        
        </div> 
        <img id="btnFull" src="Images/Player/full_nor.gif" class="hand"  onclick="SetFull()" onmouseover="MMover_Full(this)" onmouseout="MMout_Full(this)" title="<%=this.GetRes("Info_Full") %>" alt="" />
        
        <div id="Time"><span id="spState"></span>&nbsp;&nbsp;&nbsp;<span id="spTime"></span></div>
     </div>
        <div class="video_info">
        <h3><img src="Images/depend/iptv_info.gif" alt="" /></h3>
        <div class="mider">
           <p id="castInfo"></p>
        </div>
        <div class="btmer"></div> 
        </div> 
    </div>
    <script type="text/javascript">   
        PageLoad();           
    </script>
    <div id="btmer"></div>    
    <div id="footer"><%=string.Format(this.GetRes("Info_CopyRight"),DateTime.Now.Year)%></div>
    </div> 
    </form>
</body>
</html>


