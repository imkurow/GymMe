using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class ProductRepository
    {
        public static List<MsSuplementType> GetSupplementTypes()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            return db.MsSuplementTypes.ToList();
        }

    }
}