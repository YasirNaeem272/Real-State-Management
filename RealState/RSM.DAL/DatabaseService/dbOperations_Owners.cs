using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSM.DAL.DatabaseService
{
    public class DBOperations_Owners:DBOperations
    {
        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        public bool InsertOwnerData(Owner ownerData, string imagePath = ownerDefaultImagePath)
        {
            ownerData.ImagePath = imagePath;
            //ownerData.EntryTime = DateTime.UtcNow;
            _ctx.Owners.Add(ownerData);
            int rowInserted = _ctx.SaveChanges();

            return rowInserted > 0;
        }

        public List<Owner> GetOwners()
        {
            return _ctx.Owners.ToList();
        }
       
    }
}
