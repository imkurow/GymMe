using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factories
{
    public class ProductFactory
    {
        public static MsSuplement CreateSupplement(string suppName, int price, DateTime expiry, int typeId)
        {
            MsSuplement newSup = new MsSuplement();
            newSup.SuplementName = suppName;
            newSup.SuplementPrice = price;
            newSup.SuplementExpiryDate = expiry;
            newSup.SuplementTypeID = typeId;
            return newSup;
        }

        public static MsCart CreateCart(int userId, int suppId, int quantity)
        {
            MsCart newCart = new MsCart();
            newCart.UserID = userId;
            newCart.SuplementID = suppId;
            newCart.Quantity = quantity;
            return newCart;
        }

        public static TransactionHeader CreateTransactionHeader(int transID, int userID)
        {
            TransactionHeader newTrans = new TransactionHeader();
            newTrans.UserID = userID;
            newTrans.TransactionID = transID;
            newTrans.Status = "Unhandled";
            newTrans.TransactionDate = DateTime.Now;
            return newTrans;
        }

        public static TransactionDetail CreateTransactionDetail(int transID, int suppID, int quantity)
        {
            TransactionDetail newTransDetail = new TransactionDetail();
            newTransDetail.TransactionID = transID;
            newTransDetail.SuplementID = suppID;
            newTransDetail.Quantity = quantity;
            return newTransDetail;
        }
    }
}