<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigation.aspx.cs" Inherits="GymMe.Views.Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="CustomerChoice" runat="server" Visible="false">
                <asp:Label ID="Label1" runat="server" Text="Order Suplement"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="History"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="AdminChoice" runat="server" Visible="false">
                <asp:LinkButton ID="LinkButtonHome" runat="server" OnClick="LinkButtonHome_Click">Home</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonManageSup" runat="server" OnClick="LinkButtonManageSup_Click">Manage Supplement</asp:LinkButton>
                <asp:Label ID="Label7" runat="server" Text="Order Queue"></asp:Label> 
                <asp:Label ID="Label9" runat="server" Text="Transaction Report"></asp:Label>
            </asp:Panel>
            <asp:LinkButton ID="LinkButtonProfile" runat="server" OnClick="LinkButtonProfile_Click">Profile </asp:LinkButton>
            <asp:LinkButton ID="LinkButtonLogout" runat="server" OnClick="LinkButtonLogout_Click">Logout</asp:LinkButton>
        </div>
    </form>
</body>
</html>
