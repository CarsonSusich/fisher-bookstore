using Microsoft.EntityFrameworkCore;
using Fisher.Bookstore.Api.Models;

namespace Fisher.Bookstore.Data
{

    public class BookstoreContext : IdentityDbContext<Application>
    {

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
            {}

            protected override void OnModelCreating(ModelBuilder builder) =>
            base.OnModelCreating(builder);

            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

    }
}