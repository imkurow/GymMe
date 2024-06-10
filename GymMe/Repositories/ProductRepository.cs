using GymMe.Factories;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace GymMe.Repositories
{
    public class ProductRepository
    {
        public static List<dynamic> GetSupplements()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<dynamic> sups = (from s in db.MsSuplements
                                      join t in db.MsSuplementTypes
                                      on s.SuplementTypeID equals t.SuplementTypeID // Assuming there's a foreign key relationship
                                      select new
                                      {
                                          SuplementID = s.SuplementID,
                                          SuplementName = s.SuplementName,
                                          SuplementPrice = s.SuplementPrice,
                                          SuplementExpiryDate = s.SuplementExpiryDate,
                                          SuplementTypeName = t.SuplementTypeName}).ToList<dynamic>();
            return sups;
        }

        public static List<dynamic> GetUserCarts(int id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<dynamic> carts = (
                    from c in db.MsCarts
                    join s in db.MsSuplements
                    on c.SuplementID equals s.SuplementID
                    where c.UserID == id
                    select new
                    {
                        SuplementName = s.SuplementName,
                        OrderQuantity = c.Quantity,
                    }).ToList<dynamic>();
            return carts;
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

        public static void ClearCart(int userID)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == userID select c).ToList();
            foreach (MsCart cart in carts)
            {
                db.MsCarts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static void CheckoutOrder(int userID)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == userID select c).ToList();
            foreach (MsCart cart in carts)
            {
                int id = Convert.ToInt32(cart.UserID);
                TransactionHeader newTrans = ProductFactory.CreateTransactionHeader(id);
                CreateTransaction(newTrans);
                db.MsCarts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static void CreateTransaction(TransactionHeader newTransaction)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            db.TransactionHeaders.Add(newTransaction);
            db.SaveChanges();
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

        public static int GetSupplementID(string supplementName)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int id = (from s in db.MsSuplements where s.SuplementName == supplementName select s.SuplementID).FirstOrDefault();
            return id;
        }

        public static void InsertCart(MsCart newCart)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            db.MsCarts.Add(newCart);
            db.SaveChanges();
        }   

        public static List<string> GetSupplementNames()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<string> names = (from s in db.MsSuplements select s.SuplementName).ToList();
            return names;
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