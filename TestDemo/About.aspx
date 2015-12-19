<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TestDemo.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label>
            <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="年龄"></asp:Label>
            <asp:TextBox ID="tb_age" runat="server" Style="ime-mode: disabled"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="bt_save" runat="server" Text="修改" Width="70" OnClick="Save_Click" />
            <asp:Button ID="bt_delete" runat="server" Text="删除" Width="70" OnClick="Delete_Click" />
            <asp:Button ID="bt_close" runat="server" Text="关闭" Width="70" OnClick="Close_Click"  />
        </div>
    </form>
</body>
</html>
