<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApp.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Register</title>
    <link rel="stylesheet" href="registration.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="content">
        <div class="form-content">
            <h1 class="copywrite register_copywrite">Dive in to savor the home grown food experience at your fingertips.</h1>
            <div class="form">
                <h2 class="form-name">Register</h2>
                <div>
                    <div class="input-field">
                        <label for="fullName">Full Name</label>
                        <asp:TextBox ID="txtFullname" CssClass="input" runat="server" placeholder="John Doe" required="required"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="mail">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="input" runat="server" placeholder="John@Doe.com" required="required"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="password">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="input" runat="server" placeholder="Enter your passowrd" required="required"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="dob">Date of Birth</label>
                        <asp:TextBox ID="txtDOB" CssClass="input" runat="server" placeholder="yyyy-mm-dd" required="required"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="number">Number</label>
                        <asp:TextBox ID="txtTel" CssClass="input" runat="server" placeholder="0784541678" required="required"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="gender">Gender</label>
                        <asp:TextBox ID="txtGender" CssClass="input" runat="server" placeholder="Male/Female" required="required"></asp:TextBox>
                    </div>


                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="next-btn" OnClick="btnRegister_Click" />
                    <asp:Label ID="lblErr" runat="server" Text="Unable to register user" Visible="false"></asp:Label>
                    <%-- <p class="tcs">Registering means you trust us with your data—name, email, and cravings. Don’t worry,
                    we don’t share your secrets (or info) with strangers. Your taste buds’ privacy is safe with us!
                    For the nitty-gritty, check out our full Privacy Policy</p> --%>
                </div>
            </div>

        </div>
        <div class="picture-content">
        </div>
    </main>

</asp:Content>
