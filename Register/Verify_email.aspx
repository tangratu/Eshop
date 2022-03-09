<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verify_email.aspx.cs" Inherits="Register.Verify_email" %>

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
            <asp:Label ID="Label1" runat="server" Text="A verification code has been sent to your email, please enter it below"></asp:Label>
            <br />
            <asp:TextBox ID="TB_ver" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BT_ver" runat="server" OnClick="BT_ver_Click" Text="Verify" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BT_resend" runat="server" BorderStyle="Groove" OnClick="BT_resend_Click" Text="Resend code" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return to registration" />
&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
