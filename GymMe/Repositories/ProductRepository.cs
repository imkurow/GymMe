using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GymMe.Repositories
{
    public class ProductRepository
    {
        public static List<String> GetSupplementTypes()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<String> types = (from type in db.MsSuplementTypes select type.SuplementTypeName).ToList();
            return types;
        }

        public static int GetTypeId(string typeName)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int id = (from type in db.MsSuplementTypes where type.SuplementTypeName == typeName select type.SuplementTypeID).FirstOrDefault();
            return id;
        }

        public static void InsertSupplement(MsSuplement newSup)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            db.MsSuplements.Add(newSup);
            db.SaveChanges();
        }
    }
}