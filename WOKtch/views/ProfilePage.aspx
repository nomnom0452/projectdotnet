<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="WOKtch.views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:FormView ID="memberProfileF" runat="server">
            <ItemTemplate>
                <h3>Name : <%# Eval("MemberName") %></h3>
                <h3>Email : <%# Eval("MemberEmail") %></h3>
                <h3>Gender : <%# Eval("MemberGender") %></h3>
                <h3>Birth Date : <%# Eval("MemberDoB") %></h3>
                <h3>Phone Number : <%# Eval("MemberPhoneNumber") %></h3>
                <h3>Address : <%# Eval("MemberAddress") %></h3>
                <h3>Role : <%# Eval("MemberRole") %></h3>
            </ItemTemplate>
        </asp:FormView>
        <asp:Button ID="changePasswordBtn" runat="server" Text="Change Password"  OnClick="changePasswordBtn_Click" />
    </div>
</asp:Content>
