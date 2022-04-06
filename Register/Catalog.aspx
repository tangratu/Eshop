<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Register.User" %>

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
            width: 471px;
        }
        .auto-style4 {
            width: 697px;
        }
        .auto-style5 {
            text-align: right;
            width: 557px;
        }
        .auto-style6 {
            width: 513px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style6">&nbsp;</td>
                     <td class="auto-style4">
             <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Catalog of items"></asp:Label>
                     </td>
                     <td class="auto-style5">
                         <asp:Label ID="LB_user" runat="server" Text="User"></asp:Label>
                         <br />
                         <asp:LinkButton ID="HLB_Profile" runat="server" Font-Size="X-Small" OnClick="HLB_Profile_Click">My profile</asp:LinkButton>
                     </td>
                 </tr>
             </table>
        </div>
        <div class="auto-style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
             <asp:GridView runat="server" ID="GV_items"   AutoGenerateColumns="False" OnRowCommand="GV_items_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GV_items_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True" EnableTheming="True" OnSorting="GV_items_Sorting">  
                <Columns>  
                    <asp:BoundField DataField="name" HeaderText="Name" />  
                    <asp:BoundField DataField="price"  HeaderText="Price" DataFormatString="{0:C}" />  
                    <asp:BoundField DataField="stock" HeaderText="Stock" />
                    <asp:ImageField DataImageUrlField="imagepath" ControlStyle-Width="50" ControlStyle-Height="50" HeaderText="Image">
<ControlStyle Height="50px" Width="50px"></ControlStyle>
                    </asp:ImageField>   
                    <asp:ButtonField ButtonType="Button" CommandName="Buy_item" Text="VIEW" />
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
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <br />
    </form>
</body>
</html>
