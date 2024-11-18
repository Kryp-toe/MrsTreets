<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="admin_register.aspx.cs" Inherits="WebApp.admin_register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="business-login.css">--%>
    <link rel="stylesheet" href="business-registration.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="form-content">
            <div class="form">
                <h2 class="form-name">Register Your Business</h2>
                <div class="double-input">
                    <div class="input-field">
                        <label for="firstName">First Name</label>
                        <asp:TextBox ID="firstName" runat="server" CssClass="form-control" Placeholder="John" Required="true"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="lastName">Last Name</label>
                        <asp:TextBox ID="lastName" runat="server" CssClass="form-control" Placeholder="Doe" Required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="double-input">
                    <div class="input-field">
                        <label for="phone">Number</label>
                        <asp:TextBox ID="phone" runat="server" CssClass="form-control" Placeholder="087 683 7322" TextMode="Phone" Required="true"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="mail">Email</label>
                        <asp:TextBox ID="mail" runat="server" CssClass="form-control" Placeholder="john@doe.com" TextMode="Email" Required="true"></asp:TextBox>
                    </div>
                     <div class="input-field">
                        <label for="password">Password</label>
                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" Placeholder="password" TextMode="password" Required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="double-input">
                    <div class="input-field">
                        <label for="dob">Date of Birth</label>
                        <asp:TextBox ID="dob" runat="server" CssClass="form-control" TextMode="Date" Required="true"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="gender">Gender</label>
                        <asp:TextBox ID="gender" runat="server" CssClass="form-control" Placeholder="Gender" Required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="input-field single">
                    <label for="address1">Address Line 1</label>
                    <asp:TextBox ID="address1" runat="server" CssClass="form-control" Placeholder="Eg. 145 Star Street" Required="true"></asp:TextBox>
                </div>
                <div class="input-field single">
                    <label for="address2">Address Line 2</label>
                    <asp:TextBox ID="address2" runat="server" CssClass="form-control" Placeholder="Eg. Vosloorus Ext 31" Required="true"></asp:TextBox>
                </div>
                <div class="double-input">
                    <div class="input-field">
                        <label for="suburb">Suburb</label>
                        <asp:TextBox ID="suburb" runat="server" CssClass="form-control" Placeholder="Boksburg" Required="true"></asp:TextBox>
                    </div>
                    <div class="input-field">
                        <label for="city">City</label>
                        <asp:TextBox ID="city" runat="server" CssClass="form-control" Placeholder="Johannesburg" Required="true"></asp:TextBox>
                    </div>
                </div>
                <div class="double-input">
                    <div class="input-field">
                        <label for="province">Province</label>
                        <asp:DropDownList ID="province" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Gauteng" Value="Gauteng"></asp:ListItem>
                            <asp:ListItem Text="Free State" Value="Free State"></asp:ListItem>
                            <asp:ListItem Text="Limpopo" Value="Limpopo"></asp:ListItem>
                            <asp:ListItem Text="Kwa-Zulu Natal" Value="Kwa-Zulu Natal"></asp:ListItem>
                            <asp:ListItem Text="Eastern Cape" Value="Eastern Cape"></asp:ListItem>
                            <asp:ListItem Text="Western Cape" Value="Western Cape"></asp:ListItem>
                            <asp:ListItem Text="North West" Value="North West"></asp:ListItem>
                            <asp:ListItem Text="Mpumalanga" Value="Mpumalanga"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-field">
                        <label for="postal">Postal Code</label>
                        <asp:TextBox ID="postal" runat="server" CssClass="form-control" Placeholder="1467" Required="true"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnRegister" runat="server" CssClass="next-btn" Text="Register" OnClick="btnRegister_Click" />
                <asp:Label ID="lblErr" runat="server" Text="Could not register Owner"></asp:Label>
            </div>
        </div>
        <div class="copywrite">
            <h1>Let's turn your culinary passion into profit</h1>
            <p>Register your business now and start connecting with hungry customers eager to taste your specialties</p>
        </div>
    </main>
</asp:Content>
