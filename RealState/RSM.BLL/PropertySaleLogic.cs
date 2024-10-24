using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSM.BOL.Models;

namespace RSM.BLL
{
    public class PropertySaleLogic
    {
        private readonly RSMContext _ctx;
        public PropertySaleLogic()
        {
            _ctx = new RSMContext();
        }

        public void GetPropertySaleSummary(int propertyId, int ownerId, int NomineeId,PropertySell propertySell)
        {
           //var owner = _ctx.Owners.Where(n => n.OwnerId == ownerId).ToList();
        }
    }
}
