using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = null;
            Session["Type Of"] = null;
            Session["First Name"] = null;
            Session["Email"] = null;
            Session["Phone-Number"] = null;
            Session["Last Name"] = null;
            Response.Redirect("login.aspx");
        }
    }
}