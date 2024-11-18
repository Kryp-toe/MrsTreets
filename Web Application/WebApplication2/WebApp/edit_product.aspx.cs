using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class edit_product : System.Web.UI.Page
    {
        Service1Client sc = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( (Session["ID"] == null) && (Session["Type Of"] == null) )
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if(Session["Type Of"].ToString() == "OWNER")
                {
                    if (!IsPostBack)
                    {
                        if ( (Request.QueryString["prodID"] != null) && (Request.QueryString["busID"] != null) )
                        {
                            int prodID = Convert.ToInt32(Request.QueryString["prodID"]);
                            var p = sc.getProduct(prodID);

                            if (p != null)
                            {
                                PRODUCT product = new PRODUCT
                                {
                                    NAME = p.NAME,
                                    DESCRIPTION = p.DESCRIPTION,
                                    PRICE = p.PRICE,
                                    ALLERGIES = p.ALLERGIES,
                                    CATEGORY = p.CATEGORY,
                                    ISACTIVE = p.ISACTIVE
                                };

                                name.Value = product.NAME;
                                description.Value = product.DESCRIPTION;
                                category.Value = product.CATEGORY;
                                allergies.Value = product.ALLERGIES;
                                price.Value = String.Format("{0:N2}", Convert.ToDecimal(product.PRICE));
                                active.Value = product.ISACTIVE.ToString();
                                editProd.Enabled = true;
                            }
                            else
                            {
                                lblerror.InnerText = "Unable to find product";
                                lblerror.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Redirect("manage_products.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("home.aspx");
                }
            }
        }

        protected void editProd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["prodID"] != null)
            {
                int prodID = Convert.ToInt32(Request.QueryString["prodID"]);
                var p = sc.getProduct(prodID);

                if (p != null)
                {
                    PRODUCT product = new PRODUCT
                    {
                        NAME = p.NAME,
                        DESCRIPTION = p.DESCRIPTION,
                        PRICE = p.PRICE,
                        ALLERGIES = p.ALLERGIES,
                        CATEGORY = p.CATEGORY,
                        ISACTIVE = p.ISACTIVE
                    };

                    bool result = sc.editProduct(prodID, name.Value, Convert.ToDecimal(price.Value), description.Value, allergies.Value, category.Value, Convert.ToBoolean(active.Value));

                    if (result)
                    {
                        lblerror.InnerText = "Sucessfully changed product.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        lblerror.InnerText = "An error occured when changing product.";
                        lblerror.Visible = true;
                    }
                }
                else
                {
                    lblerror.InnerText = "Unable to find product";
                    lblerror.Visible = true;
                }
            }
            else
            {
                Response.Redirect("manage_products.aspx?busID=" + Convert.ToInt32(Request.QueryString["busID"].ToString()));
            }
        }

        protected void manageProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_products.aspx?busID=" + Convert.ToInt32(Request.QueryString["busID"].ToString()));
        }

        protected void manageBusinesess_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_businesses.aspx");
        }
    }
}