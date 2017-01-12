<%@ Page Language="C#" MasterPageFile="~/VideoPage.Master" AutoEventWireup="true" CodeBehind="ChannelInfo.aspx.cs" Inherits="MOD.UI.ChannelInfo" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/VideoPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
<div id="banner"></div>
<div class="brder">
    <div id="subb"><!-- use the style as subb -->
        <h3><asp:Literal ID="ltrTip" runat="server"></asp:Literal></h3>        
      
        <div class="castblock">               
                <table class="castimg"><tr><td> <asp:Literal ID="ltrLargeImg" runat="server"></asp:Literal></td></tr></table>         
             
                <ul>
                    <li> <asp:Literal ID="ltrSmallImg" runat="server"></asp:Literal>     <b>  <asp:Literal ID="ltrCName" runat="server"></asp:Literal></b></li>
                    <li> 
                        <table><tr>
                            <td><%= this.GetRes("INFO_CHANNEL_STATE") %>:
                            <asp:Literal ID="ltrStatus" runat="server"></asp:Literal></td>
                            <td><%= this.GetRes("INFO_CHANNEL_USER") %>:
                             <asp:Literal ID="ltrUserName" runat="server"></asp:Literal></td>
                       </tr></table>
                    </li>
                    <li> 
                        <table><tr>
                                <td><%= this.GetRes("INFO_CHANNEL_CREATE") %>
                                    <asp:Literal ID="ltrCreateTime" runat="server"></asp:Literal></td>
                                <td><%= this.GetRes("INFO_CHANNEL_START") %>
                                    <asp:Literal ID="ltrBeginTime" runat="server"></asp:Literal></td>
                       </tr></table>
                    </li>
                    <li><asp:Literal ID="ltrCInfo" runat="server"></asp:Literal></li>
                    <li> <table><tr><td align="right">
                         <asp:Literal ID="ltrPlay" runat="server"></asp:Literal>
                    </td></tr></table> </li>                    
                </ul>
         </div>  
         <h3><%= this.GetRes("INFO_CHANNEL_ADDRESS_TITLE")%></h3>        
         <div class="castblock">  
                <asp:Literal id="ltAddressList" runat="server"></asp:Literal>
         </div>  
                 
    </div>
</div>
</asp:Content>
