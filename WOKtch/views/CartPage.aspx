<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="WOKtch.views.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Cart Detail</h2>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <div>
        <asp:GridView ID="cartDetail" runat="server" OnDataBound="cartDetail_DataBound" OnRowCommand="cartDetail_RowCommand" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="productName" HeaderText="Watch Name" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="price" HeaderText="Price" />
                <asp:ImageField DataImageUrlField="pictureUrl" DataImageUrlFormatString="~/Assets/ProductPhotos/{0}" ControlStyle-Width="100" ControlStyle-Height = "100"  HeaderText = "Watch Picture" />
                <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Delete" CommandArgument='<%# Eval("CartId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="checkOutBtn" runat="server" Text="Check Out" OnClick="checkOutBtn_Click"/>
    </div>
</asp:Content>
