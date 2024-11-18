using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;
using System.Text;
using System.Globalization;

namespace WebApp
{
    public partial class manage_invoices : System.Web.UI.Page
    {
        Service1Client servive = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
                Response.Redirect("login.aspx");


            this.setinvoiceTag();
        }


        private void setinvoiceTag()
        {
            INVOICE[] invoices = this.servive.getUserInvoices(int.Parse(Session["ID"].ToString()));


            StringBuilder sb = new StringBuilder();


            foreach (INVOICE invoice in invoices)
            {
                sb.AppendLine("<h1>Invoice</h1>");


                sb.AppendLine("<div class=\"invoice-section\">");
                sb.AppendLine("    <h3>Product Details</h3>");
                sb.AppendLine("    <p><strong>Product Subtotal:</strong> " + invoice.PROD_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                sb.AppendLine("    <p><strong>TAX (15%):</strong> " + invoice.TAX.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                sb.AppendLine("    <p><strong>Service Subtotal:</strong> " + invoice.SERVICES_SUBTOTAL.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                sb.AppendLine("</div>");


                sb.AppendLine("<div class=\"invoice-summary\">");
                sb.AppendLine("    <p><strong>Total Discount:</strong> " + invoice.DISCOUNT.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                sb.AppendLine("    <p class=\"total\"><strong>Total Paid:</strong> " + invoice.TOTAL_PAID.ToString("C", new CultureInfo("en-ZA")) + "</p>");
                sb.AppendLine("</div>");


                sb.AppendLine("<div class=\"invoice-details\">");
                sb.AppendLine("    <p><strong>Date & Time:</strong> " + invoice.DATE_TIME.ToString() + "</p>");
                sb.AppendLine("    <p><strong>Payment Method:</strong> " + invoice.PAYMENT_METHOD + "</p>");
                sb.AppendLine("</div>");


                sb.AppendLine("<div class=\"invoice-details\">");
                sb.AppendLine("    <a href='invoice.aspx?invoiceId=" + invoice.ID + "'>VIEW</a>");
                sb.AppendLine("</div>");
            }




            invoiceContainer.InnerHtml = sb.ToString();


        }
    }
}