using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class register : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        private string fistName;
        private string lastName;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            splitStrings();
            var user = this.client.registerUser(this.fistName, this.lastName, txtEmail.Text, txtPassword.Text, txtTel.Text,  txtDOB.Text, txtGender.Text, "CUSTOMER");

            if (user != null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblErr.Visible = true;
            }
        }

        private void splitStrings()
        {
            string[] names = txtFullname.Text.Split(' ');
            if(names.Length == 2)
            {
                this.fistName = names[0];
                this.lastName = names[1];
            }
        }
    }
}