<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GuestBookList.ascx.cs" Inherits="MOD.UI.UserControls.UC_GuestBookList" %>
    <h3><img src="Images/depend/GuestBook.gif" alt="" /></h3>
    <div class="ListBar">  
      <div class="left"><a href="GuestBook.aspx?oper=add"><%=GetRes("Info_GuestBookAdd") %></a></div>      
      <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
   </div>
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate><div id="GuestBookList"></HeaderTemplate>
        <ItemTemplate>
           <div class="gbItem">
            <ul>
                <li class="w1"><%#Eval("GbSubject") %></li>
                <li class="w2"><%#Eval("GbUser") %></li>
                <li class="w3"><%#Eval("GbDate") %></li>                
            </ul>
            <p><%#Eval("GbInfo") %></p>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
           <div class="gbAlter">
            <ul>
                <li class="w1"><%#Eval("GbSubject") %></li>
                <li class="w2"><%#Eval("GbUser") %></li>
                <li class="w3"><%#Eval("GbDate") %></li>                
            </ul>
            <p><%#Eval("GbInfo") %></p>
            </div>
        </AlternatingItemTemplate>
        <FooterTemplate></div></FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>  
   <div class="ListBar">
      <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
   </div>   
