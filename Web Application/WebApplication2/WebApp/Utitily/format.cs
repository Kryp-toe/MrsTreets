using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Utitily
{
    public static class format
    {
        public static string getFormattedPrice(decimal price)
        {
            return $"R {price:0,0.00}";
        }

        public static string getFormattedPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Insert(3, "-").Insert(7, "-");
        }

    }
}