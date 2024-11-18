<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="dashboard.css">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <nav class="navbar">
            <div class="logo">
                <img class="logo-img" src="/Customer/Aunt J.svg" alt="" srcset="">
                <h2 class="logo-txt">MrS Treets</h2>
            </div>
            <i class="bi bi-bell"></i>
            <i class="bi bi-person-circle"></i>
        </nav>
        <iframe title="MrsTreetsReport" width="1140" height="100%" 
            src="https://app.powerbi.com/reportEmbed?reportId=d955bd84-61a8-4c9b-9a22-7f8f8d9486cc&autoAuth=true&ctid=d8bf7c18-5725-4b9e-b118-13388f52e44e" 
            frameborder="0" allowFullScreen="true" 
            style="display: block; margin: 0 auto; position: absolute; top: 80%; left: 50%; transform: translate(-50%, -50%);">
        </iframe>
    </main>

</asp:Content>
