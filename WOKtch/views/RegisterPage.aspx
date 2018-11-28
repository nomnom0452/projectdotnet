<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="WOKtch.views.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register Page</h2>
    <div>
        Name :<asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        <br />
        Email :<asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        Password :<asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Confirm Password : <asp:TextBox ID="repasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Gender :
        <asp:RadioButton ID="maleRb" runat="server" GroupName="gender" />Male
        <asp:RadioButton ID="femaleRb" runat="server" GroupName="gender"/>Female
        <br />
        Birth Date :<asp:TextBox ID="dobTxt" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        Profile Picture :<asp:FileUpload ID="pictureUrl" runat="server" />
        <br />
        Phone Number :<asp:TextBox ID="phoneNumberTxt" runat="server" TextMode="Phone"></asp:TextBox>
        <br />
        Address :<asp:TextBox ID="addressTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click"/>
    </div>
</asp:Content>
