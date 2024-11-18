using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebApp.ServiceReference1;
    ﻿
    namespace WebApp
{
    public partial class Cart : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    
                       
                    displayCart();
                }
                else
                {
                    //CART DOES NOT HAVE ITEMS
                    string EmptyCartHtml = "<tr><td scope='row' class='py-4'><h2>Shopping Cart is Empty<h2></td></tr>";
                    PlaceHolder1.Controls.Add(new Literal { Text = EmptyCartHtml });
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder2.Controls.Clear();
                }
            }
            else
            {
                //POSTBACK:
                displayCart();
            }
        }

        private void displayCart()
        {
            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            PlaceHolder1.Controls.Clear();

            var restuarant = sc.getRest(busId);

            CartHeading.Text = "<h1>Your '"+restuarant.NAME+"' order</h1>";

            var c = sc.getCartAtBus(userId, busId);

            if (c == null)
            {
                //CART DOES NOT HAVE ITEMS
                PlaceHolder1.Controls.Clear();
                PlaceHolder2.Controls.Clear();

                couponText.Visible = false;
                btncoupon.Visible = false;
                shop.Visible = false;
                checkout.Visible = false;

                string EmptyCartHtml = "<tr><td scope='row' class='py-4'><h2>Shopping Cart is Empty<h2></td></tr>";
                PlaceHolder1.Controls.Add(new Literal { Text = EmptyCartHtml });
            }
            else
            {
                sc.calcCartTotal(c.ID);
                c = sc.getCartAtBus(userId, busId);

                CART cart = new CART
                {
                    ID = c.ID,
                    USER_ID = c.USER_ID,
                    PROD_SUBTOTAL = c.PROD_SUBTOTAL,
                    SERVICES_SUBTOTAL = c.SERVICES_SUBTOTAL,
                    TAX = c.TAX,
                    TOTAL = c.TOTAL,
                    DISCOUNT = c.DISCOUNT,
                    TOTAL_PAID = c.TOTAL_PAID,
                    BUSINESS_ID = c.BUSINESS_ID
                };

                dynamic list = sc.getProdsInCart(cart.ID);
                List<BRIDGE> listOfCartItems = new List<BRIDGE>();

                if (list != null)
                {
                    foreach (BRIDGE cl in list)
                    {
                        BRIDGE CartList = new BRIDGE
                        {
                            CART_ID = cl.CART_ID,
                            PRODUCT_ID = cl.PRODUCT_ID,
                            QUANTITY = cl.QUANTITY,
                            PRICE = cl.PRICE
                        };
                        listOfCartItems.Add(CartList);
                    }

                    PlaceHolder1.Controls.Clear();

                    foreach (BRIDGE item in listOfCartItems)
                    {
                        var p = sc.getProduct(item.PRODUCT_ID);

                        PRODUCT prod = new PRODUCT
                        {
                            ID = p.ID,
                            NAME = p.NAME,
                            DESCRIPTION = p.DESCRIPTION,
                            PRICE = p.PRICE,
                            CATEGORY = p.CATEGORY,
                            ALLERGIES = p.ALLERGIES,
                            ISACTIVE = p.ISACTIVE
                        };

                        LiteralControl cartDisplay = new LiteralControl();
                        cartDisplay.Text += "<div class='checkout-item' style='margin-bottom:2rem;'>";
                        cartDisplay.Text += "<h4 class='cart-item-name'>" + prod.NAME + "</h4>";
                        cartDisplay.Text += "<p class='price'>" + prod.PRICE.ToString("C", new CultureInfo("en-ZA")) + "</p>";
                        cartDisplay.Text += "<div class='quantity-buttons'>";

                        PlaceHolder1.Controls.Add(cartDisplay);

                        //Subtract button
                        Button btnMinus = new Button();
                        btnMinus.CssClass = "cart-subtract";
                        btnMinus.Text = "-";
                        btnMinus.Click += new EventHandler(QuantityMinus_Click);
                        btnMinus.CommandArgument = item.PRODUCT_ID.ToString();


                        PlaceHolder1.Controls.Add(btnMinus);

                        // Create a new Label control for the quantity
                        Label quantityLabel = new Label();
                        quantityLabel.ID = "lblQuantity_" + item.PRODUCT_ID;
                        quantityLabel.CssClass = "cart-number";
                        quantityLabel.Text = item.QUANTITY.ToString();

                        PlaceHolder1.Controls.Add(quantityLabel);

                        // Create the plus button
                        Button btnPlus = new Button();
                        btnPlus.CssClass = "cart-add";
                        btnPlus.Text = "+";
                        btnPlus.Click += new EventHandler(QuantityPlus_Click);
                        btnPlus.CommandArgument = item.PRODUCT_ID.ToString();

                        PlaceHolder1.Controls.Add(btnPlus);

                        ////remove button:
                        //Button btnRemove = new Button();
                        //btnRemove.CssClass = "";
                        //btnRemove.Click += new EventHandler(RemoveProduct_Click);
                        //btnRemove.CommandArgument = item.PRODUCT_ID.ToString();
                        //btnRemove.Text = "🗑";

                        //Keamo's changes
                        //remove button:
                        Button btnRemove = new Button();
                        btnRemove.Text = "🗑";
                        btnRemove.CommandArgument = item.PRODUCT_ID.ToString();
                        btnRemove.Click += new EventHandler(RemoveProduct_Click);

                        // Add inline style to match the rest of the website
                        btnRemove.Attributes.Add("style", "display:inline-block; padding:10px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;");




                        //style="display:inline-block; padding:10px 20px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:5px; font-weight:bold;"


                        PlaceHolder1.Controls.Add(btnRemove);

                        // Add the closing tag of the HTML to the placeholder
                        LiteralControl itemHtmlEnd = new LiteralControl();
                        itemHtmlEnd.Text = "</div></div>";

                        PlaceHolder1.Controls.Add(itemHtmlEnd);

                        displayTotals();
                    }
                }
            }
        }

        private void displayTotals()
        {
            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            var c = sc.getCartAtBus(userId, busId);
            sc.calcCartTotal(c.ID);
            c = sc.getCartAtBus(userId, busId);

            CART cart = new CART
            {
                ID = c.ID,
                USER_ID = c.USER_ID,
                PROD_SUBTOTAL = c.PROD_SUBTOTAL,
                SERVICES_SUBTOTAL = c.SERVICES_SUBTOTAL,
                TAX = c.TAX,
                TOTAL = c.TOTAL,
                DISCOUNT = c.DISCOUNT,
                TOTAL_PAID = c.TOTAL_PAID,
                BUSINESS_ID = c.BUSINESS_ID
            };

            //display totals
            PlaceHolder2.Controls.Clear();

            LiteralControl total = new LiteralControl();

            total.Text = "<h4 class='subtotal'>Subtotal <span class='subtotal-price'>" + cart.PROD_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                "        <h4 class='shipping-fee'>Service Fee(incl.)<span class='shipping-fee-price'>" + cart.SERVICES_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                "        <h4 class='shipping-fee'>Total(incl.)<span class='shipping-fee-price'>" + cart.TOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
   
                "        <h4 class='subtotal'>VAT<span class='subtotal-price'>" + cart.TAX.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                            "        <h4 class='shipping-fee'>Discount<span class='shipping-fee-price'>(" + cart.DISCOUNT.ToString("C", new CultureInfo("en-ZA")) + ")</span></h4>" +
                "        <h2 class='total'>Total due<span class='total-price'>" + cart.TOTAL_PAID.ToString("C", new CultureInfo("en-ZA")) + "</span></h2>";

            PlaceHolder2.Controls.Add(total);
        }

        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);

            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            var c = sc.getCartAtBus(userId, busId);

            sc.addToCart(userId, productId, c.ID, 0);

            displayCart();
        }

        private void QuantityPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Label lblQuantity = (Label)PlaceHolder1.FindControl("lblQuantity_" + productId);
            int quantity = int.Parse(lblQuantity.Text);
            quantity++;

            if (quantity <= 0)
            {
                quantity = 1;
            }

            lblQuantity.Text = quantity.ToString();

            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            var c = sc.getCartAtBus(userId, busId);

            sc.addToCart(userId, productId, c.ID, quantity);
            displayTotals();
        }

        private void QuantityMinus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Label lblQuantity = (Label)PlaceHolder1.FindControl("lblQuantity_" + productId);
            int quantity = int.Parse(lblQuantity.Text);
            quantity--;

            if (quantity <= 0)
            {
                quantity = 1;
            }

            lblQuantity.Text = quantity.ToString();

            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            var c = sc.getCartAtBus(userId, busId);

            sc.addToCart(userId, productId, c.ID, quantity);
            displayTotals();
        }

        protected void shop_Click(object sender, EventArgs e)
        {
            Response.Redirect("resturant.aspx?RestID=" + Request.QueryString["RestID"].ToString());
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            var c = sc.getCartAtBus(userId, busId);
            Response.Redirect("checkout.aspx?cartID=" + c.ID);
        }

        protected void btncoupon_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["ID"].ToString());
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);
            var c = sc.getCartAtBus(userId, busId);

            string code = couponText.Value;

            sc.addDiscountToCart(c.ID, sc.getCodeProdID(code, busId), code);
            displayTotals();
        }
    }
}

