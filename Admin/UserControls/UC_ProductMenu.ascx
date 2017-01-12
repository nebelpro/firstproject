<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProductMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProductMenu" %>
 <div class="lRow">
    <h3><%=GetRes("Info_ProductDetail")%></h3>
    <ul id="leftNav">
     <li><a href="javascript://" onclick="product.GetIntro();"><%=GetRes("Info_ProductIntro")%></a></li>   
     <li><a href="javascript://" onclick="product.GetAuthor();"><%=GetRes("Info_ProductAuthor")%></a></li> 
     <li><a href="javascript://" onclick="product.GetSoft();"><%=this.GetRes("Info_ProductSoft") %></a></li>   
     
    </ul>
</div>
               