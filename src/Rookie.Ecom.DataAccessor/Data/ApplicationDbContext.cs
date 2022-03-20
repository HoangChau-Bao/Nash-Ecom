using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductRating> ProductRating { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //code first
            //db first
            //model first
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "Category");
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable(name: "Product");
            });

            builder.Entity<Brand>(entity =>
            {
                entity.ToTable(name: "Brand");
            });

            builder.Entity<Order>(entity =>
            {
                entity.ToTable(name: "Order");
            });

            builder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable(name: "OrderDetail");
            });

            builder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable(name: "ProductPicture");
            });

            builder.Entity<ProductRating>(entity =>
            {
                entity.ToTable(name: "ProductRating");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<UserAddress>(entity =>
            {
                entity.ToTable(name: "UserAddress");
            });
        }
    }
}
