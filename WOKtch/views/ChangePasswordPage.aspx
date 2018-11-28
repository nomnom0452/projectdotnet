<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="WOKtch.views.ChangePasswordPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Change Password</h2>
    <div>
        Old Password : <asp:TextBox ID="oldPassTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        New Password : <asp:TextBox ID="newPassTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Confirm Password :<asp:TextBox ID="rePassTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="submit" runat="server" Text="Change Password" OnClick="submit_Click" />
    </div>
</asp:Content>
