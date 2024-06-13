using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class UserHandler
    {
        public static void CreateUser(MsUser newUser)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();

            db.MsUsers.Add(newUser);
            db.SaveChanges();
        }

        public static void UpdateUserProfile(string id, string username, string email, string gender, DateTime bod)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = bod;
            db.SaveChanges();
        }
        public static void UpdateUserCredential(string id, string password)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            user.UserPassword = password;
            db.SaveChanges();
        }
    }
}