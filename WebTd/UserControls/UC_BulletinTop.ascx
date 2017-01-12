<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinTop.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_BulletinTop" %>
<asp:Repeater ID="rptBullist" runat="server">
    <HeaderTemplate>
        <h3><a href="BulletinList.aspx"><img src="Images/depend/bulletin.gif" alt="more..." /></a></h3>
        <ul class="list bulletin">
   </HeaderTemplate>
    <ItemTemplate>
        <li><a href="javascript://" onclick="user.GetBulletinInfo(<%#Eval("BId")%>,'<%#Eval("BName")%>');">
            <%#this.SubMixText(Eval("BName").ToString(), 26)%>
        </a></li>
    </ItemTemplate>
     <FooterTemplate>
        </ul>
        <div class="btm"></div>
    </FooterTemplate>
</asp:Repeater>
