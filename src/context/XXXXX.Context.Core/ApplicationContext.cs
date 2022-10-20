using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Core
{
    public class ApplicationContext : DbContext
    {

        #region Common
        public DbSet<ImageDTO> Images { get; set; }
        public DbSet<ApplicationDTO> Applications { get; set; }
        public DbSet<RouteDTO> Routes { get; set; }
        #endregion

        #region Permissions
        public DbSet<PermissionDTO> Permissions { get; set; }
        public DbSet<PermissionAdminDTO> PermissionAdmins { get; set; }
        public DbSet<PermissionCategoryDTO> PermissionCategories { get; set; }
        public DbSet<PermissionAdminCategoryDTO> PermissionAdminCategories { get; set; }
        public DbSet<OrganisationTypePermissionDTO> OrganisationTypePermissions { get; set; }
        public DbSet<RolePermissionDTO> RolePermissions { get; set; }
        public DbSet<RoleAdminPermissionDTO> RoleAdminPermissions { get; set; }
        #endregion


        #region Translations
        public DbSet<TranslationDTO> Translations { get; set; }
        public DbSet<ApplicationTranslationDTO> ApplicationTranslations { get; set; }
        #endregion


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Common
            modelBuilder.Entity<ImageDTO>(m =>
            {
                m.HasKey(i => i.Id);
            });

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
            #endregion

            #region Permissions
            modelBuilder.Entity<PermissionDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<PermissionAdminDTO>(m =>
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

            modelBuilder.Entity<PermissionAdminCategoryDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<OrganisationTypePermissionDTO>(m =>
            {
                m.HasKey(otp => otp.Id);
                m.HasOne(otp => otp.Permission)
                    .WithMany(p => p.OrganisationTypePermissions)
                    .HasForeignKey(otp => otp.PermissionId);
            });

            modelBuilder.Entity<RolePermissionDTO>(m =>
            {
                m.HasKey(rp => rp.Id);
                m.HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId);
            });

            modelBuilder.Entity<RoleAdminPermissionDTO>(m =>
            {
                m.HasKey(rp => rp.Id);
                m.HasOne(rp => rp.PermissionAdmin)
                    .WithMany(p => p.RoleAdminPermissions)
                    .HasForeignKey(rp => rp.PermissionAdminId);
            });
            #endregion

            #region Translations
            modelBuilder.Entity<TranslationDTO>(m =>
            {
                m.HasKey(t => t.Id);
                m.HasIndex(t => t.Code).IsUnique();
            });

            modelBuilder.Entity<ApplicationTranslationDTO>(m =>
            {
                m.HasKey(t => t.Id);
                m.HasOne(t => t.Translation)
                    .WithMany()
                    .HasForeignKey(t => t.TranslationId);
                m.HasOne(t => t.Application)
                    .WithMany()
                    .HasForeignKey(t => t.ApplicationId);
            });
            #endregion
        }
    }
}