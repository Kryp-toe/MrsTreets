<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="profile_information.aspx.cs" Inherits="WebApp.profile_information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="profile.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <h1>My Profile</h1>
        <div class="tabs">

            <div class="tab-links">
                <a href="profile_information.aspx" class="tab-link active information-tab">
                    <div class="icon">
                        <img src="icons/profile icons/User.svg" alt="">
                    </div>
                    <p class="tab-name">Information</p>
                </a>
            </div>
        </div>
        <div class="profile-details">
            <p class="link-name">Personal information</p>
            <div class="details">
                <div class="input">
                    <label for="name">Name</label>
                    <asp:TextBox ID="txtName" PlaceHoolder="Name goes here" runat="server"></asp:TextBox>
                </div>
                <div class="input">
                    <label for="surname">Surname</label>
                    <asp:TextBox ID="txtSurname" PlaceHoolder="Surname goes here" runat="server"></asp:TextBox>
                </div>
                <div class="input">
                    <label for="phone">Phone</label>
                    <asp:TextBox ID="txtPhoneNumber"  runat="server"></asp:TextBox>
                </div>
                <div class="input">
                    <label for="email">Email</label>
                    <asp:TextBox ID="txtEmail" PlaceHoolder="Email goes here" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="button">
                <asp:Button ID="btnSave" runat="server" Text="Save" onClick="btnSave_Click" CssClass="save-btn"/>
            </div>
        </div>
    </main>
</asp:Content>
