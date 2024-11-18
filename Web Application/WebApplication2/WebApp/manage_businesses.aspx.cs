using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class manage_businesses : System.Web.UI.Page
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
            //        int ownerUsername = Convert.ToInt32(Session["ID"].ToString());

            //        var bs = sc.getAllRestByOwner(ownerUsername);
            //        string html = "";
            //        if (bs != null)
            //        {
            //            List<BUSINESS> listBusiness = new List<BUSINESS>();
            //            foreach(BUSINESS b in bs)
            //            {
            //                listBusiness.Add(b);

            //                html +=
            //                    "<div class='inventory'>" +
            //                    "<div class='restaurant'>" +
            //                    "<div class='restaurant-thumbnail'>" +
            //                    "<a href='manage_products.aspx?busID=" + b.ID + "'>" +
            //                    "<img src='" + b.IMAGE + "' class='restaurant-img' alt=''>" +
            //                    "</div>" +
            //                    "<div class='restaurant-body'>" +
            //                    "<h3 class='restaurant-name'>" + b.NAME + "</h3>" +
            //                    "<p class='menu'>" + b.DESCRIPTION + "</p>" +
            //                    "<p class='place'>" + b.ADDRESS + "</p>" +
            //                    "</a></div></div></div>";
            //            }
            //        }
            //        else
            //        {
            //            html += "<label> You do not have any businesses </label>";
            //        }
            //        businesses.InnerHtml = html;
            //    }
            //    else
            //    {
            //        Response.Redirect("home.aspx");
            //    }
            //}
            
            if(Session["ID"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                if (Session["Type Of"].ToString() == "OWNER")
                {
                    int ownerUsername = Convert.ToInt32(Session["ID"].ToString());
                 
                        GenerateDynamicContent(ownerUsername);
                    
                }
            }
        }


        private void GenerateDynamicContent(int username)
        {
            var bs = sc.getAllRestByOwner(username);
            if (bs != null)
            {
                List<BUSINESS> listBusiness = new List<BUSINESS>();
                foreach (BUSINESS b in bs)
                {
                    listBusiness.Add(b);

                    // Start building the restaurant div HTML
                    LiteralControl itemHtmlStart = new LiteralControl();
                    itemHtmlStart.Text += "<div class='restaurant'>";
                    itemHtmlStart.Text += $"<div class='restaurant-img' style='background-image:url({b.IMAGE});'></div>";
                    itemHtmlStart.Text += "<div class='res-name'>";
                    itemHtmlStart.Text += $"<h3 class='restaurant-name'>{b.NAME}</h3>";
                    itemHtmlStart.Text += $"<p class='address'>{b.ADDRESS}</p>";
                    itemHtmlStart.Text += "</div>";
                    itemHtmlStart.Text += $"<p id='rest-desc' class='restaurant-description'>{b.DESCRIPTION}</p>";
                    itemHtmlStart.Text += "<p class='orders'>Orders <br> <span>48</span></p>";
                    itemHtmlStart.Text += "<p class='sales'>Sales <br> <span>R14, 983</span></p>";
                    itemHtmlStart.Text += "<div class='crud-btn'>";
                    itemHtmlStart.Text += "<a href='edit_business.aspx?busID=" + b.ID + "' class='btn delete-rest'>✎</a>";
                    //itemHtmlStart.Text += "<a href='RefererDelete.aspx?busID=" + b.ID + "' class='btn delete-rest'>✎</a>";
                    restaurantList.Controls.Add(itemHtmlStart);

                    // Generate the delete button with an icon
                    Button deleteButton = new Button();
                    deleteButton.CssClass = "btn delete-rest";
                    deleteButton.Text = "✕";
                    deleteButton.CommandArgument = b.ID.ToString();
                    deleteButton.UseSubmitBehavior = false; // Prevent form submission if necessary
                    deleteButton.Click += new EventHandler(DeleteButton_Click);
                    restaurantList.Controls.Add(deleteButton);

                    //// Generate the edit button with an icon
                    //Button editButton = new Button();
                    //editButton.CssClass = "btn edit-rest";
                    //editButton.Text = "✎";
                    //editButton.UseSubmitBehavior = false; // Prevent form submission if necessary
                    //editButton.Click += new EventHandler(EditButton_Click);
                    //restaurantList.Controls.Add(editButton);

                    // Close the HTML divs
                    LiteralControl itemHtmlEnd = new LiteralControl();
                    itemHtmlEnd.Text += "</div></div>"; // Closing the crud-btn and restaurant divs
                    restaurantList.Controls.Add(itemHtmlEnd);
                }
            }
            else
             {
                LiteralControl html = new LiteralControl();
                html.Text = "<h2>You do not have any businesses</h2>";
                restaurantList.Controls.Add(html);
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // Handle delete button click
            Button btn = (Button)sender;
            int busId = int.Parse(btn.CommandArgument);
            sc.deleteRest(busId);
            int ownerUsername = Convert.ToInt32(Session["ID"].ToString());
            restaurantList.Controls.Clear();
            GenerateDynamicContent(ownerUsername);
         
        }

        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    // Handle delete button click
        //    Button btn = (Button)sender;
        //    int busId = int.Parse(btn.CommandArgument);
        //    Response.Redirect("edit_business.aspx?busID=" + busId);
            
        //    Response.Write("Edit button clicked!");
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
      
            Response.Redirect("add_resturant.aspx");
        }
    }
}