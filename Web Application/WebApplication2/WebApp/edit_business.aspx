<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="edit_business.aspx.cs" Inherits="WebApp.edit_business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="add_resturant.css">
    <link rel="stylesheet" href="dashboard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
    <nav class="navbar">
            <div class="logo">
                <img class="logo-img" src="icons/Other/Aunt J.svg" alt="" srcset="">
                <h2 class="logo-txt">MrS Treets</h2>
            </div>
            <i class="bi bi-person-circle"></i>
        </nav>
    <div class="content">
        <div class="form-content">
            <div class="form">
                <h2 class="form-name">Edit Business</h2>
                <div>
                    <div class="input-field single">
                        <label for="business">Business Name</label>
                        <input type="text" name="business" id="name" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="business">Business Description</label>
                        <input type="text" name="business" id="description" runat="server" required>
                    </div>
                    <div class="input-field single">
                        <label for="address1">Address Line 1</label>
                        <input type="text" name="address1" id="address1" runat="server" placeholder="Eg. 145 Star Street" required>
                    </div>
                    <div class="input-field single">
                        <label for="address2">Address Line 2</label>
                        <input type="text" name="address2" id="address2" runat="server" placeholder="Eg. Vosloorus Ext 31" required>
                    </div>
                    <div class="double-input">
                        <div class="input-field">
                            <label for="suburb">Suburb</label>
                            <input type="text" name="suburb" id="suburb" runat="server" placeholder="Boksburg" required>
                        </div>
                        <div class="input-field">
                            <label for="city">City</label>
                            <input type="text" name="city" id="city" runat="server" placeholder="Johannesburg" required>
                        </div>
                    </div>
                    <div class="double-input">
                        <div class="input-field">
                            <label for="province">Province</label>
                            <select name="province" runat="server" id="province" required>
                                <option value="Gauteng">Gauteng</option>
                                <option value="Free State">Free State</option>
                                <option value="Limpopo">Limpopo</option>
                                <option value="Kwa-Zulu Natal">Kwa-Zulu Natal</option>
                                <option value="Eastern Cape">Eastern Cape</option>
                                <option value="Western Cape">Western Cape</option>
                                <option value="North West">North West</option>
                                <option value="Mpumalanga">Mpumalanga</option>
                            </select>
                        </div>
                        <div class="input-field">
                            <label for="postal">Postal Code</label>
                            <input type="text" name="postal" id="postal" runat="server" placeholder="1467" required>
                        </div>
                    </div>
                    <div class="input-field single">
                        <label for="image">Add Restaurant Hero</label>
                        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" />
                    </div>
                    <div class="input-field single">
                        <label for="active">Active</label>
                        <select name="active" runat="server" id="active">
                            <option value="true">Available</option>
                            <option value="false">Unavailable</option>
                        </select>
                    </div>
                    <div class="input-field single">
                        <label id="lblerror" runat="server" for="error" visible="false"></label>
                    </div>
                    <asp:Button class="next-btn" ID="editBus" Enabled="true" runat="server" Text="Submit Changes" OnClick="editBus_Click"/>
                </div>
            </div>
        </div>
    </div>
    </main>
</asp:Content>
