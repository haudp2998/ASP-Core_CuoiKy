using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP_Core_CuoiKy.Models
{
    public partial class OnlineShopContext : DbContext
    {
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentTag> ContentTag { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

   

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.MetaDescriptions).HasColumnType("nchar(250)");

                entity.Property(e => e.MetaKeywords).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescriptions).HasColumnType("nchar(250)");

                entity.Property(e => e.MetaKeywords).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SeoTitle).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("ntext");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescriptions).HasColumnType("nchar(250)");

                entity.Property(e => e.MetaKeywords).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.TopHot).HasColumnType("datetime");

                entity.Property(e => e.ViewCount).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ContentTag>(entity =>
            {
                entity.HasKey(e => new { e.ContentId, e.TagId });

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => new { e.UserGroupId, e.RoleId });

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("UserGroupID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasColumnType("ntext");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.Target).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ShipAddress).HasMaxLength(50);

                entity.Property(e => e.ShipEmail).HasMaxLength(50);

                entity.Property(e => e.ShipMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipName).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId });

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.IncludedVat).HasColumnName("IncludedVAT");

                entity.Property(e => e.MetaDescriptions).HasColumnType("nchar(250)");

                entity.Property(e => e.MetaKeywords).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MoreImages).HasColumnType("xml");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.TopHot).HasColumnType("datetime");

                entity.Property(e => e.ViewCount).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.MetaDescriptions).HasColumnType("nchar(250)");

                entity.Property(e => e.MetaKeywords).HasMaxLength(250);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SeoTitle).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('MEMBER')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
