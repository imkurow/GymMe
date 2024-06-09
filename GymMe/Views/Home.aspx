<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GymMe.Views.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Data"></asp:Label>
        </div>
        <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserDOB" HeaderText="DOB" SortExpression="UserDOB" />
            </Columns>

        </asp:GridView>
        <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav</asp:LinkButton>
    </form>
</body>
</html>
