<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="_findText" runat="server"></asp:TextBox>
            <asp:Button ID="_find" runat="server" Width="90" Text="查询" OnClick="Find_Click" />
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th></th>
                            <th>编号</th>
                            <th>姓名</th>
                            <th>年龄</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="cbSelected" CommandArgument='<%#Eval("_id")%>' OnCheckedChanged="Checked_Change" />
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltlid"></asp:Literal></td>
                        <td>
                            <asp:Literal runat="server" ID="ltlName"></asp:Literal></td>
                        <td>
                            <asp:Literal runat="server" ID="ltlAge"></asp:Literal></td>
                        <td>
                            <asp:LinkButton runat="server" ID="lbtnDetail" CommandArgument='<%#Eval("_id")%>' CommandName="Detail">详情</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Button ID="_first" runat="server" Width="70" Text="第一页" OnClick="Page_Click" />

            <asp:Button ID="_before" runat="server" Width="70" Text="上一页" OnClick="Page_Click" />

            <asp:Button ID="_next" runat="server" Width="70" Text="下一页" OnClick="Page_Click" />

            <asp:Button ID="_last" runat="server" Width="70" Text="最后一页" OnClick="Page_Click" />
        </div>
        <div>
            <asp:Button ID="_add" runat="server" Width="70" Text="增加" OnClick="Add_Click" />

            <asp:Button ID="_delete" runat="server" Width="70" Text="删除" OnClick="Delete_Click" />

            <asp:Button ID="_update" runat="server" Width="70" Text="修改" OnClick="Update_Click" />

            <asp:Button ID="_close" runat="server" Width="70" Text="退出" OnClick="Close_Click" />
        </div>

        
    </form>
</body>
</html>
