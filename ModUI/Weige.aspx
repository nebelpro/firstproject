<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weige.aspx.cs" Inherits="MOD.UI.Weige" %>
<%@ Register TagName="Footer" TagPrefix="UC" Src="UserControls/UC_Footer.ascx"  %>
<%@ Register TagName="Toper"  TagPrefix="UC" Src="UserControls/UC_Toper.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <link rel="stylesheet" href="Style/public.css" type="text/css"/>   
    <link rel="stylesheet" href="Style/master.css" type="text/css"/>   
    <link rel="stylesheet" href="Style/makeup.css" type="text/css"/>            
    <script type="text/javascript" src="Scripts/prototype.js"></script>            
    <script type="text/javascript" src="Scripts/mod.js"></script> 
    <title></title>  
    <style type="text/css">
    #mpArea{ width:1000px; margin:5px auto;}
    div.sp  { width:1000px;margin:0 0 5px 0;height:12px; background:#fff;
					 	border-top: 1px solid #9dbabe;border-bottom: 1px solid #9dbabe;}
	#mpArea table{}	
	#mpArea table td{ background:#000; border:1px solid #fff; text-align:center; color:#fff;}			 	
					 	
    #view12 {width:1000px; margin:0 auto;}					 	
    #view12 td{width:248px;height:160px;}
    #view12 .player{width:248px;height:155px; border:0;}
    
    #view4{width:1000px}
    #view4 td{width:498px;height:320px;}
    #view4 .player{width:498px;height:310px;}
    
    #view6one{width:1000px;}
    #view6one td{width:333px;height:240px;}
    #view6one .player{width:333px;height:230px;}    
 
    #view6two{width:1000px;}
    #view6two td.big{}
    #view6two td.normal{width:333px;height:240px;}   
    #view6two td.normal .player{width:333px;height:230px;}
    #view6two td.big .player{width:666px;height:450px;}    
    
    #view9{width:1000px;}
    #view9 td{width:333px;height:240px;}
    #view9 .player{width:333px;height:230px;}
    
    #view16 {width:1000px;}	
    #view16 td{width:248px;height:160px;}
    #view16 .player{width:248px;height:155px;}
    
    #view13 {width:1000px; margin:0 auto;}	  			 	
    #view13 td.big{}
    #view13 td.normal{width:248px;height:160px;}
    #view13 td.big .player{width:496px;height:310px;}
    #view13  td.normal .player{width:248px;height:155px;}   
    
    
    #sltView span{ width:48px;text-align:right;  color:red;}
    
    </style>
      
</head>
<body>
    <form id="form1" runat="server">        
        <div id="wrapper">            
            <UC:Toper id="Toper1" runat="server"/>            
            <div id="primary">
            <div class="sp"></div>
                <div>
                    <select id="sltView" onchange="ShowWeige();">                        
                        <option <%=MOD.UI.Helper.WeigeViewSelected(0) %> value="0"><%=GetRes("Info_WeigeView1")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(1) %> value="1"><%=GetRes("Info_WeigeView2")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(2) %> value="2"><%=GetRes("Info_WeigeView3")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(3) %> value="3"><%=GetRes("Info_WeigeView4")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(4) %> value="4"><%=GetRes("Info_WeigeView5")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(5) %> value="5"><%=GetRes("Info_WeigeView6")%></option>
                        <option <%=MOD.UI.Helper.WeigeViewSelected(6) %> value="6"><%=GetRes("Info_WeigeView7")%></option>
                    </select>
                    <select id="sltSort" onchange="ShowWeige();">
                        <option <%=MOD.UI.Helper.WeigeSortSelected(0)%> value="0"><%=GetRes("Info_WeigeSortByNameDesc")%></option>
                        <option <%=MOD.UI.Helper.WeigeSortSelected(1)%> value="1"><%=GetRes("Info_WeigeSortByNameAsc")%></option>
                        <option <%=MOD.UI.Helper.WeigeSortSelected(2)%> value="2"><%=GetRes("Info_WeigeSortByBeginTimeDesc")%></option>
                        <option <%=MOD.UI.Helper.WeigeSortSelected(3)%> value="3"><%=GetRes("Info_WeigeSortByBeginTimeAsc")%></option>
                    </select>
                </div>
                <div id="mpArea"></div>
            </div>  
            <UC:Footer id="UC_Footer1" runat="server"/>           
        </div>
       
    </form>
</body>
</html>
<script type="text/javascript">
    gHomeIp='<%=Session["HSServer"]%>';
    gHomePort='<%=Session["HSPort"]%>';
    strParam="<%=MOD.WebUtility.ChannelHelper.GetWeigeUI()%>";
    window.onload=function(){
        Live_Load(<%=this.GetSession(MOD.BLL.SETTING_TYPE.KEY_WEIGE_VIEW,2)%>);
    }
    window.onunload=Live_Unload;
</script>

