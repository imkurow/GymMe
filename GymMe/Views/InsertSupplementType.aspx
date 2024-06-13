<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertSupplementType.aspx.cs" Inherits="GymMe.Views.InsertSupplementType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelType" runat="server" Text="Type: "></asp:Label>
            <asp:TextBox ID="TextBoxType" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="ButtonCreate" runat="server" Text="Create" OnClick="ButtonCreate_Click" style="height: 29px" />
    </form>
</body>
</html>
