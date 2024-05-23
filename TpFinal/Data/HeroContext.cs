using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TpFinal.Models;

namespace TpFinal.Data
{
    public partial class HeroContext : DbContext
    {
        public HeroContext()
        {
        }

        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArchivesComic> ArchivesComics { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Comic> Comics { get; set; } = null!;
        public virtual DbSet<ComicsHero> ComicsHeroes { get; set; } = null!;
        public virtual DbSet<Duo> Duos { get; set; } = null!;
        public virtual DbSet<Hero> Heroes { get; set; } = null!;
        public virtual DbSet<Identite> Identites { get; set; } = null!;
        public virtual DbSet<Pouvoir> Pouvoirs { get; set; } = null!;
        public virtual DbSet<VHeroDetail> VHeroDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BDHero");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchivesComic>(entity =>
            {
                entity.Property(e => e.ArchivesComicsId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Comic>(entity =>
            {
                entity.HasKey(e => e.ComicsId)
                    .HasName("Pk_Hero_ComicsID");
            });

            modelBuilder.Entity<ComicsHero>(entity =>
            {
                entity.HasOne(d => d.Comics)
                    .WithMany()
                    .HasForeignKey(d => d.ComicsId)
                    .HasConstraintName("Fk_Hero_ComiscHeroID");

                entity.HasOne(d => d.Hero)
                    .WithMany()
                    .HasForeignKey(d => d.HeroId)
                    .HasConstraintName("Fk_Hero_HeroComicsID");
            });

            modelBuilder.Entity<Duo>(entity =>
            {
                entity.HasKey(e => e.EquipeId)
                    .HasName("Pk_Hero_DuoID");

                entity.HasOne(d => d.Hero1)
                    .WithMany(p => p.DuoHero1s)
                    .HasForeignKey(d => d.Hero1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Hero_DuoHero1ID");

                entity.HasOne(d => d.Hero2)
                    .WithMany(p => p.DuoHero2s)
                    .HasForeignKey(d => d.Hero2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Hero_DuoHero2ID");
            });

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.HasOne(d => d.Identite)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.IdentiteId)
                    .HasConstraintName("Fk_Hero_Identite");

                entity.HasOne(d => d.Pouvoir)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.PouvoirId)
                    .HasConstraintName("Fk_Hero_Pouvoir");
            });

            modelBuilder.Entity<VHeroDetail>(entity =>
            {
                entity.ToView("v_HeroDetails");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
