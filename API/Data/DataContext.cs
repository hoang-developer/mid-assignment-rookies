using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User
            builder.Entity<User>(e => e.ToTable("User"));
            
            // Category
            builder.Entity<Category>(e => e.ToTable("Categories"));
            
            builder.Entity<Category>()
            .HasMany(c => c.Books)
            .WithOne(k => k.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

            // BookBorrowingRequestDetails
            builder.Entity<BookBorrowingRequestDetails>(e => e.ToTable("BookBorrowingRequestDetails"));

            builder.Entity<BookBorrowingRequestDetails>().HasKey(rb => new{rb.BookBorrowingRequestId, rb.BookId});

            builder.Entity<BookBorrowingRequestDetails>()
            .HasOne<BookBorrowingRequest>(rb => rb.BookBorrowingRequest)
            .WithMany(s => s.RequestDetails)
            .HasForeignKey(rb => rb.BookBorrowingRequestId)
            .IsRequired();

            builder.Entity<BookBorrowingRequestDetails>()
            .HasOne<Book>(rb => rb.Book)
            .WithMany(s => s.RequestDetails)
            .HasForeignKey(rb => rb.BookId)
            .IsRequired();

            // BookBorrowingRequest

            builder.Entity<BookBorrowingRequest>(e => e.ToTable("BookBorrowingRequest"));

            builder.Entity<BookBorrowingRequest>()
            .HasOne(p => p.RequestedBy)
            .WithMany(c => c.BookBorrowingRequests)
            .HasForeignKey(p => p.RequestedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            builder.Entity<BookBorrowingRequest>()
            .HasOne(p => p.StatusUpdateBy)
            .WithMany(c => c.ProcessedRequests)
            .HasForeignKey(p => p.StatusUpdateByUserId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

            // Book
            builder.Entity<Book>(e => e.ToTable("Book"));

            var data = new List<Category>
            {
                new Category{Id = 1, Name="Fantasy"},
                new Category{Id = 2, Name="Sci-Fi"},
                new Category{Id = 3, Name="Biography"},
                new Category{Id = 4, Name="Self-Help"},
                new Category{Id = 5, Name="Reference"},
            };
            builder.Entity<Category>().HasData(data);

        }
    }
}