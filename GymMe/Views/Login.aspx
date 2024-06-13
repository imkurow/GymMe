<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GymMe.Views.Login" %>

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
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="LabelPassowordError" runat="server" Text=""></asp:Label>
        </div>
            <div>
                Remember Me
                <asp:CheckBox ID="CheckBoxRemember" runat="server" />
            </div>
        <div>
            Already have account? 
            <asp:LinkButton ID="LinkButtonRegister" runat="server" OnClick="LinkButtonRegister_Click">Register</asp:LinkButton>
        </div>
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
    </form>
</body>
</html>
