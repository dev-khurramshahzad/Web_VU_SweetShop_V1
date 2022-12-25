using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SweetShop.Models
{
    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=dbModel")
        {
        }

        public virtual DbSet<Cat_Shop_Assignment> Cat_Shop_Assignment { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Item_Shop_Assignment> Item_Shop_Assignment { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Cat_Shop_Assignment)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CatFID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CatFID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.OrderDetails)
                .WithOptional(e => e.Item)
                .HasForeignKey(e => e.ItemFID);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.OrderFID);

            modelBuilder.Entity<Shop>()
                .Property(e => e.BranchCode)
                .IsFixedLength();

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Cat_Shop_Assignment)
                .WithOptional(e => e.Shop)
                .HasForeignKey(e => e.ShopFID);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Shop)
                .HasForeignKey(e => e.ShopFID);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Shop)
                .HasForeignKey(e => e.ShopFID);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Shop)
                .HasForeignKey(e => e.ShopFID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserFID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserFID);
        }
    }
}
