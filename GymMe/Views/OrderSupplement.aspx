<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="GymMe.Views.OrderSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav</asp:LinkButton>
        </div>

        <asp:Label ID="Label1" runat="server" Text="Existing Supplement: "></asp:Label>
        <div>
            <asp:GridView ID="GridViewSupplement" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SuplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                    <asp:BoundField DataField="SuplementPrice" HeaderText="Supplement Price" SortExpression="SupplementPrice" />
                    <asp:BoundField DataField="SuplementExpiryDate" HeaderText="Expiry Date" SortExpression="SuplementExpiryDate" />
                    <asp:BoundField DataField="SuplementTypeName" HeaderText="Supplement Type" SortExpression="SuplementTypeName" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="LabelSupplement" runat="server" Text="Supplement Name: "></asp:Label>
            <asp:DropDownList ID="DropDownListSupName" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="LabelQuantity" runat="server" Text="Quantity: "></asp:Label>
            <asp:TextBox ID="TextBoxQuantity" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelQuantityError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonOrder" runat="server" Text="Order" OnClick="ButtonOrder_Click" />
        </div>
        <div>
            <asp:LinkButton ID="LinkButtonCart" runat="server" OnClick="LinkButtonCart_Click">Cart</asp:LinkButton>
        </div>
    </form>
</body>
</html>
