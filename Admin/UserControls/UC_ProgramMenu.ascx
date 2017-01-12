<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ProgramMenu.ascx.cs" Inherits="MOD.Admin.UserControls.UC_ProgramMenu" %>
   <div class="lRow">
     <h3><%=GetRes("Info_ProgramMng") %></h3>
      <ul id="leftNav">
         <li><a href="javascript://"  onclick="catalog.GetList(0);"><%=GetRes("Info_ProgramCatalogMng")%></a></li>  
         <li><a href="javascript://" onclick="program.RemarkMng(1);"><%=GetRes("Info_RemarkMng")%></a></li>
         <li><a href="javascript://" onclick="program.GetListByCatalog(1,-2);"><%=GetRes("Info_ProgramAll")%></a></li>
         <li><a href="javascript://" onclick="program.GetListByCatalog(1,-1);"><%=GetRes("Info_ProgramInCatalog")%></a></li>
         <li><a href="javascript://" onclick="program.GetListByCatalog(1,0);"><%=GetRes("Info_ProgramNoCatalog")%></a></li>
         <li><a href="javascript://" onclick="program.GetListByRecommend(1)"><%=GetRes("Info_ProgramRecommend")%></a></li>
         <li><a href="javascript://"  onclick="program.GetListNotChecked(1);"><%=GetRes("Info_ProgramNoChecked")%></a></li>         
      </ul>     
   </div> 
   
    <div class="lRow">
        <h3>
            <%=GetRes("Info_ProgramCatalogTree")%></h3>
        <div  id="catalogTree">
           <asp:Literal ID="ltrCatalogTree" runat="server"></asp:Literal>
        </div>
        
    </div>
   
  <div class="lRow txtCenter">
        <h3>
            <%=GetRes("Info_ProgramSearch") %></h3>
            <p id="pSearch"> 
               <input type="text" class="txt" id="txtKey" />
               <input type="button" class="btn" onclick="program.GetListBySearch(1,6);" value="<%=GetRes("Oper_Search")%>" />
            </p>
    </div> 