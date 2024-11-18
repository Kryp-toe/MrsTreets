<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="WebApp.forgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="login.css" />
    
    <style>label[for="email"] {
        font-family: 'Montserrat', sans-serif; /* Use the Montserrat font */
        font-size: 16px; /* Set a clear font size */
        color: #333; /* Dark gray for text color */
        margin-bottom: 8px; /* Adds spacing below the label */
        display: inline-block; /* Ensures that margin and padding work correctly */
        font-weight: 600; /* Make the label text bold */
    }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="content">
    <div class="form-content">
        <h2 class="form-name">Verify Credentials</h2>
        <!-- Box containing all elements -->
        <div class="form" style="border: 2px solid #ccc; padding: 20px;">
                <!-- Email Input -->
                <div class="input-field" id="emailInpt" style="margin-bottom: 15px;" runat="server">
                    <label for="email">Enter your email</label>&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                </div>

                <!-- Verify Email Button -->
                <div style="margin-bottom: 15px;" id="verifyEmail" runat="server">
                    <asp:Button ID="btnVerifyEmail" runat="server" Text="Verify Email" OnClick="BtnVerifyEmail_Click" />
                </div>

                <!-- Message Label -->
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                <!-- Password Reset Section (initially hidden) -->
                <div id="passwordResetSection" visible="false" runat="server" style="margin-top: 20px;">
                    <div class="input-field">
                        <label for="newPassword">Enter New Password</label>&nbsp;
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="confirmPassword">Confirm New Password</label>&nbsp;
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>

                    <!-- Reset Password Button -->
                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" OnClick="BtnResetPassword_Click" />
                </div>
        </div>
    </div>
</main>


</asp:Content>
