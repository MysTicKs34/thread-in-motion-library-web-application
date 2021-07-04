using Data.Access.Layer;
using Data.Access.Layer.Classes;
using Services.Layer.Abstraction;

namespace Services.Layer.Services
{
    public class MemberRepository : GenericRepository<Members>, IMemberRepository
    {
        public MemberRepository(LibraryWebApplicationContext context)
            : base(context)
        { }
    }
}
