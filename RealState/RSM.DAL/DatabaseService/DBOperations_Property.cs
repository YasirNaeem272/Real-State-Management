using RSM.BOL.Models;
using RSM.DAL.Context;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace RSM.DAL.DatabaseService
{
    public class DBOperations_Property
    {
        private DBContextClass db = new DBContextClass();
        public bool InsertPropertyData(Property property)
        {
            db.Properties.Add(property);
            int rowInserted = db.SaveChanges();

            return rowInserted > 0;
        }

        public List<Property> GetProperties()
        {
            return db.Properties.ToList();
        }

        public bool UpdatePropertyOwner(int ownerId, int propertyId)
        {
            var property = db.Properties.Find(propertyId);
            if (property != null)
            {
                property.OwnerId = ownerId; // Assign the selected OwnerID
                property.PropertyStatus = PropertyStatus.Sold; // Update the status
                int rowInserted = db.SaveChanges();
                return rowInserted > 0;
            }
            return false;
        }
    }
}
