using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TourOfHeroes.DataAccess.Entities
{
    public partial class TourOfHeroesContext : DbContext
    {
        public TourOfHeroesContext()
        {
        }

        public TourOfHeroesContext(DbContextOptions<TourOfHeroesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-8N0V055;Database=TourOfHeroes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Heroes_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Passsword).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
