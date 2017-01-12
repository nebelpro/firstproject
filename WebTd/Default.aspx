<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MOD.WebTd.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <script type="text/javascript" src="Scripts/prototype.js"></script>
    <script type="text/javascript" src="Scripts/mod.js"></script>
    <title></title>
</head>
<body onload="MyOnload('<%=strGoUrl%>','<%=Session["MPVer"]%>','<%=this.GetRes("Warn_IE_55") %>');">    
</body>
</html>
