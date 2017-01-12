<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BulletinList.aspx.cs" Inherits="mentougou.BulletinList" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_BulletinList.ascx" TagName="UC_BulletinList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_BulletinList id="UC_BulletinList1" runat="server">
    </uc1:UC_BulletinList>
</asp:Content>
