<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="GymMe.Views.UpdateSupplement" %>

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
        <div>
            <asp:LinkButton ID="LinkButtonBack" runat="server" OnClick="LinkButtonBack_Click">Back</asp:LinkButton>
        </div>
        <div>
            <asp:Label ID="LabelSupplement" runat="server" Text="Supplement Name: "></asp:Label>
            <asp:TextBox ID="TextBoxSuplement" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelSupError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelExpiry" runat="server" Text="Expiry Date: "></asp:Label>
            <asp:Label ID="LabelExpiryValue" runat="server" Text=""></asp:Label>
            <asp:Calendar ID="CalendarExpiry" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="LabelExpiryError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelPrice" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="TextBoxPrice" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelPriceError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelType" runat="server" Text="Type: "></asp:Label>
            <asp:DropDownList ID="DropDownListType" runat="server"></asp:DropDownList>
        </div>
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
    </form>
</body>
</html>
