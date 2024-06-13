using GymMe.Dataset;
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

        public static DataSet GetReports()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<TransactionHeader> trans = (from t in db.TransactionHeaders select t).ToList();
            DataSet data = new DataSet();
            var header = data.TransactionHeader;
            var detailTable =data.TransactionDetail;
            var suplementTable = data.MsSuplement;

            foreach (TransactionHeader t in trans)
            {
                var hrow = header.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                header.Rows.Add(hrow);

                foreach (TransactionDetail td in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = td.TransactionID;
                    drow["SuplementID"] = td.SuplementID;
                    drow["Quantity"] = td.Quantity;
                    detailTable.Rows.Add(drow);

                    var srow = suplementTable.NewRow();
                    srow["SuplementID"] = td.SuplementID;
                    srow["SuplementName"] = td.MsSuplement.SuplementName;
                    srow["SuplementPrice"] = td.MsSuplement.SuplementPrice;
                    suplementTable.Rows.Add(srow);
                }
            }
            return data;
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

        public static string GetSupplementType(int SupID)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            string type = (from t in db.MsSuplementTypes 
                           join s in db.MsSuplements on t.SuplementTypeID equals s.SuplementTypeID
                           where s.SuplementID == SupID select t.SuplementTypeName).FirstOrDefault();
            return type;    
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

        public static int GetTypeId(string typeName)
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int id = (from type in db.MsSuplementTypes where type.SuplementTypeName == typeName select type.SuplementTypeID).FirstOrDefault();
            return id;
        }

        public static int generateTransactionID()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            int? maxTransactionId = (from t in db.TransactionHeaders select (int?)t.TransactionID).Max();
            int id = maxTransactionId.HasValue ? maxTransactionId.Value + 1 : 1;
            return id;

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

        public static List<string> GetSupplementNames()
        {
            DatabaseEntities2 db = DatabaseSingleton.GetInstance();
            List<string> names = (from s in db.MsSuplements select s.SuplementName).ToList();
            return names;
        }
    }
}