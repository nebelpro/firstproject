<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableViewState="false" Inherits="MOD.WebTd.ProgramVideo" Title="Untitled Page" Codebehind="Program.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
     <div id="position"><%=this.GetRes("Info_Home")%></div>
    <div id="banner"><img src="Images/depend/banner.gif" alt="banner" /></div>
    <div class="mark">
        <div class="left"><img src="Images/depend/poprogram.gif" alt=""/></div>
        <div class="right"></div>  
    </div>
    <div id="newprm">                  <asp:Repeater ID="rptNew" runat="server" >        <ItemTemplate>         <table>
            <tr><td><a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>">
            <img src="<%# MOD.WebUtility.ProgramHelper.GetProgramImage((Int32)Eval("PImageId")) %>" alt="<%#Eval("PName") %>" onload="if(this.height>172)this.height=172;if(this.width>132)this.width=132;" />
     	    </a></td></tr>         </table> 		                    </ItemTemplate>                    </asp:Repeater>             
     </div>          
    <div class="mark">
        <div class="left"><img src="Images/depend/newpro.gif" alt=""/></div>
        <div class="right"></div>  
    </div>    
    <div id="prmlist">
        <asp:Repeater ID="rptPop" runat="server">
        <ItemTemplate>
        <div class="view-item">   
        <table>
           <tr><td class="view-item-img"><a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>">
                    <img src="<%# MOD.WebUtility.ProgramHelper.GetProgramImage((Int32)Eval("PImageId")) %>" 
                    <%#MOD.WebUtility.ProgramHelper.OutImageWidthHeight(100,100,Int32.Parse(Eval("PImageId").ToString())) %>  alt="<%#Eval("PName") %>" /></a>
                </td>
                <td class="view-item-info">
                    <table>
                        <tr><th class="view-item-title"><img title="<%=this.GetRes("INFO_PROGRAM_PLAY") %>" class="hand" onclick="OpenPlay('<%#MOD.WebUtility.WebHelper.EncryptPid(Int32.Parse(Eval("PId").ToString())) %>',0,<%#Eval("PMediaKind") %>);" src="Images/mediatype/<%#MOD.WebUtility.WebHelper.GetMediaType(int.Parse(Eval("PMediaKind").ToString()))%>" alt="" />
                        <a href="ProgramInfo.aspx?pid=<%#Eval("PId")%>"><%#this.SubMixText(Eval("PName").ToString(), 16,"...")%> </a></th></tr>               
                        <tr><td><%=this.GetRes("INFO_PROGRAM_LENGTH")%>:<span class="movie"> <%#Eval("nTime") %></span></td></tr>
                        <tr><td><%=this.GetRes("INFO_PROGRAM_POINT")%>: <span class="movie"><%#Eval("PPoint") %></span></td></tr>
                        <tr><td><%=this.GetRes("INFO_PROGRAM_VIEW")%>: <span class="movie"><%#Eval("PReadCount") %></span></td></tr>                   
                        
                    </table>
                </td>
           </tr>
        </table>			            
        </div>
        </ItemTemplate>
         </asp:Repeater>
                
    </div>    
</asp:Content>

