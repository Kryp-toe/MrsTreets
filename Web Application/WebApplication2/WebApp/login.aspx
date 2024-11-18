<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Login</title>
    <link rel="stylesheet" href="registration.css">
    <link rel="stylesheet" href="login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="content">
        <div class="form-content">
            <div class="form">
                <h2 class="form-name">Welcome</h2>
                <div>
                    <div class="input-field">
                        <label for="email">Email</label>&nbsp;
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="John@Doe" required=""></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="password">Password</label>&nbsp;
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Your Password" type="password" required=""></asp:TextBox>
                    </div>
                    <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>
                    <asp:Button class="next-btn" ID="btnLogIn" runat="server" Text="Login" OnClick="BtnLogIn_Click" />
                    <a class="forgot-password" href="forgotPassword.aspx">Forgot password?</a>
                </div>
            </div>
        </div>
        <div class="login-picture" >
            <p class="copywrite">Log in to explore your favorites and discover new local delights.
                <br>
                <br>
                "No ada way"
            </p>
        </div>
    </main>

</asp:Content>
