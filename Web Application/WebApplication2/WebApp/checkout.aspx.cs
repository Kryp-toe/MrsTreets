using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;


namespace WebApp
{
    public partial class checkout : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int cartID = Convert.ToInt32(Request.QueryString["cartID"].ToString());
            string html = "";
            sc.calcCartTotal(cartID);
            var c = sc.getCart(cartID);


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


            html += "<h2 class='total'>Order Summary</h2>" +
                "    <h4 class='subtotal'>Subtotal<span class='subtotal-price'>" + cart.PROD_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                "    <h4 class='shipping-fee'>Service Fee<span class='shipping-fee-price'>" + cart.SERVICES_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                "    <h4 class='shipping-fee'>Total<span class='shipping-fee-price'>" + cart.TOTAL.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>" +
                "    <h4 class='shipping-fee'>Discount<span class='shipping-fee-price'>(" + cart.DISCOUNT.ToString("C", new CultureInfo("en-ZA")) + ")</span></h4>" +
                "    <h2 class='total'>Total due<span class='total-price'>" + cart.TOTAL_PAID.ToString("C", new CultureInfo("en-ZA")) + "</span></h2>" +
                "    <h4 class='subtotal'>VAT<span class='subtotal-price'>" + cart.TAX.ToString("C", new CultureInfo("en-ZA")) + "</span></h4>";


            cartsummary.InnerHtml = html;
        }


        protected void pay_Click(object sender, EventArgs e)
        {
            pay.Visible = false;
            paymentchoice.Visible = false;
            paymentmethod.Visible = false;


            int cartID = Convert.ToInt32(Request.QueryString["cartID"].ToString());
            string method = paymentchoice.Value.ToString();


            var c = sc.getCart(cartID);
            INVOICE i = sc.checkout(cartID, method);


            INVOICE invoice = new INVOICE
            {
                ID = i.ID,
                BUSINESS_ID = i.BUSINESS_ID,
                USER_ID = i.USER_ID,
                PROD_SUBTOTAL = i.PROD_SUBTOTAL,
                TAX = i.TAX,
                SERVICES_SUBTOTAL = i.SERVICES_SUBTOTAL,
                TOTAL = i.TOTAL,
                DISCOUNT = i.DISCOUNT,
                TOTAL_PAID = i.TOTAL_PAID,
                DATE_TIME = i.DATE_TIME,
                PAYMENT_METHOD = i.PAYMENT_METHOD
            };

            string html = "<h2 class='total'>Your order at " + sc.getBusName(invoice.BUSINESS_ID) + " is confirmed and will be waiting for you. Please pick it up at: " + sc.getBusAddress(invoice.BUSINESS_ID) + "</h2>" +
                          "<a href='invoice.aspx?invoiceId=" + invoice.ID + "' style='display:inline-block;padding:10px 20px; background-color:var(--yellow);color:white;text-decoration:none;border-radius:5px;font-weight:bold;'>See Invoice</a>";




            cartsummary.InnerHtml = html;
        }
    }
}
