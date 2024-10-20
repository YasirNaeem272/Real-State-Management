using RSM.BOL.Models;
using RSM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BLL
{
    public class PropertySellBLL
    {
        private readonly PropertySellDb _propertySellDb;
        public PropertySellBLL()
        {
                _propertySellDb = new PropertySellDb();
        }
        public void Create(PropertySell propertySell)
        {
            _propertySellDb.Create(propertySell);
        }
    }
}
