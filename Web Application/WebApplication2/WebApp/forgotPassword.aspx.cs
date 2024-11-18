using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                //if (this.service.passwordChanged(txtNewPassword.Text, txtEmail.Text))
                //    Response.Redirect("login.aspx");
            }
            else
                lblMessage.Text = "New and Confirmed do not Match";
            
        }

        protected void BtnVerifyEmail_Click(object sender, EventArgs e)
        {
            if(this.service.emailExists(txtEmail.Text))
            {
                lblMessage.Text = "Verification SuccessFull";
                passwordResetSection.Visible = true;
                emailInpt.Visible = false;
                verifyEmail.Visible = false;
            }
            else
                lblMessage.Text = "Verification unsucessful";
            
        }
    }
}