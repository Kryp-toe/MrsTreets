<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="manage_products.aspx.cs" Inherits="WebApp.manage_products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="dashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       
    <main>
        <nav class="navbar">
            <div class="logo">
                <img class="logo-img" src="icons/Other/Aunt J.svg" alt="" srcset="">
                <h2 class="logo-txt">MrS Treets</h2>
            </div>
            <i class="bi bi-person-circle"></i>
        </nav>
        <div class="content">
<%--            <select name="restaurant" id="restaurant" class="restaurant-select" runat="server">
                <option value="Njabulo Store">Njabulo Store</option>
            </select>--%>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="restaurant-select" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>

            <div class="buttons">
                <%--<div class="search-box">
                    <input type="text" id="search">
                    <i class="fa-solid fa-magnifying-glass"></i>
                </div>--%>
                <asp:Button ID="AddItem" runat="server" Text="+ Add a product" CssClass="add-item" OnClick="AddItem_Click" />
                <%--<button class="add-item"><i class="bi bi-plus"></i> Add a product</button>--%>
            </div>
            <div class="menu-list" id="menuList" runat="server">
                <%--<div class="item">
                        <h3 class="item-name">Muffin</h3>
                        <p class="description">56 Richmond Avenue</p>
                        <p class="price">R48</p>
                        <div class="crud-btn-menu">
                            <button class="delete-rest"><i class="bi bi-x-lg"></i></button>
                            <button class="edit-rest"><i class="bi bi-pencil"></i></button>
                        </div>
                </div>--%>
               
               
            </div>
        </div>
    </main>
    
</asp:Content>