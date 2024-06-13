using GymMe.Factories;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class ProductHandler
    {
        public static void RecordTransaction(TransactionDetail newTrans)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.TransactionDetails.Add(newTrans);
            db.SaveChanges();
        }

        public static void HandleTransactionStatus(int transID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            TransactionHeader targetUser = (from th in db.TransactionHeaders where th.TransactionID == transID select th).FirstOrDefault();
            targetUser.Status = "Handled";
            db.SaveChanges();
        }

        public static void CreateType(MsSuplementType type)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.MsSuplementTypes.Add(type);
            db.SaveChanges();
        }

        public static void CreateTransaction(TransactionHeader newTransaction)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.TransactionHeaders.Add(newTransaction);
            db.SaveChanges();
        }

        public static void InsertSupplement(MsSuplement newSup)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.MsSuplements.Add(newSup);
            db.SaveChanges();
        }

        public static void UpdateSupplement(int supId, string supName, int supPrice, DateTime supExpiry, int supTypeID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == supId select s).FirstOrDefault();
            sup.SuplementName = supName;
            sup.SuplementPrice = supPrice;
            sup.SuplementExpiryDate = supExpiry;
            sup.SuplementTypeID = supTypeID;
            db.SaveChanges();
        }

        public static void InsertCart(MsCart newCart)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.MsCarts.Add(newCart);
            db.SaveChanges();
        }

        public static void DeleteSupplement(int id)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == id select s).FirstOrDefault();
            db.MsSuplements.Remove(sup);
            db.SaveChanges();
        }

        public static void CheckoutOrder(int userID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == userID select c).ToList();
            foreach (MsCart cart in carts)
            {
                int id = Convert.ToInt32(cart.UserID);
                int transID = ProductRepository.generateTransactionID();
                TransactionHeader newTrans = ProductFactory.CreateTransactionHeader(transID, userID);
                TransactionDetail newTransDetail = ProductFactory.CreateTransactionDetail(transID, cart.SuplementID, cart.Quantity);
                CreateTransaction(newTrans);
                RecordTransaction(newTransDetail);
                db.MsCarts.Remove(cart);

            }
            db.SaveChanges();
        }

        public static void ClearCart(int userID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == userID select c).ToList();
            foreach (MsCart cart in carts)
            {
                db.MsCarts.Remove(cart);
            }
            db.SaveChanges();
        }
    }
}