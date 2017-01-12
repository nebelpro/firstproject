<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramInfo.ascx.cs" Inherits="MOD.UI.UserControls.UC_ProgramInfo" %>
<%@ Register Src="~/UserControls/UC_ProgramRemark.ascx" TagName="ProgramRemark" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/UC_ProgramChapter.ascx" TagName="ProgramChapter" TagPrefix="UC" %>
<div id="prmintro">
    <table id="pInfo">
        <tr><td class="pImg">
            <table ><tr><td ><asp:Literal ID="ltrImg" runat="server"></asp:Literal></td></tr></table></td>
            <td class="detail">
                <table >
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_NAME")%>: </td><td class="w2"><asp:Literal ID="ltrName" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_POINT")%>: </td><td class="w2"><asp:Literal ID="ltrPoint" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_DIRECTOR")%>: </td><td class="w2"><asp:Literal ID="ltrDirector" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_ACTOR")%>: </td><td class="w2"><asp:Literal ID="ltrActor" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_LENGTH")%>: </td><td class="w2"><asp:Literal ID="ltrTime" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_CLASS")%>: </td><td class="w2"><asp:Literal ID="ltrClass" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_KBPS")%>: </td><td class="w2"><asp:Literal ID="ltrKbps" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_ADDTIME")%>: </td><td class="w2"><asp:Literal ID="ltrAddtime" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"><%=this.GetRes("INFO_PROGRAM_VIEW")%>: </td><td class="w2"><asp:Literal ID="ltrReadCount" runat="server"></asp:Literal></td></tr>
                    <tr><td class="w1"></td><td class="btn"><asp:Literal ID="ltrPlay" runat="server"></asp:Literal><asp:Literal ID="ltrTimeLeft" runat="server"></asp:Literal>  </td></tr>
                </table>
            </td>
        </tr>
    </table> 
</div>
<div id="mypanel">
    <div class="tab-pane" id="tabPane1">
        <script type="text/javascript">tp1 = new WebFXTabPane( $( "tabPane1" ),false);</script>
        <!-- panel 1-->
        <div class="tab-page" id="tabPage1">
            <h2 class="tab"><%=this.GetRes("INFO_PROGRAM_INTRO") %></h2>
            <script type="text/javascript">tp1.addTabPage( $( "tabPage1" ) );</script>
            <asp:Literal ID="ltrIntro" runat="server"></asp:Literal>
        </div>
        <!-- panel 1 end -->
        <!-- panel 2 -->
        <div class="tab-page" id="tabPage2" runat="server">
            <h2 class="tab"><%=this.GetRes("INFO_PROGRAM_REMARK")%></h2>
            <script type="text/javascript">tp1.addTabPage( $( "ctl00_rightHolder_UC_ProgramInfo1_tabPage2" ) );</script>
            <UC:ProgramRemark ID="UC_ProgramRemark1" runat="server" />
        </div>
        <!--panel 2 end -->
        <div class="tab-page" id="tabPage3">
            <h2 class="tab"><%=this.GetRes("INFO_PROGRAM_CHAPTER") %></h2>
            <script type="text/javascript">tp1.addTabPage( $( "tabPage3" ) );</script>
            <UC:ProgramChapter ID="UC_ProgramChapter1" runat="server" />
        </div>
        <div class="tab-page" id="tabPage4" runat="server">
            <h2 class="tab"><%=this.GetRes("Info_MediaServer")%></h2>
            <script type="text/javascript">tp1.addTabPage( $( "ctl00_rightHolder_UC_ProgramInfo1_tabPage4" ) );</script>
            <asp:Repeater ID="rptMediaServer" runat="server">
                <HeaderTemplate><table><tr><th><%=this.GetRes("MS_Name")%></th><th><%=this.GetRes("MS_State")%></th><th><%=this.GetRes("MS_Load")%></th>
                <th><%=this.GetRes("MS_Description")%></th><th><%=this.GetRes("Oper_Play")%></th><th><%=this.GetRes("Oper_Download")%></th></tr></HeaderTemplate>
                <ItemTemplate><tr><td><%#Eval("MsName") %></td><td><%#MOD.WebUtility.MediaServerHelper.GetState(Int32.Parse(Eval("MsRegister").ToString()))%></td>
                <td><%#MOD.WebUtility.MediaServerHelper.GetLoad(Int32.Parse(Eval("MsRegister").ToString()), Int32.Parse(Eval("MsAvgBand").ToString()), Int32.Parse(Eval("MsMaxBand").ToString()))%></td><td><%#Eval("MsInfo") %></td>
                <td><%#this.BindUrl(int.Parse(Eval("MsRegister").ToString()),this.GetIntParam("pid", 0), int.Parse(Eval("MsId").ToString()), 0)%></td>
                <td><%#this.BindDownload(int.Parse(Eval("MsRegister").ToString()), this.GetIntParam("pid", 0), int.Parse(Eval("MsId").ToString()), 0)%></td>
              </tr></ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>