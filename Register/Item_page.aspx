<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_page.aspx.cs" Inherits="Register.Item_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Image ID="Img_item" runat="server" />
        </div>
        <asp:Label ID="LB_name" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LB_price" runat="server" Font-Italic="True" Font-Size="X-Large" Font-Underline="False" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LB_stock" runat="server" Font-Size="Small" Text="Stock: "></asp:Label>
&nbsp;<asp:Panel ID="Panel1" runat="server" BackColor="Gray">
            <asp:Label ID="LB_desc" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
        </asp:Panel>
        <asp:Button ID="BT_return" runat="server" OnClick="BT_return_Click" Text="Catalog" />
    </form>
</body>
</html>
