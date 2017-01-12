<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GroupAdd.ascx.cs" Inherits="MOD.Admin.UserControls.UC_GroupAdd" %>
<div class="rRow">
  <h3><%=GetRes("Info_GroupInfo")%></h3>
  <form id="formGroup" action="">
  <table class="GroupInfo">
    <tr><td class="w1"><%=GetRes("Info_GroupName")%>:</td><td class="w2"><input type="text" id="txtGroupName" class="txt" /></td></tr>
    <tr><td class="w1"><%=GetRes("Info_GroupClass")%>:</td><td class="w2"><input type="text" value="0" id="txtGroupClass" class="txt" />0-255</td></tr>
    <tr><td class="w1" style=" vertical-align:top;"><%=GetRes("Info_GroupPermit")%>:</td>
        <td class="w2"><ul>
        <li><input type="checkbox" id="chkLogin" value="<%=MOD.BLL.PERMIT_TYPE.per_g_login %>" />
            <%=GetRes("Per_Login")%></li>       
        <li><input type="checkbox" id="chkUserCourse" value="<%=MOD.BLL.PERMIT_TYPE.per_g_mycourse %>"/>
            <%=GetRes("Per_MyCourse")%></li>
        <li><input type="checkbox" id="chkProgram" onclick="chkAllSingle('chkProgram','chkProgramItem');" />
            <%=GetRes("Per_Program")%>
           <ul>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_find %>" />
                  <%=GetRes("Per_Find")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_play %>" />
                  <%=GetRes("Per_Play")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_mngprogram %>" />
                  <%=GetRes("Per_ProgramMng")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_sys_catalog_mng %>" />
                  <%=GetRes("Per_CatalogMng")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_subtocheck %>" />
                  <%=GetRes("Per_SubToCheck")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_auditing %>" />
                  <%=GetRes("Per_Auditing")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_media_down %>" />
                  <%=GetRes("Per_MediaDown")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_free_audit %>" />
                  <%=GetRes("Per_FreeAudit")%></li>
             <li><input type="checkbox" onclick="ChkSub('chkProgram');" name="chkProgramItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_export_info %>" />
                  <%=GetRes("Per_ExportInfo")%></li>
           </ul>
        </li>
        <li><input type="checkbox" id="chkCast" onclick="chkAllSingle('chkCast','chkCastItem');" />
            <%=GetRes("Per_Channel")%>
          <ul>
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_set_channel %>" />
               <%=GetRes("Per_SetChannel")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_channel_recive %>" />
               <%=GetRes("Per_ChannelReceive")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_channel_play %>" />
               <%=GetRes("Per_ChannelPlay")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_live_record %>" />
               <%=GetRes("Per_LiveRecord")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_player_record %>" />
               <%=GetRes("Per_PlayerRecord")%></li>            
            <li><input type="checkbox" onclick="ChkSub('chkCast');" name="chkCastItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_weige%>" />
               <%=GetRes("Per_WeigeClass")%></li>
          </ul>
        </li>
        <li><input type="checkbox" id="chkSys" onclick="chkAllSingle('chkSys','chkSysItem');" />
            <%=GetRes("Per_SomeManager")%>
          <ul>
            <li><input type="checkbox" onclick="ChkSub('chkSys');" name="chkSysItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_sys_user_mng %>" />
               <%=GetRes("Per_UserMng")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkSys');" name="chkSysItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_sys_montior %>" />
               <%=GetRes("Per_SysMontior")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkSys');" name="chkSysItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_bulletin_mng %>" />
               <%=GetRes("Per_BulletinMng")%></li>
            <li><input type="checkbox" onclick="ChkSub('chkSys');" name="chkSysItem" value="<%=MOD.BLL.PERMIT_TYPE.per_g_sys_rate_mng %>" />
               <%=GetRes("Per_RateMng")%></li>            
          </ul>
        </li>
      </ul></td>
    </tr>
    <tr><td class="w1"><%=GetRes("Info_GroupIntro")%>:</td><td class="w2"><input type="text" id="txtGroupInfo" class="txt" /></td></tr>
    <tr><td class="w1"></td>
        <td class="w2"><input type="button"  class="btn" value="<%=GetRes("Oper_Submit")%>" onclick="scroll(0,0);group.Update(0);" /> 
      <input  class="btn" type="reset"value="<%=GetRes("Oper_Reset")%>" /></td>
    </tr>    
  </table>  
  </form>
</div>