<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProductAuthor.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProductAuthor" %>
<div class="rRow" id="Product">
    <h3><%=GetRes("Info_ProductAuthor")%></h3>
    <ul class="productAuthor">
        <asp:Literal ID="ltrAuthorInfo" runat="server"></asp:Literal>    
    </ul>
</div>