<%@ Page Language="C#" MasterPageFile="~/UserCenter.Master" AutoEventWireup="true" CodeBehind="PlayLog.aspx.cs" Inherits="MOD.UI.PlayLog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplUser" runat="server">
 <h3><img src="Images/depend/PlayLog.gif" alt=""/></h3>  
 <div class="ListBar">
  <%=this.GetRes("INFO_PLAY_TIME")%>: <asp:TextBox ID="tbDateBegin" CssClass="txt" runat="server"></asp:TextBox> - <asp:TextBox ID="tbDateEnd" CssClass="txt" runat="server"></asp:TextBox>
            <%=this.GetRes("Info_DateFormat")%><asp:ImageButton ID="ibtnSearchCardUser" Width="51px" Height="23px" ImageUrl="Images/depend/m_button_search.gif" runat="server" OnClick="ibtnSearchCardUser_Click" />
  </div>
    <div class="ListBar"><div class="right"><asp:Literal ID="ltrNavBottom" runat="server"></asp:Literal></div></div>
    
    <asp:Repeater ID="rptCardPlay" runat="server">
       <HeaderTemplate>
       <table id="PlayLog">
            <tr class="hdr">
                <td class="w1"><%=this.GetRes("INFO_PROGRAM_NAME")%></td>
                <td class="w2"><%=this.GetRes("INFO_PLAY_TIME")%></td>
                <td class="w3"><%=this.GetRes("INFO_CARD_VALUE")%></td>
            </tr>
       </HeaderTemplate>
        <ItemTemplate>
        <tr class="item"><td class="w1"><a href='ProgramInfo.aspx?pid=<%#Eval("PcpProgramId") %>' target="_blank"><%#Eval("PcpProgramName") %></a></td>
            <td class="w2"><%#Eval("PcpDateTime")%></td>
            <td class="w3"><%#Eval("PcpProgramPoint") %></td> 
        </tr>
        </ItemTemplate>	
        <AlternatingItemTemplate>
        <tr class="alter"><td class="w1"><a href='ProgramInfo.aspx?pid=<%#Eval("PcpProgramId") %>' target="_blank"><%#Eval("PcpProgramName") %></a></td>
            <td class="w2"><%#Eval("PcpDateTime")%></td>
            <td class="w3"><%#Eval("PcpProgramPoint") %></td> 
        </tr>
        </AlternatingItemTemplate>
        <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>  
        <asp:Literal ID="ltrEmpty" runat="server"></asp:Literal>
</asp:Content>
