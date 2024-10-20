using RSM.BOL.Models;
using RSM.DAL.Context;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace RSM.DAL.DatabaseService
{
    public class DBOperations_Property:DBOperations
    {
        public bool InsertPropertyData(Property property)
        {
            _ctx.Properties.Add(property);
            int rowInserted = _ctx.SaveChanges();

            return rowInserted > 0;
        }

        public List<Property> GetProperties()
        {
            return _ctx.Properties.ToList();
        }

        public bool UpdatePropertyOwner(int ownerId, int propertyId)
        {
            var property = _ctx.Properties.Find(propertyId);
            if (property != null)
            {
                property.OwnerId = ownerId; // Assign the selected OwnerID
                property.PropertyStatus = PropertyStatus.Sold; // Update the status
                int rowInserted = _ctx.SaveChanges();
                return rowInserted > 0;
            }
            return false;
        }
        
        public List<Property> GetPropertiesByOwner(int id)
        {
            return  _ctx.Properties
                    .Where(p => p.OwnerId == id).ToList();
            //return Json(properties, JsonRequestBehavior.AllowGet);
        }

    }
}
