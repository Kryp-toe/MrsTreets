<%@ Page Title="MrS Treets - Restaurant Listings" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApp.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="catalogue.css" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <!-- Search and Filter Section -->
        <div class="utilities">
            <!-- Search Boxes -->
            <div class="search-boxes">
<%--                <div class="search-box-1">
                    <input type="text" ID="food" placeholder="Search food" runat="server">
                    <asp:TextBox ID="txtSearch" runat="server" placeholder="Search food"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="🔎︎" OnClick="btnSearch_Click" />
                </div>--%>
            <div style="display:flex; align-items:center; width:100%; margin-top:20px;">
    <asp:TextBox ID="txtSearchLocation" runat="server" placeholder="Search Location" 
                 style="flex:1; padding:12px 20px; border:1px solid #ccc; border-radius:5px 0 0 5px; outline:none;">
    </asp:TextBox>
    <asp:Button ID="btnSeacrchLocation" runat="server" Text="⮚" OnClick="btnSearchLocation_Click" 
                style="padding:12px 20px; background-color: var(--yellow); color:white; border-radius:0 5px 5px 0; border:none; cursor:pointer; font-weight:bold;"/>
</div>


            <%--<div class="filters">
                <div class="tab-filters">
                    <asp:Button ID="btnSortCafe" runat="server" Text="Cafes" CssClass="filter-btn active" OnClick="btnSortCafe_Click" />
                    <asp:Button ID="btnSortBakery" runat="server" Text="Bakeries" CssClass="filter-btn active" OnClick="btnSortBakery_Click" />
                    <asp:Button ID="btnSortResturant" runat="server" Text="Resturants" CssClass="filter-btn active" OnClick="btnSortResturant_Click" />
                </div>
                <div class="dropdown">
                    <button onclick="myFunction()" class="dropbtn">Sort by <i class="fa-solid fa-angle-down"></i></button>

                </div>
            </div>--%>

            <!-- Icon Filters (Food Categories) -->
        </div>

        <!-- Restaurant Listings Section -->
        <div class="inventory" runat="server" id="divRestarauntConainer">
        </div>
    </main>

</asp:Content>
