<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="WOKtch.views.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Page</h2>
    <div>
        <asp:GridView ID="adminTransactionView" runat="server" OnRowCommand="adminTransactionView_RowCommand" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="memberEmail" HeaderText="Member Id" />
                <asp:BoundField DataField="memberName" HeaderText="Member Name" />
                <asp:BoundField DataField="transactionId" HeaderText="Transaction Id" />
                <asp:BoundField DataField="transactionDate" HeaderText="Transaction Date" />
                <asp:BoundField DataField="transactionStatus" HeaderText="Transaction Status" />
                <asp:BoundField DataField="productId" HeaderText="Watch Id" />
                <asp:BoundField DataField="productName" HeaderText="Watch Name" />
                <asp:BoundField DataField="productQuantity" HeaderText="Quantity" />
                <asp:BoundField DataField="productPrice" HeaderText="Watch Price" />
                <asp:BoundField DataField="subtotal" HeaderText="Sub Total" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Change Status" CommandArgument='<%# Eval("transactionId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="memberTransactionView" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="transactionId" HeaderText="Transaction Id" />
                <asp:BoundField DataField="transactionDate" HeaderText="Transaction Date" />
                <asp:BoundField DataField="transactionStatus" HeaderText="Transaction Status" />
                <asp:BoundField DataField="productId" HeaderText="Watch Id" />
                <asp:BoundField DataField="productName" HeaderText="Watch Name" />
                <asp:BoundField DataField="productQuantity" HeaderText="Quantity" />
                <asp:BoundField DataField="productPrice" HeaderText="Watch Price" />
                <asp:BoundField DataField="subtotal" HeaderText="Sub Total" />
            </Columns>
        </asp:GridView>


        <asp:Button ID="reportTransaction" runat="server" Text="Generate Transaction Report" OnClick="reportTransaction_Click"/>
    </div>
</asp:Content>
