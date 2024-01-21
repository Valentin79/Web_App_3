using Microsoft.EntityFrameworkCore;
using Seminar_3.Models;

namespace Seminar_3
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext()
        {

        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        /*
         dotnet ef migrations add InitialCreate --context AppDbContext
         dotnet ef database update
        */
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Price).IsRequired();

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Products);

                entity.HasOne(x => x.Storage)
                    .WithMany(x => x.Products);
            });

            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            modelBuilder.Entity<StorageEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();
            });
        }
    }
}
