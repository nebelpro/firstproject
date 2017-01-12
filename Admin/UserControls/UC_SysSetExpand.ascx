<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SysSetExpand.ascx.cs" Inherits="MOD.Admin.UserControls.UC_SysSetExpand" %>
<div class="rRow">
    <h3><%=GetRes("Info_SysSetExpand")%></h3>
    <dl class="expand">
    <dd>
        <h4>
            <%=GetRes("Info_SysExpandOne") %></h4>
       <asp:Literal ID="ltrFuncImg1" runat="server"></asp:Literal>        
        <ul>
            <li><label><%=GetRes("Info_SysExpandName") %>:</label><asp:Literal ID="ltrName1" runat="server"></asp:Literal></li>           
            <li><label><%=GetRes("Info_SysExpandLink") %>:</label><asp:Literal ID="ltrLink1" runat="server"></asp:Literal></li>
            <li><label><%=GetRes("Info_SysExpandIcon") %>:</label><select class="sel" id="selImg1" onchange="sysset.ShowImage(this,1);">
                  <option value="m_top_icon_1.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_1.gif",1) %> >m_top_icon_1.gif</option>
                  <option value="m_top_icon_2.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_2.gif",1) %> >m_top_icon_2.gif</option>
                  <option value="m_top_icon_3.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_3.gif",1) %>>m_top_icon_3.gif</option>
                  <option value="m_top_icon_4.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_4.gif",1) %>>m_top_icon_4.gif</option>
                  <option value="m_top_icon_5.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_5.gif",1) %>>m_top_icon_5.gif</option>
                  <option value="m_top_icon_6.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_6.gif",1) %>>m_top_icon_6.gif</option>
                  <option value="m_top_icon_7.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_7.gif",1) %>>m_top_icon_7.gif</option>
                  <option value="m_top_icon_8.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_8.gif",1) %>>m_top_icon_8.gif</option>
                    
                </select>
            </li>
        </ul>
    </dd>
    <dd>
        <h4>
            <%=GetRes("Info_SysExpandTwo")%></h4>
      <asp:Literal ID="ltrFuncImg2" runat="server"></asp:Literal>    
        <ul>
            <li><label><%=GetRes("Info_SysExpandName")%>:</label><asp:Literal ID="ltrName2" runat="server"></asp:Literal></li>
            <li><label><%=GetRes("Info_SysExpandLink")%>:</label><asp:Literal ID="ltrLink2" runat="server"></asp:Literal></li>
            <li><label><%=GetRes("Info_SysExpandIcon")%>:</label><select class="sel" id="selImg2" onchange="sysset.ShowImage(this,2);">
                  <option value="m_top_icon_1.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_1.gif",2) %>>m_top_icon_1.gif</option>
                  <option value="m_top_icon_2.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_2.gif",2) %>>m_top_icon_2.gif</option>
                  <option value="m_top_icon_3.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_3.gif",2) %>>m_top_icon_3.gif</option>
                  <option value="m_top_icon_4.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_4.gif",2) %>>m_top_icon_4.gif</option>
                  <option value="m_top_icon_5.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_5.gif",2) %>>m_top_icon_5.gif</option>
                  <option value="m_top_icon_6.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_6.gif",2) %>>m_top_icon_6.gif</option>
                  <option value="m_top_icon_7.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_7.gif",2) %>>m_top_icon_7.gif</option>
                  <option value="m_top_icon_8.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_8.gif",2) %>>m_top_icon_8.gif</option>
                    
                </select>
            </li>
        </ul>
   </dd>
   <dd>
        <h4><%=GetRes("Info_SysExpandThree")%></h4>
      <asp:Literal ID="ltrFuncImg3" runat="server"></asp:Literal>        
        <ul>           
            <li><label><%=GetRes("Info_SysExpandName")%>:</label><asp:Literal ID="ltrName3" runat="server"></asp:Literal></li>
            <li><label><%=GetRes("Info_SysExpandLink")%>:</label><asp:Literal ID="ltrLink3" runat="server"></asp:Literal></li>
            <li><label><%=GetRes("Info_SysExpandIcon")%>:</label><select class="sel" id="selImg3" onchange="sysset.ShowImage(this,3);">
                  <option value="m_top_icon_1.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_1.gif",3) %>>m_top_icon_1.gif</option>
                  <option value="m_top_icon_2.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_2.gif",3) %>>m_top_icon_2.gif</option>
                  <option value="m_top_icon_3.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_3.gif",3) %>>m_top_icon_3.gif</option>
                  <option value="m_top_icon_4.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_4.gif",3) %>>m_top_icon_4.gif</option>
                  <option value="m_top_icon_5.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_5.gif",3) %>>m_top_icon_5.gif</option>
                  <option value="m_top_icon_6.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_6.gif",3) %>>m_top_icon_6.gif</option>
                  <option value="m_top_icon_7.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_7.gif",3) %>>m_top_icon_7.gif</option>
                  <option value="m_top_icon_8.gif" <%=MOD.Admin.Helper.FuncImgSelected("m_top_icon_8.gif",3) %>>m_top_icon_8.gif</option>
                    
                </select>
            </li>
        </ul>
    </dd>
    <dd class="txtRight"><input type="button" onclick="sysset.SaveExpandSet();"  class="btn" value="<%=GetRes("Oper_SysSave") %>" /></dd>
    
    </dl>
</div>