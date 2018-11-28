<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="ViewMember.aspx.cs" Inherits="WOKtch.views.ViewMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Member Details</h2>
    <div>
        <asp:GridView ID="memberDetail" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField ="MemberEmail" HeaderText="Email" />
                <asp:BoundField DataField ="MemberName" HeaderText="Name" />
                <asp:BoundField DataField ="MemberGender" HeaderText="Gender" />
                <asp:BoundField DataField ="MemberDoB" HeaderText="Birth Date" />
                <asp:ImageField DataImageUrlField="MemberProfilePicture" DataImageUrlFormatString="~/Assets/MemberPhotos/{0}" ControlStyle-Width="100" ControlStyle-Height = "100"  HeaderText = "Profile Picture" />
                <asp:BoundField DataField ="MemberPhoneNumber" HeaderText="Phone Number" />
                <asp:BoundField DataField ="MemberAddress" HeaderText="Address" />
                <asp:BoundField DataField ="MemberRole" HeaderText="Role" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="changeRoleBtn" runat="server" Text=" Change Role to Admin" Visible='<%# IsMember((string)Eval("MemberEmail")) %>' CommandName="changeRoleBtn" CommandArgument='<%# Eval("MemberEmail") %>' />
                        <asp:Button ID="deleteBtn" runat="server" Text="Delete Member" CommandName="deleteMemberBtn" CommandArgument='<%# Eval("MemberEmail") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
