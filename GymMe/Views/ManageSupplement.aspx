<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="GymMe.Views.ManageSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav</asp:LinkButton>
        <div>
            <asp:LinkButton ID="LinkButtonInsertSup" runat="server" OnClick="LinkButtonInsertSup_Click">Insert Supplement</asp:LinkButton>
        </div>
        <div>
            <asp:LinkButton ID="LinkButtonUpdateSup" runat="server">Update Supplement</asp:LinkButton>
        </div>
    </form>
</body>
</html>
