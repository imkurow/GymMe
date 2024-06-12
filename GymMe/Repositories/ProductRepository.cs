using GymMe.Factories;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
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
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
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

        public static List <TransactionHeader> HistoryCustomers(int id)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List <TransactionHeader> transactionHeaders = (from t in db.TransactionHeaders where t.UserID == id select t).ToList();
            return transactionHeaders;
        }

        public static List<dynamic> HistoryAdmins()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<dynamic> historyDetails = (from td in db.TransactionDetails
                                                join th in db.TransactionHeaders
                                                on td.TransactionID equals th.TransactionID
                                                join s in db.MsSuplements
                                                on td.SuplementID equals s.SuplementID
                                                join mu in db.MsUsers
                                                on th.UserID equals mu.UserID
                                             
                                                select new
                                                {
                                                    UserID = mu.UserID,
                                                    UserName = mu.UserName,
                                                    TransactionID = td.TransactionID,
                                                    TransactionDate = th.TransactionDate,
                                                    TransactionStatus = th.Status,
                                                    SuplementName = s.SuplementName,
                                                    Quantity = td.Quantity,
                                                    SuplementPrice = s.SuplementPrice
                                                }).ToList<dynamic>();
            return historyDetails;
        }

        public static List <dynamic> GetTransactionsDetails(int transID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<dynamic> transactionDetails = (from td in db.TransactionDetails
                                                join th in db.TransactionHeaders
                                                on td.TransactionID equals th.TransactionID
                                                join s in db.MsSuplements
                                                on td.SuplementID equals s.SuplementID
                                                join mu in db.MsUsers
                                                on th.UserID equals mu.UserID
                                                where td.TransactionID == transID
                                                select new
                                                {
                                                    UserName = mu.UserName,
                                                    TransactionID = td.TransactionID,
                                                    TransactionDate = th.TransactionDate,
                                                    TransactionStatus = th.Status,
                                                    SuplementName = s.SuplementName,
                                                    Quantity = td.Quantity,
                                                    SuplementPrice = s.SuplementPrice
                                                }).ToList<dynamic>();
            return transactionDetails;
        }
        public static List<String> GetSupplementTypes()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<String> types = (from type in db.MsSuplementTypes select type.SuplementTypeName).ToList();
            return types;
        }

        public static string GetSupplementType(int id)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            string type = (from t in db.MsSuplementTypes where t.SuplementTypeID == id select t.SuplementTypeName).FirstOrDefault();
            return type;    
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

        public static void CheckoutOrder(int userID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == userID select c).ToList();
            foreach (MsCart cart in carts)
            {
                int id = Convert.ToInt32(cart.UserID);
                int transID = generateTransactionID();
                TransactionHeader newTrans = ProductFactory.CreateTransactionHeader(transID, userID);
                TransactionDetail newTransDetail = ProductFactory.CreateTransactionDetail(transID, cart.SuplementID, cart.Quantity);
                CreateTransaction(newTrans);
                RecordTransaction(newTransDetail);
                db.MsCarts.Remove(cart);

            }
            db.SaveChanges();
        }

        public static void RecordTransaction(TransactionDetail newTrans)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.TransactionDetails.Add(newTrans);
            db.SaveChanges();
        }

        public static List<dynamic> GetTransactionsQueue()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<dynamic> transactions = (from th in db.TransactionHeaders
                                          join td in db.TransactionDetails
                                                                                    on th.TransactionID equals td.TransactionID
                                          join s in db.MsSuplements
                                                                                    on td.SuplementID equals s.SuplementID
                                          join u in db.MsUsers
                                                                                    on th.UserID equals u.UserID
                                          where th.Status == "Unhandled"
                                          select new
                                          {
                                              TransactionID = th.TransactionID,
                                              UserName = u.UserName,
                                              TransactionDate = th.TransactionDate,
                                              TransactionStatus = th.Status,
                                              SuplementName = s.SuplementName,
                                              Quantity = td.Quantity,
                                              SuplementPrice = s.SuplementPrice
                                          }).ToList<dynamic>();
            return transactions;
        }

        public static void HandleTransactionStatus(int transID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            TransactionHeader targetUser = (from th in db.TransactionHeaders where th.TransactionID == transID select th).FirstOrDefault();
            targetUser.Status = "Handled";
            db.SaveChanges();
        }

        public static void CreateTransaction(TransactionHeader newTransaction)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.TransactionHeaders.Add(newTransaction);
            db.SaveChanges();
        }

        public static int GetTypeId(string typeName)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int id = (from type in db.MsSuplementTypes where type.SuplementTypeName == typeName select type.SuplementTypeID).FirstOrDefault();
            return id;
        }

        public static void InsertSupplement(MsSuplement newSup)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.MsSuplements.Add(newSup);
            db.SaveChanges();
        }

        public static int generateTransactionID()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int? maxTransactionId = (from t in db.TransactionHeaders select (int?)t.TransactionID).Max();
            int id = maxTransactionId.HasValue ? maxTransactionId.Value + 1 : 1;
            return id;

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

        public static MsSuplement GetSupplement(int id)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == id select s).FirstOrDefault();
            return sup;
        }

        public static int GetSupplementID(string supplementName)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int id = (from s in db.MsSuplements where s.SuplementName == supplementName select s.SuplementID).FirstOrDefault();
            return id;
        }

        public static void InsertCart(MsCart newCart)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            db.MsCarts.Add(newCart);
            db.SaveChanges();
        }   

        public static List<string> GetSupplementNames()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<string> names = (from s in db.MsSuplements select s.SuplementName).ToList();
            return names;
        }

        public static void DeleteSupplement(int id)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            MsSuplement sup = (from s in db.MsSuplements where s.SuplementID == id select s).FirstOrDefault();
            db.MsSuplements.Remove(sup);
            db.SaveChanges();
        }
    }
}