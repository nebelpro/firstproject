<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mentougou.Default" Title="Untitled Page" %>

<%@ Register Src="UserControl/UC_CastUI.ascx" TagName="CastUI" TagPrefix="UC" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<%@ Register Src="UserControl/UC_CatalogMix.ascx" TagName="Catalog" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
            
    <UC:Catalog id="catalog1" TitlePic="Images/depend/title01.gif" CatalogPic="Images/nodepend/catalog01.gif" ParentId="22" runat="server"/>
     <UC:CastUI id="castui" runat="server"/>
    <UC:Catalog id="catalog3" TitlePic="Images/depend/title02.gif" CatalogPic="Images/nodepend/catalog02.gif" ParentId="23" runat="server"/>
    
 <UC:Catalog id="catalog4" TitlePic="Images/depend/title03.gif" CatalogPic="Images/nodepend/catalog03.gif" ParentId="24" runat="server"/>
    <UC:Catalog id="catalog5" TitlePic="Images/depend/title04.gif" CatalogPic="Images/nodepend/catalog04.gif" ParentId="25" runat="server"/>
    <UC:Catalog id="catalog6" TitlePic="Images/depend/title05.gif" CatalogPic="Images/nodepend/catalog05.gif" ParentId="26" runat="server"/>
    
   
    <script type="text/javascript">
        function init(){  
            //var strPPPPPP="[{'cid':13,'auto':'1','ssrc':646997075,'receive':[{'type':'tcp','port':102,'ip':'192.168.0.113'},{'type':'udp','port':50133,'ip':'225.0.34.71'}]}]";
            var strPrm="<%=this.strParam %>";
           // alert(strPrm);
            if(strPrm=="-1"){
                ShowVideoEmpty();
            }else{
                Page_Load(strPrm);
            }          
        }
        window.onload =  init;
        
    </script>
   
</asp:Content>
