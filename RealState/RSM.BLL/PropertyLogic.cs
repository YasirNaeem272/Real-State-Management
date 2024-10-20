using RSM.BOL.Models;
using RSM.DAL.DatabaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BLL
{
    public class PropertyLogic
    {
        private readonly DBOperations_Property _dBOperationsProperty;

        public PropertyLogic()
        {
            _dBOperationsProperty = new DBOperations_Property();
        }

        

    }
}
