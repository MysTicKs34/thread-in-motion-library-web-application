using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class BookRepository : GenericRepository<Books>, IBookRepository
    {
        public BookRepository(LibraryWebApplicationContext context)
            : base(context)
        { }
    }
}
