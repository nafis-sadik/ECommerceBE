using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;

#nullable disable

namespace DBAccess
{
    public partial class BlueBirdDBContext : DbContext
    {
        string ConnectionString = "";

        public BlueBirdDBContext(string _connectionString = "server=localhost;User Id=root;Database=BlueBirdDB;Port=3306;")
        {
            ConnectionString = _connectionString;
            base.Database.EnsureCreated();
        }

        public BlueBirdDBContext(DbContextOptions<BlueBirdDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CommonCode> CommonCodes { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryLog> InventoryLogs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<ProductReturn> ProductReturns { get; set; }
        public virtual DbSet<ProductsInOrder> ProductsInOrders { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopProduct> ShopProducts { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CategoryName).HasMaxLength(10);

                entity.Property(e => e.CategoryNameBangla).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShopId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ShopID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Categories_Shops");
            });

            modelBuilder.Entity<CommonCode>(entity =>
            {
                entity.ToTable("CommonCode");

                entity.Property(e => e.CommonCodeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NameBangla).HasMaxLength(50);

                entity.Property(e => e.NameEnglish).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventory");

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pk)
                    .HasConstraintName("FK_Inventory_ShopProducts");
            });

            modelBuilder.Entity<InventoryLog>(entity =>
            {
                entity.ToTable("InventoryLog");

                entity.Property(e => e.InventoryLogId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.QuantityUpdateType).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TransactionDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionQuantity).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.InventoryLogNavigation)
                    .WithOne(p => p.InventoryLog)
                    .HasForeignKey<InventoryLog>(d => d.InventoryLogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLog_ShopProducts");

                entity.HasOne(d => d.QuantityUpdateTypeNavigation)
                    .WithMany(p => p.InventoryLogs)
                    .HasForeignKey(d => d.QuantityUpdateType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLog_CommonCode");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentOption).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalOrderValue).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductAttribute).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ProductImg>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.ProductImgLocation).HasMaxLength(50);

                entity.HasOne(d => d.PkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pk)
                    .HasConstraintName("FK_ProductImgs_ShopProducts");
            });

            modelBuilder.Entity<ProductReturn>(entity =>
            {
                entity.ToTable("ProductReturn");

                entity.Property(e => e.ProductReturnId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.ReturnQuantity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ReturnRequestDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductReturns)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReturn_Orders");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany(p => p.ProductReturns)
                    .HasForeignKey(d => d.Pk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReturn_ShopProducts");
            });

            modelBuilder.Entity<ProductsInOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductsInOrder");

                entity.Property(e => e.OrderId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInOrder_Orders");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInOrder_ShopProducts");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.ShopId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ShopID");

                entity.Property(e => e.ShopLogoLocation).HasMaxLength(50);

                entity.Property(e => e.ShopName).HasMaxLength(50);
            });

            modelBuilder.Entity<ShopProduct>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.HasIndex(e => e.ProductId, "IX_ShopProducts");

                entity.Property(e => e.Pk)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PK");

                entity.Property(e => e.ProductId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductPrice).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShopId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ShopID");

                entity.Property(e => e.Stock).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SubCategoryId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VendorId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopProducts_Products");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopProducts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_ShopProducts_Shops1");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.ShopProducts)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopProducts_SubCategories");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ShopProducts)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_ShopProducts_Vendors");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CategoryId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SubCategoryName).HasMaxLength(50);

                entity.Property(e => e.SubCategoryNameBangla).HasMaxLength(10);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SubCategories_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserTypeId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_Users_CommonCode");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShopId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ShopID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendors_Shops");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
