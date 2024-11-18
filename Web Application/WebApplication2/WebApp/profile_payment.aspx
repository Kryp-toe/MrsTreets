<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="profile_payment.aspx.cs" Inherits="WebApp.profile_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap"
        rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lobster&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css"
        integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="master.css">
    <link rel="stylesheet" href="profile.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <h1>My Profile</h1>
        <div class="tabs">
            <div class="profile-picture">
                <div class="picture">
                    <img src="icons/profile icons/default user.svg" alt="">
                </div>
                <form id="profilePicForm" method="post" enctype="multipart/form-data">
                    <input type="file" name="profilePicture" id="profilePicture" accept="image/*" />
                    <button type="submit">Update Profile Picture</button>
                </form>
            </div>
            <div class="tab-links">
                <a href="profile_information.aspx" class="tab-link information-tab">
                    <div class="icon">
                        <img src="icons/profile icons/User.svg" alt="">
                    </div>
                    <p class="tab-name">Information</p>
                </a>
                <a href="#" class="tab-link security-tab">
                    <div class="icon">
                        <img src="icons/profile icons/Lock.svg" alt="">
                    </div>
                    <p class="tab-name">Security</p>
                </a>
                <a href="profile_address.aspx" class="tab-link address-tab">
                    <div class="icon">
                        <img src="icons/profile icons/Map pin.svg" alt="">
                    </div>
                    <p class="tab-name">Address</p>
                </a>
                <a href="profile_payment.aspx" class="tab-link active payment-tab">
                    <div class="icon">
                        <img src="icons/profile icons/Dollar sign.svg" alt="">
                    </div>
                    <p class="tab-name">Payment</p>
                </a>
            </div>
        </div>
        <div class="profile-details">
            <p class="link-name">Payment</p>
            <div class="details">
                <p>You don't have a payment method yet</p>
            </div>
            <div class="button">
                <button class="save-btn">Save Payment Method</button>
            </div>
        </div>
    </main>

</asp:Content>
