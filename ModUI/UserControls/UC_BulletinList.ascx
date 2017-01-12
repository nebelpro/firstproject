<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinList.ascx.cs" Inherits="MOD.UI.UserControls.UC_BulletinList" %>
<div id="subb">
    <h3><asp:Literal ID="ltrTip" runat="server"></asp:Literal></h3>        
   <asp:Literal ID="ltrListTop" runat="server"></asp:Literal>
    <asp:Repeater ID="rptBullist" runat="server">
        <HeaderTemplate><table id="BulletinList"></HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="w1">
                    <a href="#" onclick="openwndex('BulletinInfo.aspx?bid=<%#Eval("BId")%>','<%#Eval("BName")%>','400','400')"
                        title="<%#Eval("BName") %>">
                        <%#this.SubMixText(Eval("BName").ToString(),20,"...")%>
                    </a>
                </td>
                <td class="w2">
                    <%#Eval("BAddTime")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
</div>