using RSM.BOL.Models;
using System.Data.Entity;

namespace RSM.DAL.Context
{
     internal class DBContextClass : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DBContextClass() : base("MyDbContext")
        {

        }
    }
}
