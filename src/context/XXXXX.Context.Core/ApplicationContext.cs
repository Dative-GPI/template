using Microsoft.EntityFrameworkCore;

using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Core
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ApplicationDTO> Applications { get; set; } 
        public DbSet<DrawerRouteDTO> Routes { get; set; } 

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

            modelBuilder.Entity<DrawerRouteDTO>(m =>
            {
                m.HasKey(r => r.Id);
                m.Property(s => s.Translations)
                    .HasColumnType("jsonb");
            });

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