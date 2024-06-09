using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GymMe.Controllers
{
    public class ProductController
    {
        public static bool isContainSupplement(string supplementName)
        {
            return supplementName.IndexOf("Supplement", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool isGreaterThanToday(DateTime date)
        {
            DateTime today = DateTime.Today;
            if (date > today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isValidPrice(int price)
        {
            if (price >= 3000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}