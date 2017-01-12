<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReg.aspx.cs" Inherits="MOD.UI.UserReg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <link rel="stylesheet" href="style/pop.css" type="text/css" media="screen" />
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1"  runat="server">     
        <div id="userreg">
            <table>
                <tr>
                    <td class="strtd">
                        <%=this.GetRes("REG_LOGIN")%>
                    </td>
                    <td class="intd">
                        <asp:TextBox ID="tbRegMask" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="strtd">
                        <%=this.GetRes("REG_USERNAME")%>
                    </td>
                    <td class="intd">
                        <asp:TextBox ID="tbRegName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="strtd">
                        <%=this.GetRes("REG_PWD")%>
                    </td>
                    <td class="intd">
                       <asp:TextBox ID="tbRegPwd" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="strtd">
                        <%=this.GetRes("REG_CONFIRM")%>
                    </td>
                    <td class="intd">
                        <asp:TextBox ID="tbConfirm" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 24px;">
                    <td class="strtd">
                        <%=this.GetRes("REG_INFO")%>
                    </td>
                    <td class="intd">
                        <asp:TextBox
                            ID="tbRegInfo" Columns="10" Rows="3" style="border:1px;" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="strtd">
                    </td>
                    <td class="intd" style=" text-align:right;">                       
                            <asp:ImageButton ID="ibtnAdd" ImageUrl="Images/depend/m_button_reg.gif" style="width: 74px;
                            height: 23px; border: 0px;" runat="server" OnClick="ibtnAdd_Click" />
                    </td>
                </tr>
            </table>

</div>

    
    
    
  
 
</form>
</body>
</html>