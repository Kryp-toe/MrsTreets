using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class deleteprod : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            sc.deleteProduct(int.Parse(Request.QueryString["prodID"].ToString()));
            Response.Redirect(Request.UrlReferrer.ToString());

        }
    }
}