﻿using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.DAL.DatabaseService
{
    public class PropertySellDb
    {
        private readonly RSMContext _ctx;

        public PropertySellDb() 
        {
         _ctx = new RSMContext();
        }
        public void Create(PropertySell propertySell)
        {
        _ctx.propertySales.Add(propertySell);   
        _ctx.SaveChanges();
        }
    }
}
