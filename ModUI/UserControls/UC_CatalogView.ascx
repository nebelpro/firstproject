<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogView.ascx.cs" Inherits="MOD.UI.UserControls.UC_CatalogView" %>
 <asp:Panel ID="pnlCatalog" runat="server">  
 <asp:Repeater ID="rptCatalogList" runat="server">
    <HeaderTemplate><ul id="cataloglist"></HeaderTemplate>
    <ItemTemplate><li onmouseover="this.className='selected';" onmouseout="this.className='none';">
    <a href="ViewByClass.aspx?cid=<%#Eval("CId") %>"><%#this.SubMixText(Eval("CName").ToString(),18) %></a>    
        [ <%#MOD.WebUtility.ProgramHelper.GetProgramCountByCatalogId(int.Parse(Eval("CId").ToString()))%> ]           
      </li></ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater> 
<p style=" clear:both;"></p>  
</asp:Panel>