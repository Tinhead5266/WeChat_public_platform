<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeChat_public_platform_test.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbToken" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetToken" runat="server" Text="获取微信Access_token" OnClick="btnGetToken_Click" />
            <br />
            <asp:TextBox ID="tbTemplateId" runat="server">Rs60eausLlPJCEOFspw0H6bFCAOVG5Tczs50tYqzevs</asp:TextBox>
            <asp:Button ID="btnSendTemplateMessage" runat="server" Text="发送模板消息调用" OnClick="btnSendTemplateMessage_Click" />
            <br />
            <asp:TextBox ID="tbCreateMenuJson" runat="server" Width="500px" Height="500px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btnCreateMenu" runat="server" Text="创建自定义菜单" OnClick="btnCreateMenu_Click" />
            <br />
            <asp:Button ID="btGetAllBatchgetMaterial" runat="server" Text="获取所有素材" OnClick="btGetAllBatchgetMaterial_Click" />
            <br />
            <asp:TextBox ID="tbAllBatchgetMaterialJson" runat="server" Width="500px" Height="500px" TextMode="MultiLine"></asp:TextBox>
            <br />
        </div>

        <%--        <div>
            <input type="text" id="tbxName" runat="server" />
            <input type="text" id="tbxPass" value="" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <input id="hiddenTest" type="hidden" value="<%= GetToken() %>" name="hiddenTestN" />
        </div>--%>
    </form>
</body>
</html>
