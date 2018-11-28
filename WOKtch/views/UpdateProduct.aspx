<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="WOKtch.views.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Product</h2>
    <div>
        Watch Name : <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        <br />
        Price : <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
        <br />
        Stock : <asp:TextBox ID="stockTxt" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        Watch Picture : <asp:FileUpload ID="pictureUrl" runat="server" />
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="updateBtn" runat="server" Text="Submit" OnClick="updateBtn_Click"/>
    </div>
</asp:Content>
