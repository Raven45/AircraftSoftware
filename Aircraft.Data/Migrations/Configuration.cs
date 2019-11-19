namespace Aircraft.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aircraft.Data.Context.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aircraft.Data.Context.Context context)
        {
            //Create the default data set. For starters, this is set to the example data sent in the email.
            Entity.Aircraft AC1 = new Entity.Aircraft { Id = 1, Model = "Falcon 7X", SerialNumber = "001" };
            Entity.Aircraft AC2 = new Entity.Aircraft { Id = 2, Model = "Falcon 8X", SerialNumber = "001" };
            Entity.Aircraft AC3 = new Entity.Aircraft { Id = 3, Model = "Falcon 2000", SerialNumber = "002" };
            Entity.Aircraft AC4 = new Entity.Aircraft { Id = 4, Model = "Falcon 7X", SerialNumber = "002" };

            context.Aircrafts.AddOrUpdate(AC1);
            context.Aircrafts.AddOrUpdate(AC2);
            context.Aircrafts.AddOrUpdate(AC3);
            context.Aircrafts.AddOrUpdate(AC4);
        }
    }
}
