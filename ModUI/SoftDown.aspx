<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftDown.aspx.cs" Inherits="MOD.UI.SoftDown" %>
<%@ Register Src="UserControls/UC_Footer.ascx" TagName="Footer" TagPrefix="UC" %>
<%@ Register Src="UserControls/UC_Toper.ascx" TagName="Toper" TagPrefix="UC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <link rel="stylesheet" href="Style/default.css" type="text/css"/>       
    <title><%=this.GetRes("INFO_SOFTDOWN") %></title>
    <script type="text/javascript" src="Scripts/prototype.js"></script>
    <script type="text/javascript" src="Scripts/mod.js"></script>
</head>
<body>
    <form id="form1" runat="server">        
        <div id="wrapper">            
          <div id="toper">
            <div id="logo"><img src="Images/depend/softdown_logo.gif" style="border-width:0px;" /></div>
             <asp:Literal ID="ltrSetting" runat="server"></asp:Literal>
        </div>    
        <dl id="naver"><dd class="w1"></dd>
            <dd class="w2"></dd>
        <dd class="w3"></dd></dl>
        <dl id="softdown">
            <dd class="row1"></dd>
             <dd class="row2">
                <ul>
                    <li class="w1"><img src="Images/nodepend/m_icon_sd_dx.gif" alt="" /></li>
                    <li class="w2">
                        <h3><img src="Images/nodepend/m_star.gif" alt="" />DirectX9 </h3>
                        <p><%=this.GetRes("Info_Directx")%><span><a href="Manager/Setup/DirectX9.exe"><img src="Images/depend/btn_down.gif" alt="" /></a></span></p>
                    </li>
                    <li class="w3"></li>
                    <li class="w1"><img src="Images/nodepend/m_icon_sd_1.gif" alt="" /></li>
                    <li class="w2">
                        <h3><img src="Images/nodepend/m_star.gif" alt="" /><%=this.GetRes("Info_Miniplayer")%></h3>
                        <p> <script type="text/javascript" language="JavaScript">GetVersion(3,'<%=Session["MPVer"]%> ')</script>  <br />
                            <%=this.GetRes("Info_MiniplayerIntro") %>
                            <span><a href="Manager/Setup/MiniPlayer.exe"><img src="Images/depend/btn_down.gif" alt="" /></a></span>
                        </p>
                    </li>
                    <asp:Literal ID="ltrSoftManager" runat="server"></asp:Literal>
                </ul>
             </dd>
            <dd class="row3"></dd>
        </dl>
          <div id="btmer"></div>
            <div id="footer"><%=string.Format(this.GetRes("COPYRIGHT"),DateTime.Now.Year)%></div>
        </div>
    </form>
</body>
</html>