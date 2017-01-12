<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_carduselist.ascx.cs" Inherits="MOD.Admin.UserControls.uc_carduselist" %>
   <div class="rRow">
    <h3><%=GetRes("Info_CardUseRecord")%></h3>
    
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
               <table id="CardUseList">
                <tr class="hdr">
                     <td class="w0"></td>
                    <td class="w1"><%=GetRes("Info_CardNo") %></td>                   
                    <td class="w2"><%=GetRes("Info_CardUseDate")%></td>
                    <td class="w3"><%=GetRes("Info_CardPoint") %></td>                    
                    <td class="w4"><%=GetRes("Info_CardUsePerson")%></td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="item">  
                    <td class="w0"></td>                    
                    <td class="w1"><%#Eval("CuNumber")%></td>  
                    <td class="w2"><%#Eval("CuDateTime").ToString()%></td>                 
                    <td class="w3"><%#Eval("CuPointValue")%><%#MOD.WebUtility.CardHelper.GetCardUnit(int.Parse(Eval("CuType").ToString()))%></td>                                       
                    <td class="w4"><%#Eval("CuMask")%></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
               <tr class="alter">  
                    <td class="w0"></td>                   
                    <td class="w1"><%#Eval("CuNumber")%></td>  
                    <td class="w2"><%#Eval("CuDateTime").ToString()%></td>                 
                    <td class="w3"><%#Eval("CuPointValue")%><%#MOD.WebUtility.CardHelper.GetCardUnit(int.Parse(Eval("CuType").ToString()))%></td>                                       
                    <td class="w4"><%#Eval("CuMask")%></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
      <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
    
    <div class="ListBar">
        <div class="left">           
        </div>
        <div class="right"><asp:Literal ID="ltrListBtm" runat="server"></asp:Literal></div>
    </div>
    </div>