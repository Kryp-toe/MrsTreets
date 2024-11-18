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
    public partial class invoice : System.Web.UI.Page
    {
        Service1Client service = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int invoiceid = Convert.ToInt32(Request.QueryString["invoiceId"]);
            INVOICE invoice = this.service.getInvoice(invoiceid);


            if (invoice != null)
            {
                USER user = service.getUserByID(invoice.USER_ID);
                BUSINESS business = service.getRest(invoice.BUSINESS_ID);

                if ((user != null) && (business != null))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("<h1 style='font-size: 2.5rem; font-weight: bold; margin-bottom: 20px; color: var(--primary-color);'>Invoice</h1>");

                    sb.AppendLine("<div style='margin-bottom: 20px; padding: 15px; background-color: var(--light-bg); border-radius: 8px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);'>");
                    sb.AppendLine("    <h3 style='font-size: 1.5rem; color: var(--primary-color); margin-bottom: 10px;'>Details</h3>");
                    sb.AppendLine("    <p><strong>Your Email:</strong> " + user.EMAIL + "</p>");
                    sb.AppendLine("    <p><strong>From:</strong> " + business.NAME + "</p>");
                    sb.AppendLine("    <p><strong>Business Address:</strong> " + business.ADDRESS + "</p>");
                    sb.AppendLine("    <p><strong>Date & Time:</strong> " + invoice.DATE_TIME.ToString() + "</p>");
                    sb.AppendLine("    <p><strong>Reference Number:</strong> " + invoice.ID + "</p>");
                    sb.AppendLine("</div>");

                    sb.AppendLine("<div style='margin-bottom: 20px; padding: 15px; background-color: var(--light-bg); border-radius: 8px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);'>");
                    sb.AppendLine("    <h3 style='font-size: 1.5rem; color: var(--primary-color); margin-bottom: 10px;'>Product Details</h3>");
                    sb.AppendLine("    <p><strong>Product Subtotal:</strong> " + invoice.PROD_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                    sb.AppendLine("    <p><strong>TAX (15%):</strong> " + invoice.TAX.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                    sb.AppendLine("    <p><strong>Service Subtotal:</strong> " + invoice.SERVICES_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                    sb.AppendLine("</div>");

                    sb.AppendLine("<div style='background-color: var(--light-yellow); padding: 15px; border-radius: 8px; margin-top: 20px; font-weight: bold;'>");
                    sb.AppendLine("    <p><strong>Total Discount:</strong> " + invoice.DISCOUNT.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                    sb.AppendLine("    <p style='font-size: 1.2rem; color: var(--highlight-color);'><strong>Total Paid:</strong> " + invoice.TOTAL_PAID.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                    sb.AppendLine("</div>");

                    sb.AppendLine("<div style='margin-top: 20px; font-size: 1rem;'>");
                    sb.AppendLine("    <p><strong>Payment Method:</strong> " + invoice.PAYMENT_METHOD + "</p>");
                    sb.AppendLine("</div>");

                    // Fixing the button HTML
                    sb.AppendLine("<a href='resturant.aspx?RestID=" + invoice.BUSINESS_ID + "' style='display: inline-block; padding: 10px 20px; background-color: var(--yellow); color: white; text-decoration: none; border-radius: 5px; font-weight: bold;'>Continue Shopping</a>");

                    makepdf.InnerHtml = sb.ToString();
                }


            }
        }
    }
}