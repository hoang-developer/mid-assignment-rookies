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

            builder.Entity<BookBorrowingRequestDetails>().HasKey(rb => new { rb.BookBorrowingRequestId, rb.BookId });

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

            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    Summary = "The saga mocks modern society with humour and cynicism and has as its hero a hapless, deeply ordinary Englishman (Arthur Dent) who unexpectedly finds himself adrift in a universe characterized by randomness and absurdity.",
                    CategoryId = 2,
                },
                new Book
                {
                    Id = 2,
                    Name = "Ready Player One",
                    Author = "Ernest Cline",
                    Summary = "The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.",
                    CategoryId = 2,
                },
                new Book
                {
                    Id = 3,
                    Name = "Nineteen Eighty-Four",
                    Author = "George Orwell",
                    Summary = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                    CategoryId = 1,
                },
                new Book
                {
                    Id = 4,
                    Name = "Harry Potter and the Philosopher's Stone",
                    Author = "J. K. Rowling",
                    Summary = "On his 11th birthday, Harry receives a letter inviting him to study magic at the Hogwarts School of Witchcraft and Wizardry. Harry discovers that not only is he a wizard, but he is a famous one. He meets two best friends, Ron Weasley and Hermione Granger, and makes his first enemy, Draco Malfoy.",
                    CategoryId = 1,
                }
            );
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}