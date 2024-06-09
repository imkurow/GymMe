<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GymMe.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
             <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
             <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelPasswordError" runat="server" Text=""></asp:Label>
        </div>

        <div>
             <asp:Label ID="LabelPassword2" runat="server" Text="Password Confirmation"></asp:Label>
             <asp:TextBox ID="TextBoxPassword2" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelPassword2Error" runat="server" Text=""></asp:Label>
        </div>

        <div>
             <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="CalendarDOB" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="LabelDOBError" runat="server" Text=""></asp:Label>
        </div>
            <asp:LinkButton ID="LinkButtonLogin" runat="server" OnClick="LinkButtonLogin_Click">Login Button</asp:LinkButton>
        <div>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
        </div>
    </form>
</body>
</html>
