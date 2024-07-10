using Bibliotopia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bibliotopia.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Books>().HasKey(ab => new
            {
                ab.AuthorId,
                ab.BookId
            });
            modelBuilder.Entity<Author_Books>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorsBooks)
                .HasForeignKey(ab => ab.BookId);
            modelBuilder.Entity<Author_Books>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.Authors_Books)
                .HasForeignKey(ab => ab.AuthorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Books> AuthorsBooks { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
