<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="WebApp.add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="add_resturant.css">
        <link rel="stylesheet" href="dashboard.css">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

    <nav class="navbar">
            <div class="logo">
                <img class="logo-img" src="icons/Other/Aunt J.svg" alt="" srcset="">
                <h2 class="logo-txt">MrS Treets</h2>
            </div>
            <i class="bi bi-bell"></i>
            <i class="bi bi-person-circle"></i>
        </nav>
    <div class="content">
        <div class="form-content">
            <div class="form">
                <h2 id="title" runat="server" class="form-name">Add a Product</h2>
                <div>
                    <div class="input-field single">
                        <label for="product">Product Name</label>
                        <input type="text" name="business" id="name" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="business">Product Description</label>
                        <input type="text" name="product" id="description" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="category">Category</label>
                        <input type="text" name="category" id="category" runat="server" placeholder="Eg. Drinks" required>
                    </div>
                    <div class="input-field single">
                        <label for="allergies">Allergies</label>
                        <input type="text" name="allergies" id="allergies" runat="server" placeholder="Eg. Nuts, None" required>
                    </div>
                    <div class="input-field single">
                        <label for="price">Price</label>
                        <input type="number" name="image" runat="server" id="price">
                    </div>
                    <div class="input-field single">
                        <label id="lblerror" runat="server" for="error" visible="false"></label>
                    </div>
                    <asp:Button ID="addProd" runat="server" Text="Add Product" OnClick="addProd_Click"/>
                </div>
            </div>
        </div>
    </div>
    </main>
</asp:Content>
