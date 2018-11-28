<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="UpdateReview.aspx.cs" Inherits="WOKtch.views.UpdateReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Review</h2>
    <div>
        Rating : <asp:TextBox ID="ratingTxt" runat="server"></asp:TextBox>
        <br />
        Review : <asp:TextBox ID="reviewTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="submit" runat="server" Text="Update" OnClick="submit_Click" />
    </div>
</asp:Content>
