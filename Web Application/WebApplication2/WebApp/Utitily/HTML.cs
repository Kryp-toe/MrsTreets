using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebApp.ServiceReference1;
using System.Globalization;

namespace WebApp.Utitily
{
    public static class HTML
    {
        static Service1Client service = new Service1Client();

        public static string getRESTARAUNTS_HTML()
        {
            StringBuilder sb = new StringBuilder();

            foreach (BUSINESS business_ in service.getAllRests())
            {
                sb.AppendLine("<div class=\"restaurant\">");
                sb.AppendLine("        <a style='text-decoration:none;' class=\"resturantAnchor\" href=\"resturant.aspx?RestID=" + business_.ID + "\">");
                sb.AppendLine("    <p class=\"discount\">50% Off</p>");
                sb.AppendLine("    <div class=\"restaurant-thumbnail\">");
               
                sb.AppendLine("            <img src=\"" + business_.IMAGE + "\" class=\"restaurant-img\" alt=\"Restaurant Image\">");

                sb.AppendLine("    </div>");
                sb.AppendLine("    <div class=\"restaurant-body\">");
                sb.AppendLine("        <h3 class=\"restaurant-name\">" + business_.NAME + "</h3>");
                sb.AppendLine("        <p class=\"menu\">" + business_.DESCRIPTION + "</p>");
                sb.AppendLine("        <p class=\"place\">" + business_.ADDRESS + "</p>");
                //sb.AppendLine("        <span class=\"rating\">4.2<i class=\"fa-regular fa-star\"></i></span>");
                sb.AppendLine("    </div>");
                sb.AppendLine("        </a>");
                sb.AppendLine("</div>");

            }

            return sb.ToString();
        }



        public static string getRESTARAUNT_BIO_HTML(int id)
        {
            BUSINESS business = service.getRest(id);

            if (business != null)
            { 
                StringBuilder bioHtml = new StringBuilder();
                bioHtml.AppendLine("<div class='restaurant-image' style='background-image: url(\""+business.IMAGE+"\")'></div>");
                bioHtml.AppendLine("<div class='restaurant-info'>");
                bioHtml.AppendLine("    <h2 class='restaurantName'>" + business.NAME + "</h2>");
                bioHtml.AppendLine("    <p class='restaurant-description'>" + business.DESCRIPTION + "</p>");
                bioHtml.AppendLine("</div>");

                return bioHtml.ToString();
            }
            return null;
        }


        public static string getPRODUCTS_HTML(int id)
        {
            PRODUCT[] arryProducts = service.getAllActiveProducts(id);

            if (arryProducts != null)
            {
                StringBuilder productsHtml = new StringBuilder();
                foreach (PRODUCT product in arryProducts)
                {
                    productsHtml.AppendLine("<div class='item'>");
                    productsHtml.AppendLine("    <h4 class='item-name'>" + product.NAME + "</h4>");
                    productsHtml.AppendLine("    <p class='item-description'>" + product.DESCRIPTION + "</p>");
                    productsHtml.AppendLine("    <p class='price'>" + product.PRICE.ToString("C", new CultureInfo("en-ZA"))+ "</p>");
                    productsHtml.AppendLine("    <br />");
                    productsHtml.AppendLine("    <button class='btn-add-item'>ADD</button>");
                    productsHtml.AppendLine("    <br />");
                    productsHtml.AppendLine("</div>");
                }
                return productsHtml.ToString();
            }

            return null;
        }


