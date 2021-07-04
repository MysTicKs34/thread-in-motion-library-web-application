using Data.Access.Layer.Classes;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.Layer
{
    public class LibraryWebApplicationContext : DbContext
    {
        public LibraryWebApplicationContext(DbContextOptions<LibraryWebApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<BookTransactions> BookTransactions { get; set; }
        public DbSet<BookTypes> BookTypes { get; set; }
    }
}
