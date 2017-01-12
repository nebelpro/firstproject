<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SysSetSystem.ascx.cs" Inherits="MOD.Admin.UserControls.UC_SysSetSystem" %>

<div class="rRow">
<h3><%=GetRes("Info_SysVisitor")%></h3>
    <ul class="visitSet">
        <li><input id="chkSet" type="checkbox" <%=MOD.Admin.Helper.IsSetVisiter() %> onclick="sysset.SetDefaultVisiter();" />
            <%=GetRes("Info_SysVisitorSetDefault") %></li>       
        <li><select class="sel" id="selUid" <%=MOD.Admin.Helper.UserIsDisabled() %> >
            <option value="0"><%=GetRes("Info_SysVisitorTip") %></option>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                <option value="<%#Eval("Key")%>" <%#MOD.Admin.Helper.UserSelected(int.Parse(Eval("Key").ToString())) %>   > <%#Eval("Value") %></option>    
                </ItemTemplate>
            </asp:Repeater>
        
        </select></li>       
        <li class="txtRight"><input type="button" class="btn" onclick="sysset.SaveDefaultVisiter();" value="<%=GetRes("Oper_SysSave") %>" /></li>
    </ul>
</div>

<div class="rRow">
<h3><%=GetRes("Info_SysSystem") %></h3>
    <ul class="sysSet">
        <li class="hidden"><input type="checkbox" id="chkShowLogin" <%=MOD.Admin.Helper.ShowLoginIsDisabled() %>  <%=MOD.Admin.Helper.IsShowLogin() %> />
            <%=GetRes("Info_SysShowLogin") %></li>
        <li><label><%=GetRes("Info_SysAllowReg") %>:</label><input type="checkbox" id="chkAllowReg" <%=MOD.Admin.Helper.IsAllowReg() %> /></li>
        <li><label><%=GetRes("Info_SysAllowRemark") %>:</label><input type="checkbox" id="chkAllowRemark" <%=MOD.Admin.Helper.IsAllowRemark() %> /></li>
        <li><label> <%=GetRes("Info_SysDefaultOrder") %>:</label>
            <select class="sel" id="selDefaultSort" name="selDefaultSort">
              <option value="0" <%=MOD.Admin.Helper.SortSelected(0) %>><%=GetRes("Info_ProgramOrderByAddTimeDesc") %></option>
	          <option value="1" <%=MOD.Admin.Helper.SortSelected(1) %>><%=GetRes("Info_ProgramOrderByAddTimeAsc")%></option>
              <option value="2" <%=MOD.Admin.Helper.SortSelected(2) %>><%=GetRes("Info_ProgmraOrderByReadCountDesc") %></option>
	          <option value="3" <%=MOD.Admin.Helper.SortSelected(3) %>><%=GetRes("Info_ProgmraOrderByReadCountAsc")%></option>	          
	          <option value="4" <%=MOD.Admin.Helper.SortSelected(4) %>><%=GetRes("Info_ProgramOrderByTimeDesc") %></option>          
	          <option value="5" <%=MOD.Admin.Helper.SortSelected(5) %>><%=GetRes("Info_ProgramOrderByTimeAsc")%></option>
	          <option value="6" <%=MOD.Admin.Helper.SortSelected(6) %>><%=GetRes("Info_ProgramOrderByNameDesc") %></option>
	          <option value="7" <%=MOD.Admin.Helper.SortSelected(7) %>><%=GetRes("Info_ProgramOrderByNameAsc")%></option>	          
          </select> 
        </li>
        <li><label><%=GetRes("Info_SysViewSet") %>:</label>
           <select class="sel" name="selVM" id="selVM">
	            <option value="1" <%=MOD.Admin.Helper.ViewModelSelected(1) %>><%=GetRes("Info_SysViewDetail") %></option>
	            <option value="2" <%=MOD.Admin.Helper.ViewModelSelected(2) %>><%=GetRes("Info_SysViewList") %></option>	           
           </select>                  
        </li>
        <li><label><%=GetRes("Info_DefaultSort") %>:</label>
            <select class="sel" name="selCatalog" id="selCatalog">
                <asp:Repeater ID="rptCatalog" runat="server">
                    <ItemTemplate>
                        <option value="<%#Eval("CId")%>" <%#MOD.Admin.Helper.CatalogSelected(int.Parse(Eval("CId").ToString()))%>><%#Eval("CName")%></option>
                    </ItemTemplate>
                    
                </asp:Repeater>
                <asp:Literal ID="ltrCatalog" runat="server"></asp:Literal>
            </select>
        </li>
        <li><label><%=GetRes("Info_SysFreeTime") %>:</label>
        <input type="text" id="txtMaxfree" class="txt" value="<%=MOD.WebUtility.WebHelper.GetSession(MOD.BLL.SETTING_TYPE.KEY_FREETIME,0) %>"  />
            <%=GetRes("Info_SysMinute") %> </li>
            
        
        <li class="txtRight"><input type="button"  class="btn" onclick="sysset.SaveSysSet();" value="<%=GetRes("Oper_SysSave") %>" /></li>
        
    </ul>
</div>
