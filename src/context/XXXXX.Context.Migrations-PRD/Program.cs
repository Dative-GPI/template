using System;
using System.Text.Json;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Bongard.Context.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<DbContext> contexts = new List<DbContext>()
            {
                new CustomApplicationContextDesignFactory().CreateDbContext(null),
            };

            foreach (var context in contexts)
            {
                Console.WriteLine($"Applying migrations for {context.ToString()}");
                Console.WriteLine(JsonSerializer.Serialize(context.Database.GetPendingMigrations()));
                context.Database.Migrate();
            }
        }
    }
}
