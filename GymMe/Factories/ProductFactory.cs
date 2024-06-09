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
    }
}