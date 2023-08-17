using Foundation.Template.Context;
using Microsoft.EntityFrameworkCore;

namespace XXXXX.Context.Core
{
    public class ApplicationContext : BaseApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}