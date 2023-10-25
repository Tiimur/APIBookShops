using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.EFModels;

public partial class BookstoreChainContext : DbContext
{
    public BookstoreChainContext()
    {
    }

    public BookstoreChainContext(DbContextOptions<BookstoreChainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Bookauthor> Bookauthors { get; set; }

    public virtual DbSet<Bookauthordetail> Bookauthordetails { get; set; }

    public virtual DbSet<Bookbinding> Bookbindings { get; set; }

    public virtual DbSet<Bookgenre> Bookgenres { get; set; }

    public virtual DbSet<Bookgenredetail> Bookgenredetails { get; set; }

    public virtual DbSet<Bookpublisher> Bookpublishers { get; set; }

    public virtual DbSet<Bookseries> Bookseries { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saleproduct> Saleproducts { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Storedproduct> Storedproducts { get; set; }

    public virtual DbSet<Storedproductstatus> Storedproductstatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usercard> Usercards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=timuruksivt12;database=BookstoreChain", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookIsbn).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.BookIdBinding, "BookIdBinding");

            entity.HasIndex(e => e.BookIdPublisher, "BookIdPublisher");

            entity.HasIndex(e => e.BookIdSeries, "BookIdSeries");

            entity.Property(e => e.BookIsbn)
                .ValueGeneratedNever()
                .HasColumnName("BookISBN");
            entity.Property(e => e.BookCirculation).HasDefaultValueSql("'0'");
            entity.Property(e => e.BookDescription)
                .HasMaxLength(1000)
                .HasDefaultValueSql("'Описание отсутствует.'");
            entity.Property(e => e.BookDiscount).HasDefaultValueSql("'0'");
            entity.Property(e => e.BookPrice).HasPrecision(5, 2);
            entity.Property(e => e.BookSize)
                .HasMaxLength(35)
                .HasDefaultValueSql("'0x0'");
            entity.Property(e => e.BookTitle).HasMaxLength(200);
            entity.Property(e => e.BooksQuantityInNetwork).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.BookIdBindingNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookIdBinding)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookIdBinding");

            entity.HasOne(d => d.BookIdPublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookIdPublisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookIdPublisher");

            entity.HasOne(d => d.BookIdSeriesNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookIdSeries)
                .HasConstraintName("BookIdSeries");
        });

        modelBuilder.Entity<Bookauthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PRIMARY");

            entity.ToTable("bookauthors");

            entity.Property(e => e.AuthorName).HasMaxLength(100);
            entity.Property(e => e.AuthorPatronymic).HasMaxLength(100);
            entity.Property(e => e.AuthorSurname).HasMaxLength(100);
        });

        modelBuilder.Entity<Bookauthordetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bookauthordetails");

            entity.HasIndex(e => e.BookAuthorDetailIsbn, "BookAuthorDetailISBN");

            entity.HasIndex(e => e.BookAuthorDetailIdAuthor, "BookAuthorDetailIdAuthor");

            entity.Property(e => e.BookAuthorDetailIsbn).HasColumnName("BookAuthorDetailISBN");

            entity.HasOne(d => d.BookAuthorDetailIdAuthorNavigation).WithMany()
                .HasForeignKey(d => d.BookAuthorDetailIdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookAuthorDetailIdAuthor");

            entity.HasOne(d => d.BookAuthorDetailIsbnNavigation).WithMany()
                .HasForeignKey(d => d.BookAuthorDetailIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookAuthorDetailISBN");
        });

        modelBuilder.Entity<Bookbinding>(entity =>
        {
            entity.HasKey(e => e.BindingId).HasName("PRIMARY");

            entity.ToTable("bookbindings");

            entity.Property(e => e.BindingTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Bookgenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");

            entity.ToTable("bookgenres");

            entity.Property(e => e.GenreTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Bookgenredetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bookgenredetails");

            entity.HasIndex(e => e.BookGenreDetailIsbn, "BookGenreDetailISBN");

            entity.HasIndex(e => e.BookGenreDetailIdGenre, "BookGenreDetailIdGenre");

            entity.Property(e => e.BookGenreDetailIsbn).HasColumnName("BookGenreDetailISBN");

            entity.HasOne(d => d.BookGenreDetailIdGenreNavigation).WithMany()
                .HasForeignKey(d => d.BookGenreDetailIdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookGenreDetailIdGenre");

            entity.HasOne(d => d.BookGenreDetailIsbnNavigation).WithMany()
                .HasForeignKey(d => d.BookGenreDetailIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookGenreDetailISBN");
        });

        modelBuilder.Entity<Bookpublisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PRIMARY");

            entity.ToTable("bookpublishers");

            entity.Property(e => e.PublisherId).ValueGeneratedNever();
            entity.Property(e => e.PublisherCity).HasMaxLength(100);
            entity.Property(e => e.PublisherNumPhone).HasMaxLength(11);
            entity.Property(e => e.PublisherRegeon).HasMaxLength(100);
            entity.Property(e => e.PublisherStreet).HasMaxLength(100);
            entity.Property(e => e.PublisherTitle).HasMaxLength(200);
        });

        modelBuilder.Entity<Bookseries>(entity =>
        {
            entity.HasKey(e => e.SerieId).HasName("PRIMARY");

            entity.ToTable("bookseries");

            entity.Property(e => e.SerieDescription).HasMaxLength(3000);
            entity.Property(e => e.SerieTitle).HasMaxLength(350);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.OrderIdCustomer, "OrderIdCustomer");

            entity.HasIndex(e => e.OrderIdEmployee, "OrderIdEmployee");

            entity.HasIndex(e => e.OrderIdShop, "OrderIdShop");

            entity.HasIndex(e => e.OrderIdStatus, "OrderIdStatus");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.OrderIdCustomerNavigation).WithMany(p => p.OrderOrderIdCustomerNavigations)
                .HasForeignKey(d => d.OrderIdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderIdCustomer");

            entity.HasOne(d => d.OrderIdEmployeeNavigation).WithMany(p => p.OrderOrderIdEmployeeNavigations)
                .HasForeignKey(d => d.OrderIdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderIdEmployee");

            entity.HasOne(d => d.OrderIdShopNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderIdShop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderIdShop");

            entity.HasOne(d => d.OrderIdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderIdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderIdStatus");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orderproducts");

            entity.HasIndex(e => e.OrderBookIsbn, "OrderBookISBN");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.Property(e => e.OrderBookIsbn).HasColumnName("OrderBookISBN");

            entity.HasOne(d => d.OrderBookIsbnNavigation).WithMany()
                .HasForeignKey(d => d.OrderBookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderBookISBN");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderId");
        });

        modelBuilder.Entity<Orderstatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("orderstatuses");

            entity.Property(e => e.StatusTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PRIMARY");

            entity.ToTable("reports");

            entity.HasIndex(e => e.ReportIdShop, "ReportIdShop");

            entity.Property(e => e.ReportDate).HasColumnType("datetime");
            entity.Property(e => e.ReportFile).HasColumnType("blob");

            entity.HasOne(d => d.ReportIdShopNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ReportIdShop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ReportIdShop");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PRIMARY");

            entity.ToTable("sales");

            entity.HasIndex(e => e.SaleIdShop, "SaleIdShop");

            entity.HasIndex(e => e.SaleIdUser, "SaleIdUser");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");

            entity.HasOne(d => d.SaleIdShopNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SaleIdShop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SaleIdShop");

            entity.HasOne(d => d.SaleIdUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SaleIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SaleIdUser");
        });

        modelBuilder.Entity<Saleproduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("saleproducts");

            entity.HasIndex(e => e.SaleBookIsbn, "SaleBookISBN");

            entity.HasIndex(e => e.SaleId, "SaleId");

            entity.Property(e => e.SaleBookIsbn).HasColumnName("SaleBookISBN");

            entity.HasOne(d => d.SaleBookIsbnNavigation).WithMany()
                .HasForeignKey(d => d.SaleBookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SaleBookISBN");

            entity.HasOne(d => d.Sale).WithMany()
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SaleId");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("PRIMARY");

            entity.ToTable("shops");

            entity.Property(e => e.ShopCity).HasMaxLength(100);
            entity.Property(e => e.ShopRegeon).HasMaxLength(100);
            entity.Property(e => e.ShopStreet).HasMaxLength(100);
        });

        modelBuilder.Entity<Storedproduct>(entity =>
        {
            entity.HasKey(e => e.StoredProductId).HasName("PRIMARY");

            entity.ToTable("storedproducts");

            entity.HasIndex(e => e.StoredProductIsbn, "StoredProductISBN");

            entity.HasIndex(e => e.StoredProductIdShop, "StoredProductIdShop");

            entity.HasIndex(e => e.StoredProductIdStatus, "StoredProductIdStatus");

            entity.Property(e => e.StoredProductDateChange).HasColumnType("datetime");
            entity.Property(e => e.StoredProductIsbn).HasColumnName("StoredProductISBN");

            entity.HasOne(d => d.StoredProductIdShopNavigation).WithMany(p => p.Storedproducts)
                .HasForeignKey(d => d.StoredProductIdShop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StoredProductIdShop");

            entity.HasOne(d => d.StoredProductIdStatusNavigation).WithMany(p => p.Storedproducts)
                .HasForeignKey(d => d.StoredProductIdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StoredProductIdStatus");

            entity.HasOne(d => d.StoredProductIsbnNavigation).WithMany(p => p.Storedproducts)
                .HasForeignKey(d => d.StoredProductIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StoredProductISBN");
        });

        modelBuilder.Entity<Storedproductstatus>(entity =>
        {
            entity.HasKey(e => e.StoredProductStatusId).HasName("PRIMARY");

            entity.ToTable("storedproductstatuses");

            entity.Property(e => e.StoredProductStatusTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserEmail, "UserEmail_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserIdRole, "UserIdRole");

            entity.HasIndex(e => e.UserLogin, "UserLogin_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserNumPhone, "UserNumPhone_UNIQUE").IsUnique();

            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserLogin).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserNumPhone).HasMaxLength(11);
            entity.Property(e => e.UserPassword).HasMaxLength(100);
            entity.Property(e => e.UserPatronymic).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(50);

            entity.HasOne(d => d.UserIdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserIdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserIdRole");
        });

        modelBuilder.Entity<Usercard>(entity =>
        {
            entity.HasKey(e => e.UserCardId).HasName("PRIMARY");

            entity.ToTable("usercards");

            entity.HasIndex(e => e.UserCardBookIsbn, "UserCardBookISBN");

            entity.HasIndex(e => e.UserCardIdUser, "UserCardUserId");

            entity.Property(e => e.UserCardBookIsbn).HasColumnName("UserCardBookISBN");

            entity.HasOne(d => d.UserCardBookIsbnNavigation).WithMany(p => p.Usercards)
                .HasForeignKey(d => d.UserCardBookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserCardBookISBN");

            entity.HasOne(d => d.UserCardIdUserNavigation).WithMany(p => p.Usercards)
                .HasForeignKey(d => d.UserCardIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserCardUserId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
