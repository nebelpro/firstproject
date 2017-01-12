<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableViewState="false"  CodeBehind="ViewByClass.aspx.cs" Inherits="MOD.UI.ViewByClass" Title="MOD" %>
<%@ Register Src="UserControls/uc_programlist.ascx" TagName="ProgramList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightHolder" runat="server">
    <div class="brder">
        <div id="subb">            
            <UC:ProgramList ID="Uc_programlist1" runat="server" />
        </div>
       
    </div>
</asp:Content>
