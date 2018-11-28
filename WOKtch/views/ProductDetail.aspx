<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="WOKtch.views.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Product Detail</h2>
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <asp:Image ID="Image1" ImageUrl='<%# "~/Assets/ProductPhotos/" + Eval("ProductPicture") %>' runat="server" />
                <h3><%# Eval("ProductName") %></h3>
                <h3><%# Eval("ProductStock") + "Unit(s) Available" %></h3>
                <h3><%# "Rp. " + Eval("ProductPrice") %></h3>
            </ItemTemplate>
        </asp:FormView>
    </div>

    <div runat="server" id="reviewDiv">
        <h2>Give Rating and Review</h2>
        Rating : <asp:TextBox ID="ratingTxt" runat="server"></asp:TextBox>
        <br />
        Review Description : <asp:TextBox ID="reviewDescTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Label ID="errorLb" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="postBtn" runat="server" Text="Post" OnClick="postBtn_Click" />
    </div>

    <div>
        <h2>Rating and Review</h2>
        
        <asp:ListView ID="reviewList" runat="server">
            <ItemTemplate>
                <h3><%# Eval("MemberName") %></h3>
                <h4>Rating : <%# Eval("ReviewRating") + " out of 5" %></h4>
                <p>Review : <%# Eval("ReviewDescription") %></p>
                <asp:Button ID="updateBtn" runat="server" Text="Update" Visible='<%# IsMember((int)Eval("ReviewId")) %>' CommandName="updateBtn" CommandArgument='<%# Eval("ReviewId") %>' />
                <asp:Button ID="deleteBtn" runat="server" Text="Delete" Visible='<%# IsMember((int)Eval("ReviewId")) %>' CommandName="deleteBtn" CommandArgument='<%# Eval("ReviewId") %>' />
                <br />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
