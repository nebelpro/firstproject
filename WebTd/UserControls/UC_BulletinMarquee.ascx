<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinMarquee.ascx.cs" Inherits="MOD.WebTd.UserControl.UC_BulletinMarquee" %>
<div id="naver"><div class="left"></div>
<asp:Repeater ID="rptBulletin" runat="server">
    <HeaderTemplate><div id="BulletinNav"><marquee direction="left" onMouseOver="this.stop();" onMouseOut="this.start()" scrollamount="2" ><ul></HeaderTemplate>
    <ItemTemplate> <li>
                <a href="BulletinList.aspx">[<%#Eval("BAddTime")%>]
                <%#this.SubMixText(Eval("BName").ToString(),22,"...")%>
            </a></li></ItemTemplate>
    <FooterTemplate></ul></marquee></div></FooterTemplate>    
</asp:Repeater> 
<div class="right"></div></div>