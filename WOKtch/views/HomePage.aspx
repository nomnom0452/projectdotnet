<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WOKtch.views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Homepage</h2>
    <div>
        <h2>Top Product</h2>
        <asp:Button ID="productBtn" runat="server" Text="View All Product" OnClick="productBtn_Click"/>
        <br />
        <asp:ListView ID="topProductLV" runat="server">
            <ItemTemplate>
                <br />
                <asp:Image ID="images" ImageUrl ='<%# "~/Assets/ProductPhotos/" + Eval("ProductPicture") %>' Width="200px" Height="200px" runat="server" />
                <h3><%# Eval("ProductName") %></h3>
                <h3><%# "Rp. " + Eval("ProductPrice") %></h3>
                <br />
            </ItemTemplate>
        </asp:ListView>
        <br />
    </div>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
