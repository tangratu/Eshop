<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_page.aspx.cs" Inherits="Register.User_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            height: 42px;
            text-align: left;
            width: 420px;
        }
        .auto-style4 {
            height: 42px;
            text-align: right;
        }
        .auto-style5 {
            height: 364px;
        }
        .auto-style6 {
            height: 364px;
            text-align: center;
        }
        .auto-style7 {
            height: 364px;
            width: 420px;
        }
        .auto-style8 {
            width: 420px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LB_User" runat="server" Text="User"></asp:Label>
                        <br />
                        <asp:Label ID="LB_Mail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td class="auto-style2"></td>
                    <td class="auto-style4">
                        <asp:Button ID="BT_catalog" runat="server" OnClick="Button1_Click" Text="Back to catalog" />
                        <br />
                        <asp:Button ID="BT_Logout" runat="server" Text="Logout" OnClick="BT_Logout_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style6">
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                            <asp:View ID="View_receipts" runat="server">
                            </asp:View>
                            <asp:View ID="View_cart" runat="server">
                                <asp:GridView runat="server" ID="GV_cart"   AutoGenerateColumns="False" OnRowCommand="GV_cart_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True" EnableTheming="True">  
                <Columns>  
                    <asp:BoundField DataField="name" HeaderText="Name" /> 
                    <asp:BoundField DataField="quantity" HeaderText="Quantity"/>
                    <asp:BoundField DataField="price"  HeaderText="Price" DataFormatString="{0:C}" />                        
                    <asp:ButtonField ButtonType="Button" CommandName="Remove_item" Text="X" />
                </Columns>  
                 <FooterStyle BackColor="White" ForeColor="#000066" />
                 <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                 <RowStyle ForeColor="#000066" />
                 <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#007DBB" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
                                <asp:Label ID="LB_sum" runat="server" Text="Total sum: "></asp:Label>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
