using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class manage_products : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.showDDL();
                GenerateDynamicContent();

            }
        }

        private void GenerateDynamicContent()
        {
            
            int businessId = int.Parse(DropDownList1.SelectedValue);
            menuList.Controls.Clear();
            foreach (PRODUCT prod in this.sc.getAllProducts(businessId))
            {
                // Create a new LiteralControl
                LiteralControl itemHtml = new LiteralControl();

                // Define the HTML content
                itemHtml.Text += "<div class='item'>";
                itemHtml.Text += "<h3 class='item-name'>" + prod.NAME + "</h3>";
                itemHtml.Text += "<p class='description'>" + prod.DESCRIPTION + "</p>";
                itemHtml.Text += "<p class='price'>" + prod.PRICE.ToString("C", new CultureInfo("en-ZA")) + "</p>";
                itemHtml.Text += "<div class='crud-btn-menu'>";
                itemHtml.Text += $"<a href='deleteprod.aspx?prodID={prod.ID}' class='delete-rest'>✕</a>";
                itemHtml.Text += $"<a href='edit_product.aspx?busID={businessId} &prodID={prod.ID}' class='edit-rest'>✎</a>";
                itemHtml.Text += "</div></div>";

                // Add the LiteralControl to the PlaceHolder
                menuList.Controls.Add(itemHtml);



                // Generate the delete button
                //Button deleteButton = new Button();
                //deleteButton.CssClass = "delete-rest";
                //deleteButton.Text = "✕";
                //deleteButton.CommandArgument = prod.ID.ToString();
                //deleteButton.ToolTip = "delete restaurant";
                ////deleteButton.UseSubmitBehavior = false;  // Prevent form submission if necessary
                //deleteButton.Click += new EventHandler(DeleteButton_Click);
                //menuList.Controls.Add(deleteButton);

                //// Generate the edit button
                //Button editButton = new Button();
                //editButton.CssClass = "edit-rest";
                //editButton.Text = "✎";
                //editButton.CommandArgument = prod.ID.ToString();
                //editButton.ToolTip = "edit restaurant";
                //editButton.UseSubmitBehavior = false;  // Prevent form submission if necessary
                //editButton.Click += new EventHandler(EditButton_Click);
                //menuList.Controls.Add(editButton);

                //// Create a LiteralControl to close the div
                //LiteralControl itemHtmlEnd = new LiteralControl();
                //itemHtmlEnd.Text = "</div></div>";
                //menuList.Controls.Add(itemHtmlEnd);

            }

        }

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int prodId = int.Parse(btn.CommandArgument);
        //    sc.deleteProduct(prodId);
        //    GenerateDynamicContent();
        //}

        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    // Handle edit button click
        //    //Respone.Write("Edit button clicked!");
        //    Button btn = (Button)sender;
        //    int prodId = int.Parse(btn.CommandArgument);
        //    Response.Redirect("edit_product.aspx?busID=" + DropDownList1.SelectedValue + "&prodID=" + prodId);
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            menuList.Controls.Clear();
            GenerateDynamicContent();
        }


        private void showDDL()
        {

            BUSINESS[] arry = this.sc.getAllRestByOwner(int.Parse(Session["ID"].ToString()));
            if(arry != null)
            {
                DropDownList1.DataSource = arry;
                DropDownList1.DataTextField = "NAME";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();


                // Set the first item as default
                if (DropDownList1.Items.Count > 0)
                {
                    DropDownList1.SelectedIndex = 0;
                }

            }
           


        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_product.aspx?busID=" + DropDownList1.SelectedValue);
        }
    }
}