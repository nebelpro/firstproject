<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinInfo.aspx.cs" Inherits="MOD.UI.BulletinInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=this.GetRes("INFO_BULLETIN_TITLE") %></title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
	<meta http-equiv="Content-Language" content="utf-8"/>
	<style type="text/css">
	*{ word-break:break-all;}
	</style>
	
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 15px;">
            <h3 style="color: #004a9c; font-size: 18px;">
                <asp:Literal ID="ltrName" runat="server"></asp:Literal></h3>
            <p>
                <span style="color: #719675; margin-right: 10px;">
                    <asp:Literal ID="ltrAddTime" runat="server"></asp:Literal>
                </span>
                <asp:Literal ID="ltrUserName" runat="server"></asp:Literal></p>
            <p style="font-size:12px; text-indent:20px; text-align: left;">
                <asp:Literal ID="ltrInfo" runat="server"></asp:Literal></p>
        </div>
        <div style="text-align: center; margin-top: 16px;">
            <input type="button" style="width: 64px; height: 20px; border: 1px solid #cdcdcd;
                background: #ccc;" value="<%=this.GetRes("BTN_CLOSE")%>" onclick="self.window.close();" /></div>
    </form>
</body>
</html>
