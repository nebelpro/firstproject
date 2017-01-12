<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinTop.ascx.cs" Inherits="MOD.UI.UserControls.UC_BulletinTop" %>
<div id="bulletin">
<div class="bug">   
    <asp:Repeater ID="rptBullist" runat="server">
        <HeaderTemplate><table class="list"></HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="w1">
                    <a href="#" onclick="openwndex('BulletinInfo.aspx?bid=<%#Eval("BId")%>','<%=this.GetRes("INFO_BULLETIN_TITLE") %>','400','400')"
                        title="<%#Eval("BName") %>">
                        <%#this.SubMixText(this.TextOut(Eval("BName").ToString()),22)%>
                    </a>
                </td>
                <td class="w2">
                    <%#Convert.ToDateTime(Eval("BAddTime").ToString()).ToShortDateString()%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>   
</div>
<a class="more" href="BulletinList.aspx" title="more..."></a>
</div>