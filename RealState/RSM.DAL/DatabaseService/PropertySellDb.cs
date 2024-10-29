using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.DAL.DatabaseService
{
    public class PropertySellDb:DBOperations
    {
        public bool InsertPropertySaleData(PropertySell propertySell)
        {
            _ctx.PropertySells.Add(propertySell);
            return _ctx.SaveChanges() > 0;
        }
    }
}
