using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class DatabaseSingleton
    {
        private static DatabaseEntities2 db = null;
        
        public static DatabaseEntities2 GetInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities2();
            }
            return db;
        }

    }
}