using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class ReferPage : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int prodId = Convert.ToInt32(Request.QueryString["ProdID"]);
            int busId = Convert.ToInt32(Request.QueryString["RestID"]);

            if (Session["ID"] != null)
            {
                int userID = Convert.ToInt32(Session["ID"].ToString());
                //check if cart exists

                var userCart = client.getCartAtBus(userID, busId);

                if (userCart != null)
                {
                    client.addToCart(userID, prodId, userCart.ID, 1);
                }
                else
                {
                    var ncart = client.createCart(userID, prodId);
                    client.addToCart(userID, prodId, ncart.ID, 1);
                }
                Response.Redirect("Cart.aspx?RestID=" + busId);
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}