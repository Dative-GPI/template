using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core;
using XXXXX.Context.Core.DTOs;
using XXXXX.Context.Migrations.Shared;

namespace XXXXX.Context.Migrations
{
    public class CustomApplicationContext : ApplicationContext
    {
        public CustomApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // It could be possible to avoid the dependency to Context.Core in Migrations.Shared
            //  by creating the providers here ...
            var fixturesProvider = new FixturesProvider("../Bongard.Context.Fixtures/Fixtures");

            modelBuilder.Entity<PermissionDTO>()
                .HasData(fixturesProvider.GetPermissions());

            modelBuilder.Entity<PermissionCategoryDTO>()
                .HasData(fixturesProvider.GetPermissionCategories());

            modelBuilder.Entity<PermissionAdminDTO>()
                .HasData(fixturesProvider.GetPermissionAdmins());

            modelBuilder.Entity<PermissionAdminCategoryDTO>()
                .HasData(fixturesProvider.GetPermissionAdminCategories());

            modelBuilder.Entity<TranslationDTO>()
                .HasData(fixturesProvider.GetTranslations());
        }
    }
}