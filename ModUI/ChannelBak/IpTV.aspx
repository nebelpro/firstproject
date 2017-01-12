<%@ Page Language="C#" MasterPageFile="~/VideoPage.Master" AutoEventWireup="true" CodeBehind="IpTV.aspx.cs" Inherits="MOD.UI.IpTV" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/VideoPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
    
    <div class="video_list">
        <h3><img src="Images/depend/iptv_list.gif" alt="" /></h3>
        <div class="mider" id="chaList">
            <asp:Repeater ID="rptBroad" runat="server">
                <HeaderTemplate><ul></HeaderTemplate>
                <ItemTemplate>
                    <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
                </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
            
           <asp:Repeater ID="rptIPTV" runat="server">
                <HeaderTemplate><ul></HeaderTemplate>
                <ItemTemplate>
                    <li><a href="javascript://" onclick="CastPlay(<%#Eval("CId")%>)"><%#Eval("CName")%></a></li>
                </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        </div>
        
        <div class="btmer"></div>               
    </div>
    <div class="video_player iptv_player">
        <object id="MWP" classid="clsid:A58688A5-3C99-4B22-B29C-53545CEE03D2" viewastext> </object> 
        <div id="divImg"><img src="Images/depend/novideo.gif" alt="" /></div>
        <div id="Oper">
        <img src="Images/player/play_0.gif" style=" cursor:pointer;" id="imgPlay" onclick="PlayPause();" onmouseover="Mover_Play()" onmouseout="Mout_Play()" alt=""/>
        <img id="mid" src="Images/player/mid.gif" alt="" />
        <img src="Images/player/stop_0.gif" id="imgStop" onclick="Stop();" onmouseover="Mover_Stop();" onmouseout="Mout_Stop();"  style=" cursor:pointer;" alt="" />
        </div>
        <div id="Time"><span id="spTime"></span></div>
    <div>
    
    <span id="spRec"></span>
    <span id="spNow" style=" display:none;"></span></div>
    </div>
    
    <div class="video_info">
         <h3><img src="Images/depend/iptv_info.gif" alt="" /></h3>
        <div class="mider">
           <p id="castInfo"></p>
        </div>
        <div class="btmer"></div> 
    </div>    
   
    <script type="text/javascript">
         Event.observe($("chaList"), "click",ChannelSelected);
    </script>
</asp:Content>
