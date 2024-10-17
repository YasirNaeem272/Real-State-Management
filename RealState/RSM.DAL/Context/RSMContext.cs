
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RSM.BOL.Models;


namespace RSM.DAL.Context
{
    public class RSMContext:DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertySell> propertySells { get; set; }
        //public DbSet<Owner> Owners { get; set; }
        public RSMContext() : base("AddCon")
        {

        }
        //private static string GetConnectionString()
        //{
        //    return ConfigurationManager.ConnectionStrings["AddCon"].ConnectionString;
        //}
    }
}
