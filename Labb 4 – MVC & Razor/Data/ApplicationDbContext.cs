using Labb_4___MVC___Razor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;


namespace Labb_4___MVC___Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCustomer> BookCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCustomer>()
    .HasKey(bc => bc.BookCustomerId); // Sätt BookCustomerId som primärnyckel

            // Konfigurera relationen mellan Customer och Book
            modelBuilder.Entity<BookCustomer>()
                .HasOne(bc => bc.Customer)
                .WithMany(c => c.BorrowedBooks)
                .HasForeignKey(bc => bc.FkCustomerId);

            modelBuilder.Entity<BookCustomer>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Borrowers)
                .HasForeignKey(bc => bc.FkBookId);

            // Lägg till exempeldata för Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Anna Persson",
                    Email = "anna.persson@example.com",
                    PhoneNumber = "0768839487"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Peter Johannson",
                    Email = "peter.johansson@example.com",
                    PhoneNumber = "0728839748"
                }
            );

            // Lägg till exempeldata för Book
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    BookTitle = "The Ghost",
                    IsBorrowed = true
                },
                new Book
                {
                    BookId = 2,
                    BookTitle = "Forgotten",
                    IsBorrowed = false
                }
            );

            // Lägg till exempeldata för BookCustomer för att simulera lån
            modelBuilder.Entity<BookCustomer>().HasData(
                new BookCustomer
                {
                    BookCustomerId = 1,
                    FkCustomerId = 1,
                    FkBookId = 1,
                  
                   
                },
                new BookCustomer
                {
                    BookCustomerId = 2,
                    FkCustomerId = 2,
                    FkBookId = 2,
                    
                    
                }
            );
        }



    }


}
