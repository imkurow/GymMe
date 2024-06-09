using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GymMe.Controllers
{
    public class UserController
    {
        public static bool isValidEmail(string email)
        {
            return email.EndsWith(".com", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsPasswordAlphanumeric(string password)
        {
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(password, pattern);
        }
    }
}