<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="WebApp.admin_login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="business-login.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="content">
        <div class="form-content">
            <div class="form">
                <h2 class="form-name">Welcome</h2>
                <div>
                    <div class="input-field">
                        <label for="mail">Email</label>&nbsp;
                        <asp:TextBox ID="Email" runat="server" type="text" name="Email" placeholder="Enter your email" required></asp:TextBox>
               
                        </div>
                    <div class="input-field">
                        <label for="password">Password</label>&nbsp;
                      <br />
                        <asp:TextBox ID="Password" runat="server" type="password" name="password" placeholder="Enter your password" required></asp:TextBox> 
                        <asp:Button class="next-btn" type="button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign In" />
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    </div>
                    </div>
            </div>
        </div>
    </main>

</asp:Content>
