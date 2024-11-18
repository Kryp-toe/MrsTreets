using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class add_resturant : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (Session["Type Of"].ToString() != "OWNER")
                {
                    Response.Redirect("home.aspx");
                }
            }
        }


        protected void addRest_Click(object sender, EventArgs e)
        {
            string address = address1.Value + "," + address2.Value + "," + suburb.Value + "," + city.Value + "," + province.Value + "," + postal.Value;
            BUSINESS newRest = sc.addRest(Convert.ToInt32(Session["ID"].ToString()), name.Value, address, getUploadedPicture(), description.Value);


            if (newRest != null)
            {
                Response.Redirect("add_product.aspx?busID=" + newRest.ID);
            }
            else
            {
                lblerror.InnerText = "Error! Unable to add resturant.";
                lblerror.Visible = true;
            }

        }




        private string getUploadedPicture()
        {
            string uploadDirectory = Server.MapPath("~/Business IMGs/");

            // Check if the directory exists; if not, create it
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            // Check if a file has been uploaded
            if (fileUploadProfilePicture.HasFile)
            {
                try
                {
                    // Get the file name
                    string fileName = Path.GetFileName(fileUploadProfilePicture.FileName);
                    // Define the full path to save the file
                    string savePath = Path.Combine(uploadDirectory, fileName);

                    // Save the uploaded file
                    fileUploadProfilePicture.SaveAs(savePath);
                   // lblUploadMessage.Text = "File uploaded successfully: " + fileName;
                    return "Business IMGs/" + fileName;
                }
                catch (Exception ex)
                {
                   // lblUploadMessage.Text = "Error: " + ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }


}

