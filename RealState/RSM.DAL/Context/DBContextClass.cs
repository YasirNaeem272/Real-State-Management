using RSM.BOL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.DAL.Context
{
    class DBContextClass : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DBContextClass() : base("MyDbContext")
        {

        }
    }
}
