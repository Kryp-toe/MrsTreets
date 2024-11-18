using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class add_product : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (Session["Type Of"].ToString() != "OWNER")
                {
                    Response.Redirect("login.aspx");
                }
                int businessID = Convert.ToInt32(Request.QueryString["busID"]);
                title.InnerText = "Add a Product to " + sc.getBusName(businessID);
            }
        }

        protected void addProd_Click(object sender, EventArgs e)
        {
            int businessID = Convert.ToInt32(Request.QueryString["busID"]);

            PRODUCT newProd = sc.addProduct(businessID, name.Value, description.Value, category.Value, allergies.Value, Convert.ToDecimal(price.Value));

            if (newProd != null)
            {
                Response.Redirect("add_product.aspx?busID=" + Request.QueryString["busID"].ToString());
                //How do i confirm with user if product has been edited, should i show a message or what??
            }
            else
            {
                lblerror.InnerText = "Error! Unable to add product.";
                lblerror.Visible = true;
            }
        }
    }
}