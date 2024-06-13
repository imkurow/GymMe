<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="GymMe.Views.TransactionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButtonNav" runat="server" OnClick="LinkButtonNav_Click">Nav</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButtonBack" runat="server" OnClick="LinkButtonBack_Click">Back</asp:LinkButton>    
        </div>
        <div>
    
                
                <asp:GridView ID="GridViewDetail" runat="server" AutoGenerateColumns="False">

                    <Columns>
    
                        <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                        <asp:BoundField DataField="TransactionStatus" HeaderText="Transaction Status" SortExpression="Status" />
                        <asp:BoundField DataField="SuplementName" HeaderText="Supplement Name" SortExpression="SuplementName" />
                        <asp:BoundField DataField="SuplementPrice" HeaderText="Price" SortExpression="SuplementPrice" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

                    </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
