<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebApp.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="content" style="padding:20px; background-color:#f8f9fa; border-radius:10px; max-width:800px; margin:auto;">
        <div class="form-content" style="margin-bottom:30px;">
            <div class="form" style="background-color:white; padding:30px; border-radius:10px; box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);">
                <h2 class="form-name" style="text-align:center; color:#333; font-weight:bold; margin-bottom:20px;">Checkout</h2>
                <div>
                    <div class="input-field" style="margin-bottom:20px;">
                        <label id="paymentmethod" for="paymentmethod" runat="server" style="display:block; margin-bottom:10px; color:#333; font-weight:bold;">Payment Method</label>
                        <select id="paymentchoice" runat="server" style="width:100%; padding:10px; border:1px solid #ccc; border-radius:5px;">
                            <option value="card">Card</option>
                            <option value="eft">EFT</option>
                            <option value="instore">In Store</option>
                        </select>
                    </div>
                    <div id="cartsummary" runat="server" style="margin-top:20px; padding:20px; background-color:#fff3cd; border:1px solid #ffeeba; border-radius:5px;">
                        <!-- Order Summary will be populated here -->
                    </div>
                    <asp:Button ID="pay" runat="server" Text="Confirm Order" OnClick="pay_Click" 
                        style="display:inline-block; width:100%; padding:12px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold; text-align:center; margin-top:20px; border:none; cursor:pointer;" />
                </div>
            </div>
        </div>
    </main>

</asp:Content>
