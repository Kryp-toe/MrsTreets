using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class admin_login : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = client.login(Email.Text, Password.Text);

            if (user != null)
            {
                Session["ID"] = user.ID;
                Session["Type Of"] = user.TYPE_OF;
                Session["First Name"] = user.FISRT_NAME;
                Session["Email"] = user.EMAIL;
                Session["Phone-Number"] = user.CELL_NUMBER;
                Session["Last Name"] = user.LAST_NAME;
                Response.Redirect("Dashboard.aspx");
            }
            else
                Label1.Text = "Incorrect User name or Password is incorrect";
        }
    }
}