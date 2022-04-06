<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_page.aspx.cs" Inherits="Register.Item_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 586px;
        }
        .auto-style4 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
            <asp:Image ID="Img_item" runat="server" Height="16px" />
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="LB_user" runat="server" Text="User"></asp:Label>
                        <br />
                        <asp:LinkButton ID="HLB_profile" runat="server" OnClick="HLB_profile_Click">Shopping cart</asp:LinkButton>
                    </td>
                </tr>
            </table>
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
        <p class="auto-style1">
            <asp:Button ID="BT_buy" runat="server" OnClick="BT_buy_Click" Text="Buy" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Quantity:"></asp:Label>
            <asp:TextBox ID="TB_amount" runat="server" Width="28px"></asp:TextBox>
        </p>
        <p class="auto-style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_amount" ErrorMessage="Specify quantity!" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p class="auto-style1">
            <asp:RangeValidator ID="RV_amount" runat="server" ControlToValidate="TB_amount" ErrorMessage="Invalid amount!" ForeColor="Red" MinimumValue="1"></asp:RangeValidator>
        </p>
        <p class="auto-style1">
            &nbsp;</p>
    </form>
</body>
</html>
