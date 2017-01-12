<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BulletinList.ascx.cs" Inherits="mentougou.UserControl.UC_BulletinList" %>
<div class="subb">
     <h3><img src="Images/depend/h3_bulletin.gif"  alt=""/></h3>
     <div class="subcontent"> 
        <div class="ListBar">
                <div class="left" style=" padding-left:10px;">
                    <asp:Literal ID="ltrOper" runat="server"></asp:Literal></div>
                <div class="right"><asp:Literal ID="ltrListTop" runat="server"></asp:Literal></div>
         </div>  
        <asp:Repeater ID="rptBullist" runat="server">
            <HeaderTemplate> <table id="bulletin"></HeaderTemplate>
            <ItemTemplate>
               <tr class="cTitle">
                <td class="w1"><img src="Images/nodepend/li2.gif" alt=""/></td>
                <td class="w2"><%#mentougou.Helper.GetEditUrl(Eval("BId").ToString(),Eval("BName").ToString())%>
                        
                </td>
                <td class="w3"><%#Eval("BUserName") %></td>
                <td class="w4"><%#Eval("BAddTime")%></td>
               </tr>
               <tr class="cInfo"><td class="w1"></td><td colspan="3" ><%#Eval("BInfo") %></td></tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
         </asp:Repeater>  
         <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>  
         <div class="ListBar">
                <div class="left"></div>
                <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
         </div>   
           
          
     </div>
     <div class="subfooter"></div>
</div>