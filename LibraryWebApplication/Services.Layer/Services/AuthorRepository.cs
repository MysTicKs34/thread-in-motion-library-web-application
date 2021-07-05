using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class AuthorRepository : GenericRepository<Authors>, IAuthorRepository
    {
        public AuthorRepository(LibraryWebApplicationContext context)
           : base(context)
        { }
    }
}
