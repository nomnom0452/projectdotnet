<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WOKtch.views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login Page</h2>
    <div>
        Email : <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        Password : <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:CheckBox ID="rememberCheck" runat="server" /> Remember Me
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="LoginBtn" runat="server" Text="Log in"  OnClick="LoginBtn_Click"/>
    </div>
</asp:Content>
