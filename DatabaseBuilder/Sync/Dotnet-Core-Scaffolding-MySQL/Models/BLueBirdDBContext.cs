using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dotnet_Core_Scaffolding_MySQL.Models
{
    public partial class BLueBirdDBContext : DbContext
    {
        public BLueBirdDBContext()
        {
        }

        public BLueBirdDBContext(DbContextOptions<BLueBirdDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Commoncode> Commoncodes { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Inventorylog> Inventorylogs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productimg> Productimgs { get; set; }
        public virtual DbSet<Productreturn> Productreturns { get; set; }
        public virtual DbSet<Productsinorder> Productsinorders { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Shopproduct> Shopproducts { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;User Id=root;Database=BLueBirdDB;Port=3306;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.ShopId, "IX_Categories_ShopID");

                entity.Property(e => e.CategoryId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CategoryNameBangla)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopId)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("ShopID")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Categories_Shops");
            });

            modelBuilder.Entity<Commoncode>(entity =>
            {
                entity.ToTable("commoncode");

                entity.Property(e => e.CommonCodeId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.NameBangla)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("inventory");

                entity.HasIndex(e => e.Pk, "IX_Inventory_PK");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pk)
                    .HasConstraintName("FK_Inventory_ShopProducts");
            });

            modelBuilder.Entity<Inventorylog>(entity =>
            {
                entity.ToTable("inventorylog");

                entity.HasIndex(e => e.QuantityUpdateType, "IX_InventoryLog_QuantityUpdateType");

                entity.Property(e => e.InventoryLogId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK");

                entity.Property(e => e.QuantityUpdateType).HasColumnType("decimal(18,0)");

                entity.Property(e => e.TransactionDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionQuantity).HasColumnType("decimal(18,0)");

                entity.HasOne(d => d.InventoryLog)
                    .WithOne(p => p.Inventorylog)
                    .HasForeignKey<Inventorylog>(d => d.InventoryLogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLog_ShopProducts");

                entity.HasOne(d => d.QuantityUpdateTypeNavigation)
                    .WithMany(p => p.Inventorylogs)
                    .HasForeignKey(d => d.QuantityUpdateType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLog_CommonCode");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                entity.Property(e => e.OrderId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.DeliveryLocation).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrderDescription).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentOption)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalOrderValue)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).HasColumnType("decimal(18,0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductAttribute)
                    .HasColumnType("longtext")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Productimg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productimgs");

                entity.HasIndex(e => e.Pk, "IX_ProductImgs_PK");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductImgLocation)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Pk)
                    .HasConstraintName("FK_ProductImgs_ShopProducts");
            });

            modelBuilder.Entity<Productreturn>(entity =>
            {
                entity.ToTable("productreturn");

                entity.HasIndex(e => e.OrderId, "IX_ProductReturn_OrderId");

                entity.HasIndex(e => e.Pk, "IX_ProductReturn_PK");

                entity.Property(e => e.ProductReturnId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.OrderId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK");

                entity.Property(e => e.ReturnQuantity)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Productreturns)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReturn_Orders");

                entity.HasOne(d => d.PkNavigation)
                    .WithMany(p => p.Productreturns)
                    .HasForeignKey(d => d.Pk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReturn_ShopProducts");
            });

            modelBuilder.Entity<Productsinorder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productsinorder");

                entity.HasIndex(e => e.OrderId, "IX_ProductsInOrder_OrderId");

                entity.HasIndex(e => e.Pk, "IX_ProductsInOrder_PK");

                entity.Property(e => e.OrderId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

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
                entity.ToTable("shops");

                entity.Property(e => e.ShopId)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("ShopID");

                entity.Property(e => e.ShopLogoLocation)
                    .HasColumnType("longtext")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Shopproduct>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("PRIMARY");

                entity.ToTable("shopproducts");

                entity.HasIndex(e => e.ProductId, "IX_ShopProducts");

                entity.HasIndex(e => e.ShopId, "IX_ShopProducts_ShopID");

                entity.HasIndex(e => e.SubCategoryId, "IX_ShopProducts_SubCategoryId");

                entity.HasIndex(e => e.VendorId, "IX_ShopProducts_VendorId");

                entity.Property(e => e.Pk)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("PK");

                entity.Property(e => e.ProductDescription).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopId)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("ShopID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Stock)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SubCategoryId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.VendorId)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Shopproducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopProducts_Products");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Shopproducts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_ShopProducts_Shops1");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Shopproducts)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopProducts_SubCategories");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Shopproducts)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_ShopProducts_Vendors");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategories");

                entity.HasIndex(e => e.CategoryId, "IX_SubCategories_CategoryId");

                entity.Property(e => e.SubCategoryId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SubCategoryNameBangla)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SubCategories_Categories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserTypeId, "IX_Users_UserTypeId");

                entity.Property(e => e.UserId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.Password).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProfilePicLoc).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserTypeId)
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_Users_CommonCode");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendors");

                entity.HasIndex(e => e.ShopId, "IX_Vendors_ShopID");

                entity.Property(e => e.VendorId).HasColumnType("decimal(18,0)");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Remarks).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopId)
                    .HasColumnType("decimal(18,0)")
                    .HasColumnName("ShopID");

                entity.Property(e => e.VendorAddress).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.VendorName).HasDefaultValueSql("'NULL'");

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
