<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="manage_businesses.aspx.cs" Inherits="WebApp.manage_businesses" %>

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
            <i class="bi bi-bell"></i>
            <i class="bi bi-person-circle"></i>
        </nav>
        <div class="content">
            <h1 class="heading">My Restaurants</h1>

            <asp:Button ID="Button1" runat="server" Text="+Add a restaurant" class="add-restaurant" OnClick="Button1_Click"/>
          
            <div class="restaurant-list" id="restaurantList" runat="server">
                <%--<div class="restaurant">
                    <div class="restaurant-img"></div>
                    <div class="res-name">
                        <h3 class="restaurant-name">Njabulo's Store</h3>
                        <p class="address">56 Richmond Avenue</p>
                    </div>
                    <p id="rest-desc" class="restaurant-description">So good so nice Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nihil </p>
                    <p class="orders">Orders <br> <span>48</span></p>
                    <p class="sales">Sales <br> <span>R14, 983</span></p>
                    <div class="crud-btn">
                        <button class="delete-rest"><i class="bi bi-x-lg"></i></button>
                        <button class="edit-rest"><i class="bi bi-pencil"></i></button>
                    </div>
                </div>--%>
            </div>

        </div>
    </main>

    

</asp:Content>
