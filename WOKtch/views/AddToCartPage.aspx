<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="AddToCartPage.aspx.cs" Inherits="WOKtch.views.AddToCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add to Cart</h2>
    <div>
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <h3><%# Eval("ProductName") %></h3>
                <h3><%# Eval("ProductStock")  + "Unit(s) Available" %></h3>
            </ItemTemplate>
        </asp:FormView>
        Quantity : <asp:TextBox ID="quantityTxt" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click"/>
    </div>
</asp:Content>
