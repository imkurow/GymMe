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
                <asp:LinkButton ID="LinkButtonOrderSup" runat="server" OnClick="LinkButtonOrderSup_Click">Order Supplement </asp:LinkButton>
            </asp:Panel>

            <asp:Panel ID="AdminChoice" runat="server" Visible="false">
                <asp:LinkButton ID="LinkButtonManageSup" runat="server" OnClick="LinkButtonManageSup_Click">Manage Supplement </asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButtonTransactionQueue" runat="server" OnClick="LinkButtonTransactionQueue_Click">Transaction Queue </asp:LinkButton> 
                <br />
                <asp:LinkButton ID="LinkButtonTransactionReport" runat="server" OnClick="LinkButtonTransactionReport_Click1">Transaction Report</asp:LinkButton>
                <br />
            </asp:Panel>
            <asp:LinkButton ID="LinkButtonHome" runat="server" OnClick="LinkButtonHome_Click">Home </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButtonHistory" runat="server" OnClick="LinkButtonHistory_Click">History </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButtonProfile" runat="server" OnClick="LinkButtonProfile_Click">Profile </asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButtonLogout" runat="server" OnClick="LinkButtonLogout_Click">Logout</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
