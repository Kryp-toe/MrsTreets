using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class resturant : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the specific business
            int BusID = Convert.ToInt32(Request.QueryString["RestID"]);
            //cart.HRef = "Cart.aspx?RestID=" + BusID;
            //get all products from business
            dynamic prods = sc.getAllActiveProducts(BusID);
            var bus = sc.getRest(BusID);

            string html = " ";
            string bioHtml = " ";

            bioHtml += "<div class='restaurant-image' style='background-image:url(\"" + bus.IMAGE + "\")'></div>";

            bioHtml += "<div class='restaurant-info'>";
            bioHtml += "<h2 class='restaurantName'>" + bus.NAME + "</h2>";
            bioHtml += "<p class='restaurant-description'>" + bus.DESCRIPTION + "</p>";
            bioHtml += "</div>";

            RestBio.InnerHtml = bioHtml;

            foreach (PRODUCT p in prods)
            {
                html += "<div class='item'>";
                html += "<h4 class='item-name'>" + p.NAME + "</h4>";
                html += "<p class='item-description'>" + p.DESCRIPTION + "</p>";
                html += "<p class='price'>Price:" + p.PRICE.ToString("C", new CultureInfo("en-ZA"))+ "</p>";
                html += "<a href='ReferPage.aspx?ProdID=" + p.ID + "&RestID=" + BusID + "' style='display:inline-block; padding:5px 10px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:3px; font-weight:bold;'>+</a>";
                html += "</div>";
            }
            MenuClass.InnerHtml = html;
        }

        protected void SubstractOn_Click(object sender, EventArgs e)
        {
            // Decrement the quantity but don't go below 1
            int currentQuantity = int.Parse(modalNumber.InnerText);
            if (currentQuantity > 1)
            {
                currentQuantity--;
            }
            modalNumber.InnerText = currentQuantity.ToString();
        }

        protected void AddOn_Click(object sender, EventArgs e)
        {
            // Increment the quantity
            int currentQuantity = int.Parse(modalNumber.InnerText);
            currentQuantity++;
            modalNumber.InnerText = currentQuantity.ToString();
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            //TO DO:
            //sc.addToCart(Convert.ToInt32(Session["ID"].ToString()), );
        }

        protected void btnSearchLocation_Click(object sender, EventArgs e)
        {
            int businessID = int.Parse(Request.QueryString["RestID"].ToString());
            PRODUCT[] resultProducts = this.sc.getSearchedProducts(txtSearchLocation.Text, businessID);

            if (resultProducts != null)
            {
                string html = "";
                foreach (PRODUCT p in resultProducts)
                {
                    html += "<div class='item'>";
                    html += "<h4 class='item-name'>" + p.NAME + "</h4>";
                    html += "<p class='item-description'>" + p.DESCRIPTION + "</p>";
                    html += "<p class='price'>Price:" + p.PRICE.ToString("C", new CultureInfo("en-ZA")) + "</p>";
                    html += "<a href='ReferPage.aspx?ProdID=" + p.ID + "&RestID=" + p.BUSINESS_ID + "' style='display:inline-block; padding:5px 10px; background-color: var(--yellow); color:white; text-decoration:none; border-radius:3px; font-weight:bold;'>+</a>";
                    html += "</div>";
                }
                MenuClass.InnerHtml = html;
            }
        }

    }
}