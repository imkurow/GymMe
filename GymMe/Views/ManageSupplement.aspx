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
            <asp:GridView ID="GridViewSup" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewSup_RowDeleting" OnSelectedIndexChanged="GridViewSup_SelectedIndexChanged" OnRowEditing="GridViewSup_RowEditing">
                <Columns>
                    <asp:BoundField DataField="SuplementID" HeaderText="Supplement ID" SortExpression="SuplementID"/>
                    <asp:BoundField DataField="SuplementName" HeaderText="Supplement Name" SortExpression="SuplementName" />
                    <asp:BoundField DataField="SuplementExpiryDate" HeaderText="Expiry Date" SortExpression="SuplementExpiryDate" />
                    <asp:BoundField DataField="SuplementPrice" HeaderText="Price" SortExpression="SuplementPrice" />
                    <asp:BoundField DataField="SuplementTypeName" HeaderText="Suplement Type" SortExpression="SuplementTypeID" />
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Actions" ShowHeader="True" Text="Update" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Actions" ShowHeader="True" Text="Delete" />
                </Columns>

            </asp:GridView>
        </div>
        <div>
            <asp:LinkButton ID="LinkButtonInsertSup" runat="server" OnClick="LinkButtonInsertSup_Click">Insert Supplement</asp:LinkButton>
        </div>
    </form>
</body>
</html>
