namespace Mvc5Calculator.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class CalcConfiguration : DbMigrationsConfiguration<Mvc5Calculator.Models.CalculatorDBContext>
    {
        public CalcConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mvc5Calculator.Models.CalculatorDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
