<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WOKtch.views.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Product</h2>
    <div>
        Watch Name : <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        <br />
        Watch Price : <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
        <br />
        Watch Stock : <asp:TextBox ID="stockTxt" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        Watch Picture : <asp:FileUpload ID="pictureUrl" runat="server" />
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click"/>
    </div>
</asp:Content>
