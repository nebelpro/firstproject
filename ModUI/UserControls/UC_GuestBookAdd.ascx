<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GuestBookAdd.ascx.cs" Inherits="MOD.UI.UserControls.UC_GuestBookAdd" %>
<h3><img src="Images/depend/GuestBookAdd.gif" alt="" /></h3>
<table id="GuestBookAdd">
<tr><td class="w1"><%=GetRes("Info_GuestBookTitle")%></td><td class="w2"><input type="text"  runat="server" id="txtSubject" class="txt" /></td></tr>
<tr><td class="w1"><%=GetRes("Info_GuestBookInfo")%></td><td class="w2"><textarea rows="5" id="txtInfo" runat="server" class="txt" cols="16"></textarea> </td></tr>
<tr><td class="w1"><%=GetRes("Info_GuestBookType")%></td>
    <td class="w2">           
       <input type="radio" id="gbType0" name="gbType" checked runat="server" /><%=GetRes("Info_GuestBookPublic")%> 
       <input type="radio" id="gbType1" name="gbType" runat="server" /><%=GetRes("Info_GuestBookPrivate") %>
    </td>        
</tr>
<tr>
<td></td>
<td class="txtRight">
    <asp:Label ID="lblTips" runat="server" ForeColor="red"></asp:Label>
    <input type="image" src="~/Images/depend/btn_ok.gif"  class="btn" onserverclick="Add_Click" runat="server" />
</td></tr>
</table>   
