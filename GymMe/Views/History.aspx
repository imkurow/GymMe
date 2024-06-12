<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="GymMe.Views.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav </asp:LinkButton>
   
        </div>
        <div>
            <asp:Panel ID="CustomerChoice" runat="server" Visible="false">
                <asp:GridView ID="GridViewCustomer" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged" >

                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                        <asp:BoundField DataField="Status" HeaderText="Transaction Status" SortExpression="Status" />
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Details" ShowHeader="True" Text="Detail" />
                    </Columns>


                </asp:GridView>
            </asp:Panel>

            <asp:Panel ID="AdminChoice" runat="server" Visible="false">
                             <asp:GridView ID="GridViewAdmin" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged" >

                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                        <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                        <asp:BoundField DataField="TransactionStatus" HeaderText="Transaction Status" SortExpression="Status" />
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Details" ShowHeader="True" Text="Detail" />
                    </Columns>


                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
