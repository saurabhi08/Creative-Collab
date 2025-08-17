using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindAndMarket.Models;

namespace MindAndMarket.Data
{
    public class MindAndMarketContext : IdentityDbContext<IdentityUser>
    {
        public MindAndMarketContext(DbContextOptions<MindAndMarketContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Aisle> Aisles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ReadingSpot> ReadingSpots { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationships
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedProducts)
                .WithMany(p => p.RelatedBooks)
                .UsingEntity(j => j.ToTable("BookProducts"));

            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedDepartments)
                .WithMany(d => d.RelatedBooks)
                .UsingEntity(j => j.ToTable("BookDepartments"));

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Events)
                .WithMany(e => e.RelatedBooks)
                .UsingEntity(j => j.ToTable("BookEvents"));

            // Configure one-to-many relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Aisle)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.AisleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 