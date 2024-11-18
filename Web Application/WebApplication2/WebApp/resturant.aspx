<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="resturant.aspx.cs" Inherits="WebApp.resturant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="resturant.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<li><a href="Cart.aspx"  runat="server" id="cart"><i class="fa-solid fa-cart-shopping"></i></a></li>--%>
        <main>
            <div class="restaurant-header" id="RestBio" runat="server">

            </div>

            <div class="menu-div">

                <div class="modal">
                    <div class="add-to-cart">
                        <h4 class="item-name" id="H1" runat="server">Combo 1</h4>
                        <p class="item-description" id="P1" runat="server">Wors and Chips</p>
                        <div class="order-modification">
                            <textarea name="notes" id="notes"></textarea>
                            <div class="quantity">
                                <asp:Button ID="btnSubstract" runat="server" Text="-" class="subtract" OnClick="SubstractOn_Click" />
                                <p class="number" id="modalNumber" runat="server">1</p>
                                <asp:Button ID="btnAdd" runat="server" Text="+" class="add" OnClick="AddOn_Click" />
                            </div>
                        </div>

                        <asp:Button ID="BbtnAddToCart" runat="server" Text="Add to cart" class="btn-add-to-order" OnClick="AddToCart_Click" />

                    </div>
                </div>
                <div class="search-boxes">
                    <asp:TextBox ID="txtSearchLocation" runat="server" placeholder="Search Products" 
                 style="flex:1; padding:12px 20px; border:1px solid #ccc; border-radius:5px 0 0 5px; outline:none;">
    </asp:TextBox>
    <asp:Button ID="btnSeacrchLocation" runat="server" Text="⮚" OnClick="btnSearchLocation_Click" 
                style="padding:12px 20px; background-color: var(--yellow); color:white; border-radius:0 5px 5px 0; border:none; cursor:pointer; font-weight:bold;"/>
                </div>
                <div class="menu-category">
                    <div class="menu-items" id="MenuClass" runat="server">

                    </div>
                </div>

            </div>
        </main>
    <script>
        var itemName = "";
        var itemDescription = "";

        var modalContent = document.getElementsByClassName("add-to-cart")[0];
        var modalView = document.querySelector(".modal");
        var addToCartItemName = document.getElementById("item-name");
        var addToCartItemDescription = document.getElementById("item-description");
        var btnAdd = document.querySelector(".btn-add-to-order");
        var closeModal = document.querySelector(".fa-circle-xmark");

        //elements inside the add to cart
        var subtract = document.getElementsByClassName("subtract")[0];
        var number = document.getElementsByClassName("number")[0];
        var add = document.getElementsByClassName("add")[0];
        var notes = document.getElementById("notes");
        var all = document.querySelector("*");
        var cart = document.querySelector(".cart-list");
        var value;
        var num = 0;

        function subtracting() {
            var value = number.innerText;
            value--
            // console.log(value)

            if (value <= 0) {
                number.innerHTML = 1;
                num = 1
            } else {
                number.innerHTML = value;
                num = Number(value)
            }
        }

        function adding() {
            var value = number.innerText;
            value++

            console.log(value);
            if (value <= 0) {
                number.innerHTML = 1;
                num = 1

            } else {
                number.innerHTML = value;
                num = Number(value)
            }
        }

        subtract.addEventListener("click", () => {
            subtracting();
        })

        add.addEventListener("click", () => {
            adding();
        })

        btnAdd.addEventListener("click", () => {
            console.log(number);
            var item = document.createElement('div');
            item.classList.add("cart-item")
            item.innerHTML = `<h4 class="cart-item-name">` + itemName + `<img src="Trash 2.svg" alt="" class="delete"></h4>
                    
                    <p class="price">` + price + `</p>
                    <div class="quantity-buttons">
                        <button class="cart-subtract">-</button>
                        <p class="cart-number">` + num + `</p>
                        <button class="cart-add">+</button>
                    </div>`
            cart.appendChild(item);
            modalView.classList.remove("modal-active")
            all.style.overflow = "initial"
        })

        var price;

        var pressedBtn;


        addBtn = document.querySelectorAll(".btn-add-item");
        addBtn.forEach(element => {
            element.addEventListener("click", function getInfo() {
                price = this.previousElementSibling.innerText
                itemDescription = this.previousElementSibling.previousElementSibling.innerText
                itemName = this.previousElementSibling.previousElementSibling.previousElementSibling.innerText
                addToCartItemName.innerText = itemName
                addToCartItemDescription.innerText = itemDescription
                modalView.classList.add("modal-active");
                all.style.overflow = "hidden"
                pressedBtn = element
            })
        });


        window.onclick = function (event) {
            if ((modalView.classList[1] === "modal-active") && (event.target != pressedBtn)) {
                console.log("it spans")
                if ((event.target != modalContent) && (event.target != modalContent.children[0])
                    && (event.target != modalContent.children[1]) && (event.target != modalContent.children[2])
                    && (event.target != notes) && (event.target != subtract)
                    && (event.target != number) && (event.target != add)
                    && (event.target != modalContent.children[3])) {
                    modalView.classList.remove("modal-active");
                    all.style.overflow = "initial";
                }
            }
        }


        closeModal.onclick = function (e) {
            if ((modalView.classList[1] === "modal-active") && (event.target != pressedBtn)) {
                modalView.classList.remove("modal-active");
                all.style.overflow = "initial";
            }
        }
    </script>
</asp:Content>
