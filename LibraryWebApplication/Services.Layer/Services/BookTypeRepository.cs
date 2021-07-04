using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class BookTypeRepository: GenericRepository<BookTypes>, IBookTypeRepository
    {
        public BookTypeRepository(LibraryWebApplicationContext context)
            : base(context)
        { }
    }
}
