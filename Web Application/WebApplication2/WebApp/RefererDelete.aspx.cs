using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class RefererDelete : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

            int busId = Convert.ToInt32(Request.QueryString["busID"]);

            client.deleteRest(busId);
            Response.Redirect(Request.UrlReferrer.ToString());

        }
    }
}