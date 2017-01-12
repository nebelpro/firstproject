<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CatalogMix.ascx.cs" Inherits="mentougou.UserControl.UC_CatalogMix" %>
 <div class="albums">
     <h3> <asp:Image ID="TitleImage" runat="server"></asp:Image></h3>
    <div class="acover">
    <table><tr><td><asp:Image ID="CatalogImage" runat="server" /></td></tr></table>
     </div>     
     <asp:Repeater ID="rptCatalog" runat="server" OnItemDataBound="rptCatalog_ItemDataBound">
        <HeaderTemplate><dl class="b-info"></HeaderTemplate>
        <ItemTemplate>
            <dd><ul class="info"><li class="name" onmouseover="ShowSubCatalog(this);" onmouseout="HideSubCatalog(this);">
                    <a href="ViewByClass.aspx?cid=<%#Eval("CId") %>"><%#this.SubMixText(Eval("CName").ToString(),8)%></a>
                    <asp:Repeater ID="rptCatalogList" runat="server">
                        <HeaderTemplate><ul></HeaderTemplate>
                        <ItemTemplate><li><a href="ViewByClass.aspx?cid=<%#Eval("CId") %>"><%#this.SubMixText(Eval("CName").ToString(),8)%></a></li>
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:Repeater></li>
                    <asp:Repeater ID="rptSubProgram" runat="server">
                        <ItemTemplate>
                        <li class="item"><span><%#mentougou.Helper.GetHotTip(int.Parse(Eval("PId").ToString()))%></span><a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>"><%#this.SubMixText(Eval("PName").ToString(),8,"...")%></a></li></ItemTemplate>
                    </asp:Repeater>   
                </ul></dd>     
        </ItemTemplate>
        <FooterTemplate></dl></FooterTemplate>
         
    </asp:Repeater>
    <p class="more"><a href="ViewByClass.aspx?cid=<%=this.ParentId%>"><img src="Images/depend/more.gif" alt="" /></a></p>
</div>