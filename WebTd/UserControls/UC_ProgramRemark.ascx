<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramRemark.ascx.cs" Inherits="MOD.WebTd.UserControls.UC_ProgramRemark" %>
<a name="remark"></a>
<div class="mark">
    <div class="left"><img src="Images/depend/pro_remark_list.gif" alt=""/></div>
    <div class="right"></div>  
</div>  

<div>
    <div class="remarktop"></div>
    <div class="remarkcenter">
        <div class="remarkarea">
            <div class="remarkpage"><asp:Literal ID="ltPage" runat="server"></asp:Literal></div>
            <asp:Repeater ID="rptPrmRemark" runat="server">
                <ItemTemplate>
                    <div class="remark-item">
                    <div class="remark-item-head"><b><%#Server.HtmlEncode(Eval("VUserName").ToString()) %></b> <%#Eval("PrAddTime") %></div>
                    <div class="remark-item-info"><%#MOD.WebUtility.WebHelper.HtmlEncode(Eval("PrInfo").ToString())%></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>           
        <div class="newcomment">
            <div><%=this.GetRes("INFO_PROGRAM_COMMENT")%></div>
            <div>
                <asp:TextBox ID="tbPrInfo" TextMode="MultiLine" Rows="8" runat="server" CssClass="remarkinput"></asp:TextBox>
            </div>
            <div>
                <asp:ImageButton ImageUrl="~/Images/depend/btn_submit.gif" runat="server" Width="71px" Height="26px" id="btnComment" OnClick="btnComment_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <img src="Images/depend/btn_reset.gif" class="hand" onclick="document.getElementById('aspnetForm').reset();" />
            </div>
        </div>
    </div>
    <div class="remarkbottom"></div>
</div>