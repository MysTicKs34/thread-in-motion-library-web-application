using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class TypeRepository : GenericRepository<Types>, ITypeRepository
    {
        public TypeRepository(LibraryWebApplicationContext context)
            : base(context)
        { }
    }
}
