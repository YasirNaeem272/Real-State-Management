using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSM.BOL.Models;
using RSM.DAL.DatabaseService;

namespace RSM.BLL
{
    public class PropertySaleLogic
    {
        private readonly DBOperations_Owners _ownersDB;
        private readonly DBOperations_Property _propertyDB;
        private readonly DBOperations_Nominees _nomineeDB;
        private readonly PropertySellDb _propertySaleDB;
        public PropertySaleLogic()
        {
            _ownersDB = new DBOperations_Owners();
            _propertyDB = new DBOperations_Property();
            _nomineeDB = new DBOperations_Nominees();
            _propertySaleDB = new PropertySellDb();
        }

        public bool OnConfirmSaleRequested(int propertyId, int ownerId, PropertySell saleData)
        {
            saleData.PropertyID = propertyId;
           var isSaleDataInserted = _propertySaleDB.InsertPropertySaleData(saleData);

            var isPropertyUpdated = _propertyDB.UpdatePropertyOwnerAndStatus(ownerId, propertyId);

            return isSaleDataInserted && isPropertyUpdated;
        }

        public Tuple<Owner,Property,Nominee,PropertySell> GetPropertySaleSummary(int propertyId, int ownerId, int nomineeId,PropertySell saleData)
        {
           var owner = _ownersDB.GetOwnerByID(ownerId);
            var property = _propertyDB.GetPropertyByID(propertyId);
            var nominee = _nomineeDB.GetNomineeById(nomineeId);

            //property Sale Logic

            var balance = Math.Max(0, saleData.TotalCostOfProperty - saleData.PaymentOnBooking);

            if(saleData.PaymentPlan == PaymentPlan.Installlement)
            {
                saleData.PerMonthInstallment = balance / saleData.NumberOfInstallments;
            }
            saleData.Balance = balance;

            return Tuple.Create(owner, property,nominee,saleData);
        }


    }
}
