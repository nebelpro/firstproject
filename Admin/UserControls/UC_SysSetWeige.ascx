<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SysSetWeige.ascx.cs" Inherits="MOD.Admin.UserControls.UC_SysSetWeige" %>
<div class="rRow">
  <h3><%=this.GetRes("Info_SysSetWeige")%></h3>
  <table id="WeigeView">
    <tr><td class="w1"><%=GetRes("Info_WeigeSort")%>:</td>
            <td class="w2"><select class="sel" id="sltWgSort" >
                <option <%=MOD.Admin.Helper.WeigeSortSelected(0)%> value="0"><%=GetRes("Info_WeigeSortByNameDesc")%></option>
                <option <%=MOD.Admin.Helper.WeigeSortSelected(1)%> value="1"><%=GetRes("Info_WeigeSortByNameAsc")%></option>
                <option <%=MOD.Admin.Helper.WeigeSortSelected(2)%> value="2"><%=GetRes("Info_WeigeSortByBeginTimeDesc")%></option>
                <option <%=MOD.Admin.Helper.WeigeSortSelected(3)%> value="3"><%=GetRes("Info_WeigeSortByBeginTimeAsc")%></option>
            </select></td></tr>
    <tr><td class="w1"><%=this.GetRes("Info_WeigeView")%>:</td>
    <td class="w2">
        <select class="sel" id="sltWgView"  onchange="sysset.ShowWeige(this);">
            <option <%=MOD.Admin.Helper.WeigeViewSelected(0) %> value="0"><%=GetRes("Info_WeigeView1")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(1) %> value="1"><%=GetRes("Info_WeigeView2")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(2) %> value="2"><%=GetRes("Info_WeigeView3")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(3) %> value="3"><%=GetRes("Info_WeigeView4")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(4) %> value="4"><%=GetRes("Info_WeigeView5")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(5) %> value="5"><%=GetRes("Info_WeigeView6")%></option>
            <option <%=MOD.Admin.Helper.WeigeViewSelected(6) %> value="6"><%=GetRes("Info_WeigeView7")%></option>
        </select>
        <img id="imgWg" src="Images/nodepend/wg_v<%=Session[MOD.BLL.SETTING_TYPE.KEY_WEIGE_VIEW]%>.gif" alt=""/>
    </td></tr>
    <tr><td class="wgBtn" colspan="2"> <input type="button"  class="btn" onclick="sysset.SaveWeige();"  value="<%=GetRes("Oper_SysSave") %>" /></td></tr>  
  </table>
</div>
