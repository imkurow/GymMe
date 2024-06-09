using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
    public class UserFactory
    {
        public static MsUser createUser(string username, string email, string password, string gender, DateTime bod)
        {
            MsUser user = new MsUser();
            user.UserName = username;
            user.UserEmail = email;
            user.UserPassword = password;
            user.UserGender = gender;
            user.UserRole = "Customer";
            user.UserDOB = bod;
            return user;
        }

    }
}