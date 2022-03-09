<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 362px;
        }
        .auto-style2 {
            width: 291px;
            text-align: right;
        }
        .auto-style4 {
            text-align: left;
            width: 288px;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style9 {
            width: 291px;
            text-align: right;
            height: 33px;
        }
        .auto-style10 {
            text-align: center;
            width: 288px;
            height: 33px;
        }
        .auto-style11 {
            text-align: left;
            height: 33px;
        }
        .auto-style13 {
            text-align: center;
            width: 288px;
            height: 77px;
        }
        .auto-style15 {
            width: 291px;
            text-align: right;
            height: 48px;
        }
        .auto-style16 {
            text-align: left;
            width: 288px;
            height: 48px;
        }
        .auto-style17 {
            text-align: left;
            height: 48px;
        }
        .auto-style18 {
            width: 291px;
            text-align: right;
            height: 77px;
        }
        .auto-style19 {
            text-align: left;
            height: 77px;
        }
    </style>
</head>
<body>
        <div class="auto-style7">
            Registration</div>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Username</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_uname" runat="server" Width="268px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_uname" ErrorMessage="Username is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_uname" ErrorMessage="Must be between 4 and 40 characters!" ForeColor="Red" ValidationExpression="^[\s\S]{4,40}$"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_pass1" runat="server" TextMode="Password" Width="268px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_pass1" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TB_pass1" ErrorMessage="Must be between 4 and 40 characters!" ForeColor="Red" ValidationExpression="^[\s\S]{4,40}$"></asp:RegularExpressionValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Confirm password</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TB_pass2" runat="server" TextMode="Password" Width="268px"></asp:TextBox>
                </td>
                <td class="auto-style17">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_pass2" ErrorMessage="You must repeat the password!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_pass1" ControlToValidate="TB_pass2" ErrorMessage="Does not match password!" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TB_mail" runat="server" Width="268px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TB_mail" ErrorMessage="Email is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_mail" ErrorMessage="Not a valid email!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="auto-style13">                    
                    <BotDetect:WebFormsCaptcha ID="Captcha_box" 
                            runat="server" Width="293px" />
                    <asp:textbox ID="TB_captcha" runat="server"></asp:textbox>
                </td>
                <td class="auto-style19">
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10">
                    <asp:Button ID="B_reg" runat="server" OnClick="B_reg_Click" Text="Register" />
                </td>
                <td class="auto-style11">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
                    <br />
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
