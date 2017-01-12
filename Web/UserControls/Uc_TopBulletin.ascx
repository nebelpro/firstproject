<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_TopBulletin.ascx.cs" Inherits="MOD.WebTd.UserControls.Uc_TopBulletin" %>
 <asp:Panel ID="panelBulletin" runat="server">
    <asp:Repeater ID="rptBullist" runat="server">
        <HeaderTemplate>
            <div class="btop" style="background: url(images/depend/bulletin.gif) no-repeat;">
            </div>
            <div class="blist">
                <ul class="bullist">
       </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="#" onclick="openwndex('BulletinInfo.aspx?bid=<%#Eval("BId")%>','<%#Eval("BName")%>','400','400');return false;">
                            <%#MOD.WebUtility.WebHelper.GetSubString(Eval("BInfo").ToString(), 14)%>
                        </a></li>
                    </ItemTemplate>
         <FooterTemplate>
                </ul> 
            </div>
            <div class="bbtm"></div>
        </FooterTemplate>
    </asp:Repeater>
    </asp:Panel>