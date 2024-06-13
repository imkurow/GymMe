<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GymMe.Views.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButtonBack" runat="server" OnClick="LinkButtonBack_Click">Back</asp:LinkButton>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Your Cart: "></asp:Label>
        <div>
            <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SuplementName" HeaderText="Supplement Name" SortExpression="SuplementName" />
                    <asp:BoundField DataField="OrderQuantity" HeaderText="Quantity" SortExpression="OrderQuantity" />
                </Columns>

            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="ButtonClearCart" runat="server" Text="Clear Cart " OnClick="ButtonClearCart_Click"/>
            <asp:Button ID="ButtonCheckout" runat="server" Text="Checkout" OnClick="ButtonCheckout_Click" />
        </div>
    </form>
</body>
</html>
