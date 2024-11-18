using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.ServiceReference1;

namespace WebApp
{
    public partial class home : System.Web.UI.Page
    {
        Service1Client service = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                divRestarauntConainer.InnerHtml = Utitily.HTML.getRESTARAUNTS_HTML();

        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //   BUSINESS[] resultBusiness = this.service.getSearchedProducts(txtSearch.Text);

        //    if (resultBusiness != null)
        //        divRestarauntConainer.InnerHtml = Utitily.HTML.getSEARCHED_HTML(resultBusiness);
        //}

        protected void btnSearchLocation_Click(object sender, EventArgs e)
        {
            BUSINESS[] resultBusinesses = this.service.getSearchedBusinessLocation(txtSearchLocation.Text);

            if (resultBusinesses != null)
                divRestarauntConainer.InnerHtml = Utitily.HTML.getLocationSearched_HTML(resultBusinesses);

        }

        //protected void btnSortCafe_Click(object sender, EventArgs e)
        //{
        //    BUSINESS[] businesses = this.service.getProductsByCategory("Cafe");
        //    if(businesses != null)
        //        divRestarauntConainer.InnerHtml = Utitily.HTML.getSORTED_HTML(businesses);
        //}

        //protected void btnSortResturant_Click(object sender, EventArgs e)
        //{
        //    BUSINESS[] businesses = this.service.getProductsByCategory("Restaurant");
        //    if(businesses != null)
        //        divRestarauntConainer.InnerHtml = Utitily.HTML.getSORTED_HTML(businesses);
        //}

        //protected void btnSortBakery_Click(object sender, EventArgs e)
        //{
        //    BUSINESS[] businesses = this.service.getProductsByCategory("Bakery");
        //    if(businesses != null)
        //        divRestarauntConainer.InnerHtml = Utitily.HTML.getSORTED_HTML(businesses);
        //}
    }
}