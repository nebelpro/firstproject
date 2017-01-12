<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramTop.ascx.cs" Inherits="MOD.UI.UserControls.UC_ProgramTop" %>
<div id="topProgram">
<h3><img src="Images/depend/counttop.gif" alt="" /></h3>
<asp:Repeater ID="rptPopList" runat="server">
<HeaderTemplate><div><table></HeaderTemplate>
<ItemTemplate>
    <tr><td class="w1"><%#MOD.UI.Helper.GetItemString(rptPopList.Items.Count+1)%></td>
        <td class="w2"><a href="ProgramInfo.aspx?pid=<%#Eval("PId") %> " title="<%#Eval("PName") %>">
                <%#this.SubMixText(Eval("PName").ToString(),12,"...") %>
        </a></td>
        <td class="w3"><%#Eval("PReadCount")%></td>
    </tr>
</ItemTemplate>
<FooterTemplate></table></div></FooterTemplate>
</asp:Repeater>               
</div>