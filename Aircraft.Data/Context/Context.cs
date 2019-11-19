using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aircraft.Data.Context
{
    /// <summary>
    /// The code-first db context.
    /// </summary>
    public class Context: DbContext
    {
        //Default constructor. We're passing our own connection string as the default.
        public Context(): base("DefaultConnection")
        {

        }

        //Define the data set for aircraft.
        public DbSet<Entity.Aircraft> Aircrafts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
