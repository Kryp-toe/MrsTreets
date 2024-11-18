<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="WebApp.invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
    <link rel="stylesheet" href="master.css" type="text/css">
    <link rel="stylesheet" href="resturant.css" type="text/css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.9.2/html2pdf.bundle.js">
    </script>
    <title></title>
</head>

<body>
  <%--  <nav class="navbar">
        <div class="logo">
            <img class="logo-img" src="icons/Other/Aunt J.svg" alt="" srcset="">
            <h2 class="logo-txt">MrS Treets</h2>
        </div>
        <ul class="nav-pill-list">
            <li><a href="home.aspx" target="_blank" rel="noopener noreferrer">Home</a></li>
            <li><a href="login.aspx" target="_blank" rel="noopener noreferrer" id="login" runat="server">Login</a></li>
            <li><a href="register.aspx" target="_blank" rel="noopener noreferrer" id="register" runat="server">Register</a></li>

            <li><a href="manage_businesses.aspx" target="_blank" rel="noopener noreferrer" id="A1" runat="server">Login</a></li>
            <li><a href="Cart.aspx" target="_blank" rel="noopener noreferrer" runat="server" id="cart"><i class="fa-solid fa-cart-shopping"></i></a></li>
            <li><a href="profile_information.aspx" target="_blank" rel="noopener noreferrer" runat="server" id="prof"><i class="fa-regular fa-user"></i></a></li>
        </ul>
    </nav>--%>
    <!-- NAV ENDS -->


    <div class="container">
        <button id="button" style="display:inline-block; padding:10px 20px; background-color:var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;">Download Invoice</button>
        <div class="card" id="makepdf" runat="server">
            <h2>Welcome to GeeksforGeeks</h2>
            <ul>
                <li>
                    <h4>We are going to generate a pdf
                        from the area inside the box
                    </h4>
                </li>
                <li>
                    <h4>This is an example of generating
                        pdf from HTML during runtime
                    </h4>
                </li>
            </ul>
        </div>
        
    </div>


    <footer>
        <div class="links">
            <div class="box1">
                <div class="logo footer-logo">
                    <img class="logo-img" src="Aunt J.svg" alt="" srcset="">
                    <h2 class="logo-txt">MrS Treets</h2>
                </div>
                <a class="phone-link box1-link" href="tel:0109483678"><i class="fa-solid fa-phone"></i>010 948 3678</a>
            </div>
            <div class="socials box1-link">
                <h3>Follow us</h3>
                <a href="#" target="_blank" rel="noopener noreferrer"><i class="social-links fa-brands fa-instagram"></i></a>
                <a href="#" target="_blank" rel="noopener noreferrer"><i class="social-links fa-brands fa-x-twitter"></i></a>
                <a href="#" target="_blank" rel="noopener noreferrer"><i class="social-links fa-brands fa-linkedin"></i></a>
                <a href="#" target="_blank" rel="noopener noreferrer"><i class="social-links fa-brands fa-youtube"></i></a>
            </div>
            <div class="box2">
                <h3>Details</h3>

                <a href="#" target="_blank" rel="noopener noreferrer">About</a>
                <a href="#" target="_blank" rel="noopener noreferrer">Sign in</a>
                <a href="#" target="_blank" rel="noopener noreferrer">Terms of Service</a>
            </div>
            <div class="email2">
                <label for="email">Stay in touch</label>
                <input type="text" placeholder="Type email" name="mail" id="email">
                <button class="contact-support">Contact Support</button>
            </div>
        </div>
        <div class="email">
            <label for="email">Stay in touch</label>
            <input type="text" placeholder="Type email" name="mail" id="email">
            <button class="contact-support">Contact Support</button>
        </div>
    </footer>

    <script>
        let button = document.getElementById("button");
        let makepdf = document.getElementById("makepdf");

        button.addEventListener("click", function () {
            let mywindow = window.open("", "PRINT",
                "height=400,width=600");

            mywindow.document.write(makepdf.innerHTML);

            mywindow.document.close();
            mywindow.focus();

            mywindow.print();
            mywindow.close();

            return true;
        });

        //profile operations
        //open profile
        const profileNav = document.querySelector(".profile-nav");
        const profileIcon = document.querySelector(".fa-user");
        profileIcon.addEventListener("click", () => {
            profileNav.classList.add("active-profile");
        })

        //close profile
        const closeProfile = document.querySelector(".close-profile");
        closeProfile.addEventListener("click", () => {
            profileNav.classList.remove("active-profile")
        })
    </script>

</body>
</html>