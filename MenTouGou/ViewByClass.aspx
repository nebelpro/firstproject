<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="ViewByClass.aspx.cs" Inherits="mentougou.ViewByClass" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_ProgramList.ascx" TagName="UC_ProgramList" TagPrefix="uc1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlCatalog" runat="server">       
        <div class="subb">
            <h3><img src="Images/depend/h3_catalog.gif" alt="" /></h3>  
            <div class="subcontent">      
            <asp:Repeater ID="rptCatalogList" runat="server">
                <HeaderTemplate><ul id="cataloglist"></HeaderTemplate>
                <ItemTemplate><li> <a href="ViewByClass.aspx?cid=<%#Eval("CId") %>"><%#this.SubMixText(Eval("CName").ToString(),30,"...") %></a>
                [<%#mentougou.Helper.GetProgramCountByCatalogId(int.Parse(Eval("CId").ToString()))%>]</li></ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater> 
            <div style="clear:both;"></div>
            </div>         
           <div class="subfooter"></div>
           
       </div>
        
    </asp:Panel>
    <uc1:UC_ProgramList id="UC_ProgramList1" runat="server"/>
   


</asp:Content>
