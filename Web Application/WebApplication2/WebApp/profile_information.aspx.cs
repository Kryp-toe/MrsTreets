using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;
using WebApp.Utitily;
namespace WebApp
{
    public partial class profile_information : System.Web.UI.Page
    {
        Service1Client service = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
                Response.Redirect("login.aspx");


            if (!IsPostBack)
            {
                txtEmail.Attributes["placeholder"] = Session["Email"].ToString();
                txtName.Attributes["placeholder"] = Session["First Name"].ToString();
                txtSurname.Attributes["placeholder"] = Session["Last Name"].ToString();
                txtPhoneNumber.Attributes["placeholder"] =  format.getFormattedPhoneNumber(Session["Phone-Number"].ToString());
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int customerID = int.Parse(Session["ID"].ToString());
            bool isEdited = this.service.editCustomer(customerID, txtName.Text, txtSurname.Text, txtEmail.Text, txtPhoneNumber.Text);
            if (isEdited)
            {
                Session["Email"] = txtEmail.Text;
                Session["First Name"] = txtName.Text;
                Session["Last Name"] = txtSurname.Text;
                Session["Phone-Number"] = txtPhoneNumber.Text;
                Response.Redirect("profile_information.aspx");
            }

        }


        protected void btnUpdateProfilePicture_Click(object sender, EventArgs e)
        {

        }
    }
}