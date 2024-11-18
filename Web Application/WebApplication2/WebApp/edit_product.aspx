<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="edit_product.aspx.cs" Inherits="WebApp.edit_product" %>

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
                <h2 class="form-name">Edit Product</h2>
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
                        <input type="text" name="category" id="category" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="allergies">Allergies</label>
                        <input type="text" name="allergies" id="allergies" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="price">Price</label>
                        <input type="text" name="price" runat="server" id="price">
                    </div>
                    <div class="input-field single">
                        <label for="active">Active</label>
                        <select name="active" runat="server" id="active">
                            <option value="true">Available</option>
                            <option value="false">Unavailable</option>
                        </select>
                    </div>
                    <div class="input-field single">
                        <label id="lblerror" runat="server" for="error" visible="false"></label>
                    </div>
                    <asp:Button ID="editProd" Enabled="false" runat="server" Text="Edit Product" OnClick="editProd_Click"/>
                    <asp:Button ID="manageBusinesess" Enabled="true" runat="server" Text="Manage Businesess" OnClick="manageBusinesess_Click"/>
                    <asp:Button ID="manageProducts" Enabled="true" runat="server" Text="Manage Products" OnClick="manageProducts_Click"/>
                </div>
            </div>
        </div>
    </div>
</main>
</asp:Content>
