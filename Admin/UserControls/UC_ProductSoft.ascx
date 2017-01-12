<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProductSoft.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProductSoft" %>
<div class="rRow">
  <h3><%=GetRes("Info_ProductSoft")%></h3>  
  <dl class="productSoft">
    <dd><ul><li class="w1"><img src="Images/nodepend/m_star.gif" alt="" />DirectX9</li><li class="w2"><a href="Setup/DirectX9.exe"><%=this.GetRes("Oper_SoftDown")%></a></li></ul></dd>
    <dd><ul><li class="w1"><img src="Images/nodepend/m_star.gif" alt="" /><%=this.GetRes("Info_Soft_MiniPlayer") %> </li><li class="w2"><a href="Setup/MiniPlayer.exe"><%=this.GetRes("Oper_SoftDown")%></a></li></ul></dd>
    <dd><ul><li class="w1"><img src="Images/nodepend/m_star.gif" alt="" /><%=this.GetRes("Info_Soft_Manager") %> </li><li class="w2"><a href="Setup/Manager.exe"><%=this.GetRes("Oper_SoftDown")%></a></li></ul></dd>
     
  </dl>
  
  
</div>