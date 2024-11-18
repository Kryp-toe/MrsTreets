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
    public partial class edit_business : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            //else
            //{
            //    if (Session["Type Of"].ToString() == "OWNER")
            //    {
            //        if (!IsPostBack)
            //        {
            //            if (Request.QueryString["busID"] != null)
            //            {
            //                int busID = Convert.ToInt32(Request.QueryString["busID"]);
            //                displayBus(busID);
            //            }
            //            else
            //            {
            //                Response.Redirect("manage_businesses.aspx");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("home.aspx");
            //    }
            //}
        }

   
        protected void editBus_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["busID"] != null)
            {
                int busID = Convert.ToInt32(Request.QueryString["busID"]);
                string addy = address1.Value + "," + address2.Value + "," + suburb.Value + "," + city.Value + "," + province.Value + "," + postal.Value;

                string picURL = this.getUploadedPicture();
                if (picURL != null)
                {
                    bool result = sc.editBusiness(busID, name.Value, addy, picURL, description.Value, Convert.ToBoolean(active.Value));

                    displayBus(busID);

                    if (result)
                    {
                        lblerror.InnerText = "Sucessfully changed business.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        lblerror.InnerText = "An error occured when changing business.";
                        lblerror.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("manage_businesses.aspx");
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
                    //lblUploadMessage.Text = "File uploaded successfully: " + fileName;
                    return "Business IMGs/" + fileName;
                }
                catch (Exception ex)
                {
                    //lblUploadMessage.Text = "Error: " + ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    

    protected void manageBus_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_businesses.aspx");
        }

        private void displayBus(int busID)
        {
            var b = sc.getRest(busID);

            if (b != null)
            {
                editBus.Enabled = true;
                BUSINESS business = new BUSINESS
                {
                    ID = b.ID,
                    NAME = b.NAME,
                    ADDRESS = b.ADDRESS,
                    IMAGE = b.IMAGE,
                    DESCRIPTION = b.DESCRIPTION
                };

                name.Value = business.NAME;
                description.Value = business.DESCRIPTION;

                string addy = business.ADDRESS;
                string[] address = addy.Split(',');
                address1.Value = address[0];
                //address2.Value = address[1];
                //suburb.Value = address[2];
                //city.Value = address[3];
                //province.Value = address[4];
                //postal.Value = address[5];

                //image.Value = business.IMAGE;
                active.Value = business.ISACTIVE.ToString();

            }
            else
            {
                lblerror.InnerText = "Unable to find business";
                lblerror.Visible = true;
            }
        }

        protected void manageProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_products.aspx?busID=" + Request.QueryString["busID"]);
        }
    }
}