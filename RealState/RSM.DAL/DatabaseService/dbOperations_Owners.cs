using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSM.DAL.DatabaseService
{
    public class DBOperations_Owners
    {
        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        private DBContextClass db = new DBContextClass();
        public bool InsertOwnerData(Owner ownerData, string imagePath = ownerDefaultImagePath)
        {
            ownerData.ImagePath = imagePath;
            //ownerData.EntryTime = DateTime.UtcNow;
            db.Owners.Add(ownerData);
            int rowInserted = db.SaveChanges();

            return rowInserted > 0;
        }

        public List<Owner> GetOwners()
        {
            return db.Owners.ToList();
        }
    }
}
