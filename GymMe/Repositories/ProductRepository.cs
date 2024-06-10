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
        public static List<MsSuplement> GetSupplements()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<MsSuplement> sups = (from sup in db.MsSuplements select sup).ToList();
            return sups;
        }

        public static List<String> GetSupplementTypes()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<String> types = (from type in db.MsSuplementTypes select type.SuplementTypeName).ToList();
            return types;
        }

        public static string GetSupplementType(int id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            string type = (from t in db.MsSuplementTypes where t.SuplementTypeID == id select t.SuplementTypeName).FirstOrDefault();
            return type;    
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

        public static void UpdateSupplement(int supId, string supName, int supPrice, DateTime supExpiry, int supTypeID)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == supId select s).FirstOrDefault();
            sup.SuplementName = supName;
            sup.SuplementPrice = supPrice;
            sup.SuplementExpiryDate = supExpiry;
            sup.SuplementTypeID = supTypeID;
            db.SaveChanges();
        }

        public static MsSuplement GetSupplement(int id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == id select s).FirstOrDefault();
            return sup;
        }

        public static void DeleteSupplement(int id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == id select s).FirstOrDefault();
            db.MsSuplements.Remove(sup);
            db.SaveChanges();
        }
    }
}