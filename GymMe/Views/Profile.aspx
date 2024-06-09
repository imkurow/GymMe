<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GymMe.Views.Profile" %>

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
            <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelUsernameError" runat="server" Text=""></asp:Label>
        </div>

        <div>
             <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
             <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelEmailError" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="DropDownListGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="LabelGenderError" runat="server" Text=""></asp:Label>
        </div>
        <div>
             <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth: "></asp:Label>
            <asp:Label ID="LabelDOBData" runat="server" Text=""></asp:Label>
            <asp:Calendar ID="CalendarDOB" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="LabelDOBError" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
        <div>
            <div>
                 <asp:Label ID="LabelPassword" runat="server" Text="New Password"></asp:Label>
                 <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="LabelPasswordError" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="LabelPassword2" runat="server" Text="Old Password"></asp:Label>
                <asp:TextBox ID="TextBoxPassword2" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="LabelPassword2Error" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="ButtonChangePassword" runat="server" Text="Change Password" OnClick="ButtonChangePassword_Click" />
        </div>
    </form>
</body>
</html>
