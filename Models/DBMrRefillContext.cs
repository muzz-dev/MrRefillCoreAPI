using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrRefillCoreAPI.Models
{
    public partial class DBMrRefillContext : DbContext
    {
        public DBMrRefillContext()
        {
        }

        public DBMrRefillContext(DbContextOptions<DBMrRefillContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AssignRequest> AssignRequest { get; set; }
        public virtual DbSet<Cartridge> Cartridge { get; set; }
        public virtual DbSet<CartridgeType> CartridgeType { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<ExchangeCartridge> ExchangeCartridge { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Problem> Problem { get; set; }
        public virtual DbSet<ProductMaster> ProductMaster { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseReturn> PurchaseReturn { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesDetails> SalesDetails { get; set; }
        public virtual DbSet<SalesReturn> SalesReturn { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MUZZ-PC\\SQLEXPRESS;Initial Catalog=DBMrRefill;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.AreaName)
                    .HasColumnName("areaName")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AssignRequest>(entity =>
            {
                entity.HasKey(e => e.AssignId);

                entity.Property(e => e.AssignId).HasColumnName("assignId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeId).HasColumnName("exchangeId");

                entity.Property(e => e.IsPay)
                    .HasColumnName("isPay")
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("paymentMode")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Exchange)
                    .WithMany(p => p.AssignRequest)
                    .HasForeignKey(d => d.ExchangeId)
                    .HasConstraintName("FK_AssignRequest_ExchangeCartridge");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssignRequest)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AssignRequest_User");
            });

            modelBuilder.Entity<Cartridge>(entity =>
            {
                entity.Property(e => e.CartridgeId).HasColumnName("cartridgeId");

                entity.Property(e => e.CartridgeName)
                    .HasColumnName("cartridgeName")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageUrl")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.ModelId).HasColumnName("modelId");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Cartridge_Model");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Cartridge_CartridgeType");
            });

            modelBuilder.Entity<CartridgeType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExchangeCartridge>(entity =>
            {
                entity.HasKey(e => e.ExchangeId);

                entity.Property(e => e.ExchangeId).HasColumnName("exchangeId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.CartridgeId).HasColumnName("cartridgeId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.ProblemId).HasColumnName("problemId");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("requestDate")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.ExchangeCartridge)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_ExchangeCartridge_Area");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.ExchangeCartridge)
                    .HasForeignKey(d => d.CartridgeId)
                    .HasConstraintName("FK_ExchangeCartridge_Cartridge");

                entity.HasOne(d => d.Problem)
                    .WithMany(p => p.ExchangeCartridge)
                    .HasForeignKey(d => d.ProblemId)
                    .HasConstraintName("FK_ExchangeCartridge_Problem");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExchangeCartridge)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExchangeCartridge_User");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.FeedbackText)
                    .HasColumnName("feedbackText")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_User");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId).HasColumnName("modelId");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.ModelName)
                    .HasColumnName("modelName")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Problem>(entity =>
            {
                entity.Property(e => e.ProblemId).HasColumnName("problemId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .IsUnicode(false);

                entity.Property(e => e.ProblemName)
                    .HasColumnName("problemName")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageUrl")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductMaster)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductMaster_Category");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchaseDate")
                    .IsUnicode(false);

                entity.Property(e => e.TotalPayment)
                    .HasColumnName("totalPayment")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Purchase_User");
            });

            modelBuilder.Entity<PurchaseDetails>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseId, e.ProductId });

                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.BuyPrice)
                    .HasColumnName("buyPrice")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDetails_ProductMaster");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDetails_Purchase");
            });

            modelBuilder.Entity<PurchaseReturn>(entity =>
            {
                entity.Property(e => e.PurchaseReturnId).HasColumnName("purchaseReturnId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .IsUnicode(false);

                entity.Property(e => e.ReturnAmount)
                    .HasColumnName("returnAmount")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseReturn)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PurchaseReturn_ProductMaster");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseReturn)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK_PurchaseReturn_Purchase");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.SalesId).HasColumnName("salesId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.SalesDate)
                    .HasColumnName("salesDate")
                    .IsUnicode(false);

                entity.Property(e => e.TotalPayment)
                    .HasColumnName("totalPayment")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Sales_User");
            });

            modelBuilder.Entity<SalesDetails>(entity =>
            {
                entity.HasKey(e => new { e.SalesId, e.ProductId });

                entity.Property(e => e.SalesId).HasColumnName("salesId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsUnicode(false);

                entity.Property(e => e.SalesPrice)
                    .HasColumnName("salesPrice")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesDetails_ProductMaster");

                entity.HasOne(d => d.Sales)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.SalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesDetails_Sales");
            });

            modelBuilder.Entity<SalesReturn>(entity =>
            {
                entity.Property(e => e.SalesReturnId).HasColumnName("salesReturnId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .IsUnicode(false);

                entity.Property(e => e.ReturnAmount)
                    .HasColumnName("returnAmount")
                    .IsUnicode(false);

                entity.Property(e => e.SalesId).HasColumnName("salesId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesReturn)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_SalesReturn_ProductMaster");

                entity.HasOne(d => d.Sales)
                    .WithMany(p => p.SalesReturn)
                    .HasForeignKey(d => d.SalesId)
                    .HasConstraintName("FK_SalesReturn_Sales");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TranscationId);

                entity.Property(e => e.TranscationId).HasColumnName("transcationId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");

                entity.Property(e => e.PurchaseReturnId).HasColumnName("purchaseReturnId");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .IsUnicode(false);

                entity.Property(e => e.SalesId).HasColumnName("salesId");

                entity.Property(e => e.SalesReturnId).HasColumnName("salesReturnId");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transactionDate")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .IsUnicode(false);

                entity.Property(e => e.GstNumber)
                    .HasColumnName("gstNumber")
                    .IsUnicode(false);

                entity.Property(e => e.IsBlock)
                    .HasColumnName("isBlock")
                    .IsUnicode(false);

                entity.Property(e => e.IsVerify)
                    .HasColumnName("isVerify")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Otp)
                    .HasColumnName("otp")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.RegisterBy)
                    .HasColumnName("registerBy")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_User_Area");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
