<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionQueue.aspx.cs" Inherits="GymMe.Views.TransactionQueue" %>

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
             <asp:GridView ID="GridViewQueue" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewQueue_SelectedIndexChanged">

     <Columns>
    
         <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
         <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
         <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
         <asp:BoundField DataField="TransactionStatus" HeaderText="Transaction Status" SortExpression="Status" />
         <asp:BoundField DataField="SuplementName" HeaderText="Supplement Name" SortExpression="SuplementName" />
         <asp:BoundField DataField="SuplementPrice" HeaderText="Price" SortExpression="SuplementPrice" />
         <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

         <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Handle" ShowHeader="True" Text="Handle Transaction" />

     </Columns>
 </asp:GridView>
        </div>
    </form>
</body>
</html>
