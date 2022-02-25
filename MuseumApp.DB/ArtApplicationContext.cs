using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MuseumApp.DB
{
    public partial class ArtApplicationContext : DbContext
    {
        public ArtApplicationContext()
        {
        }

        public ArtApplicationContext(DbContextOptions<ArtApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtType> ArtTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ArtType>(entity =>
            {
                entity.ToTable("ArtType", "ArtApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist", "ArtApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bio).HasMaxLength(500);

                entity.Property(e => e.Born).HasMaxLength(50);

                entity.Property(e => e.BornLocation).HasMaxLength(100);

                entity.Property(e => e.Died).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.ToTable("Artwork", "ArtApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.MediumId).HasColumnName("MediumID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Artwork__ArtistI__0C85DE4D");

                entity.HasOne(d => d.LocationNowNavigation)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.LocationNow)
                    .HasConstraintName("FK__Artwork__Locatio__0E6E26BF");

                entity.HasOne(d => d.Medium)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.MediumId)
                    .HasConstraintName("FK__Artwork__MediumI__0D7A0286");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ArtId })
                    .HasName("PK_UserIDArtID");

                entity.ToTable("Likes", "ArtApp");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ArtId).HasColumnName("ArtID");

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.LikesNavigation)
                    .HasForeignKey(d => d.ArtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Likes__ArtID__114A936A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Likes__UserID__10566F31");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "ArtApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LocationUrl)
                    .IsRequired()
                    .HasColumnName("LocationURL");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Location__TypeID__66603565");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType", "ArtApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "ArtApp");

                entity.HasIndex(e => e.Email, "UQ__User__161CF7249108CAA3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FromLocation).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
