<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApp.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="checkout.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Header ends -->
     <main>
         <%--<h1>Your  </h1>--%>
         <asp:Literal ID="CartHeading" runat="server"></asp:Literal>
         <div class="checkout-list">
           
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <input type="text" name="coupon" id="couponText" runat="server">
             <asp:Button ID="btncoupon" runat="server" Text="Apply Coupon" OnClick="btncoupon_Click" style="display:inline-block; padding:10px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;"/>
        </div>

         <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
         <asp:Button ID="shop" runat="server" Text="Continue Shopping" OnClick="shop_Click" style="display:inline-block; padding:10px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;"/>
         <asp:Button ID="checkout" runat="server" Text="Checkout" OnClick="checkout_Click" style="display:inline-block; padding:10px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;"/>
     </main>

</asp:Content>
