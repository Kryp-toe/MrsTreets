using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class admin_register : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           
            var user = this.client.registerUser(firstName.Text, lastName.Text, mail.Text, Password.Text, phone.Text, dob.Text, gender.Text, "OWNER");

            if (user != null)
            {
                Response.Redirect("admin_login.aspx");
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        //private void splitStrings()
        //{
        //    string[] names = txtFullname.Text.Split(' ');
        //    if (names.Length == 2)
        //    {
        //        this.fistName = names[0];
        //        this.lastName = names[1];
        //    }
        //}
    }
}