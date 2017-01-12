<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinMarquee.ascx.cs" Inherits="MOD.UI.UserControl.UC_BulletinMarquee" %>
<asp:Repeater ID="rptBulletin" runat="server">
    <HeaderTemplate><marquee direction="left" onMouseOver="this.stop();" onMouseOut="this.start()" scrollamount="2" ><ul id="bulletinNav"></HeaderTemplate>
    <ItemTemplate> <li>
                <a href="BulletinList.aspx">[<%#Eval("BAddTime")%>]
                <%#this.SubMixText(Eval("BName").ToString(),22,"...")%>
            </a></li></ItemTemplate>
    <FooterTemplate></ul></marquee></FooterTemplate>
    
</asp:Repeater> 