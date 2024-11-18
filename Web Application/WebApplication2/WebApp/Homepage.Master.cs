using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Homepage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                //sideNav.Visible = false;
                //mobileNav.Visible = false;
                //sigIn.Visible = false;
                //login.Visible = false;
                //register.Visible = false;

                //prof.Visible = true;

                if (Session["Type Of"] != null)
                {
                    if (Session["Type Of"].ToString() == "OWNER")
                    {
                        //mangebusinesses.Visible = true;
                        sideNav.Visible = true;
                        mobileNav.Visible = true;
                    }
                    else if (Session["Type Of"].ToString() == "CUSTOMER")
                    {
                        userName.InnerText = Session["First Name"].ToString();
                        sideNav.Visible = false;
                        mobileNav.Visible = false;
                        sigIn.Visible = false;
                        //cart.Visible = true;
                        //get the specific business
                        int BusID = Convert.ToInt32(Request.QueryString["RestID"]);
                        cart.HRef = "Cart.aspx?RestID=" + BusID;
                        Session["cart.HRef"] = cart.HRef;
                    }
                    else if (Session["Type Of"].ToString() == "ADMIN")
                    {
                        //what special features do they get??
                    }
                }
            }
            else
            {
                userName.Style.Add("color", "transparent");
                sideNav.Visible = false;
                mobileNav.Visible = false;
                signOut.Visible = false;
                invoices.Visible = false;
                manageAcclink.Visible = false;
                cart.Visible = false;
            }
        }
    }
}