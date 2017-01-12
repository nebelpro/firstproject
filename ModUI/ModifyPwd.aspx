<%@ Page Language="C#" MasterPageFile="~/UserCenter.Master" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="MOD.UI.ModifyPwd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplUser" runat="server">
<h3><img src="Images/depend/modify.gif" alt=""/></h3>
 <table id="ModifyPwd">
    <tr>      
      <td class="w1"><%=this.GetRes("INFO_PWD_OLD")%>: </td>
      <td class="w2"><asp:TextBox CssClass="txt" ID="txPdOld" runat="server" TextMode="Password"></asp:TextBox></td>
      <td class="w3"><asp:Label ID="lblPwdOld" ForeColor="red" runat="server"></asp:Label></td>
    </tr>    
    <tr>      
      <td class="w1"><%=this.GetRes("INFO_PWD_NEW")%>: </td>
      <td class="w2"><asp:TextBox CssClass="txt" ID="txPdDefault" runat="server" TextMode="Password"></asp:TextBox></td>
      <td class="w3"><asp:Label ID="lblPwdNew" ForeColor="red" runat="server"></asp:Label></td>
    </tr>    
    <tr>      
      <td class="w1"><%=this.GetRes("INFO_PWD_NEWCONFIRM")%>: </td>
      <td class="w2"><asp:TextBox CssClass="txt" ID="txPdConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
      <td class="w3"><asp:Label ID="lblPwdConfirm" ForeColor="red" runat="server"></asp:Label></td>
    </tr>    
    <tr> 
      <td class="w1">&nbsp;</td>
      <td class="w2"><asp:ImageButton ID="ImageChangePwd" CssClass="btn" runat="server" ImageUrl="Images/depend/m_button_editpass.gif" OnClick="ImageChangePwd_Click" /></td>
      <td class="w3"></td>
    </tr>    
  </table>
</asp:Content>
