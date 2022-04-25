using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Core
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ApplicationDTO> Applications { get; set; } 
        public DbSet<RouteDTO> Routes { get; set; } 

        #region Permissions
        public DbSet<PermissionDTO> Permissions { get; set; }
        public DbSet<PermissionCategoryDTO> PermissionCategories { get; set; }
        public DbSet<OrganisationTypePermissionDTO> OrganisationTypePermissions { get; set; }
        public DbSet<RolePermissionDTO> RolePermissions { get; set; }
        #endregion

        public DbSet<TranslationDTO> Translations { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationDTO>(m =>
            {
                m.HasKey(a => a.Id);
            });

            modelBuilder.Entity<RouteDTO>(m =>
            {
                m.HasKey(r => r.Id);
                m.Property(s => s.Translations)
                    .HasColumnType("jsonb");
            });

            #region Permissions
            modelBuilder.Entity<PermissionDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<PermissionCategoryDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });
            
            modelBuilder.Entity<OrganisationTypePermissionDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.HasOne(p => p.Permission)
                    .WithMany(p => p.OrganisationTypePermissions)
                    .HasForeignKey(p => p.PermissionId);
            });
            #endregion

            #region Translations
            modelBuilder.Entity<TranslationDTO>(m =>
            {
                m.HasKey(t => t.Id);
                m.HasIndex(t => t.Code);
            });
            #endregion



        }
    }
}