<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLink.aspx.cs" Inherits="mentougou.AddLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        *{ font-size:12px; margin:0;}
       body {background-color:#f5f5f5}
       input.txt {width:440px;}
       textarea.txtarea { width:440px;height:100px;}
       table    { width:516px;border-collapse:collapse; margin:20px auto; text-align:center; }
       table td {height:30px;}
       table td.w1{ width:76px;}
       table td.w2{ width:440px;}
       table td.w3{ width:516px; text-align:right;}
       .tips { color:red; float:left; padding-left:76px;}
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table><tbody>
            <tr><td class="w1"><%=this.GetRes("Info_LinkName")%>:</td><td class="w2">
                <asp:TextBox CssClass="txt" ID="tbName" runat="server"></asp:TextBox></td></tr>
            <tr><td class="w1"><%=this.GetRes("Info_LinkHref")%>:</td><td class="w2">
                <asp:TextBox ID="tbInfo" CssClass="txt" runat="server">http://</asp:TextBox></td></tr>
            <tr><td colspan="2" class="w3">
                <asp:Label ID="lblError" CssClass="tips" runat="server" Text=""></asp:Label><asp:ImageButton ID="ibtnAdd" runat="server" OnClick="ibtnAdd_Click"/></td></tr>
    </tbody></table>
    </form>
</body>
</html>