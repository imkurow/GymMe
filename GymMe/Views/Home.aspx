<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GymMe.Views.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
            <asp:Panel ID="CustomerChoice" runat="server" Visible="false">
                Welcome to GymMe, 
                <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
                <div>
                Role: 
                <asp:Label ID="LabelRole" runat="server" Text=""></asp:Label>

                </div>
            </asp:Panel>
    <asp:Panel ID="AdminChoice" runat="server">
        <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserDOB" HeaderText="DOB" SortExpression="UserDOB" />
            </Columns>

        </asp:GridView>
    </asp:Panel>
        <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav</asp:LinkButton>
    </form>
</body>
</html>