        public static string getSEARCHED_HTML(BUSINESS[] businesses)
        {

            StringBuilder sb = new StringBuilder();

            foreach (BUSINESS business_ in businesses)
            {
                sb.AppendLine("<div class=\"restaurant\">");
                sb.AppendLine("<a style='text-decoration:none;' class=\"go-back\" href=\"home.aspx\">X</a>");
                sb.AppendLine("    <a style='text-decoration:none;' class=\"resturantAnchor\" href=\"resturant.aspx?RestID=" + business_.ID + "\">");
                sb.AppendLine("    <p class=\"discount\">50% Off</p>");
                sb.AppendLine("    <div class=\"restaurant-thumbnail\">");

                sb.AppendLine("            <img src=\"" + business_.IMAGE + "\" class=\"restaurant-img\" alt=\"Restaurant Image\">");

                sb.AppendLine("    </div>");
                sb.AppendLine("    <div class=\"restaurant-body\">");
                sb.AppendLine("        <h3 class=\"restaurant-name\">" + business_.NAME + "</h3>");
                sb.AppendLine("        <p class=\"menu\">" + business_.DESCRIPTION + "</p>");
                sb.AppendLine("        <p class=\"place\">" + business_.ADDRESS + "</p>");
                sb.AppendLine("        <span class=\"rating\">4.2<i class=\"fa-regular fa-star\"></i></span>");
                sb.AppendLine("    </div>");
                sb.AppendLine("        </a>");
                sb.AppendLine("</div>");

            }

            return sb.ToString();
        }


        public static string getLocationSearched_HTML(BUSINESS[] businesses)
        {
            StringBuilder sb = new StringBuilder();

            foreach (BUSINESS business_ in businesses)
            {
                sb.AppendLine("<div class=\"restaurant\">");
                sb.AppendLine("<a style='text-decoration:none;' class=\"go-back\" href=\"home.aspx\">X</a>");
                sb.AppendLine("        <a style='text-decoration:none;' class=\"resturantAnchor\" href=\"resturant.aspx?RestID=" + business_.ID + "\">");
                sb.AppendLine("    <p class=\"discount\">50% Off</p>");
                sb.AppendLine("    <div class=\"restaurant-thumbnail\">");

                sb.AppendLine("            <img src=\"" + business_.IMAGE + "\" class=\"restaurant-img\" alt=\"Restaurant Image\">");

                sb.AppendLine("    </div>");
                sb.AppendLine("    <div class=\"restaurant-body\">");
                sb.AppendLine("        <h3 class=\"restaurant-name\">" + business_.NAME + "</h3>");
                sb.AppendLine("        <p class=\"menu\">" + business_.DESCRIPTION + "</p>");
                sb.AppendLine("        <p class=\"place\">" + business_.ADDRESS + "</p>");
                sb.AppendLine("        <span class=\"rating\">4.2<i class=\"fa-regular fa-star\"></i></span>");
                sb.AppendLine("    </div>");
                sb.AppendLine("        </a>");
                sb.AppendLine("</div>");

            }
            return sb.ToString();
        }


        public static string getSORTED_HTML(BUSINESS[] businesses)
        {
            StringBuilder sb = new StringBuilder();

            foreach (BUSINESS business_ in businesses)
            {
                sb.AppendLine("<div class=\"restaurant\">");
                sb.AppendLine("<a style='text-decoration:none;' class=\"go-back\" href=\"home.aspx\">X</a>");
                sb.AppendLine("        <a style='text-decoration:none;' class=\"resturantAnchor\" href=\"resturant.aspx?RestID=" + business_.ID + "\">");
                sb.AppendLine("    <p class=\"discount\">50% Off</p>");
                sb.AppendLine("    <div class=\"restaurant-thumbnail\">");
                sb.AppendLine("            <img src=\"" + business_.IMAGE + "\" class=\"restaurant-img\" alt=\"Restaurant Image\">");
                sb.AppendLine("    </div>");
                sb.AppendLine("    <div class=\"restaurant-body\">");
                sb.AppendLine("        <h3 class=\"restaurant-name\">" + business_.NAME + "</h3>");
                sb.AppendLine("        <p class=\"menu\">" + business_.DESCRIPTION + "</p>");
                sb.AppendLine("        <p class=\"place\">" + business_.ADDRESS + "</p>");
                sb.AppendLine("        <span class=\"rating\">4.2<i class=\"fa-regular fa-star\"></i></span>");
                sb.AppendLine("    </div>");
                sb.AppendLine("        </a>");
                sb.AppendLine("</div>");

            }
            return sb.ToString();
        }
    }




}