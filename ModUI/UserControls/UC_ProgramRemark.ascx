<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramRemark.ascx.cs" Inherits="MOD.UI.UserControls.UC_ProgramRemark" %>

 <div id="rmkhdr"></div>
   <asp:Literal ID="ltrListTop" runat="server"></asp:Literal>
    <a name="remark"></a>    
    <asp:Repeater ID="rptPrmRemark" runat="server">
        <ItemTemplate>
            <div class="rmkblock">
                <div class="title">
                    <div class="left">
                        <%#Eval("PrName") %></div>
                    <div class="right"><%#Eval("VUserName") %>  <%#Eval("PrAddTime") %></div>
                </div>
                <p>
                    <%#this.TextIn(Eval("PrInfo").ToString()) %>
                </p>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="rmkblock">
                <div class="title" style="background: #e0d9c7;">
                     <div class="left">
                        <%#Eval("PrName") %></div>
                    <div class="right">
                         <%#Eval("VUserName") %>  <%#Eval("PrAddTime") %></div>
                </div>
                <p style="background: #f5f5f3;">
                     <%#Eval("PrInfo") %>
                </p>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
    <table class="addRemark">
        <tr><td class="w1"><%=this.GetRes("INFO_REMARK_TITLE")%>:</td>
            <td class="w2"><asp:TextBox ID="tbPrName"  runat="server"></asp:TextBox></td></tr>
        <tr><td class="w1"><%=this.GetRes("INFO_REMARK_CONTENT")%>:</td>
        <td class="w2"><asp:TextBox ID="tbPrInfo" TextMode="MultiLine"  runat="server"></asp:TextBox></td></tr>
        <tr><td></td><td class="rowbtn">
        <asp:ImageButton ID="ibtnPostComment" runat="server" ImageUrl="~/Images/depend/btn_submit.gif" OnClick="ibtnPostComment_Click" />
        <input type="image" src="Images/depend/btn_reset.gif" onclick="aspnetForm.reset();return false;" alt="" /></td></tr>
    </table>