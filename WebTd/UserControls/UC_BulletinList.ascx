<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinList.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_BulletinList" %>

<div class="mark">
    <div class="left"><img src="Images/depend/bul_list.gif" alt=""/></div>
    <div class="right"></div>  
</div>       
<asp:Literal ID="ltrListTop" runat="server"></asp:Literal>
<asp:Repeater ID="rptBullist" runat="server">
    <HeaderTemplate><table id="BulletinList"></HeaderTemplate>
    <ItemTemplate>
        <tr class="item"><td class="w1">
                <a href="#" onclick="user.GetBulletinInfo(<%#Eval("BId")%>,'<%#Eval("BName")%>');"
                    title="<%#Eval("BName") %>">
                    <%#this.SubMixText(Eval("BName").ToString(),20,"...")%>
                </a>
            </td>
            <td class="w2">
                <%#Eval("BAddTime")%>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="alter"><td class="w1">
                <a href="#" onclick="user.GetBulletinInfo(<%#Eval("BId")%>,'<%#Eval("BName")%>');"
                    title="<%#Eval("BName") %>">
                    <%#this.SubMixText(Eval("BName").ToString(),20,"...")%>
                </a>
            </td>
            <td class="w2">
                <%#Eval("BAddTime")%>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate></table></FooterTemplate>
</asp:Repeater>
<asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
