using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {
        }

        public DbSet<Product> DbProducts { get; set; }
        public DbSet<ProductReview> DbProductsReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("TB_PRODUCTS");
                p.HasKey(p => p.Id);
                p.Property(p => p.Title).HasMaxLength(150).IsRequired().HasColumnName("TITLE");
                p.Property(p => p.Description).HasMaxLength(250).IsRequired().HasColumnName("DESCRIPTION");
                p.Property(p => p.Price).IsRequired().HasColumnName("PRICE");
                p.Property(p => p.RegisteredAt).IsRequired().HasColumnName("REGISTERED_AT");

                p.HasMany(pp => pp.ProductReviews)
                .WithOne()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                //.OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductReview>(pr =>
            {
                pr.ToTable("TB_PRODUCT_REVIEW");
                pr.HasKey(pr => pr.Id);
                pr.Property(pr => pr.Author).HasMaxLength(50).IsRequired().HasColumnName("AUTHOR");
                pr.Property(pr => pr.Rating).IsRequired().HasColumnName("RATING");
                pr.Property(pr => pr.Comments).HasMaxLength(250).IsRequired().HasColumnName("COMMENTS");
                pr.Property(pr => pr.RegisteredAt).IsRequired().HasColumnName("REGISTERED_AT");

            });
        }
    }
}
