<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="WOKtch.views.ProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="addBtn" runat="server" Text="Add Product" OnClick="addBtn_Click"/>
    <br />
    <h2>Product List</h2>

    <asp:listview id="productList" runat="server">
            <ItemTemplate>
                <br />
                <asp:Image ImageUrl ='<%# "~/Assets/ProductPhotos/" + Eval("ProductPicture") %>' Width="200px" Height="200px" runat="server" />
                <h3><%# Eval("ProductName") %></h3>
                <h3><%# Eval("ProductStock") + "Unit(s) Available" %></h3>
                <h3><%# "Rp. " + Eval("ProductPrice") %></h3>
                <asp:Button ID="addCartBtn" runat="server" Text="Add to Cart" Visible='<%# IsMember() %>' CommandName="addCartBtn" CommandArgument='<%# Eval("ProductId") %>' />
                <asp:Button ID="Detail" runat="server" Text="Detail" CommandName="detailBtn" CommandArgument='<%# Eval("ProductId") %>' />
                <asp:Button ID="updateProductBtn" runat="server" Text="Update" CommandName="updateProductBtn" Visible='<%# IsAdmin() %>' CommandArgument='<%# Eval("ProductId") %>' />
                <asp:Button ID="deleteProductBtn" runat="server" Text="Delete" CommandName="deleteProductBtn" Visible='<%# IsAdmin() %>' CommandArgument='<%# Eval("ProductId") %>' />
                <br />
            </ItemTemplate>
     </asp:listview>
</asp:Content>
